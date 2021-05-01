using System;
using System.Threading;

namespace KanbanBoardSystem
{
    class MainMenu : LoginSystem
    {
      //variables
        char optionSelected;
        string message;
     //MainMenu
        public void DisplayMenu()
        { 
                try
                {

                    Console.WriteLine("\n\n\t\t -------------------------------------- Kaban Board System --------------------------------------\n\n");
                    Console.Write("Choices: \n B or b - Go to the Board ");
                    Console.Write("\t\t\t T or t - View the Task Table\n");
                    Console.WriteLine(" L or l - Log-out  \t\t\t\t V or v - View Logging Activities");


                    Console.Write("\nWhat do you want to do? ");
                    optionSelected = Console.ReadLine()[0];

                    switch (optionSelected)
                    {
                        case 'B':
                        case 'b':
                        message = TaskListData.actionsList[1];
                        TaskListData.logActivities.Push($" {userName} , {message} {DateTime.Now.ToString()}");
                        BoardTask board = new BoardTask();
                        board.DisplayBoardTask();

                        break;

                        case 'T':
                        case 't':
                          
                        Console.Write("Viewing Table.");
                        Thread.Sleep(1000);
                        Console.Write(".");
                        Thread.Sleep(1000);
                        Console.Write(".");
                        Thread.Sleep(1000);
                        Console.Write(".");
                        Thread.Sleep(1000);
                        Console.Write(".\n\n");

                        TaskTable taskTable = new TaskTable();
                        taskTable.DiplayingTaskTableList();

                        message = TaskListData.actionsList[2];
                        TaskListData.logActivities.Push($" {userName} , {message}  {DateTime.Now.ToString()}");


                        Console.WriteLine("\nPress enter to back to Main Menu.... ");
                        Console.ReadLine();

                        message = TaskListData.actionsList[10];
                        TaskListData.logActivities.Push($" {userName} , {message}  {DateTime.Now.ToString()}");

                        DisplayMenu();
                            break;

                        case 'L':
                        case 'l':
                            loginAttempt = 3;


                        message = TaskListData.actionsList[3];
                        TaskListData.logActivities.Push($" {userName} , {message}  {DateTime.Now.ToString()}");


                        //2 seconds delay
                        Console.Write("Logging-out.");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            Console.Write(".\n");
                            Login();
                            break;

                      case 'V':
                      case 'v':

                        message = TaskListData.actionsList[11];
                        TaskListData.logActivities.Push($" {userName} , {message}  {DateTime.Now.ToString()}");

                        LoggingActivity logActivities = new LoggingActivity();
                        logActivities.ShowLogActivities();


                        break;

                        default:
                            Console.WriteLine("Invalid Choice!");
                            DisplayMenu();
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            
        }
    }
}
