using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string dir = @"C:\";
        try
        {
            string[] dirs = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly);
            Console.WriteLine("The number of directories {0}.", dirs.Length);
            foreach (string di in dirs)
            {
                Console.WriteLine(di);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}