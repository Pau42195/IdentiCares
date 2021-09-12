package com.gruixuts.geniuscares9;

import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.os.Bundle;
import android.view.View;
import android.widget.CheckBox;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;

public class act_rep_sel extends AppCompatActivity {

    GestorDB db;
    SimpleDateFormat frmtData = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
    classProves Prova;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_rep_sel);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);

        db = new GestorDB(getApplicationContext());
        TextView txtr1h = findViewById(R.id.txtRep1h);
        TextView txtr1d = findViewById(R.id.txtRep1d);
        TextView txtr1s = findViewById(R.id.txtRep1s);
        TextView txtr1m = findViewById(R.id.txtRep1m);
        TextView txtr6m = findViewById(R.id.txtRep6m);
        db.open();
        txtr1h.setText(db.QuantsRep("1h").toString());
        txtr1d.setText(db.QuantsRep("1d").toString());
        txtr1s.setText(db.QuantsRep("1s").toString());
        txtr1m.setText(db.QuantsRep("1m").toString());
        txtr6m.setText(db.QuantsRep("6m").toString());
        db.close();

    }

    public void GoToExamenRepas(View view){
        String Repassos;
        Calendar cal = new GregorianCalendar(TimeZone.getTimeZone("Europe/Madrid"));

        CheckBox chk1h = findViewById(R.id.chkRep1h);
        CheckBox chk1d = findViewById(R.id.chkRep1d);
        CheckBox chk1s = findViewById(R.id.chkRep1s);
        CheckBox chk1m = findViewById(R.id.chkRep1m);
        CheckBox chk6m = findViewById(R.id.chkRep6m);
        String Filtre ="";
        if (chk1h.isChecked()) Filtre += "or NextTipus='1h' ";
        if (chk1d.isChecked()) Filtre += "or NextTipus='1d' ";
        if (chk1s.isChecked()) Filtre += "or NextTipus='1s' ";
        if (chk1m.isChecked()) Filtre += "or NextTipus='1m' ";
        if (chk6m.isChecked()) Filtre += "or NextTipus='6m' ";
        if (Filtre.length() > 0) {
            Filtre =  Filtre.substring(3);
        } else {
            Filtre =  "0";
        }
        Filtre = "((" + Filtre + ") and ( NextData < '" +  frmtData.format(cal.getTime()) + "') and NOT ( NextData =''))";
        objLlistaTrobats.NouSQLtxt(Filtre,"",getApplicationContext());

        if (objLlistaTrobats.ITEMS.size()==0) {
            Global.Missatge("No hi ha items a revisar", "Ho sento", this);
        }
        db.open();
        Prova = new classProves();
        Prova.setId(db.UltimaProva()+1);
        Prova.setTipusProva(classProves.TIP_REPAS);
        Prova.setDia(cal.getTime());
        Prova.setSeleccio(Filtre);
        Prova.setNumPreguntes(objLlistaTrobats.ITEMS.size());
        Prova.setNumRespostes(0);
        Prova.setTemps(0L);
        Prova.setAcabada(false);
        db.insProves(Prova);
        db.close();
        Intent myIntent = new Intent(this, act_preg.class);
        myIntent.putExtra(act_preg.ARG_NUM_PROVA, "" + Prova.getId()); //Optional parameters
        startActivity(myIntent);

    }

}
