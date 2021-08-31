package com.gruixuts.geniuscares9;

import android.content.Context;
import android.content.DialogInterface;
import android.view.View;

import androidx.appcompat.app.AlertDialog;

public class Global {

    // Dialegs

    public static void Missatge(String Missatge, String Titol, Context context) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(Missatge);
        builder.setTitle(Titol);
        builder.setCancelable(false);
        builder.setNeutralButton("Entesos",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.cancel();
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();
    }

    public static void MissatgeError(String Missatge, Context context) {
        Missatge(Missatge, "Error!!!",context);
    }

    public static boolean MissatgeSiNo(String Missatge, String Titol, Context context) {
        // MsgBox ¿?
        final boolean[] Resposta = new boolean[1];
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(Missatge);
        builder.setTitle(Titol);
        builder.setCancelable(false);
        builder.setNegativeButton("No",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.cancel();
                        Resposta[0] =false;
                    }
                });
        builder.setPositiveButton("Sí",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.cancel();
                        Resposta[0] =true;
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();
        return Resposta[0];
        // Fi MsgBox
    }

    // Paràmetres
    public static final String ARG_PREG_AVAL_ITEM_ID = "item_id";
    public static final String ARG_PREG_AVAL_RESP = "resposta";
    public static final String ARG_PREG_AVAL_AVAL = "avaluacio";


}
