package com.gruixuts.geniuscares9;

import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Environment;
import android.os.SystemClock;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.TimeZone;

public class act_mem extends AppCompatActivity {
    //List<classDiccionari> Llista;
    SimpleDateFormat frmtData = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
    GestorDB db;
    Integer Actual = 0;
    classDiccionari mItem;
    classProves Prova = null;
    //String Filtre="";
    //Integer IdEntDic;
    Long TempsIniciProva;
    Long TempsIniciPregunta;
    Long TempsProva;

    private String CarpetaImatges = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Imatges";
    private String CarpetaImatgesItem;  // La carpeta del Item actual
    private Integer numImatge;
    private String nomsImatge[];

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Integer NumProva;
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mem);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
        //txtNom = (TextView) findViewById(R.id.txtMemNom);
        //txtCognom1 = (TextView) findViewById(R.id.txtMemCognom1);
        //txtCognom2 = (TextView) findViewById(R.id.txtMemCognom2);
        //txtCurs = (TextView) findViewById(R.id.txtMemCurs);
        //edtMemPAV = (TextView) findViewById(R.id.edtMemPAV);
        //edtMemComentaris = (TextView) findViewById(R.id.edtMemComentaris);
        //vwImatge = (ImageView) findViewById(R.id.imgImatges);
        //Llista = objLlistaTrobats.ITEMS;
        //Actual=0; No, ja que cada cop que gires el telèfon es tornaria a posar a 0
        mItem = objLlistaTrobats.ITEMS.get(Actual);
        TempsIniciProva = SystemClock.currentThreadTimeMillis();
        CarpetaImatges = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Imatges";
        db=  new GestorDB(getApplicationContext());
        //PreguntaSeguent();
        if (objLlistaTrobats.ITEMS.size()==0) {
            Global.MissatgeError("No hi ha res a memoritzar",this);
            finish();
        }
        CarregaItem(mItem);
    }

    private void CarregaItem(classDiccionari item) {
        assert (item != null);
        ((TextView) findViewById(R.id.txtMemNom)).setText(item.getNom());
        ((TextView) findViewById(R.id.txtMemCognom1)).setText(item.getCognom1());
        ((TextView) findViewById(R.id.txtMemCognom2)).setText(item.getCognom2());
        ((TextView) findViewById(R.id.txtMemCurs)).setText(item.getCurs());
        ((TextView) findViewById(R.id.edtMemPAV)).setText(item.getPAV());
        ((TextView) findViewById(R.id.edtMemComentaris)).setText(item.getComentaris());
        ((TextView) findViewById(R.id.txtCompt)).setText("Actual: " + (Actual + 1) + "/" + objLlistaTrobats.ITEMS.size());


        // Imatges:
        if (item.getImatges() != null) {
            assert (item.getImatges().length() > 0);
            CarpetaImatgesItem = CarpetaImatges + "/" + item.getImatges();
            File carpeta = new File(CarpetaImatgesItem);
            if (!carpeta.exists()) { // Crear-la
                MissatgeError("La cerpeta d'immatges " + CarpetaImatgesItem + " no existeix");
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
        if (numImatge==0) {
            ((ImageView) findViewById(R.id.imgImatges)).setImageResource(R.mipmap.ic_launcher);
        }
        TempsIniciPregunta = SystemClock.currentThreadTimeMillis();
    }


/*
    private void PreguntaSeguent() {
        // Mostla seguent paraula a memoritzar

        Actual++;
        if (Actual<objLlistaTrobats.ITEMS.size()) {
            mItem =Llista.get(Actual);
            //IdEntDic= mItem.getId();
            File carpeta = new File(CarpetaImatges + "/" + mItem.getImatges());
            numImatge = 0;
            if (carpeta.exists()) {
                nomsImatge = carpeta.list();
                if (nomsImatge.length != 0) {
                    numImatge = 1;
                }
            }
            fotoPrimera();
            txtNom.setText(mItem.getNom());
            txtCognom1.setText(mItem.getCognom1());
            txtCognom2.setText(mItem.getCognom2());
            txtCurs.setText(mItem.getCurs());
            edtMemPAV.setText(mItem.getPAV());
            edtMemComentaris.setText(mItem.getComentaris());
            TextView txtCompt = (TextView) findViewById(R.id.txtCompt);
            txtCompt.setText("Actual: " + (Actual + 1) + "/" + objLlistaTrobats.ITEMS.size());
            TempsIniciPregunta = SystemClock.currentThreadTimeMillis();
        } else {
            Toast msg = Toast.makeText(this, "No hi ha més cares a memoritzar", Toast.LENGTH_SHORT);
            msg.setDuration(Toast.LENGTH_LONG);
            msg.show();
            Button bt1 = (Button) findViewById(R.id.cmdMemOk);
            Button bt2 = (Button) findViewById(R.id.cmdMemPasso);
            Button bt3 = (Button) findViewById(R.id.cmdMemEdit);
            txtNom.setText("");
            txtCognom1.setText("");
            txtCognom2.setText("");
            txtCurs.setText("");
            edtMemPAV.setText("");
            edtMemComentaris.setText("");
            bt1.setEnabled(false);
            bt2.setEnabled(false);
            bt3.setEnabled(false);
            if (Prova != null) {
                Prova.setAcabada(true);
                db.open();
                db.actProves(Prova);
                db.close();
            }
        }

    }
*/

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


    public void MemOk(View view) {
        Calendar cal = Calendar.getInstance(TimeZone.getTimeZone("Europe/Madrid"));
        Date Ara = cal.getTime();
        // Diccionari
        mItem.setNextTipus("1h");
        cal.add(Calendar.HOUR,1);
        mItem.setNextData(cal.getTime());
        mItem.setPAV(((TextView) findViewById(R.id.edtMemPAV)).getText().toString());
        mItem.setComentaris(((TextView) findViewById(R.id.edtMemComentaris)).getText().toString());
        db.open();
        db.actDiccionari(mItem);
        // Prova
        if (Prova == null) {
            Prova = new classProves();
            Prova.setId(db.NumNovaProva());
            Prova.setDia(Ara);
            Prova.setTipusProva(classProves.TIP_APRENDRE);
            Prova.setSeleccio(objLlistaTrobats.Filtre);
            Prova.setNumPreguntes(objLlistaTrobats.ITEMS.size());
            Prova.setAcabada(false);
        }
        Prova.setTemps((Long) (SystemClock.currentThreadTimeMillis() - TempsIniciProva));
        Prova.setNumRespostes(Actual);
        db.actProves(Prova);
        // Resultat
        classResultats rslt = new classResultats();
        rslt.setDia(Ara);
        rslt.setIdProva(Prova.getId());
        rslt.setIdItem(mItem.getId());
        rslt.setResposta("Memoritzat");
        rslt.setTemps((Long) (SystemClock.currentThreadTimeMillis() - TempsIniciPregunta));
        rslt.setValoracio(classResultats.VAL_APRES);
        db.insResultat(rslt);
        db.close();
        MemPasso(view);
    }

    public void MemPasso(View view) {
        if (Actual<objLlistaTrobats.ITEMS.size()) {
            Actual++;
            mItem = objLlistaTrobats.ITEMS.get(Actual);
            CarregaItem(mItem);
        } else {
            Toast msg = Toast.makeText(this, "No hi ha més cares a memoritzar", Toast.LENGTH_SHORT);
            msg.setDuration(Toast.LENGTH_LONG);
            msg.show();
            finish();
        }

    }

    public void MemEdit(View view) {
        Context context = view.getContext();
        Intent intent = new Intent(context, act_mnt_edita.class);
        //No! num ordre obj...
        intent.putExtra(act_mnt_edita.ARG_ITEM_ID, Actual);
        context.startActivity(intent);
    }
    private void MissatgeError(String Missatge) {
        MissatgeError(Missatge, "Error!!!");
    }

    private void MissatgeError(String Missatge, String Titol) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage(Missatge);
        builder.setTitle(Titol);
        builder.setCancelable(false);
        builder.setNeutralButton("Entesos",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.cancel();
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();
    }

}
