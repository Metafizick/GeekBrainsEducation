using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
namespace Task_5
{
    class Program
    {
        public 
        static void Main(string[] args)
        {
            var tasklist = new TaskList();
            ShowTasks(tasklist.Tasks);
            while (true)
            {
                Console.WriteLine("Command List: \n" +
                    "number - choose number of task for work\n" +
                    "new - create new task\n" +
                    "esc - for escape");
                var inputword = Console.ReadLine();
                switch (inputword)
                {
                    case "esc":
                        Console.WriteLine("See you later");
                        foreach (ToDo item in tasklist.Tasks)
                        {
                            if (item.IsDone)
                                tasklist.Tasks.Remove(item);
                        }
                        string json = JsonSerializer.Serialize(tasklist.Tasks);
                        File.WriteAllText("Tasks.json", json);
                        return;
                    case "new":
                        Console.Clear();
                        Console.WriteLine("Enter new task");
                        var newTitle = Console.ReadLine();
                        tasklist.AddTask(newTitle);
                        ShowTasks(tasklist.Tasks);
                        break;
                    case "number":
                        Console.Clear();
                        Console.WriteLine("Enter number of task");
                        int numb = Convert.ToInt32(Console.ReadLine());
                        tasklist.TaskIsDone(numb);
                        ShowTasks(tasklist.Tasks);
                        break;
                }
            }

        }
        static void PrintItem(ToDo item)
        {
            var title = item.Title;
            var done = item.IsDone;
            Console.WriteLine($"{title,-3} {done,15}");
        }
        static void ShowTasks(List<ToDo> List)
        {
            Console.Clear();
            foreach (ToDo item in List)
            {
                Console.Write($"{List.IndexOf(item) + 1}\t");
                PrintItem(item);
            }
        }
    }
}
