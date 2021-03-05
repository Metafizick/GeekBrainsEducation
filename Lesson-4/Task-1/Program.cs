using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How much users you want entering now?");
            int numUsers = Convert.ToInt32(Console.ReadLine());
            string[] users = new string[numUsers];
            for (int i = 0; i < users.GetLength(0); i++)
            {
                Console.WriteLine($"Entering {i+1} user");
                string name1 = GetUserName();
                string surname1 = GetUserSurname();
                string patronomic1 = GetUserPatronomic();
                string user1 = GetFullName(name1, surname1, patronomic1);
                users[i] = user1;
                string userSuccess1 = userComplete(users[i]);
                Console.WriteLine(userSuccess1);
            }
            Console.WriteLine("Let's see full lisr of users!");
            for (int i = 0; i<users.GetLength(0); i++)
            {
                Console.WriteLine(users[i]);
            }
        }
        static string GetUserName()
        {
            Console.WriteLine("What is name of user?");
            string userName = Console.ReadLine();
            return userName;
        }
        static string GetUserSurname()
        {
            Console.WriteLine("What is surname of user?");
            string userSurname = Console.ReadLine();
            return userSurname;
        }
        static string GetUserPatronomic()
        {
            Console.WriteLine("What is patronomic of user?");
            string userPatronomic = Console.ReadLine();
            return userPatronomic;
        }
        static string GetFullName(string userName, string userSurname, string userPatronomic)
        {
            string fullName = userSurname + " " + userName + " " + userPatronomic;
            return fullName;
        }
        static string userComplete(string fullName)
        {
            return $"User {fullName} successfully entered!";
        }
    }
}
