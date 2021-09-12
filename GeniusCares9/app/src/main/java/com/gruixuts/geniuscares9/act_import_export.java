package com.gruixuts.geniuscares9;

import android.Manifest;
import android.content.Context;
import android.content.DialogInterface;
import android.content.pm.ActivityInfo;
import android.content.pm.PackageManager;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

public class act_import_export  extends AppCompatActivity {

    SimpleDateFormat frmtData = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
    static String Separador = ",";
    TextView estat;
    static String CarpetaCopies = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Copies";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_import_export);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);

        estat = findViewById(R.id.txtEstat);
        estat.setText("preparat");
        isStoragePermissionGranted();

    }

    public boolean isStoragePermissionGranted() {
        if (Build.VERSION.SDK_INT >= 23) {
            if (checkSelfPermission(android.Manifest.permission.WRITE_EXTERNAL_STORAGE)
                    == PackageManager.PERMISSION_GRANTED) {
                return true;
            } else {

                ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}, 1);
                return false;
            }
        } else { //permission is automatically granted on sdk<23 upon installation
            return true;
        }
    }

    public Integer ANum(String a) {
        // Resol un fallo del sistema que no tinc controlat, a cops cal posar substr i a cops no
        try {
            return Integer.parseInt(a);
        } catch (Exception e) {
            return Integer.parseInt(a.substring(1));
        }
    }


    public void ImportarCopia(View view) {
        //Todo: Importar Proves i Resultats
        Exportar(view);
        GestorDB db = new GestorDB(getApplicationContext());
        TextView elim = findViewById(R.id.edtEliminarOk);
        TextView estat = findViewById(R.id.txtEstat);
        TextView nomfit = findViewById(R.id.edtNomFitxerImport);
        String[] camps;
        File fitxer;
        BufferedReader Buf; // Buffer del fitxer
        String txt; // On es llegeix cada línia
        long NumLin = 0;

        // Provisional, per a fer proves:
        nomfit.setText("AImportar.txt");
        elim.setText("ELIMINAR");
        // Miro si s'ha escrit la paraula ELIMINAR (per seguretat)
        if (elim.getText().toString().compareTo("ELIMINAR") == 0) {
            estat.setText("Buscant fitxers");
            try {
                // Controlem que el fitxer existeix
                fitxer = new File(CarpetaCopies,nomfit.getText().toString());
                if (!fitxer.exists()) {
                    estat.setText("El fitxer no existeix");
                    return;
                }
            } catch (Exception e) {
                estat.setText("Error al mirar si el fitxer existeix: " + e.getMessage());
                return;
            }

            estat.setText("Important de " + nomfit.getText().toString());

            try {
                // Llegim les dades
                Buf = new BufferedReader((new InputStreamReader(new FileInputStream(fitxer))));
                db.open();
                db.delDiccionari();  //Buidem tot lo anterior
                while ((txt = Buf.readLine()) != null) {
                    NumLin++;
                    camps = txt.split(Separador);
                    switch (camps[0]) {
                        case "V": // Versió
                            break; // Mentre no fem noves versions, no cal
                        case "A": // Alumne o persona a recordar
                            db.insDiccionari(new classDiccionari(
                                    ANum(camps[1]), //Id
                                    camps[2],                   //Imatges
                                    camps[3],                   //Nom
                                    camps[4],                   //Cognom1
                                    camps[5],                   //Cognom2
                                    camps[6],                   //Curs
                                    camps[7],                   //Codi
                                    camps[8],                   //PAV
                                    camps[9],                   //Comentaris
                                    camps[10],                  //Grup
                                    camps[11],                  //NextTipus
                                    camps[12].equals("") ? null : frmtData.parse(camps[12]), //NextData
                                    camps[13].equals("true"))
                            );
                            break; // Mentre no fem noves versions, no cal
                        case "P": // Proves
                            /*
                            try {
                                num1 = Integer.parseInt(camps[0]);
                            } catch (Exception e) {
                                num1 = Integer.parseInt(camps[0].substring(1));
                            }
                            try {
                                num2 = Integer.parseInt(camps[4]);
                            } catch (Exception e) {
                                num2 = Integer.parseInt(camps[4].substring(1));
                            }
                            try {
                                num3 = Integer.parseInt(camps[5]);
                            } catch (Exception e) {
                                num3 = Integer.parseInt(camps[5].substring(1));
                            }
                            try {
                                num4 = Long.parseLong(camps[6]);
                            } catch (Exception e) {
                                num4 = Long.parseLong(camps[6].substring(1));
                            }
                            Boolean p = camps[13].equals("True");
                            db.insProves(new classProves(
                                    num1,                        //Id
                                    GestorDB.AData(camps[1]),                   //Dia
                                    camps[2],                   //TipusProva
                                    camps[3],                   //Seleccio
                                    num2,                   //NumPreguntes
                                    num3,                   //NumRespostes
                                    num4,                   //Temps
                                    !camps[9].equals("0"))
                            );*/
                            break;
                        case "R":  // Resultats
                            classResultats Resultat = new classResultats(txt);
                            db.insResultat(Resultat);
                            break;
                        default:
                            MissatgeError("Error al llegir la línia, tipus de registre no conegut linia " + NumLin,view.getContext());

                    }
                }
                db.close();
            } catch (Exception e) {
                String text= "Dades no carregades: " + e.getMessage();
                Toast.makeText(act_import_export.this, text, Toast.LENGTH_LONG).show();
                estat.setText(text);
            }

            estat.setText("Tot importat correctament de " + nomfit.getText().toString());

        } else {
            estat.setText("No s'ha posat ELIMINAR");
        }



    }

    public void ImportarDb(View view) {
        // Ara copiem la base de dades
        String Dades = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Dades/AImportar.db";
        String FitxerDb = "/data/data/com.gruixuts.geniuscares9/databases/GeniusCares.db";

        File origin = new File(Dades);
        File destination = new File(FitxerDb);
        if (origin.exists()) {
            Exportar(view);
            try {
                InputStream in = new FileInputStream(origin);
                OutputStream out = new FileOutputStream(destination);
                // We use a buffer for the copy (Usamos un buffer para la copia).
                byte[] buf = new byte[1024];
                int len;
                while ((len = in.read(buf)) > 0) {
                    out.write(buf, 0, len);
                }
                in.close();
                out.close();
            } catch (IOException ioe) {
                ioe.printStackTrace();
                MissatgeError("Base de dades no copiada: " + ioe.getMessage(),view.getContext());
            }
        } else {
            MissatgeError("Base de dades AImportar.db no trobada",view.getContext());
        }
    }


    public static void Exportar(String sMarcador, Context context) {
        File fitxer;

        GestorDB db = new GestorDB( context );
        ArrayList<classDiccionari> LlistaDiccionari;
        ArrayList<classProves> LlistaProves;
        ArrayList<classResultats> LlistaResultats;
        OutputStreamWriter fout;
        Toast.makeText(context, "Exportant marca:" + sMarcador, Toast.LENGTH_LONG).show();

        try {
            db.open();
            LlistaDiccionari = db.selDiccionari("", "Id");
            LlistaProves = db.selProves("", "");
            LlistaResultats = db.selResultats("", "");
            db.close();
            fitxer = new File(CarpetaCopies, "Dades_" + sMarcador + ".txt");
            if (fitxer.exists()) {
                MissatgeError("No es pot exportar, nom ja usat, torna a provar " + fitxer.getName(),context);
                return;
            }

            fout = new OutputStreamWriter(new FileOutputStream(fitxer));
            try {
                fout.write("V" + Separador);
                fout.write( db.DATABASE_VERSION + "\r\n");
            } catch (Exception e) {
                MissatgeError("Diccionari Fallo linia: V0 no exportada " + e.getMessage(),context);
            }
            for (int n = 0; n < LlistaDiccionari.size(); n++) {
                try {
                    fout.write("A" + Separador);
                    fout.write(LlistaDiccionari.get(n).getId().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getImatgesTxt().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getNom().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getCognom1().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getCognom2().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getCurs().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getCodi().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getPAV().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getComentaris().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getGrup().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getNextTipus().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getNextDataTxt().toString() + Separador);
                    fout.write(LlistaDiccionari.get(n).getAMemoritzar().toString() + "\r\n");
                    fout.flush();  // Per localitzar errors, quan vagi bé cal treure-ho per accelerar
                } catch (Exception e) {
                    MissatgeError("Diccionari Fallo linia: A" + n + " no exportada " + e.getMessage(),context);
                }
            }
            for (int n = 0; n < LlistaProves.size(); n++) {
                try {
                fout.write("P" + Separador);
                fout.write(LlistaProves.get(n).getId().toString() + Separador);
                fout.write(LlistaProves.get(n).getDiaTxt().toString() + Separador);
                fout.write(LlistaProves.get(n).getTipusProva().toString() + Separador);
                fout.write(LlistaProves.get(n).getSeleccio().toString() + Separador);
                fout.write(LlistaProves.get(n).getNumPreguntes().toString() + Separador);
                fout.write(LlistaProves.get(n).getNumRespostes().toString() + Separador);
                fout.write(LlistaProves.get(n).getTemps().toString() + Separador);
                fout.write(LlistaProves.get(n).getAcabada().toString() + "\r\n");
                fout.flush();
                } catch (Exception e) {
                    MissatgeError("Diccionari Fallo linia: P" + n + " no exportada " + e.getMessage(),context);
                }
            }
            for (int n = 0; n < LlistaResultats.size(); n++) {
                try {
                fout.write("R" + Separador);
                fout.write(LlistaResultats.get(n).getDiaTxt().toString() + classResultats.Separador);
                fout.write(LlistaResultats.get(n).getIdProva().toString() + classResultats.Separador);
                fout.write(LlistaResultats.get(n).getIdItem().toString() + classResultats.Separador);
                fout.write(LlistaResultats.get(n).getRepasTipus().toString() + classResultats.Separador);
                fout.write(LlistaResultats.get(n).getRepasDataTxt().toString() + classResultats.Separador);
                fout.write(LlistaResultats.get(n).getResposta().toString() + classResultats.Separador);
                fout.write(LlistaResultats.get(n).getErrors().toString() + classResultats.Separador);
                fout.write(LlistaResultats.get(n).getTemps().toString() + classResultats.Separador);
                fout.write(LlistaResultats.get(n).getValoracio().toString() + "\r\n");
                fout.flush();
                } catch (Exception e) {
                    MissatgeError("Diccionari Fallo linia: R" + n + " no exportada " + e.getMessage(),context);
                }
            }
            fout.close();
        } catch (Exception e) {
            Log.d("Fallo;)", "Error: Exportar: " + e.getMessage());
            MissatgeError("Diccionari no exportat: " + e.getMessage(),context);
            return;
        }

        // Ara copiem la base de dades
        String CarpetaDades = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Dades";
        String FitxerDb = "/data/data/com.gruixuts.geniuscares9/databases/GeniusCares.db";

        File origin = new File(FitxerDb);
        File destination = new File(CarpetaDades + "/GeniusCares" + sMarcador + ".db");
        if (origin.exists()) {
            try {
                InputStream in = new FileInputStream(origin);
                OutputStream out = new FileOutputStream(destination);
                // We use a buffer for the copy (Usamos un buffer para la copia).
                byte[] buf = new byte[1024];
                int len;
                while ((len = in.read(buf)) > 0) {
                    out.write(buf, 0, len);
                }
                in.close();
                out.close();
            } catch (IOException ioe) {
                ioe.printStackTrace();
                MissatgeError("Base de dades no copiada: " + ioe.getMessage(),context);
            }
        } else {
            MissatgeError("Base de dades no trobada",context);
        }
    }

    public void Exportar(View view) {
        estat.setText("Exportant ");
        String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
        Exportar(timeStamp, this);
        estat.setText("Preparat");

    }

    static private void MissatgeError(String Missatge, Context context) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(Missatge);
        builder.setTitle("Error!!!");
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
