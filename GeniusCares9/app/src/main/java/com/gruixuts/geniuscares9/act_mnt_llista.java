package com.gruixuts.geniuscares9;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.recyclerview.widget.DividerItemDecoration;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;

public class act_mnt_llista extends AppCompatActivity  {

    GestorDB db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mnt_llista);

        setupToolbar();
        setupRecyclerView();

    }

    private void setupToolbar() {
        Toolbar toolbar = findViewById(R.id.tst_toolbar);
        setSupportActionBar(toolbar);
    }

    private void setupRecyclerView() {
        RecyclerView recyclerView = findViewById(R.id.tst_recyclerView);
        db=  new GestorDB(getApplicationContext());
        db.open();
        recyclerView.setAdapter(new act_mnt_llista_Adapter(objLlistaTrobats.ITEMS));
        recyclerView.setLayoutManager(new LinearLayoutManager(this));

        DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(recyclerView.getContext(),
                ((LinearLayoutManager) recyclerView.getLayoutManager()).getOrientation());
        recyclerView.addItemDecoration(dividerItemDecoration);
    }
}