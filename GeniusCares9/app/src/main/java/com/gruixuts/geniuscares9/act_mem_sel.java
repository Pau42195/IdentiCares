package com.gruixuts.geniuscares9;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.RadioGroup;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class act_mem_sel  extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mem_sel);
        ((TextView) findViewById(R.id.edtMmrId)).setText("");
        ((TextView) findViewById(R.id.edtMmrNom)).setText("");
        ((TextView) findViewById(R.id.edtMmrCognom1)).setText("");
        ((TextView) findViewById(R.id.edtMmrCognom2)).setText("");
        ((TextView) findViewById(R.id.edtMmrCurs)).setText("");
        ((TextView) findViewById(R.id.edtMmrSiCodi)).setText("");
        ((TextView) findViewById(R.id.edtMmrNoCodi)).setText("");
        ((TextView) findViewById(R.id.edtMmrSiGrup)).setText("");
        ((TextView) findViewById(R.id.edtMmrNoGrup)).setText("");
    }


    public void MmrBusca(View view) {
        String Filtre = "";
        if (((TextView) findViewById(R.id.edtMmrId)).getText().length()!=0) {
            Filtre += " and (Id = " + ((TextView) findViewById(R.id.edtMmrId)).getText() + " )";
        }
        if (((TextView) findViewById(R.id.edtMmrNom)).getText().length()!=0) {
            Filtre += " and (Nom like '" + ((TextView) findViewById(R.id.edtMmrNom)).getText() + "' )";
        }
        if (((TextView) findViewById(R.id.edtMmrCognom1)).getText().length()!=0) {
            Filtre += " and (Cognom1 like '" + ((TextView) findViewById(R.id.edtMmrCognom1)).getText() + "' )";
        }
        if (((TextView) findViewById(R.id.edtMmrCognom2)).getText().length()!=0) {
            Filtre += " and (Cognom2 like '" + ((TextView) findViewById(R.id.edtMmrCognom2)).getText() + "' )";
        }
        if (((TextView) findViewById(R.id.edtMmrCurs)).getText().length()!=0) {
            Filtre += " and (Curs like '" + ((TextView) findViewById(R.id.edtMmrCurs)).getText() + "' )";
        }
        if (((TextView) findViewById(R.id.edtMmrSiCodi)).getText().length()!=0) {
            Filtre += " and (Codi like '" + ((TextView) findViewById(R.id.edtMmrSiCodi)).getText() + "' )";
        }
        if (((TextView) findViewById(R.id.edtMmrNoCodi)).getText().length()!=0) {
            Filtre += " and not(Codi like '" + ((TextView) findViewById(R.id.edtMmrNoCodi)).getText() + "' )";
        }
        if (((TextView) findViewById(R.id.edtMmrSiGrup)).getText().length()!=0) {
            Filtre += " and (Grup like '" + ((TextView) findViewById(R.id.edtMmrSiGrup)).getText() + "' )";
        }
        if (((TextView) findViewById(R.id.edtMmrNoGrup)).getText().length()!=0) {
            Filtre += " and not(Grup like '" + ((TextView) findViewById(R.id.edtMmrNoGrup)).getText() + "' )";
        }
        Filtre += " and (AMemoritzar <> 0  )";
        Filtre += " and (NextTipus = 'a')";

        int rb = ((RadioGroup) findViewById(R.id.mem_grpOrdre)).getCheckedRadioButtonId();
        String Ordre;
        if (rb==R.id.mem_radNom ) {
            Ordre = "Nom";
        } else if (rb==R.id.mem_radCognom ) {
            Ordre = "Cognom1";
        } else if (rb==R.id.mem_radCod ) {
            Ordre = "Codi";
        } else {
            Ordre = "";
        }


        if (Filtre.length()>4) Filtre=Filtre.substring(4);
        objLlistaTrobats.NouSQLtxt(Filtre,Ordre,getApplicationContext());

        Intent myIntent = new Intent(act_mem_sel.this, act_mem.class);
        startActivity(myIntent);

    }

}
