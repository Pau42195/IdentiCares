package com.gruixuts.identicares;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.provider.BaseColumns;
import android.util.Log;

import java.text.ParsePosition;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Random;
import java.util.TimeZone;

public class GestorDB {


    public static final int DATABASE_VERSION = 5;
    public static final String DATABASE_NAME = "IdentiCares.db";

    public static SimpleDateFormat frmtData = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

    public static Date AData(String DataTxt) {
        return frmtData.parse(DataTxt, new ParsePosition(0));
    }

    // Definició de les taules
    private static abstract class DiccionariDef implements BaseColumns {
        public static final String TABLE_NAME = "Diccionari";
        public static final String LLISTA_CAMPS = "Id,Imatges,Nom,Cognom1,Cognom2,Curs,Codi,PAV,Comentaris,Grup,NextTipus,NextData,AMemoritzar";

        public static final String Id = "Id";
        //public static final String Catala = "Catala";  // A eliminar
        //public static final String Basc = "Basc";   // A eliminar
        public static final String Imatges = "Imatges";
        public static final String Nom = "Nom";
        public static final String Cognom1 = "Cognom1";
        public static final String Cognom2 = "Cognom2";
        public static final String Curs = "Curs";
        public static final String Codi = "Codi";
        public static final String Grup = "Grup";   // Serveix per arganitzar l'aprenentatge o repassos. Poden ser dates
        public static final String PAV = "PAV";
        public static final String Comentaris = "Comentaris";
        public static final String NextTipus = "NextTipus";  // 1h,1d,1s,1m,6m
        public static final String NextData = "NextData";
        public static final String AMemoritzar = "AMemoritzar"; // A eliminar

    }

    private static abstract class ProvesDef implements BaseColumns {
        public static final String TABLE_NAME = "Proves";
        public static final String LLISTA_CAMPS = "Id,Dia,TipusProva,Seleccio,NumPreguntes,NumRespostes,Temps,Acabada";

        public static final String Id = "Id";
        public static final String Dia = "Dia";
        public static final String TipusProva = "TipusProva";
        public static final String Seleccio = "Seleccio";
        public static final String NumPreguntes = "NumPreguntes";
        public static final String NumRespostes = "NumRespostes";
        public static final String Temps = "Temps";
        public static final String Acabada = "Acabada";

    }

    private static abstract class ResultatsDef implements BaseColumns {
        public static final String TABLE_NAME = "Resultats";
        //        public static final String LLISTA_CAMPS = "Dia,IdProva,IdEntDic,Pregunta,Resposta,Correcta,Errors,Temps,Valoracio";
        public static final String LLISTA_CAMPS = "Dia,IdProva,IdEntDic,Resposta,Errors,Temps,Valoracio";

        public static final String Dia = "Dia";
        public static final String IdProva = "IdProva";
        public static final String IdEntDic = "IdEntDic";
        //public static final String Pregunta = "Pregunta";
        public static final String Resposta = "Resposta";  // Nom,Cognom1,Cognom2,Curs
        //public static final String Correcta = "Correcta"; // A Eliminar --> Errors
        public static final String Errors = "Errors";  // 0 => Correcta
        // Errors comesos: Nom, Cognom1,... Es tracta de tipificar-los
        public static final String Temps = "Temps";
        public static final String Valoracio = "Valoracio";  // Per a prioritzar i veure progrés
    }

    // Sentencies per a la creació de taules
    private static final String Diccionari_TABLE_CREATE = "create table " + DiccionariDef.TABLE_NAME
            + " (" + DiccionariDef.Id + " integer primary key, "
            //+ DiccionariDef.Catala + " text, "
            //+ DiccionariDef.Basc + " text, "
            + DiccionariDef.Imatges + " text, "
            + DiccionariDef.Nom + " text, "
            + DiccionariDef.Cognom1 + " text, "
            + DiccionariDef.Cognom2 + " text, "
            + DiccionariDef.Curs + " text, "
            + DiccionariDef.Codi + " text, "
            + DiccionariDef.Grup + " text, "
            + DiccionariDef.PAV + " text, "
            + DiccionariDef.Comentaris + " text, "
            + DiccionariDef.NextTipus + " text, "
            + DiccionariDef.NextData + " text, "
            + DiccionariDef.AMemoritzar + " integer ); ";

    private static final String Proves_TABLE_CREATE = "create table " + ProvesDef.TABLE_NAME
            + "(" + ProvesDef.Id + " integer primary key, "
            + ProvesDef.Dia + " text, "
            + ProvesDef.TipusProva + " text, "
            + ProvesDef.Seleccio + " text, "
            + ProvesDef.NumPreguntes + " integer, "
            + ProvesDef.NumRespostes + " integer, "
            + ProvesDef.Temps + " integer, "
            + ProvesDef.Acabada + " integer );  ";

    private static final String Resultats_TABLE_CREATE = "create table " + ResultatsDef.TABLE_NAME
            + "(" + ResultatsDef.Dia + " text, "
            + ResultatsDef.IdProva + " integer, "
            + ResultatsDef.IdEntDic + " integer, "
//            + ResultatsDef.Pregunta + " text, "
            + ResultatsDef.Resposta + " text, "
//            + ResultatsDef.Correcta + " text, "
            + ResultatsDef.Errors + " text, "
            + ResultatsDef.Temps + " text, "
            + ResultatsDef.Valoracio + " text) ; ";


    private class DBHandler extends SQLiteOpenHelper {

        public DBHandler(Context context) {
            super(context, DATABASE_NAME, null, DATABASE_VERSION);
        }

        @Override
        public void onCreate(SQLiteDatabase db) {
            db.execSQL(Diccionari_TABLE_CREATE);
            db.execSQL(Proves_TABLE_CREATE);
            db.execSQL(Resultats_TABLE_CREATE);
        }

        @Override
        public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
            db.execSQL("DROP TABLE IF EXISTS " + DiccionariDef.TABLE_NAME);
            db.execSQL("DROP TABLE IF EXISTS " + ProvesDef.TABLE_NAME);
            db.execSQL("DROP TABLE IF EXISTS " + ResultatsDef.TABLE_NAME);
            onCreate(db);
        }
    }

    private Context context;
    private SQLiteDatabase db;
    private DBHandler openHelper; //Gestor de base de datos

    public GestorDB(Context context) {
        this.context = context;
        this.openHelper = new DBHandler(this.context);
    }

    //Obrir i tancar la base de dades

    public GestorDB open() {
        this.db = openHelper.getWritableDatabase(); //Crea/abre la base de datos para la lectura/escritura
        return this;
    }

    public void close() {
        this.db.close();
    }

    // Función públiques d'accés a les dades


    //Selecció

    public ArrayList<classDiccionari> selDiccionari(String Filtre, String Ordre) {
        ArrayList<classDiccionari> list = new ArrayList<classDiccionari>();
        String SQLtxt;

        SQLtxt = "Select " + DiccionariDef.LLISTA_CAMPS + " from " + DiccionariDef.TABLE_NAME;
        if (Filtre.length() > 0) {
            SQLtxt += " where " + Filtre;
        }
        if (Ordre.length() > 0) {
            SQLtxt += " order by " + Ordre;
        }
        SQLtxt += " ;";
        Cursor cursor = this.db.rawQuery(SQLtxt, null);
        if (cursor.moveToFirst()) {
            do {
                try {
                    classDiccionari entrada = new classDiccionari(cursor);
                    list.add(entrada);
                } catch (Exception ex) {
                    Log.e("GestorDB", "selDiccionari: Error al crear Diccionari");
                }
            } while (cursor.moveToNext());
        }

        if (cursor != null && !cursor.isClosed()) {//Se cierra el cursor si no está cerrado ya
            cursor.close();
        }
        if (Ordre.length() > 0) {
            return list;
        } else {
            return Desordena(list);
        }
    }

    public classDiccionari selEntDic(Integer Id) {
        String SQLtxt;

        SQLtxt = "Select " + DiccionariDef.LLISTA_CAMPS + " from " + DiccionariDef.TABLE_NAME + " where Id=" + Id + ";";
        Cursor cursor = this.db.rawQuery(SQLtxt, null);
        if (cursor.moveToFirst()) {
            try {
                classDiccionari entrada = new classDiccionari(cursor);
                cursor.close();
                return entrada;
            } catch (Exception ex) {
                Log.e("GestorDB", "selDiccionari: Error al crear Diccionari");
            }
        }

        if (cursor != null && !cursor.isClosed()) {//Se cierra el cursor si no está cerrado ya
            cursor.close();
        }
        return null;
    }

    public ArrayList<classDiccionari> selDiccionariAntiguetat(String Filtre, String Ordre, Integer NumEntrades) {
        ArrayList<classDiccionari> list = new ArrayList<classDiccionari>();
        String SQLtxt;


        SQLtxt = "Select ";
        SQLtxt += "Diccionari.* from ((select * from ( ";
        SQLtxt += "( SELECT Max(Dia) AS UltDeDia, IdEntDic as UltIdEntDic FROM Resultats GROUP BY Resultats.IdEntDic ) as Ult ";
        SQLtxt += "INNER JOIN Resultats as Rst ON (Ult.UltIdEntDic = Rst.IdEntDic) AND (Ult.UltDeDia = Rst.Dia))) as pp ";
        SQLtxt += "INNER JOIN Diccionari on IdEntDic=Diccionari.Id) where ((Valoracio <> 'Obl') ";
        if (Filtre.length() > 0) {
            SQLtxt += " and " + Filtre + ") ";
        } else {
            SQLtxt += ") ";
        }
        SQLtxt += " ORDER BY Dia";
        if (NumEntrades > 0) {
            SQLtxt += " limit " + NumEntrades + " ";
        }
        SQLtxt += ";";

        Cursor cursor = this.db.rawQuery(SQLtxt, null);
        if (cursor.moveToFirst()) {
            do {
                try {
                    classDiccionari entrada = new classDiccionari(cursor);
                    list.add(entrada);
                } catch (Exception ex) {
                    Log.e("GestorDB", "selDiccionari: Error al crear Diccionari");
                }
            } while (cursor.moveToNext());
        }

        if (cursor != null && !cursor.isClosed()) {//Se cierra el cursor si no está cerrado ya
            cursor.close();
        }
        if (NumEntrades == 0) {
            return list;
        } else {
            return Desordena(list);
        }
    }


    public ArrayList<classDiccionari> selDiccionariRevisar(String Filtre, String Ordre, Integer NumEntrades) {
        ArrayList<classDiccionari> list = new ArrayList<classDiccionari>();
        String SQLtxt;
        Cursor cursor;

        SQLtxt = "Select ";
        SQLtxt += "Diccionari.* from ((select * from ( ";
        SQLtxt += "( SELECT Max(Dia) AS UltDeDia, IdEntDic as UltIdEntDic FROM Resultats GROUP BY Resultats.IdEntDic ) as Ult ";
        SQLtxt += "INNER JOIN Resultats as Rst ON (Ult.UltIdEntDic = Rst.IdEntDic) AND (Ult.UltDeDia = Rst.Dia))) as pp ";
        SQLtxt += "INNER JOIN Diccionari on IdEntDic=Diccionari.Id) where Valoracio = 'Rev' ";
        if (Ordre == "Ant") {
            SQLtxt += " ORDER BY Dia";
        }
        if (NumEntrades > 0) {
            SQLtxt += " limit " + NumEntrades + " ";
        }
        SQLtxt += ";";

        try {
            cursor = this.db.rawQuery(SQLtxt, null);
        } catch (Exception ex) {
            Log.e("GestorDB", "selDiccionariRevisar: Error al obrir el cursor del Diccionari");
            return list;
        }
        if (cursor.moveToFirst()) {
            do {
                try {
                    classDiccionari entrada = new classDiccionari(cursor);
                    list.add(entrada);
                } catch (Exception ex) {
                    Log.e("GestorDB", "selDiccionariRevisar: Error al crear Diccionari");
                }
            } while (cursor.moveToNext());
        }

        if (cursor != null && !cursor.isClosed()) {//Se cierra el cursor si no está cerrado ya
            cursor.close();
        }
        if (Ordre.length() > 0) {
            return list;
        } else {
            return Desordena(list);
        }
    }


    public ArrayList<classDiccionari> selDiccionariSeguir() {
        ArrayList<classDiccionari> list = new ArrayList<classDiccionari>();
        String SQLtxt;
        Cursor cursor;

        Integer NumEntrades;
        String Ordre ="";
        String Filtre;
        String Top;




        SQLtxt = "Select ";
        SQLtxt += "Diccionari.* from ((select * from ( ";
        SQLtxt += "( SELECT Max(Dia) AS UltDeDia, IdEntDic as UltIdEntDic FROM Resultats GROUP BY Resultats.IdEntDic ) as Ult ";
        SQLtxt += "INNER JOIN Resultats as Rst ON (Ult.UltIdEntDic = Rst.IdEntDic) AND (Ult.UltDeDia = Rst.Dia))) as pp ";
        SQLtxt += "INNER JOIN Diccionari on IdEntDic=Diccionari.Id) where Valoracio = 'Rev' ";
        SQLtxt += ";";

        try {
            cursor = this.db.rawQuery(SQLtxt, null);
        } catch (Exception ex) {
            Log.e("GestorDB", "selDiccionariRevisar: Error al obrir el cursor del Diccionari");
            return list;
        }
        if (cursor.moveToFirst()) {
            do {
                try {
                    classDiccionari entrada = new classDiccionari(cursor);
                    list.add(entrada);
                } catch (Exception ex) {
                    Log.e("GestorDB", "selDiccionariRevisar: Error al crear Diccionari");
                }
            } while (cursor.moveToNext());
        }

        if (cursor != null && !cursor.isClosed()) {//Se cierra el cursor si no está cerrado ya
            cursor.close();
        }
        if (Ordre.length() > 0) {
            return list;
        } else {
            return Desordena(list);
        }
    }




    public ArrayList<classProves> selProves(String Filtre, String Ordre) {
        ArrayList<classProves> list = new ArrayList<classProves>();
        String SQLtxt;

        SQLtxt = "Select " + ProvesDef.LLISTA_CAMPS + " from " + ProvesDef.TABLE_NAME;
        if (Filtre.length() > 0) {
            SQLtxt += " where " + Filtre;
        }
        if (Ordre.length() > 0) {
            SQLtxt += " order by " + Ordre;
        }
        SQLtxt += " ;";
        Cursor cursor = this.db.rawQuery(SQLtxt, null);
        if (cursor.moveToFirst()) {
            do {
                try {
                    classProves entrada = new classProves(cursor);
                    list.add(entrada);
                } catch (Exception ex) {
                    Log.e("GestorDB", "selProves: Error al crear Proves");
                }
            } while (cursor.moveToNext());
        }

        if (cursor != null && !cursor.isClosed()) {//Se cierra el cursor si no está cerrado ya
            cursor.close();
        }
        return list;
    }

    public ArrayList<classResultats> selResultats(String Filtre, String Ordre) {
        ArrayList<classResultats> list = new ArrayList<classResultats>();
        String SQLtxt;

        SQLtxt = "Select " + ResultatsDef.LLISTA_CAMPS + " from " + ResultatsDef.TABLE_NAME;
        if (Filtre.length() > 0) {
            SQLtxt += " where " + Filtre;
        }
        if (Ordre.length() > 0) {
            SQLtxt += " order by " + Ordre;
        }
        SQLtxt += " ;";
        Cursor cursor = this.db.rawQuery(SQLtxt, null);
        if (cursor.moveToFirst()) {
            do {
                try {
                    classResultats entrada = new classResultats(cursor);
                    list.add(entrada);
                } catch (Exception ex) {
                    Log.e("GestorDB", "selResultats: Error al crear Resultats");
                }
            } while (cursor.moveToNext());
        }

        if (cursor != null && !cursor.isClosed()) {//Se cierra el cursor si no está cerrado ya
            cursor.close();
        }
        return list;
    }



    public ArrayList<classDiccionari> selExamenFallosUlt() {
        ArrayList<classDiccionari> list = new ArrayList<classDiccionari>();
        String SQLtxt;
        Integer UltProva;
        Cursor cursor;

        SQLtxt = "select max(IdProva) from " + ResultatsDef.TABLE_NAME;
        cursor = this.db.rawQuery(SQLtxt, null);
        cursor.moveToFirst();
        UltProva = cursor.getInt(0);


        SQLtxt = "select BascId from " + ResultatsDef.TABLE_NAME;
        SQLtxt += " WHERE (IdProva=" + UltProva + ") AND (Correcta = 0);";
        cursor = this.db.rawQuery(SQLtxt, null);
        if (cursor.moveToFirst()) {
            do {
                SQLtxt = "Select Id,Catala,Basc from Diccionari where (Id = " + cursor.getInt(0) + ");";
                Cursor cursor2 = this.db.rawQuery(SQLtxt, null);
                cursor2.moveToFirst();

                classDiccionari entrada = new classDiccionari(cursor2.getInt(0),
                        cursor2.getString(1),
                        cursor2.getString(2));

                list.add(entrada);
            } while (cursor.moveToNext());
        }
        if (cursor != null && !cursor.isClosed()) {//Se cierra el cursor si no está cerrado ya
            cursor.close();
        }

        return Desordena(list);
    }

    private ArrayList<classDiccionari> Desordena(ArrayList<classDiccionari> list) {
        ArrayList<classDiccionari> result = new ArrayList<classDiccionari>();
        Random rand = new Random();

        while (list.size() > 0) {
            result.add(list.remove(rand.nextInt(list.size())));
        }
        return result;
    }


    public Integer UltimaProva() {
        String SQLtxt = "select max(IdProva) from " + ResultatsDef.TABLE_NAME;
        Cursor cursor = this.db.rawQuery(SQLtxt, null);
        cursor.moveToFirst();
        return cursor.getInt(0);
    }

    public Integer QuantsRep(String TipRep) {
        String[] Camps = new String[2];
        String Selec;
        Calendar cal = Calendar.getInstance(TimeZone.getTimeZone("Europe/Madrid"));
        Camps[0] = "Count(Id)";
        Camps[1] = "datetime(NextData)";
        Selec = "(NextTipus = '" + TipRep + "' and datetime(NextData)<'" + frmtData.format(cal.getTime()) +  "')";
        try {
            Cursor cr = db.query(DiccionariDef.TABLE_NAME, Camps, Selec, null, null, null, null);
            if (cr.moveToFirst()) {

                return cr.getInt(0);

            }
        } catch (Exception e) {
            Log.d("GestorDB", "QuantsRep: Accés al fer query '" + Selec + "'");
        }
        return 0;
    }

    //Eliminació
    public void delDiccionari() {
        db.delete(DiccionariDef.TABLE_NAME, "-1", null);
    }
    public void delEntDic(Integer Id) {
        db.delete(DiccionariDef.TABLE_NAME, "Id=" + Id, null);
    }
    public void delProves() {
        db.delete(ProvesDef.TABLE_NAME, "-1", null);
    }
    public void delResultats() {
        db.delete(ResultatsDef.TABLE_NAME, "-1", null);
    }

    //Insertar
    public void insDiccionari(classDiccionari ent) {
        ContentValues values = new ContentValues();

        // Parells clau-valor
        values.put(DiccionariDef.Id, ent.getId());
        values.put(DiccionariDef.Imatges, ent.getImatges());
        values.put(DiccionariDef.Nom, ent.getNom());
        values.put(DiccionariDef.Cognom1, ent.getCognom1());
        values.put(DiccionariDef.Cognom2, ent.getCognom2());
        values.put(DiccionariDef.Curs, ent.getCurs());
        values.put(DiccionariDef.Codi, ent.getCodi());
        values.put(DiccionariDef.PAV, ent.getPAV());
        values.put(DiccionariDef.Comentaris, ent.getComentaris());
        values.put(DiccionariDef.Grup, ent.getGrup());
        values.put(DiccionariDef.NextTipus, ent.getNextTipus());
        if (ent.getNextData() == null) {
            values.put(DiccionariDef.NextData,"null");
        } else {
            values.put(DiccionariDef.NextData, ent.getNextDataTxt());
        }
        values.put(DiccionariDef.AMemoritzar, ent.getAMemoritzar());
        // Insertar...
        db.insert(DiccionariDef.TABLE_NAME, null, values);
    }

    public void insProves(classProves prova) {   // Per importació
        ContentValues values = new ContentValues();
        values.put(ProvesDef.Id, prova.getId());
        values.put(ProvesDef.Dia, prova.getDiaTxt() );
        values.put(ProvesDef.TipusProva, prova.getTipusProva());
        values.put(ProvesDef.Seleccio, prova.getSeleccio());
        values.put(ProvesDef.NumPreguntes, prova.getNumPreguntes());
        values.put(ProvesDef.NumRespostes, prova.getNumRespostes());
        values.put(ProvesDef.Temps, prova.getTemps());
        values.put(ProvesDef.Acabada, prova.getAcabada());
        db.insert(ProvesDef.TABLE_NAME, null, values);
    }
    /*
    public classProves(Integer id,
                       Date dia,
                       String tipusprova,
                       String seleccio,
                       int numpreguntes,
                       int numrespostes,
                       Long temps,
                       Boolean acabada) {

     */
    public classProves insNovaProvaAprendre(String sel, Integer numpreg, Long temps) {
        String SQLtxt = "select max(Id) from " + ProvesDef.TABLE_NAME;
        Cursor cursor = this.db.rawQuery(SQLtxt, null);
        classProves Prova;
        Date Ara =  Calendar.getInstance(TimeZone.getTimeZone("Europe/Madrid")).getTime();

        cursor.moveToFirst();
        int NouId = cursor.getInt(0);
        Prova = new classProves(NouId,Ara,"a",sel,numpreg,1,temps,false);
        return Prova;
    }

    public Integer NumNovaProva() {
        String SQLtxt = "select max(Id) from " + ProvesDef.TABLE_NAME;
        Cursor cursor = this.db.rawQuery(SQLtxt, null);
        cursor.moveToFirst();
        return (cursor.getInt(0)+1);
    }

    public void insResultat(classResultats Rslt) {
        ContentValues values = new ContentValues();

        // Parells clau-valor
        values.put(ResultatsDef.Dia, Rslt.getDiaTxt());
        values.put(ResultatsDef.IdProva, Rslt.getIdProva());
        values.put(ResultatsDef.IdEntDic, Rslt.getIdEntDic());
        //values.put(ResultatsDef.Pregunta, Rslt.getPregunta());
        values.put(ResultatsDef.Resposta, Rslt.getResposta());
        //values.put(ResultatsDef.Correcta, Rslt.getCorrecta());
        values.put(ResultatsDef.Temps, Rslt.getTemps());
        values.put(ResultatsDef.Valoracio, Rslt.getValoracio());


        db.insert(ResultatsDef.TABLE_NAME, null, values);

    }

    public void creaDiccionari(classDiccionari ent) {
        Cursor cursor;
        if (ent.getId() != 0) {
            String SQLtxt = "select Id from " + DiccionariDef.TABLE_NAME + " where (Id=" + ent.getId() + ")" ;
            cursor = this.db.rawQuery(SQLtxt, null);
            if (cursor.moveToFirst())
                ent.setId(0);
        }
        if (ent.getId()==0) {

            String SQLtxt = "select max(Id) from " + DiccionariDef.TABLE_NAME;
            cursor = this.db.rawQuery(SQLtxt, null);
            cursor.moveToFirst();
            int NouId = cursor.getInt(0);
            ent.setId(NouId + 1);
        }
        insDiccionari(ent);
    }

    //Actualitzar
    public void actRepassat(int IdEntrada, String Dia) {
        ContentValues values = new ContentValues();
        String[] Camps = {"Apres", "Repas1h", "Repas1d", "Repas1s", "Repas1m", "Repas6m"};
        Cursor cursor = db.query(DiccionariDef.TABLE_NAME, Camps, "Id=" + IdEntrada, null, null, null, null);
        Calendar cal = Calendar.getInstance(TimeZone.getTimeZone("Europe/Madrid"));
        String Actual = frmtData.format(cal.getTime());
        cal.add(Calendar.HOUR, -1);
        String RefData = frmtData.format(cal.getTime());
        cursor.moveToFirst();
        if ((cursor.getString(0).compareTo(RefData) < 0) && (cursor.getString(1) == null)) {
            values.put("Repas1h", Actual);
        }
        cal.add(Calendar.HOUR, -23);
        RefData = frmtData.format(cal.getTime());
        if ((cursor.getString(0).compareTo(RefData) < 0) && (cursor.getString(2) == null)) {
            values.put("Repas1d", Actual);
        }
        cal.add(Calendar.DATE, -6);
        RefData = frmtData.format(cal.getTime());
        if ((cursor.getString(0).compareTo(RefData) < 0) && (cursor.getString(3) == null)) {
            values.put("Repas1s", Actual);
        }
        cal.add(Calendar.DATE, -21);
        RefData = frmtData.format(cal.getTime());
        if ((cursor.getString(0).compareTo(RefData) < 0) && (cursor.getString(4) == null)) {
            values.put("Repas1m", Actual);
        }
        cal.add(Calendar.DATE, -(5 * 28));
        RefData = frmtData.format(cal.getTime());
        if ((cursor.getString(0).compareTo(RefData) < 0) && (cursor.getString(5) == null)) {
            values.put("Repas6m", Actual);
        }
        db.update(DiccionariDef.TABLE_NAME, values, "Id=" + IdEntrada, null);

    }


    public void actDiccionari(classDiccionari ent) {
        ContentValues values = new ContentValues();
        values.put(DiccionariDef.Imatges, ent.getImatges());
        values.put(DiccionariDef.Nom, ent.getNom());
        values.put(DiccionariDef.Cognom1, ent.getCognom1());
        values.put(DiccionariDef.Cognom2, ent.getCognom2());
        values.put(DiccionariDef.Curs, ent.getCurs());
        values.put(DiccionariDef.Codi, ent.getCodi());
        values.put(DiccionariDef.Grup, ent.getGrup());
        values.put(DiccionariDef.PAV, ent.getPAV());
        values.put(DiccionariDef.Comentaris, ent.getComentaris());
        values.put(DiccionariDef.NextTipus, ent.getNextTipus());
        values.put(DiccionariDef.NextData, ent.getNextDataTxt());
        values.put(DiccionariDef.AMemoritzar, ent.getAMemoritzar());
        db.update(DiccionariDef.TABLE_NAME, values, "Id=" + ent.getId(), null);

    }


    public void actProves(classProves prova) {   // Per importació
        ContentValues values = new ContentValues();
        //values.put(ProvesDef.Id, prova.getId());
        values.put(ProvesDef.Dia, prova.getDiaTxt() );
        values.put(ProvesDef.TipusProva, prova.getTipusProva());
        values.put(ProvesDef.Seleccio, prova.getSeleccio());
        values.put(ProvesDef.NumPreguntes, prova.getNumPreguntes());
        values.put(ProvesDef.NumRespostes, prova.getNumRespostes());
        values.put(ProvesDef.Temps, prova.getTemps());
        values.put(ProvesDef.Acabada, prova.getAcabada());
        db.update(ProvesDef.TABLE_NAME, values, "Id=" + prova.getId(), null);
    }



}
