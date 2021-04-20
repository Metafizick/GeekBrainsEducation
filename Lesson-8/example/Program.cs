using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace example
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            int sum = 0;
            for (int i = 0; i < 2_000_000_000; i++)
            {
                sum += i;
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.ReadLine();
        }

    }
}
