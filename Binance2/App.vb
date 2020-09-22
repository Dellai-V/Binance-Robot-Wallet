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
        Timer2.Start()
        Binance.LoadAPI()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        If Binance.OHLCDone = True Then
            Binance.OHLC()
            Binance.EmuChart()
            Binance.CalcoloBTC()
        End If
        Timer1.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        If CheckBox1.Checked = True Then
            Binance.CancellaOrdini()
            Binance.VerificaBilancio()
            Binance.StartTrade()
        End If
        Timer2.Start()

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
End Class