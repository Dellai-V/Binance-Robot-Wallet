# Binance Robot Wallet

> Source : https://github.com/Dellai-V/Binance-Robot-Wallet

> Referral Binance : https://www.binance.com/en/register?ref=EORD9N10

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
  - "Asset to own" (*3) indicates the amount of assets that you want to keep in the wallet, by changing this value the ideal balance will change depending on how many assets you want to own.
  - "Next update" (*4) indicates when the next chart update will be and any transactions if the bot will be activated.
  - List of markets (*5).
  - Event log (*6).
  - List of open orders (*7).
  - Balance (*8).
  >  Ideal : balance to which the bot will tend if the bot is activated, this value changes according to the market trend.
  - Wallet chart (*9) with statistics in percentages and dollar values (*10).
    
# CONFIGURATION 
  
  <img src="https://github.com/Dellai-V/Binance-Robot-Wallet/blob/master/Img/Setting.PNG" alt="Setting"/>

- Create a new account on Binance.com if you don't have it.
- Create a new API > https://www.binance.com/en/usercenter/settings/api-management
  Use API restrictions: Read Only, Enable Trading.
- Copy the API Key (*1) and the API secret (*2) in the bot configurations.
- Update time (*3) corresponds to the value in minutes, the time for updating the charts and the work of the bot.
> [Min = 1 ; Max = 120]

- Charts Period (*4) corresponds to the period of the graph, you can add multiple periods to get an average.
> [Periods : 1W, 3D, 1D, 12h, 8h, 6h, 4h, 2h, 1h, 30m, 15m, 5m, 3m, 1m]

- Press the "Add / Edit Asset" button (*7) to add or edit an asset (*5) with the split (*6) consideration you wish to have. The assets used will be listed in the list (*9), to remove them just select them in the list and click on the "Remove" button (*8).

- To save the changes click on "Save" (*10). The configurations are saved in the "Binance.exe.config" file in the xml format.
