using FixerIoFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RateTypes[] arr = { RateTypes.GBP, RateTypes.JPY, RateTypes.AED };
            string value = string.Join(",", arr);

            string access_key = "632165af7c22a54f0de43157d32ae275";

            var client = new FixerIoClient(access_key);
           // Currency cur1 = client.GetLatest("AMD", "GBP");
            Currency cur1 = client.GetLatest(RateTypes.AMD, RateTypes.GBP);
           // Currency cur1 = client.Get(new DateTime(2017, 12, 24));
        }
    }
}
