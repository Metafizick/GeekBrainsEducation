using System;
using System.IO;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string workDir = @"C:\";
            string[] entries = Directory.GetFileSystemEntries(workDir, "*", SearchOption.AllDirectories);
            for (int i = 0; i < entries.Length; i++)
            {
                Console.WriteLine(entries[i]);
            }

        }

    }
}
