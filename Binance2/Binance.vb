Imports Binance.Net
Imports System.Windows.Forms.DataVisualization.Charting
Public Class MARKET
    Public Name As New List(Of String)
    Public Base As New List(Of Integer)
    Public Quote As New List(Of Integer)
    Public MinPrice As New List(Of Decimal)
    Public MinVolume As New List(Of Decimal)
    Public MaxVolume As New List(Of Decimal)

    Public Last As New List(Of Date)
    Public Volume As New List(Of Decimal)
    Public Price As New List(Of Decimal)
    Public PriceMin As New List(Of Decimal)
    Public PriceMax As New List(Of Decimal)

    Public Periodo As String
    Public Charts() As Chart
    Public ind() As String = {"SMAH5", "SMAL5", "EMA5", "EMA10", "EMA20", "EMA30", "EMA50", "EMA100", "EMA200", "SMA5", "SMA10", "SMA20", "SMA30", "SMA50", "SMA100", "SMA200", "MACD", "MACD-EMA", "WMA10", "WMA20", "RSI", "CCI", "W%R"}
End Class
Public Class ASSET
    Public Name As New List(Of String)
    Public Split As New List(Of String)
    Public List As New List(Of String)
    Public Bilancio As New List(Of Decimal)
    Public BilancioDisponibile As New List(Of Decimal)
    Public BilancioOrdini As New List(Of Decimal)
    Public BILANCIOideale As New List(Of Decimal)
    Public ToBTC As New List(Of Decimal)
    Public BTCtot As Decimal
End Class

Public Class API
    Public info As CryptoExchange.Net.Objects.WebCallResult(Of Objects.Spot.MarketData.BinanceExchangeInfo)
    Public client As BinanceClient = New BinanceClient()
    Public stato As Boolean = False
    Public APIkey As String
    Public APISecret As String
End Class


Public Class Binance
    Dim api As New API
    Public asset As New ASSET
    Dim market As New MARKET
    Async Sub LoadAPI()
        api.APIkey = My.Settings.APIKey
        api.APISecret = My.Settings.APISecret
        api.stato = False
        If api.APIkey.Length = 64 And api.APISecret.Length = 64 Then
            api.client.SetApiCredentials(api.APIkey, api.APISecret)
            api.info = Await api.client.GetExchangeInfoAsync()
            Dim accountInfo = Await api.client.GetAccountInfoAsync()
            If accountInfo.Error Is Nothing Then
                api.stato = accountInfo.Data.CanTrade
                LoadVar()
                Log("Account Type : " & accountInfo.Data.AccountType & " | Can Trade : " & accountInfo.Data.CanTrade &
                    " | Maker Commission : " & accountInfo.Data.MakerCommission / 100 & "% | Taker Commission : " & accountInfo.Data.TakerCommission / 100 & "%")
            Else
                LogError("ERROR API : wrong settings")
            End If
        Else
            LogError("ERROR API : You have not configured the APIKey or APISecret")
        End If
    End Sub
    Private Sub ResetVar()
        asset.Name.Clear()
        asset.Split.Clear()
        asset.List.Clear()
        asset.Bilancio.Clear()
        asset.BilancioDisponibile.Clear()
        asset.BilancioOrdini.Clear()
        asset.BILANCIOideale.Clear()
        asset.ToBTC.Clear()

        market.Name.Clear()
        market.Base.Clear()
        market.Quote.Clear()
        asset.List.Clear()
        market.MinPrice.Clear()
        market.Last.Clear()
        market.Volume.Clear()
        market.Price.Clear()
        market.MaxVolume.Clear()
        market.PriceMin.Clear()
        market.PriceMax.Clear()

    End Sub
    Public Sub LoadVar()
        ResetVar()
        App.Timer1.Interval = My.Settings.Ctimer * 1000
        App.Timer2.Interval = My.Settings.UPtimer * 60000
        For x = 0 To My.Settings.Asset.Count - 1
            asset.Name.Add(My.Settings.Asset(x))
        Next
        For x = 0 To My.Settings.Split.Count - 1
            asset.Split.Add(My.Settings.Split(x))
        Next
        For x As Integer = 0 To api.info.Data.Symbols.Count - 1
            If asset.Name.Contains(api.info.Data.Symbols(x).BaseAsset) And asset.Name.Contains(api.info.Data.Symbols(x).QuoteAsset) Then
                market.Name.Add(api.info.Data.Symbols(x).Name)
                For y = 0 To asset.Name.Count - 1
                    If asset.Name(y) = api.info.Data.Symbols(x).BaseAsset Then
                        market.Base.Add(y)
                    End If
                Next
                For y = 0 To asset.Name.Count - 1
                    If asset.Name(y) = api.info.Data.Symbols(x).QuoteAsset Then
                        market.Quote.Add(y)
                    End If
                Next
                market.MinPrice.Add(api.info.Data.Symbols(x).PriceFilter.MinPrice)
                market.MinVolume.Add(api.info.Data.Symbols(x).LotSizeFilter.MinQuantity)
                market.MaxVolume.Add(api.info.Data.Symbols(x).LotSizeFilter.MaxQuantity)
                Log("ADD Market : " & api.info.Data.Symbols(x).Name & "  |  Min Trade : " & api.info.Data.Symbols(x).LotSizeFilter.MinQuantity & " " & api.info.Data.Symbols(x).BaseAsset & " |  Min Price : " & api.info.Data.Symbols(x).PriceFilter.MinPrice & " " & api.info.Data.Symbols(x).BaseAsset)
            End If
            If Not asset.List.Contains(api.info.Data.Symbols(x).BaseAsset) Then
                asset.List.Add(api.info.Data.Symbols(x).BaseAsset)
            End If
            If Not asset.List.Contains(api.info.Data.Symbols(x).QuoteAsset) Then
                asset.List.Add(api.info.Data.Symbols(x).QuoteAsset)
            End If
        Next
        For x = 0 To market.Name.Count - 1
            market.Last.Add(Nothing)
            market.Price.Add(Nothing)
            market.Volume.Add(Nothing)
            market.PriceMax.Add(Nothing)
            market.PriceMin.Add(Nothing)
        Next
        For x = 0 To asset.Name.Count - 1
            asset.Bilancio.Add(Nothing)
            asset.BilancioDisponibile.Add(Nothing)
            asset.BilancioOrdini.Add(Nothing)
            asset.BILANCIOideale.Add(Nothing)
            asset.ToBTC.Add(Nothing)
        Next

        StabilityTest()
        makeChart()
        OHLC()
        VerificaBilancio()
        MakeListView()
        UpdateListView()

        App.Timer1.Start()

    End Sub

    Private Sub StabilityTest()
        Dim x As Integer = market.Name.Count
        Dim y As Integer = asset.Name.Count
        If Not ((y * y) - y) / 2 = x Then
            LogError("/!\ WARNING : The current configuration of the assets makes the BOT UNSTABLE")
        End If
    End Sub
    Private Sub makeChart()
        market.Periodo = My.Settings.period
        ReDim market.Charts(market.Name.Count - 1)
        For n As Integer = 0 To market.Charts.Length - 1
            market.Charts(n) = New Chart
            market.Charts(n).Series.Add(market.Name(n))
            market.Charts(n).Series(market.Name(n)).XValueType = ChartValueType.DateTime
            market.Charts(n).Series(market.Name(n)).YValuesPerPoint = 4
            market.Charts(n).Series(market.Name(n)).ChartType = SeriesChartType.Candlestick
            market.Charts(n).Series(market.Name(n)).Sort(PointSortOrder.Ascending, "X")

            market.Charts(n).Series.Add("Volume")
            market.Charts(n).Series("Volume").XValueType = ChartValueType.DateTime
            market.Charts(n).Series("Volume").YValuesPerPoint = 4
            market.Charts(n).Series("Volume").Sort(PointSortOrder.Ascending, "X")
            For i As Integer = 0 To market.ind.Length - 1
                market.Charts(n).Series.Add(market.ind(i))
                market.Charts(n).Series(market.ind(i)).XValueType = ChartValueType.DateTime
                market.Charts(n).Series(market.ind(i)).Sort(PointSortOrder.Ascending, "X")
            Next
        Next
    End Sub

    Async Sub VerificaBilancio()
        If api.stato = True Then
            Try
                Dim info = Await api.client.GetAccountInfoAsync
                For y As Integer = 0 To asset.Name.Count - 1
                    For x As Integer = 0 To info.Data.Balances.Count - 1
                        If info.Data.Balances(x).Asset = asset.Name(y) Then
                            asset.Bilancio(y) = info.Data.Balances(x).Total
                            asset.BilancioDisponibile(y) = info.Data.Balances(x).Free
                            '   asset.BilancioOrdini(y) = info.Data.Balances(x).Locked
                            Exit For
                        End If
                    Next
                Next
                CalcoloBTC()
            Catch ex As Exception
                LogError("ERROR Balances : " & ex.Message)
            End Try
            VerificaPosizioniAperte()
        End If
    End Sub

    Public Sub CalcoloBTC()
        If api.stato = True Then
            asset.ToBTC(0) = 1 'Valore base 
            For a As Integer = 0 To market.Name.Count - 1
                If market.Quote(a) = 0 And market.Price(a) > 0 Then

                    asset.ToBTC(market.Base(a)) = market.Price(a)
                End If
                If market.Base(a) = 0 And market.Price(a) > 0 Then
                    asset.ToBTC(market.Quote(a)) = 1 / market.Price(a)
                End If
            Next
            asset.BTCtot = 0
            For x As Integer = 0 To asset.Name.Count - 1
                asset.BTCtot += asset.Bilancio(x) * asset.ToBTC(x)
            Next
            App.LabelTot.Text = "Tot : " & Math.Round(asset.BTCtot, 6) & " " & asset.Name(0)
        End If
    End Sub
    Private Sub VerificaPosizioniAperte()
        Try
            Dim ordini = api.client.GetOpenOrders
            App.ListOrder.Items.Clear()
            For n As Integer = 0 To asset.Name.Count - 1
                asset.BilancioOrdini(n) = 0
            Next
            Dim p As Boolean = False
            For x As Integer = 0 To ordini.Data.Count - 1
                App.ListOrder.Items.Add(ordini.Data(x).Symbol)
                App.ListOrder.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = ordini.Data(x).Price
                If ordini.Data(x).Side = 0 Then
                    App.ListOrder.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = "BUY"
                    App.ListOrder.Items(x).ForeColor = Color.DarkSeaGreen
                    For n = 0 To market.Name.Count - 1
                        If ordini.Data(x).Symbol = market.Name(n) Then
                            asset.BilancioOrdini(market.Base(n)) += ordini.Data(x).Quantity - ordini.Data(x).QuantityFilled
                        End If
                    Next
                Else
                    App.ListOrder.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = "SELL"
                    App.ListOrder.Items(x).ForeColor = Color.Salmon
                    For n = 0 To market.Name.Count - 1
                        If ordini.Data(x).Symbol = market.Name(n) Then
                            asset.BilancioOrdini(market.Quote(n)) += (ordini.Data(x).Quantity - ordini.Data(x).QuantityFilled) * ordini.Data(x).Price
                        End If
                    Next
                End If
                App.ListOrder.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = ordini.Data(x).Quantity
                App.ListOrder.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = ordini.Data(x).QuantityFilled
                App.ListOrder.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = ordini.Data(x).OrderId
            Next
        Catch ex As Exception
            LogError("ERROR Open Order : " & ex.Message)
        End Try
    End Sub

    ' CHARTS
    Public OHLCDone As Boolean = False
    Public Async Sub OHLC() 'Aggiorna grafici
        OHLCDone = False
        For n As Integer = 0 To market.Charts.Length - 1
            Try
                Dim trade_stream As CryptoExchange.Net.Objects.WebCallResult(Of IEnumerable(Of Objects.Spot.MarketData.BinanceKline))
                If market.Last(n) = Nothing Then
                    trade_stream = Await api.client.GetKlinesAsync(market.Name(n), Interval(market.Periodo))
                Else
                    trade_stream = Await api.client.GetKlinesAsync(market.Name(n), Interval(market.Periodo), startTime:=market.Last(n))
                    market.Charts(n).Series(market.Name(n)).Points.RemoveAt(market.Charts(n).Series(market.Name(n)).Points.Count - 1)
                End If
                If trade_stream.Error Is Nothing And trade_stream.Success Then
                    If trade_stream.Data.Count > 0 Then
                        For x As Integer = 0 To trade_stream.Data.Count - 1
                            market.Last(n) = trade_stream.Data(x).OpenTime
                            market.Price(n) = trade_stream.Data(x).Close
                            market.PriceMax(n) = trade_stream.Data(x).High
                            market.PriceMin(n) = trade_stream.Data(x).Low
                            market.Volume(n) = trade_stream.Data(x).Volume
                            market.Charts(n).Series(market.Name(n)).Points.AddXY(trade_stream.Data(x).CloseTime, trade_stream.Data(x).High, trade_stream.Data(x).Low, trade_stream.Data(x).Open, trade_stream.Data(x).Close)
                            market.Charts(n).Series("Volume").Points.AddXY(trade_stream.Data(x).CloseTime, trade_stream.Data(x).Volume, trade_stream.Data(x).TakerBuyBaseAssetVolume, trade_stream.Data(x).TakerBuyQuoteAssetVolume, trade_stream.Data(x).QuoteAssetVolume)
                        Next
                        For i As Integer = 0 To market.ind.Length - 1
                            market.Charts(n).Series(market.ind(i)).Points.Clear()
                        Next
                        ' Y1 = Higt  |  Y2 = Low  |  Y3 = Open  |  Y4 = Colose
                        FormulaEMA(n)
                        FormulaSMA(n)
                        FormulaMACD(n)
                        FormulaWMA(n)
                        FormulaRSI(n)
                        FormulaCCI(n)
                        FormulaWILR(n)
                    End If
                End If
            Catch ex As Exception
                LogError("ERROR CHART " & market.Name(n) & " : " & ex.Message)
                market.Last(n) = Nothing
                market.Charts(n).Series(market.Name(n)).Points.Clear()
            End Try
        Next
        OHLCDone = True
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
    Private Function indicator(ByVal n As Integer, ByVal ind As String, Optional ByRef p As Integer = 0) As Decimal
        Try
            Return market.Charts(n).Series(ind).Points((market.Charts(n).Series(ind).Points.Count - (1 + p))).YValues(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub FormulaCCI(ByRef n As Integer)
        Try           'Commodity Channel Index
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.CommodityChannelIndex, "20", market.Name(n), "CCI")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaRSI(ByRef n As Integer) 'RSI  =  100  -  100 /  ( 1  +  RS ) 
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.RelativeStrengthIndex, "14", market.Name(n) & ":Y4", "RSI")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaWMA(ByRef n As Integer)
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "20", market.Name(n) & ":Y4", "WMA20")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "10", market.Name(n) & ":Y4", "WMA10")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaWILR(ByRef n As Integer) '%R = (Highest High - CurrentClose) / (Highest High - Lowest Low) x -100
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.WilliamsR, "14", market.Name(n) & ":Y1," & market.Name(n) & ":Y2," & market.Name(n) & ":Y4", "W%R")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaMACD(ByRef n As Integer)
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverageConvergenceDivergence, "12,26", market.Name(n) & ":Y4", "MACD") '10,26
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "9", "MACD", "MACD-EMA") '9
            '  MACDDIF = MACD - MACD-EMA
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaEMA(ByRef n As Integer) 'Exponential Moving Average
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "5", market.Name(n) & ":Y4", "EMA5")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "10", market.Name(n) & ":Y4", "EMA10")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "20", market.Name(n) & ":Y4", "EMA20")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "30", market.Name(n) & ":Y4", "EMA30")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "50", market.Name(n) & ":Y4", "EMA50")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "100", market.Name(n) & ":Y4", "EMA100")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "200", market.Name(n) & ":Y4", "EMA200")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaSMA(ByRef n As Integer) 'Simple Moving Average
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "5", market.Name(n) & ":Y4", "SMA5")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "10", market.Name(n) & ":Y4", "SMA10")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "20", market.Name(n) & ":Y4", "SMA20")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "30", market.Name(n) & ":Y4", "SMA30")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "50", market.Name(n) & ":Y4", "SMA50")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "100", market.Name(n) & ":Y4", "SMA100")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "200", market.Name(n) & ":Y4", "SMA200")

            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "5", market.Name(n) & ":Y1", "SMAH5") 'High
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "5", market.Name(n) & ":Y2", "SMAL5") 'Low
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MakeListView()
        Dim p As Boolean = False
        App.ListCharts.Items.Clear()
        App.ListCharts.Columns.Clear()
        App.ListCharts.Columns.Add("Name", 100)
        App.ListCharts.Columns.Add("Price", 100)
        App.ListCharts.Columns.Add("Higth", 100)
        App.ListCharts.Columns.Add("Low", 100)
        App.ListCharts.Columns.Add("Volume", 100)
        For i As Integer = 0 To market.ind.Length - 1
            App.ListCharts.Columns.Add(market.ind(i), 100)
        Next
        For x As Integer = 0 To market.Name.Count - 1
            App.ListCharts.Items.Add(market.Name(x))
            App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = market.Price(x)
            App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = market.PriceMax(x)
            App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = market.PriceMin(x)
            App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = market.Volume(x)
            For i As Integer = 0 To market.ind.Length - 1
                If Not Nothing = indicator(x, market.ind(i)) Then
                    App.ListCharts.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Math.Round(indicator(x, market.ind(i)), 8)
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
        App.ListBalance.Columns.Item(4).Text = "Balance To " & My.Settings.Asset(0)
        For x As Integer = 0 To asset.Name.Count - 1
            App.ListBalance.Items.Add(asset.Name(x))
            If App.ImageList1.Images.ContainsKey(asset.Name(x) & ".png") Then
                App.ListBalance.Items(x).ImageKey = asset.Name(x) & ".png"
            End If
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = asset.Bilancio(x)
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = asset.BilancioDisponibile(x)
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = asset.BilancioOrdini(x)
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Math.Round(asset.Bilancio(x) * asset.ToBTC(x), 8)
            App.ListBalance.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Math.Round(asset.BILANCIOideale(x), 8)
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
        For x As Integer = 0 To market.Name.Count - 1
            If Not App.ListCharts.Items(x).SubItems(1).Text = market.Price(x) Then
                App.ListCharts.Items(x).SubItems(1).Text = market.Price(x)
                For i As Integer = 0 To market.ind.Length - 1
                    If Not Nothing = indicator(x, market.ind(i)) Then
                        App.ListCharts.Items(x).SubItems(i + 5).Text = Math.Round(indicator(x, market.ind(i)), 8)
                    Else
                        If Not App.ListCharts.Items(x).SubItems(i + 5).Text = "nd" Then
                            App.ListCharts.Items(x).SubItems(i + 5).Text = "nd"
                        End If
                    End If
                Next
            End If
            If Not App.ListCharts.Items(x).SubItems(2).Text = market.PriceMax(x) Then
                App.ListCharts.Items(x).SubItems(2).Text = market.PriceMax(x)
            End If
            If Not App.ListCharts.Items(x).SubItems(3).Text = market.PriceMin(x) Then
                App.ListCharts.Items(x).SubItems(3).Text = market.PriceMin(x)
            End If
            If Not App.ListCharts.Items(x).SubItems(4).Text = market.Volume(x) Then
                App.ListCharts.Items(x).SubItems(4).Text = market.Volume(x)
            End If
        Next

        For x As Integer = 0 To asset.Name.Count - 1
            If Not App.ListBalance.Items(x).SubItems(1).Text = asset.Bilancio(x) Then
                App.ListBalance.Items(x).SubItems(1).Text = asset.Bilancio(x)
            End If
            If Not App.ListBalance.Items(x).SubItems(2).Text = asset.BilancioDisponibile(x) Then
                App.ListBalance.Items(x).SubItems(2).Text = asset.BilancioDisponibile(x)
            End If
            If Not App.ListBalance.Items(x).SubItems(3).Text = Math.Round(asset.BilancioOrdini(x), 8) Then
                App.ListBalance.Items(x).SubItems(3).Text = Math.Round(asset.BilancioOrdini(x), 8)
            End If
            If Not App.ListBalance.Items(x).SubItems(4).Text = Math.Round(asset.Bilancio(x) * asset.ToBTC(x), 8) Then
                App.ListBalance.Items(x).SubItems(4).Text = Math.Round(asset.Bilancio(x) * asset.ToBTC(x), 8)
            End If
            If Not App.ListBalance.Items(x).SubItems(5).Text = Math.Round(asset.BILANCIOideale(x), 8) Then
                App.ListBalance.Items(x).SubItems(5).Text = Math.Round(asset.BILANCIOideale(x), 8)
            End If
        Next
    End Sub
    Dim priority() As Integer
    Dim topC() As Integer
    Public Sub ReadingIndicator()
        Dim prioTot As Integer = 0
        priority = Nothing
        ReDim priority(asset.Name.Count - 1)
        For n As Integer = 0 To market.Name.Count - 1
            If indicator(n, "CCI") > 200 And indicator(n, "CCI") < indicator(n, "CCI", 1) And indicator(n, "CCI") <> Nothing Then
                priority(market.Quote(n)) += 2
            ElseIf indicator(n, "CCI") < -200 And indicator(n, "CCI") > indicator(n, "CCI", 1) And Not indicator(n, "CCI") <> Nothing Then
                priority(market.Base(n)) += 2
            End If
            If indicator(n, "RSI") > 80 And indicator(n, "RSI") <> Nothing Then
                priority(market.Quote(n)) += 2
            ElseIf indicator(n, "RSI") < 20 And indicator(n, "RSI") <> Nothing Then
                priority(market.Base(n)) += 2
            End If
            If (indicator(n, "MACD") - indicator(n, "MACD-EMA")) > 0 And (indicator(n, "MACD") - indicator(n, "MACD-EMA")) <> Nothing Then
                priority(market.Base(n)) += 2
            ElseIf (indicator(n, "MACD") - indicator(n, "MACD-EMA")) < 0 And (indicator(n, "MACD") - indicator(n, "MACD-EMA")) <> Nothing Then
                priority(market.Quote(n)) += 2
            End If
            If indicator(n, "W%R") > -80 And indicator(n, "W%R") <> Nothing Then
                priority(market.Base(n)) += 1
            ElseIf indicator(n, "W%R") < -20 And indicator(n, "W%R") <> Nothing Then
                priority(market.Quote(n)) += 1
            End If
            Dim ind As String() = {"EMA5", "EMA10", "EMA20", "EMA30", "EMA50", "EMA100", "EMA200", "SMA5", "SMA10", "SMA20", "SMA30", "SMA50", "SMA100", "SMA200", "WMA10", "WMA20"}
            For x = 0 To ind.Length - 1
                If indicator(n, ind(x)) < market.Price(n) And indicator(n, ind(x)) <> Nothing Then
                    priority(market.Base(n)) += 1
                ElseIf indicator(n, ind(x)) <> Nothing Then
                    priority(market.Quote(n)) += 1
                End If
            Next
        Next
        PriorityTop()
        If My.Settings.ATO < topC.Length Then
            For n = My.Settings.ATO To topC.Length - 1
                priority(topC(n)) = 0
            Next
        End If
        For n = 0 To priority.Length - 1
            priority(n) = priority(n) ^ 2 * asset.Split(n)
        Next


        For n As Integer = 0 To asset.Name.Count - 1
            prioTot += priority(n)
        Next
        For n As Integer = 0 To asset.Name.Count - 1
            If asset.ToBTC(n) > 0 And priority(n) > 0 Then
                asset.BILANCIOideale(n) = Math.Round(((asset.BTCtot / prioTot) * priority(n)) / asset.ToBTC(n), 8)
            Else
                asset.BILANCIOideale(n) = 0
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
        App.LabelBuy.Text = "BUY : " & asset.Name(topC(0))
        App.LabelSell.Text = "SELL : " & asset.Name(topC(topC.Length - 1))
    End Sub
    Public Sub StartTrade()
        If api.stato = True Then
            For h As Integer = 0 To topC.Length - 2
                For l As Integer = 1 To topC.Length - 1
                    For n As Integer = 0 To market.Name.Count - 1
                        If market.Base(n) = topC(h) And market.Quote(n) = topC(topC.Length - l) And topC.Length - l > h And indicator(n, "SMAL5") > market.Price(n) Then
                            If priority(market.Quote(n)) = 0 And asset.Bilancio(market.Base(n)) < (asset.BILANCIOideale(market.Base(n)) / 1.1) Then
                                CancellaOrdini(market.Name(n))
                                ' MBuy(n, 5)
                                LBuy(n, 1)
                            Else
                                'CancellaOrdini(market.Name(n))
                                MBuy(n, 10)
                                'LBuy(n, 2)
                            End If
                        End If
                        If market.Quote(n) = topC(h) And market.Base(n) = topC(topC.Length - l) And topC.Length - l > h And indicator(n, "SMAL5") < market.Price(n) Then
                            If priority(market.Base(n)) = 0 And asset.Bilancio(market.Quote(n)) < (asset.BILANCIOideale(market.Quote(n)) / 1.1) Then
                                CancellaOrdini(market.Name(n))
                                ' MSell(n, 5)
                                LSell(n, 1)
                            Else
                                'CancellaOrdini(market.Name(n))
                                MSell(n, 10)
                                'LSell(n, 2)
                            End If
                        End If
                    Next
                Next
            Next
        End If
    End Sub
    Private Sub CancellaOrdini(ByRef Symbol As String)
        Dim ordini = api.client.GetOpenOrders
        For x As Integer = 0 To ordini.Data.Count - 1
            If ordini.Data(x).Symbol = Symbol Then
                api.client.CancelOrder(ordini.Data(x).Symbol, ordini.Data(x).OrderId)
                Log("Order canceled : " & ordini.Data(x).Symbol & "  ID : " & ordini.Data(x).OrderId)
            End If
        Next
    End Sub
    Private Function BuyMed(ByRef n As Integer) As Decimal
        If indicator(n, "SMAL5") > market.Price(n) Then
            Return market.PriceMin(n)
        Else
            Return indicator(n, "SMAL5")
        End If
    End Function
    Private Function SellMed(ByRef n As Integer) As Decimal
        If indicator(n, "SMAH5") < market.Price(n) Then
            Return market.PriceMax(n)
        Else
            Return indicator(n, "SMAH5")
        End If
    End Function
    Private Sub LSell(ByVal n As Integer, Optional ByVal Div As Integer = 1)
        For x = Div To 100
            Dim Volume As Decimal = Mdecimal((asset.BilancioOrdini(market.Base(n)) + asset.BilancioDisponibile(market.Base(n)) - asset.BILANCIOideale(market.Base(n))) / x, market.MinVolume(n))
            If Volume > 0.05 / asset.ToBTC(market.Base(n)) And (asset.BilancioDisponibile(market.Quote(n)) + asset.BilancioOrdini(market.Quote(n))) + (Volume * market.Price(n)) <= asset.BILANCIOideale(market.Quote(n)) Then
                Try
                    Dim ordine = api.client.PlaceOrder(market.Name(n), Enums.OrderSide.Sell, Enums.OrderType.Limit, Volume, price:=SellMed(n), timeInForce:=Enums.TimeInForce.GoodTillCancel)
                    Log("SELL Limit : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & ordine.Data.Price & " ID : " & ordine.Data.OrderId)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    LogError(" ERROR SELL Limit : " & market.Name(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                End Try
            End If
        Next
    End Sub
    Private Sub LBuy(ByVal n As Integer, Optional ByVal Div As Integer = 1)
        For x = Div To 100
            Dim Volume As Decimal = Mdecimal((asset.BILANCIOideale(market.Base(n)) - asset.BilancioDisponibile(market.Base(n)) - asset.BilancioOrdini(market.Base(n))) / x, market.MinVolume(n))
            If Volume > 0.05 / asset.ToBTC(market.Base(n)) And (asset.BilancioDisponibile(market.Quote(n)) + asset.BilancioOrdini(market.Quote(n))) - (Volume * market.Price(n)) >= asset.BILANCIOideale(market.Quote(n)) Then
                Try
                    Dim ordine = api.client.PlaceOrder(market.Name(n), Enums.OrderSide.Buy, Enums.OrderType.Limit, Volume, price:=BuyMed(n), timeInForce:=Enums.TimeInForce.GoodTillCancel)
                    Log("BUY Limit : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & ordine.Data.Price & " ID : " & ordine.Data.OrderId)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    LogError("ERROR BUY : " & market.Name(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                End Try
            End If
        Next
    End Sub
    Private Sub MSell(ByVal n As Integer, Optional ByVal Div As Integer = 1) 'base >to> quote
        For x = Div To 100
            Dim Volume As Decimal = Mdecimal((asset.BilancioOrdini(market.Base(n)) + asset.BilancioDisponibile(market.Base(n)) - asset.BILANCIOideale(market.Base(n))) / x, market.MinVolume(n))
            If Volume > 0.05 / asset.ToBTC(market.Base(n)) And (asset.BilancioDisponibile(market.Quote(n)) + asset.BilancioOrdini(market.Quote(n))) + (Volume * market.Price(n)) <= asset.BILANCIOideale(market.Quote(n)) Then
                Try
                    Dim ordine = api.client.PlaceOrder(market.Name(n), Enums.OrderSide.Sell, Enums.OrderType.Market, Volume, market.MinVolume(n))
                    Log("SELL Market : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & market.Price(n) & " ID : " & ordine.Data.OrderId)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    LogError("ERROR SELL Market : " & market.Name(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                End Try
            End If
        Next
    End Sub
    Private Sub MBuy(ByVal n As Integer, Optional ByVal Div As Integer = 1) 'quote >to> base     Base/quote
        For x = Div To 100
            Dim Volume As Decimal = Mdecimal((asset.BILANCIOideale(market.Base(n)) - asset.BilancioDisponibile(market.Base(n)) - asset.BilancioOrdini(market.Base(n))) / x, market.MinVolume(n))
            If Volume > 0.05 / asset.ToBTC(market.Base(n)) And (asset.BilancioDisponibile(market.Quote(n)) + asset.BilancioOrdini(market.Quote(n))) - (Volume * market.Price(n)) >= asset.BILANCIOideale(market.Quote(n)) Then
                Try
                    Dim ordine = api.client.PlaceOrder(market.Name(n), Enums.OrderSide.Buy, Enums.OrderType.Market, Volume)
                    Log("BUY Market : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & market.Price(n) & " ID : " & ordine.Data.OrderId)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    LogError("ERROR BUY : " & market.Name(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                End Try
            Else
            End If
        Next
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

End Class