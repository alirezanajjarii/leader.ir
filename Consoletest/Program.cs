using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consoletest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 35; i++)
            {
                if (i % 4 == 0)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
    }
}
