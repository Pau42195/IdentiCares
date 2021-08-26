package com.gruixuts.geniuscares9;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

/*    public void goToColors(View view) {
        Intent myIntent = new Intent(MainActivity.this, act_colors.class);
        MainActivity.this.startActivity(myIntent);
    }

 */

    public void goToImportExport(View view) {
        Intent myIntent = new Intent(MainActivity.this, act_import_export.class);
        MainActivity.this.startActivity(myIntent);
    }

    public void goToManteniment(View view) {
        Intent myIntent = new Intent(MainActivity.this, act_mnt_sel.class);
        MainActivity.this.startActivity(myIntent);
    }
/*
    public void goToTest(View view) {
        Intent myIntent = new Intent(MainActivity.this, act_mnt_llista.class);
        MainActivity.this.startActivity(myIntent);
    }
*/
}