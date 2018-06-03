using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxAsyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var res = GetResult().Result;
            }
            catch (Exception e)
            {
                
            }

            Console.ReadKey();
        }

        static async Task<long> GetResult()
        {
            return await Observable.Interval(TimeSpan.FromSeconds(5)).SingleAsync();
        }
    }
}
