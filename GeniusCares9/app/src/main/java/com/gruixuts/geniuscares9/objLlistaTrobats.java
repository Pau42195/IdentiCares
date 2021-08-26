package com.gruixuts.geniuscares9;

import android.content.Context;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class objLlistaTrobats {

    public static final List<classDiccionari> ITEMS = new ArrayList<classDiccionari>();
    public static final Map<String, classDiccionari> ITEM_MAP = new HashMap<String, classDiccionari>();


    public static void NouSQLtxt (String filtre, String ordre, Context c) {
        ITEMS.clear();
        ITEM_MAP.clear();
        GestorDB db;
        db= new GestorDB(c);
        ArrayList<classDiccionari> Llista;
        db.open();
        Llista = db.selDiccionari(filtre,ordre);
        db.close();
        for (Integer i = 1; i <= Llista.size(); i++) {
            addItem(i.toString(), Llista.get(i-1));
        }
    }

    private static void addItem(String Pos, classDiccionari item) {
        ITEMS.add(item);
        ITEM_MAP.put(item.getId().toString(), item);
    }

}
