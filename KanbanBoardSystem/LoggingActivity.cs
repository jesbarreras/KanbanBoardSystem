using System;
using System.Threading;

namespace KanbanBoardSystem
{
    class LoggingActivity
    {

     //variable
        string message;
        
        public void ShowLogActivities ()
        {
            Console.Write("\nChecking.");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".\n");

    //displaying logs in LIFO
            Console.WriteLine("\n Logging Activities: \n");
            foreach (var logslist in TaskListData.logActivities)
            {
                Console.WriteLine(logslist);
            }

    //back to main menu
            Console.WriteLine("\nPress Enter to back in Main Menu: ");
            Console.ReadLine();

            message = TaskListData.actionsList[10];
            TaskListData.logActivities.Push($"{LoginSystem.userName} , {message}  {DateTime.Now.ToString()}");

            Console.Write("\nPlease wait.");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".\n");
            MainMenu menu = new MainMenu();
            menu.DisplayMenu();
        }
    }
}


