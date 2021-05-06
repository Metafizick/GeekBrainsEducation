using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace Task_5
{
    class TaskList
    {
        public List<ToDo> Tasks { get; set; }
        public TaskList() 
        {
            string json = File.ReadAllText("Tasks.json");
            Tasks = JsonSerializer.Deserialize<List<ToDo>>(json);
        }
       
        public void AddTask(string title)
        {
            var newTask = new ToDo { Title = title };
            Tasks.Add(newTask);
        }
        public void TaskIsDone(int number)
        {
            Tasks[number-1].Title = "[x]" + " " + Tasks[number - 1].Title;
            Tasks[number - 1].IsDone = true;
        }
        public List<ToDo> DeleteIsDone (List<ToDo> list)
        {
            list.RemoveAll(o => o.IsDone == true);
            return list;
        }
    }
}
