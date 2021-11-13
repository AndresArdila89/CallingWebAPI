using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CryptoBalance Consuming API ");
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var coin = new HttpClient())
            {
                coin.BaseAddress = new Uri("https://api.hitbtc.com/api/3/public/");
                coin.DefaultRequestHeaders.Accept.Clear();
                coin.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await coin.GetAsync("price/rate?from=ETH&to=BTC");
                if (response.IsSuccessStatusCode)
                {
                    //Coin crypto = await response.Content.ReadAsAsync<Coin>();

                   string crypto = await response.Content.ReadAsStringAsync();


                    //Console.WriteLine("{0}\t${1}\t{2}", crypto.Currency,crypto.Price, crypto.Timestamp);
                    Console.WriteLine(crypto);
                }
            }
        }


    }
}
