package com.gruixuts.geniuscares8;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class act_manteniment_llista_Adapter extends RecyclerView.Adapter<act_manteniment_llista_ViewHolder> {
    private final List<classDiccionari> data;
    private final act_manteniment_llista_RecyclerViewOnItemClickListener actmntRecyclerViewOnItemClickListener;

    public act_manteniment_llista_Adapter(@NonNull List<classDiccionari> data,
                                          @NonNull act_manteniment_llista_RecyclerViewOnItemClickListener
                                                     actmntRecyclerViewOnItemClickListener) {
        this.data = data;
        this.actmntRecyclerViewOnItemClickListener = actmntRecyclerViewOnItemClickListener;
    }

    @Override
    @NonNull
    public act_manteniment_llista_ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View row = LayoutInflater.from(parent.getContext()).inflate(R.layout.activity_manteniment_llista_element, parent, false);
        return new act_manteniment_llista_ViewHolder(row, actmntRecyclerViewOnItemClickListener);
    }

    @Override
    public void onBindViewHolder(act_manteniment_llista_ViewHolder holder, int position) {
        holder.bindRow(data.get(position));
    }

    @Override
    public int getItemCount() {
        return data.size();
    }


}