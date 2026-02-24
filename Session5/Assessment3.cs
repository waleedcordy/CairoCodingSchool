using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Session5
{
    public class Assessment3
    {
        //Assessment3
        //Create a simple console-based To-Do List app that allows users to:
        //Add tasks with a description.
        //View all tasks with status(Pending/Completed).
        //Mark tasks as completed.
        //Remove tasks from the list.
        //Save tasks to List
        //Hint we will have 2 classes TaskItem, ToDoList
        public Assessment3()
        {
            ToDoList list = new ToDoList();

            ShowMainMenu(ref list);
        }

        void ShowMainMenu(ref ToDoList list)
        {
            while (true)
            {
                Console.ResetColor();
                Console.WriteLine("TO-DO LIST APP");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Remove Task");
                Console.WriteLine("5. Exit");
                Console.WriteLine(Environment.NewLine);
                Console.Write("Choose an operation: ");

                var line = Console.ReadLine();
                if (int.TryParse(line, out int value))
                {
                    if (value >= 1 && value <= 5)
                    {
                        switch (value)
                        {
                            case (int)Operations.AddTask:
                                CallAddTask(ref list);
                                break;

                            case (int)Operations.ViewTasks:
                                CallViewTasks(ref list);
                                break;

                            case (int)Operations.MarkCompleted:
                                CallMarkCompleted(ref list);
                                break;

                            case (int)Operations.RemoveTask:
                                CallRemoveTask(ref list);
                                break;

                            case (int)Operations.Exit:
                                CallExit();
                                break;

                                //will entering 6 here , will it asks again for entering operation number ?
                                //will it break the while loop if called from 1-5 ????
                        }
                    }
                }
            }
        }

        void CallAddTask(ref ToDoList list)
        {
            while (true)
            {
                Console.ResetColor();
                Console.Write("Enter task desciption: ");

                var line = Console.ReadLine();
                if (line.Length > 0)
                {
                    list.AddTask(line);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Task added succesfully!");

                    ShowMainMenu(ref list);
                }
            }
        }

        void CallViewTasks(ref ToDoList list)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(list.ViewTasks());
            ShowMainMenu(ref list);
        }

        void CallMarkCompleted(ref ToDoList list)
        {
            while (true)
            {
                Console.ResetColor();
                Console.Write("Enter task number to mark as completed: ");
                var line = Console.ReadLine();
                if (int.TryParse(line, out int id))
                {
                    if (list.MarkCompleted(id))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Task marked as completed!");

                        ShowMainMenu(ref list);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Task id is wrong");
                    }
                }
            }
        }

        void CallRemoveTask(ref ToDoList list)
        {
            while (true)
            {
                Console.ResetColor();
                Console.Write("Enter task number to remove: ");
                var line = Console.ReadLine();
                if (int.TryParse(line, out int id))
                {
                    if (list.RemoveTask(id))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Task removed!");
                        ShowMainMenu(ref list);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Task id is wrong");
                    }
                }
            }
        }

        void CallExit()
        {
            Environment.Exit(0);
        }

    }



    public class ToDoList
    {
        List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(string description)
        {
            int suggestedId = 1;
            if (tasks.Count != 0)
            {
                suggestedId = tasks.Max(x => x.Id) + 1;
            }
            tasks.Add(new TaskItem(suggestedId, description));
        }

        public string ViewTasks()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Environment.NewLine);

            if (tasks.Count == 0)
            {
                sb.AppendLine("No tasks available.");
            }
            else
            {
                Console.WriteLine("Your Tasks:");
                foreach (var task in tasks)
                {
                    sb.AppendLine(task.ToString());
                }
            }
            sb.AppendLine(Environment.NewLine);

            return sb.ToString();
        }

        public bool RemoveTask(int id)
        {
            if (tasks.FirstOrDefault(x => x.Id == id) != null)
            {
                tasks.RemoveAll(t => t.Id == id);
                return true;
            }

            return false;
        }

        public bool MarkCompleted(int id)
        {
            var foundTask = tasks.FirstOrDefault(x => x.Id == id);
            if (foundTask != null)
            {
                foundTask.MarkCompleted();
                return true;
            }

            return false;
        }

    }

    public class TaskItem
    {
        string description;
        TaskStatus status;

        public int Id { get; private set; }


        public TaskItem(int _id, string _description)
        {
            Id = _id;
            description = _description;
            status = TaskStatus.Pending;
        }

        public override string ToString()
        {
            return $"{Id}. {description} - {status.ToString()}";
        }

        public void MarkCompleted()
        {
            status = TaskStatus.Completed;
        }
    }

    public enum TaskStatus
    {
        Pending,
        Completed
    }

    public enum Operations
    {
        AddTask = 1,
        ViewTasks = 2,
        MarkCompleted = 3,
        RemoveTask = 4,
        Exit = 5
    }

}