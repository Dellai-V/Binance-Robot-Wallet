# Binance Robot Wallet

<a href="https://github.com/Dellai-V/Binance-Robot-Wallet">Source</a>

<a href="https://www.binance.com/en/register?ref=EORD9N10">Binance</a>

This software performs automatic cryptocurrency transactions using Binance exchange.
Before using the bot it is advisable to understand how the code works.
You should be aware that this is a tool that could make you lose money.
This code is for educational purposes only, and is totally free.

---------------
# INSTRUCTIONS

  <img src="https://github.com/Dellai-V/Binance-Robot-Wallet/blob/master/Img/Bot.PNG" alt="Bot"/>
  
  - "Setting" button (*1) will open the configuration window.
  - The "Active Bot Trade" checkbox (*2), if checked, activates the bot's automatic transactions.
  > ! DO NOT ACTIVATE IF YOU DO NOT UNDERSTAND HOW THE BOT WORKS !
  - List of markets (*3).
  - List of open orders (*4).
  - Balance (*5).
  >  Ideal : balance to which the bot will tend if the bot is activated, this value changes according to the market trend.
  - Event log (*6).
      
# CONFIGURATION 

  <img src="https://github.com/Dellai-V/Binance-Robot-Wallet/blob/master/Img/Setting%20API.PNG" alt="SettingAPI"/>
    
- Create a new account on Binance.com if you don't have it.
- Create a new API > https://www.binance.com/en/usercenter/settings/api-management
> Use API restrictions: Read Only, Enable Trading.

- Copy the API Key (*1) and the API secret (*2) in the bot configurations.
  
  <img src="https://github.com/Dellai-V/Binance-Robot-Wallet/blob/master/Img/Setting.PNG" alt="Setting"/>

- Update Time Charts in seconds : the time for updating the charts.
> [Min = 1 ; Max = 120]

- Update Time Trade in minutes : trade timer.
> [Min = 1 ; Max = 120]

- Charts Period : corresponds to the period of the graph, you can add multiple periods to get an average.
> [Periods : 1W, 3D, 1D, 12h, 8h, 6h, 4h, 2h, 1h, 30m, 15m, 5m, 3m, 1m]

  - Asset to own : indicates the amount of assets that you want to keep in the wallet, by changing this value the ideal balance will change depending on how many assets you want to own.

- Press the "Add / Edit Asset" button (*4) to add or edit an asset (*2) with the split (*3) consideration you wish to have. The assets used will be listed in the list (*1), to remove them just select them in the list and click on the "Remove" button (*5).

> The bot can emulate a market, marking it with the abbreviation "emu". this type of market does not really exist, but is created for proper analysis.

- To save the changes click on "Save". The configurations are saved in the "Binance.exe.config" file in the xml format.


---------------

# BOT WORK

Uses indicators to analyze each graph, and based on the result decides how many and which cryipto should be owned, using the proportions you have set in the configurations.for example if you use a configuration:
<pre>
  Asset | Split
   BTC  | 100
   ETH  | 100
   USDT | 50
</pre>

If the result of the indicators :
<pre>
          | BUY | SELL
 BTC/ETH  | 10  |  10
 BTC/USDT | 18  |  2
 ETH/USDT | 15  |  5
</pre>

Based on the results of the indicators, the bot will tend to carry the wallet with the following proportion:

 > Ideal Balance = (Total of positive indicators)^2 * Split
 <pre>
  Asset                      |  Ideal Balance
  BTC  = 28^2 * 100 = 78400  |   ~ 54,7 %
  ETH  = 25^2 * 100 = 62500  |   ~ 43,6 %
  USDT = 7^2  * 50  = 2450   |   ~  1,7 %
 </pre>
 
 Therefore if you modify "Asset to own" following the example we will get:
 
  <pre>
  Asset to own |     3      |    2        |    1
  BTC          |  ~ 54,7 %  |  ~ 55,64 %  |   100 %
  ETH          |  ~ 43,6 %  |  ~ 44,36 %  |    0
  USDT         |  ~  1,7 %  |    0        |    0  
 </pre>
 
 # TECHNICAL ANALYSIS
 list of indicators used :
 <pre>
  EMA5
  EMA10
  EMA20
  EMA30
  EMA50
  EMA100
  EMA200
  SMA5
  SMA10
  SMA20
  SMA30
  SMA50
  SMA100
  SMA200
  MACD
  MACD-EMA
  WMA
  RSI
  CCI
  W%R
 </pre>
