using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*
 Pseudocode:
- Task class
-- Description
-- Status 
--- An object with statusId:"desk" pairs
--- Get;
--- Set - check if the statusId is valid
-- name
-- id = idCount++;
-- static idCount
- Task service
-- List of tasks
-- AddTask(name,desc,status)
--- See if the name already exists, propose to rewrite or to create new
--- add task
-- ShowTasks(status)

 */

namespace _2
{

    class Task
    {
        static int idCount = 0;
        public static Dictionary<int, string> statusDict = new Dictionary<int, string>() { { 0, "In process" }, {1, "Completed" }, {2, "Planned"} };

        public int id;
        public string description;
        public string name;
        private int _status;
        public int status
        {
            get { return _status; }
            set
            {
                if (!statusDict.ContainsKey(value))
                {
                    throw new Exception("Error: invalid status!");
                }
                _status = value;
            }
        }

        public Task(string name, string description,int status) {
            this.id = idCount++;
            this.name = name;
            this.description = description;
            this.status = status;
        }
    }

    class TaskService
    {
        public List<Task> tasks;

        public TaskService() { 
            tasks = new List<Task>();
        }

        public TaskService(List<Task> userTasks)
        {
            tasks = userTasks;
        }

        public void UpdateTask(int id, int field, string value)
        {
            Task task = CheckExistanceById(id);
            if (value != null)
            {
                switch (field)
                {
                    case 0:
                        task.description = value;
                        break;
                    case 1:
                        task.name = value;
                        break;
                    case 2:
                        task.status = Convert.ToInt16(value);
                        break;
                    default:
                        throw new Exception("Error: invalid field");
                }
            }

        }

        public void DeleteTask(int id) 
        {
            tasks.Remove(CheckExistanceById(id));
        }

        public void AddTask(string name,string description, int status) {
            Task existingTask = CheckExistanceByName(name);

            if (existingTask == null )
            {
                tasks.Add(new Task(name, description, status));
                return;
            }

            int answer = Convert.ToInt16(Helper.AskUser("The task with the same name was found. Do you want to update it (0) or create new (1)?"));
            if (answer == 0)
            {
                existingTask.name = name;
                existingTask.description = description;
                existingTask.status = status;
            }else if(answer == 1)
            {
                tasks.Add(new Task(name,description, status));
            }
            else
            {
                throw new Exception("Error: invalid answer!");
            }
        
        }

        public void ShowTasksByStatus(int status)
        {
            foreach(Task item in tasks)
            {
                if(item.status == status)
                {
                    Console.WriteLine($"{item.id}) {item.name} - {Task.statusDict[item.status]}");
                }
            }
        }

        public void ShowAll()
        {
            foreach (Task item in tasks)
            {
                Console.WriteLine($"{item.id}) {item.name} - {Task.statusDict[item.status]}");
            }
        }

        private Task CheckExistanceById(int id)
        {
            Task task = tasks.Find(item => item.id == id);
            if(task != null)
            {
                return task;
            }
            throw new Exception("Error: the task doesn't exist!");
        }

        private Task CheckExistanceByName(string name) {

            foreach(Task item in tasks)
            {
                if (item.name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }

            return null;
        }

    }

    public static class Helper
    {
        static public string AskUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
    internal class Program
    {

        static void Main(string[] args) // Чи можна замість switch/case використати об'єкт з functionId:functionDelegate парами?
        {


                TaskService taskService = new TaskService();
                Dictionary<int, string> availableFunctions = new Dictionary<int, string>() { { 0, "Add Task" }, { 1, "Update Task" }, { 2, "Delete Task" }, { 3, "Show tasks by status " }, { 4, "Show all tasks" } };
                List <string> messages = new List<string>() {"Insert Id: ", "Insert name: ", "Insert description: ", $"Insert status:\n\t0 - {Task.statusDict[0]}\n\t1 - {Task.statusDict[1]}\n\t2 - {Task.statusDict[2]}", "Insert field:\n\t0 - Description\n\t1 - name\n\t2 - status\n", "Insert value: " };

                Console.WriteLine("Welcome to the task manager. Available functions: ");
                foreach (int item in availableFunctions.Keys)
                {
                    Console.WriteLine(item + " - " + availableFunctions[item]);
                }
                while (true)
                {

                    try
                    {
                        int action = Convert.ToInt16(Helper.AskUser("Insert an action: "));
                        switch (action)
                        {
                            case 0:
                                string name = Helper.AskUser(messages[1]);
                                string description = Helper.AskUser(messages[2]);
                                int status = Convert.ToInt16(Helper.AskUser(messages[3]));
                                taskService.AddTask(name, description, status);
                                break;
                            case 1:
                                int id = Convert.ToInt16(Helper.AskUser(messages[0]));
                                taskService.UpdateTask(id, -1, null);
                                int field = Convert.ToInt16(Helper.AskUser(messages[4]));
                                string value = Helper.AskUser(messages[5]);
                                taskService.UpdateTask(id, field, value);
                                break;
                            case 2:
                                id = Convert.ToInt16(Helper.AskUser(messages[0]));
                                taskService.DeleteTask(id);
                                break;
                            case 3:
                                status = Convert.ToInt16(Helper.AskUser(messages[3]));
                                taskService.ShowTasksByStatus(status);
                                break;
                            case 4:
                                taskService.ShowAll();
                                break;
                        }
                    }catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }finally { Console.WriteLine(); }
                }   
        }

    }
}
