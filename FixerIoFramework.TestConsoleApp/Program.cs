using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixerIoFramework.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string access_key = "632165af7c22a54f0de43157d32ae275";

            var client = new RestClient("http://data.fixer.io/api/");

            var request = new RestRequest("latest", Method.GET);
            request.AddParameter("access_key", access_key);

            IRestResponse<_Currency> response = client.Execute<_Currency>(request);

            //Console.WriteLine($"AED - {response.Data.Rates.AED}");
            //Console.WriteLine(response.Data.Rates.AFN);
            foreach (var item in response.Data.Rates)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.ReadLine();
        }
    }
}
