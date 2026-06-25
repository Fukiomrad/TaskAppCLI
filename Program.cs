using System;
using System.Collections.Generic;
using System.Text.Json;

namespace TaskbarApp
{
    class Program
    {   //User Options and User Guiding 
        static void Main (string[] args)
        {
          Console.WriteLine("----------------------------");
          Console.WriteLine("Welcome to the Taskbar App");
          Console.WriteLine("-----------------------------");
          Console.WriteLine("Press 1 to Continue");
          ConsoleKeyInfo appState = Console.ReadKey();

            while ( appState.Key == ConsoleKey.D1)
            {
             Console.Clear();

             Console.WriteLine("----------");
             Console.WriteLine("THE MENU");
             Console.WriteLine("----------");

             Console.WriteLine("Press '1' to Create a Tasks File \nPress '2' to delete a tasks file(warning it will delete all your data!)\nPress '3' to Add a Task\nPress '4' to remove  a Task\nPress '5' to view all Tasks\nPress 'q' to Exit The Program ");
             ConsoleKeyInfo appRuntime = Console.ReadKey();
             

              switch(appRuntime.Key)
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
            
                    
             case ConsoleKey.Q :
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
    }  
    //I want to create a class in this class module so that I can call these methods in my main and do user wanted operations
    class FileOperations
    {
        
        public static void FileCreate()
        {
            Console.WriteLine("File Created!");
            
        }
        public static void FileDelete()
        {
            Console.WriteLine("File Deleted!");
            
        }

        public static void FileTaskView()
        {
            Console.WriteLine("Task Viewer!");
            
        }

        public static void FileTaskAdd()
        {
            Console.WriteLine("Task Added!");
            
        }
        public static void FileTaskRemove()
        {
            Console.WriteLine("Task Removed");
            
        }


     class TaskData
     {
      public string Username { get; set; }
      public DateTime DateCreated { get; set; }
      public List<TaskItem> Tasks { get; set; } = new();
     }

     class TaskItem
{
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}   
        
        
        
    }
      





        
         


            
      






        
         


         
      




    
} 







      
       
        
       
    
 
