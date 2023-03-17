using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.Title = Properties.Settings.Default.ApplicationNameDebug;
#else
            Console.Title = Properties.Settings.Default.ApplicationName;

#endif
            if (string.IsNullOrEmpty(Properties.Settings.Default.Fio) || Properties.Settings.Default.Age <= 0)
            {
                Console.Write("Введите ФИО:");
                Properties.Settings.Default.Fio = Console.ReadLine();

                Console.Write("Введите ваш возраст");
                if (int.TryParse(Console.ReadLine(), out int age)) 
                {
                    Properties.Settings.Default.Age = age;
                }
                else
                {
                    Properties.Settings.Default.Age = 0;
                }
                Properties.Settings.Default.Save();
            }
            Console.WriteLine($"Фио:{Properties.Settings.Default.Fio}");
            Console.WriteLine($"Возраст:{Properties.Settings.Default.Age}");

            /*ConnectionString connectionString1 = new ConnectionString
            {
                Host = "LocalHost",
                DatabaseName = "NewDatabae",
                UserName = "Andrey",
                Password = "12345"
            };
            ConnectionString connectionString2 = new ConnectionString
            {
                Host = "LocalHost",
                DatabaseName = "NewDatabase",
                UserName = "Andrey B",
                Password = "543215"
            };
            List<ConnectionString> connections = new List<ConnectionString>();
            connections.Add( connectionString1 );
            connections.Add( connectionString2 );
            CacheProvider cacheProvider = new CacheProvider();
            cacheProvider.CacheConnections(connections);*/
            CacheProvider cacheProvider = new CacheProvider();
            List<ConnectionString> connections = cacheProvider.GetConnectionFromCache();
            foreach (var connection in connections) 
            {
                Console.WriteLine($"{connection.Host} {connection.DatabaseName} {connection.UserName} {connection.Password}");
            }

            Console.ReadKey();
        }
    }
}
