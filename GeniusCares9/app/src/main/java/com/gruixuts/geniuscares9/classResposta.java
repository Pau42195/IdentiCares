package com.gruixuts.geniuscares9;

import org.w3c.dom.DOMStringList;

import java.util.List;

public class classResposta {
    private String nom_;
    private String cognom1_;
    private String cognom2_;
    private String curs_;

    public static final String Separador=":";

    public  classResposta () {
        nom_="";
        cognom1_="";
        cognom2_="";
        curs_="";
    }

    public  classResposta (String Llista) {
        String[]  ll;
        ll = ("i"+Separador+Llista+Separador+"f").split(Separador);
        // ll = Llista.split(Separador);
        // Es fa així per si ve una llista buida, que split no inclou les buides d'inici ni de final
        assert(ll.length==6);
        nom_ = ll[1];
        cognom1_ = ll[2];
        cognom2_ = ll[3];
        curs_ = ll[4];
    }

    public String getNom() {
        return nom_;
    }

    public void setNom(String nom) {
        assert(nom.indexOf(Separador)==-1);
        nom_ = nom;
    }

    public String getCognom1() {
            return cognom1_;
    }

    public void setCognom1(String cognom1) {
        assert(cognom1.indexOf(Separador)==-1);
        cognom1_ = cognom1;
    }

    public String getCognom2() {
        return cognom2_;
    }

    public void setCognom2(String cognom2) {
        assert(cognom2.indexOf(Separador)==-1);
        cognom2_ = cognom2;
    }

    public String getCurs() {
        return curs_;
    }

    public void setCurs(String curs) {
        assert(curs.indexOf(Separador)==-1);
        curs_ = curs;
    }

    public String toString() {
        return nom_ + Separador + cognom1_ + Separador + cognom2_ + Separador + curs_;
    }
}
