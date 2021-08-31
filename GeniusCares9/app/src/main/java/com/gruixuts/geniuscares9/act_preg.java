package com.gruixuts.geniuscares9;

import android.content.Context;
import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Environment;
import android.os.SystemClock;
import android.speech.RecognizerIntent;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;


public class act_preg extends AppCompatActivity {
    //List<classDiccionari> Llista;
    SimpleDateFormat frmtData = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
    GestorDB db;
    Integer Actual;
    classDiccionari mItem;
    classProves Prova = null;
    String TipusProva;
    int NumProva;
    classResposta resposta;
    classResposta avaluacioInici;
    classResposta avaluacioFinal;
    boolean FetAmbVeu = false;
    String Resultat;

    //String Filtre="";
    //Integer IdEntDic;
    Long TempsIniciProva;
    Long TempsProva;
    Long TempsIniciPregunta;
    Long TempsPregunta;

    private String CarpetaImatges = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Imatges";
    private String CarpetaImatgesItem;  // La carpeta del Item actual
    private Integer numImatge;
    private String nomsImatge[];

    protected static final int REQUEST_CODE = 11;
    protected static final int SPEECH_REQUEST_CODE = 13;
    protected static final String ARG_NUM_PROVA = "tp";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_preg);
        NumProva = Integer.parseInt(getIntent().getStringExtra(ARG_NUM_PROVA));
        db=new GestorDB(getApplicationContext());
        db.open();
        Prova = db.getProva(NumProva);
        Actual=0;
        mItem = objLlistaTrobats.ITEMS.get(Actual);
        TempsIniciProva = SystemClock.currentThreadTimeMillis();
        TempsProva=Prova.getTemps();  // Per si ja portava temps
        CarpetaImatges = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Imatges";
        //PreguntaSeguent();
        if (objLlistaTrobats.ITEMS.size()==0) {
            Global.MissatgeError("No hi ha cap pregunta",this);
            finish();
        }
        CarregaItem(mItem);
        CarregaResp(new classResposta());
    }

    private void CarregaItem(classDiccionari item) {
        assert (item != null);
        ((TextView) findViewById(R.id.txtPregCompta)).setText("Actual: " + (Actual + 1) + "/" + objLlistaTrobats.ITEMS.size());
        // Imatges:
        if (item.getImatges() != null) {
            assert (item.getImatges().length() > 0);
            CarpetaImatgesItem = CarpetaImatges + "/" + item.getImatges();
            File carpeta = new File(CarpetaImatgesItem);
            if (!carpeta.exists()) { // Crear-la
                Global.MissatgeError("La cerpeta d'immatges " + CarpetaImatgesItem + " no existeix",this);
                numImatge = 0;
                //carpeta.mkdirs();
                nomsImatge = new String[0];

            } else {
                nomsImatge = carpeta.list();
            }
            if (nomsImatge.length != 0) {
                numImatge = 1;
                Drawable d = Drawable.createFromPath(CarpetaImatgesItem + "/" + nomsImatge[numImatge - 1]);
                ((ImageView) findViewById(R.id.imgImatges)).setImageDrawable(d);
            } else {
                numImatge = 0;
            }
        } else {
            CarpetaImatgesItem = "";
            numImatge = 0;
            nomsImatge = new String[0];
        }
        TempsIniciPregunta = SystemClock.currentThreadTimeMillis();
    }
    public void CarregaResp(classResposta resp) {
        ((TextView) findViewById(R.id.edtPregNom)).setText(resp.getNom());
        ((TextView) findViewById(R.id.edtPregCognom1)).setText(resp.getCognom1());
        ((TextView) findViewById(R.id.edtPregCognom2)).setText(resp.getCognom2());
        ((TextView) findViewById(R.id.edtPregCurs)).setText(resp.getCurs());
        FetAmbVeu = false;
    }

    // Imatges:

    public void fotoSeguent(View view) {
        if ((numImatge < nomsImatge.length) && (numImatge >0) ) {
            numImatge++;
            Drawable d = Drawable.createFromPath(CarpetaImatges + "/" + mItem.getImatges() + "/" + nomsImatge[numImatge - 1]);
            ((ImageView) findViewById(R.id.imgImatges)).setImageDrawable(d);
        }
    }
    public void fotoAnterior(View view) {
        if (numImatge > 1 ) {
            numImatge--;
            Drawable d = Drawable.createFromPath(CarpetaImatges + "/" + mItem.getImatges() + "/" + nomsImatge[numImatge - 1]);
            ((ImageView) findViewById(R.id.imgImatges)).setImageDrawable(d);
        }
    }


    public void cmd_Veu (View view) {
        Intent intent = new Intent(RecognizerIntent.ACTION_RECOGNIZE_SPEECH);
        intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE_MODEL,
                RecognizerIntent.LANGUAGE_MODEL_FREE_FORM);
        // Start the activity, the intent will be populated with the speech text
        startActivityForResult(intent, SPEECH_REQUEST_CODE);

    }

    public classResposta Tradueix(List<String> llistaS) {
        classResposta Rslt;
        String Frase = llistaS.get(0);
        String[] llista = Frase.replace('-',' ').split(" ");
        Rslt = new classResposta();
        if (llista.length==5) {
            if (("0123456789").indexOf( llista[3])!=-1) {
                Rslt.setNom(llista[0]);
                Rslt.setCognom1(llista[1]);
                Rslt.setCognom2(llista[2]);
                Rslt.setCurs(llista[3] + " " + llista[3] );
            }
        }
        if (llista.length==4) {
                Rslt.setNom(llista[0]);
                Rslt.setCognom1(llista[1]);
                Rslt.setCognom2(llista[2]);
                Rslt.setCurs(llista[3]);
        }
        return Rslt;
    }



    public void cmd_Ok(View view) {

        avaluacioInici = new classResposta();
        resposta = new classResposta();
        resposta.setNom(((TextView) findViewById(R.id.edtPregNom)).getText().toString());
        resposta.setCognom1(((TextView) findViewById(R.id.edtPregCognom1)).getText().toString());
        resposta.setCognom2(((TextView) findViewById(R.id.edtPregCognom2)).getText().toString());
        resposta.setCurs(((TextView) findViewById(R.id.edtPregCurs)).getText().toString());

        avaluacioInici.setNom(Avalua(mItem.getNom(),resposta.getNom()));
        avaluacioInici.setCognom1(Avalua(mItem.getCognom1(),resposta.getCognom1()));
        avaluacioInici.setCognom2(Avalua(mItem.getCognom2(),resposta.getCognom2()));
        avaluacioInici.setCurs(Avalua(mItem.getCurs(),resposta.getCurs()));

        TempsPregunta = SystemClock.currentThreadTimeMillis() - TempsIniciPregunta;

        Intent intent = new Intent(act_preg.this, act_preg_aval.class);
        intent.putExtra( act_preg_aval.ARG_ID_ITEM, Actual.toString());
        intent.putExtra(act_preg_aval.ARG_RESP, resposta.toString());
        intent.putExtra(act_preg_aval.ARG_AVAL, avaluacioInici.toString());
        startActivityForResult(intent, REQUEST_CODE);
    }

    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        //super.onActivityResult(requestCode, resultCode, data);
        classResposta rsp;
        if (requestCode == REQUEST_CODE) {
            if (resultCode == RESULT_OK) {
                // Todo: Registrar resultats
                String results = data.getStringExtra(act_preg_aval.ARG_CORR);
                avaluacioFinal = new classResposta(results);
                RegistraResposta();
                Seguent();
                return; // Temporal
            } else {
                return;
            }
        } else if (requestCode == SPEECH_REQUEST_CODE) {    // Reconeixement de veu
            if (resultCode == RESULT_OK) {
                List<String> results = data.getStringArrayListExtra(
                        RecognizerIntent.EXTRA_RESULTS);
                rsp=Tradueix(results);
                CarregaResp(rsp);
                FetAmbVeu=true;
            }
            super.onActivityResult(requestCode, resultCode, data);

        }
    }


    private String Avalua(String correcta, String resposta) {
        correcta = correcta.toLowerCase().trim();
        resposta = resposta.toLowerCase().trim();
        if (correcta.equals(resposta)) {
            return classResultats.VAL_PERFECTE;
        } else if (resposta.length() == 0) {
            return classResultats.VAL_OBLIDAT;
        } else {
            return classResultats.VAL_REPASSAR;
        }
    }


    public act_preg() {
        super();
    }

    private void RegistraResposta() {

        classResultats Result;
        classDiccionari Item;
        Calendar cal = new GregorianCalendar(TimeZone.getTimeZone("Europe/Madrid"));
        classResposta combinada= new classResposta();

        combinada.setNom(avaluacioInici.getNom()+"-" + avaluacioFinal.getNom());
        combinada.setNom(avaluacioInici.getCognom1()+"-" + avaluacioFinal.getCognom1());
        combinada.setNom(avaluacioInici.getCognom2()+"-" + avaluacioFinal.getCognom2());
        combinada.setNom(avaluacioInici.getCurs()+"-" + avaluacioFinal.getCurs());

        if (avaluacioFinal.getNom().equals(classResultats.VAL_PERFECTE) &&
                avaluacioFinal.getCognom1().equals(classResultats.VAL_PERFECTE) &&
                avaluacioFinal.getCurs().equals(classResultats.VAL_PERFECTE))
            Resultat = classResultats.VAL_PERFECTE;
        else if ((avaluacioFinal.getNom().equals(classResultats.VAL_PERFECTE) || avaluacioFinal.getNom().equals(classResultats.VAL_REPASSAR) ) &&
                (avaluacioFinal.getCognom1().equals(classResultats.VAL_PERFECTE)  || avaluacioFinal.getCognom1().equals(classResultats.VAL_REPASSAR) ) &&
                (avaluacioFinal.getCurs().equals(classResultats.VAL_PERFECTE)  || avaluacioFinal.getCurs().equals(classResultats.VAL_REPASSAR) ) )
            Resultat = classResultats.VAL_REPASSAR;
        else if (!avaluacioFinal.getNom().equals(classResultats.VAL_OBLIDAT) &&
                !avaluacioFinal.getCognom1().equals(classResultats.VAL_OBLIDAT) &&
                !avaluacioFinal.getCurs().equals(classResultats.VAL_OBLIDAT) )
            Resultat = classResultats.VAL_APRES;
        else
            Resultat = classResultats.VAL_OBLIDAT;




        //Crea Resultat
        Result = new classResultats(
                cal.getTime(),
                NumProva,
                mItem.getId(),
                mItem.getNextTipus(),
                mItem.getNextData(),
                resposta.toString(),
                (FetAmbVeu ? "Veu":"Teclat") + "," + combinada.toString(),
                TempsPregunta,
                Resultat
                );

        // Actualitza Prova
        Prova.setTemps(Prova.getTemps()+ TempsPregunta);
        Prova.setNumRespostes(Prova.getNumRespostes()+1);

        db.open();
        db.insResultat(Result);
        db.actProves(Prova);
        
        //cal.setTime(new Date());
        if ((Resultat.equals(classResultats.VAL_PERFECTE)) && (cal.getTime().after(mItem.getNextData()))) {
            if (TipusProva.equals( classProves.TIP_REPAS)) {
                switch (mItem.getNextTipus()) {
                    case "1h":
                        mItem.setNextTipus("1d");
                        cal.add(Calendar.HOUR, 23);
                        break;
                    case "1d":
                        mItem.setNextTipus("1s");
                        cal.add(Calendar.DATE, 6);
                        break;
                    case "1s":
                        mItem.setNextTipus("1m");
                        cal.add(Calendar.DATE, 21);
                        break;
                    case "1m":
                        mItem.setNextTipus("6m");
                        cal.add(Calendar.DATE, 28 * 5);
                        break;
                    case "6m":
                        cal.add(Calendar.DATE, 28 * 6);
                }
                mItem.setNextData(cal.getTime());
                db.actDiccionari(mItem);
            }
        } else if (Resultat.equals(classResultats.VAL_APRES)) {
            mItem.setNextTipus("1h");
            cal.add(Calendar.HOUR, 1);
            mItem.setNextData(cal.getTime());
            db.actDiccionari(mItem);
        } else if (Resultat.equals(classResultats.VAL_OBLIDAT)) {
            mItem.setNextTipus("a");
            mItem.setNextData("");
            db.actDiccionari(mItem);
        }
        // si és VAL_REVISIO no s'ha de gravar res
        // Si és examen i és perfecte, tampoc

        db.close();
    }


    public void Seguent() {
        if (Actual<objLlistaTrobats.ITEMS.size()) {
            Actual++;
            mItem = objLlistaTrobats.ITEMS.get(Actual);
            CarregaResp(new classResposta());
            CarregaItem(mItem);
        } else {
            Toast msg = Toast.makeText(this, "No hi ha més cares a memoritzar", Toast.LENGTH_SHORT);
            msg.setDuration(Toast.LENGTH_LONG);
            msg.show();
            finish();
        }

    }

    public void cmd_Edita(View view) {
        Context context = view.getContext();
        Intent intent = new Intent(context, act_mnt_edita.class);
        //No! num ordre obj...
        intent.putExtra(act_mnt_edita.ARG_ITEM_ID, Actual);
        context.startActivity(intent);
    }


}
