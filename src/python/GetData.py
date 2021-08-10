import config

from binance import Client, ThreadedWebsocketManager, ThreadedDepthCacheManager

client = Client(config.API_KEY, config.API_SECRET)

candles = client.get_klines(symbol='BTCUSDT', interval=Client.KLINE_INTERVAL_5MINUTE)

print(len(candles))

for candle in candles:
    print(candle)