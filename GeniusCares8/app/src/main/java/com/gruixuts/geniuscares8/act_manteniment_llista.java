package com.gruixuts.geniuscares8;

import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.recyclerview.widget.DividerItemDecoration;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class act_manteniment_llista   extends AppCompatActivity {

    GestorDB db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_manteniment_llista);

        setupToolbar();
        setupRecyclerView();
        db=  new GestorDB(getApplicationContext());
    }

    private void setupToolbar() {
        Toolbar toolbar = findViewById(R.id.mnt_toolbar);
        setSupportActionBar(toolbar);
        setTitle("Trobats: " + objLlistaTrobats.ITEMS.size());
        toolbar.setTitle(getTitle());

    }

    private void setupRecyclerView() {
        RecyclerView recyclerView = findViewById(R.id.mnt_recyclerView);
        final List<classDiccionari> items = objLlistaTrobats.ITEMS;
        recyclerView.setAdapter(new act_manteniment_llista_Adapter(items, new act_manteniment_llista_RecyclerViewOnItemClickListener() {
            @Override
            public void m_onClick(View v, int position) {
                String text = position + " " + items.get(position).getNom();
                Toast.makeText(act_manteniment_llista.this, text, Toast.LENGTH_SHORT).show();
            }
        }));
        //VERTICAL
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        //HORIZONTAL
        //recyclerView.setLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.HORIZONTAL, false));

        DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(recyclerView.getContext(),
                ((LinearLayoutManager) recyclerView.getLayoutManager()).getOrientation());
        recyclerView.addItemDecoration(dividerItemDecoration);
    }


}
