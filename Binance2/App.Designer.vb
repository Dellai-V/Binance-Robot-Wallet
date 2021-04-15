<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class App
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(App))
        Me.ListCharts = New System.Windows.Forms.ListView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.SettigAPIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingBOTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TradeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelTot = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelBuy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelSell = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Log = New System.Windows.Forms.RichTextBox()
        Me.ListBalance = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListCharts
        '
        Me.ListCharts.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListCharts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListCharts.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListCharts.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListCharts.ForeColor = System.Drawing.Color.White
        Me.ListCharts.HideSelection = False
        Me.ListCharts.LabelWrap = False
        Me.ListCharts.Location = New System.Drawing.Point(0, 0)
        Me.ListCharts.Margin = New System.Windows.Forms.Padding(0)
        Me.ListCharts.MultiSelect = False
        Me.ListCharts.Name = "ListCharts"
        Me.ListCharts.Size = New System.Drawing.Size(782, 287)
        Me.ListCharts.TabIndex = 2
        Me.ListCharts.UseCompatibleStateImageBehavior = False
        Me.ListCharts.View = System.Windows.Forms.View.Details
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'Timer2
        '
        Me.Timer2.Interval = 600000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton1, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.LabelTot, Me.ToolStripStatusLabel3, Me.LabelBuy, Me.LabelSell})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 739)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(782, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettigAPIToolStripMenuItem, Me.SettingBOTToolStripMenuItem, Me.TradeToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Margin = New System.Windows.Forms.Padding(0, 2, 10, 0)
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 20)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'SettigAPIToolStripMenuItem
        '
        Me.SettigAPIToolStripMenuItem.Name = "SettigAPIToolStripMenuItem"
        Me.SettigAPIToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SettigAPIToolStripMenuItem.Text = "Setting API"
        '
        'SettingBOTToolStripMenuItem
        '
        Me.SettingBOTToolStripMenuItem.Name = "SettingBOTToolStripMenuItem"
        Me.SettingBOTToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SettingBOTToolStripMenuItem.Text = "Setting BOT"
        '
        'TradeToolStripMenuItem
        '
        Me.TradeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem})
        Me.TradeToolStripMenuItem.Name = "TradeToolStripMenuItem"
        Me.TradeToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.TradeToolStripMenuItem.Text = "Trade"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Salmon
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(10, 3, 10, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "Auto Trade : OFF"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = "|"
        '
        'LabelTot
        '
        Me.LabelTot.BackColor = System.Drawing.Color.Transparent
        Me.LabelTot.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTot.ForeColor = System.Drawing.Color.Black
        Me.LabelTot.Margin = New System.Windows.Forms.Padding(0, 3, 10, 2)
        Me.LabelTot.Name = "LabelTot"
        Me.LabelTot.Size = New System.Drawing.Size(84, 17)
        Me.LabelTot.Text = "Tot : 0 BTC"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel3.Text = "|"
        '
        'LabelBuy
        '
        Me.LabelBuy.BackColor = System.Drawing.Color.Transparent
        Me.LabelBuy.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBuy.ForeColor = System.Drawing.Color.Green
        Me.LabelBuy.Margin = New System.Windows.Forms.Padding(10, 3, 10, 2)
        Me.LabelBuy.Name = "LabelBuy"
        Me.LabelBuy.Size = New System.Drawing.Size(42, 17)
        Me.LabelBuy.Text = "Buy :"
        '
        'LabelSell
        '
        Me.LabelSell.ActiveLinkColor = System.Drawing.Color.Salmon
        Me.LabelSell.BackColor = System.Drawing.Color.Transparent
        Me.LabelSell.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSell.ForeColor = System.Drawing.Color.Salmon
        Me.LabelSell.Margin = New System.Windows.Forms.Padding(10, 3, 10, 2)
        Me.LabelSell.Name = "LabelSell"
        Me.LabelSell.Size = New System.Drawing.Size(49, 17)
        Me.LabelSell.Text = "Sell :"
        '
        'Log
        '
        Me.Log.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Log.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Log.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Log.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Log.ForeColor = System.Drawing.Color.White
        Me.Log.Location = New System.Drawing.Point(0, 430)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(782, 309)
        Me.Log.TabIndex = 10
        Me.Log.Text = ""
        '
        'ListBalance
        '
        Me.ListBalance.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListBalance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBalance.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader13, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListBalance.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBalance.ForeColor = System.Drawing.Color.White
        Me.ListBalance.HideSelection = False
        Me.ListBalance.LabelWrap = False
        Me.ListBalance.Location = New System.Drawing.Point(0, 287)
        Me.ListBalance.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBalance.MultiSelect = False
        Me.ListBalance.Name = "ListBalance"
        Me.ListBalance.Size = New System.Drawing.Size(782, 140)
        Me.ListBalance.SmallImageList = Me.ImageList1
        Me.ListBalance.TabIndex = 11
        Me.ListBalance.UseCompatibleStateImageBehavior = False
        Me.ListBalance.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Asset"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Balance Total"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Savings"
        Me.ColumnHeader13.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Free"
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "to BTC"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Ideal"
        Me.ColumnHeader6.Width = 100
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ADA.png")
        Me.ImageList1.Images.SetKeyName(1, "ATOM.png")
        Me.ImageList1.Images.SetKeyName(2, "BCH.png")
        Me.ImageList1.Images.SetKeyName(3, "BCHSV.png")
        Me.ImageList1.Images.SetKeyName(4, "BNB.png")
        Me.ImageList1.Images.SetKeyName(5, "BTC.png")
        Me.ImageList1.Images.SetKeyName(6, "DASH.png")
        Me.ImageList1.Images.SetKeyName(7, "ETC.png")
        Me.ImageList1.Images.SetKeyName(8, "ETH.png")
        Me.ImageList1.Images.SetKeyName(9, "IOTA.png")
        Me.ImageList1.Images.SetKeyName(10, "LINK.png")
        Me.ImageList1.Images.SetKeyName(11, "LTC.png")
        Me.ImageList1.Images.SetKeyName(12, "NEO.png")
        Me.ImageList1.Images.SetKeyName(13, "TRX.jpg")
        Me.ImageList1.Images.SetKeyName(14, "USDC.png")
        Me.ImageList1.Images.SetKeyName(15, "USDT.png")
        Me.ImageList1.Images.SetKeyName(16, "VET.png")
        Me.ImageList1.Images.SetKeyName(17, "XLM.png")
        Me.ImageList1.Images.SetKeyName(18, "XMR.png")
        Me.ImageList1.Images.SetKeyName(19, "XRP.png")
        Me.ImageList1.Images.SetKeyName(20, "XTZ.png")
        Me.ImageList1.Images.SetKeyName(21, "ZEC.png")
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        Me.Timer3.Interval = 1000
        '
        'App
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(782, 761)
        Me.Controls.Add(Me.ListBalance)
        Me.Controls.Add(Me.Log)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ListCharts)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "App"
        Me.ShowIcon = False
        Me.Text = "Binance"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListCharts As ListView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LabelBuy As ToolStripStatusLabel
    Friend WithEvents LabelSell As ToolStripStatusLabel
    Friend WithEvents Log As RichTextBox
    Friend WithEvents ListBalance As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents SettigAPIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingBOTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Timer3 As Timer
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents LabelTot As ToolStripStatusLabel
    Friend WithEvents TradeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
End Class
