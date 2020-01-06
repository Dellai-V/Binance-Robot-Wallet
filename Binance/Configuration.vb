Public Class Configuration
    Dim p As Boolean = False
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxKey.Text = My.Settings.APIkey
        TextBoxSecret.Text = My.Settings.APIsecret
        XNumeric1.Value = My.Settings.UPtimer
        '  XComboBox1.SelectedItem = My.Settings.period
        ListView1.Items.Clear()
        If BOT.stato = True Then
            For x As Integer = 0 To BOT.ASSET.Length - 1
                ListView1.Items.Add(BOT.ASSET(x))
                ListView1.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = BOT.ASSETSplit(x)
                If p = False Then
                    ListView1.Items(x).BackColor = Color.FromArgb(35, 35, 35)
                    ListView1.Items(x).ForeColor = Color.White
                    p = True
                Else
                    ListView1.Items(x).BackColor = Color.FromArgb(64, 64, 64)
                    ListView1.Items(x).ForeColor = Color.Silver
                    p = False
                End If
            Next
            Chartinfo()
        End If
    End Sub
    Private Sub XButton1_Click(sender As Object, e As EventArgs) Handles XButton1.Click
        My.Settings.APIkey = TextBoxKey.Text
        My.Settings.APIsecret = TextBoxSecret.Text
        My.Settings.UPtimer = XNumeric1.Value
        ' My.Settings.period = XComboBox1.SelectedItem
        My.Settings.Asset.Clear()
        My.Settings.Split.Clear()
        For x As Integer = 0 To ListView1.Items.Count - 1
            My.Settings.Asset.Add(ListView1.Items(x).Text)
            My.Settings.Split.Add(ListView1.Items(x).SubItems(1).Text)
        Next
        BOT.LoadConfig()
        Me.Close()
    End Sub
    Private Sub XButton2_Click(sender As Object, e As EventArgs) Handles XButton2.Click
        If BOT.stato = True Then
            Dim ass As String = XNormalTextBox1.Text.ToUpper
            Dim assetTEMP As New List(Of String)
            Dim splitTEMP As New List(Of Integer)
            For n As Integer = 0 To BOT.ASSETDisp.Count - 1
                If BOT.ASSETDisp(n) = ass Then
                    For x As Integer = 0 To ListView1.Items.Count - 1
                        assetTEMP.Add(ListView1.Items(x).Text)
                        splitTEMP.Add(ListView1.Items(x).SubItems(1).Text)
                    Next
                    ListView1.Items.Clear()
                    Dim es As Boolean = False
                    For x As Integer = 0 To assetTEMP.Count - 1
                        ListView1.Items.Add(assetTEMP(x))
                        If ass = assetTEMP(x) Then
                            es = True
                            ListView1.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = XNumeric2.Value
                        Else
                            ListView1.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = splitTEMP(x)
                        End If
                        If p = False Then
                            ListView1.Items(x).BackColor = Color.FromArgb(35, 35, 35)
                            ListView1.Items(x).ForeColor = Color.White
                            p = True
                        Else
                            ListView1.Items(x).BackColor = Color.FromArgb(64, 64, 64)
                            ListView1.Items(x).ForeColor = Color.Silver
                            p = False
                        End If
                    Next
                    If es = False Then
                        ListView1.Items.Add(ass)
                        ListView1.Items(assetTEMP.Count).SubItems.Add(New ListViewItem.ListViewSubItem).Text = XNumeric2.Value
                        If p = False Then
                            ListView1.Items(assetTEMP.Count).BackColor = Color.FromArgb(35, 35, 35)
                            ListView1.Items(assetTEMP.Count).ForeColor = Color.White
                            p = True
                        Else
                            ListView1.Items(assetTEMP.Count).BackColor = Color.FromArgb(64, 64, 64)
                            ListView1.Items(assetTEMP.Count).ForeColor = Color.Silver
                            p = False
                        End If
                    End If
                End If
            Next
            Chartinfo()
        End If
    End Sub
    Private Sub XButton3_Click(sender As Object, e As EventArgs) Handles XButton3.Click
        If BOT.stato = True Then
            For x As Integer = 2 To ListView1.Items.Count - 1
                If ListView1.Items(x).Selected = True Then
                    ListView1.Items(x).Remove()
                    Exit For
                End If
            Next
            Chartinfo()
        End If
    End Sub
    Private Sub Chartinfo()
        Dim assetTEMP As New List(Of String)
        Dim splitTEMP As New List(Of Integer)
        For x As Integer = 0 To ListView1.Items.Count - 1
            assetTEMP.Add(ListView1.Items(x).Text)
            splitTEMP.Add(ListView1.Items(x).SubItems(1).Text)
        Next
        Chart1.Series(0).Points.Clear()
        For n As Integer = 0 To assetTEMP.Count - 1
            Chart1.Series(0).Points.AddY(splitTEMP(n))
            Chart1.Series(0).Points(n).LegendText = assetTEMP(n)
        Next
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            XNormalTextBox1.Text = ListView1.SelectedItems(0).Text
            XNumeric2.Value = ListView1.SelectedItems(0).SubItems(1).Text
        End If
    End Sub
    Private Sub XButton5_Click(sender As Object, e As EventArgs) Handles XButton5.Click
        Process.Start("https://github.com/Dellai-V/Binance-Robot-Wallet")
    End Sub
    Private Sub XButton4_Click(sender As Object, e As EventArgs) Handles XButton4.Click
        Process.Start("https://www.binance.com/en/register?ref=EORD9N10")
    End Sub
End Class