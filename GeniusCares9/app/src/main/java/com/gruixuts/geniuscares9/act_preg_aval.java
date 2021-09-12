package com.gruixuts.geniuscares9;

import android.content.Context;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Environment;
import android.view.View;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import java.io.File;

public class act_preg_aval extends AppCompatActivity {

    private int numIndex; // Index 0..N del item que s'està veient dins la llista @objLlistaTrobades
    private classDiccionari mItem;
    private classResposta Resp;
    private classResposta Avaluacio;
    private String TallVeu;
    GestorDB db;

    // Imatges
    private String CarpetaImatges;
    private String CarpetaImatgesItem;  // La carpeta del Item actual
    private Integer numImatge;
    private String nomsImatge[] = {};

    // Paràmetres
    public static final String ARG_ID_ITEM = "id_item";
    public static final String ARG_RESP = "resposta";
    public static final String ARG_AVAL = "avaluacio";
    public static final String ARG_CORR = "corregit";
    public static final String ARG_TALLVEU = "TallVeu";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_preg_aval);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
//        numIndex = Integer.parseInt(getIntent().getStringExtra( "item_id"));
//        numIndex = Integer.parseInt(getIntent().getStringExtra( Global.ARG_PREG_AVAL_ITEM_ID));
        numIndex = Integer.parseInt(getIntent().getStringExtra(ARG_ID_ITEM));
        Resp = new classResposta(getIntent().getStringExtra(ARG_RESP));
        Avaluacio = new classResposta(getIntent().getStringExtra(ARG_AVAL));
        TallVeu = getIntent().getStringExtra(ARG_TALLVEU);
        CarpetaImatges = Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pau/GeniusCares/Imatges";
        db=  new GestorDB(getApplicationContext());
        mItem = objLlistaTrobats.ITEMS.get(numIndex);
        CarregaItem(mItem);

    }

    private void CarregaItem(classDiccionari item) {
        if (item != null) {
            ((TextView) findViewById(R.id.txtValNomOk)).setText(item.getNom());
            ((TextView) findViewById(R.id.txtValCgnm1Ok)).setText(item.getCognom1());
            ((TextView) findViewById(R.id.txtValCgnm2Ok)).setText(item.getCognom2());
            ((TextView) findViewById(R.id.txtValCursOk)).setText(item.getCurs());
            ((TextView) findViewById(R.id.txtValNomRsp)).setText(Resp.getNom());
            ((TextView) findViewById(R.id.txtValCgnm1Rsp)).setText(Resp.getCognom1());
            ((TextView) findViewById(R.id.txtValCgnm2Rsp)).setText(Resp.getCognom2());
            ((TextView) findViewById(R.id.txtValCursRsp)).setText(Resp.getCurs());

            switch (Avaluacio.getNom()) {
                case classResultats.VAL_PERFECTE:
                    ((RadioButton) findViewById(R.id.rdNomBe)).setChecked(true);
                    break;
                case classResultats.VAL_REPASSAR:
                    ((RadioButton) findViewById(R.id.rdNomRev)).setChecked(true);
                    break;
                case classResultats.VAL_APRES:
                    ((RadioButton) findViewById(R.id.rdNomApres)).setChecked(true);
                    break;
                case classResultats.VAL_OBLIDAT:
                    ((RadioButton) findViewById(R.id.rdNomOblid)).setChecked(true);
                    break;
            }

            switch (Avaluacio.getCognom1()) {
                case classResultats.VAL_PERFECTE:
                    ((RadioButton) findViewById(R.id.rdCgnm1Be)).setChecked(true);
                    break;
                case classResultats.VAL_REPASSAR:
                    ((RadioButton) findViewById(R.id.rdCgnm1Rev)).setChecked(true);
                    break;
                case classResultats.VAL_APRES:
                    ((RadioButton) findViewById(R.id.rdCgnm1Apres)).setChecked(true);
                    break;
                case classResultats.VAL_OBLIDAT:
                    ((RadioButton) findViewById(R.id.rdCgnm1Oblid)).setChecked(true);
                    break;
            }

            switch (Avaluacio.getCognom2()) {
                case classResultats.VAL_PERFECTE:
                    ((RadioButton) findViewById(R.id.rdCgnm2Be)).setChecked(true);
                    break;
                case classResultats.VAL_REPASSAR:
                    ((RadioButton) findViewById(R.id.rdCgnm2Rev)).setChecked(true);
                    break;
                case classResultats.VAL_APRES:
                    ((RadioButton) findViewById(R.id.rdCgnm2Apres)).setChecked(true);
                    break;
                case classResultats.VAL_OBLIDAT:
                    ((RadioButton) findViewById(R.id.rdCgnm2Oblid)).setChecked(true);
                    break;
            }

            switch (Avaluacio.getCurs()) {
                case classResultats.VAL_PERFECTE:
                    ((RadioButton) findViewById(R.id.rdCursBe)).setChecked(true);
                    break;
                case classResultats.VAL_REPASSAR:
                    ((RadioButton) findViewById(R.id.rdCursRev)).setChecked(true);
                    break;
                case classResultats.VAL_APRES:
                    ((RadioButton) findViewById(R.id.rdCursApres)).setChecked(true);
                    break;
                case classResultats.VAL_OBLIDAT:
                    ((RadioButton) findViewById(R.id.rdCursOblid)).setChecked(true);
                    break;
            }
            ((TextView) findViewById(R.id.txtValVeuRsp)).setText(TallVeu);

            // Imatges:
            if (item.getImatges()!=null) {
                assert (item.getImatges().length()>0);
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
                CarpetaImatgesItem="";
                numImatge = 0;
                nomsImatge = new String[0];
            }
            if (numImatge==0) {
                ((ImageView) findViewById(R.id.imgImatges)).setImageResource(R.mipmap.ic_launcher);
            }
        } else {
            Global.MissatgeError("item=null, i no hauria de ser",this);
            finish();
        }
    }

    public void cmd_Ok(View view) {
        classResposta aval= new classResposta();
        int rb = ((RadioGroup) findViewById(R.id.rdgNom)).getCheckedRadioButtonId();
        if (rb==R.id.rdNomBe ) {
            aval.setNom(classResultats.VAL_PERFECTE);
        } else if (rb==R.id.rdNomRev ) {
            aval.setNom(classResultats.VAL_REPASSAR);
        } else if (rb==R.id.rdNomApres ) {
            aval.setNom(classResultats.VAL_APRES);
        } else if (rb==R.id.rdNomOblid ) {
            aval.setNom(classResultats.VAL_OBLIDAT);
        } else {
            aval.setNom("");
        }
        rb = ((RadioGroup) findViewById(R.id.rdgCgnm1)).getCheckedRadioButtonId();
        if (rb==R.id.rdCgnm1Be ) {
            aval.setCognom1(classResultats.VAL_PERFECTE);
        } else if (rb==R.id.rdCgnm1Rev ) {
            aval.setCognom1(classResultats.VAL_REPASSAR);
        } else if (rb==R.id.rdCgnm1Apres ) {
            aval.setCognom1(classResultats.VAL_APRES);
        } else if (rb==R.id.rdCgnm1Oblid ) {
            aval.setCognom1(classResultats.VAL_OBLIDAT);
        } else {
            aval.setCognom1("");
        }
        rb = ((RadioGroup) findViewById(R.id.rdgCgnm2)).getCheckedRadioButtonId();
        if (rb==R.id.rdCgnm2Be ) {
            aval.setCognom2(classResultats.VAL_PERFECTE);
        } else if (rb==R.id.rdCgnm2Rev ) {
            aval.setCognom2(classResultats.VAL_REPASSAR);
        } else if (rb==R.id.rdCgnm2Apres ) {
            aval.setCognom2(classResultats.VAL_APRES);
        } else if (rb==R.id.rdCgnm2Oblid ) {
            aval.setCognom2(classResultats.VAL_OBLIDAT);
        } else {
            aval.setCognom2("");
        }
        rb = ((RadioGroup) findViewById(R.id.rdgCurs)).getCheckedRadioButtonId();
        if (rb==R.id.rdCursBe ) {
            aval.setCurs(classResultats.VAL_PERFECTE);
        } else if (rb==R.id.rdCursRev ) {
            aval.setCurs(classResultats.VAL_REPASSAR);
        } else if (rb==R.id.rdCursApres ) {
            aval.setCurs(classResultats.VAL_APRES);
        } else if (rb==R.id.rdCursOblid ) {
            aval.setCurs(classResultats.VAL_OBLIDAT);
        } else {
            aval.setCurs("");
        }
        Intent data = new Intent();
        data.putExtra(ARG_CORR ,aval.toString());
        setResult(RESULT_OK,data);
        finish();
    }


    public void cmd_Edita(View view) {
        Context context = view.getContext();
        Intent intent = new Intent(context, act_mnt_edita.class);
        //No! num ordre obj...
        intent.putExtra(act_mnt_edita.ARG_ITEM_ID, numIndex);
        context.startActivity(intent);

    }

}
