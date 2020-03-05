using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {

            if (args.Length != 1 )
            {
                Console.WriteLine("No url given as argument!");
                throw new ArgumentNullException("No arguments!");
            }
            else
            {

                var url = args[0];

                Console.WriteLine("Starting");

                await startCrawling(url);


            }

        }




        private static async Task startCrawling(string url)
        {
            Console.WriteLine(url);

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z0-9]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var maches = regex.Matches(content);
                foreach (var item in maches)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }


        }
       
    }
}
