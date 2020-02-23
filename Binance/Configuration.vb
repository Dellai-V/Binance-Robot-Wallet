Public Class Configuration

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxKey.Text = My.Settings.APIkey
        TextBoxSecret.Text = My.Settings.APIsecret
        Numeric1.Value = My.Settings.UPtimer
        For x As Integer = 0 To My.Settings.period.Count - 1
            If x = 0 Then
                TextBoxPeriod.Text = My.Settings.period(x)
            Else
                TextBoxPeriod.Text = TextBoxPeriod.Text & ", " & My.Settings.period(x)
            End If
        Next
        ListView1.Items.Clear()
        Dim p As Boolean = False
        For x As Integer = 0 To My.Settings.Asset.Count - 1
            ListView1.Items.Add(My.Settings.Asset(x))
            ListView1.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = My.Settings.Split(x)
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
            TextBoxAsset.Text = ListView1.SelectedItems(0).Text
            Numeric2.Value = ListView1.SelectedItems(0).SubItems(1).Text
        End If
    End Sub


    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
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

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        If BOT.stato = True Then
            Dim ass As String = TextBoxAsset.Text.ToUpper
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
                    Dim p As Boolean = False
                    For x As Integer = 0 To assetTEMP.Count - 1
                        ListView1.Items.Add(assetTEMP(x))
                        If ass = assetTEMP(x) Then
                            es = True
                            ListView1.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Numeric2.Value
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
                        ListView1.Items(assetTEMP.Count).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Numeric2.Value
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

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        If TextBoxKey.Text.Length = 64 And TextBoxSecret.Text.Length = 64 Then
            My.Settings.APIkey = TextBoxKey.Text
            My.Settings.APIsecret = TextBoxSecret.Text
            My.Settings.UPtimer = Numeric1.Value
            My.Settings.period.Clear()
            My.Settings.Asset.Clear()
            My.Settings.Split.Clear()
            For x As Integer = 0 To ListView1.Items.Count - 1
                My.Settings.Asset.Add(ListView1.Items(x).Text)
                My.Settings.Split.Add(ListView1.Items(x).SubItems(1).Text)
            Next
            Dim cut() As String = TextBoxPeriod.Text.Split(",")
            For x As Integer = 0 To cut.Length - 1
                My.Settings.period.Add(cut(x).Replace(" ", ""))
            Next
            BOT.LoadConfig()
            Me.Close()
        End If
    End Sub

    Private Sub Account_Click(sender As Object, e As EventArgs) Handles Account.Click
        Process.Start("https://www.binance.com/en/register?ref=EORD9N10")
    End Sub

    Private Sub ButtonGitHub_Click(sender As Object, e As EventArgs) Handles ButtonGitHub.Click
        Process.Start("https://github.com/Dellai-V/Binance-Robot-Wallet")
    End Sub
End Class