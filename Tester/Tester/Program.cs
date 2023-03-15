using System;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Running TestProduct method");
            Tester Test = new Tester();
            await Test.TestProducts();
            Console.ReadKey();
            Console.WriteLine("Running TestVentas Method");
            await Test.TestSales();
            Console.WriteLine("TEST PASSED");
        }

    }
}
