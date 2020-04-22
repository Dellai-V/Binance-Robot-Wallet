<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.NumericChart = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericTrade = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboPeriod = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Numeric2 = New System.Windows.Forms.NumericUpDown()
        Me.TextBoxAsset = New System.Windows.Forms.TextBox()
        Me.ButtonEdit = New System.Windows.Forms.Button()
        Me.ButtonRemove = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumericAssetOwn = New System.Windows.Forms.NumericUpDown()
        CType(Me.NumericChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericTrade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeric2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericAssetOwn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericChart
        '
        Me.NumericChart.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NumericChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericChart.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericChart.ForeColor = System.Drawing.Color.White
        Me.NumericChart.Location = New System.Drawing.Point(532, 14)
        Me.NumericChart.Maximum = New Decimal(New Integer() {320, 0, 0, 0})
        Me.NumericChart.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericChart.Name = "NumericChart"
        Me.NumericChart.Size = New System.Drawing.Size(60, 23)
        Me.NumericChart.TabIndex = 0
        Me.NumericChart.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(333, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Update Time Charts in seconds :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(339, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Update Time Trade in minutes :"
        '
        'NumericTrade
        '
        Me.NumericTrade.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NumericTrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericTrade.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericTrade.ForeColor = System.Drawing.Color.White
        Me.NumericTrade.Location = New System.Drawing.Point(532, 43)
        Me.NumericTrade.Maximum = New Decimal(New Integer() {320, 0, 0, 0})
        Me.NumericTrade.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericTrade.Name = "NumericTrade"
        Me.NumericTrade.Size = New System.Drawing.Size(60, 23)
        Me.NumericTrade.TabIndex = 2
        Me.NumericTrade.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(423, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "Charts Period  :"
        '
        'ComboPeriod
        '
        Me.ComboPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ComboPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboPeriod.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboPeriod.ForeColor = System.Drawing.Color.White
        Me.ComboPeriod.FormattingEnabled = True
        Me.ComboPeriod.Items.AddRange(New Object() {"1W", "3D", "1D", "12h", "8h", "6h", "4h", "2h", "1h", "30m", "15m", "5m", "3m", "1m"})
        Me.ComboPeriod.Location = New System.Drawing.Point(532, 70)
        Me.ComboPeriod.Name = "ComboPeriod"
        Me.ComboPeriod.Size = New System.Drawing.Size(60, 22)
        Me.ComboPeriod.TabIndex = 182
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(446, 133)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 30)
        Me.Button1.TabIndex = 183
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Numeric2
        '
        Me.Numeric2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Numeric2.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeric2.ForeColor = System.Drawing.Color.Silver
        Me.Numeric2.Location = New System.Drawing.Point(210, 41)
        Me.Numeric2.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Numeric2.Name = "Numeric2"
        Me.Numeric2.Size = New System.Drawing.Size(87, 23)
        Me.Numeric2.TabIndex = 201
        Me.Numeric2.Tag = ""
        Me.Numeric2.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'TextBoxAsset
        '
        Me.TextBoxAsset.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TextBoxAsset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxAsset.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAsset.ForeColor = System.Drawing.Color.Silver
        Me.TextBoxAsset.Location = New System.Drawing.Point(210, 12)
        Me.TextBoxAsset.Name = "TextBoxAsset"
        Me.TextBoxAsset.Size = New System.Drawing.Size(87, 23)
        Me.TextBoxAsset.TabIndex = 200
        '
        'ButtonEdit
        '
        Me.ButtonEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ButtonEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEdit.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEdit.ForeColor = System.Drawing.Color.White
        Me.ButtonEdit.Location = New System.Drawing.Point(151, 70)
        Me.ButtonEdit.Name = "ButtonEdit"
        Me.ButtonEdit.Size = New System.Drawing.Size(146, 30)
        Me.ButtonEdit.TabIndex = 199
        Me.ButtonEdit.Text = "Add/Edit Asset"
        Me.ButtonEdit.UseVisualStyleBackColor = False
        '
        'ButtonRemove
        '
        Me.ButtonRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ButtonRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRemove.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRemove.ForeColor = System.Drawing.Color.White
        Me.ButtonRemove.Location = New System.Drawing.Point(151, 106)
        Me.ButtonRemove.Name = "ButtonRemove"
        Me.ButtonRemove.Size = New System.Drawing.Size(146, 30)
        Me.ButtonRemove.TabIndex = 198
        Me.ButtonRemove.Text = "Remove"
        Me.ButtonRemove.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(148, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 197
        Me.Label7.Text = "Split :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(148, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 196
        Me.Label6.Text = "Asset :"
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListView1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.Transparent
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(140, 175)
        Me.ListView1.TabIndex = 195
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Asset"
        Me.ColumnHeader17.Width = 65
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Split"
        Me.ColumnHeader18.Width = 65
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(435, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 203
        Me.Label3.Text = "Asset to own :"
        '
        'NumericAssetOwn
        '
        Me.NumericAssetOwn.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NumericAssetOwn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericAssetOwn.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericAssetOwn.ForeColor = System.Drawing.Color.White
        Me.NumericAssetOwn.Location = New System.Drawing.Point(532, 98)
        Me.NumericAssetOwn.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.NumericAssetOwn.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericAssetOwn.Name = "NumericAssetOwn"
        Me.NumericAssetOwn.Size = New System.Drawing.Size(60, 23)
        Me.NumericAssetOwn.TabIndex = 202
        Me.NumericAssetOwn.Value = New Decimal(New Integer() {99, 0, 0, 0})
        '
        'Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(606, 175)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericAssetOwn)
        Me.Controls.Add(Me.Numeric2)
        Me.Controls.Add(Me.TextBoxAsset)
        Me.Controls.Add(Me.ButtonEdit)
        Me.Controls.Add(Me.ButtonRemove)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboPeriod)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericTrade)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericChart)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setting"
        Me.ShowIcon = False
        Me.Text = "Setting"
        CType(Me.NumericChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericTrade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeric2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericAssetOwn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NumericChart As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NumericTrade As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboPeriod As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Numeric2 As NumericUpDown
    Friend WithEvents TextBoxAsset As TextBox
    Friend WithEvents ButtonEdit As Button
    Friend WithEvents ButtonRemove As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericAssetOwn As NumericUpDown
End Class
