using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects;
using Binance.Net.Objects.Spot;

namespace BinanceToDesktop
{
    class Program
    {

        static void Main(string[] args)
        {
            var client = new BinanceSocketClient();

            var BIG = new List<decimal> { 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27 };
            var SMALL = new List<decimal> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            var SINGLE = new List<decimal> { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27 };
            var DOUBLE = new List<decimal> { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26 };
            var SMALLDOUBLE = new List<decimal> { 0, 2, 4, 6, 8, 10, 12 };
            var SMALLSINGLE = new List<decimal> { 0, 2, 4, 6, 8, 10, 12 };
            var BIGDOUBLE = new List<decimal> { 14, 16, 18, 20, 22, 24, 26 };
            var BIGSINGLE = new List<decimal> { 15, 17, 19, 21, 23, 25, 27 };

            client.Spot.SubscribeToKlineUpdatesAsync("BTCUSDT", KlineInterval.OneMinute, Kline =>
            {
                var seed = Kline.Data.Close.ToString("0.00").Replace(".", "").Take(3).Select(e => decimal.Parse(e.ToString())).Sum();

                var R0 = BIG.Contains(seed) ? "BIG" : SMALL.Contains(seed) ? "SMALL" : "";
                var R1 = SINGLE.Contains(seed) ? "SINGLE" : DOUBLE.Contains(seed) ? "DOUBLE" : "";
                var R2 = SMALLDOUBLE.Contains(seed) ? "SMALLDOUBLE" : 
                SMALLSINGLE.Contains(seed) ? "SMALLSINGLE" : 
                BIGDOUBLE.Contains(seed) ? "BIGDOUBLE" :
                BIGSINGLE.Contains(seed) ? "BIGSINGLE" : "";

                Console.WriteLine($"{Kline.Data.OpenTime.ToLocalTime()} " + $"{Kline.Data.CloseTime.ToLocalTime()} " +
                            $"{Kline.Data.Open.ToString("0.00")} " +
                            $"{Kline.Data.Close.ToString("0.00")} " +
                            $"{Kline.Data.Low.ToString("0.00")} " +
                            $"{Kline.Data.High.ToString("0.00")} {R0} {R1} {R2}");
                

            });

            while (true) { }
        }
    }
}
