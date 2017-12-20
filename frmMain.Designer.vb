<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdInici = New System.Windows.Forms.Button()
        Me.txtParaula = New System.Windows.Forms.TextBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'cmdInici
        '
        Me.cmdInici.Location = New System.Drawing.Point(12, 12)
        Me.cmdInici.Name = "cmdInici"
        Me.cmdInici.Size = New System.Drawing.Size(83, 29)
        Me.cmdInici.TabIndex = 0
        Me.cmdInici.Text = "Empezar"
        Me.cmdInici.UseVisualStyleBackColor = True
        '
        'txtParaula
        '
        Me.txtParaula.Location = New System.Drawing.Point(173, 17)
        Me.txtParaula.Name = "txtParaula"
        Me.txtParaula.Size = New System.Drawing.Size(100, 20)
        Me.txtParaula.TabIndex = 1
        '
        'txtNum
        '
        Me.txtNum.Enabled = False
        Me.txtNum.Location = New System.Drawing.Point(128, 16)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(39, 20)
        Me.txtNum.TabIndex = 2
        '
        'Timer1
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 157)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.txtParaula)
        Me.Controls.Add(Me.cmdInici)
        Me.Name = "frmMain"
        Me.Text = "100 Imágenes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdInici As Button
    Friend WithEvents txtParaula As TextBox
    Friend WithEvents txtNum As TextBox
    Friend WithEvents Timer1 As Timer
End Class
