package com.gruixuts.geniuscares8;

import android.view.View;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

public class act_manteniment_llista_ViewHolder extends RecyclerView.ViewHolder implements View
        .OnClickListener {

    private final TextView ll_Codi;
    private final TextView ll_Nom;
    private final TextView ll_Cognom1;
    private final TextView ll_Id;
    private final act_manteniment_llista_RecyclerViewOnItemClickListener listener;


    public act_manteniment_llista_ViewHolder(@NonNull View itemView, @NonNull act_manteniment_llista_RecyclerViewOnItemClickListener listener) {
        super(itemView);
        ll_Codi = itemView.findViewById(R.id.ll_codi);
        ll_Nom = itemView.findViewById(R.id.ll_nom);
        ll_Cognom1 = itemView.findViewById(R.id.ll_cognom1);
        ll_Id = itemView.findViewById(R.id.ll_id);
        this.listener = listener;
        itemView.setOnClickListener(this);
    }

    public void bindRow(@NonNull classDiccionari item) {
        ll_Codi.setText(item.getCodi());
        ll_Nom.setText(item.getNom());
        ll_Cognom1.setText(item.getCognom1());
        ll_Id.setText(item.getId());
    }

    @Override
    public void onClick(View v) {
        listener.m_onClick(v, getAdapterPosition());
    }

}
