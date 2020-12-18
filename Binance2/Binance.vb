Imports Binance.Net
Imports System.Windows.Forms.DataVisualization.Charting
Public Class MARKET
    Public Name As New List(Of String)
    Public Base As New List(Of Integer)
    Public Quote As New List(Of Integer)
    Public MinPrice As New List(Of Decimal)
    Public MinVolume As New List(Of Decimal)
    Public MinNotional As New List(Of Decimal)

    Public Last As New List(Of Date)
    Public Volume As New List(Of Decimal)
    Public Price As New List(Of Decimal)
    Public PriceMin As New List(Of Decimal)
    Public PriceMax As New List(Of Decimal)

    Public EMU As New List(Of Boolean)

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
    Public BILANCIOidealeSMA As New List(Of Decimal)
    Public ToBTC As New List(Of Decimal)
    Public BTCtot As Decimal
    Public Ideal() As Chart
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
    Public market As New MARKET
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
                LoadVar()
                Log("Account Type : " & accountInfo.Data.AccountType & " | Can Trade : " & accountInfo.Data.CanTrade &
                    " | Maker Commission : " & accountInfo.Data.MakerCommission / 100 & "% | Taker Commission : " & accountInfo.Data.TakerCommission / 100 & "%")
            Else
                LogError("ERROR API : wrong settings")
            End If
        Else
            LogError("ERROR API : You have not configured the APIKey or APISecret")
            APIsetting.Show()
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
        asset.BILANCIOidealeSMA.Clear()
        asset.ToBTC.Clear()

        market.Name.Clear()
        market.Base.Clear()
        market.Quote.Clear()
        market.MinPrice.Clear()
        market.Last.Clear()
        market.Volume.Clear()
        market.Price.Clear()
        market.MinNotional.Clear()
        market.PriceMin.Clear()
        market.PriceMax.Clear()
        market.EMU.Clear()

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
                market.MinNotional.Add(api.info.Data.Symbols(x).MinNotionalFilter.MinNotional)
                market.MinVolume.Add(api.info.Data.Symbols(x).LotSizeFilter.MinQuantity)
                market.MinPrice.Add(api.info.Data.Symbols(x).PriceFilter.MinPrice)
                Log("ADD Market : " & api.info.Data.Symbols(x).Name & "  |  Min Trade : " & api.info.Data.Symbols(x).LotSizeFilter.MinQuantity & " " & api.info.Data.Symbols(x).BaseAsset & " |  Min Price : " & api.info.Data.Symbols(x).MinNotionalFilter.MinNotional & " " & api.info.Data.Symbols(x).QuoteAsset)
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
            market.EMU.Add(False)
        Next
        For x = 0 To asset.Name.Count - 1
            asset.Bilancio.Add(Nothing)
            asset.BilancioDisponibile.Add(Nothing)
            asset.BilancioOrdini.Add(Nothing)
            asset.BILANCIOideale.Add(Nothing)
            asset.BILANCIOidealeSMA.Add(Nothing)
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
            market.Charts(n).Series.Add("slp1")
            market.Charts(n).Series("slp1").XValueType = ChartValueType.DateTime
            market.Charts(n).Series("slp1").Sort(PointSortOrder.Ascending, "X")

            market.Charts(n).Series.Add("slp2")
            market.Charts(n).Series("slp2").XValueType = ChartValueType.DateTime
            market.Charts(n).Series("slp2").Sort(PointSortOrder.Ascending, "X")
        Next
        ReDim asset.Ideal(asset.Name.Count - 1)
        For n = 0 To asset.Name.Count - 1
            asset.Ideal(n) = New Chart
            asset.Ideal(n).Series.Add(asset.Name(n))
            asset.Ideal(n).Series(asset.Name(n)).XValueType = ChartValueType.DateTime
            asset.Ideal(n).Series(asset.Name(n)).Sort(PointSortOrder.Ascending, "X")
            asset.Ideal(n).Series.Add("SMA")
            asset.Ideal(n).Series("SMA").XValueType = ChartValueType.DateTime
            asset.Ideal(n).Series("SMA").Sort(PointSortOrder.Ascending, "X")
        Next
    End Sub
    Private Sub StabilityTest()
        Dim x As Integer = market.Name.Count
        Dim y As Integer = asset.Name.Count
        If Not ((y * y) - y) / 2 = x Then
            LogError("/!\ WARNING : For correct operation, some charts will be emulated")
            For b = 0 To asset.Name.Count - 2 'create an emulated chart, if it doesn't exist
                For q = b + 1 To asset.Name.Count - 1
                    Dim c As Boolean = False
                    For a = 0 To market.Name.Count - 1
                        If market.Base(a) = b And market.Quote(a) = q Then
                            c = True
                        End If
                        If market.Base(a) = q And market.Quote(a) = b Then
                            c = True
                        End If
                    Next
                    If c = False Then
                        market.Name.Add(asset.Name(b) & asset.Name(q))
                        market.Base.Add(b)
                        market.Quote.Add(q)
                        market.Last.Add(Nothing)
                        market.Price.Add(Nothing)
                        market.PriceMax.Add(Nothing)
                        market.PriceMin.Add(Nothing)
                        market.Volume.Add(0)
                        market.EMU.Add(True)
                        Log("ADD Market emulated : " & asset.Name(b) & asset.Name(q))
                    End If
                Next
            Next
        End If
    End Sub
#End Region
#Region "Balance"
    Sub VerificaBilancio()
        If api.stato = True Then
            Try
                VerificaPosizioniAperte()
                Dim info = api.client.General.GetAccountInfo()
                If info.Error Is Nothing Then
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
                End If
            Catch ex As Exception
                LogError("ERROR Balances : " & ex.Message)
            End Try
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
    Async Sub VerificaPosizioniAperte()
        Try
            Dim ordini = Await api.client.Spot.Order.GetOpenOrdersAsync()
            App.ListOrder.Items.Clear()
            For n As Integer = 0 To asset.Name.Count - 1
                asset.BilancioOrdini(n) = 0
            Next
            If ordini.Error Is Nothing Then
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
            End If
        Catch ex As Exception
            LogError("ERROR Open Order : " & ex.Message)
        End Try
    End Sub
#End Region
#Region "CHARTS"
    Public Async Sub OHLC() 'Aggiorna grafici
        For n As Integer = 0 To market.Charts.Length - 1
            If market.EMU(n) = False Then
                Try
                    Dim trade_stream As CryptoExchange.Net.Objects.WebCallResult(Of IEnumerable(Of Interfaces.IBinanceKline))
                    If market.Last(n) = Nothing Then
                        trade_stream = Await api.client.Spot.Market.GetKlinesAsync(market.Name(n), Interval(market.Periodo))
                    Else
                        trade_stream = Await api.client.Spot.Market.GetKlinesAsync(market.Name(n), Interval(market.Periodo), startTime:=market.Last(n))
                        market.Charts(n).Series(market.Name(n)).Points.RemoveAt(market.Charts(n).Series(market.Name(n)).Points.Count - 1)
                    End If
                    If trade_stream.Error Is Nothing And trade_stream.Success Then
                        If trade_stream.Data.Count > 0 Then
                            For x As Integer = 0 To trade_stream.Data.Count - 1
                                market.Last(n) = trade_stream.Data(x).OpenTime
                                market.Price(n) = trade_stream.Data(x).Close
                                market.PriceMax(n) = trade_stream.Data(x).High
                                market.PriceMin(n) = trade_stream.Data(x).Low
                                market.Volume(n) = trade_stream.Data(x).BaseVolume
                                market.Charts(n).Series(market.Name(n)).Points.AddXY(trade_stream.Data(x).CloseTime, trade_stream.Data(x).High, trade_stream.Data(x).Low, trade_stream.Data(x).Open, trade_stream.Data(x).Close)
                                market.Charts(n).Series("Volume").Points.AddXY(trade_stream.Data(x).CloseTime, trade_stream.Data(x).BaseVolume, trade_stream.Data(x).TakerBuyBaseVolume, trade_stream.Data(x).TakerBuyQuoteVolume, trade_stream.Data(x).QuoteVolume)
                            Next
                            For i As Integer = 0 To market.ind.Length - 1
                                market.Charts(n).Series(market.ind(i)).Points.Clear()
                            Next
                            ' Y1 = Higt  |  Y2 = Low  |  Y3 = Open  |  Y4 = Colose
                        End If
                    End If
                    FormulaEMA(n)
                    FormulaSMA(n)
                    FormulaMACD(n)
                    FormulaWMA(n)
                    FormulaRSI(n)
                    FormulaCCI(n)
                    FormulaWILR(n)
                Catch ex As Exception
                    LogError("ERROR CHART " & market.Name(n) & " : " & ex.Message)
                    market.Last(n) = Nothing
                    market.Charts(n).Series(market.Name(n)).Points.Clear()
                End Try
            End If
        Next
    End Sub

    Public Sub EmuChart()
        For c = 0 To market.Name.Count - 1
            If market.EMU(c) = True Then
                Dim b As Integer
                Dim q As Integer
                For x As Integer = 0 To market.Name.Count - 1
                    If market.Quote(x) = 0 And market.Base(c) = market.Base(x) Then
                        b = x
                    End If
                    If market.Quote(x) = 0 And market.Quote(c) = market.Base(x) Then
                        q = x
                    End If
                Next
                For x = 0 To market.Charts(b).Series(market.Name(b)).Points.Count - 1
                    If market.Charts(b).Series(market.Name(b)).Points(x).XValue = market.Charts(q).Series(market.Name(q)).Points(x).XValue Then
                        market.Price(c) = Math.Round(market.Charts(b).Series(market.Name(b)).Points(x).YValues(3) / market.Charts(q).Series(market.Name(q)).Points(x).YValues(3), 8)
                        market.PriceMax(c) = Math.Round(market.Charts(b).Series(market.Name(b)).Points(x).YValues(0) / market.Charts(q).Series(market.Name(q)).Points(x).YValues(0), 8)
                        market.PriceMin(c) = Math.Round(market.Charts(b).Series(market.Name(b)).Points(x).YValues(1) / market.Charts(q).Series(market.Name(q)).Points(x).YValues(1), 8)
                        market.Charts(c).Series(market.Name(c)).Points.AddXY(market.Charts(b).Series(market.Name(b)).Points(x).XValue, market.Charts(b).Series(market.Name(b)).Points(x).YValues(0) / market.Charts(q).Series(market.Name(q)).Points(x).YValues(0), market.Charts(b).Series(market.Name(b)).Points(x).YValues(1) / market.Charts(q).Series(market.Name(q)).Points(x).YValues(1), market.Charts(b).Series(market.Name(b)).Points(x).YValues(2) / market.Charts(q).Series(market.Name(q)).Points(x).YValues(2), market.Charts(b).Series(market.Name(b)).Points(x).YValues(3) / market.Charts(q).Series(market.Name(q)).Points(x).YValues(3))
                    End If
                Next
                FormulaEMA(c)
                FormulaSMA(c)
                FormulaMACD(c)
                FormulaWMA(c)
                FormulaRSI(c)
                FormulaCCI(c)
                FormulaWILR(c)
            End If
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
        For n = 0 To asset.Name.Count - 1
            asset.Ideal(n).Series(asset.Name(n)).Points.AddXY(DateTime.UtcNow.ToUniversalTime, asset.BILANCIOideale(n))
            asset.Ideal(n).Series("SMA").Points.Clear()
            If asset.Ideal(n).Series(asset.Name(n)).Points.Count > 200 Then
                asset.Ideal(n).Series(asset.Name(n)).Points.Remove(asset.Ideal(n).Series(asset.Name(n)).Points(0))
            ElseIf asset.Ideal(n).Series(asset.Name(n)).Points.Count < 10 Then
                For x = 0 To 20
                    asset.Ideal(n).Series(asset.Name(n)).Points.AddXY(DateTime.UtcNow.ToUniversalTime, asset.BILANCIOideale(n))
                Next
            End If
            Try
                asset.Ideal(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "10", asset.Name(n) & ":Y1", "SMA")
                asset.BILANCIOidealeSMA(n) = asset.Ideal(n).Series("SMA").Points(asset.Ideal(n).Series("SMA").Points.Count - 1).YValues(0)
                IdealOK = True
            Catch ex As Exception
                IdealOK = False
            End Try
        Next
    End Sub
    Private Function indicator(ByVal n As Integer, ByVal ind As String, Optional ByRef p As Integer = 0) As Decimal
        Try
            Return market.Charts(n).Series(ind).Points((market.Charts(n).Series(ind).Points.Count - (1 + p))).YValues(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Sub FormulaCCI(ByRef n As Integer)
        Try           'Commodity Channel Index
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.CommodityChannelIndex, "20", market.Name(n), "CCI")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaRSI(ByRef n As Integer) 'RSI  =  100  -  100 /  ( 1  +  RS ) 
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.RelativeStrengthIndex, "14", market.Name(n) & ":Y4", "RSI")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaWMA(ByRef n As Integer)
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "20", market.Name(n) & ":Y4", "WMA20")
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "10", market.Name(n) & ":Y4", "WMA10")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaWILR(ByRef n As Integer) '%R = (Highest High - CurrentClose) / (Highest High - Lowest Low) x -100
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.WilliamsR, "14", market.Name(n) & ":Y1," & market.Name(n) & ":Y2," & market.Name(n) & ":Y4", "W%R")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaMACD(ByRef n As Integer)
        Try
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverageConvergenceDivergence, "12,26", market.Name(n) & ":Y4", "MACD") '10,26
            market.Charts(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "9", "MACD", "MACD-EMA") '9
            '  MACDDIF = MACD - MACD-EMA
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FormulaEMA(ByRef n As Integer) 'Exponential Moving Average
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
    Public Sub FormulaSMA(ByRef n As Integer) 'Simple Moving Average
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
        For i As Integer = 0 To market.ind.Length - 1
            App.ListCharts.Columns.Add(market.ind(i), 100)
        Next
        For x As Integer = 0 To market.Name.Count - 1
            If market.EMU(x) = True Then
                App.ListCharts.Items.Add(market.Name(x) & " emu")
            Else
                App.ListCharts.Items.Add(market.Name(x))
            End If
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
            If IdealOK = True Then
                If Not App.ListBalance.Items(x).SubItems(5).Text = Math.Round(asset.BILANCIOidealeSMA(x), 8) Then
                    App.ListBalance.Items(x).SubItems(5).Text = Math.Round(asset.BILANCIOidealeSMA(x), 8)
                End If
            End If
        Next
    End Sub
#End Region
#Region "SCRIPT"
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
            priority(n) = (priority(n) ^ 2) * asset.Split(n)
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
        ReadingIndicator()
        IdealCharts()

        If api.stato = True And IdealOK = True Then
            For n As Integer = 0 To market.Name.Count - 1
                If Not market.EMU(n) = True Then
                    If indicator(n, "SMAL5") > market.Price(n) Then
                        MBuy(n, 6)
                    Else
                        LBuy(n, 6)
                        If market.Base(n) = topC(0) And market.Quote(n) = topC(topC.Length - 1) Then
                            MBuy(n, 20)
                        ElseIf market.Base(n) = topC(1) And market.Quote(n) = topC(topC.Length - 1) Then
                            MBuy(n, 40)
                        End If
                    End If
                    If indicator(n, "SMAH5") < market.Price(n) Then
                        MSell(n, 6)
                    Else
                        LSell(n, 6)
                        If market.Base(n) = topC(topC.Length - 1) And market.Quote(n) = topC(0) Then
                            MSell(n, 20)
                        ElseIf market.Base(n) = topC(topC.Length - 1) And market.Quote(n) = topC(1) Then
                            MSell(n, 40)
                        End If
                    End If
                    End If
            Next
        End If
    End Sub
#End Region
#Region "Trade"
    Public Sub CancellaOrdini(Optional Symbol As String = Nothing)
        Try
            If Symbol = Nothing Then
                For x = 0 To market.Name.Count - 1
                    api.client.Spot.Order.CancelAllOpenOrders(market.Name(x))
                Next
            Else
                api.client.Spot.Order.CancelAllOpenOrders(Symbol)
            End If
        Catch ex As Exception
            LogError("ERROR Cancel Order : " & ex.Message)
        End Try
    End Sub
    Private Function BuyMed(ByRef n As Integer) As Decimal
        If indicator(n, "SMAL5") > market.Price(n) Then
            Return Mdecimal((market.PriceMin(n) + market.Charts(n).Series(market.Name(n)).Points((market.Charts(n).Series(market.Name(n)).Points.Count - 2)).YValues(1) + market.Price(n)) / 3, market.MinPrice(n))
        Else
            Return Mdecimal((indicator(n, "SMAL5") + market.PriceMin(n) + market.Price(n)) / 3, market.MinPrice(n))
        End If
    End Function
    Private Function SellMed(ByRef n As Integer) As Decimal
        If indicator(n, "SMAH5") < market.Price(n) Then
            Return Mdecimal((market.PriceMax(n) + market.Charts(n).Series(market.Name(n)).Points((market.Charts(n).Series(market.Name(n)).Points.Count - 2)).YValues(0) + market.Price(n)) / 3, market.MinPrice(n))
        Else
            Return Mdecimal((indicator(n, "SMAH5") + market.PriceMax(n) + market.Price(n)) / 3, market.MinPrice(n))
        End If
    End Function
    Private Sub LSell(ByVal n As Integer, Optional ByVal Div As Integer = 1)
        For x = 1 To 1000
            Dim Volume As Decimal = Mdecimal((asset.BTCtot * asset.ToBTC(market.Base(n))) / (Div * x), market.MinVolume(n))
            If Volume > market.MinNotional(n) / market.Price(n) And (asset.BilancioDisponibile(market.Quote(n)) + asset.BilancioOrdini(market.Quote(n))) + (Volume * market.Price(n)) <= asset.BILANCIOidealeSMA(market.Quote(n)) And asset.BilancioDisponibile(market.Base(n)) - Volume >= asset.BILANCIOidealeSMA(market.Base(n)) Then
                Try
                    Dim ordine = api.client.Spot.Order.PlaceOrder(market.Name(n), Enums.OrderSide.Sell, Enums.OrderType.Limit, Mdecimal(Volume, market.MinVolume(n)), price:=SellMed(n), timeInForce:=Enums.TimeInForce.GoodTillCancel)
                    Log("SELL Limit : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & ordine.Data.Price & " ID : " & ordine.Data.OrderId)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    LogError("ERROR SELL Limit : " & market.Name(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                    Exit For
                End Try
            ElseIf asset.BilancioDisponibile(market.Base(n)) - Volume >= asset.BILANCIOidealeSMA(market.Base(n)) Then
                Exit For
            End If
        Next
    End Sub
    Private Sub LBuy(ByVal n As Integer, Optional ByVal Div As Integer = 1)
        For x = 1 To 1000
            Dim Volume As Decimal = Mdecimal((asset.BTCtot / asset.ToBTC(market.Base(n))) / (Div * x), market.MinVolume(n))
            If Volume > market.MinNotional(n) / market.Price(n) And (asset.BilancioDisponibile(market.Base(n)) + asset.BilancioOrdini(market.Base(n))) + Volume <= asset.BILANCIOidealeSMA(market.Base(n)) And asset.BilancioDisponibile(market.Quote(n)) - (Volume * market.Price(n)) >= asset.BILANCIOidealeSMA(market.Quote(n)) Then
                Try
                    Dim ordine = api.client.Spot.Order.PlaceOrder(market.Name(n), Enums.OrderSide.Buy, Enums.OrderType.Limit, Mdecimal(Volume, market.MinVolume(n)), price:=BuyMed(n), timeInForce:=Enums.TimeInForce.GoodTillCancel)
                    Log("BUY Limit : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & ordine.Data.Price & " ID : " & ordine.Data.OrderId)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    LogError("ERROR BUY Limit : " & market.Name(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                    Exit For
                End Try
            ElseIf asset.BilancioDisponibile(market.Quote(n)) - (Volume * market.Price(n)) < asset.BILANCIOidealeSMA(market.Quote(n)) Then
                Exit For
            End If
        Next
    End Sub
    Private Sub MSell(ByVal n As Integer, Optional ByVal Div As Integer = 1) 'base >to> quote
        For x = 1 To 1000
            Dim Volume As Decimal = Mdecimal((asset.BTCtot / asset.ToBTC(market.Base(n))) / (Div * x), market.MinVolume(n))
            If Volume > market.MinNotional(n) / market.Price(n) And (asset.BilancioDisponibile(market.Quote(n)) + asset.BilancioOrdini(market.Quote(n))) + (Volume * market.Price(n)) <= asset.BILANCIOidealeSMA(market.Quote(n)) And asset.BilancioDisponibile(market.Base(n)) - Volume >= asset.BILANCIOidealeSMA(market.Base(n)) Then
                Try
                    Dim ordine = api.client.Spot.Order.PlaceOrder(market.Name(n), Enums.OrderSide.Sell, Enums.OrderType.Market, Mdecimal(Volume, market.MinVolume(n)))
                    Log("SELL Market : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & market.Price(n) & " ID : " & ordine.Data.OrderId)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    LogError("ERROR SELL Market : " & market.Name(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                    Exit For
                End Try
            ElseIf asset.BilancioDisponibile(market.Base(n)) - Volume >= asset.BILANCIOidealeSMA(market.Base(n)) Then
                Exit For
            End If
        Next
    End Sub
    Private Sub MBuy(ByVal n As Integer, Optional ByVal Div As Integer = 1) 'quote >to> base    |  Base/quote
        For x = 1 To 1000
            Dim Volume As Decimal = Mdecimal((asset.BTCtot / asset.ToBTC(market.Base(n))) / (Div * x), market.MinVolume(n))
            If Volume > market.MinNotional(n) / market.Price(n) And (asset.BilancioDisponibile(market.Base(n)) + asset.BilancioOrdini(market.Base(n))) + Volume <= asset.BILANCIOidealeSMA(market.Base(n)) And asset.BilancioDisponibile(market.Quote(n)) - (Volume * market.Price(n)) >= asset.BILANCIOidealeSMA(market.Quote(n)) Then
                Try
                    Dim ordine = api.client.Spot.Order.PlaceOrder(market.Name(n), Enums.OrderSide.Buy, Enums.OrderType.Market, Mdecimal(Volume, market.MinVolume(n)))
                    Log("BUY Market : " & ordine.Data.Symbol & " Volume : " & ordine.Data.Quantity & " Price : " & market.Price(n) & " ID : " & ordine.Data.OrderId)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    LogError("ERROR BUY Market : " & market.Name(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message)
                    Exit For
                End Try
            ElseIf asset.BilancioDisponibile(market.Quote(n)) - (Volume * market.Price(n)) < asset.BILANCIOidealeSMA(market.Quote(n)) Then
                Exit For
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