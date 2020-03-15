<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BOT
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BOT))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ListView4 = New System.Windows.Forms.ListView()
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LabelBUY = New System.Windows.Forms.Label()
        Me.LabelSELL = New System.Windows.Forms.Label()
        Me.TextLog = New System.Windows.Forms.RichTextBox()
        Me.ButtonSetting = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.LabelTOT = New System.Windows.Forms.Label()
        Me.LabelUSD = New System.Windows.Forms.Label()
        Me.Label1D = New System.Windows.Forms.Label()
        Me.Label7D = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(144, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.ToolStripMenuItem1.Text = "Cancel Order"
        '
        'Chart2
        '
        Me.Chart2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart2.BackColor = System.Drawing.Color.Transparent
        Me.Chart2.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea1.AxisX.IsStartedFromZero = False
        ChartArea1.AxisX2.IsStartedFromZero = False
        ChartArea1.AxisY.IsStartedFromZero = False
        ChartArea1.AxisY2.IsStartedFromZero = False
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.BackImageTransparentColor = System.Drawing.Color.Transparent
        ChartArea1.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea1.BorderColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea1)
        Me.Chart2.Location = New System.Drawing.Point(679, 451)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Series1.IsVisibleInLegend = False
        Series1.Name = "Asset"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
        Me.Chart2.Series.Add(Series1)
        Me.Chart2.Size = New System.Drawing.Size(690, 207)
        Me.Chart2.TabIndex = 155
        Me.Chart2.Text = "Chart2"
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.Transparent
        Me.Chart1.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.BackImageTransparentColor = System.Drawing.Color.Transparent
        ChartArea2.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea2.BorderColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.ForeColor = System.Drawing.Color.Gainsboro
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(394, 655)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series2.Legend = "Legend1"
        Series2.Name = "Asset"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(279, 298)
        Me.Chart1.TabIndex = 153
        Me.Chart1.Text = "Chart1"
        '
        'ListView4
        '
        Me.ListView4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView4.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListView4.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26})
        Me.ListView4.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView4.ForeColor = System.Drawing.Color.Transparent
        Me.ListView4.HideSelection = False
        Me.ListView4.Location = New System.Drawing.Point(8, 453)
        Me.ListView4.Name = "ListView4"
        Me.ListView4.Size = New System.Drawing.Size(380, 500)
        Me.ListView4.TabIndex = 149
        Me.ListView4.UseCompatibleStateImageBehavior = False
        Me.ListView4.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Name"
        Me.ColumnHeader21.Width = 100
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Price"
        Me.ColumnHeader22.Width = 100
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "SIde"
        Me.ColumnHeader23.Width = 50
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Original Quantity"
        Me.ColumnHeader24.Width = 130
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Executed Quantity"
        Me.ColumnHeader25.Width = 130
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "ID"
        Me.ColumnHeader26.Width = 100
        '
        'ListView3
        '
        Me.ListView3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView3.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader27})
        Me.ListView3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView3.ForeColor = System.Drawing.Color.Transparent
        Me.ListView3.HideSelection = False
        Me.ListView3.Location = New System.Drawing.Point(679, 664)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(690, 300)
        Me.ListView3.TabIndex = 148
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Asset"
        Me.ColumnHeader17.Width = 75
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Balance Total"
        Me.ColumnHeader18.Width = 150
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Balance Free"
        Me.ColumnHeader19.Width = 150
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Orders"
        Me.ColumnHeader20.Width = 150
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Ideal"
        Me.ColumnHeader27.Width = 150
        '
        'ListView2
        '
        Me.ListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListView2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.ForeColor = System.Drawing.Color.Transparent
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(8, 45)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(665, 400)
        Me.ListView2.TabIndex = 147
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Name"
        Me.ColumnHeader5.Width = 106
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Price"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Higth"
        Me.ColumnHeader7.Width = 85
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Low"
        Me.ColumnHeader8.Width = 84
        '
        'LabelBUY
        '
        Me.LabelBUY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelBUY.AutoSize = True
        Me.LabelBUY.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBUY.ForeColor = System.Drawing.Color.Green
        Me.LabelBUY.Location = New System.Drawing.Point(394, 466)
        Me.LabelBUY.Name = "LabelBUY"
        Me.LabelBUY.Size = New System.Drawing.Size(90, 19)
        Me.LabelBUY.TabIndex = 170
        Me.LabelBUY.Text = "BUY : BTC"
        '
        'LabelSELL
        '
        Me.LabelSELL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelSELL.AutoSize = True
        Me.LabelSELL.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSELL.ForeColor = System.Drawing.Color.Salmon
        Me.LabelSELL.Location = New System.Drawing.Point(574, 466)
        Me.LabelSELL.Name = "LabelSELL"
        Me.LabelSELL.Size = New System.Drawing.Size(99, 19)
        Me.LabelSELL.TabIndex = 171
        Me.LabelSELL.Text = "SELL : BTC"
        '
        'TextLog
        '
        Me.TextLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TextLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextLog.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextLog.ForeColor = System.Drawing.Color.Silver
        Me.TextLog.Location = New System.Drawing.Point(679, 45)
        Me.TextLog.Name = "TextLog"
        Me.TextLog.Size = New System.Drawing.Size(690, 400)
        Me.TextLog.TabIndex = 172
        Me.TextLog.Text = ""
        '
        'ButtonSetting
        '
        Me.ButtonSetting.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ButtonSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSetting.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSetting.ForeColor = System.Drawing.Color.White
        Me.ButtonSetting.Location = New System.Drawing.Point(8, 4)
        Me.ButtonSetting.Name = "ButtonSetting"
        Me.ButtonSetting.Size = New System.Drawing.Size(85, 30)
        Me.ButtonSetting.TabIndex = 173
        Me.ButtonSetting.Text = "Setting"
        Me.ButtonSetting.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(119, 10)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(119, 17)
        Me.CheckBox1.TabIndex = 174
        Me.CheckBox1.Text = "Active Bot Trade"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'LabelTOT
        '
        Me.LabelTOT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelTOT.AutoSize = True
        Me.LabelTOT.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTOT.ForeColor = System.Drawing.Color.Silver
        Me.LabelTOT.Location = New System.Drawing.Point(394, 574)
        Me.LabelTOT.Name = "LabelTOT"
        Me.LabelTOT.Size = New System.Drawing.Size(80, 22)
        Me.LabelTOT.TabIndex = 175
        Me.LabelTOT.Text = "Tot : 0"
        '
        'LabelUSD
        '
        Me.LabelUSD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelUSD.AutoSize = True
        Me.LabelUSD.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUSD.ForeColor = System.Drawing.Color.Silver
        Me.LabelUSD.Location = New System.Drawing.Point(421, 608)
        Me.LabelUSD.Name = "LabelUSD"
        Me.LabelUSD.Size = New System.Drawing.Size(63, 19)
        Me.LabelUSD.TabIndex = 176
        Me.LabelUSD.Text = " ~ 0 $"
        '
        'Label1D
        '
        Me.Label1D.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1D.AutoSize = True
        Me.Label1D.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1D.ForeColor = System.Drawing.Color.Silver
        Me.Label1D.Location = New System.Drawing.Point(394, 519)
        Me.Label1D.Name = "Label1D"
        Me.Label1D.Size = New System.Drawing.Size(72, 19)
        Me.Label1D.TabIndex = 177
        Me.Label1D.Text = "1D : 0%"
        '
        'Label7D
        '
        Me.Label7D.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7D.AutoSize = True
        Me.Label7D.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7D.ForeColor = System.Drawing.Color.Silver
        Me.Label7D.Location = New System.Drawing.Point(394, 538)
        Me.Label7D.Name = "Label7D"
        Me.Label7D.Size = New System.Drawing.Size(72, 19)
        Me.Label7D.TabIndex = 178
        Me.Label7D.Text = "7D : 0%"
        '
        'BOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1384, 961)
        Me.Controls.Add(Me.Label7D)
        Me.Controls.Add(Me.Label1D)
        Me.Controls.Add(Me.LabelUSD)
        Me.Controls.Add(Me.LabelTOT)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ButtonSetting)
        Me.Controls.Add(Me.TextLog)
        Me.Controls.Add(Me.LabelSELL)
        Me.Controls.Add(Me.LabelBUY)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.ListView4)
        Me.Controls.Add(Me.ListView3)
        Me.Controls.Add(Me.ListView2)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BOT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DV Bot"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents ListView4 As ListView
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents ColumnHeader25 As ColumnHeader
    Friend WithEvents ColumnHeader26 As ColumnHeader
    Friend WithEvents ListView3 As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents LabelBUY As Label
    Friend WithEvents LabelSELL As Label
    Friend WithEvents TextLog As RichTextBox
    Friend WithEvents ButtonSetting As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents LabelTOT As Label
    Friend WithEvents LabelUSD As Label
    Friend WithEvents Label1D As Label
    Friend WithEvents Label7D As Label
End Class
