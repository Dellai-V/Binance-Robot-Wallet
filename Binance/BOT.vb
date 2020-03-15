Imports System.Globalization
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Linq
Imports Binance.Net
Imports Binance.Net.Objects
Imports System.IO
Public Class BOT
    Dim ChartX() As Chart
    Dim info As CryptoExchange.Net.Objects.WebCallResult(Of BinanceExchangeInfo)
    Dim last As Date()
    Dim price() As Decimal
    Dim priceMin As Decimal()
    Dim priceMax As Decimal()
    Dim BTCtot As Decimal
    Dim BILANCIO As Decimal()
    Dim BILANCIOdisp As Decimal()
    Dim BILANCIOordini As Decimal()
    Dim BILANCIOideale As Decimal()
    Dim ToBTC As Decimal()
    Dim MinPrice As New List(Of Decimal)
    Dim VolumeMin As New List(Of Decimal)
    Public ASSET As String()
    Public ASSETSplit As String()
    Dim SCAMBI As New List(Of String)
    Dim BaseASSET As New List(Of Integer)
    Dim QuoteASSET As New List(Of Integer)
    Public ASSETDisp As New List(Of String)
    Dim client As BinanceClient = New BinanceClient()
    Public stato As Boolean = False
    '#############  Configurazione  #############
    ' set app.confing 
    Dim APIkey As String
    Dim APISecret As String
    Dim Periodo As New List(Of String)
    Dim Timer As Integer = 10 'min
    Dim ind() As String = {"EMA5", "EMA10", "EMA20", "EMA30", "EMA50", "EMA100", "EMA200", "SMA5", "SMA10", "SMA20", "SMA30", "SMA50", "SMA100", "SMA200", "MACD", "MACD-EMA", "WMA", "RSI", "CCI", "W%R"}
    '############################################
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-Us")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-Us")
        If NumberFormatInfo.CurrentInfo.NumberDecimalSeparator = "," Then
            NumberFormatInfo.CurrentInfo.NumberDecimalSeparator = "."
        End If
        LoadConfig()
        If stato = True Then
            LoadChartBTCtot()
        End If
    End Sub
    Public Sub LoadConfig()
        Timer = My.Settings.UPtimer
        APIkey = My.Settings.APIkey
        APISecret = My.Settings.APIsecret
        Timer1.Interval = Timer * 60000
        LoadAPI()
    End Sub
    Private Function Interval(ByRef i As String) As KlineInterval
        Select Case i
            Case "1W"
                Return KlineInterval.OneWeek
            Case "3D"
                Return KlineInterval.ThreeDay
            Case "1D"
                Return KlineInterval.OneDay
            Case "12h"
                Return KlineInterval.TwelveHour
            Case "8h"
                Return KlineInterval.EightHour
            Case "6h"
                Return KlineInterval.SixHour
            Case "4h"
                Return KlineInterval.FourHour
            Case "2h"
                Return KlineInterval.TwoHour
            Case "1h"
                Return KlineInterval.OneHour
            Case "30m"
                Return KlineInterval.ThirtyMinutes
            Case "15m"
                Return KlineInterval.FifteenMinutes
            Case "5m"
                Return KlineInterval.FiveMinutes
            Case "3m"
                Return KlineInterval.ThreeMinutes
            Case "1m"
                Return KlineInterval.OneMinute
            Case Else
                Return KlineInterval.ThreeDay
        End Select
    End Function
    Public Sub LoadAPI()
        If APIkey.Length = 64 And APISecret.Length = 64 Then
            client.SetApiCredentials(APIkey, APISecret)
            info = client.GetExchangeInfo()
            Dim accountInfo = client.GetAccountInfo()
            If accountInfo.Error Is Nothing Then
                LoadVar()
                TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " >  Account Type : " & accountInfo.Data.AccountType & "  |   Asset : " & ASSET.Length & "  |  Exchange : " & SCAMBI.Count & "  |  Indicators : " & ind.Count & "  |  Update Time : " & Timer & " min" & vbCrLf)
                stato = True
            Else
                TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > ERROR API : wrong settings" & vbCrLf)
                stato = False
            End If
        Else
            TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > ERROR API : You have not configured the APIKey or APISecret" & vbCrLf)
            stato = False
        End If
    End Sub
    Private Sub LoadVar()
        ReDim ASSET(My.Settings.Asset.Count - 1)
        My.Settings.Asset.CopyTo(ASSET, 0)
        Dim ass As Integer = ASSET.Length - 1
        ReDim ASSETSplit(ass)
        My.Settings.Split.CopyTo(ASSETSplit, 0)
        SCAMBI.Clear()
        BaseASSET.Clear()
        QuoteASSET.Clear()
        ASSETDisp.Clear()
        MinPrice.Clear()
        VolumeMin.Clear()
        Periodo.Clear()
        ASSETDisp.Add(info.Data.Symbols(0).BaseAsset)
        NumericAssetOwn.Maximum = ASSET.Length
        NumericAssetOwn.Value = NumericAssetOwn.Maximum
        For p As Integer = 0 To My.Settings.period.Count - 1
            For x As Integer = 0 To info.Data.Symbols.Count - 1
                For a As Integer = 0 To ass
                    For b As Integer = 0 To ass
                        If ASSET(a) = info.Data.Symbols(x).BaseAsset And ASSET(b) = info.Data.Symbols(x).QuoteAsset Then
                            SCAMBI.Add(info.Data.Symbols(x).Name)
                            BaseASSET.Add(a)
                            QuoteASSET.Add(b)
                            Periodo.Add(My.Settings.period(p))
                            MinPrice.Add(info.Data.Symbols(x).PriceFilter.MinPrice)
                            VolumeMin.Add(info.Data.Symbols(x).LotSizeFilter.MinQuantity)
                            '  TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > SYMBOL : " & info.Data.Symbols(x).Name & " |  Period : " & My.Settings.period(p) & "  |  Min Trade : " & info.Data.Symbols(x).LotSizeFilter.MinQuantity & " " & ASSET(a) & " |  Min Price : " & info.Data.Symbols(x).PriceFilter.MinPrice & " " & ASSET(b) & vbCrLf)
                            Exit For
                        End If
                    Next
                Next
                For n As Integer = 0 To ASSETDisp.Count
                    If ASSETDisp(n) = info.Data.Symbols(x).BaseAsset Then
                        Exit For
                    ElseIf n = ASSETDisp.Count - 1 Then
                        ASSETDisp.Add(info.Data.Symbols(x).BaseAsset)
                    End If
                Next
                For n As Integer = 0 To ASSETDisp.Count
                    If ASSETDisp(n) = info.Data.Symbols(x).QuoteAsset Then
                        Exit For
                    ElseIf n = ASSETDisp.Count - 1 Then
                        ASSETDisp.Add(info.Data.Symbols(x).QuoteAsset)
                    End If
                Next
            Next
        Next
        Dim sl As Integer = SCAMBI.Count - 1
        ReDim last(sl)
        ReDim price(sl)
        ReDim priceMax(sl)
        ReDim priceMin(sl)
        ReDim BILANCIO(ass)
        ReDim BILANCIOdisp(ass)
        ReDim BILANCIOordini(ass)
        ReDim BILANCIOideale(ass)
        ReDim ToBTC(ass)
        ReDim ChartX(sl)
        makeChart()
        OHLC()
        VerificaBilancio()
        ReadingIndicator()
        MakeListView()
        UpdateListView()
    End Sub
    Private Sub makeChart()
        For n As Integer = 0 To ChartX.Length - 1
            ChartX(n) = New Chart
            ChartX(n).Series.Add("Data")
            ChartX(n).Series("Data").XValueType = ChartValueType.DateTime
            ChartX(n).Series("Data").YValuesPerPoint = 4
            ChartX(n).Series("Data").ChartType = SeriesChartType.Candlestick
            ChartX(n).Series("Data").Sort(PointSortOrder.Ascending, "X")
            For i As Integer = 0 To ind.Length - 1
                ChartX(n).Series.Add(ind(i))
                ChartX(n).Series(ind(i)).XValueType = ChartValueType.DateTime
                ChartX(n).Series(ind(i)).Sort(PointSortOrder.Ascending, "X")
            Next
        Next
    End Sub
    Private Sub OHLC() 'Aggiorna grafici
        For n As Integer = 0 To ChartX.Length - 1
            Try
                If SCAMBI(n) = Nothing Then
                    Exit Sub
                End If
                Dim trade_stream As Threading.Tasks.Task(Of CryptoExchange.Net.Objects.WebCallResult(Of IEnumerable(Of BinanceKline)))
                If last(n) = Nothing Then
                    trade_stream = client.GetKlinesAsync(SCAMBI(n), Interval(Periodo(n)))
                Else
                    trade_stream = client.GetKlinesAsync(SCAMBI(n), Interval(Periodo(n)), startTime:=last(n))
                    ChartX(n).Series("Data").Points.RemoveAt(ChartX(n).Series("Data").Points.Count - 1)
                End If
                If trade_stream.Result.Error Is Nothing Then
                    If trade_stream.Result.Data.Count > 0 Then
                        For x As Integer = 0 To trade_stream.Result.Data.Count - 1
                            last(n) = trade_stream.Result.Data(x).OpenTime
                            price(n) = trade_stream.Result.Data(x).Close
                            priceMax(n) = trade_stream.Result.Data(x).High
                            priceMin(n) = trade_stream.Result.Data(x).Low
                            ChartX(n).Series("Data").Points.AddXY(trade_stream.Result.Data(x).CloseTime, trade_stream.Result.Data(x).High, trade_stream.Result.Data(x).Low, trade_stream.Result.Data(x).Open, trade_stream.Result.Data(x).Close)
                        Next
                        For i As Integer = 0 To ind.Length - 1
                            ChartX(n).Series(ind(i)).Points.Clear()
                        Next
                        ' Y1 = Higt  |  Y2 = Low  |  Y3 = Open  |  Y4 = Colose
                        FormulaEMA(n)
                        FormulaSMA(n)
                        FormulaMACD(n)
                        FormulaWMA(n)
                        ' FormulaHMA(n)
                        FormulaRSI(n)
                        FormulaCCI(n)
                        FormulaWILR(n)
                    End If
                End If
            Catch ex As Exception
                TextLog.AppendText(System.DateTime.UtcNow.ToUniversalTime & " > ERROR CHART " & SCAMBI(n) & " : " & ex.Message & vbCrLf)
                last(n) = Nothing
                ChartX(n).Series("Data").Points.Clear()
            End Try
        Next
    End Sub
    Private Function indicator(ByVal n As Integer, ByVal ind As String, Optional ByRef p As Integer = 0) As Decimal
        Try
            Return ChartX(n).Series(ind).Points((ChartX(n).Series(ind).Points.Count - (1 + p))).YValues(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub FormulaCCI(ByRef n As Integer)
        Try           'Commodity Channel Index
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.CommodityChannelIndex, "20", "Data", "CCI")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaRSI(ByRef n As Integer) 'RSI  =  100  -  100 /  ( 1  +  RS ) 
        Try
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.RelativeStrengthIndex, "14", "Data:Y4", "RSI")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaWMA(ByRef n As Integer)
        Try
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "20", "Data:Y4", "WMA")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaWILR(ByRef n As Integer) '%R = (Highest High - CurrentClose) / (Highest High - Lowest Low) x -100
        Try
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.WilliamsR, "14", "Data:Y1,Data:Y2,Data:Y4", "W%R")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaHMA(ByRef n As Integer)
        Try               'HMA= WMA(2*WMA(n/2) − WMA(n)),sqrt(n))
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, Math.Sqrt(9), "WMA", "HMA")
        Catch ex As Exception
        End Try

    End Sub
    Private Sub FormulaMACD(ByRef n As Integer)
        Try
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverageConvergenceDivergence, "9,26", "Data:Y4", "MACD") '10,26
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "9", "MACD", "MACD-EMA") '9
            '  MACDDIF = MACD - MACD-EMA
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaEMA(ByRef n As Integer) 'Exponential Moving Average
        Try
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "5", "Data:Y4", "EMA5")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "10", "Data:Y4", "EMA10")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "20", "Data:Y4", "EMA20")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "30", "Data:Y4", "EMA30")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "50", "Data:Y4", "EMA50")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "100", "Data:Y4", "EMA100")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, "200", "Data:Y4", "EMA200")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FormulaSMA(ByRef n As Integer) 'Simple Moving Average
        Try
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "5", "Data:Y4", "SMA5")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "10", "Data:Y4", "SMA10")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "20", "Data:Y4", "SMA20")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "30", "Data:Y4", "SMA30")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "50", "Data:Y4", "SMA50")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "100", "Data:Y4", "SMA100")
            ChartX(n).DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, "200", "Data:Y4", "SMA200")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UpdateListView()
        For x As Integer = 0 To SCAMBI.Count - 1
            ListView2.Items(x).SubItems(1).Text = price(x)
            ListView2.Items(x).SubItems(2).Text = priceMax(x)
            ListView2.Items(x).SubItems(3).Text = priceMin(x)
            For i As Integer = 0 To ind.Length - 1
                If Not Nothing = indicator(x, ind(i)) Then
                    ListView2.Items(x).SubItems(i + 4).Text = Math.Round(indicator(x, ind(i)), 8)
                Else
                    ListView2.Items(x).SubItems(i + 4).Text = "nd"
                End If
            Next
            If priority(BaseASSET(x)) > priority(QuoteASSET(x)) Then
                ListView2.Items(x).ForeColor = Color.DarkSeaGreen
            Else
                ListView2.Items(x).ForeColor = Color.Salmon
            End If
        Next
        For x As Integer = 0 To ASSET.Length - 1
            ListView3.Items(x).SubItems(1).Text = BILANCIO(x)
            ListView3.Items(x).SubItems(2).Text = BILANCIOdisp(x)
            ListView3.Items(x).SubItems(3).Text = Math.Round(BILANCIOordini(x), 8)
            ListView3.Items(x).SubItems(4).Text = BILANCIOideale(x)
        Next
        TextLog.ScrollToCaret()
    End Sub
    Private Sub MakeListView()
        Dim p As Boolean = False
        ListView2.Items.Clear()
        ListView2.Columns.Clear()
        ListView2.Columns.Add("Name", 130)
        ListView2.Columns.Add("Price", 130)
        ListView2.Columns.Add("Higth", 130)
        ListView2.Columns.Add("Low", 130)
        For i As Integer = 0 To ind.Length - 1
            ListView2.Columns.Add(ind(i), 100)
        Next
        For x As Integer = 0 To SCAMBI.Count - 1
            ListView2.Items.Add(SCAMBI(x) & " - " & Periodo(x))
            ListView2.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = price(x)
            ListView2.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = priceMax(x)
            ListView2.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = priceMin(x)
            For i As Integer = 0 To ind.Length - 1
                If Not Nothing = indicator(x, ind(i)) Then
                    ListView2.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Math.Round(indicator(x, ind(i)), 8)
                Else
                    ListView2.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = "nd"
                End If
            Next
            If p = False Then
                ListView2.Items(x).BackColor = Color.FromArgb(35, 35, 35)
                p = True
            Else
                ListView2.Items(x).BackColor = Color.FromArgb(64, 64, 64)
                p = False
            End If
        Next
        ListView3.Items.Clear()
        For x As Integer = 0 To ASSET.Length - 1
            ListView3.Items.Add(ASSET(x))
            ListView3.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = BILANCIO(x)
            ListView3.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = BILANCIOdisp(x)
            ListView3.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = Math.Round(BILANCIOordini(x), 8)
            ListView3.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = BILANCIOideale(x)
            If p = False Then
                ListView3.Items(x).BackColor = Color.FromArgb(35, 35, 35)
                ListView3.Items(x).ForeColor = Color.White
                p = True
            Else
                ListView3.Items(x).BackColor = Color.FromArgb(64, 64, 64)
                ListView3.Items(x).ForeColor = Color.Silver
                p = False
            End If
        Next
    End Sub
    Private Sub VerificaBilancio()
        Try
            Dim info = client.GetAccountInfo
            For y As Integer = 0 To ASSET.Length - 1
                For x As Integer = 0 To info.Data.Balances.Count - 1
                    If info.Data.Balances(x).Asset = ASSET(y) Then
                        BILANCIO(y) = info.Data.Balances(x).Total
                        BILANCIOdisp(y) = info.Data.Balances(x).Free
                        ' BILANCIOusato(y) = info.Data.Balances.Item(x).Locked
                        Exit For
                    End If
                Next
            Next
            CalcoloBTC()
            LabelTOT.Text = "Tot : " & Math.Round(BTCtot, 6) & " " & ASSET(0)
            Dim USDtot As Decimal = 0
            For a As Integer = 0 To (SCAMBI.Count / My.Settings.period.Count) - 1
                If BaseASSET(a) = 0 Then
                    If ASSET(QuoteASSET(a)) = "USDT" Or ASSET(QuoteASSET(a)) = "BUSD" Or ASSET(QuoteASSET(a)) = "PAX" Or ASSET(QuoteASSET(a)) = "TUSD" Or ASSET(QuoteASSET(a)) = "USDC" Then
                        USDtot = BTCtot * price(a)
                    End If
                End If
            Next
            LabelUSD.Text = " ~ " & Math.Round(USDtot, 2) & " $"
        Catch ex As Exception
            TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > ERROR Balances : " & ex.Message & vbCrLf)
        End Try
        Chartinfo()
        ChartBTCtot()
        VerificaPosizioniAperte()
    End Sub
    Private Sub CalcoloBTC()
        ToBTC(0) = 1 'Valore base 
        For a As Integer = 0 To SCAMBI.Count - 1
            If QuoteASSET(a) = 0 Then
                ToBTC(BaseASSET(a)) = price(a)
            End If
            If BaseASSET(a) = 0 Then
                ToBTC(QuoteASSET(a)) = 1 / price(a)
            End If
        Next
        BTCtot = 0
        For x As Integer = 0 To ASSET.Length - 1
            BTCtot += BILANCIO(x) * ToBTC(x)
        Next
    End Sub
    Private Sub Chartinfo()
        Chart1.Series(0).Points.Clear()
        For n As Integer = 0 To ASSET.Length - 1
            Chart1.Series(0).Points.AddY(BILANCIO(n) * ToBTC(n))
            Chart1.Series(0).Points(n).LegendText = ASSET(n)
        Next
    End Sub
    Private Sub LoadChartBTCtot()
        Dim path As String = Directory.GetCurrentDirectory() & "\BTCtot"
        If File.Exists(path) Then
            Chart2.Series(0).Points.Clear()
            Dim delLine As Boolean = False
            Dim lines As List(Of String) = New List(Of String)
            Using sr As StreamReader = File.OpenText(path)
                Do While sr.Peek() >= 0
                    Dim cut() As String = sr.ReadLine().Split("@")
                    Chart2.Series(0).Points.AddXY(DateTime.FromOADate(cut(0)), cut(1))
                    If cut(0) < DateTime.UtcNow.ToUniversalTime.AddDays(-30).ToOADate Then
                        delLine = True
                    Else
                        lines.Add(sr.ReadLine())
                    End If
                Loop
            End Using
            If delLine = True Then
                System.IO.File.WriteAllLines(path, lines)
            End If
        End If
    End Sub
    Private Sub ChartBTCtot()
        Chart2.Series(0).Sort(PointSortOrder.Ascending, "X")
        Chart2.Series(0).Points.AddXY(DateTime.UtcNow.ToUniversalTime, BTCtot)
        Dim path As String = Directory.GetCurrentDirectory() & "\BTCtot"
        If Not File.Exists(path) Then
            Using sw As StreamWriter = File.CreateText(path)
                sw.WriteLine(DateTime.UtcNow.ToUniversalTime.ToOADate & "@" & Math.Round(BTCtot, 8))
            End Using
        Else
            Using sw As StreamWriter = File.AppendText(path)
                sw.WriteLine(DateTime.UtcNow.ToUniversalTime.ToOADate & "@" & Math.Round(BTCtot, 8))
            End Using
        End If
        Dim dif As Decimal = BTCtot
        For x As Integer = 0 To Chart2.Series(0).Points.Count - 1
            If Chart2.Series(0).Points(Chart2.Series(0).Points.Count - 1 - x).XValue > DateTime.UtcNow.ToUniversalTime.AddDays(-1).ToOADate Then
                dif = Chart2.Series(0).Points(Chart2.Series(0).Points.Count - 1 - x).YValues(0)
            Else
                Exit For
            End If
        Next
        dif = BTCtot - dif
        If dif > 0 Then
            Label1D.Text = "1D : +" & Math.Round(dif, 4) & "  " & Math.Round((dif / BTCtot) * 100, 2) & "%"
            Label1D.ForeColor = Color.DarkSeaGreen
        Else
            Label1D.Text = "1D : " & Math.Round(dif, 4) & "  " & Math.Round((dif / BTCtot) * 100, 2) & "%"
            Label1D.ForeColor = Color.Salmon
        End If
        For x As Integer = 0 To Chart2.Series(0).Points.Count - 1
            If Chart2.Series(0).Points(Chart2.Series(0).Points.Count - 1 - x).XValue > DateTime.UtcNow.ToUniversalTime.AddDays(-7).ToOADate Then
                dif = Chart2.Series(0).Points(Chart2.Series(0).Points.Count - 1 - x).YValues(0)
            Else
                Exit For
            End If
        Next
        dif = BTCtot - dif
        If dif > 0 Then
            Label7D.Text = "7D : +" & Math.Round(dif, 4) & "  " & Math.Round((dif / BTCtot) * 100, 2) & "%"
            Label7D.ForeColor = Color.DarkSeaGreen
        Else
            Label7D.Text = "7D : " & Math.Round(dif, 4) & "  " & Math.Round((dif / BTCtot) * 100, 2) & "%"
            Label7D.ForeColor = Color.Salmon
        End If
    End Sub
    Private Sub CancellaOrdini(ByRef Symbol As String)
        Dim ordini = client.GetOpenOrders
        For x As Integer = 0 To ordini.Data.Count - 1
            If ordini.Data(x).Symbol = Symbol Then
                client.CancelOrder(ordini.Data(x).Symbol, ordini.Data(x).OrderId)
                TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > Order canceled : " & ordini.Data(x).Symbol & "  ID : " & ordini.Data(x).OrderId & vbCrLf)
            End If
        Next
    End Sub
    Private Sub VerificaPosizioniAperte()
        Try
            Dim ordini = client.GetOpenOrders
            ListView4.Items.Clear()
            For n As Integer = 0 To ASSET.Length - 1
                BILANCIOordini(n) = 0
            Next
            Dim p As Boolean = False
            For x As Integer = 0 To ordini.Data.Count - 1
                ListView4.Items.Add(ordini.Data(x).Symbol)
                ListView4.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = ordini.Data(x).Price
                If ordini.Data(x).Side = 0 Then
                    ListView4.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = "BUY"
                    ListView4.Items(x).ForeColor = Color.DarkSeaGreen
                    For n As Integer = 0 To (SCAMBI.Count / My.Settings.period.Count) - 1
                        If ordini.Data(x).Symbol = SCAMBI(n) Then
                            If BILANCIOdisp(BaseASSET(n)) + BILANCIOordini(BaseASSET(n)) > BILANCIOideale(BaseASSET(n)) and  BILANCIOdisp(QuoteASSET(n)) + BILANCIOordini(QuoteASSET(n)) < BILANCIOideale(QuoteASSET(n)) And CheckBox1.Checked = True Then
                                client.CancelOrder(ordini.Data(x).Symbol, ordini.Data(x).OrderId)
                                TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > Order canceled : " & ordini.Data(x).Symbol & "  ID : " & ordini.Data(x).OrderId & vbCrLf)
                            Else
                                BILANCIOordini(BaseASSET(n)) += ordini.Data(x).OriginalQuantity - ordini.Data(x).ExecutedQuantity
                            End If
                        End If
                    Next
                Else
                    ListView4.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = "SELL"
                    ListView4.Items(x).ForeColor = Color.Salmon
                    For n As Integer = 0 To (SCAMBI.Count / My.Settings.period.Count) - 1
                        If ordini.Data(x).Symbol = SCAMBI(n) Then
                            If BILANCIO(QuoteASSET(n)) + BILANCIOordini(QuoteASSET(n)) > BILANCIOideale(QuoteASSET(n)) and  BILANCIOdisp(BaseASSET(n)) + BILANCIOordini(BaseASSET(n)) < BILANCIOideale(BaseASSET(n))  And CheckBox1.Checked = True Then
                                client.CancelOrder(ordini.Data(x).Symbol, ordini.Data(x).OrderId)
                                TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > Order canceled : " & ordini.Data(x).Symbol & "  ID : " & ordini.Data(x).OrderId & vbCrLf)
                            Else
                                BILANCIOordini(QuoteASSET(n)) += (ordini.Data(x).OriginalQuantity - ordini.Data(x).ExecutedQuantity) * ordini.Data(x).Price
                            End If
                        End If
                    Next
                End If
                ListView4.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = ordini.Data(x).OriginalQuantity
                ListView4.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = ordini.Data(x).ExecutedQuantity
                ListView4.Items(x).SubItems.Add(New ListViewItem.ListViewSubItem).Text = ordini.Data(x).OrderId
                If p = False Then
                    ListView4.Items(x).BackColor = Color.FromArgb(35, 35, 35)
                    p = True
                Else
                    ListView4.Items(x).BackColor = Color.FromArgb(64, 64, 64)
                    p = False
                End If
            Next
        Catch ex As Exception
            TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > ERROR Open Order : " & ex.Message & vbCrLf)
        End Try
    End Sub
    Dim priority() As Integer
    Dim topC() As Integer
    Private Sub ReadingIndicator()
        Dim prioTot As Integer = 0
        priority = Nothing
        ReDim priority(ASSET.Length - 1)
        For n As Integer = 0 To SCAMBI.Count - 1
            If indicator(n, "CCI") > 200 And indicator(n, "CCI") < indicator(n, "CCI", 1) And indicator(n, "CCI") <> Nothing Then
                priority(QuoteASSET(n)) += 2
            ElseIf indicator(n, "CCI") < -200 And indicator(n, "CCI") > indicator(n, "CCI", 1) And Not indicator(n, "CCI") <> Nothing Then
                priority(BaseASSET(n)) += 2
            End If
            If indicator(n, "RSI") > 80 And indicator(n, "RSI") <> Nothing Then
                priority(QuoteASSET(n)) += 2
            ElseIf indicator(n, "RSI") < 20 And indicator(n, "RSI") <> Nothing Then
                priority(BaseASSET(n)) += 2
            End If
            If (indicator(n, "MACD") - indicator(n, "MACD-EMA")) > 0 And (indicator(n, "MACD") - indicator(n, "MACD-EMA")) > (indicator(n, "MACD", 1) - indicator(n, "MACD-EMA", 1)) And (indicator(n, "MACD") - indicator(n, "MACD-EMA")) <> Nothing Then
                priority(BaseASSET(n)) += 2
            ElseIf (indicator(n, "MACD") - indicator(n, "MACD-EMA")) < 0 And (indicator(n, "MACD") - indicator(n, "MACD-EMA")) < (indicator(n, "MACD", 1) - indicator(n, "MACD-EMA", 1)) And (indicator(n, "MACD") - indicator(n, "MACD-EMA")) <> Nothing Then
                priority(QuoteASSET(n)) += 2
            End If
            If indicator(n, "W%R") > -80 And indicator(n, "W%R") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "W%R") < -20 And indicator(n, "W%R") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "EMA5") < price(n) And indicator(n, "EMA5") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "EMA5") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "EMA10") < price(n) And indicator(n, "EMA10") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "EMA10") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "EMA20") < price(n) And indicator(n, "EMA20") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "EMA20") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "EMA30") < price(n) And indicator(n, "EMA30") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "EMA30") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "EMA50") < price(n) And indicator(n, "EMA50") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "EMA50") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "EMA100") < price(n) And indicator(n, "EMA100") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "EMA100") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "EMA200") < price(n) And indicator(n, "EMA200") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "EMA200") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "SMA5") < price(n) And indicator(n, "SMA5") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "SMA5") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "SMA10") < price(n) And indicator(n, "SMA10") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "SMA10") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "SMA20") < price(n) And indicator(n, "SMA20") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "SMA20") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "SMA30") < price(n) And indicator(n, "SMA30") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "SMA30") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "SMA50") < price(n) And indicator(n, "SMA50") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "SMA50") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "SMA100") < price(n) And indicator(n, "SMA100") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "SMA100") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "SMA200") < price(n) And indicator(n, "SMA200") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "SMA200") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
            If indicator(n, "WMA") < price(n) And indicator(n, "WMA") <> Nothing Then
                priority(BaseASSET(n)) += 1
            ElseIf indicator(n, "WMA") <> Nothing Then
                priority(QuoteASSET(n)) += 1
            End If
        Next

        PriorityTop()
        Dim q As Integer = NumericAssetOwn.Value - 1 'numero di cripto 
        For n As Integer = q + 1 To topC.Length - 1
            If Not priority(topC(n)) = priority(topC(q)) Then
                priority(topC(n)) = 0
            End If
        Next
        For n As Integer = 0 To topC.Length - 1
            priority(n) = priority(n) * ASSETSplit(n) * priority(n)
        Next
        For n As Integer = 0 To ASSET.Length - 1
            prioTot += priority(n)
        Next
        For n As Integer = 0 To ASSET.Length - 1
            BILANCIOideale(n) = Math.Round(((BTCtot / prioTot) * priority(n)) / ToBTC(n), 8)
        Next
    End Sub
    Private Sub StartTrade()
        If CheckBox1.Checked = True Then
            For h As Integer = 0 To topC.Length - 2
                For l As Integer = 1 To topC.Length - 1
                    For n As Integer = 0 To (SCAMBI.Count / My.Settings.period.Count) - 1
                        If BaseASSET(n) = topC(h) And QuoteASSET(n) = topC(topC.Length - l) And topC.Length - l > h Then
                            If priority(QuoteASSET(n)) = 0 And BILANCIO(BaseASSET(n)) < (BILANCIOideale(BaseASSET(n)) / 1.1) And QuoteASSET(n) <> topC(h + 1) Then
                                CancellaOrdini(SCAMBI(n))
                                MBuy(n, 5)
                                LBuy(n, 1)
                            Else
                                CancellaOrdini(SCAMBI(n))
                                MBuy(n, 10)
                                LBuy(n, 2)
                            End If
                        End If
                        If QuoteASSET(n) = topC(h) And BaseASSET(n) = topC(topC.Length - l) And topC.Length - l > h Then
                            If priority(BaseASSET(n)) = 0 And BILANCIO(QuoteASSET(n)) < (BILANCIOideale(QuoteASSET(n)) / 1.1) And BaseASSET(n) <> topC(h + 1) Then
                                CancellaOrdini(SCAMBI(n))
                                MSell(n, 5)
                                LSell(n, 1)
                            Else
                                CancellaOrdini(SCAMBI(n))
                                MSell(n, 10)
                                LSell(n, 2)
                            End If
                        End If
                    Next
                Next
            Next
        End If
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
        LabelSELL.Text = "SELL : " & ASSET(topC(topC.Length - 1))
        LabelBUY.Text = "BUY : " & ASSET(topC(0))
    End Sub
    Private Function indMed(ByRef s As Integer, ByRef i As String) As Decimal
        Dim c As Integer = 0
        Dim p As Decimal = 0
        For x As Integer = 0 To SCAMBI.Count - 1
            If SCAMBI(x) = SCAMBI(s) Then
                c += 1
                p += indicator(s, i)
            End If
        Next
        Return Mdecimal(p / c, MinPrice(s))
    End Function
    Private Function BuyMed(ByRef s As Integer) As Decimal
        Dim c As Integer = 0
        Dim p As Decimal = 0
        For x As Integer = 0 To SCAMBI.Count - 1
            If SCAMBI(x) = SCAMBI(s) Then
                c += 1
                p += priceMin(x)
            End If
        Next
        Return Mdecimal(p / c, MinPrice(s))
    End Function
    Private Function SellMed(ByRef s As Integer) As Decimal
        Dim c As Integer = 0
        Dim p As Decimal = 0
        For x As Integer = 0 To SCAMBI.Count - 1
            If SCAMBI(x) = SCAMBI(s) Then
                c += 1
                p += priceMax(x)
            End If
        Next
        Return Mdecimal(p / c, MinPrice(s))
    End Function
    Private Sub LSell(ByVal n As Integer, Optional ByVal Div As Integer = 1)
        Dim Volume As Decimal = Math.Round(BILANCIOdisp(BaseASSET(n)) - BILANCIOideale(BaseASSET(n)), 8)
        For x = Div To 10
            If Volume / x > 0.005 / ToBTC(BaseASSET(n)) And (BILANCIOdisp(QuoteASSET(n)) + BILANCIOordini(QuoteASSET(n))) + ((Volume / x) * SellMed(n)) <= BILANCIOideale(QuoteASSET(n)) Then
                Try
                    Dim ordine = client.PlaceOrder(SCAMBI(n), OrderSide.Sell, OrderType.Limit, Mdecimal((Volume / x), VolumeMin(n)), price:=SellMed(n), timeInForce:=TimeInForce.GoodTillCancel)
                    TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > SELL Limit : " & ordine.Data.Symbol & " Volume : " & ordine.Data.OriginalQuantity & " Price : " & ordine.Data.Price & " ID : " & ordine.Data.OrderId & vbCrLf)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > ERROR SELL : " & SCAMBI(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message & vbCrLf)
                End Try
            ElseIf Volume / x < 0.005 / ToBTC(BaseASSET(n)) Then
                Exit For
            End If
        Next
    End Sub
    Private Sub LBuy(ByVal n As Integer, Optional ByVal Div As Integer = 1)
        Dim Volume As Decimal = Math.Round((BILANCIOdisp(QuoteASSET(n)) - BILANCIOideale(QuoteASSET(n))) / (priceMin(n)), 8)
        For x = Div To 10
            If Volume / x > 0.005 / ToBTC(BaseASSET(n)) And (BILANCIOdisp(BaseASSET(n)) + BILANCIOordini(BaseASSET(n))) + (Volume / x) <= BILANCIOideale(BaseASSET(n)) Then
                Try
                    Dim ordine = client.PlaceOrder(SCAMBI(n), OrderSide.Buy, OrderType.Limit, Mdecimal((Volume / x), VolumeMin(n)), price:=BuyMed(n), timeInForce:=TimeInForce.GoodTillCancel)
                    TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > BUY Limit : " & ordine.Data.Symbol & " Volume : " & ordine.Data.OriginalQuantity & " Price : " & ordine.Data.Price & " ID : " & ordine.Data.OrderId & vbCrLf)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > ERROR BUY : " & SCAMBI(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message & vbCrLf)
                End Try
            ElseIf Volume / x < 0.005 / ToBTC(BaseASSET(n)) Then
                Exit For
            End If
        Next
    End Sub
    Private Sub MSell(ByVal n As Integer, Optional ByVal Div As Integer = 1)
        Dim Volume As Decimal = Math.Round(BILANCIOdisp(BaseASSET(n)) - BILANCIOideale(BaseASSET(n)), 8)
        For x = Div To 10
            If Volume / x > 0.1 / ToBTC(BaseASSET(n)) And (BILANCIOdisp(QuoteASSET(n)) + BILANCIOordini(QuoteASSET(n))) + ((Volume / x) * priceMax(n)) <= BILANCIOideale(QuoteASSET(n)) Then
                Try
                    Dim ordine = client.PlaceOrder(SCAMBI(n), OrderSide.Sell, OrderType.Market, Mdecimal(Volume / x, VolumeMin(n)))
                    TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > SELL Market : " & ordine.Data.Symbol & " Volume : " & ordine.Data.OriginalQuantity & " Price : " & price(n) & " ID : " & ordine.Data.OrderId & vbCrLf)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > ERROR SELL : " & SCAMBI(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message & vbCrLf)
                End Try
            ElseIf Volume / x < 0.005 / ToBTC(BaseASSET(n)) Then
                Exit For
            End If
        Next
    End Sub
    Private Sub MBuy(ByVal n As Integer, Optional ByVal Div As Integer = 1)
        Dim Volume As Decimal = Math.Round((BILANCIOdisp(QuoteASSET(n)) - BILANCIOideale(QuoteASSET(n))) / priceMin(n), 8)
        For x = Div To 10
            If Volume / x > 0.1 / ToBTC(BaseASSET(n)) And (BILANCIOdisp(BaseASSET(n)) + BILANCIOordini(BaseASSET(n))) + (Volume / x) <= BILANCIOideale(BaseASSET(n)) Then
                Try
                    Dim ordine = client.PlaceOrder(SCAMBI(n), OrderSide.Buy, OrderType.Market, Mdecimal(Volume / x, VolumeMin(n)))
                    TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > BUY Market : " & ordine.Data.Symbol & " Volume : " & ordine.Data.OriginalQuantity & " Price : " & price(n) & " ID : " & ordine.Data.OrderId & vbCrLf)
                    VerificaBilancio()
                    Exit For
                Catch ex As Exception
                    TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > ERROR BUY : " & SCAMBI(n) & "  |  Volume : " & Volume & " /!\ " & ex.Message & vbCrLf)
                End Try
            ElseIf Volume / x < 0.005 / ToBTC(BaseASSET(n)) Then
                Exit For
            End If
        Next
    End Sub
    Private Function Mdecimal(ByVal vol As Decimal, ByVal v As Decimal) As Decimal
        Dim dec As Integer = 0
        Dim i As Decimal = 0.5
        For x As Integer = 0 To 8
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
    Private Sub Trade()
        Timer1.Stop()
        If stato = True Then
            OHLC()
            VerificaBilancio()
            ReadingIndicator()
            StartTrade()
            UpdateListView()
        End If
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Trade()
        LabelUpdate.Text = "Next update : " & DateTime.UtcNow.ToUniversalTime.AddMilliseconds(Timer1.Interval)
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If ListView4.SelectedItems.Count = 1 Then
            client.CancelOrder(ListView4.SelectedItems(0).Text, ListView4.SelectedItems(0).SubItems(5).Text)
            TextLog.AppendText(DateTime.UtcNow.ToUniversalTime & " > Order canceled : " & ListView4.SelectedItems(0).Text & "  ID : " & ListView4.SelectedItems(0).SubItems(5).Text & vbCrLf)
            VerificaPosizioniAperte()
        End If
    End Sub
    Private Sub ButtonSetting_Click(sender As Object, e As EventArgs) Handles ButtonSetting.Click
        Configuration.Show()
        CheckBox1.Checked = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox1.ForeColor = Color.LightGreen
        Else
            CheckBox1.ForeColor = Color.Salmon
        End If
    End Sub

    Private Sub NumericAssetOwn_ValueChanged(sender As Object, e As EventArgs) Handles NumericAssetOwn.ValueChanged
        If stato = True Then
            ReadingIndicator()
            UpdateListView()
        End If
    End Sub
End Class
