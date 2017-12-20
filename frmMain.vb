Imports System.ComponentModel

Public Class frmMain
    Dim Comptador As Integer
    Dim hInici As DateTime
    Dim hFi As DateTime

    Dim Paraules() As String = {"Hola", "Adeu"}

    Private Sub cmdInici_Click(sender As Object, e As EventArgs) Handles cmdInici.Click
        Dim Num As Integer
        Dim rnd As New Random()
        Num = rnd.Next(1, 100)
        txtNum.Text = Num
        Timer1.Start()
        hInici = Now()
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub txtParaula_TextChanged(sender As Object, e As EventArgs) Handles txtParaula.TextChanged

    End Sub

    Private Sub txtParaula_Validating(sender As Object, e As CancelEventArgs) Handles txtParaula.Validating
        Dim Estona As Decimal
        Dim Estona10 As Decimal
        hFi = Now()
        Estona = DateDiff(DateInterval.Second, hInici, hFi)
        Estona10 = hFi.Ticks - hInici.Ticks
        Timer1.Stop()
    End Sub
End Class
