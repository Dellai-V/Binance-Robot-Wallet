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
        Me.ListOrder = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.SettigAPIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingBOTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelTot = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelBuy = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelSell = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Log = New System.Windows.Forms.RichTextBox()
        Me.ListBalance = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListCharts
        '
        Me.ListCharts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListCharts.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListCharts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListCharts.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListCharts.ForeColor = System.Drawing.Color.White
        Me.ListCharts.HideSelection = False
        Me.ListCharts.Location = New System.Drawing.Point(0, 0)
        Me.ListCharts.Name = "ListCharts"
        Me.ListCharts.Size = New System.Drawing.Size(784, 272)
        Me.ListCharts.TabIndex = 2
        Me.ListCharts.UseCompatibleStateImageBehavior = False
        Me.ListCharts.View = System.Windows.Forms.View.Details
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'ListOrder
        '
        Me.ListOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListOrder.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12})
        Me.ListOrder.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListOrder.ForeColor = System.Drawing.Color.White
        Me.ListOrder.HideSelection = False
        Me.ListOrder.Location = New System.Drawing.Point(0, 272)
        Me.ListOrder.Name = "ListOrder"
        Me.ListOrder.Size = New System.Drawing.Size(784, 154)
        Me.ListOrder.TabIndex = 7
        Me.ListOrder.UseCompatibleStateImageBehavior = False
        Me.ListOrder.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Name"
        Me.ColumnHeader7.Width = 70
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Price"
        Me.ColumnHeader8.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Slde"
        Me.ColumnHeader9.Width = 50
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Original Quantity"
        Me.ColumnHeader10.Width = 120
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Executed Quantity"
        Me.ColumnHeader11.Width = 120
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Id"
        Me.ColumnHeader12.Width = 120
        '
        'Timer2
        '
        Me.Timer2.Interval = 600000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton1, Me.LabelTot, Me.LabelBuy, Me.LabelSell})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 739)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettigAPIToolStripMenuItem, Me.SettingBOTToolStripMenuItem})
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
        Me.Log.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Log.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.Log.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Log.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Log.ForeColor = System.Drawing.Color.White
        Me.Log.Location = New System.Drawing.Point(0, 581)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(784, 158)
        Me.Log.TabIndex = 10
        Me.Log.Text = ""
        '
        'ListBalance
        '
        Me.ListBalance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBalance.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ListBalance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBalance.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListBalance.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBalance.ForeColor = System.Drawing.Color.White
        Me.ListBalance.HideSelection = False
        Me.ListBalance.Location = New System.Drawing.Point(0, 432)
        Me.ListBalance.Name = "ListBalance"
        Me.ListBalance.Size = New System.Drawing.Size(784, 149)
        Me.ListBalance.TabIndex = 11
        Me.ListBalance.UseCompatibleStateImageBehavior = False
        Me.ListBalance.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Asset"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Balance Total"
        Me.ColumnHeader2.Width = 170
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Balance Free"
        Me.ColumnHeader3.Width = 170
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Balance Orders"
        Me.ColumnHeader4.Width = 170
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Balance to BTC"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Ideal"
        Me.ColumnHeader6.Width = 100
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.White
        Me.CheckBox1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(639, 741)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(110, 19)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Active Trade"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'App
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 761)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ListBalance)
        Me.Controls.Add(Me.Log)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ListOrder)
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
    Friend WithEvents ListOrder As ListView
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents Timer2 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LabelTot As ToolStripStatusLabel
    Friend WithEvents LabelBuy As ToolStripStatusLabel
    Friend WithEvents LabelSell As ToolStripStatusLabel
    Friend WithEvents Log As RichTextBox
    Friend WithEvents ListBalance As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents SettigAPIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingBOTToolStripMenuItem As ToolStripMenuItem
End Class
