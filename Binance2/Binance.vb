Imports Binance.Net
Imports System.Windows.Forms.DataVisualization.Charting
Public Class MARKET
    Public Name As String
    Public Base As Integer
    Public Quote As Integer
    Public MinPrice As Decimal
    Public MinVolume As Decimal
    Public MinNotional As Decimal

    Public Last As Date
    Public Volume As Decimal
    Public Price As Decimal
    Public PriceMin As Decimal
    Public PriceMax As Decimal

    Public Periodo As String
    Public Charts As Chart
End Class

Public Class ASSET
    Public Name As String
    Public Split As String
    Public Balance As Decimal
    Public BalanceFree As Decimal
    Public BalanceIdeal As Decimal
    Public BalanceIdealSMA As Decimal
    Public BalanceRisparmio As Decimal
    Public ToBTC As Decimal
    Public Ideal As Chart
End Class

Public Class API
    Public info As CryptoExchange.Net.Objects.WebCallResult(Of Objects.Spot.MarketData.BinanceExchangeInfo)
    Public client As BinanceClient = New BinanceClient()
    Public stato As Boolean = False
    Public APIkey As String
    Public APISecret As String
End Class

Public Class MyCustomQuote
    Public Property Open As Decimal
    Public Property High As Decimal
    Public Property Low As Decimal
    Public Property Close As Decimal
    Public Property Volume As Decimal
    Public Property MyOtherProperty As Integer
    Public Property CloseDate As DateTime
End Class


Public Class Binance

    Public ind() As String = {"SMAH5", "SMAL5", "EMA5", "EMA10", "EMA20", "EMA30", "EMA50", "EMA100", "EMA200", "SMA5", "SMA10", "SMA20", "SMA30", "SMA50", "SMA100", "SMA200", "MACD", "MACD-EMA", "WMA10", "WMA20", "RSI", "CCI", "W%R"}
    Public BTCtot As Decimal

    Dim api As New API
    Public Shared asset As New List(Of ASSET)
    Public Shared market As New List(Of MARKET)
    Dim priority() As Integer
    Dim topC() As Integer
#Region "START"
    Async Sub LoadAPI()

        api.APIkey = My.Settings.APIKey
        api.APISecret = My.Settings.APISecret
        api.stato = False
        If api.APIkey.Length = 64 And api.APISecret.Length = 64 Then
            api.client.SetApiCredentials(api.APIkey, api.APISecret)
            api.info = Await api.client.Spot.System.GetExchangeInfoAsync()
            Dim accountInfo = Await api.client.General.GetAccountInfoAsync()
            If accountInfo.Error Is Nothing Then
                api.stato = accountInfo.Data.CanTrade
                Log("Account Type : " & accountInfo.Data.AccountType.ToString & " | Can Trade : " & accountInfo.Data.CanTrade &
                    " | Maker Commission : " & accountInfo.Data.MakerCommission / 100 & "% | Taker Commission : " & accountInfo.Data.TakerCommission / 100 & "%")
                LoadVar()
            Else
                LogError("ERROR API : wrong settings")
            End If
        Else
            LogError("ERROR API : You have not configured the APIKey or APISecret")
            APIsetting.Show()
        End If
    End Sub
    Private Sub ResetVar()
        asset.Clear()
        market.Clear()
    End Sub
    Public Sub LoadVar()
        ResetVar()
        App.Timer1.Interval = My.Settings.Ctimer * 1000
        App.Timer2.Interval = My.Settings.UPtimer * 60000
        For x = 0 To My.Settings.Asset.Count - 1
            Dim a As New ASSET
            a.Name = My.Settings.Asset(x)
            a.Split = My.Settings.Split(x)
            a.Ideal = ChartASSET(a.Name)
            asset.Add(a)
        Next
        For x As Integer = 0 To api.info.Data.Symbols.Count - 1
            For y = 0 To asset.Count - 1
                If asset(y).Name = api.info.Data.Symbols(x).BaseAsset Then
                    For z = 0 To asset.Count - 1
                        If asset(z).Name = api.info.Data.Symbols(x).QuoteAsset Then
                            Dim m As New MARKET
                            m.Name = api.info.Data.Symbols(x).Name
                            m.Base = y
                            m.Quote = z
                            m.MinNotional = api.info.Data.Symbols(x).MinNotionalFilter.MinNotional
                            m.MinVolume = api.info.Data.Symbols(x).LotSizeFilter.MinQuantity
                            m.MinPrice = api.info.Data.Symbols(x).PriceFilter.MinPrice
                            m.Periodo = My.Settings.period
                            m.Charts = ChartMARKET(m.Name)
                            market.Add(m)
                        End If
                    Next
                End If
            Next
        Next
        StabilityTest()
        OHLC()
        GetBalance()
        LendingBalance()
        MakeListView()
        UpdateListView()
        App.Timer1.Start()
    End Sub

    Private Function ChartMARKET(name As String) As Chart
        Dim c As New Chart
        c.Series.Add(name)
        c.Series(name).XValueType = ChartValueType.DateTime
        c.Series(name).YValuesPerPoint = 4
        c.Series(name).ChartType = SeriesChartType.Candlestick
        c.Series(name).Sort(PointSortOrder.Ascending, "X")

        c.Series.Add("Volume")
        c.Series("Volume").XValueType = ChartValueType.DateTime
        c.Series("Volume").YValuesPerPoint = 4
        c.Series("Volume").Sort(PointSortOrder.Ascending, "X")
        For i As Integer = 0 To ind.Length - 1
            c.Series.Add(ind(i))
            c.Series(ind(i)).XValueType = ChartValueType.DateTime
            c.Series(ind(i)).Sort(PointSortOrder.Ascending, "X")
        Next
        Return c
    End Function
    Private Function ChartASSET(name As String) As Chart
        Dim c As New Chart
        c.Series.Add(name)
        c.Series(name).XValueType = ChartValueType.DateTime
        c.Series(name).Sort(PointSortOrder.Ascending, "X")
        c.Series.Add("SMA")
        c.Series("SMA").XValueType = ChartValueType.DateTime
        c.Series("SMA").Sort(PointSortOrder.Ascending, "X")
        Return c
    End Function


    Private Sub StabilityTest()
        Dim x As Integer = market.Count
        Dim y As Integer = asset.Count
        If Not ((y * y) - y) / 2 = x Then
            LogError("/!\ WARNING : For correct operation, some assets will cause problems because there is not a market list with all combinations")
        End If
    End Sub
#End Region
#Region "Balance"
    Sub GetBalance()
        If api.stato = True Then
            Try
                Dim info = api.client.General.GetAccountInfo()
                If info.Error Is Nothing Then
                    For y As Integer = 0 To asset.Count - 1
                        For x As Integer = 0 To info.Data.Balances.Count - 1
                            If info.Data.Balances(x).Asset = asset(y).Name Then
                                asset(y).Balance = info.Data.Balances(x).Total
                                asset(y).BalanceFree = info.Data.Balances(x).Free
                                Exit For
                            End If
                        Next
                    Next
                    CalcoloBTC()
                End If
            Catch ex As Exception
                LogError("ERROR Balances : " & ex.Message)
            End Try
        End If
    End Sub
    Sub LendingBalance()
        If api.stato = True Then
            Try
                Dim info = api.client.Lending.GetLendingAccount()
                If info.Error Is Nothing Then
                    For y As Integer = 0 To asset.Count - 1
                        For x As Integer = 0 To info.Data.PositionAmounts.Count - 1
                            If info.Data.PositionAmounts(x).Asset = asset(y).Name Then
                                asset(y).BalanceRisparmio = info.Data.PositionAmounts(x).Amount
                            End If
                        Next
                    Next
                End If
            Catch ex As Exception
                LogError("ERROR Balances : " & ex.Message)
            End Try
        End If
    End Sub
    Public Sub CalcoloBTC()
        If api.stato = True Then
            asset(0).ToBTC = 1 'Valore base 
            For a As Integer = 0 To market.Count - 1
                Dim m As MARKET = market(a)
                If m.Quote = 0 And m.Price > 0 Then
                    asset(m.Base).ToBTC = m.Price
                End If
                If m.Base = 0 And m.Price > 0 Then
                    asset(m.Quote).ToBTC = 1 / m.Price
                End If
            Next
            BTCtot = 0
            For x As Integer = 0 To asset.Count - 1
                BTCtot += (asset(x).Balance + asset(x).BalanceRisparmio) * asset(x).ToBTC
            Next
            App.LabelTot.Text = "Tot : " & Math.Round(BTCtot, 6) & " " & asset(0).Name
        End If
    End Sub
#End Region
#Region "CHARTS"
    Dim offline As Boolean = False
    Public Async Sub OHLC() 'Aggiorna grafici
        For n As Integer = 0 To market.Count - 1
            Dim m As MARKET = market(n)
            Try
                Dim trade_stream As CryptoExchange.Net.Objects.WebCallResult(Of IEnumerable(Of Interfaces.IBinanceKline))
                If m.Last = Nothing Then
                    trade_stream = Await api.client.Spot.Market.GetKlinesAsync(m.Name, Interval(m.Periodo))
                Else
                    trade_stream = Await api.client.Spot.Market.GetKlinesAsync(m.Name, Interval(m.Periodo), startTime:=m.Last)
                    m.Charts.Series(m.Name).Points.RemoveAt(m.Charts.Series(m.Name).Points.Count - 1)
                End If
                If trade_stream.Error Is Nothing And trade_stream.Success Then
                    If offline = True Then
                        offline = False
                        LoadVar()
                        Exit Sub
                    End If
                    If trade_stream.Data.Count > 0 Then
                        For x As Integer = 0 To trade_stream.Data.Count - 1
                            m.Last = trade_stream.Data(x).OpenTime
                            m.Price = trade_stream.Data(x).Close
                            m.PriceMax = trade_stream.Data(x).High
                            m.PriceMin = trade_stream.Data(x).Low
                            m.Volume = trade_stream.Data(x).BaseVolume
                            m.Charts.Series(m.Name).Points.AddXY(trade_stream.Data(x).CloseTime, trade_stream.Data(x).High, trade_stream.Data(x).Low, trade_stream.Data(x).Open, trade_stream.Data(x).Close)
                            m.Charts.Series("Volume").Points.AddXY(trade_stream.Data(x).CloseTime, trade_stream.Data(x).BaseVolume, trade_stream.Data(x).TakerBuyBaseVolume, trade_stream.Data(x).TakerBuyQuoteVolume, trade_stream.Data(x).QuoteVolume)

                    Next
                    End If
                    For i As Integer = 0 To ind.Length - 1
                        m.Charts.Series(ind(i)).Points.Clear()
                    Next
                    ' Y1 = Higt  |  Y2 = Low  |  Y3 = Open  |  Y4 = Colose
                    FormulaEMA(m)
                    FormulaSMA(m)
                    FormulaMACD(m)
                    FormulaWMA(m)
                    FormulaRSI(m)
                    FormulaCCI(m)
                FormulaWILR(m)
            Else
                    offline = True
                End If
            Catch ex As Exception
            LogError("ERROR CHART " & m.Name & " : " & ex.Message)
            m.Last = Nothing
            m.Charts.Series(m.Name).Points.Clear()
            End Try
        Next
    End Sub
    Private Function Interval(ByRef i As String) As Enums.KlineInterval
        Select Case i
            Case "1W"
                Return Enums.KlineInterval.OneWeek
            Case "3D"
                Return Enums.KlineInterval.ThreeDay
            Case "1D"
                Return Enums.KlineInterval.OneDay
            Case "12h"
                Return Enums.KlineInterval.TwelveHour
            Case "8h"
                Return Enums.KlineInterval.EightHour
            Case "6h"
                Return Enums.KlineInterval.SixHour
            Case "4h"
                Return Enums.KlineInterval.FourHour
            Case "2h"
                Return Enums.KlineInterval.TwoHour
            Case "1h"
                Return Enums.KlineInterval.OneHour
            Case "30m"
                Return Enums.KlineInterval.ThirtyMinutes
            Case "15m"
                Return Enums.KlineInterval.FifteenMinutes
            Case "5m"
                Return Enums.KlineInterval.FiveMinutes
            Case "3m"
                Return Enums.KlineInterval.ThreeMinutes
            Case "1m"
                Return Enums.KlineInterval.OneMinute
            Case Else
                Return Enums.KlineInterval.ThreeDay
        End Select
    End Function
    Dim IdealOK As Boolean = False
    Private Sub IdealCharts()
        For n = 0 To asset.Count - 1
            Dim a As ASSET = asset(n)
            a.Ideal.Series(a.Name).Points.AddXY(DateTime.UtcNow.ToUniversalTime, a.BalanceIdeal)
            a.Ideal.Series("SMA").Points.Clear()
            If a.Ideal.Series(a.Name).Points.Count > 1000 Then
                a.Ideal.Series(a.Name).Points.Remove(a.Ideal.Series(a.Name).Points(0))
            ElseIf a.Ideal.Series(a.Name).Points.Count < 50 Then
                For x = 0 To 120
                    a.Ideal.Series(a.Name).Points.AddXY(DateTime.UtcNow.ToUniversalTime, a.BalanceIdeal)
                Next
            End If
            Try
                a.Ideal.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "50", a.Name & ":Y1", "SMA")
                a.BalanceIdealSMA = a.Ideal.Series("SMA").Points(a.Ideal.Series("SMA").Points.Count - 1).YValues(0)
                IdealOK = True
            Catch ex As Exception
                IdealOK = False
            End Try
        Next
    End Sub
    Private Function indicatorB(ByVal m As MARKET, ByVal ind As String, Optional ByRef p As Integer = 0) As Decimal
        Try
            Return m.Charts.Series(ind).Points((m.Charts.Series(ind).Points.Count - (1 + p))).YValues(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Sub FormulaCCI(ByRef m As MARKET)
        Try           'Commodity Channel Index
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.CommodityChannelIndex, "20", m.Name, "CCI")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaRSI(ByRef m As MARKET) 'RSI  =  100  -  100 /  ( 1  +  RS ) 
        Try
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.RelativeStrengthIndex, "14", m.Name & ":Y4", "RSI")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaWMA(ByRef m As MARKET)
        Try
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "20", m.Name & ":Y4", "WMA20")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "10", m.Name & ":Y4", "WMA10")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaWILR(ByRef m As MARKET) '%R = (Highest High - CurrentClose) / (Highest High - Lowest Low) x -100
        Try
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.WilliamsR, "14", m.Name & ":Y1," & m.Name & ":Y2," & m.Name & ":Y4", "W%R")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaMACD(ByRef m As MARKET)
        Try
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverageConvergenceDivergence, "12,26", m.Name & ":Y4", "MACD") '10,26
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "9", "MACD", "MACD-EMA") '9
            '  MACDDIF = MACD - MACD-EMA
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaEMA(ByRef m As MARKET) 'Exponential Moving Average
        Try
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "5", m.Name & ":Y4", "EMA5")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "10", m.Name & ":Y4", "EMA10")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "20", m.Name & ":Y4", "EMA20")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "30", m.Name & ":Y4", "EMA30")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "50", m.Name & ":Y4", "EMA50")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "100", m.Name & ":Y4", "EMA100")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "200", m.Name & ":Y4", "EMA200")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaSMA(ByRef m As MARKET) 'Simple Moving Average
        Try
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "5", m.Name & ":Y4", "SMA5")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "10", m.Name & ":Y4", "SMA10")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "20", m.Name & ":Y4", "SMA20")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "30", m.Name & ":Y4", "SMA30")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "50", m.Name & ":Y4", "SMA50")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "100", m.Name & ":Y4", "SMA100")
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "200", m.Name & ":Y4", "SMA200")

            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "5", m.Name & ":Y1", "SMAH5") 'High
            m.Charts.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "5", m.Name & ":Y2", "SMAL5") 'Low
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "LIST VIEW"
    Private Sub MakeListView()
        Dim p As Boolean = False
        App.ListCharts.Items.Clear()
        App.ListCharts.Columns.Clear()
        App.ListCharts.Columns.Add("Name", 100)
        App.ListCharts.Columns.Add("Price", 100)
        App.ListCharts.Columns.Add("Higth", 100)
        App.ListCharts.Columns.Add("Low", 100)
        App.ListCharts.Columns.Add("Volume", 100)
        For i As Integer = 0 To ind.Length - 1
            App.ListCharts.Columns.Add(ind(i), 100)
        Next
        For x As Integer = 0 To market.Count - 1
            Dim m As MARKET = market(x)
            App.ListCharts.Items.Add(m.Name)
            App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = m.Price
            App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = m.PriceMax
            App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = m.PriceMin
            App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = m.Volume
            For i As Integer = 0 To ind.Length - 1
                If Not Nothing = indicatorB(m, ind(i)) Then
                    App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Math.Round(indicatorB(m, ind(i)), 8)
                Else
                    App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = "nd"
                End If
            Next
            If p = False Then
                p = True
            Else
                App.ListCharts.Items(x).ForeColor = Color.Silver
                p = False
            End If
        Next
        App.ListBalance.Items.Clear()
        App.ListBalance.Columns.Item(4).Text = "To " & My.Settings.Asset(0)
        For x As Integer = 0 To asset.Count - 1
            Dim a As ASSET = asset(x)
            App.ListBalance.Items.Add(a.Name)
            If App.ImageList1.Images.ContainsKey(a.Name & ".png") Then
                App.ListBalance.Items(x).ImageKey = a.Name & ".png"
            End If
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = a.Balance
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = a.BalanceRisparmio
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = a.BalanceFree
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Math.Round((a.Balance + a.BalanceRisparmio) * a.ToBTC, 8)
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = 0
            If p = False Then
                ' Form1.ListBalance.Items(x).BackColor = Color.FromArgb(35, 35, 35)
                App.ListBalance.Items(x).ForeColor = Color.White
                p = True
            Else
                App.ListBalance.Items(x).ForeColor = Color.Silver
                p = False
            End If
        Next
    End Sub
    Public Sub UpdateListView()
        For x As Integer = 0 To market.Count - 1
            Dim m As MARKET = market(x)
            If Not App.ListCharts.Items(x).SubItems(1).Text = m.Price Then
                App.ListCharts.Items(x).SubItems(1).Text = m.Price
                For i As Integer = 0 To ind.Length - 1
                    If Not Nothing = indicatorB(m, ind(i)) Then
                        App.ListCharts.Items(x).SubItems(i + 5).Text = Math.Round(indicatorB(m, ind(i)), 8)
                    Else
                        If Not App.ListCharts.Items(x).SubItems(i + 5).Text = "nd" Then
                            App.ListCharts.Items(x).SubItems(i + 5).Text = "nd"
                        End If
                    End If
                Next
            End If
            If Not App.ListCharts.Items(x).SubItems(2).Text = m.PriceMax Then
                App.ListCharts.Items(x).SubItems(2).Text = m.PriceMax
            End If
            If Not App.ListCharts.Items(x).SubItems(3).Text = m.PriceMin Then
                App.ListCharts.Items(x).SubItems(3).Text = m.PriceMin
            End If
            If Not App.ListCharts.Items(x).SubItems(4).Text = m.Volume Then
                App.ListCharts.Items(x).SubItems(4).Text = m.Volume
            End If
        Next

        For x As Integer = 0 To asset.Count - 1
            Dim a As ASSET = asset(x)
            If Not App.ListBalance.Items(x).SubItems(1).Text = a.Balance Then
                App.ListBalance.Items(x).SubItems(1).Text = a.Balance
            End If
            If Not App.ListBalance.Items(x).SubItems(2).Text = a.BalanceRisparmio Then
                App.ListBalance.Items(x).SubItems(2).Text = a.BalanceRisparmio
            End If
            If Not App.ListBalance.Items(x).SubItems(3).Text = a.BalanceFree Then
                App.ListBalance.Items(x).SubItems(3).Text = a.BalanceFree
            End If
            If Not App.ListBalance.Items(x).SubItems(4).Text = Math.Round((a.Balance + a.BalanceRisparmio) * a.ToBTC, 8) Then
                App.ListBalance.Items(x).SubItems(4).Text = Math.Round((a.Balance + a.BalanceRisparmio) * a.ToBTC, 8)
            End If
            If IdealOK = True Then
                If Not App.ListBalance.Items(x).SubItems(5).Text = Math.Round(a.BalanceIdealSMA, 8) Then
                    App.ListBalance.Items(x).SubItems(5).Text = Math.Round(a.BalanceIdealSMA, 8)
                End If
            End If

        Next
    End Sub
#End Region
#Region "SCRIPT"
    Public Sub ReadingindicatorB(Optional ByRef p As Integer = 0)
        Dim prioTot As Integer = 0
        priority = Nothing
        ReDim priority(asset.Count - 1)
        For n As Integer = 0 To market.Count - 1
            Dim m As MARKET = market(n)
            If indicatorB(m, "CCI", p) > 200 And indicatorB(m, "CCI", p) < indicatorB(m, "CCI", 1 + p) And indicatorB(m, "CCI", p) <> Nothing Then
                priority(m.Quote) += 2
            ElseIf indicatorB(m, "CCI", p) < -200 And indicatorB(m, "CCI", p) > indicatorB(m, "CCI", 1 + p) And Not indicatorB(m, "CCI", p) <> Nothing Then
                priority(m.Base) += 2
            End If
            If indicatorB(m, "RSI", p) > 80 And indicatorB(m, "RSI", p) <> Nothing Then
                priority(m.Quote) += 2
            ElseIf indicatorB(m, "RSI", p) < 20 And indicatorB(m, "RSI", p) <> Nothing Then
                priority(m.Base) += 2
            End If
            If (indicatorB(m, "MACD", p) - indicatorB(m, "MACD-EMA", p)) > 0 And (indicatorB(m, "MACD", p) - indicatorB(m, "MACD-EMA", p)) <> Nothing Then
                priority(m.Base) += 2
            ElseIf (indicatorB(m, "MACD", p) - indicatorB(m, "MACD-EMA", p)) < 0 And (indicatorB(m, "MACD", p) - indicatorB(m, "MACD-EMA", p)) <> Nothing Then
                priority(m.Quote) += 2
            End If
            If indicatorB(m, "W%R", p) > -80 And indicatorB(m, "W%R", p) <> Nothing Then
                priority(m.Base) += 1
            ElseIf indicatorB(m, "W%R", p) < -20 And indicatorB(m, "W%R", p) <> Nothing Then
                priority(m.Quote) += 1
            End If
            Dim ind As String() = {"EMA5", "EMA10", "EMA20", "EMA30", "EMA50", "EMA100", "EMA200", "SMA5", "SMA10", "SMA20", "SMA30", "SMA50", "SMA100", "SMA200", "WMA10", "WMA20"}
            For x = 0 To ind.Length - 1
                If indicatorB(m, ind(x), p) < m.Price And indicatorB(m, ind(x), p) <> Nothing Then
                    priority(m.Base) += 1
                ElseIf indicatorB(m, ind(x)) <> Nothing Then
                    priority(m.Quote) += 1
                End If
            Next
        Next
        For n = 0 To priority.Length - 1
            priority(n) = priority(n) * asset(n).Split
        Next

        PriorityTop()
        If My.Settings.ATO < topC.Length Then
            For n = My.Settings.ATO To topC.Length - 1
                priority(topC(n)) = 0
            Next
        End If

        For n = 0 To priority.Length - 1
            priority(n) = (priority(n) ^ 2)
        Next

        For n As Integer = 0 To asset.Count - 1
            prioTot += priority(n)
        Next
        For n As Integer = 0 To asset.Count - 1
            Dim a As ASSET = asset(n)
            If a.ToBTC > 0 And priority(n) > 0 Then
                a.BalanceIdeal = Math.Round(((BTCtot / prioTot) * priority(n)) / a.ToBTC, 8)
            Else
                a.BalanceIdeal = 0
            End If
        Next
    End Sub
    Private Sub PriorityTop()
        Dim l As Integer = priority.Length - 1
        ReDim topC(l)
        For p As Integer = 0 To l
            If priority(p) > priority(topC(0)) Then
                topC(0) = p
            End If
        Next
        For p As Integer = 1 To l
            If priority(p) < priority(topC(1)) Then
                For t As Integer = 1 To l
                    topC(t) = p
                Next
            End If
        Next
        For t As Integer = 1 To l
            For p As Integer = 0 To l
                If priority(p) <= priority(topC(t - 1)) And priority(p) >= priority(topC(t)) Then
                    Dim ex As Boolean = False
                    For tx As Integer = 0 To l
                        If topC(tx) = p Then
                            ex = True
                        End If
                    Next
                    If ex = False Then
                        topC(t) = p
                    End If
                End If
            Next
        Next
        App.LabelBuy.Text = "BUY : " & asset(topC(0)).Name
        App.LabelSell.Text = "SELL : " & asset(topC(topC.Length - 1)).Name
    End Sub
    Public Sub StartTrade()
        ReadingindicatorB()
        IdealCharts()
        If api.stato = True And IdealOK = True Then
            For n As Integer = 0 To market.Count - 1
                Dim m As MARKET = market(n)
                If indicatorB(m, "SMAL5") > m.Price And asset(m.Quote).BalanceFree + asset(m.Quote).BalanceRisparmio > asset(m.Quote).BalanceIdealSMA And asset(m.Base).BalanceFree + asset(m.Base).BalanceRisparmio < asset(m.Base).BalanceIdealSMA Then
                    MBuy(m, 60)
                ElseIf indicatorB(m, "SMAH5") > m.Price And asset(m.Quote).BalanceIdealSMA < 0.001 And asset(m.Quote).BalanceFree + asset(m.Quote).BalanceRisparmio > asset(m.Quote).BalanceIdealSMA And asset(m.Base).BalanceFree + asset(m.Base).BalanceRisparmio < asset(m.Base).BalanceIdealSMA Then
                    MBuy(m, 330)
                End If
                If indicatorB(m, "SMAH5") < m.Price And asset(m.Base).BalanceFree + asset(m.Base).BalanceRisparmio > asset(m.Base).BalanceIdealSMA And asset(m.Quote).BalanceFree + asset(m.Quote).BalanceRisparmio < asset(m.Quote).BalanceIdealSMA Then
                    MSell(m, 60)
                ElseIf indicatorB(m, "SMAL5") < m.Price And asset(m.Base).BalanceIdealSMA < 0.001 And asset(m.Base).BalanceFree + asset(m.Base).BalanceRisparmio > asset(m.Base).BalanceIdealSMA And asset(m.Quote).BalanceFree + asset(m.Quote).BalanceRisparmio < asset(m.Quote).BalanceIdealSMA Then
                    MSell(m, 330)
                End If
            Next
        End If
    End Sub
#End Region
#Region "Trade"
    Public Sub CancellaOrdini(Optional Symbol As String = Nothing)
        Try
            If Symbol = Nothing Then
                For x = 0 To market.Count - 1
                    api.client.Spot.Order.CancelAllOpenOrders(market(x).Name)
                Next
            Else
                api.client.Spot.Order.CancelAllOpenOrders(Symbol)
            End If
        Catch ex As Exception
            LogError("ERROR Cancel Order : " & ex.Message)
        End Try
    End Sub
    Private Function BuyMed(ByRef m As MARKET) As Decimal
        If indicatorB(m, "SMAL5") > m.Price Then
            Return Mdecimal((m.PriceMin + m.Charts.Series(m.Name).Points((m.Charts.Series(m.Name).Points.Count - 2)).YValues(1) + m.Price) / 3, m.MinPrice)
        Else
            Return Mdecimal((indicatorB(m, "SMAL5") + m.PriceMin + m.Price) / 3, m.MinPrice)
        End If
    End Function
    Private Function SellMed(ByRef m As MARKET) As Decimal
        If indicatorB(m, "SMAH5") < m.Price Then
            Return Mdecimal((m.PriceMax + m.Charts.Series(m.Name).Points(m.Charts.Series(m.Name).Points.Count - 2).YValues(0) + m.Price) / 3, m.MinPrice)
        Else
            Return Mdecimal((indicatorB(m, "SMAH5") + m.PriceMax + m.Price) / 3, m.MinPrice)
        End If
    End Function
    Private Sub MSell(ByVal m As MARKET, Optional ByVal Div As Integer = 1) 'base >to> quote
        For x = 0 To 10000
            Dim Volume As Decimal = Mdecimal((BTCtot / asset(m.Base).ToBTC) / (Div + x), m.MinVolume)
            If Volume > asset(m.Base).BalanceFree And Volume < asset(m.Base).BalanceRisparmio + asset(m.Base).BalanceFree And asset(m.Base).BalanceRisparmio > asset(m.Base).BalanceIdealSMA Then
                LeftQ(asset(m.Base).Name, Math.Round(asset(m.Base).BalanceRisparmio - asset(m.Base).BalanceIdealSMA, 7))
                Exit For
            ElseIf Volume > m.MinNotional / m.Price And asset(m.Quote).BalanceFree + (Volume * m.Price) + asset(m.Quote).BalanceRisparmio <= asset(m.Quote).BalanceIdealSMA And asset(m.Base).BalanceFree + asset(m.Base).BalanceRisparmio - Volume >= asset(m.Base).BalanceIdealSMA And asset(m.Base).BalanceFree > Volume Then
                Try
                    Dim ordine = api.client.Spot.Order.PlaceOrder(m.Name, Enums.OrderSide.Sell, Enums.OrderType.Market, Mdecimal(Volume, m.MinVolume))
                    Log("SELL : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & m.Price & " ID : " & ordine.Data.OrderId)
                    GetBalance()
                    Exit For
                Catch ex As Exception
                    LogError("ERROR SELL : " & m.Name & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                    Exit For
                End Try
            End If
        Next
    End Sub
    Private Sub MBuy(ByVal m As MARKET, Optional ByVal Div As Integer = 1) 'quote >to> base    |  Base/quote
        For x = 0 To 10000
            Dim Volume As Decimal = Mdecimal((BTCtot / asset(m.Base).ToBTC) / (Div + x), m.MinVolume)
            If Volume * m.Price > asset(m.Quote).BalanceFree And Volume * m.Price < asset(m.Quote).BalanceRisparmio + asset(m.Quote).BalanceFree And asset(m.Quote).BalanceRisparmio > asset(m.Quote).BalanceIdealSMA Then
                LeftQ(asset(m.Quote).Name, Math.Round(asset(m.Quote).BalanceRisparmio - asset(m.Quote).BalanceIdealSMA, 7))
                Exit For
            ElseIf Volume > m.MinNotional / m.Price And asset(m.Base).BalanceFree + Volume + asset(m.Base).BalanceRisparmio <= asset(m.Base).BalanceIdealSMA And asset(m.Quote).BalanceFree + asset(m.Quote).BalanceRisparmio - (Volume * m.Price) >= asset(m.Quote).BalanceIdealSMA And asset(m.Quote).BalanceFree > (Volume * m.Price) Then
                Try
                    Dim ordine = api.client.Spot.Order.PlaceOrder(m.Name, Enums.OrderSide.Buy, Enums.OrderType.Market, Mdecimal(Volume, m.MinVolume))
                    Log("BUY : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & m.Price & " ID : " & ordine.Data.OrderId)
                    GetBalance()
                    Exit For
                Catch ex As Exception
                    LogError("ERROR BUY : " & m.Name & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                    Exit For
                End Try
            End If
        Next
    End Sub
    Private Sub LeftQ(ByVal n As String, ByVal volume As Decimal)
        Try
            Dim info = api.client.Lending.GetFlexibleProductPosition(n)
            If info.Error Is Nothing Then
                For x As Integer = 0 To info.Data.Count - 1
                    If info.Data(x).Asset = n And info.Data(x).FreeAmount > volume Then
                        Dim left = api.client.Lending.RedeemFlexibleProduct(info.Data(x).ProductId, volume, Enums.RedeemType.Fast)
                        Log("REDEEM : " & info.Data(x).ProductId & "  Volume : " & volume)
                    End If
                Next
            End If
        Catch ex As Exception
            LogError("ERROR REDEEM : " & n & "  /!\ " & ex.Message)
        End Try
    End Sub
    Private Function Mdecimal(ByVal vol As Decimal, ByVal v As Decimal) As Decimal
        Dim dec As Integer = 0
        Dim i As Decimal = 0.5
        For x As Integer = 0 To 10
            If Not v < 1 Then
                Exit For
            Else
                v = v * 10
                dec += 1
                i = i / 10
            End If
        Next
        Return Math.Round(vol - i, dec)
    End Function
#End Region
#Region "LOG"
    Public Sub Log(ByRef text As String)
        Dim d As String = DateTime.UtcNow.ToUniversalTime & " >  "
        App.Log.SelectionStart = App.Log.TextLength
        App.Log.SelectionLength = 0
        App.Log.SelectionColor = Color.Silver
        App.Log.AppendText(d)
        App.Log.SelectionColor = App.Log.ForeColor
        App.Log.AppendText(text & vbCrLf)
        App.Log.ScrollToCaret()
    End Sub
    Public Sub LogError(ByRef text As String)
        Dim d As String = DateTime.UtcNow.ToUniversalTime & " >  "
        App.Log.SelectionStart = App.Log.TextLength
        App.Log.SelectionLength = 0
        App.Log.SelectionColor = Color.Silver
        App.Log.AppendText(d)
        App.Log.SelectionColor = Color.Red
        App.Log.AppendText(text & vbCrLf)
        App.Log.ScrollToCaret()
    End Sub
#End Region
End Class