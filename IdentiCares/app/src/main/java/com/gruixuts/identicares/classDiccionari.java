package com.gruixuts.identicares;

import android.database.Cursor;
import android.util.Log;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Random;

public class classDiccionari {

    public static SimpleDateFormat frmtData = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

    private Integer Id;

    private String Imatges;
    private String Nom;
    private String Cognom1;
    private String Cognom2;
    private String Curs;

    private String Codi;
    private String Grup;
    private String PAV;
    private String Comentaris;
    private String NextTipus;
    private Date NextData;
    private Boolean AMemoritzar;

    public static final int LongNomImg = 4;  // Longitud del nom de la carpeta que conté les imatges

    public String NovaImatge() {
        String rslt="";
        int n_aleat;
        Random aleatori = new Random(System.currentTimeMillis());
        for ( int n=0;n<LongNomImg;n++) {
            n_aleat=aleatori.nextInt(61);
            char c;
            if (n_aleat < 10) {
                c=(char) (n_aleat+48);
            } else if (n_aleat< 36) {
                c=(char) (n_aleat+55);
            } else {
                c=(char) (n_aleat+61);
            }
            rslt +=c;
        }
        return rslt;
    }

    public classDiccionari(Integer id, String imatges, String nom, String cognom1, String cognom2, String curs, String codi, String pav, String comentaris, String grup, String nexttipus, Date nextdata, Boolean amemoritzar) {
        Id = id;
        if (imatges == null) {
            Imatges = NovaImatge();
        } else if (imatges.equals("")) {
            Imatges = NovaImatge();
        } else {
            Imatges = imatges;
        }
        Nom = nom;
        Cognom1 = cognom1;
        Cognom2 = cognom2;
        Curs = curs;
        Codi = codi;
        this.PAV = pav;
        Comentaris = comentaris;
        Grup = grup;
        NextTipus = nexttipus;
        NextData = nextdata;
        AMemoritzar = amemoritzar;
    }

    public classDiccionari(Cursor cursor) {
        Id = cursor.getInt(0);
        Imatges = cursor.getString(1);
        Nom = cursor.getString(2);
        Cognom1 = cursor.getString(3);
        Cognom2 = cursor.getString(4);
        Curs = cursor.getString(5);
        Codi = cursor.getString(6);
        PAV = cursor.getString(7);
        Comentaris = cursor.getString(8);
        Grup = cursor.getString(9);
        NextTipus = cursor.getString(10);
        NextData = cursor.getString(11) == null ? null : GestorDB.AData(cursor.getString(11));
        AMemoritzar = cursor.getInt(12) == 0 ? false : true;
    }

    ;

    public classDiccionari(Integer id, String nom, String cognom1) {
        Id = id;
        Codi = "";
        Imatges = NovaImatge();
        Nom = nom;
        Cognom1=cognom1;
        this.PAV = "";
        Comentaris = "";
        Grup = "";
        NextTipus = "a";
        NextData = null;
        AMemoritzar = true;

    }

    public classDiccionari() {
        Id = 0;
        Codi = "";
        Imatges = NovaImatge();
        Nom = "";
        Cognom1 = "";
        Cognom2 = "";
        Curs = "";
        PAV = "";
        Comentaris = "";
        Grup = "";
        NextTipus = "a";
        NextData = null;
        AMemoritzar = true;
    }

    public Integer getId() {
        return Id;
    }

    public void setId(Integer id) {
        Id = id;
    }

    public String getCodi() {
        return Codi;
    }

    public void setCodi(String codi) {
        Codi = codi;
    }

    public String getImatges() {
        return Imatges;
    }

    public void setImatges(String imatges) {
        Imatges = imatges;
    }

    public String getNom() {
        return Nom;
    }

    public void setNom(String nom) { Nom = nom; }

    public String getCognom1() {
        return Cognom1;
    }

    public void setCognom1(String cognom1) { Cognom1 = cognom1; }

    public String getCognom2() {
        return Cognom2;
    }

    public void setCognom2(String cognom2) { Cognom2 = cognom2; }

    public String getCurs() { return Curs; }

    public void setCurs(String curs) { Curs = curs; }

    public String getPAV() {
        return PAV;
    }

    public void setPAV(String PAV) {
        this.PAV = PAV;
    }

    public String getComentaris() {
        return Comentaris;
    }

    public void setComentaris(String comentaris) {
        Comentaris = comentaris;
    }

    public String getGrup() {
        return Grup;
    }

    public void setGrup(String grup) {
        Grup = grup;
    }

    public String getNextTipus() {
        return NextTipus;
    }

    public void setNextTipus(String nexttipus) {
        NextTipus = nexttipus;
    }

    public Date getNextData() {
        return NextData;
    }

    public String getNextDataTxt() {
        if (NextData == null) {
            return "";
        } else {
            return frmtData.format(NextData);
        }
    }

    public void setNextData(Date nextdata) {
        NextData = nextdata;
    }

    public void setNextData(String nextdata) {
        if (nextdata=="") {
            NextData = null;
        } else {
            try {
                NextData = frmtData.parse(nextdata);
            } catch (Exception ex) {
                Log.d("class Diccionari", "setNextData: Error al parse");
                NextData=null;
            }
        }
    }

    public Boolean getAMemoritzar() {
        return AMemoritzar;
    }

    public void setAMemoritzar(Boolean amemoritzar) {
        AMemoritzar = amemoritzar;
    }


}
