Imports System.Globalization

Public Class App
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-Us")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-Us")
        If NumberFormatInfo.CurrentInfo.NumberDecimalSeparator = "," Then
            NumberFormatInfo.CurrentInfo.NumberDecimalSeparator = "."
        End If
        Timer1.Interval = My.Settings.Ctimer * 1000
        Timer2.Interval = My.Settings.UPtimer * 60000
        Binance.LoadAPI()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Binance.OHLC()
        Binance.CalcoloBTC()
        Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Binance.CancellaOrdini()
        Binance.GetBalance()
        Binance.LendingBalance()
        Binance.StartTrade()
        If StartToolStripMenuItem.Text = "Stop" Then
            Timer2.Start()
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Binance.UpdateListView()
    End Sub

    Private Sub SettigAPIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettigAPIToolStripMenuItem.Click
        APIsetting.Show()
    End Sub

    Private Sub SettingBOTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingBOTToolStripMenuItem.Click
        Setting.Show()
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        If StartToolStripMenuItem.Text = "Start" Then
            StartToolStripMenuItem.Text = "Stop"
            ToolStripStatusLabel1.Text = "Auto Trade : ON"
            ToolStripStatusLabel1.ForeColor = Color.Green
            Timer2.Start()
        Else
            StartToolStripMenuItem.Text = "Start"
            ToolStripStatusLabel1.Text = "Auto Trade : OFF"
            ToolStripStatusLabel1.ForeColor = Color.Salmon
        End If
    End Sub
End Class