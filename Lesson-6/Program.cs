using System;
using System.Diagnostics;
using System.Text;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            StringBuilder listProcc = new StringBuilder();
            listProcc.Append('*', 29).Append(" Task Manager ").Append('*', 29);
            listProcc.AppendLine("\n");
            listProcc.AppendFormat("{0,-12} {1,25} {2, 30} ", "Name of Process", "Process ID", "Memory Size");
            listProcc.AppendLine("\n");
            listProcc.Append('=', 20).Append(' ', 5).Append('=', 20).Append(' ', 10).Append('=', 20);
            listProcc.AppendLine("\n");
            for (int i = 0; i < processes.Length; i++)
            {
                listProcc.AppendFormat("{0,-12} {1,25} {2, 30} ", processes[i].ProcessName, processes[i].Id, processes[i].VirtualMemorySize64);
                listProcc.AppendLine();
            }
            Console.WriteLine(listProcc.ToString());
            Console.WriteLine("Would you stop any process(Y/N)");
            string ans;
            do
            {
                ans = Console.ReadLine();
                if (ans != "Y" & ans != "N")
                {
                    Console.WriteLine("Incorrect.Try again");
                }
            } while (ans != "Y" & ans != "N");
            if (ans == "Y")
            {
                Console.WriteLine("Enter process name or process ID");
                string killProc = Console.ReadLine();
                for (int i = 0; i < processes.Length; i++)
                {
                    if (killProc == processes[i].ProcessName)
                    {
                        processes[i].Kill();
                        // Console.WriteLine(processes[i].ExitCode);
                        Console.WriteLine($"Process {killProc} succesfully killed! Thanks for using Task manager");
                        break;
                    }
                    else if (killProc == Convert.ToString(processes[i].Id))
                    {
                        processes[i].Kill();
                        // Console.WriteLine(processes[i].ExitCode);
                        Console.WriteLine($"Process {killProc} succesfully killed! Thanks for using Task manager");
                        break;
                    }
                }
            }else if (ans == "N")
            {
                Console.WriteLine("So, go out :)");
            }
            Console.ReadKey();
        }
    }
}
