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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.XThemeContainer1 = New Binance.XThemeContainer()
        Me.XLabel7 = New Binance.XLabel()
        Me.XButton4 = New Binance.XButton()
        Me.XButton3 = New Binance.XButton()
        Me.XLabel4 = New Binance.XLabel()
        Me.XButton2 = New Binance.XButton()
        Me.XLabel6 = New Binance.XLabel()
        Me.XLabel5 = New Binance.XLabel()
        Me.XNormalTextBox2 = New Binance.XNormalTextBox()
        Me.XNormalTextBox1 = New Binance.XNormalTextBox()
        Me.XComboBox3 = New Binance.XComboBox()
        Me.XComboBox2 = New Binance.XComboBox()
        Me.XComboBox1 = New Binance.XComboBox()
        Me.XLabel3 = New Binance.XLabel()
        Me.XLabel2 = New Binance.XLabel()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.CheckBox1 = New Binance.XCheckBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TextLog = New Binance.XRichTextBox()
        Me.XButton1 = New Binance.XButton()
        Me.XLabel1 = New Binance.XLabel()
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
        Me.ContextMenuStrip1.SuspendLayout()
        Me.XThemeContainer1.SuspendLayout()
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
        'XThemeContainer1
        '
        Me.XThemeContainer1.AllowClose = True
        Me.XThemeContainer1.AllowMaximize = True
        Me.XThemeContainer1.AllowMinimize = True
        Me.XThemeContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XThemeContainer1.BaseColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XThemeContainer1.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XThemeContainer1.ContainerColour = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.XThemeContainer1.Controls.Add(Me.XLabel7)
        Me.XThemeContainer1.Controls.Add(Me.XButton4)
        Me.XThemeContainer1.Controls.Add(Me.XButton3)
        Me.XThemeContainer1.Controls.Add(Me.XLabel4)
        Me.XThemeContainer1.Controls.Add(Me.XButton2)
        Me.XThemeContainer1.Controls.Add(Me.XLabel6)
        Me.XThemeContainer1.Controls.Add(Me.XLabel5)
        Me.XThemeContainer1.Controls.Add(Me.XNormalTextBox2)
        Me.XThemeContainer1.Controls.Add(Me.XNormalTextBox1)
        Me.XThemeContainer1.Controls.Add(Me.XComboBox3)
        Me.XThemeContainer1.Controls.Add(Me.XComboBox2)
        Me.XThemeContainer1.Controls.Add(Me.XComboBox1)
        Me.XThemeContainer1.Controls.Add(Me.XLabel3)
        Me.XThemeContainer1.Controls.Add(Me.XLabel2)
        Me.XThemeContainer1.Controls.Add(Me.Chart2)
        Me.XThemeContainer1.Controls.Add(Me.CheckBox1)
        Me.XThemeContainer1.Controls.Add(Me.Chart1)
        Me.XThemeContainer1.Controls.Add(Me.TextLog)
        Me.XThemeContainer1.Controls.Add(Me.XButton1)
        Me.XThemeContainer1.Controls.Add(Me.XLabel1)
        Me.XThemeContainer1.Controls.Add(Me.ListView4)
        Me.XThemeContainer1.Controls.Add(Me.ListView3)
        Me.XThemeContainer1.Controls.Add(Me.ListView2)
        Me.XThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XThemeContainer1.FontColour = System.Drawing.Color.White
        Me.XThemeContainer1.FontSize = 10
        Me.XThemeContainer1.HoverColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.XThemeContainer1.Name = "XThemeContainer1"
        Me.XThemeContainer1.ShowIcon = False
        Me.XThemeContainer1.Size = New System.Drawing.Size(1920, 1050)
        Me.XThemeContainer1.TabIndex = 0
        Me.XThemeContainer1.Text = "BINANCE"
        '
        'XLabel7
        '
        Me.XLabel7.AutoSize = True
        Me.XLabel7.BackColor = System.Drawing.Color.Transparent
        Me.XLabel7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.XLabel7.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XLabel7.Location = New System.Drawing.Point(393, 658)
        Me.XLabel7.Name = "XLabel7"
        Me.XLabel7.Size = New System.Drawing.Size(26, 15)
        Me.XLabel7.TabIndex = 145
        Me.XLabel7.Text = "BTC"
        '
        'XButton4
        '
        Me.XButton4.BackColor = System.Drawing.Color.Transparent
        Me.XButton4.BaseColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XButton4.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XButton4.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XButton4.HoverColour = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.XButton4.Location = New System.Drawing.Point(364, 650)
        Me.XButton4.Name = "XButton4"
        Me.XButton4.PressedColour = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.XButton4.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.XButton4.Size = New System.Drawing.Size(23, 30)
        Me.XButton4.TabIndex = 144
        Me.XButton4.Text = "+"
        '
        'XButton3
        '
        Me.XButton3.BackColor = System.Drawing.Color.Transparent
        Me.XButton3.BaseColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XButton3.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XButton3.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XButton3.HoverColour = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.XButton3.Location = New System.Drawing.Point(335, 650)
        Me.XButton3.Name = "XButton3"
        Me.XButton3.PressedColour = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.XButton3.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.XButton3.Size = New System.Drawing.Size(23, 30)
        Me.XButton3.TabIndex = 143
        Me.XButton3.Text = "-"
        '
        'XLabel4
        '
        Me.XLabel4.AutoSize = True
        Me.XLabel4.BackColor = System.Drawing.Color.Transparent
        Me.XLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.XLabel4.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XLabel4.Location = New System.Drawing.Point(332, 693)
        Me.XLabel4.Name = "XLabel4"
        Me.XLabel4.Size = New System.Drawing.Size(26, 15)
        Me.XLabel4.TabIndex = 142
        Me.XLabel4.Text = "BTC"
        '
        'XButton2
        '
        Me.XButton2.BackColor = System.Drawing.Color.Transparent
        Me.XButton2.BaseColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XButton2.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XButton2.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XButton2.HoverColour = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.XButton2.Location = New System.Drawing.Point(521, 650)
        Me.XButton2.Name = "XButton2"
        Me.XButton2.PressedColour = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.XButton2.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.XButton2.Size = New System.Drawing.Size(113, 64)
        Me.XButton2.TabIndex = 141
        Me.XButton2.Text = "BUY"
        '
        'XLabel6
        '
        Me.XLabel6.AutoSize = True
        Me.XLabel6.BackColor = System.Drawing.Color.Transparent
        Me.XLabel6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.XLabel6.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XLabel6.Location = New System.Drawing.Point(148, 693)
        Me.XLabel6.Name = "XLabel6"
        Me.XLabel6.Size = New System.Drawing.Size(59, 15)
        Me.XLabel6.TabIndex = 140
        Me.XLabel6.Text = "Quantity :"
        '
        'XLabel5
        '
        Me.XLabel5.AutoSize = True
        Me.XLabel5.BackColor = System.Drawing.Color.Transparent
        Me.XLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.XLabel5.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XLabel5.Location = New System.Drawing.Point(168, 658)
        Me.XLabel5.Name = "XLabel5"
        Me.XLabel5.Size = New System.Drawing.Size(39, 15)
        Me.XLabel5.TabIndex = 139
        Me.XLabel5.Text = "Price :"
        '
        'XNormalTextBox2
        '
        Me.XNormalTextBox2.BackColor = System.Drawing.Color.Transparent
        Me.XNormalTextBox2.BackgroundColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XNormalTextBox2.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XNormalTextBox2.Location = New System.Drawing.Point(213, 685)
        Me.XNormalTextBox2.MaxLength = 32767
        Me.XNormalTextBox2.Multiline = False
        Me.XNormalTextBox2.Name = "XNormalTextBox2"
        Me.XNormalTextBox2.ReadOnly = False
        Me.XNormalTextBox2.Size = New System.Drawing.Size(113, 29)
        Me.XNormalTextBox2.Style = Binance.XNormalTextBox.Styles.NotRounded
        Me.XNormalTextBox2.TabIndex = 137
        Me.XNormalTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.XNormalTextBox2.TextColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XNormalTextBox2.UseSystemPasswordChar = False
        '
        'XNormalTextBox1
        '
        Me.XNormalTextBox1.BackColor = System.Drawing.Color.Transparent
        Me.XNormalTextBox1.BackgroundColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XNormalTextBox1.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XNormalTextBox1.Location = New System.Drawing.Point(213, 650)
        Me.XNormalTextBox1.MaxLength = 32767
        Me.XNormalTextBox1.Multiline = False
        Me.XNormalTextBox1.Name = "XNormalTextBox1"
        Me.XNormalTextBox1.ReadOnly = False
        Me.XNormalTextBox1.Size = New System.Drawing.Size(113, 29)
        Me.XNormalTextBox1.Style = Binance.XNormalTextBox.Styles.NotRounded
        Me.XNormalTextBox1.TabIndex = 136
        Me.XNormalTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.XNormalTextBox1.TextColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XNormalTextBox1.UseSystemPasswordChar = False
        '
        'XComboBox3
        '
        Me.XComboBox3.ArrowColour = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.XComboBox3.BackColor = System.Drawing.Color.Transparent
        Me.XComboBox3.BaseColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XComboBox3.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XComboBox3.DisplayMember = "0"
        Me.XComboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.XComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.XComboBox3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.XComboBox3.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XComboBox3.FormattingEnabled = True
        Me.XComboBox3.Items.AddRange(New Object() {"LIMIT", "MARKET"})
        Me.XComboBox3.LineColour = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.XComboBox3.Location = New System.Drawing.Point(94, 618)
        Me.XComboBox3.Name = "XComboBox3"
        Me.XComboBox3.Size = New System.Drawing.Size(113, 26)
        Me.XComboBox3.SqaureColour = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.XComboBox3.SqaureHoverColour = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.XComboBox3.StartIndex = 0
        Me.XComboBox3.TabIndex = 135
        Me.XComboBox3.ValueMember = "0"
        '
        'XComboBox2
        '
        Me.XComboBox2.ArrowColour = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.XComboBox2.BackColor = System.Drawing.Color.Transparent
        Me.XComboBox2.BaseColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XComboBox2.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XComboBox2.DisplayMember = "0"
        Me.XComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.XComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.XComboBox2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.XComboBox2.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XComboBox2.FormattingEnabled = True
        Me.XComboBox2.LineColour = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.XComboBox2.Location = New System.Drawing.Point(332, 618)
        Me.XComboBox2.Name = "XComboBox2"
        Me.XComboBox2.Size = New System.Drawing.Size(113, 26)
        Me.XComboBox2.SqaureColour = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.XComboBox2.SqaureHoverColour = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.XComboBox2.StartIndex = 0
        Me.XComboBox2.TabIndex = 134
        Me.XComboBox2.ValueMember = "0"
        '
        'XComboBox1
        '
        Me.XComboBox1.ArrowColour = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.XComboBox1.BackColor = System.Drawing.Color.Transparent
        Me.XComboBox1.BaseColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XComboBox1.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XComboBox1.DisplayMember = "0"
        Me.XComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.XComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.XComboBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.XComboBox1.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XComboBox1.FormattingEnabled = True
        Me.XComboBox1.Items.AddRange(New Object() {"BUY", "SELL"})
        Me.XComboBox1.LineColour = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.XComboBox1.Location = New System.Drawing.Point(213, 618)
        Me.XComboBox1.Name = "XComboBox1"
        Me.XComboBox1.Size = New System.Drawing.Size(113, 26)
        Me.XComboBox1.SqaureColour = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.XComboBox1.SqaureHoverColour = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.XComboBox1.StartIndex = 0
        Me.XComboBox1.TabIndex = 133
        Me.XComboBox1.ValueMember = "0"
        '
        'XLabel3
        '
        Me.XLabel3.AutoSize = True
        Me.XLabel3.BackColor = System.Drawing.Color.Transparent
        Me.XLabel3.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XLabel3.FontColour = System.Drawing.Color.White
        Me.XLabel3.ForeColor = System.Drawing.Color.Silver
        Me.XLabel3.Location = New System.Drawing.Point(834, 976)
        Me.XLabel3.Name = "XLabel3"
        Me.XLabel3.Size = New System.Drawing.Size(80, 22)
        Me.XLabel3.TabIndex = 132
        Me.XLabel3.Text = "7D : 0%"
        '
        'XLabel2
        '
        Me.XLabel2.AutoSize = True
        Me.XLabel2.BackColor = System.Drawing.Color.Transparent
        Me.XLabel2.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XLabel2.FontColour = System.Drawing.Color.White
        Me.XLabel2.ForeColor = System.Drawing.Color.Silver
        Me.XLabel2.Location = New System.Drawing.Point(834, 949)
        Me.XLabel2.Name = "XLabel2"
        Me.XLabel2.Size = New System.Drawing.Size(80, 22)
        Me.XLabel2.TabIndex = 131
        Me.XLabel2.Text = "1D : 0%"
        '
        'Chart2
        '
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
        Me.Chart2.Location = New System.Drawing.Point(811, 496)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Series1.IsVisibleInLegend = False
        Series1.Name = "Asset"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
        Me.Chart2.Series.Add(Series1)
        Me.Chart2.Size = New System.Drawing.Size(1097, 218)
        Me.Chart2.TabIndex = 130
        Me.Chart2.Text = "Chart2"
        '
        'CheckBox1
        '
        Me.CheckBox1.BaseColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.CheckBox1.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.CheckBox1.Checked = False
        Me.CheckBox1.CheckedColour = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.CheckBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckBox1.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CheckBox1.Location = New System.Drawing.Point(1784, 995)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(117, 22)
        Me.CheckBox1.TabIndex = 129
        Me.CheckBox1.Text = "Active BOT Trade"
        '
        'Chart1
        '
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
        Me.Chart1.Location = New System.Drawing.Point(820, 720)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series2.Legend = "Legend1"
        Series2.Name = "Asset"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(285, 218)
        Me.Chart1.TabIndex = 127
        Me.Chart1.Text = "Chart1"
        '
        'TextLog
        '
        Me.TextLog.BaseColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TextLog.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.TextLog.Location = New System.Drawing.Point(811, 49)
        Me.TextLog.Name = "TextLog"
        Me.TextLog.Size = New System.Drawing.Size(1097, 441)
        Me.TextLog.TabIndex = 126
        Me.TextLog.TextColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'XButton1
        '
        Me.XButton1.BackColor = System.Drawing.Color.Transparent
        Me.XButton1.BaseColour = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.XButton1.BorderColour = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.XButton1.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XButton1.HoverColour = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.XButton1.Location = New System.Drawing.Point(1784, 949)
        Me.XButton1.Name = "XButton1"
        Me.XButton1.PressedColour = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.XButton1.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.XButton1.Size = New System.Drawing.Size(75, 31)
        Me.XButton1.TabIndex = 112
        Me.XButton1.Text = "Setting"
        '
        'XLabel1
        '
        Me.XLabel1.AutoSize = True
        Me.XLabel1.BackColor = System.Drawing.Color.Transparent
        Me.XLabel1.Font = New System.Drawing.Font("Consolas", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XLabel1.FontColour = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.XLabel1.ForeColor = System.Drawing.Color.Silver
        Me.XLabel1.Location = New System.Drawing.Point(811, 998)
        Me.XLabel1.Name = "XLabel1"
        Me.XLabel1.Size = New System.Drawing.Size(103, 28)
        Me.XLabel1.TabIndex = 90
        Me.XLabel1.Text = "Tot : 0"
        '
        'ListView4
        '
        Me.ListView4.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListView4.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26})
        Me.ListView4.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView4.ForeColor = System.Drawing.Color.Transparent
        Me.ListView4.HideSelection = False
        Me.ListView4.Location = New System.Drawing.Point(12, 747)
        Me.ListView4.Name = "ListView4"
        Me.ListView4.Size = New System.Drawing.Size(793, 284)
        Me.ListView4.TabIndex = 89
        Me.ListView4.UseCompatibleStateImageBehavior = False
        Me.ListView4.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Name"
        Me.ColumnHeader21.Width = 105
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Price"
        Me.ColumnHeader22.Width = 100
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "SIde"
        Me.ColumnHeader23.Width = 59
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Original Quantity"
        Me.ColumnHeader24.Width = 172
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Executed Quantity"
        Me.ColumnHeader25.Width = 169
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "ID"
        Me.ColumnHeader26.Width = 154
        '
        'ListView3
        '
        Me.ListView3.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader27})
        Me.ListView3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView3.ForeColor = System.Drawing.Color.Transparent
        Me.ListView3.HideSelection = False
        Me.ListView3.Location = New System.Drawing.Point(1111, 720)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(797, 218)
        Me.ListView3.TabIndex = 88
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Asset"
        Me.ColumnHeader17.Width = 90
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Balance Total"
        Me.ColumnHeader18.Width = 183
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Balance Free"
        Me.ColumnHeader19.Width = 152
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Orders"
        Me.ColumnHeader20.Width = 164
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Ideal"
        Me.ColumnHeader27.Width = 174
        '
        'ListView2
        '
        Me.ListView2.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListView2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.ForeColor = System.Drawing.Color.Transparent
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(3, 49)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(802, 553)
        Me.ListView2.TabIndex = 47
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
        'BOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1920, 1050)
        Me.Controls.Add(Me.XThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BOT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.XThemeContainer1.ResumeLayout(False)
        Me.XThemeContainer1.PerformLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XThemeContainer1 As XThemeContainer
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ListView3 As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ListView4 As ListView
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents ColumnHeader25 As ColumnHeader
    Friend WithEvents ColumnHeader26 As ColumnHeader
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents XLabel1 As XLabel
    Friend WithEvents XButton1 As XButton
    Friend WithEvents TextLog As XRichTextBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents CheckBox1 As XCheckBox
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents XLabel2 As XLabel
    Friend WithEvents XLabel3 As XLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents XComboBox2 As XComboBox
    Friend WithEvents XComboBox1 As XComboBox
    Friend WithEvents XButton2 As XButton
    Friend WithEvents XLabel6 As XLabel
    Friend WithEvents XLabel5 As XLabel
    Friend WithEvents XNormalTextBox2 As XNormalTextBox
    Friend WithEvents XNormalTextBox1 As XNormalTextBox
    Friend WithEvents XComboBox3 As XComboBox
    Friend WithEvents XLabel4 As XLabel
    Friend WithEvents XButton4 As XButton
    Friend WithEvents XButton3 As XButton
    Friend WithEvents XLabel7 As XLabel
End Class
