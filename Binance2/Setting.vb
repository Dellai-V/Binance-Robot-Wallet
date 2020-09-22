Public Class Setting
    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumericChart.Value = My.Settings.Ctimer
        NumericTrade.Value = My.Settings.UPtimer
        ComboPeriod.SelectedItem = My.Settings.period
        NumericAssetOwn.Value = My.Settings.ATO
        NumericAssetOwn.Maximum = My.Settings.Asset.Count
        For x As Integer = 0 To My.Settings.Asset.Count - 1
            ListView1.Items.Add(My.Settings.Asset(x))
            ListView1.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = My.Settings.Split(x)
        Next
    End Sub
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            TextBoxAsset.Text = ListView1.SelectedItems(0).Text
            Numeric2.Value = ListView1.SelectedItems(0).SubItems(1).Text
        End If
    End Sub
    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        For x As Integer = 2 To ListView1.Items.Count - 1
            If ListView1.Items(x).Selected = True Then
                ListView1.Items(x).Remove()
                Exit For
            End If
        Next
    End Sub
    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        Dim ass As String = TextBoxAsset.Text.ToUpper
        Dim assetTEMP As New List(Of String)
            Dim splitTEMP As New List(Of Integer)

        If Binance.asset.List.Contains(ass) Then
            For x As Integer = 0 To ListView1.Items.Count - 1
                assetTEMP.Add(ListView1.Items(x).Text)
                splitTEMP.Add(ListView1.Items(x).SubItems(1).Text)
            Next
            If assetTEMP.Contains(ass) Then
                ListView1.Items.Clear()
                For x As Integer = 0 To assetTEMP.Count - 1
                    ListView1.Items.Add(assetTEMP(x))
                    If ass = assetTEMP(x) Then
                        ListView1.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Numeric2.Value
                    Else
                        ListView1.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = splitTEMP(x)
                    End If
                Next
            Else
                ListView1.Items.Add(ass)
                ListView1.Items(assetTEMP.Count).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Numeric2.Value
            End If
        End If
        NumericAssetOwn.Maximum = ListView1.Items.Count
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.Ctimer = NumericChart.Value
        My.Settings.UPtimer = NumericTrade.Value
        My.Settings.period = ComboPeriod.SelectedItem
        My.Settings.ATO = NumericAssetOwn.Value
        My.Settings.Asset.Clear()
        My.Settings.Split.Clear()
        For x As Integer = 0 To ListView1.Items.Count - 1
            My.Settings.Asset.Add(ListView1.Items(x).Text)
            My.Settings.Split.Add(ListView1.Items(x).SubItems(1).Text)
        Next
        Binance.LoadVar()
        App.Timer2.Stop()
        App.Timer1.Interval = My.Settings.Ctimer * 1000
        App.Timer2.Interval = My.Settings.UPtimer * 60000
        App.Timer2.Start()
        Me.Close()
    End Sub
End Class