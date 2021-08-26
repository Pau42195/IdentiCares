package com.gruixuts.geniuscares9;

import static java.lang.Integer.parseInt;

import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.view.View;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.TimeZone;

public class act_mnt_edita  extends AppCompatActivity {


    public static final String ARG_ITEM_ID = "item_id";
    private int numIndex; // Index 0..N del item que s'està veient dins la llista @objLlistaTrobades
    private classDiccionari mItem;
    Boolean ResetApres = false;
    GestorDB db;

    // Imatges
    private String CarpetaImatges;
    private String CarpetaImatgesItem;  // La carpeta del Item actual
    private Integer numImatge;
    private String nomsImatge[] = {};
    static final int REQUEST_IMAGE_CAPTURE = 17;

    protected static final int REQUEST_CODE = 10;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mnt_edita);
        ResetApres = false;
        numIndex = Integer.parseInt(getIntent().getStringExtra(ARG_ITEM_ID));
        CarpetaImatges = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Imatges";
        db=  new GestorDB(getApplicationContext());
        if (numIndex == 0) {
            mItem = new classDiccionari();
        } else {
            mItem = objLlistaTrobats.ITEMS.get(numIndex);
        }
        CarregaItem(mItem);

    }

    private void CarregaItem(classDiccionari item) {
        if (item != null) {
            ((TextView) findViewById(R.id.txtModId)).setText("" + item.getId());
            ((TextView) findViewById(R.id.edtModNom)).setText(item.getNom());
            ((TextView) findViewById(R.id.edtModCognom1)).setText(item.getCognom1());
            ((TextView) findViewById(R.id.edtModCognom2)).setText(item.getCognom2());
            ((TextView) findViewById(R.id.edtModCurs)).setText(item.getCurs());
            ((TextView) findViewById(R.id.edtModCodi)).setText(item.getCodi());
            ((Switch) findViewById(R.id.schTraduible)).setChecked(item.getAMemoritzar());
            ((TextView) findViewById(R.id.edtModGrup)).setText(item.getGrup());
            switch (item.getNextTipus()) {
                case "t":
                    ((RadioButton) findViewById(R.id.rdT)).setChecked(true);
                    break;
                case "a":
                    ((RadioButton) findViewById(R.id.rdA)).setChecked(true);
                    break;
                case "1h":
                    ((RadioButton) findViewById(R.id.rd1h)).setChecked(true);
                    break;
                case "1d":
                    ((RadioButton) findViewById(R.id.rd1d)).setChecked(true);
                    break;
                case "1s":
                    ((RadioButton) findViewById(R.id.rd1s)).setChecked(true);
                    break;
                case "1m":
                    ((RadioButton) findViewById(R.id.rd1m)).setChecked(true);
                    break;
                case "6m":
                    ((RadioButton) findViewById(R.id.rd6m)).setChecked(true);
                    break;
                default:
                    Toast toast = Toast.makeText(getApplicationContext(), "Tipus propera acció: '" + (item.getNextTipus()) + "' no identificat", Toast.LENGTH_LONG);
                    toast.show();
                    ;
                    ((RadioButton) findViewById(R.id.rdT)).setChecked(true);
                    break;
            }
            ((TextView) findViewById(R.id.edtModNextData)).setText(item.getNextDataTxt());
            // Imatges:
            if (item.getImatges()!=null) {
                assert (item.getImatges().length()>0);
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
                CarpetaImatgesItem="";
                numImatge = 0;
                nomsImatge = new String[0];
            }
        } else {
            MissatgeError("item=null, i no hauria de ser");
            ((TextView) findViewById(R.id.txtModId)).setText("");
            ((TextView) findViewById(R.id.edtModNom)).setText("");
            ((TextView) findViewById(R.id.edtModCognom1)).setText("");
            ((TextView) findViewById(R.id.edtModCognom2)).setText("");
            ((TextView) findViewById(R.id.edtModCurs)).setText("");
            ((TextView) findViewById(R.id.edtModCodi)).setText("");
            ((Switch) findViewById(R.id.schTraduible)).setChecked(false);
            ((TextView) findViewById(R.id.edtModGrup)).setText("");
            ((RadioButton) findViewById(R.id.rdT)).setChecked(true);
            ((TextView) findViewById(R.id.edtModNextData)).setText("");
            Toast toast = Toast.makeText(getApplicationContext(), "No hi ha res" , Toast.LENGTH_LONG);
            toast.show();
        }
    }

    private void DescarregaItem(classDiccionari item) {
        item.setNom(((TextView) findViewById(R.id.edtModNom)).getText().toString());
        item.setCognom1(((TextView) findViewById(R.id.edtModCognom1)).getText().toString());
        item.setCognom2(((TextView) findViewById(R.id.edtModCognom2)).getText().toString());
        item.setCurs(((TextView) findViewById(R.id.edtModCurs)).getText().toString());
        item.setCodi(((TextView) findViewById(R.id.edtModCodi)).getText().toString());
        item.setAMemoritzar(((Switch) findViewById(R.id.schTraduible)).isChecked());
        item.setGrup(((TextView) findViewById(R.id.edtModGrup)).getText().toString());
        if (((RadioButton) findViewById(R.id.rdT)).isChecked()) {
            item.setNextTipus("t");
        } else if (((RadioButton) findViewById(R.id.rdA)).isChecked()) {
            item.setNextTipus("a");
        } else if (((RadioButton) findViewById(R.id.rd1h)).isChecked()) {
            item.setNextTipus("1h");
        } else if (((RadioButton) findViewById(R.id.rd1d)).isChecked()) {
            item.setNextTipus("1d");
        } else if (((RadioButton) findViewById(R.id.rd1s)).isChecked()) {
            item.setNextTipus("1s");
        } else if (((RadioButton) findViewById(R.id.rd1m)).isChecked()) {
            item.setNextTipus("1m");
        } else if (((RadioButton) findViewById(R.id.rd6m)).isChecked()) {
            item.setNextTipus("6m");
        } else item.setNextTipus("t");
        item.setNextData(((TextView) findViewById(R.id.edtModNextData)).getText().toString());

        // Consistència
        if (item.getNextTipus().equals("t") || item.getNextTipus().equals("a")) {
            item.setNextData("");
        } else {
            if (item.getNextDataTxt().equals("")) {
                Calendar cal = new GregorianCalendar(TimeZone.getTimeZone("Europe/Madrid"));
                cal.setTime(new Date());
                switch (item.getNextTipus()) {
                    case "1h":
                        cal.add(Calendar.HOUR, 1);
                        break;
                    case "1d":
                        cal.add(Calendar.DATE, 1);
                        break;
                    case "1s":
                        cal.add(Calendar.DATE, 7);
                        break;
                    case "1m":
                        cal.add(Calendar.DATE, 28);
                        break;
                    case "6m":
                        cal.add(Calendar.DATE, 28 * 6);
                }
                item.setNextData(cal.getTime());
            }
        }


    }

    /*************************************************************************/
    /********************************* Imatges *******************************/
    /*************************************************************************/

    public void fotoSeguent(View view) {
        if (numImatge < nomsImatge.length && numImatge > 0) {
            numImatge++;
            Drawable d = Drawable.createFromPath(CarpetaImatgesItem + "/" + nomsImatge[numImatge - 1]);
            ((ImageView) findViewById(R.id.imgImatges)).setImageDrawable(d);
        }
    }

    public void fotoAnterior(View view) {
        if (numImatge > 1) {
            numImatge--;
            Drawable d = Drawable.createFromPath(CarpetaImatgesItem + "/" + nomsImatge[numImatge - 1]);
            ((ImageView) findViewById(R.id.imgImatges)).setImageDrawable(d);
        }
    }

    public void fotoAfegeix(View view) {
        Intent CameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        if (CameraIntent.resolveActivity(getPackageManager()) != null) {
            startActivityForResult(CameraIntent, REQUEST_IMAGE_CAPTURE);
        }
    }

    public void fotoElimina(View view) {
        MissatgeError("Opció encara no implementada");
    }

    // Es crida després d'haver fet la foto
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Bitmap imgBitmap;
        ImageView imgView = findViewById(R.id.imgImatges);
        File imatge = null;
        if (requestCode == REQUEST_IMAGE_CAPTURE && resultCode == RESULT_OK) {
            Bundle extras = data.getExtras();
            imgBitmap = (Bitmap) extras.get("data");
        } else {
            return;
        }
        // Crea el nom del fitxer de la nova imatge
        String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
        String imageFileName = "JPEG_" + timeStamp + "_";

        // Crea la carpeta (si cal)
        if (CarpetaImatgesItem.length()==0) {  // Miro si ja hi ha carpeta
            // Si numImatge == 0 vol dir que no hi ha fotos, si n'hi hagués vol dir que la carpeta existeix
            // No hi ha texte d'imatges, per tant cal decidir-lo
            assert (numImatge==0);
            assert (nomsImatge.length==0);
            mItem.setCodi(((TextView) findViewById(R.id.edtModCodi)).getText().toString()); // Per si s'està editant, que serà el normal
            if (mItem.getCodi().length() == 0) {  // No hi ha codi => cal inventar-se un nom
                mItem.setImatges(classDiccionari.NovaImatge());   //Assigna nom aleatori
            } else {
                mItem.setImatges(mItem.getCodi());
            }
            CarpetaImatgesItem=CarpetaImatges + "/" + mItem.getImatges();
        }
        File fi = new File(CarpetaImatgesItem);
        if (!fi.exists()) {
            if (!fi.mkdirs()) {
                MissatgeError("No s'ha pogut crear la carpeta:" + fi.getName());
                //Toast.makeText(this, "No s'ha pogut crear la carpeta:" + fi.getName(), Toast.LENGTH_SHORT).show();
                numImatge=0;
                nomsImatge = new String[0];
                CarpetaImatgesItem="";
                return;
            }
        }
        // Creo el fitxer
        try {
            imatge = File.createTempFile(
                    imageFileName,  /* prefix */
                    ".jpg",         /* suffix */
                    new File(CarpetaImatgesItem)      /* directory */
            );
        } catch (IOException e) {
            e.printStackTrace();
            MissatgeError("No es pot crear el nou fitxer (tmp):" + e.getMessage());
            return;
        }
        try {
            FileOutputStream fOut = new FileOutputStream(imatge);

            imgBitmap.compress(Bitmap.CompressFormat.JPEG, 85, fOut);
            fOut.flush();
            fOut.close();
//            MakeSureFileWasCreatedThenMakeAvabile(file);
//            AbleToSave();
        } catch (FileNotFoundException e) {
            MissatgeError("No es pot crear el nou fitxer (no se sap perquè):" + e.getMessage());
            //          Toast.makeText(context, "¡No se ha podido guardar la imagen!", Toast.LENGTH_SHORT).show();
        } catch (IOException e) {
            MissatgeError("No es pot crear el nou fitxer:" + e.getMessage());
//            Toast.makeText(context, "¡No se ha podido guardar la imagen!", Toast.LENGTH_SHORT).show();
        }

        imgView.setImageBitmap(imgBitmap);
        numImatge = nomsImatge.length+1;
        nomsImatge = Arrays.copyOf(nomsImatge, numImatge);
        nomsImatge[numImatge - 1] = imatge.getName();

    }

    /********************************************************************/
    /**************  Comandaments botons  *******************************/
    /********************************************************************/


    public void cmd_Ok(View view) {
        db.open();
        DescarregaItem(mItem);
        if (mItem.getId() == 0) {
            db.creaDiccionari(mItem);
        } else {
            db.actDiccionari(mItem);
        }
        db.close();
        finish();
    }

    public void cmd_Cancella(View view) {
        CarregaItem(mItem);
    }

    public void cmd_Elimina(View view) {
        // MsgBox ¿?
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage("Segur que vols esborrar?");
        builder.setTitle("Atenció!!");
        builder.setCancelable(false);
        builder.setNegativeButton("No",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.cancel();
                    }
                });
        builder.setPositiveButton("Sí",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        db.open();
                        if (mItem.getId() != 0) {
                            db.delEntDic(mItem.getId());
                        }
                        db.close();
                        // Todo: Eliminar les imatges

                        dialog.cancel();
                        finish();
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();
        // Fi MsgBox
    }

    public void cmd_Ant() {

    }

    public void cmd_Seg() {

    }

    /***************************************************************************************/
    /************************  Utilitats  **************************************************/
    /***************************************************************************************/

    public void AutomTraduible(View view) {
        if (((Switch) findViewById(R.id.schTraduible)).isChecked()) {
            ((RadioButton) findViewById(R.id.rdT)).setChecked(false);
            ((RadioButton) findViewById(R.id.rdA)).setChecked(false);
            ((RadioButton) findViewById(R.id.rd1h)).setChecked(false);
            ((RadioButton) findViewById(R.id.rd1d)).setChecked(false);
            ((RadioButton) findViewById(R.id.rd1s)).setChecked(false);
            ((RadioButton) findViewById(R.id.rd1m)).setChecked(false);
            ((RadioButton) findViewById(R.id.rd6m)).setChecked(false);
            ((TextView) findViewById(R.id.edtModNextData)).setText("");
        } else {
            ((RadioButton) findViewById(R.id.rdA)).setChecked(true);
        }
    }

    public void BuscaCodi(View view) {
//        Intent intent = new Intent(act_manteniment_modificar.this, act_aux_Codi.class);

        // Passem les cadenes a comparar ja normalitzades
//        intent.putExtra("Codi", ((TextView) findViewById(R.id.edtModCodi)).getText());
//        intent.putExtra("Codi", ((TextView) findViewById(R.id.edtModCodi)).getText());
//        startActivityForResult(intent, REQUEST_CODE);

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



