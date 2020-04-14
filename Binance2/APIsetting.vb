Public Class APIsetting
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.binance.com/en/register?ref=EORD9N10")
    End Sub

    Private Sub APIsetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.APIKey
        TextBox2.Text = My.Settings.APISecret
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.APIKey = TextBox1.Text
        My.Settings.APISecret = TextBox2.Text
        Binance.LoadAPI()
        Me.Close()
    End Sub
End Class