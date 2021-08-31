package com.gruixuts.geniuscares9;

import android.database.Cursor;

import java.text.SimpleDateFormat;
import java.util.Date;

public class classResultats {

    public static SimpleDateFormat frmtData = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

    public static final String VAL_PERFECTE = "Per";   //
    public static final String VAL_REPASSAR = "Rep";  //Petit fallo que reforça la memòria
    public static final String VAL_APRES = "Apr";  //He tornat a fer un PAV, com si ho acabés d'aprendre
    public static final String VAL_OBLIDAT = "Obl";  //Ho he oblidat, ho he de tornar a aprendre
    public static final String Separador = ",";

    private Date Dia_;
    private Integer IdProva_;
    private Integer IdItem_;
    private String RepasTipus_;
    private Date RepasData_;
    private String Resposta_; // classResposta.toString() <--> classResposta.separador
    private String Errors_; // Errors comesos: Nom, Cognom1,... Es tracta de tipificar-los
    private Long Temps_;
    private String Valoracio_; // Perfecte, Revisar, Aprèsm, Oblidat... veure classe Resultats


    public classResultats(Date dia,
                          Integer idprova,
                          Integer iditem,
                          String repastipus,
                          Date repasdata,
                          String resposta,
                          String errors,
                          Long temps,
                          String valoracio) {
        setDia(dia);
        setIdProva(idprova);
        setIdItem(iditem);
        setRepasTipus(repastipus);
        setRepasData(repasdata);
        setResposta(resposta);
        setErrors(errors);
        setTemps(temps);
        setValoracio(valoracio);
    }

    public classResultats() {

    }

    public classResultats(String Cadena) {  //Això és per importat
        String[] camps;

        camps = Cadena.split(Separador);
        String R = camps[0];
        assert (R.equals("R"));
        Dia_=GestorDB.AData(camps[1]);
        try {
            IdProva_ = Integer.parseInt(camps[2]);
        } catch (Exception e) {
            IdProva_ = Integer.parseInt(camps[2].substring(1));
        }
        try {
            IdItem_ = Integer.parseInt(camps[3]);
        } catch (Exception e) {
            IdItem_ = Integer.parseInt(camps[3].substring(1));
        }
        RepasTipus_ = camps[4];
        RepasData_ =GestorDB.AData(camps[5]);

        Resposta_=camps[6];
        Errors_ = camps[7];
        try {
            Temps_ =  Long.parseLong(camps[8]);
        } catch (Exception e) {
            Temps_ = Long.parseLong(camps[8].substring(1));
        }
        Valoracio_=camps[9];

    }

    public classResultats(Cursor cursor) {
        Dia_ = cursor.getString(0) == null ? null : GestorDB.AData(cursor.getString(0));
        IdProva_ = cursor.getInt(1);
        IdItem_ = cursor.getInt(2);
        RepasTipus_ = cursor.getString(3);
        RepasData_ = cursor.getString(4) == null ? null : GestorDB.AData(cursor.getString(4));
        Resposta_ = cursor.getString(5);
        Errors_ = cursor.getString(6);
        Temps_ = cursor.getLong(7);
        Valoracio_ = cursor.getString(8);
    }


    public Date getDia() {
        return Dia_;
    }

    public String getDiaTxt() {
        if (Dia_ == null) {
            return "";
        } else {
            return frmtData.format(Dia_);
        }
    }

    public void setDia(Date dia) {
        Dia_ = dia;
    }

    public Integer getIdProva() {
        return IdProva_;
    }

    public void setIdProva(Integer idProva) {
        IdProva_ = idProva;
    }

    public Integer getIdItem() {
        return IdItem_;
    }

    public void setIdItem(Integer idEntDic) {
        IdItem_ = idEntDic;
    }

    public String getRepasTipus() {
        return RepasTipus_;
    }

    public void setRepasTipus(String repasTipus) {
        RepasTipus_ = repasTipus;
    }

    public Date getRepasData() {
        return RepasData_;
    }

    public String getRepasDataTxt() {
        if (RepasData_ == null) {
            return "";
        } else {
            return frmtData.format(RepasData_);
        }
    }

    public void setRepasData(Date repasData) {
        RepasData_ = repasData;
    }

    public String getResposta() {
        return Resposta_;
    }

    public void setResposta(String resposta) {
        Resposta_ = resposta;
    }

    public String getErrors() {
        return Errors_;
    }

    public void setErrors(String errors) {
        Errors_ = errors;
    }

    public Long getTemps() {
        return Temps_;
    }

    public void setTemps(Long temps) {
        Temps_ = temps;
    }

    public String getValoracio() {
        return Valoracio_;
    }

    public void setValoracio(String valoracio) {
        Valoracio_ = valoracio;
    }

    public String toString() {
        String rslt;
        rslt = getDiaTxt() + Separador;
        rslt += IdProva_.toString() + Separador;
        rslt += IdItem_.toString() + Separador;
        rslt += RepasTipus_ + Separador;
        rslt += getRepasDataTxt() + Separador;
        rslt += Resposta_ + Separador;
        rslt += Errors_ + Separador;
        rslt += Temps_.toString() + Separador;
        rslt += Valoracio_;

        return rslt;
    }


    public void setTexte(String Cadena) {
    }


}
