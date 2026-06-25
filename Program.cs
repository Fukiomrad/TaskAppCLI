using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace TaskbarApp
{
    class Program
    {   //User Options and User Guiding 
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to the Taskbar App");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Press 1 to Continue");
            ConsoleKeyInfo appState = Console.ReadKey();

            while (appState.Key == ConsoleKey.D1)
            {
                Console.Clear();

                Console.WriteLine("----------");
                Console.WriteLine("THE MENU");
                Console.WriteLine("----------");

                Console.WriteLine("Press '1' to Create a Tasks File \nPress '2' to delete a tasks file(warning it will delete all your data!)\nPress '3' to Add a Task\nPress '4' to remove  a Task\nPress '5' to view all Tasks\nPress 'q' to Exit The Program ");
                ConsoleKeyInfo appRuntime = Console.ReadKey();


                switch (appRuntime.Key)
                {
                    case ConsoleKey.D1:
                        FileOperations.FileCreate();

                        break;
                    case ConsoleKey.D2:
                        FileOperations.FileDelete();

                        break;
                    case ConsoleKey.D3:
                        FileOperations.FileTaskAdd();

                        break;
                    case ConsoleKey.D4:
                        FileOperations.FileTaskRemove();

                        break;
                    case ConsoleKey.D5:
                        FileOperations.FileTaskView();

                        break;


                    case ConsoleKey.Q:
                        Console.WriteLine("Key: Q Pressed Closing The program");
                        Console.WriteLine("Press Any Key to Exit...");
                        Console.ReadKey();
                        System.Environment.Exit(1);
                        break;



                    default:
                        Console.WriteLine("\nInvalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }

                Console.WriteLine("Press any Key to Continue");

                Console.ReadKey();





            }







        }

        //I want to create a class module so that I can call these methods in my main and do user wanted operations

        class FileOperations
        {
            private static readonly string filePath = "tasks.json";

            public static void FileCreate()
            {
                if (File.Exists(filePath))
                {
                    Console.WriteLine("File already exists!");
                    return;
                }
                File.WriteAllText(filePath, "[]");
                Console.WriteLine("Task file created!");
            }

            public static void FileTaskAdd()
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No task file. Create one first (Option 1).");
                    return;
                }

                Console.Write("Enter task description: ");
                string desc = Console.ReadLine();

                var tasks = JsonSerializer.Deserialize<List<Task>>(File.ReadAllText(filePath));

                var newTask = new Task
                {
                    Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
                    Description = desc,
                    CreatedAt = DateTime.Now,
                    IsDone = false
                };

                tasks.Add(newTask);
                File.WriteAllText(filePath, JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true }));

                Console.WriteLine($"Task added (ID: {newTask.Id})");
            }

            public static void FileDelete()
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No file to delete.");
                    return;
                }

                Console.Write("Are you sure? (y/n): ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    File.Delete(filePath);
                    Console.WriteLine("\nFile deleted.");
                }
                else
                {
                    Console.WriteLine("\nCancelled.");
                }
            }

            public static void FileTaskView()
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No task file. Create one first (Option 1).");
                    return;
                }

                var tasks = JsonSerializer.Deserialize<List<Task>>(File.ReadAllText(filePath));

                if (tasks.Count == 0)
                {
                    Console.WriteLine("No tasks yet.");
                    return;
                }

                Console.WriteLine("\n--- YOUR TASKS ---");
                foreach (var t in tasks)
                {
                    string status = t.IsDone ? "[X]" : "[ ]";
                    Console.WriteLine($"{status} ID:{t.Id} - {t.Description} ({t.CreatedAt:MM/dd})");
                }
            }



            public static void FileTaskRemove()
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No task file. Create one first (Option 1).");
                    return;
                }

                Console.Write("Enter task ID to remove: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID.");
                    return;
                }

                var tasks = JsonSerializer.Deserialize<List<Task>>(File.ReadAllText(filePath));
                var task = tasks.FirstOrDefault(t => t.Id == id);

                if (task == null)
                {
                    Console.WriteLine($"No task with ID {id}.");
                    return;
                }

                tasks.Remove(task);
                File.WriteAllText(filePath, JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true }));
                Console.WriteLine($"Removed: {task.Description}");
            }



        }
    }




    class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDone { get; set; }
    }





}











































