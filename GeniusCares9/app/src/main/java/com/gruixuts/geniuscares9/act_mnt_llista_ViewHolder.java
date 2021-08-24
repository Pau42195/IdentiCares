package com.gruixuts.geniuscares9;

import android.content.Intent;
import android.view.MotionEvent;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

public class act_mnt_llista_ViewHolder extends RecyclerView.ViewHolder implements View.
        OnClickListener {

    private final TextView tst_Nom;
    private final TextView tst_Cognom1;

    act_mnt_llista_ViewHolder(@NonNull View itemView) {
        super(itemView);
        tst_Nom = itemView.findViewById(R.id.tst_nom);
        tst_Cognom1 = itemView.findViewById(R.id.tst_cognom1);
        itemView.setOnClickListener(this);
    }

    void ompleFila(@NonNull classDiccionari item) {
        tst_Nom.setText(item.getNom());
        tst_Cognom1.setText(item.getCognom1());
    }

    @Override
    public void onClick(View v) {
        //listener.m_onClick(v, getAdapterPosition());
        String text = "Click element de la posició " + getAdapterPosition() + "   id=" + getItemId();
        Toast.makeText(v.getContext(), text, Toast.LENGTH_SHORT).show();
        Intent myIntent = new Intent(v.getContext(), act_mnt_edita.class);
        myIntent.putExtra(act_mnt_edita.ARG_ITEM_ID, "" + getAdapterPosition());
        v.getContext().startActivity(myIntent);
    }

}
