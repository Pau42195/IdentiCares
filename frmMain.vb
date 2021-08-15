Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.String
Imports System.Data.SqlClient

'Dim Paraules() As String = {"te", "noe", "humo", "rey", "leo", "hacha", "oca", "feo", "boa", "taza",
'"dado", "atun", "dama", "toro", "tele", "ducha", "dique", "tufo", "tubo", "nuez",
'"nido", "niño", "nemo", "noria", "anillo", "nacho", "nuca", "onoff", "nieve", "mesa",
'"moto", "mano", "mama", "mar", "miel", "macho", "mago", "mafia", "mapa", "rosa",
'"rueda", "rana", "remo", "horror", "rollo", "racha", "roca", "rifa", "arpa", "lazo",
'"lata", "luna", "lima", "loro", "lola", "leche", "lago", "elfo", "lobo", "choza",
'"chita", "china", "chema", "churro", "chal", "chacha", "cheque", "chufa", "chupa", "casa",
'"gato", "canoa", "cama", "carro", "cal", "coche", "coca", "cafe", "copa", "foso",
'"foto", "fan", "fama", "faro", "fila", "ficha", "foca", "fofa", "fobia", "pozo",
'"pato", "pan", "puma", "bar", "pelo", "pecho", "boca", "bufe", "papa", "tizas"}




Public Class clsCursGenius
    Dim TipProva As String = ""
    Dim Comptador As Integer = 0
    Dim NumParaules As Integer = 10
    Dim NumErrades As Integer = 0
    Dim MaxProves As Integer
    Dim rnd As New Random()
    Dim hInici As DateTime
    Dim hFi As DateTime
    Dim Estona As Long
    Dim EstonaTotal As Long
    Dim AMemoritzar As New Collection
    Dim ARevisar As New Collection
    Dim CodiActual As String

    Dim ExamBe As Integer = 0
    Dim ExamPse As Integer = 0
    Dim ExamMal As Integer = 0
    Dim IniciUltimaProva As DateTime


    Const NumPregs = 10
    Const FraccSeg = 1000



#Region "Formulari.General"
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: esta línea de código carga datos en la tabla 'GeniusDataSet.DiccProves' Puede moverla o quitarla según sea necesario.
        Me.DiccProvesTableAdapter.Fill(Me.GeniusDataSet.DiccProves)
        'TODO: esta línea de código carga datos en la tabla 'GeniusDataSet.Basc' Puede moverla o quitarla según sea necesario.
        Me.TabControl1.SelectedIndex = My.Settings.PestanyaActiva
        Me.BascTableAdapter.Fill(Me.GeniusDataSet.Basc)
        LlegeixParaules()
        txtNumDigits.Text = My.Settings.DigitsNumLlarg
        Timer1.Interval = 1000
        cmdPAVOk.Visible = False
        cmdRepAbandona.Visible = False
        cmdRepPista.Visible = False

        tvwTesaurus.Nodes.Clear()
        AddNivell("", tvwTesaurus.Nodes)
        tvwTesaurus.SelectedNode = tvwTesaurus.Nodes(0)

        dtpExamDesde.Value = CDate("2018-01-01")
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Select Case TipProva
            Case "Fitxes"
                txtCrono.Text = Format(Int((Now().Ticks - hInici.Ticks) / 10000000), "#,###") 'En segons
            Case "NumLlargMem"
                txtCronoMem.Text = Format(Int((Now().Ticks - hInici.Ticks) / 10000000), "#,###") 'En segons
            Case "NumLlargRec"
                txtCronoRec.Text = Format(Int((Now().Ticks - hInici.Ticks) / 10000000), "#,###") 'En segons
            Case Else
                MsgBox("Error. Tipus de prova desconegut")
        End Select
    End Sub

    Private Sub ArrancaCrono()
        hInici = Now()
        hFi = #0:0:0#
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.PestanyaActiva = Me.TabControl1.SelectedIndex
        My.Settings.Save()
    End Sub

    Private Function DataStd(Moment As DateTime) As String
        Return Moment.ToString("u").Replace("Z", "")
    End Function



#End Region


#Region "Fitxes"

    Dim Paraules(100)



    Private Class Prova
        Dim Ord As Integer = 0
        Dim NumProva As Integer
        Dim TempsTot As Decimal = 0.0
        Public S3 As Integer = 0
        Public S10 As Integer = 0
        Public Errs As Integer = 0
        Public EsOk As Boolean = True
        Public NumPar(NumPregs) As Integer
        Public TempsResp(NumPregs) As Decimal
        Public NErrs(NumPregs) As Integer

        Public Sub RegistraRes(Num As Integer, Temps As Decimal)
            NumPar(Ord) = Num
            TempsResp(Ord) = Temps
            Ord += 1
            TempsTot += Temps
            If Temps < 3 * FraccSeg Then
                S3 += 1
            ElseIf Temps < 10 * FraccSeg Then
                S10 += 1
            End If
        End Sub
        Public Sub RegistraErr()
            Errs += 1
            NErrs(Ord) += 1
        End Sub
        Public Sub Grava()
            NumProva = clsCursGenius.GravaProva(TempsTot / NumPregs, S3, S10, Errs, EsOk)
            For n = 1 To NumPregs
                clsCursGenius.GravaResultat(NumProva, n, NumPar(n - 1), TempsResp(n - 1), NErrs(n - 1))
            Next
        End Sub


    End Class

    Dim ProvaAct As Prova

    Private Sub cmdInici_Click(sender As Object, e As EventArgs) Handles cmdInici.Click
        ProvaAct = New Prova
        TipProva = "Fitxes"
        Timer1.Start()
        EstonaTotal = 0
        NumErrades = 0
        Comptador = 1
        txtTempsMig.Text = ""
        txtNumErrades.Text = ""
        txtT1.Text = ""
        txtT2.Text = ""
        txtT3.Text = ""
        txtT4.Text = ""
        txtT5.Text = ""
        txtT6.Text = ""
        txtT7.Text = ""
        txtT8.Text = ""
        txtT9.Text = ""
        txtT10.Text = ""
        txtComptador.Text = ""
        NouNum()
    End Sub

    Private Sub txtParaula_Validating(sender As Object, e As CancelEventArgs) Handles txtParaula.Validating
        If txtNum.Text <> "" Then
            FiParaula()
        End If
    End Sub

    Private Sub FiParaula()
        If Paraules(CInt(txtNum.Text) - 1) <> txtParaula.Text Then
            Errada()
            ProvaAct.RegistraErr()
            Exit Sub
        End If

        If hFi = #0:0:0# Then
            hFi = Now()
        End If
        Estona = CLng((hFi.Ticks - hInici.Ticks) / 10000000 * FraccSeg) 'En milisegons si FracSeg = 1000
        EstonaTotal += Estona
        tabFitxes.Controls("txtT" & Comptador).Text = Format(Estona, "#,###")
        txtCrono.Text = ""
        ProvaAct.RegistraRes(CInt(txtNum.Text), Estona)
        If Comptador < NumParaules Then
            Comptador += 1
            NouNum()
        Else
            txtNum.Text = ""
            txtParaula.Text = ""
            txtTempsMig.Text = Format(EstonaTotal / NumParaules, "#,###")
            Timer1.Stop()
            ProvaAct.Grava()
        End If
        txtComptador.Text = Comptador & "/" & NumParaules
    End Sub

    Private Sub txtParaula_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParaula.KeyDown
        If e.KeyCode = Keys.Enter Then
            FiParaula()

        ElseIf e.KeyCode >= Keys.A And e.KeyCode <= Keys.Z Then
            If hFi = #0:0:0# Then
                hFi = Now()
            End If
        Else
            Errada()
        End If
    End Sub

    Private Sub Errada()
        NumErrades += 1
        txtNumErrades.Text = NumErrades
        hFi = #0:0:0#
    End Sub

    Private Sub LlegeixParaules()
        Try

            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand
                Dim rdrSQL As SqlDataReader
                connection.Open()
                txtSQL = "SELECT Num, Paraula FROM  Fitxes"
                cmmSQL = New SqlCommand(txtSQL, connection)
                rdrSQL = cmmSQL.ExecuteReader
                If rdrSQL.HasRows Then
                    While rdrSQL.Read()
                        Paraules(rdrSQL.GetInt32(0) - 1) = rdrSQL.GetString(1)
                    End While
                    rdrSQL.Close()
                Else
                    MsgBox("Error, Problemes amb la base de dades")
                    Error 1001
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error al intentar llegir de la base de dades" & vbNewLine &
                    ex.Message)
        End Try


    End Sub

    Private Function GravaProva(Tmig As Decimal, S3 As Integer, S10 As Integer, Errs As Integer, EsOk As Boolean) As Integer
        Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
            Dim txtSQL As String
            Dim cmmSQL As SqlCommand


            connection.Open()
            txtSQL = "INSERT INTO [Fitxes-Proves]  ( Data, TempsMig, Sub3, Sub10, Errors, NumPregs, EsBona) VALUES "
            txtSQL &= "('" & DataStd(Now()) & "',"
            txtSQL &= Format(Tmig, "0") & ","
            txtSQL &= S3 & ","
            txtSQL &= S10 & ","
            txtSQL &= Errs & ","
            txtSQL &= NumPregs & ","
            txtSQL &= IIf(EsOk, -1, 0) & ")"

            cmmSQL = New SqlCommand(txtSQL, connection)
            cmmSQL.ExecuteNonQuery()

        End Using

        Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
            Dim txtSQL As String
            Dim cmmSQL As SqlCommand
            connection.Open()
            txtSQL = "SELECT Max(Id) AS IdMax "
            txtSQL &= "FROM [Fitxes-Proves]"

            cmmSQL = New SqlCommand(txtSQL, connection)
            Return cmmSQL.ExecuteScalar
        End Using
    End Function

    Private Sub GravaResultat(Prova As Integer, Ordre As Integer, NumParaula As Integer, Temps As Decimal, NErrs As Integer)

        Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
            Dim txtSQL As String
            Dim cmmSQL As SqlCommand


            connection.Open()
            txtSQL = "INSERT INTO Fitxes-Resultats  (IdProva, Ordre, Num, Temps, Errors) VALUES "
            txtSQL &= "(" & Prova & ","
            txtSQL &= Ordre & ","
            txtSQL &= NumParaula & ","
            txtSQL &= Temps & ","
            txtSQL &= NErrs & ")"

            cmmSQL = New SqlCommand(txtSQL, connection)
            cmmSQL.ExecuteNonQuery()

        End Using

    End Sub


#End Region

#Region "NumeroLlarg"


    Private Sub NouNum()
        txtParaula.Text = ""
        txtNum.Text = rnd.Next(1, 100)
        txtParaula.Focus()
        ArrancaCrono()
    End Sub

    Private Sub cmdCreaNum_Click(sender As Object, e As EventArgs) Handles cmdCreaNum.Click
        My.Settings.DigitsNumLlarg = txtNumDigits.Text
        My.Settings.Save()
        txtNumARecordar.Text = ""
        txtNumRecordat.Text = ""
        txtNumRecordat.ForeColor = Color.Black
        While Len(txtNumARecordar.Text) < Val(txtNumDigits.Text)
            txtNumARecordar.Text &= Format(rnd.Next(1, 100), "00")
        End While
        TipProva = "NumLlargMem"
        hInici = Now()
        hInici = Now()
        Timer1.Start()
    End Sub

    Private Sub cmdEsborra_Click(sender As Object, e As EventArgs) Handles cmdEsborra.Click
        Estona = CLng((Now().Ticks - hInici.Ticks) / 10000000 * FraccSeg) 'En milisegons si FracSeg = 1000
        txtNumARecordar.Visible = False
        txtNumRecordat.Focus()
        TipProva = "NumLlargRec"
        hInici = Now()

    End Sub


    Private Sub txtNumRecordat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumRecordat.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            FiNumLlarg(0)
        End If

    End Sub

    Private Sub FiNumLlarg(Aband As Integer)
        EstonaTotal = CLng((Now().Ticks - hInici.Ticks) / 10000000 * FraccSeg) 'En milisegons si FracSeg = 1000
        Timer1.Stop()
        txtNumARecordar.Visible = True
        If txtNumARecordar.Text = txtNumRecordat.Text Then
            txtNumRecordat.ForeColor = Color.DarkGreen
        Else
            txtNumRecordat.ForeColor = Color.DarkRed
        End If
        Try

            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand


                connection.Open()
                txtSQL = "INSERT INTO [NumLlarg-Proves]  (Data, TempsMem, TempsRec, Numero, Resultat,Abandonat) VALUES "
                txtSQL &= "('" & Format(Now(), "yyyy-MM-dd HH:mm:ss") & "',"
                txtSQL &= Estona & ","
                txtSQL &= EstonaTotal & ",'"
                txtSQL &= txtNumARecordar.Text & "','"
                txtSQL &= txtNumRecordat.Text & "',"
                txtSQL &= Aband & ")"

                cmmSQL = New SqlCommand(txtSQL, connection)
                cmmSQL.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            MsgBox("Error al gravar resultat" & vbNewLine &
                   ex.Message)
        End Try

    End Sub

    Private Sub cmdAbandona_Click(sender As Object, e As EventArgs) Handles cmdAbandona.Click
        FiNumLlarg(-1)
    End Sub


#End Region


#Region "Memoritzar basc"

    Private Class EntradaDic
        Public Catala As String
        Public Basc As String
        Public PAV As String
        Public TipusProva As String
        Public IdDicc As ULong
    End Class

    Dim IdProva As Integer

    Private Sub BascBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.BascBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.GeniusDataSet)

    End Sub

    Private Sub cmdMirarPendent_Click(sender As Object, e As EventArgs) Handles cmdMirarPendent.Click
        MirarPendent()
    End Sub

    Private Sub MirarPendent()

        Const IncrementFila = 25
        '       Dim NouCheck As CheckBox
        Dim Col As Integer
        Dim FilaNou As Integer
        Dim NumCtrl As Integer = 1
        Dim CosesPendents As Integer = 0

        If Not Interrupcio() Then
            Exit Sub
        End If


        Do While Not (tabBasc.Controls("chkRev" & NumCtrl) Is Nothing)
            tabBasc.Controls.Remove(tabBasc.Controls("chkRev" & NumCtrl))
            NumCtrl += 1
        Loop

        Col = Me.chkRevPendents.Left
        FilaNou = chkRevPendents.Top + IncrementFila + 5
        NumCtrl = 1

        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand
                Dim rdrSQL As SqlDataReader
                Dim Ara As String
                Dim LimitH As Date
                Dim TipRepas As String = ""
                connection.Open()
                Ara = DataStd(Now())
                txtSQL = "SELECT Planificada, COUNT(Catala) "
                txtSQL &= " FROM  Basc "
                txtSQL &= " WHERE  Planificada <= '" & Ara & "' AND IsNull(Apres,'')='' "
                txtSQL &= " GROUP BY Planificada;"
                cmmSQL = New SqlCommand(txtSQL, connection)
                rdrSQL = cmmSQL.ExecuteReader
                If rdrSQL.HasRows Then
                    While rdrSQL.Read()
                        'Paraules(rdrSQL.GetInt32(0) - 1) = rdrSQL.GetString(1)
                        NouCheckBox(FilaNou, Col, NumCtrl,
                            "Fer: Planificada " & rdrSQL.GetValue(0) & " (" & rdrSQL.GetValue(1) & ")")
                        FilaNou += IncrementFila
                        NumCtrl += 1
                        CosesPendents += 1
                    End While
                End If
                rdrSQL.Close()
                For n = 1 To 4
                    Select Case n
                        Case 1
                            TipRepas = "h"
                            LimitH = DateAdd(DateInterval.Hour, -1, Now())
                        Case 2
                            TipRepas = "d"
                            LimitH = DateAdd(DateInterval.Day, -1, Now())
                        Case 3
                            TipRepas = "s"
                            LimitH = DateAdd(DateInterval.Day, -7, Now())
                        Case 4
                            TipRepas = "m"
                            LimitH = DateAdd(DateInterval.Day, -28, Now())
                    End Select
                    txtSQL = "SELECT MAX(Apres), COUNT(Catala) "
                    txtSQL &= " FROM  Basc "
                    txtSQL &= " WHERE  Apres <= '" & DataStd(LimitH) & "' AND ISNULL(Repas1" & TipRepas & ",'')='' "
                    txtSQL &= " GROUP BY MONTH(Apres)*35+DAY(Apres);"
                    cmmSQL = New SqlCommand(txtSQL, connection)
                    rdrSQL = cmmSQL.ExecuteReader
                    If rdrSQL.HasRows Then
                        While rdrSQL.Read()
                            'Paraules(rdrSQL.GetInt32(0) - 1) = rdrSQL.GetString(1)
                            NouCheckBox(FilaNou, Col, NumCtrl,
                                "Repàs 1" & TipRepas & ": Après:" & rdrSQL.GetValue(0) & " (" & rdrSQL.GetValue(1) & ")")
                            FilaNou += IncrementFila
                            NumCtrl += 1
                            CosesPendents += 1
                        End While
                    End If
                    rdrSQL.Close()
                Next n

                'Fallos fets a revisar
                txtSQL = "Select  DiccProves.Id, DiccProves.Origen, DiccProves.Inici, "
                txtSQL &= " Count(DiccResultats.IdEntrada) As Total "
                txtSQL &= " From DiccResultats INNER Join DiccProves On DiccResultats.IdProva = DiccProves.Id "
                txtSQL &= " Where (IsNull(Data,'')<>'') and (IsNull(Correcta,0)=0) and (IsNull(Revisada,0)=0) "
                txtSQL &= " GROUP BY DiccProves.Id,  DiccProves.Origen, DiccProves.Inici;"
                cmmSQL = New SqlCommand(txtSQL, connection)
                rdrSQL = cmmSQL.ExecuteReader
                If rdrSQL.HasRows Then
                    While rdrSQL.Read()
                        'Paraules(rdrSQL.GetInt32(0) - 1) = rdrSQL.GetString(1)
                        NouCheckBox(FilaNou, Col, NumCtrl,
                                "Revisar ex:" & rdrSQL.GetValue(0) & ": " & rdrSQL.GetValue(1) & " " & rdrSQL.GetValue(2) & " (" & rdrSQL.GetValue(3) & ")")
                        FilaNou += IncrementFila
                        NumCtrl += 1
                        CosesPendents += 1
                    End While
                End If
                rdrSQL.Close()

                'Examens ue han quedat a mitjes
                txtSQL = "Select  DiccProves.Id,  DiccProves.Origen, DiccProves.Inici, "
                txtSQL &= " Count(DiccResultats.IdEntrada) As Total "
                txtSQL &= " From DiccResultats INNER Join DiccProves On DiccResultats.IdProva = DiccProves.Id "
                txtSQL &= " Where (IsNull(DiccProves.Final,'')='') and (IsNull(DiccResultats.Data,'')='')"
                txtSQL &= " GROUP BY DiccProves.Id,  DiccProves.Origen, DiccProves.Inici;"

                'txtSQL = "Select  DiccProves.Id, DiccProves.Origen, DiccProves.Filtre, DiccProves.Inici, "
                'txtSQL &= " Count(DiccResultats.IdEntrada) As Total, "
                'txtSQL &= " sum(case IsNull(Data,'') when '' then 1 else 0 end) as Pendent, "
                'txtSQL &= " sum(case IsNull(Data,'') when '' then 0 else 1 end) as Fet "
                'txtSQL &= " From DiccResultats INNER Join DiccProves On DiccResultats.IdProva = DiccProves.Id "
                'txtSQL &= " Where (IsNull(DiccProves.Final,'')='') "
                'txtSQL &= " GROUP BY DiccProves.Id, DiccProves.Origen, DiccProves.Filtre, DiccProves.Inici;"

                cmmSQL = New SqlCommand(txtSQL, connection)
                rdrSQL = cmmSQL.ExecuteReader
                If rdrSQL.HasRows Then
                    While rdrSQL.Read()
                        NouCheckBox(FilaNou, Col, NumCtrl,
                                "Seguir ex:" & rdrSQL.GetValue(0) & ": " & rdrSQL.GetValue(1) & " " & rdrSQL.GetValue(2) & " (" & rdrSQL.GetValue(3) & ")")
                        FilaNou += IncrementFila
                        NumCtrl += 1
                        CosesPendents += 1
                    End While
                End If
                rdrSQL.Close()


            End Using

        Catch ex As Exception
            MsgBox("Error al mirar Pendents" & vbNewLine &
                   ex.Message)
        End Try

        'Mirar estadístiques

        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand
                Dim rdrSQL As SqlDataReader
                Dim Ara As String
                Dim TipRepas As String = ""
                connection.Open()
                Ara = DataStd(Now())



                txtSQL = "	SELECT  "
                txtSQL &= "	count(Id), "
                txtSQL &= "	sum(Traduible*1), "  'Total traduibles
                txtSQL &= "	sum(Traduible-LEN(left(isnull(Basc,''),1))),  " 'Pendentsa de traduir
                txtSQL &= "	sum(Traduible*LEN(left(isnull(Basc,''),1))*(1-isdate(Planificada))),  " 'Traduides pendents de planificar
                txtSQL &= "	sum(Traduible*LEN(left(isnull(Basc,''),1))*isdate(Planificada)*(1-isdate(Apres))),  " 'Traduides planificades = prepadades
                txtSQL &= "	sum(isdate(Apres)),  "  'Apreses
                txtSQL &= "	sum(isdate(Repas1h )),  "
                txtSQL &= "	sum(isdate(Repas1d )),  "
                txtSQL &= "	sum(isdate(Repas1s )),  "
                txtSQL &= "	sum(isdate(Repas1m )),  "
                txtSQL &= "	sum(isdate(Repas6m )),  "
                'Control d'errors
                txtSQL &= "	sum((1-Traduible*1)*LEN(left(isnull(Basc,''),1))), " 'No traduibles traduides
                txtSQL &= "	sum((1-Traduible*1)*isdate(Planificada)), "  'No traduibles planificades
                txtSQL &= "	sum((1-Traduible*1)*isdate(Apres)), "     'No traduibles apreses
                txtSQL &= "	sum((1-LEN(left(isnull(Basc,''),1)))*isdate(Planificada)), " 'No traduides planificades
                txtSQL &= "	sum((1-LEN(left(isnull(Basc,''),1)))*isdate(Apres)), "  ' No traduides apreses
                txtSQL &= "	sum((1-isdate(Planificada))*isdate(Apres)), " 'No planificades apreses
                txtSQL &= "	sum((1-isdate(Apres))*isdate(Repas1h)), "   'No apreses repassades 1h
                txtSQL &= "	sum((1-isdate(Repas1h))*isdate(Repas1h)), "
                txtSQL &= "	sum((1-isdate(Repas1d))*isdate(Repas1s)), "
                txtSQL &= "	sum((1-isdate(Repas1s))*isdate(Repas1m)), "
                txtSQL &= "	sum((1-isdate(Repas1m))*isdate(Repas6m)) "
                txtSQL &= "	FROM  Basc; "


                cmmSQL = New SqlCommand(txtSQL, connection)
                rdrSQL = cmmSQL.ExecuteReader
                If rdrSQL.HasRows Then
                    rdrSQL.Read()
                    lblEstAApr.Text = rdrSQL.GetInt32(1).ToString("0")
                    lblEstNoTra.Text = rdrSQL.GetInt32(2).ToString("0")
                    lblEstNoPla.Text = rdrSQL.GetInt32(3).ToString("0")
                    lblEstPrep.Text = rdrSQL.GetInt32(4).ToString("0")
                    lblEstApre.Text = rdrSQL.GetInt32(5).ToString("0")
                    lblEstR1h.Text = rdrSQL.GetInt32(6).ToString("0")
                    lblEstR1d.Text = rdrSQL.GetInt32(7).ToString("0")
                    lblEstR1s.Text = rdrSQL.GetInt32(8).ToString("0")
                    lblEstR1m.Text = rdrSQL.GetInt32(9).ToString("0")
                    lblEstR6m.Text = rdrSQL.GetInt32(10).ToString("0")
                End If

                ControlErrorBasc(rdrSQL.GetInt32(11), "no traduibles traduides")
                ControlErrorBasc(rdrSQL.GetInt32(12), "no traduibles planificades")
                ControlErrorBasc(rdrSQL.GetInt32(13), "no traduibles apreses")
                ControlErrorBasc(rdrSQL.GetInt32(14), "no traduides planificades")
                ControlErrorBasc(rdrSQL.GetInt32(15), "no traduides apreses")
                ControlErrorBasc(rdrSQL.GetInt32(16), "no planificades apreses")
                ControlErrorBasc(rdrSQL.GetInt32(17), "no apreses amb repas1h")
                ControlErrorBasc(rdrSQL.GetInt32(18), "no repassades1h amb repas1d")
                ControlErrorBasc(rdrSQL.GetInt32(19), "no repassades1d amb repas1s")
                ControlErrorBasc(rdrSQL.GetInt32(20), "no repassades1s amb repas1m")
                ControlErrorBasc(rdrSQL.GetInt32(21), "no repassades1m amb repas6m")
                rdrSQL.Close()


            End Using

        Catch ex As Exception
            MsgBox("Error al mirar el Basc" & vbNewLine &
                   ex.Message)
        End Try



        If CosesPendents = 0 Then
            MsgBox("Res pendent")
        End If

    End Sub

    Sub ControlErrorBasc(NumError As Integer, TextCas As String)
        If NumError = 0 Then Exit Sub
        MsgBox("Hi ha " & NumError & " paraules " & TextCas)
    End Sub

    Private Sub NouCheckBox(Fila As Integer, Col As Integer, Num As Integer, Txt As String)

        Dim NouCheck As CheckBox

        NouCheck = New CheckBox
        NouCheck.Name = "chkRev" & Num
        NouCheck.Left = Col
        NouCheck.Top = Fila
        NouCheck.AutoSize = True
        NouCheck.Text = Txt
        tabBasc.Controls.Add(NouCheck)

    End Sub


    Private Sub chkRevPendents_CheckedChanged(sender As Object, e As EventArgs) Handles chkRevPendents.CheckedChanged
        Dim NumCtrl As Integer = 1
        Do While Not (tabBasc.Controls("chkRev" & NumCtrl) Is Nothing)
            CType(tabBasc.Controls("chkRev" & NumCtrl), CheckBox).Checked = chkRevPendents.Checked
            NumCtrl += 1
        Loop
    End Sub

    Private Function Interrupcio() As Boolean

        If AMemoritzar.Count > 0 Or ARevisar.Count > 0 Then
            If MsgBox("S'està fent alguna cosa. Ho interrumpeixo?", vbYesNo) = MsgBoxResult.No Then
                Return False
            End If
        End If

        AMemoritzar = New Collection
        ARevisar = New Collection
        MaxProves = 0
        IdProva = 0
        ExamBe = 0
        ExamPse = 0
        ExamMal = 0
        lblExamBe.Text = ""
        lblExamPse.Text = ""
        lblExamMal.Text = ""
        lblExamResp.Text = ""
        lblExamPend.Text = ""
        lblExamActual.Text = ""
        lblExamTotal.Text = ""

        Return True
    End Function

    Private Sub cmdFerPendent_Click(sender As Object, e As EventArgs) Handles cmdFerPendent.Click
        Dim NumCtrl As Integer = 1
        Dim Dia As String
        Dim texte As String
        Dim Limit As String
        Dim TipRepas As String
        Dim iReg As Integer = 0

        If Not Interrupcio() Then
            Exit Sub
        End If

        IniciUltimaProva = Now

        Do While (Not (tabBasc.Controls("chkRev" & NumCtrl) Is Nothing)) AndAlso Mid(tabBasc.Controls("chkRev" & NumCtrl).Text, 1, 3) = "Fer"
            'A memoritzar planificades
            If CType(tabBasc.Controls("chkRev" & NumCtrl), CheckBox).Checked Then
                texte = tabBasc.Controls("chkRev" & NumCtrl).Text
                Dia = CDate(Mid(texte, 18, 10))
                Try
                    Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                        Dim txtSQL As String
                        Dim cmmSQL As SqlCommand
                        Dim rdrSQL As SqlDataReader
                        Dim Entr As EntradaDic
                        connection.Open()
                        txtSQL = "SELECT ISNULL(Catala,''), ISNULL(Basc,''), ISNULL(PAV,'') "
                        txtSQL &= " FROM  Basc "
                        txtSQL &= " WHERE  CONVERT(nvarchar(10), Planificada, 103) = '" & Dia & "' AND IsNull(Apres,'')=''; "
                        cmmSQL = New SqlCommand(txtSQL, connection)
                        rdrSQL = cmmSQL.ExecuteReader
                        If rdrSQL.HasRows Then
                            While rdrSQL.Read()
                                Entr = New EntradaDic
                                Entr.Catala = rdrSQL.GetString(0)
                                Entr.Basc = rdrSQL.GetString(1)
                                Entr.PAV = rdrSQL.GetString(2)
                                Entr.TipusProva = "Mem"
                                AMemoritzar.Add(Entr)
                            End While
                            rdrSQL.Close()
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox("Error al llegir les fetes" & vbNewLine &
                           ex.Message)
                End Try
            End If
            'Repassos
            NumCtrl += 1
        Loop
        If AMemoritzar.Count = 0 Then
            ' A perassar
            Do While (Not (tabBasc.Controls("chkRev" & NumCtrl) Is Nothing)) AndAlso Mid(tabBasc.Controls("chkRev" & NumCtrl).Text, 1, 3) = "Rep"
                If CType(tabBasc.Controls("chkRev" & NumCtrl), CheckBox).Checked Then
                    '                Dia = Mid(tabBasc.Controls("chkRev" & NumCtrl).Text, 18, 10)
                    texte = tabBasc.Controls("chkRev" & NumCtrl).Text
                    Dia = CDate(Mid(texte, 17, 10))
                    TipRepas = Mid(texte, 8, 1)
                    Select Case TipRepas
                        Case "h"
                            Limit = DataStd(DateAdd(DateInterval.Hour, -1, Now()))
                        Case "d"
                            Limit = DataStd(DateAdd(DateInterval.Day, -1, Now()))
                        Case "s"
                            Limit = DataStd(DateAdd(DateInterval.Day, -7, Now()))
                        Case "m"
                            Limit = DataStd(DateAdd(DateInterval.Day, -28, Now()))
                        Case Else
                            MsgBox("Error al interpretar el tipus de repàs")
                            Limit = "1900-01-01 00:00:00Z"
                    End Select
                    Try
                        Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                            Dim txtSQL As String
                            Dim cmmSQL As SqlCommand
                            Dim rdrSQL As SqlDataReader
                            Dim Entr As EntradaDic
                            connection.Open()
                            txtSQL = "SELECT ISNULL(Catala,''), ISNULL(Basc,''), ISNULL(PAV,''),Id "
                            txtSQL &= " FROM  Basc "
                            txtSQL &= " WHERE  CONVERT(nvarchar(10), Apres, 121) = '" & Mid(DataStd(Dia), 1, 10) & "' AND Apres <= '" & Limit & "' AND IsNull(Repas1" & TipRepas & ",'')=''; "
                            cmmSQL = New SqlCommand(txtSQL, connection)
                            rdrSQL = cmmSQL.ExecuteReader
                            If rdrSQL.HasRows Then
                                While rdrSQL.Read()
                                    Entr = New EntradaDic
                                    Entr.Catala = rdrSQL.GetString(0)
                                    Entr.Basc = rdrSQL.GetString(1)
                                    Entr.PAV = rdrSQL.GetString(2)
                                    Entr.TipusProva = "Repas1" & TipRepas
                                    Entr.IdDicc = rdrSQL.GetValue(3)
                                    ARevisar.Add(Entr)
                                End While
                                rdrSQL.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox("Error al llegir les fetes" & vbNewLine &
                               ex.Message)
                    End Try
                End If
                NumCtrl += 1
            Loop
        End If
        If ARevisar.Count = 0 Then
            'Revisar examen
            Do While (Not (tabBasc.Controls("chkRev" & NumCtrl) Is Nothing)) AndAlso Mid(tabBasc.Controls("chkRev" & NumCtrl).Text, 1, 3) = "Rev"
                If CType(tabBasc.Controls("chkRev" & NumCtrl), CheckBox).Checked Then
                    Dim IdProvaAnt As Integer
                    IdProvaAnt = Val(tabBasc.Controls("chkRev" & NumCtrl).Text.Split(":")(1))
                    If IdProva = 0 Then
                        IdProva = CreaProva("REV", IdProvaAnt.ToString("0"))
                    Else
                        ActFiltProvaREV(IdProva, IdProvaAnt)
                    End If
                    Try
                            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                                Dim txtSQL As String
                                Dim cmmSQL As SqlCommand
                                Dim rdrSQL As SqlDataReader
                                Dim Entr As EntradaDic
                                connection.Open()

                                txtSQL = "Select Catala,Basc,PAV,Id "
                                txtSQL &= "From Basc INNER Join DiccResultats ON Basc.Id = DiccResultats.IdEntrada  "
                                txtSQL &= "Where (IdProva = " & IdProvaAnt & ") And (IsNull(Data,'')<>'')  And "
                                txtSQL &= "      (IsNull(Correcta,0)=0)   And (IsNull(Revisada,0)=0) "
                                cmmSQL = New SqlCommand(txtSQL, connection)
                                rdrSQL = cmmSQL.ExecuteReader
                                If rdrSQL.HasRows Then
                                    While rdrSQL.Read()
                                        'Crear Entrada
                                        Entr = New EntradaDic
                                        Entr.Catala = rdrSQL.GetString(0)
                                        Entr.Basc = rdrSQL.GetString(1)
                                        Entr.PAV = rdrSQL.GetString(2)
                                        Entr.TipusProva = "Revisio"
                                        Entr.IdDicc = rdrSQL.GetValue(3)
                                        ARevisar.Add(Entr)
                                        'Crear DiccResultat
                                        CreaResultat(IdProva, rdrSQL.GetValue(3))
                                        'Actualitzar DiccResultat
                                        RevisaResultat(IdProvaAnt, rdrSQL.GetValue(3))

                                    End While
                                    rdrSQL.Close()
                                    'Actualitzat DiccProves
                                End If
                            End Using
                        Catch ex As Exception
                            MsgBox("Error al llegir les fetes" & vbNewLine &
                           ex.Message)
                        End Try



                    End If
                    NumCtrl += 1
            Loop
        End If
        If ARevisar.Count = 0 Then
            'Seguir examen
            Do While (Not (tabBasc.Controls("chkRev" & NumCtrl) Is Nothing)) AndAlso Mid(tabBasc.Controls("chkRev" & NumCtrl).Text, 1, 3) = "Seg"
                If CType(tabBasc.Controls("chkRev" & NumCtrl), CheckBox).Checked Then
                    IdProva = Val(tabBasc.Controls("chkRev" & NumCtrl).Text.Split(":")(1))
                    Try
                        Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                            Dim txtSQL As String
                            Dim cmmSQL As SqlCommand
                            Dim rdrSQL As SqlDataReader
                            Dim Entr As EntradaDic
                            connection.Open()

                            txtSQL = "Select Basc.Catala, Basc.Basc, Basc.PAV, Basc.Id, DiccResultats.IdEntrada "
                            txtSQL &= "From Basc INNER Join DiccResultats ON Basc.Id = DiccResultats.IdEntrada "
                            txtSQL &= "Where (DiccResultats.IdProva = " & IdProva & ") And (IsNull(DiccResultats.Data,'')='') "
                            cmmSQL = New SqlCommand(txtSQL, connection)
                            rdrSQL = cmmSQL.ExecuteReader
                            If rdrSQL.HasRows Then
                                While rdrSQL.Read()
                                    Entr = New EntradaDic
                                    Entr.Catala = rdrSQL.GetString(0)
                                    Entr.Basc = rdrSQL.GetString(1)
                                    Entr.PAV = rdrSQL.GetString(2)
                                    Entr.TipusProva = "ExamenCB"
                                    Entr.IdDicc = rdrSQL.GetValue(3)
                                    ARevisar.Add(Entr)
                                End While
                                rdrSQL.Close()
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox("Error al llegir les fetes" & vbNewLine &
                               ex.Message)
                    End Try
                    Exit Do 'Només es pot seguir una prova
                End If
                NumCtrl += 1
            Loop
        End If
        MaxProves = AMemoritzar.Count + ARevisar.Count
        lblExamTotal.Text = MaxProves
        Comptador = 0
        If AMemoritzar.Count > 0 Then
            lblIdProva.Text = "Mem"
        ElseIf IdProva = 0 Then
            lblIdProva.Text = "Repàs"
        Else
            lblIdProva.Text = IdProva
        End If

        FesTasca()
    End Sub

    Private Function CreaProva(Origen As String, Filtre As String) As Integer
        Dim Rslt As Integer

        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand


                connection.Open()
                txtSQL = "Select Count(Id) From DiccProves"
                cmmSQL = New SqlCommand(txtSQL, connection)
                Rslt = cmmSQL.ExecuteScalar()
                If Rslt = 0 Then
                    Rslt = 1
                Else
                    txtSQL = "Select MAX(Id) From DiccProves"
                    cmmSQL = New SqlCommand(txtSQL, connection)
                    Rslt = cmmSQL.ExecuteScalar() + 1
                End If
                Filtre = Filtre.Replace("'", "''")
                txtSQL = "INSERT INTO DiccProves  (Id, Origen, Filtre, Inici) VALUES "
                txtSQL &= "(" & Rslt & ",'" & Origen & "', '" & Filtre & "','" & DataStd(Now()) & "')"
                cmmSQL = New SqlCommand(txtSQL, connection)
                cmmSQL.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("Error al crear prova" & vbNewLine &
                           ex.Message)
            Return 0
        End Try

        Return Rslt

    End Function

    Private Sub ActFiltProvaREV(IdProva As Integer, IdProvaAnt As Integer)

        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand


                connection.Open()
                txtSQL = "Update DiccProves set Filtre = Filtre + '" & IdProvaAnt & "' where Id = " & IdProva
                cmmSQL = New SqlCommand(txtSQL, connection)
                cmmSQL.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("Error al actualitzar prova anterior" & vbNewLine &
                           ex.Message)
        End Try

    End Sub


    Private Sub FiProva()
        If IdProva > 0 Then
            'Elimino les respostes pendents
            Try
                Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                    Dim txtSQL As String
                    Dim cmmSQL As SqlCommand

                    connection.Open()
                    txtSQL = "DELETE FROM DiccResultats  "
                    txtSQL &= " WHERE IdProva = " & IdProva & " AND "
                    txtSQL &= " IsNull(Data,'')=''"

                    cmmSQL = New SqlCommand(txtSQL, connection)
                    cmmSQL.ExecuteNonQuery()

                End Using
            Catch ex As Exception
                MsgBox("Error al eliminat preguntes " & vbNewLine &
                           ex.Message)
            End Try

            'Poso data fina a la prova
            Try

                Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                    Dim txtSQL As String
                    Dim cmmSQL As SqlCommand
                    connection.Open()
                    txtSQL = "UPDATE DiccProves SET "
                    txtSQL &= " Final = '" & DataStd(Now()) & "' "
                    txtSQL &= " WHERE Id = " & IdProva & " "

                    cmmSQL = New SqlCommand(txtSQL, connection)
                    cmmSQL.ExecuteNonQuery()

                End Using
            Catch ex As Exception
                MsgBox("Error al gravar el final de la prova" & vbNewLine &
                   ex.Message)
            End Try

            'Actualitzo "repassats" de la prova
            RepassaRevisats(IdProva)
            'Poso Prova a 0
            IdProva = 0
        End If
    End Sub

    Private Sub CreaResultat(IdProva As Integer, IdEntrada As Integer)

        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand


                connection.Open()
                txtSQL = "INSERT INTO DiccResultats  (IdProva,IdEntrada) VALUES "
                txtSQL &= "(" & IdProva & "," & IdEntrada & ")"
                cmmSQL = New SqlCommand(txtSQL, connection)
                cmmSQL.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("Error al crear resultat" & vbNewLine &
                           ex.Message)
        End Try


    End Sub

    Private Sub RevisaResultat(IdProva As Integer, IdEntrada As Integer)

        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand


                connection.Open()
                txtSQL = "UPDATE DiccResultats  SET "
                txtSQL &= "Revisada = -1 "
                txtSQL &= " Where IdProva = " & IdProva & "  AND IdEntrada = " & IdEntrada
                cmmSQL = New SqlCommand(txtSQL, connection)
                cmmSQL.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("Error al actualitzar revisió resultat" & vbNewLine &
                           ex.Message)
        End Try


    End Sub

    Private Sub cmdExamen_Click(sender As Object, e As EventArgs) Handles cmdExamen.Click
        Dim NumCtrl As Integer = 1
        Dim iReg As Integer = 0

        Dim Filtre As String



        If Not Interrupcio() Then
            Exit Sub
        End If

        IniciUltimaProva = Now()

        MostraResultatsExam()

        'Creo el registre de proves


        Filtre = " IsDate(Apres) =1 "
        Filtre &= " AND Apres >= '" & dtpExamDesde.Value.ToString("yyyy-MM-dd") & "' "
        Filtre &= " AND Apres <= '" & dtpExamFins.Value.ToString("yyyy-MM-dd") & "' "
        If Len(txtExamCodis.Text.Trim) > 0 Then
            Filtre &= " AND Thesaurus LIKE '" & txtExamCodis.Text.Trim.Replace("*", "%").Replace("?", "_") & "' "
        End If
        If Len(txtExamenNumPar.Text.Trim) > 0 Then
            Filtre &= "::" & txtExamenNumPar.Text
        End If

        IdProva = CreaProva("EXM", Filtre)
        If IdProva = 0 Then Exit Sub


        Try
            ARevisar = Nothing
            ARevisar = New Collection
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand
                Dim rdrSQL As SqlDataReader
                Dim Entr As EntradaDic
                'Crea el registre a Proves

                connection.Open()
                txtSQL = "SELECT "
                If Len(txtExamenNumPar.Text.Trim) > 0 Then
                    txtSQL &= " TOP " & txtExamenNumPar.Text & "  "
                End If
                txtSQL &= " ISNULL(Catala,''), ISNULL(Basc,''), ISNULL(PAV,''),Id "
                txtSQL &= " FROM  Basc "
                txtSQL &= " WHERE  IsDate(Apres) =1 "
                txtSQL &= " AND Apres >= '" & dtpExamDesde.Value.ToString("yyyy-MM-dd") & "' "
                txtSQL &= " AND Apres <= '" & dtpExamFins.Value.ToString("yyyy-MM-dd") & "' "
                If Len(txtExamCodis.Text.Trim) > 0 Then
                    txtSQL &= " AND Thesaurus LIKE '" & txtExamCodis.Text.Trim.Replace("*", "%").Replace("?", "_") & "' "
                End If
                If Len(txtExamenNumPar.Text.Trim) > 0 Then
                    txtSQL &= " ORDER BY Apres DESC "
                End If
                txtSQL &= " ; "
                cmmSQL = New SqlCommand(txtSQL, connection)
                rdrSQL = cmmSQL.ExecuteReader
                If rdrSQL.HasRows Then
                    While rdrSQL.Read()
                        Entr = New EntradaDic
                        Entr.Catala = rdrSQL.GetString(0)
                        Entr.Basc = rdrSQL.GetString(1)
                        Entr.PAV = rdrSQL.GetString(2)
                        Entr.TipusProva = "ExamenCB"
                        Entr.IdDicc = rdrSQL.GetValue(3)
                        ARevisar.Add(Entr)
                        'I crea el registre a Resultats
                        CreaResultat(IdProva, Entr.IdDicc)
                    End While
                    rdrSQL.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error al llegir les apreses" & vbNewLine &
                           ex.Message)
        End Try

        MaxProves = ARevisar.Count
        Comptador = 0
        lblExamTotal.Text = MaxProves
        lblIdProva.Text = IdProva

        txtFerBasc.Focus()

        FesTasca()

    End Sub


    Private Sub FesTasca()
        Dim NumRep As Integer
        Dim Interc As EntradaDic
        hInici = Now()

        Comptador += 1
        lblExamActual.Text = Comptador
        If Comptador <= MaxProves Then barProgres.Value = 100 * Comptador / MaxProves

        If AMemoritzar.Count > 0 Then
            cmdPAVOk.Visible = True
            txtFerCat.Text = CType(AMemoritzar(1), EntradaDic).Catala
            txtFerBasc.Text = CType(AMemoritzar(1), EntradaDic).Basc
            txtFerBasc.Enabled = False
            txtFerPAV.Text = CType(AMemoritzar(1), EntradaDic).PAV
            Exit Sub
        Else
            cmdPAVOk.Visible = False
        End If

        If ARevisar.Count > 0 Then
            ' Aleatori
            NumRep = Rnd.Next(1, ARevisar.Count + 1)
            Interc = ARevisar(NumRep)
            ARevisar.Remove(NumRep)
            ARevisar.Add(Interc,, 1)
            '
            cmdRepPista.Visible = True
            cmdRepAbandona.Visible = True
            txtFerCat.Text = CType(ARevisar(1), EntradaDic).Catala
            txtFerPAV.Text = ""
            txtFerBasc.Text = ""
            txtFerBasc.Enabled = True
            Exit Sub
        End If
        txtFerCat.Text = ""
        txtFerPAV.Text = ""
        txtFerBasc.Text = ""
        cmdMirarPendent.Visible = True
        cmdFerPendent.Visible = True
        cmdPAVOk.Visible = False
        cmdRepPista.Visible = False
        cmdRepAbandona.Visible = False
        lblContador.Text = ""
        lblMax.Text = ""
        barProgres.Value = 0
        FiProva()
        MirarPendent()


    End Sub

    Private Sub cmdPAVOk_Click(sender As Object, e As EventArgs) Handles cmdPAVOk.Click

        Try

            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand
                connection.Open()
                txtSQL = "UPDATE Basc SET "
                txtSQL &= " Apres = '" & DataStd(Now()) & "', "
                txtSQL &= " PAV = '" & txtFerPAV.Text.Replace("'", "''") & "' "
                txtSQL &= " WHERE Catala = '" & txtFerCat.Text & "' "

                cmmSQL = New SqlCommand(txtSQL, connection)
                cmmSQL.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            MsgBox("Error al gravar el PAV" & vbNewLine &
                   ex.Message)
        End Try
        AMemoritzar.Remove(1)
        FesTasca()
    End Sub

    Private Sub Reaprendre(IdEntrada As Integer, PAV As String)

        Try

            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand
                connection.Open()
                txtSQL = "UPDATE Basc SET "
                txtSQL &= " Apres = '" & DataStd(Now()) & "', "
                txtSQL &= " PAV = '" & PAV.Replace("'", "''") & "', "
                txtSQL &= " Repas1h = Null, "
                txtSQL &= " Repas1d = Null, "
                txtSQL &= " Repas1s = Null, "
                txtSQL &= " Repas1m = Null, "
                txtSQL &= " Repas6m = Null  "
                txtSQL &= " WHERE Id = " & IdEntrada

                cmmSQL = New SqlCommand(txtSQL, connection)
                cmmSQL.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            MsgBox("Error al gravar el PAV per reaprendre" & vbNewLine &
                   ex.Message)
        End Try
    End Sub


    Private Sub txtFerBasc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFerBasc.KeyDown
        Dim Rslt As String = ""
        Dim AlgunaCorrecta As Boolean
        Dim FaltaAlguna As Boolean

        If e.KeyCode = Keys.Enter And txtFerBasc.Text <> "" Then
            'Actualitzar Basc
            Dim Correcte As Boolean

            With CType(ARevisar(1), EntradaDic)
                If EsCorrecte(txtFerBasc.Text, .Basc, AlgunaCorrecta, FaltaAlguna) Then
                    ExamBe += 1
                    Correcte = True
                Else
                    Dim Dlg As New frmAvaluacio

                    Dlg.txtPregunta.Text = .Catala
                    Dlg.txtRespFeta.Text = txtFerBasc.Text
                    Dlg.txtRespBona.Text = .Basc
                    Dlg.chkAlgCor.Checked = AlgunaCorrecta
                    Dlg.chkFalten.Checked = FaltaAlguna
                    Dlg.txtPAV.Text = .PAV
                    Dlg.txtPropTipus
                    Dlg.txtPropData
                    Dlg.ShowDialog()

                    If Dlg.rdbBona.Checked Then
                        Correcte = True
                        ExamBe += 1
                    Else
                        If Dlg.rdbNPI.Checked Then Rslt &= ",NPI"
                        If Dlg.rdbGreu.Checked Then Rslt &= ",Greu"
                        If Dlg.rdbLleu.Checked Then Rslt &= ",Lleu"
                        If Dlg.rdbFonetica.Checked Then Rslt &= ",Fonet"
                        If Dlg.chkAlgCor.Checked Then Rslt &= ",PartOk"
                        If Dlg.chkFalten.Checked Then Rslt &= ",Falten"
                        If Len(Rslt) > 1 Then Rslt = Mid(Rslt, 2)
                        If Rslt.ToString.Contains("NPI") Or Rslt.ToString.Contains("Greu") Or Rslt = "" Then
                            ExamMal += 1
                            Correcte = False
                        Else
                            ExamPse += 1
                            Correcte = False
                        End If
                    End If
                    'Com es replanifica?
                End If

                If Correcte Then
                    'Replanificar bé segons moment
                End If
                If Dlg.chkReaprendre.Checked Then
                    Reaprendre(.IdDicc, Dlg.txtPAV.Text)
                End If


                MostraResultatsExam()
                If Correcte And Mid(.TipusProva, 1, 4) <> "Exam" And Mid(.TipusProva, 1, 4) <> "Revi" Then
                    Try

                        Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                            Dim txtSQL As String
                            Dim cmmSQL As SqlCommand
                            connection.Open()
                            txtSQL = "UPDATE Basc SET "
                            txtSQL &= .TipusProva & " = '" & DataStd(Now()) & "' "
                            txtSQL &= " WHERE Id = " & .IdDicc & " "

                            cmmSQL = New SqlCommand(txtSQL, connection)
                            cmmSQL.ExecuteNonQuery()

                        End Using
                    Catch ex As Exception
                        MsgBox("Error al actualitzar paraula" & vbNewLine &
                               ex.Message)
                    End Try
                End If
                'Crear Resultat Repas
                Try

                    Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                        Dim txtSQL As String
                        Dim cmmSQL As SqlCommand
                        connection.Open()
                        txtSQL = "UPDATE DiccResultats SET "
                        txtSQL &= " Data = '" & DataStd(Now()) & "', "
                        txtSQL &= " Temps = " & CLng((Now().Ticks - hInici.Ticks) / 10000) & ", "  'En mili segons
                        txtSQL &= " Pregunta = '" & .Catala & "', "
                        txtSQL &= " Resposta = '" & txtFerBasc.Text & "', "
                        txtSQL &= " RespCorrecta = '" & .Basc & "', "
                        txtSQL &= " Correcta = " & IIf(Correcte, -1, 0) & ", "
                        txtSQL &= " Fallos = '" & Rslt & "' "
                        txtSQL &= " WHERE IdEntrada = " & .IdDicc & " "
                        txtSQL &= "    AND IdProva = " & IdProva & " "

                        cmmSQL = New SqlCommand(txtSQL, connection)
                        cmmSQL.ExecuteNonQuery()

                    End Using
                Catch ex As Exception
                    MsgBox("Error al actualitzar paraula" & vbNewLine &
                               ex.Message)
                End Try

            End With
            'Eliminar de llista i Cridar FerTasca
            ARevisar.Remove(1)
            FesTasca()
        End If
    End Sub

    Function EsCorrecte(Intent As String, Diccionari As String, ByRef AlgCorr As Boolean, ByRef Falten As Boolean) As Boolean
        Dim DicNorm As String
        Dim IntentNorm As String
        Dim Intents() As String
        AlgCorr = False
        Falten = False
        If Intent = Diccionari Then Return True
        DicNorm = Diccionari.Replace(" ", "")
        IntentNorm = Intent.Replace(" ", "")
        If IntentNorm = DicNorm Then Return True
        IntentNorm = IntentNorm.ToLower
        DicNorm = DicNorm.ToLower
        If IntentNorm = DicNorm Then Return True

        DicNorm = "," + DicNorm.Replace(",", ",,") + ","
        If InStr(IntentNorm, ",") > 0 Then
            Intents = IntentNorm.Split(",")
            For n = 0 To Intents.Count() - 1
                If InStr(DicNorm, "," + Intents(n) + ",") Then
                    DicNorm = DicNorm.Replace("," + Intents(n) + ",", "")
                    AlgCorr = True
                End If
            Next
            If DicNorm = "" Then Return True
        Else
            If InStr(DicNorm, ",,") > 0 Then
                Falten = True
                If InStr(DicNorm, "," + IntentNorm + ",") Then
                    AlgCorr = True
                End If
            End If
        End If
        Return False
    End Function


    Sub MostraResultatsExam()
        lblExamBe.Text = ExamBe
        lblExamPse.Text = ExamPse
        lblExamMal.Text = ExamMal
        lblExamResp.Text = ExamBe + ExamPse + ExamMal
        lblExamPend.Text = MaxProves - ExamBe - ExamPse - ExamMal


    End Sub

    Private Sub cmdRepAbandona_Click(sender As Object, e As EventArgs) Handles cmdRepAbandona.Click
        ARevisar.Clear()
        FesTasca()
    End Sub

    Private Sub RepassaRevisats(IdProva)
        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand
                Dim PendentsRev As Integer
                Dim Val As String
                connection.Open()
                txtSQL = "SELECT Count(IdEntrada) "
                txtSQL &= " FROM  DiccResultats "
                txtSQL &= " WHERE IdProva = " & IdProva & " AND "
                '                txtSQL &= "  Not(IsNull(Data,'')='') and (IsNull(Revisada,0)=0) And (IsNull(Correcta,0)=0);"
                txtSQL &= " (IsNull(Revisada,0)=0) And (IsNull(Correcta,0)=0);"
                cmmSQL = New SqlCommand(txtSQL, connection)
                PendentsRev = cmmSQL.ExecuteScalar
                If PendentsRev = 0 Then
                    Val = "-1"
                Else
                    Val = "0"
                End If
                Try
                    txtSQL = "UPDATE DiccProves SET Repassada = " & Val
                    txtSQL &= " WHERE Id =" & IdProva & ";"

                    cmmSQL = New SqlCommand(txtSQL, connection)
                    cmmSQL.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox("Error al actualitzar que està la prova repassada" & vbNewLine &
                           ex.Message)
                End Try

            End Using

        Catch ex As Exception
            MsgBox("Error al llegir resultats per actualitzar 'Repassada'" & vbNewLine &
                           ex.Message)
        End Try

    End Sub




#End Region


#Region "Thesaurus i manteniment del diccionari"


    Private Sub cmdDiccLegeix_Click(sender As Object, e As EventArgs) Handles cmdDiccLegeix.Click
        Dim Act As String = ""
        If tvwTesaurus.Nodes.Count > 0 Then
            Act = tvwTesaurus.SelectedNode.Name
        End If
        tvwTesaurus.Nodes.Clear()
        AddNivell("", tvwTesaurus.Nodes)
        If Len(Act) > 0 Then
            tvwTesaurus.SelectedNode = tvwTesaurus.Nodes.Find(Act, True)(0)
        End If
    End Sub

    Private Sub AddNivell(Codi As String, ByRef Nods As TreeNodeCollection)
        Dim Nd As TreeNode
        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand
                Dim rdrSQL As SqlDataReader
                Dim Ln As Integer = -1
                Dim Th As String
                connection.Open()
                txtSQL = "SELECT ISNULL(Thesaurus,''),ISNULL(Catala,'') "
                txtSQL &= " FROM  Basc "
                txtSQL &= " WHERE  Thesaurus LIKE '" & Codi & "%'   AND LEN(Thesaurus) > " & Len(Codi) & " "
                txtSQL &= " ORDER BY  Thesaurus ;"
                cmmSQL = New SqlCommand(txtSQL, connection)
                rdrSQL = cmmSQL.ExecuteReader
                If rdrSQL.HasRows Then
                    While rdrSQL.Read()
                        Th = rdrSQL.GetString(0)
                        If (Ln = -1 Or Ln = Len(Th)) Then
                            Ln = Len(Th)
                            Nd = Nods.Add(Th, Th & ":" & rdrSQL.GetString(1))
                            AddNivell(Th, Nd.Nodes)
                        End If
                    End While
                    rdrSQL.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error al llegir diccionari" & vbNewLine &
                           ex.Message)
        End Try


    End Sub

    Private Sub tvwTesaurus_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwTesaurus.AfterSelect
        lblPare.Text = e.Node.Text
        CodiActual = e.Node.Text.Split(":")(0)
        grdFills.DataSource.filter = "Thesaurus LIKE '" & CodiActual & "%' AND LEN(Thesaurus) = " & Len(CodiActual) + 1
        grdFills.DataSource.sort = "Thesaurus"
    End Sub


    Private Function CharSeg(a As String) As String
        If a = "9" Then
            Return "A"
        ElseIf a = "Z" Then
            MsgBox("Errada, massa fills al mateix nivell")
            Return "Z"
        Else
            Return Chr(Asc(a) + 1)
        End If
    End Function


    Private Sub grdFills_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles grdFills.DefaultValuesNeeded
        Dim Codi As String
        If grdFills.RowCount > 1 Then
            Codi = grdFills.Rows(grdFills.RowCount - 2).Cells(0).Value
            Codi = Mid(Codi, 1, Len(Codi) - 1) & CharSeg(Mid(Codi, Len(Codi), 1))
        Else
            Codi = CodiActual & "1"
        End If
        e.Row.Cells("colThesaurus").Value = Codi
    End Sub

    Private Sub grdFills_Validated(sender As Object, e As EventArgs) Handles grdFills.Validated
        TableAdapterManager.UpdateAll(GeniusDataSet)
    End Sub

    Private Sub cmdDiccCanviCodi_Click(sender As Object, e As EventArgs) Handles cmdDiccCanviCodi.Click
        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand

                connection.Open()
                txtSQL = "UPDATE Basc SET Thesaurus = "
                txtSQL &= " STUFF([Thesaurus],1," & Len(CodiActual) & ",'" & txtDiccNouCodi.Text & "') "
                txtSQL &= " WHERE [Thesaurus] like '" & CodiActual & "%';"

                cmmSQL = New SqlCommand(txtSQL, connection)
                cmmSQL.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            MsgBox("Error al intentar canviar els codis" & vbNewLine &
                           ex.Message)
        End Try
        BascTableAdapter.Fill(GeniusDataSet.Basc)
    End Sub

    Private Sub grdFills_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdFills.CellContentDoubleClick
        Dim Codi As String
        Codi = grdFills.Rows(e.RowIndex).Cells(0).Value
        tvwTesaurus.SelectedNode = tvwTesaurus.Nodes.Find(Codi, True)(0)
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Const Separador = "/--/"
        Dim NomFit As String
        NomFit = "C:\Users\Usuario\Desktop\Tmp\ExportGeniusBasc.txt"
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(NomFit, False)
        Try
            Using connection As New SqlConnection(My.Settings.GeniusConnectionString)
                Dim txtSQL As String
                Dim cmmSQL As SqlCommand
                Dim rdrSQL As SqlDataReader
                connection.Open()
                Dim Linia As String
                Dim Camp As String

                txtSQL = " SELECT Id,Thesaurus"
                txtSQL &= "       ,[Catala]"
                txtSQL &= "       ,[Basc]"
                txtSQL &= "       ,[PAV]"
                txtSQL &= "       ,[Comentaris]"
                txtSQL &= "       ,[Planificada]"
                txtSQL &= "       ,[Apres]"
                txtSQL &= "       ,[Repas1h]"
                txtSQL &= "       ,[Repas1d]"
                txtSQL &= "       ,[Repas1s]"
                txtSQL &= "       ,[Repas1m]"
                txtSQL &= "       ,[Repas6m]"
                txtSQL &= "       ,[Traduible]"
                txtSQL &= "   FROM [Basc]"

                cmmSQL = New SqlCommand(txtSQL, connection)
                rdrSQL = cmmSQL.ExecuteReader
                If rdrSQL.HasRows Then
                    While rdrSQL.Read()
                        Linia = rdrSQL.GetValue(0).ToString
                        For n = 1 To rdrSQL.FieldCount - 1
                            Camp = rdrSQL.GetValue(n).ToString
                            While (InStr(Camp, Chr(10)) > 0)
                                Camp = Camp.Replace(Chr(13) + Chr(10), ";;")
                            End While
                            Linia += Separador + Camp
                        Next
                        file.WriteLine(Linia)
                    End While
                    rdrSQL.Close()
                End If
            End Using
            file.Close()
        Catch ex As Exception
            MsgBox("Error al llegir les apreses" & vbNewLine &
                           ex.Message)
        End Try



    End Sub




#End Region

End Class
