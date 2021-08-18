package com.gruixuts.geniuscares3;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void MiraLlista(View view) {
        Toast.makeText(MainActivity.this, "A la llista!", Toast.LENGTH_SHORT).show();
    }
}