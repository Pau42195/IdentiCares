package com.gruixuts.geniuscares9;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class act_mnt_llista_Adapter extends RecyclerView.Adapter<act_mnt_llista_ViewHolder> {
    private List<classDiccionari> dades;

    public act_mnt_llista_Adapter(@NonNull List<classDiccionari> data) {
        this.dades = data;
    }

    @Override
    @NonNull
    public act_mnt_llista_ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View row = LayoutInflater.from(parent.getContext()).inflate(R.layout.activity_mnt_llista_elem, parent, false);
        return new act_mnt_llista_ViewHolder(row);
    }

     @Override
    public void onBindViewHolder(act_mnt_llista_ViewHolder holder, int position) {
        holder.ompleFila(dades.get(position));
    }

    @Override
    public int getItemCount() {
        return dades.size();
    }
}
