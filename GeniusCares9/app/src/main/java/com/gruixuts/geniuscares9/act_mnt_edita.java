package com.gruixuts.geniuscares9;

import static java.lang.Integer.parseInt;

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
    private String nomsImatge[]={};
    static final int REQUEST_IMAGE_CAPTURE = 17;

    protected static final int REQUEST_CODE = 10;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mnt_edita);
        ResetApres = false;
        numIndex = Integer.parseInt(getIntent().getStringExtra(ARG_ITEM_ID));
        CarpetaImatges = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Imatges";
        mItem = objLlistaTrobats.ITEMS.get(numIndex);
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
                    ((RadioButton) findViewById(R.id.rdT)).setChecked(true); break;
                case "a":
                    ((RadioButton) findViewById(R.id.rdA)).setChecked(true); break;
                case "1h":
                    ((RadioButton) findViewById(R.id.rd1h)).setChecked(true); break;
                case "1d":
                    ((RadioButton) findViewById(R.id.rd1d)).setChecked(true); break;
                case "1s":
                    ((RadioButton) findViewById(R.id.rd1s)).setChecked(true); break;
                case "1m":
                    ((RadioButton) findViewById(R.id.rd1m)).setChecked(true); break;
                case "6m":
                    ((RadioButton) findViewById(R.id.rd6m)).setChecked(true); break;
                default:
                    Toast toast = Toast.makeText(getApplicationContext(), "Tipus propera acció: '" + (item.getNextTipus()) + "' no identificat", Toast.LENGTH_LONG);
                    toast.show();;
                    ((RadioButton) findViewById(R.id.rdT)).setChecked(true); break;
            }
            ((TextView) findViewById(R.id.edtModNextData)).setText(item.getNextDataTxt());
            CarpetaImatgesItem = CarpetaImatges + "/" + item.getImatges();
            File carpeta = new File(CarpetaImatgesItem);
            if(!carpeta.exists()) { // Crear-la
                numImatge =0;
                //carpeta.mkdirs();
                nomsImatge = new String[0];

            }
            else {
                nomsImatge = carpeta.list();
            }
            if (nomsImatge.length != 0) {
                numImatge = 1;
                Drawable d = Drawable.createFromPath(CarpetaImatgesItem + "/" + nomsImatge[numImatge - 1]);
                ((ImageView) findViewById(R.id.imgImatges)).setImageDrawable(d);
            }
            else {
                numImatge = 0;
            }
        }
        else {
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
                        cal.add(Calendar.DATE, 28*6);
                }
                item.setNextData(cal.getTime());
            }
        }



    }

    /*************************************************************************/
    /********************************* Imatges *******************************/
    /*************************************************************************/

    public void fotoSeguent(View view) {
        if (numImatge < nomsImatge.length && numImatge >0) {
            numImatge++;
            Drawable d = Drawable.createFromPath(CarpetaImatgesItem + "/" + nomsImatge[numImatge - 1]);
            ((ImageView) findViewById(R.id.imgImatges)).setImageDrawable(d);
        }
    }

    public void fotoAnterior(View view) {
        if (numImatge > 1 ) {
            numImatge--;
            Drawable d = Drawable.createFromPath(CarpetaImatgesItem + "/" + nomsImatge[numImatge - 1]);
            ((ImageView) findViewById(R.id.imgImatges)).setImageDrawable(d);
        }
    }

    public void fotoAfegeix(View view) {
        Intent CameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        if(CameraIntent.resolveActivity(getPackageManager()) != null){
            startActivityForResult(CameraIntent, REQUEST_IMAGE_CAPTURE);
        }
    }
    public void fotoElimina(View view) {

    }

    // Es crida després d'haver fet la foto
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Bitmap imgBitmap;
        ImageView imgView = findViewById(R.id.imgImatges);
        File image = null;
        if (requestCode == REQUEST_IMAGE_CAPTURE && resultCode == RESULT_OK) {
            Bundle extras = data.getExtras();
            imgBitmap = (Bitmap) extras.get("data");
            imgView.setImageBitmap(imgBitmap);
        }
        else {
            return;
        }
        // Create an image file name
        String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
        String imageFileName = "JPEG_" + timeStamp + "_";
        try {
            image = File.createTempFile(
                    imageFileName,  /* prefix */
                    ".jpg",         /* suffix */
                    new File(CarpetaImatges)      /* directory */
            );
        } catch (IOException e) {
            e.printStackTrace();
        }
        try {
            FileOutputStream fOut = new FileOutputStream(image);

            imgBitmap.compress(Bitmap.CompressFormat.JPEG, 85, fOut);
            fOut.flush();
            fOut.close();
//            MakeSureFileWasCreatedThenMakeAvabile(file);
//            AbleToSave();
        }

        catch(FileNotFoundException e) {
            //          Toast.makeText(context, "¡No se ha podido guardar la imagen!", Toast.LENGTH_SHORT).show();
        }
        catch(IOException e) {
//            Toast.makeText(context, "¡No se ha podido guardar la imagen!", Toast.LENGTH_SHORT).show();
        }

        numImatge = nomsImatge.length;
        nomsImatge = Arrays.copyOf(nomsImatge, numImatge);
        nomsImatge[numImatge -1]= imageFileName + ".jpg";


        // Save a file: path for use with ACTION_VIEW intents
        //currentPhotoPath = image.getAbsolutePath();

    }

    /********************************************************************/
    /**************  Comandaments botons  *******************************/
    /********************************************************************/


    public void cmd_Ok(View view) {
        db.open();
        DescarregaItem(mItem);
        db.open();
        if (mItem.getId()==0) {
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
                        if (mItem.getId()!=0) {
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

}


