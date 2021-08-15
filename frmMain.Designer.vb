Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class clsCursGenius
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(clsCursGenius))
        Me.DiccProvesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GeniusDataSet = New Genius.GeniusDataSet()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BascBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BascTableAdapter = New Genius.GeniusDataSetTableAdapters.BascTableAdapter()
        Me.TableAdapterManager = New Genius.GeniusDataSetTableAdapters.TableAdapterManager()
        Me.tabDiccionari = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvwTesaurus = New System.Windows.Forms.TreeView()
        Me.grdFills = New System.Windows.Forms.DataGridView()
        Me.colThesaurus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuBarraDicc = New System.Windows.Forms.ToolStrip()
        Me.cmdDiccLegeix = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblPare = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtDiccNouCodi = New System.Windows.Forms.ToolStripTextBox()
        Me.cmdDiccCanviCodi = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tabBasc = New System.Windows.Forms.TabPage()
        Me.grpProvaActual = New System.Windows.Forms.GroupBox()
        Me.lblExamActual = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.lblExamTotal = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblExamPend = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblExamResp = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblIdProva = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblExamMal = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblExamPse = New System.Windows.Forms.Label()
        Me.lblExamBe = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmdRepAbandona = New System.Windows.Forms.Button()
        Me.cmdRepPista = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblContador = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblMax = New System.Windows.Forms.ToolStripStatusLabel()
        Me.barProgres = New System.Windows.Forms.ToolStripProgressBar()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.lblEstAApr = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblEstNoTra = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblEstNoPla = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblEstR6m = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.grpSeleccioExamen = New System.Windows.Forms.GroupBox()
        Me.txtExamCodis = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dtpExamFins = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpExamDesde = New System.Windows.Forms.DateTimePicker()
        Me.txtExamenNumPar = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmdExamen = New System.Windows.Forms.Button()
        Me.lblEstR1m = New System.Windows.Forms.Label()
        Me.lblEstR1s = New System.Windows.Forms.Label()
        Me.lblEstR1d = New System.Windows.Forms.Label()
        Me.lblEstR1h = New System.Windows.Forms.Label()
        Me.lblEstApre = New System.Windows.Forms.Label()
        Me.lblEstPrep = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdFerPendent = New System.Windows.Forms.Button()
        Me.cmdPAVOk = New System.Windows.Forms.Button()
        Me.lblPAV = New System.Windows.Forms.Label()
        Me.lblBasc = New System.Windows.Forms.Label()
        Me.lblCat = New System.Windows.Forms.Label()
        Me.txtFerPAV = New System.Windows.Forms.TextBox()
        Me.txtFerBasc = New System.Windows.Forms.TextBox()
        Me.txtFerCat = New System.Windows.Forms.TextBox()
        Me.chkRevPendents = New System.Windows.Forms.CheckBox()
        Me.cmdMirarPendent = New System.Windows.Forms.Button()
        Me.tabNumLlarg = New System.Windows.Forms.TabPage()
        Me.cmdAbandona = New System.Windows.Forms.Button()
        Me.txtNumLlargUltFet = New System.Windows.Forms.TextBox()
        Me.txtNumARecordar = New System.Windows.Forms.TextBox()
        Me.txtNumDigits = New System.Windows.Forms.TextBox()
        Me.txtCronoRec = New System.Windows.Forms.TextBox()
        Me.txtCronoMem = New System.Windows.Forms.TextBox()
        Me.txtNumRecordat = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdCreaNum = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdEsborra = New System.Windows.Forms.Button()
        Me.tabFitxes = New System.Windows.Forms.TabPage()
        Me.txtP10 = New System.Windows.Forms.TextBox()
        Me.txtP9 = New System.Windows.Forms.TextBox()
        Me.txtP8 = New System.Windows.Forms.TextBox()
        Me.txtP7 = New System.Windows.Forms.TextBox()
        Me.txtP6 = New System.Windows.Forms.TextBox()
        Me.txtP5 = New System.Windows.Forms.TextBox()
        Me.txtP4 = New System.Windows.Forms.TextBox()
        Me.txtP3 = New System.Windows.Forms.TextBox()
        Me.txtP2 = New System.Windows.Forms.TextBox()
        Me.txtP1 = New System.Windows.Forms.TextBox()
        Me.txtT10 = New System.Windows.Forms.TextBox()
        Me.txtParaula = New System.Windows.Forms.TextBox()
        Me.txtT9 = New System.Windows.Forms.TextBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.txtT8 = New System.Windows.Forms.TextBox()
        Me.txtCrono = New System.Windows.Forms.TextBox()
        Me.txtT7 = New System.Windows.Forms.TextBox()
        Me.txtT6 = New System.Windows.Forms.TextBox()
        Me.txtTempsMig = New System.Windows.Forms.TextBox()
        Me.txtComptador = New System.Windows.Forms.TextBox()
        Me.txtT5 = New System.Windows.Forms.TextBox()
        Me.txtT4 = New System.Windows.Forms.TextBox()
        Me.txtT3 = New System.Windows.Forms.TextBox()
        Me.txtT2 = New System.Windows.Forms.TextBox()
        Me.txtNumErrades = New System.Windows.Forms.TextBox()
        Me.txtT1 = New System.Windows.Forms.TextBox()
        Me.cmdInici = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.DiccProvesTableAdapter = New Genius.GeniusDataSetTableAdapters.DiccProvesTableAdapter()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.DiccProvesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GeniusDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BascBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDiccionari.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdFills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuBarraDicc.SuspendLayout()
        Me.tabBasc.SuspendLayout()
        Me.grpProvaActual.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.grpSeleccioExamen.SuspendLayout()
        Me.tabNumLlarg.SuspendLayout()
        Me.tabFitxes.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DiccProvesBindingSource
        '
        Me.DiccProvesBindingSource.DataMember = "DiccProves"
        Me.DiccProvesBindingSource.DataSource = Me.GeniusDataSet
        '
        'GeniusDataSet
        '
        Me.GeniusDataSet.DataSetName = "GeniusDataSet"
        Me.GeniusDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Timer1
        '
        '
        'BascBindingSource
        '
        Me.BascBindingSource.DataMember = "Basc"
        Me.BascBindingSource.DataSource = Me.GeniusDataSet
        '
        'BascTableAdapter
        '
        Me.BascTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Basc_ResultatsTableAdapter = Nothing
        Me.TableAdapterManager.BascTableAdapter = Me.BascTableAdapter
        Me.TableAdapterManager.DiccProvesTableAdapter = Nothing
        Me.TableAdapterManager.DiccResultatsTableAdapter = Nothing
        Me.TableAdapterManager.Fitxes_ProvesTableAdapter = Nothing
        Me.TableAdapterManager.Fitxes_ResultatsTableAdapter = Nothing
        Me.TableAdapterManager.FitxesCatTableAdapter = Nothing
        Me.TableAdapterManager.FitxesTableAdapter = Nothing
        Me.TableAdapterManager.NumLlarg_ProvesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Genius.GeniusDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'tabDiccionari
        '
        Me.tabDiccionari.Controls.Add(Me.SplitContainer1)
        Me.tabDiccionari.Location = New System.Drawing.Point(4, 22)
        Me.tabDiccionari.Name = "tabDiccionari"
        Me.tabDiccionari.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDiccionari.Size = New System.Drawing.Size(861, 447)
        Me.tabDiccionari.TabIndex = 4
        Me.tabDiccionari.Text = "Diccionari"
        Me.tabDiccionari.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvwTesaurus)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdFills)
        Me.SplitContainer1.Panel2.Controls.Add(Me.mnuBarraDicc)
        Me.SplitContainer1.Size = New System.Drawing.Size(855, 441)
        Me.SplitContainer1.SplitterDistance = 285
        Me.SplitContainer1.TabIndex = 0
        '
        'tvwTesaurus
        '
        Me.tvwTesaurus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwTesaurus.Location = New System.Drawing.Point(0, 0)
        Me.tvwTesaurus.Name = "tvwTesaurus"
        Me.tvwTesaurus.Size = New System.Drawing.Size(285, 441)
        Me.tvwTesaurus.TabIndex = 0
        '
        'grdFills
        '
        Me.grdFills.AutoGenerateColumns = False
        Me.grdFills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFills.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colThesaurus, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11})
        Me.grdFills.DataSource = Me.BascBindingSource
        Me.grdFills.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFills.Location = New System.Drawing.Point(0, 25)
        Me.grdFills.Name = "grdFills"
        Me.grdFills.Size = New System.Drawing.Size(566, 416)
        Me.grdFills.TabIndex = 1
        '
        'colThesaurus
        '
        Me.colThesaurus.DataPropertyName = "Thesaurus"
        Me.colThesaurus.HeaderText = "Thesaurus"
        Me.colThesaurus.Name = "colThesaurus"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Catala"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Catala"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Basc"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Basc"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PAV"
        Me.DataGridViewTextBoxColumn4.HeaderText = "PAV"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Comentaris"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Comentaris"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Planificada"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Planificada"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Apres"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Apres"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Repas1h"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Repas1h"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Repas1d"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Repas1d"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Repas1s"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Repas1s"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Repas1m"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Repas1m"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'mnuBarraDicc
        '
        Me.mnuBarraDicc.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdDiccLegeix, Me.ToolStripSeparator1, Me.lblPare, Me.ToolStripSeparator2, Me.txtDiccNouCodi, Me.cmdDiccCanviCodi, Me.ToolStripSeparator3, Me.ToolStripButton1})
        Me.mnuBarraDicc.Location = New System.Drawing.Point(0, 0)
        Me.mnuBarraDicc.Name = "mnuBarraDicc"
        Me.mnuBarraDicc.Size = New System.Drawing.Size(566, 25)
        Me.mnuBarraDicc.TabIndex = 0
        Me.mnuBarraDicc.Text = "ToolStrip1"
        '
        'cmdDiccLegeix
        '
        Me.cmdDiccLegeix.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdDiccLegeix.Image = CType(resources.GetObject("cmdDiccLegeix.Image"), System.Drawing.Image)
        Me.cmdDiccLegeix.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDiccLegeix.Name = "cmdDiccLegeix"
        Me.cmdDiccLegeix.Size = New System.Drawing.Size(47, 22)
        Me.cmdDiccLegeix.Text = "Llegeix"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblPare
        '
        Me.lblPare.Name = "lblPare"
        Me.lblPare.Size = New System.Drawing.Size(10, 22)
        Me.lblPare.Text = "."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'txtDiccNouCodi
        '
        Me.txtDiccNouCodi.Name = "txtDiccNouCodi"
        Me.txtDiccNouCodi.Size = New System.Drawing.Size(100, 25)
        '
        'cmdDiccCanviCodi
        '
        Me.cmdDiccCanviCodi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdDiccCanviCodi.Image = CType(resources.GetObject("cmdDiccCanviCodi.Image"), System.Drawing.Image)
        Me.cmdDiccCanviCodi.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDiccCanviCodi.Name = "cmdDiccCanviCodi"
        Me.cmdDiccCanviCodi.Size = New System.Drawing.Size(54, 22)
        Me.cmdDiccCanviCodi.Text = "<-Canvi"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripButton1.Text = "Verifica"
        '
        'tabBasc
        '
        Me.tabBasc.Controls.Add(Me.grpProvaActual)
        Me.tabBasc.Controls.Add(Me.StatusStrip1)
        Me.tabBasc.Controls.Add(Me.cmdExport)
        Me.tabBasc.Controls.Add(Me.lblEstAApr)
        Me.tabBasc.Controls.Add(Me.Label23)
        Me.tabBasc.Controls.Add(Me.lblEstNoTra)
        Me.tabBasc.Controls.Add(Me.Label21)
        Me.tabBasc.Controls.Add(Me.lblEstNoPla)
        Me.tabBasc.Controls.Add(Me.Label19)
        Me.tabBasc.Controls.Add(Me.lblEstR6m)
        Me.tabBasc.Controls.Add(Me.Label18)
        Me.tabBasc.Controls.Add(Me.Label16)
        Me.tabBasc.Controls.Add(Me.grpSeleccioExamen)
        Me.tabBasc.Controls.Add(Me.lblEstR1m)
        Me.tabBasc.Controls.Add(Me.lblEstR1s)
        Me.tabBasc.Controls.Add(Me.lblEstR1d)
        Me.tabBasc.Controls.Add(Me.lblEstR1h)
        Me.tabBasc.Controls.Add(Me.lblEstApre)
        Me.tabBasc.Controls.Add(Me.lblEstPrep)
        Me.tabBasc.Controls.Add(Me.Label14)
        Me.tabBasc.Controls.Add(Me.Label13)
        Me.tabBasc.Controls.Add(Me.Label12)
        Me.tabBasc.Controls.Add(Me.Label11)
        Me.tabBasc.Controls.Add(Me.Label10)
        Me.tabBasc.Controls.Add(Me.Label9)
        Me.tabBasc.Controls.Add(Me.cmdFerPendent)
        Me.tabBasc.Controls.Add(Me.cmdPAVOk)
        Me.tabBasc.Controls.Add(Me.lblPAV)
        Me.tabBasc.Controls.Add(Me.lblBasc)
        Me.tabBasc.Controls.Add(Me.lblCat)
        Me.tabBasc.Controls.Add(Me.txtFerPAV)
        Me.tabBasc.Controls.Add(Me.txtFerBasc)
        Me.tabBasc.Controls.Add(Me.txtFerCat)
        Me.tabBasc.Controls.Add(Me.chkRevPendents)
        Me.tabBasc.Controls.Add(Me.cmdMirarPendent)
        Me.tabBasc.Location = New System.Drawing.Point(4, 22)
        Me.tabBasc.Name = "tabBasc"
        Me.tabBasc.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBasc.Size = New System.Drawing.Size(861, 447)
        Me.tabBasc.TabIndex = 3
        Me.tabBasc.Text = "Basc"
        Me.tabBasc.UseVisualStyleBackColor = True
        '
        'grpProvaActual
        '
        Me.grpProvaActual.Controls.Add(Me.lblExamActual)
        Me.grpProvaActual.Controls.Add(Me.Label36)
        Me.grpProvaActual.Controls.Add(Me.lblExamTotal)
        Me.grpProvaActual.Controls.Add(Me.Label34)
        Me.grpProvaActual.Controls.Add(Me.lblExamPend)
        Me.grpProvaActual.Controls.Add(Me.Label32)
        Me.grpProvaActual.Controls.Add(Me.lblExamResp)
        Me.grpProvaActual.Controls.Add(Me.Label30)
        Me.grpProvaActual.Controls.Add(Me.lblIdProva)
        Me.grpProvaActual.Controls.Add(Me.Label26)
        Me.grpProvaActual.Controls.Add(Me.lblExamMal)
        Me.grpProvaActual.Controls.Add(Me.Label25)
        Me.grpProvaActual.Controls.Add(Me.lblExamPse)
        Me.grpProvaActual.Controls.Add(Me.lblExamBe)
        Me.grpProvaActual.Controls.Add(Me.Label28)
        Me.grpProvaActual.Controls.Add(Me.Label29)
        Me.grpProvaActual.Controls.Add(Me.cmdRepAbandona)
        Me.grpProvaActual.Controls.Add(Me.cmdRepPista)
        Me.grpProvaActual.Location = New System.Drawing.Point(280, 323)
        Me.grpProvaActual.Name = "grpProvaActual"
        Me.grpProvaActual.Size = New System.Drawing.Size(557, 82)
        Me.grpProvaActual.TabIndex = 46
        Me.grpProvaActual.TabStop = False
        Me.grpProvaActual.Text = "Prova actual"
        '
        'lblExamActual
        '
        Me.lblExamActual.BackColor = System.Drawing.SystemColors.Control
        Me.lblExamActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExamActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExamActual.Location = New System.Drawing.Point(200, 20)
        Me.lblExamActual.Name = "lblExamActual"
        Me.lblExamActual.Size = New System.Drawing.Size(44, 17)
        Me.lblExamActual.TabIndex = 55
        Me.lblExamActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(207, 7)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(37, 13)
        Me.Label36.TabIndex = 54
        Me.Label36.Text = "Actual"
        '
        'lblExamTotal
        '
        Me.lblExamTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblExamTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExamTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExamTotal.Location = New System.Drawing.Point(250, 20)
        Me.lblExamTotal.Name = "lblExamTotal"
        Me.lblExamTotal.Size = New System.Drawing.Size(44, 17)
        Me.lblExamTotal.TabIndex = 53
        Me.lblExamTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(262, 7)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(31, 13)
        Me.Label34.TabIndex = 52
        Me.Label34.Text = "Total"
        '
        'lblExamPend
        '
        Me.lblExamPend.BackColor = System.Drawing.SystemColors.Control
        Me.lblExamPend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExamPend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExamPend.Location = New System.Drawing.Point(300, 20)
        Me.lblExamPend.Name = "lblExamPend"
        Me.lblExamPend.Size = New System.Drawing.Size(44, 17)
        Me.lblExamPend.TabIndex = 51
        Me.lblExamPend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(312, 7)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(32, 13)
        Me.Label32.TabIndex = 50
        Me.Label32.Text = "Pend"
        '
        'lblExamResp
        '
        Me.lblExamResp.BackColor = System.Drawing.SystemColors.Control
        Me.lblExamResp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExamResp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExamResp.Location = New System.Drawing.Point(350, 20)
        Me.lblExamResp.Name = "lblExamResp"
        Me.lblExamResp.Size = New System.Drawing.Size(44, 17)
        Me.lblExamResp.TabIndex = 49
        Me.lblExamResp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(362, 7)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(32, 13)
        Me.Label30.TabIndex = 48
        Me.Label30.Text = "Resp"
        '
        'lblIdProva
        '
        Me.lblIdProva.BackColor = System.Drawing.SystemColors.Control
        Me.lblIdProva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIdProva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdProva.Location = New System.Drawing.Point(105, 20)
        Me.lblIdProva.Name = "lblIdProva"
        Me.lblIdProva.Size = New System.Drawing.Size(70, 17)
        Me.lblIdProva.TabIndex = 47
        Me.lblIdProva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(118, 7)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 13)
        Me.Label26.TabIndex = 46
        Me.Label26.Text = "Id Examen"
        '
        'lblExamMal
        '
        Me.lblExamMal.BackColor = System.Drawing.SystemColors.Control
        Me.lblExamMal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExamMal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExamMal.Location = New System.Drawing.Point(500, 20)
        Me.lblExamMal.Name = "lblExamMal"
        Me.lblExamMal.Size = New System.Drawing.Size(44, 17)
        Me.lblExamMal.TabIndex = 45
        Me.lblExamMal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(520, 7)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(24, 13)
        Me.Label25.TabIndex = 44
        Me.Label25.Text = "Mal"
        '
        'lblExamPse
        '
        Me.lblExamPse.BackColor = System.Drawing.SystemColors.Control
        Me.lblExamPse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExamPse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExamPse.Location = New System.Drawing.Point(449, 20)
        Me.lblExamPse.Name = "lblExamPse"
        Me.lblExamPse.Size = New System.Drawing.Size(44, 17)
        Me.lblExamPse.TabIndex = 43
        Me.lblExamPse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExamBe
        '
        Me.lblExamBe.BackColor = System.Drawing.SystemColors.Control
        Me.lblExamBe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExamBe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExamBe.Location = New System.Drawing.Point(399, 20)
        Me.lblExamBe.Name = "lblExamBe"
        Me.lblExamBe.Size = New System.Drawing.Size(44, 17)
        Me.lblExamBe.TabIndex = 42
        Me.lblExamBe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(472, 7)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(25, 13)
        Me.Label28.TabIndex = 41
        Me.Label28.Text = "Pse"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(425, 7)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(20, 13)
        Me.Label29.TabIndex = 40
        Me.Label29.Text = "Bé"
        '
        'cmdRepAbandona
        '
        Me.cmdRepAbandona.Location = New System.Drawing.Point(399, 47)
        Me.cmdRepAbandona.Name = "cmdRepAbandona"
        Me.cmdRepAbandona.Size = New System.Drawing.Size(70, 29)
        Me.cmdRepAbandona.TabIndex = 12
        Me.cmdRepAbandona.Text = "Finalitzar"
        Me.cmdRepAbandona.UseVisualStyleBackColor = True
        '
        'cmdRepPista
        '
        Me.cmdRepPista.Location = New System.Drawing.Point(335, 47)
        Me.cmdRepPista.Name = "cmdRepPista"
        Me.cmdRepPista.Size = New System.Drawing.Size(58, 29)
        Me.cmdRepPista.TabIndex = 11
        Me.cmdRepPista.Text = "Pista"
        Me.cmdRepPista.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblContador, Me.lblMax, Me.barProgres})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 422)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(855, 22)
        Me.StatusStrip1.TabIndex = 29
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblContador
        '
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(0, 17)
        '
        'lblMax
        '
        Me.lblMax.Name = "lblMax"
        Me.lblMax.Size = New System.Drawing.Size(0, 17)
        '
        'barProgres
        '
        Me.barProgres.Name = "barProgres"
        Me.barProgres.Size = New System.Drawing.Size(500, 16)
        Me.barProgres.Step = 1
        Me.barProgres.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(469, 16)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(116, 29)
        Me.cmdExport.TabIndex = 41
        Me.cmdExport.Text = "Exportar Dicc"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'lblEstAApr
        '
        Me.lblEstAApr.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstAApr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstAApr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstAApr.Location = New System.Drawing.Point(303, 75)
        Me.lblEstAApr.Name = "lblEstAApr"
        Me.lblEstAApr.Size = New System.Drawing.Size(44, 17)
        Me.lblEstAApr.TabIndex = 39
        Me.lblEstAApr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(287, 59)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 13)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = "A Aprendre"
        '
        'lblEstNoTra
        '
        Me.lblEstNoTra.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstNoTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstNoTra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstNoTra.Location = New System.Drawing.Point(353, 75)
        Me.lblEstNoTra.Name = "lblEstNoTra"
        Me.lblEstNoTra.Size = New System.Drawing.Size(44, 17)
        Me.lblEstNoTra.TabIndex = 37
        Me.lblEstNoTra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(353, 59)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 13)
        Me.Label21.TabIndex = 36
        Me.Label21.Text = "No Trad"
        '
        'lblEstNoPla
        '
        Me.lblEstNoPla.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstNoPla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstNoPla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstNoPla.Location = New System.Drawing.Point(403, 75)
        Me.lblEstNoPla.Name = "lblEstNoPla"
        Me.lblEstNoPla.Size = New System.Drawing.Size(44, 17)
        Me.lblEstNoPla.TabIndex = 35
        Me.lblEstNoPla.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(402, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 13)
        Me.Label19.TabIndex = 34
        Me.Label19.Text = "No Plan"
        '
        'lblEstR6m
        '
        Me.lblEstR6m.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstR6m.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstR6m.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstR6m.Location = New System.Drawing.Point(793, 75)
        Me.lblEstR6m.Name = "lblEstR6m"
        Me.lblEstR6m.Size = New System.Drawing.Size(44, 17)
        Me.lblEstR6m.TabIndex = 33
        Me.lblEstR6m.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(816, 62)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(21, 13)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "6m"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(653, 49)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Repassades"
        '
        'grpSeleccioExamen
        '
        Me.grpSeleccioExamen.Controls.Add(Me.txtExamCodis)
        Me.grpSeleccioExamen.Controls.Add(Me.Label22)
        Me.grpSeleccioExamen.Controls.Add(Me.dtpExamFins)
        Me.grpSeleccioExamen.Controls.Add(Me.Label20)
        Me.grpSeleccioExamen.Controls.Add(Me.Label17)
        Me.grpSeleccioExamen.Controls.Add(Me.dtpExamDesde)
        Me.grpSeleccioExamen.Controls.Add(Me.txtExamenNumPar)
        Me.grpSeleccioExamen.Controls.Add(Me.Label15)
        Me.grpSeleccioExamen.Controls.Add(Me.cmdExamen)
        Me.grpSeleccioExamen.Location = New System.Drawing.Point(276, 201)
        Me.grpSeleccioExamen.Name = "grpSeleccioExamen"
        Me.grpSeleccioExamen.Size = New System.Drawing.Size(561, 116)
        Me.grpSeleccioExamen.TabIndex = 30
        Me.grpSeleccioExamen.TabStop = False
        Me.grpSeleccioExamen.Text = "Selecció examen"
        '
        'txtExamCodis
        '
        Me.txtExamCodis.Location = New System.Drawing.Point(254, 64)
        Me.txtExamCodis.Name = "txtExamCodis"
        Me.txtExamCodis.Size = New System.Drawing.Size(72, 20)
        Me.txtExamCodis.TabIndex = 32
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(273, 48)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(33, 13)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "Codis"
        '
        'dtpExamFins
        '
        Me.dtpExamFins.Location = New System.Drawing.Point(332, 17)
        Me.dtpExamFins.Name = "dtpExamFins"
        Me.dtpExamFins.Size = New System.Drawing.Size(200, 20)
        Me.dtpExamFins.TabIndex = 30
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(297, 24)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 13)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Fins:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Preses desde:"
        '
        'dtpExamDesde
        '
        Me.dtpExamDesde.Location = New System.Drawing.Point(91, 17)
        Me.dtpExamDesde.Name = "dtpExamDesde"
        Me.dtpExamDesde.Size = New System.Drawing.Size(200, 20)
        Me.dtpExamDesde.TabIndex = 0
        '
        'txtExamenNumPar
        '
        Me.txtExamenNumPar.Location = New System.Drawing.Point(188, 64)
        Me.txtExamenNumPar.Name = "txtExamenNumPar"
        Me.txtExamenNumPar.Size = New System.Drawing.Size(52, 20)
        Me.txtExamenNumPar.TabIndex = 25
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(168, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Últ. X Paraules"
        '
        'cmdExamen
        '
        Me.cmdExamen.Location = New System.Drawing.Point(380, 64)
        Me.cmdExamen.Name = "cmdExamen"
        Me.cmdExamen.Size = New System.Drawing.Size(78, 26)
        Me.cmdExamen.TabIndex = 28
        Me.cmdExamen.Text = "Examen"
        Me.cmdExamen.UseVisualStyleBackColor = True
        '
        'lblEstR1m
        '
        Me.lblEstR1m.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstR1m.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstR1m.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstR1m.Location = New System.Drawing.Point(742, 75)
        Me.lblEstR1m.Name = "lblEstR1m"
        Me.lblEstR1m.Size = New System.Drawing.Size(44, 17)
        Me.lblEstR1m.TabIndex = 24
        Me.lblEstR1m.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstR1s
        '
        Me.lblEstR1s.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstR1s.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstR1s.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstR1s.Location = New System.Drawing.Point(692, 75)
        Me.lblEstR1s.Name = "lblEstR1s"
        Me.lblEstR1s.Size = New System.Drawing.Size(44, 17)
        Me.lblEstR1s.TabIndex = 23
        Me.lblEstR1s.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstR1d
        '
        Me.lblEstR1d.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstR1d.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstR1d.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstR1d.Location = New System.Drawing.Point(642, 75)
        Me.lblEstR1d.Name = "lblEstR1d"
        Me.lblEstR1d.Size = New System.Drawing.Size(44, 17)
        Me.lblEstR1d.TabIndex = 22
        Me.lblEstR1d.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstR1h
        '
        Me.lblEstR1h.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstR1h.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstR1h.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstR1h.Location = New System.Drawing.Point(592, 75)
        Me.lblEstR1h.Name = "lblEstR1h"
        Me.lblEstR1h.Size = New System.Drawing.Size(44, 17)
        Me.lblEstR1h.TabIndex = 21
        Me.lblEstR1h.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstApre
        '
        Me.lblEstApre.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstApre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstApre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstApre.Location = New System.Drawing.Point(524, 75)
        Me.lblEstApre.Name = "lblEstApre"
        Me.lblEstApre.Size = New System.Drawing.Size(44, 17)
        Me.lblEstApre.TabIndex = 20
        Me.lblEstApre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstPrep
        '
        Me.lblEstPrep.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstPrep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstPrep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstPrep.Location = New System.Drawing.Point(453, 75)
        Me.lblEstPrep.Name = "lblEstPrep"
        Me.lblEstPrep.Size = New System.Drawing.Size(44, 17)
        Me.lblEstPrep.TabIndex = 19
        Me.lblEstPrep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(765, 62)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "1m"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(718, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(18, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "1s"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(667, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "1d"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(617, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "1h"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(523, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Apreses"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(468, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Prep"
        '
        'cmdFerPendent
        '
        Me.cmdFerPendent.Location = New System.Drawing.Point(145, 16)
        Me.cmdFerPendent.Name = "cmdFerPendent"
        Me.cmdFerPendent.Size = New System.Drawing.Size(102, 29)
        Me.cmdFerPendent.TabIndex = 10
        Me.cmdFerPendent.Text = "Fer pendent"
        Me.cmdFerPendent.UseVisualStyleBackColor = True
        '
        'cmdPAVOk
        '
        Me.cmdPAVOk.Location = New System.Drawing.Point(303, 155)
        Me.cmdPAVOk.Name = "cmdPAVOk"
        Me.cmdPAVOk.Size = New System.Drawing.Size(102, 29)
        Me.cmdPAVOk.TabIndex = 9
        Me.cmdPAVOk.Text = "PAV Ok"
        Me.cmdPAVOk.UseVisualStyleBackColor = True
        '
        'lblPAV
        '
        Me.lblPAV.AutoSize = True
        Me.lblPAV.Location = New System.Drawing.Point(414, 163)
        Me.lblPAV.Name = "lblPAV"
        Me.lblPAV.Size = New System.Drawing.Size(28, 13)
        Me.lblPAV.TabIndex = 8
        Me.lblPAV.Text = "PAV"
        '
        'lblBasc
        '
        Me.lblBasc.AutoSize = True
        Me.lblBasc.Location = New System.Drawing.Point(442, 100)
        Me.lblBasc.Name = "lblBasc"
        Me.lblBasc.Size = New System.Drawing.Size(31, 13)
        Me.lblBasc.TabIndex = 7
        Me.lblBasc.Text = "Basc"
        '
        'lblCat
        '
        Me.lblCat.AutoSize = True
        Me.lblCat.Location = New System.Drawing.Point(287, 100)
        Me.lblCat.Name = "lblCat"
        Me.lblCat.Size = New System.Drawing.Size(37, 13)
        Me.lblCat.TabIndex = 6
        Me.lblCat.Text = "Català"
        '
        'txtFerPAV
        '
        Me.txtFerPAV.Location = New System.Drawing.Point(448, 151)
        Me.txtFerPAV.Multiline = True
        Me.txtFerPAV.Name = "txtFerPAV"
        Me.txtFerPAV.Size = New System.Drawing.Size(389, 44)
        Me.txtFerPAV.TabIndex = 5
        '
        'txtFerBasc
        '
        Me.txtFerBasc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFerBasc.Location = New System.Drawing.Point(448, 122)
        Me.txtFerBasc.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.txtFerBasc.Name = "txtFerBasc"
        Me.txtFerBasc.Size = New System.Drawing.Size(389, 23)
        Me.txtFerBasc.TabIndex = 4
        '
        'txtFerCat
        '
        Me.txtFerCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFerCat.Location = New System.Drawing.Point(276, 122)
        Me.txtFerCat.Name = "txtFerCat"
        Me.txtFerCat.Size = New System.Drawing.Size(166, 22)
        Me.txtFerCat.TabIndex = 3
        '
        'chkRevPendents
        '
        Me.chkRevPendents.AutoSize = True
        Me.chkRevPendents.Location = New System.Drawing.Point(37, 64)
        Me.chkRevPendents.Name = "chkRevPendents"
        Me.chkRevPendents.Size = New System.Drawing.Size(97, 17)
        Me.chkRevPendents.TabIndex = 2
        Me.chkRevPendents.Text = "Seleccionar tot"
        Me.chkRevPendents.UseVisualStyleBackColor = True
        '
        'cmdMirarPendent
        '
        Me.cmdMirarPendent.Location = New System.Drawing.Point(37, 16)
        Me.cmdMirarPendent.Name = "cmdMirarPendent"
        Me.cmdMirarPendent.Size = New System.Drawing.Size(102, 29)
        Me.cmdMirarPendent.TabIndex = 1
        Me.cmdMirarPendent.Text = "Mirar Pendent"
        Me.cmdMirarPendent.UseVisualStyleBackColor = True
        '
        'tabNumLlarg
        '
        Me.tabNumLlarg.Controls.Add(Me.cmdAbandona)
        Me.tabNumLlarg.Controls.Add(Me.txtNumLlargUltFet)
        Me.tabNumLlarg.Controls.Add(Me.txtNumARecordar)
        Me.tabNumLlarg.Controls.Add(Me.txtNumDigits)
        Me.tabNumLlarg.Controls.Add(Me.txtCronoRec)
        Me.tabNumLlarg.Controls.Add(Me.txtCronoMem)
        Me.tabNumLlarg.Controls.Add(Me.txtNumRecordat)
        Me.tabNumLlarg.Controls.Add(Me.Label8)
        Me.tabNumLlarg.Controls.Add(Me.Label7)
        Me.tabNumLlarg.Controls.Add(Me.cmdCreaNum)
        Me.tabNumLlarg.Controls.Add(Me.Label6)
        Me.tabNumLlarg.Controls.Add(Me.Label5)
        Me.tabNumLlarg.Controls.Add(Me.cmdEsborra)
        Me.tabNumLlarg.Location = New System.Drawing.Point(4, 22)
        Me.tabNumLlarg.Name = "tabNumLlarg"
        Me.tabNumLlarg.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNumLlarg.Size = New System.Drawing.Size(861, 447)
        Me.tabNumLlarg.TabIndex = 1
        Me.tabNumLlarg.Text = "Nº Llarg"
        Me.tabNumLlarg.UseVisualStyleBackColor = True
        '
        'cmdAbandona
        '
        Me.cmdAbandona.Location = New System.Drawing.Point(57, 248)
        Me.cmdAbandona.Name = "cmdAbandona"
        Me.cmdAbandona.Size = New System.Drawing.Size(105, 24)
        Me.cmdAbandona.TabIndex = 33
        Me.cmdAbandona.Text = "Abandona"
        Me.cmdAbandona.UseVisualStyleBackColor = True
        '
        'txtNumLlargUltFet
        '
        Me.txtNumLlargUltFet.Enabled = False
        Me.txtNumLlargUltFet.Location = New System.Drawing.Point(211, 38)
        Me.txtNumLlargUltFet.Name = "txtNumLlargUltFet"
        Me.txtNumLlargUltFet.Size = New System.Drawing.Size(123, 20)
        Me.txtNumLlargUltFet.TabIndex = 32
        '
        'txtNumARecordar
        '
        Me.txtNumARecordar.Location = New System.Drawing.Point(180, 152)
        Me.txtNumARecordar.Name = "txtNumARecordar"
        Me.txtNumARecordar.Size = New System.Drawing.Size(343, 20)
        Me.txtNumARecordar.TabIndex = 24
        '
        'txtNumDigits
        '
        Me.txtNumDigits.Location = New System.Drawing.Point(180, 113)
        Me.txtNumDigits.Name = "txtNumDigits"
        Me.txtNumDigits.Size = New System.Drawing.Size(58, 20)
        Me.txtNumDigits.TabIndex = 22
        '
        'txtCronoRec
        '
        Me.txtCronoRec.Enabled = False
        Me.txtCronoRec.Location = New System.Drawing.Point(426, 113)
        Me.txtCronoRec.Name = "txtCronoRec"
        Me.txtCronoRec.Size = New System.Drawing.Size(100, 20)
        Me.txtCronoRec.TabIndex = 28
        '
        'txtCronoMem
        '
        Me.txtCronoMem.Enabled = False
        Me.txtCronoMem.Location = New System.Drawing.Point(320, 113)
        Me.txtCronoMem.Name = "txtCronoMem"
        Me.txtCronoMem.Size = New System.Drawing.Size(100, 20)
        Me.txtCronoMem.TabIndex = 27
        '
        'txtNumRecordat
        '
        Me.txtNumRecordat.Location = New System.Drawing.Point(180, 199)
        Me.txtNumRecordat.Name = "txtNumRecordat"
        Me.txtNumRecordat.Size = New System.Drawing.Size(343, 20)
        Me.txtNumRecordat.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(157, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Últim fet:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(466, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "t. Recordar"
        '
        'cmdCreaNum
        '
        Me.cmdCreaNum.Location = New System.Drawing.Point(57, 148)
        Me.cmdCreaNum.Name = "cmdCreaNum"
        Me.cmdCreaNum.Size = New System.Drawing.Size(105, 24)
        Me.cmdCreaNum.TabIndex = 21
        Me.cmdCreaNum.Text = "Crea el Numero"
        Me.cmdCreaNum.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(353, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "t. Memoritzar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(157, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Longitud [digits]"
        '
        'cmdEsborra
        '
        Me.cmdEsborra.Location = New System.Drawing.Point(57, 196)
        Me.cmdEsborra.Name = "cmdEsborra"
        Me.cmdEsborra.Size = New System.Drawing.Size(105, 24)
        Me.cmdEsborra.TabIndex = 26
        Me.cmdEsborra.Text = "Esborra"
        Me.cmdEsborra.UseVisualStyleBackColor = True
        '
        'tabFitxes
        '
        Me.tabFitxes.Controls.Add(Me.ReportViewer1)
        Me.tabFitxes.Controls.Add(Me.txtP10)
        Me.tabFitxes.Controls.Add(Me.txtP9)
        Me.tabFitxes.Controls.Add(Me.txtP8)
        Me.tabFitxes.Controls.Add(Me.txtP7)
        Me.tabFitxes.Controls.Add(Me.txtP6)
        Me.tabFitxes.Controls.Add(Me.txtP5)
        Me.tabFitxes.Controls.Add(Me.txtP4)
        Me.tabFitxes.Controls.Add(Me.txtP3)
        Me.tabFitxes.Controls.Add(Me.txtP2)
        Me.tabFitxes.Controls.Add(Me.txtP1)
        Me.tabFitxes.Controls.Add(Me.txtT10)
        Me.tabFitxes.Controls.Add(Me.txtParaula)
        Me.tabFitxes.Controls.Add(Me.txtT9)
        Me.tabFitxes.Controls.Add(Me.txtNum)
        Me.tabFitxes.Controls.Add(Me.txtT8)
        Me.tabFitxes.Controls.Add(Me.txtCrono)
        Me.tabFitxes.Controls.Add(Me.txtT7)
        Me.tabFitxes.Controls.Add(Me.txtT6)
        Me.tabFitxes.Controls.Add(Me.txtTempsMig)
        Me.tabFitxes.Controls.Add(Me.txtComptador)
        Me.tabFitxes.Controls.Add(Me.txtT5)
        Me.tabFitxes.Controls.Add(Me.txtT4)
        Me.tabFitxes.Controls.Add(Me.txtT3)
        Me.tabFitxes.Controls.Add(Me.txtT2)
        Me.tabFitxes.Controls.Add(Me.txtNumErrades)
        Me.tabFitxes.Controls.Add(Me.txtT1)
        Me.tabFitxes.Controls.Add(Me.cmdInici)
        Me.tabFitxes.Controls.Add(Me.Label1)
        Me.tabFitxes.Controls.Add(Me.Label2)
        Me.tabFitxes.Controls.Add(Me.Label3)
        Me.tabFitxes.Controls.Add(Me.Label4)
        Me.tabFitxes.Location = New System.Drawing.Point(4, 22)
        Me.tabFitxes.Name = "tabFitxes"
        Me.tabFitxes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFitxes.Size = New System.Drawing.Size(861, 447)
        Me.tabFitxes.TabIndex = 0
        Me.tabFitxes.Text = "Fitxes"
        Me.tabFitxes.UseVisualStyleBackColor = True
        '
        'txtP10
        '
        Me.txtP10.Enabled = False
        Me.txtP10.Location = New System.Drawing.Point(358, 226)
        Me.txtP10.Name = "txtP10"
        Me.txtP10.Size = New System.Drawing.Size(76, 20)
        Me.txtP10.TabIndex = 30
        '
        'txtP9
        '
        Me.txtP9.Enabled = False
        Me.txtP9.Location = New System.Drawing.Point(358, 204)
        Me.txtP9.Name = "txtP9"
        Me.txtP9.Size = New System.Drawing.Size(76, 20)
        Me.txtP9.TabIndex = 29
        '
        'txtP8
        '
        Me.txtP8.Enabled = False
        Me.txtP8.Location = New System.Drawing.Point(358, 182)
        Me.txtP8.Name = "txtP8"
        Me.txtP8.Size = New System.Drawing.Size(76, 20)
        Me.txtP8.TabIndex = 28
        '
        'txtP7
        '
        Me.txtP7.Enabled = False
        Me.txtP7.Location = New System.Drawing.Point(358, 160)
        Me.txtP7.Name = "txtP7"
        Me.txtP7.Size = New System.Drawing.Size(76, 20)
        Me.txtP7.TabIndex = 27
        '
        'txtP6
        '
        Me.txtP6.Enabled = False
        Me.txtP6.Location = New System.Drawing.Point(358, 138)
        Me.txtP6.Name = "txtP6"
        Me.txtP6.Size = New System.Drawing.Size(76, 20)
        Me.txtP6.TabIndex = 26
        '
        'txtP5
        '
        Me.txtP5.Enabled = False
        Me.txtP5.Location = New System.Drawing.Point(149, 226)
        Me.txtP5.Name = "txtP5"
        Me.txtP5.Size = New System.Drawing.Size(76, 20)
        Me.txtP5.TabIndex = 25
        '
        'txtP4
        '
        Me.txtP4.Enabled = False
        Me.txtP4.Location = New System.Drawing.Point(149, 204)
        Me.txtP4.Name = "txtP4"
        Me.txtP4.Size = New System.Drawing.Size(76, 20)
        Me.txtP4.TabIndex = 24
        '
        'txtP3
        '
        Me.txtP3.Enabled = False
        Me.txtP3.Location = New System.Drawing.Point(149, 182)
        Me.txtP3.Name = "txtP3"
        Me.txtP3.Size = New System.Drawing.Size(76, 20)
        Me.txtP3.TabIndex = 23
        '
        'txtP2
        '
        Me.txtP2.Enabled = False
        Me.txtP2.Location = New System.Drawing.Point(149, 160)
        Me.txtP2.Name = "txtP2"
        Me.txtP2.Size = New System.Drawing.Size(76, 20)
        Me.txtP2.TabIndex = 22
        '
        'txtP1
        '
        Me.txtP1.Enabled = False
        Me.txtP1.Location = New System.Drawing.Point(149, 138)
        Me.txtP1.Name = "txtP1"
        Me.txtP1.Size = New System.Drawing.Size(76, 20)
        Me.txtP1.TabIndex = 21
        '
        'txtT10
        '
        Me.txtT10.Enabled = False
        Me.txtT10.Location = New System.Drawing.Point(276, 227)
        Me.txtT10.Name = "txtT10"
        Me.txtT10.Size = New System.Drawing.Size(76, 20)
        Me.txtT10.TabIndex = 20
        '
        'txtParaula
        '
        Me.txtParaula.Location = New System.Drawing.Point(167, 23)
        Me.txtParaula.Name = "txtParaula"
        Me.txtParaula.Size = New System.Drawing.Size(100, 20)
        Me.txtParaula.TabIndex = 1
        '
        'txtT9
        '
        Me.txtT9.Enabled = False
        Me.txtT9.Location = New System.Drawing.Point(276, 205)
        Me.txtT9.Name = "txtT9"
        Me.txtT9.Size = New System.Drawing.Size(76, 20)
        Me.txtT9.TabIndex = 19
        '
        'txtNum
        '
        Me.txtNum.Enabled = False
        Me.txtNum.Location = New System.Drawing.Point(122, 22)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(39, 20)
        Me.txtNum.TabIndex = 2
        '
        'txtT8
        '
        Me.txtT8.Enabled = False
        Me.txtT8.Location = New System.Drawing.Point(276, 183)
        Me.txtT8.Name = "txtT8"
        Me.txtT8.Size = New System.Drawing.Size(76, 20)
        Me.txtT8.TabIndex = 18
        '
        'txtCrono
        '
        Me.txtCrono.Enabled = False
        Me.txtCrono.Location = New System.Drawing.Point(122, 76)
        Me.txtCrono.Name = "txtCrono"
        Me.txtCrono.Size = New System.Drawing.Size(100, 20)
        Me.txtCrono.TabIndex = 3
        '
        'txtT7
        '
        Me.txtT7.Enabled = False
        Me.txtT7.Location = New System.Drawing.Point(276, 161)
        Me.txtT7.Name = "txtT7"
        Me.txtT7.Size = New System.Drawing.Size(76, 20)
        Me.txtT7.TabIndex = 17
        '
        'txtT6
        '
        Me.txtT6.Enabled = False
        Me.txtT6.Location = New System.Drawing.Point(276, 138)
        Me.txtT6.Name = "txtT6"
        Me.txtT6.Size = New System.Drawing.Size(76, 20)
        Me.txtT6.TabIndex = 16
        '
        'txtTempsMig
        '
        Me.txtTempsMig.Enabled = False
        Me.txtTempsMig.Location = New System.Drawing.Point(324, 76)
        Me.txtTempsMig.Name = "txtTempsMig"
        Me.txtTempsMig.Size = New System.Drawing.Size(100, 20)
        Me.txtTempsMig.TabIndex = 4
        '
        'txtComptador
        '
        Me.txtComptador.Enabled = False
        Me.txtComptador.Location = New System.Drawing.Point(122, 102)
        Me.txtComptador.Name = "txtComptador"
        Me.txtComptador.Size = New System.Drawing.Size(100, 20)
        Me.txtComptador.TabIndex = 5
        '
        'txtT5
        '
        Me.txtT5.Enabled = False
        Me.txtT5.Location = New System.Drawing.Point(67, 226)
        Me.txtT5.Name = "txtT5"
        Me.txtT5.Size = New System.Drawing.Size(76, 20)
        Me.txtT5.TabIndex = 15
        '
        'txtT4
        '
        Me.txtT4.Enabled = False
        Me.txtT4.Location = New System.Drawing.Point(67, 204)
        Me.txtT4.Name = "txtT4"
        Me.txtT4.Size = New System.Drawing.Size(76, 20)
        Me.txtT4.TabIndex = 14
        '
        'txtT3
        '
        Me.txtT3.Enabled = False
        Me.txtT3.Location = New System.Drawing.Point(67, 182)
        Me.txtT3.Name = "txtT3"
        Me.txtT3.Size = New System.Drawing.Size(76, 20)
        Me.txtT3.TabIndex = 13
        '
        'txtT2
        '
        Me.txtT2.Enabled = False
        Me.txtT2.Location = New System.Drawing.Point(67, 160)
        Me.txtT2.Name = "txtT2"
        Me.txtT2.Size = New System.Drawing.Size(76, 20)
        Me.txtT2.TabIndex = 12
        '
        'txtNumErrades
        '
        Me.txtNumErrades.Enabled = False
        Me.txtNumErrades.Location = New System.Drawing.Point(324, 102)
        Me.txtNumErrades.Name = "txtNumErrades"
        Me.txtNumErrades.Size = New System.Drawing.Size(100, 20)
        Me.txtNumErrades.TabIndex = 9
        '
        'txtT1
        '
        Me.txtT1.Enabled = False
        Me.txtT1.Location = New System.Drawing.Point(67, 138)
        Me.txtT1.Name = "txtT1"
        Me.txtT1.Size = New System.Drawing.Size(76, 20)
        Me.txtT1.TabIndex = 11
        '
        'cmdInici
        '
        Me.cmdInici.Location = New System.Drawing.Point(6, 18)
        Me.cmdInici.Name = "cmdInici"
        Me.cmdInici.Size = New System.Drawing.Size(83, 29)
        Me.cmdInici.TabIndex = 0
        Me.cmdInici.Text = "Iniciar"
        Me.cmdInici.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Temps"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "# Prova"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(260, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Temps mig"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(260, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Num Errors"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabFitxes)
        Me.TabControl1.Controls.Add(Me.tabNumLlarg)
        Me.TabControl1.Controls.Add(Me.tabBasc)
        Me.TabControl1.Controls.Add(Me.tabDiccionari)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(869, 473)
        Me.TabControl1.TabIndex = 31
        '
        'DiccProvesTableAdapter
        '
        Me.DiccProvesTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(8, 8)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(396, 246)
        Me.ReportViewer1.TabIndex = 31
        '
        'clsCursGenius
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 473)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "clsCursGenius"
        Me.Text = "100 Imágenes"
        CType(Me.DiccProvesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GeniusDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BascBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDiccionari.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdFills, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuBarraDicc.ResumeLayout(False)
        Me.mnuBarraDicc.PerformLayout()
        Me.tabBasc.ResumeLayout(False)
        Me.tabBasc.PerformLayout()
        Me.grpProvaActual.ResumeLayout(False)
        Me.grpProvaActual.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpSeleccioExamen.ResumeLayout(False)
        Me.grpSeleccioExamen.PerformLayout()
        Me.tabNumLlarg.ResumeLayout(False)
        Me.tabNumLlarg.PerformLayout()
        Me.tabFitxes.ResumeLayout(False)
        Me.tabFitxes.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GeniusDataSet As GeniusDataSet
    Friend WithEvents BascBindingSource As BindingSource
    Friend WithEvents BascTableAdapter As GeniusDataSetTableAdapters.BascTableAdapter
    Friend WithEvents TableAdapterManager As GeniusDataSetTableAdapters.TableAdapterManager
    Friend WithEvents tabDiccionari As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tvwTesaurus As TreeView
    Friend WithEvents grdFills As DataGridView
    Friend WithEvents colThesaurus As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents mnuBarraDicc As ToolStrip
    Friend WithEvents cmdDiccLegeix As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lblPare As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents txtDiccNouCodi As ToolStripTextBox
    Friend WithEvents cmdDiccCanviCodi As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents tabBasc As TabPage
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblContador As ToolStripStatusLabel
    Friend WithEvents lblMax As ToolStripStatusLabel
    Friend WithEvents barProgres As ToolStripProgressBar
    Friend WithEvents cmdExport As Button
    Friend WithEvents lblEstAApr As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblEstNoTra As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblEstNoPla As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblEstR6m As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents grpSeleccioExamen As GroupBox
    Friend WithEvents lblExamMal As Label
    Friend WithEvents txtExamCodis As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents lblExamPse As Label
    Friend WithEvents lblExamBe As Label
    Friend WithEvents dtpExamFins As DateTimePicker
    Friend WithEvents Label28 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents dtpExamDesde As DateTimePicker
    Friend WithEvents txtExamenNumPar As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cmdExamen As Button
    Friend WithEvents lblEstR1m As Label
    Friend WithEvents lblEstR1s As Label
    Friend WithEvents lblEstR1d As Label
    Friend WithEvents lblEstR1h As Label
    Friend WithEvents lblEstApre As Label
    Friend WithEvents lblEstPrep As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmdRepAbandona As Button
    Friend WithEvents cmdRepPista As Button
    Friend WithEvents cmdFerPendent As Button
    Friend WithEvents cmdPAVOk As Button
    Friend WithEvents lblPAV As Label
    Friend WithEvents lblBasc As Label
    Friend WithEvents lblCat As Label
    Friend WithEvents txtFerPAV As TextBox
    Friend WithEvents txtFerBasc As TextBox
    Friend WithEvents txtFerCat As TextBox
    Friend WithEvents chkRevPendents As CheckBox
    Friend WithEvents cmdMirarPendent As Button
    Friend WithEvents tabNumLlarg As TabPage
    Friend WithEvents cmdAbandona As Button
    Friend WithEvents txtNumLlargUltFet As TextBox
    Friend WithEvents txtNumARecordar As TextBox
    Friend WithEvents txtNumDigits As TextBox
    Friend WithEvents txtCronoRec As TextBox
    Friend WithEvents txtCronoMem As TextBox
    Friend WithEvents txtNumRecordat As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmdCreaNum As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmdEsborra As Button
    Friend WithEvents tabFitxes As TabPage
    Friend WithEvents txtP10 As TextBox
    Friend WithEvents txtP9 As TextBox
    Friend WithEvents txtP8 As TextBox
    Friend WithEvents txtP7 As TextBox
    Friend WithEvents txtP6 As TextBox
    Friend WithEvents txtP5 As TextBox
    Friend WithEvents txtP4 As TextBox
    Friend WithEvents txtP3 As TextBox
    Friend WithEvents txtP2 As TextBox
    Friend WithEvents txtP1 As TextBox
    Friend WithEvents txtT10 As TextBox
    Friend WithEvents txtParaula As TextBox
    Friend WithEvents txtT9 As TextBox
    Friend WithEvents txtNum As TextBox
    Friend WithEvents txtT8 As TextBox
    Friend WithEvents txtCrono As TextBox
    Friend WithEvents txtT7 As TextBox
    Friend WithEvents txtT6 As TextBox
    Friend WithEvents txtTempsMig As TextBox
    Friend WithEvents txtComptador As TextBox
    Friend WithEvents txtT5 As TextBox
    Friend WithEvents txtT4 As TextBox
    Friend WithEvents txtT3 As TextBox
    Friend WithEvents txtT2 As TextBox
    Friend WithEvents txtNumErrades As TextBox
    Friend WithEvents txtT1 As TextBox
    Friend WithEvents cmdInici As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents grpProvaActual As GroupBox
    Friend WithEvents lblExamActual As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents lblExamTotal As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents lblExamPend As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents lblExamResp As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents lblIdProva As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents DiccProvesBindingSource As BindingSource
    Friend WithEvents DiccProvesTableAdapter As GeniusDataSetTableAdapters.DiccProvesTableAdapter
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
