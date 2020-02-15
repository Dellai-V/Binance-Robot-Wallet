<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuration
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ButtonRemove = New System.Windows.Forms.Button()
        Me.ButtonEdit = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.ButtonGitHub = New System.Windows.Forms.Button()
        Me.Account = New System.Windows.Forms.Button()
        Me.TextBoxKey = New System.Windows.Forms.TextBox()
        Me.TextBoxSecret = New System.Windows.Forms.TextBox()
        Me.TextBoxPeriod = New System.Windows.Forms.TextBox()
        Me.TextBoxAsset = New System.Windows.Forms.TextBox()
        Me.Numeric1 = New System.Windows.Forms.NumericUpDown()
        Me.Numeric2 = New System.Windows.Forms.NumericUpDown()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeric1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeric2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.Transparent
        Me.Chart1.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.BackImageTransparentColor = System.Drawing.Color.Transparent
        ChartArea1.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea1.BorderColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.ForeColor = System.Drawing.Color.Gainsboro
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(413, 210)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series1.Legend = "Legend1"
        Series1.Name = "Asset"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(285, 218)
        Me.Chart1.TabIndex = 148
        Me.Chart1.Text = "Chart1"
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18})
        Me.ListView1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.Transparent
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(16, 32)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(197, 364)
        Me.ListView1.TabIndex = 141
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Asset"
        Me.ColumnHeader17.Width = 90
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Split"
        Me.ColumnHeader18.Width = 98
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(250, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 18)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "API KEY :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(226, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 18)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = "API SECRET :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(226, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 15)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Update Time  :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(504, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 15)
        Me.Label4.TabIndex = 180
        Me.Label4.Text = "Charts Period  :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Silver
        Me.Label5.Location = New System.Drawing.Point(626, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 15)
        Me.Label5.TabIndex = 181
        Me.Label5.Text = "es. : 3D, 1D, 5m, 1h"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(235, 227)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "Asset :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(235, 271)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 183
        Me.Label7.Text = "Split :"
        '
        'ButtonRemove
        '
        Me.ButtonRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ButtonRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRemove.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRemove.ForeColor = System.Drawing.Color.White
        Me.ButtonRemove.Location = New System.Drawing.Point(16, 402)
        Me.ButtonRemove.Name = "ButtonRemove"
        Me.ButtonRemove.Size = New System.Drawing.Size(197, 30)
        Me.ButtonRemove.TabIndex = 184
        Me.ButtonRemove.Text = "Remove"
        Me.ButtonRemove.UseVisualStyleBackColor = False
        '
        'ButtonEdit
        '
        Me.ButtonEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ButtonEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEdit.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEdit.ForeColor = System.Drawing.Color.White
        Me.ButtonEdit.Location = New System.Drawing.Point(219, 322)
        Me.ButtonEdit.Name = "ButtonEdit"
        Me.ButtonEdit.Size = New System.Drawing.Size(172, 74)
        Me.ButtonEdit.TabIndex = 185
        Me.ButtonEdit.Text = "Add/Edit Asset"
        Me.ButtonEdit.UseVisualStyleBackColor = False
        '
        'ButtonSave
        '
        Me.ButtonSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ButtonSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSave.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSave.ForeColor = System.Drawing.Color.White
        Me.ButtonSave.Location = New System.Drawing.Point(704, 371)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(112, 61)
        Me.ButtonSave.TabIndex = 186
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.UseVisualStyleBackColor = False
        '
        'ButtonGitHub
        '
        Me.ButtonGitHub.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ButtonGitHub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonGitHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonGitHub.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGitHub.ForeColor = System.Drawing.Color.White
        Me.ButtonGitHub.Location = New System.Drawing.Point(704, 262)
        Me.ButtonGitHub.Name = "ButtonGitHub"
        Me.ButtonGitHub.Size = New System.Drawing.Size(112, 30)
        Me.ButtonGitHub.TabIndex = 187
        Me.ButtonGitHub.Text = "GitHub"
        Me.ButtonGitHub.UseVisualStyleBackColor = False
        '
        'Account
        '
        Me.Account.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Account.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Account.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Account.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Account.ForeColor = System.Drawing.Color.White
        Me.Account.Location = New System.Drawing.Point(704, 226)
        Me.Account.Name = "Account"
        Me.Account.Size = New System.Drawing.Size(112, 30)
        Me.Account.TabIndex = 188
        Me.Account.Text = "New Account"
        Me.Account.UseVisualStyleBackColor = False
        '
        'TextBoxKey
        '
        Me.TextBoxKey.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TextBoxKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxKey.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKey.ForeColor = System.Drawing.Color.Silver
        Me.TextBoxKey.Location = New System.Drawing.Point(336, 43)
        Me.TextBoxKey.Name = "TextBoxKey"
        Me.TextBoxKey.Size = New System.Drawing.Size(480, 23)
        Me.TextBoxKey.TabIndex = 189
        '
        'TextBoxSecret
        '
        Me.TextBoxSecret.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TextBoxSecret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxSecret.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSecret.ForeColor = System.Drawing.Color.Silver
        Me.TextBoxSecret.Location = New System.Drawing.Point(336, 78)
        Me.TextBoxSecret.Name = "TextBoxSecret"
        Me.TextBoxSecret.Size = New System.Drawing.Size(480, 23)
        Me.TextBoxSecret.TabIndex = 190
        Me.TextBoxSecret.UseSystemPasswordChar = True
        '
        'TextBoxPeriod
        '
        Me.TextBoxPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TextBoxPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPeriod.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPeriod.ForeColor = System.Drawing.Color.Silver
        Me.TextBoxPeriod.Location = New System.Drawing.Point(629, 126)
        Me.TextBoxPeriod.Name = "TextBoxPeriod"
        Me.TextBoxPeriod.Size = New System.Drawing.Size(187, 23)
        Me.TextBoxPeriod.TabIndex = 191
        Me.TextBoxPeriod.Text = "3D, 1D"
        '
        'TextBoxAsset
        '
        Me.TextBoxAsset.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TextBoxAsset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxAsset.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAsset.ForeColor = System.Drawing.Color.Silver
        Me.TextBoxAsset.Location = New System.Drawing.Point(297, 225)
        Me.TextBoxAsset.Name = "TextBoxAsset"
        Me.TextBoxAsset.Size = New System.Drawing.Size(94, 23)
        Me.TextBoxAsset.TabIndex = 192
        '
        'Numeric1
        '
        Me.Numeric1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Numeric1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeric1.ForeColor = System.Drawing.Color.Silver
        Me.Numeric1.Location = New System.Drawing.Point(336, 126)
        Me.Numeric1.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.Numeric1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Numeric1.Name = "Numeric1"
        Me.Numeric1.Size = New System.Drawing.Size(75, 23)
        Me.Numeric1.TabIndex = 193
        Me.Numeric1.Tag = ""
        Me.Numeric1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Numeric2
        '
        Me.Numeric2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Numeric2.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Numeric2.ForeColor = System.Drawing.Color.Silver
        Me.Numeric2.Location = New System.Drawing.Point(297, 267)
        Me.Numeric2.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Numeric2.Name = "Numeric2"
        Me.Numeric2.Size = New System.Drawing.Size(94, 23)
        Me.Numeric2.TabIndex = 194
        Me.Numeric2.Tag = ""
        Me.Numeric2.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(833, 465)
        Me.Controls.Add(Me.Numeric2)
        Me.Controls.Add(Me.Numeric1)
        Me.Controls.Add(Me.TextBoxAsset)
        Me.Controls.Add(Me.TextBoxPeriod)
        Me.Controls.Add(Me.TextBoxSecret)
        Me.Controls.Add(Me.TextBoxKey)
        Me.Controls.Add(Me.Account)
        Me.Controls.Add(Me.ButtonGitHub)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.ButtonEdit)
        Me.Controls.Add(Me.ButtonRemove)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Configuration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confing"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeric1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeric2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ButtonRemove As Button
    Friend WithEvents ButtonEdit As Button
    Friend WithEvents ButtonSave As Button
    Friend WithEvents ButtonGitHub As Button
    Friend WithEvents Account As Button
    Friend WithEvents TextBoxKey As TextBox
    Friend WithEvents TextBoxSecret As TextBox
    Friend WithEvents TextBoxPeriod As TextBox
    Friend WithEvents TextBoxAsset As TextBox
    Friend WithEvents Numeric1 As NumericUpDown
    Friend WithEvents Numeric2 As NumericUpDown
End Class
