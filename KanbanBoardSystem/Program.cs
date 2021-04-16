using System;
using System.Threading;
using System.Collections.Generic;

namespace KanbanBoardSystem
{
    class Program

    {
        //variables
        List<string> taskToDo = new List<string>();
        List<string> taskDoing = new List<string>();
        List<string> taskDone = new List<string>();
        string inputUserName, inputPassword, userName = "root", userPassword = "root", taskProjectName = "", addedTask, moveTask;
        int loginAttempt = 3, taskListIndex, taskNumber;
        char optionSelected;


        //login system
        public void Login ()
        {
            try
            {

                do
                {
                    Console.WriteLine("\n\n\t\t ------------------------------ Welcome To Barre Kaban Board System ------------------------------\n\n");
                    Console.WriteLine("Log-in Attempt: "+loginAttempt);
                    Console.Write("\t\t\t\t\t\t Enter username: ");
                    inputUserName = Console.ReadLine().ToLower();
                    Console.Write("\t\t\t\t\t\t Enter Password: ");
                    inputPassword = Console.ReadLine();
              
         //3 seconds delay
                    Console.Write("\nVerifying.");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");

        //log-in Verification
                    if (userName.Equals(inputUserName) && userPassword.Equals(inputPassword))
                    {
                        Console.WriteLine("\n\nSuccefully Login"); 
                        Console.WriteLine("Welcome," + userName);
                        MainMenu();
                    }

                    else if (inputUserName.Equals("") || inputPassword.Equals(""))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPlease fill the blank!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIncorrect UserName or Password"!);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        --loginAttempt;
                 
                 //login attempt reached
                        if (loginAttempt == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You reached the maximum log-in attempt!\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("Please wait.");
                //4 seconds delay
                            for (int i = 0; i <4; i++)
                            {
                                Thread.Sleep(1000);
                                Console.Write(".");
                            }
                                                       
                            loginAttempt = 3;
                        }

                    }
                } while (!inputUserName.Equals(userName) || !inputPassword.Equals(userPassword));

            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        //Main Menu 
        public void MainMenu ()
        {
            try {
     
 
                Console.WriteLine("\n\n\t\t -------------------------------------- Kaban Board System --------------------------------------\n\n");
                Console.Write("Choices: \n B or b - Go to the Board ");
                Console.Write("\t\t\t T or t - View the Task Table\n");
                Console.WriteLine(" L or l - Log-out");

        
                    Console.Write("\nWhat do you want to do? ");
                    optionSelected = Console.ReadLine()[0];

                    switch (optionSelected)
                    {
                        case 'B': case 'b':
                            BoardTask();
                            break;

                        case 'T': case 't':
                            TaskTableView();
                            break;

                        case 'L': case 'l':
                            loginAttempt = 3;

              //2 seconds delay
                        Console.Write("Logging-out.");
                        Thread.Sleep(1000);
                        Console.Write(".");
                        Thread.Sleep(1000);
                        Console.Write(".\n");
                        Login();
                        break;

                        default:
                            Console.WriteLine("Invalid Choice!");
                            MainMenu();
                            break;
                    }
          
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
          
        }


        //board task creating and moving a task
        void BoardTask()
        {
            try
            {
           //2 seconds delay
                Console.Write("Please Wait.");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".\n");

                if (taskProjectName.Equals(""))
                {
                    Console.Write("\nEnter Project Name: ");
                    taskProjectName = Console.ReadLine();
                
                }
                
                Console.WriteLine("\n\nBoard:");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Project Name: " + taskProjectName);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");

                DisplayTaskListToDo();
                DisplayTaskListDoing();
                DisplayTaskListDone();

                //creating and moving task

                Console.WriteLine("\nChoices: \n");
                Console.Write(" A or a - Add Task ");
                Console.Write("\t\t\t B or b - Back to Main Menu\n");
                Console.WriteLine(" M or m - Move Task\n");

                Console.Write("What do you want to do? ");
                optionSelected = Console.ReadLine()[0];

                switch (optionSelected)
                {
                    case 'A' : case 'a' :

                    //adding task 
                        do
                        {
                            Console.Write("\nEnter a task you want to add: ");
                            addedTask = Console.ReadLine();
                            taskToDo.Add(addedTask);
                            Console.WriteLine("\nSuccessfully Added!The added task automatically goes to To Do List!");

                            Console.Write("\n\nDo you want to add task again? press Y or y to proceed or any key to stop: ");
                            optionSelected = Console.ReadLine()[0];

                        } while (optionSelected =='y'|| optionSelected=='Y');
                        BoardTask();

                    break;

             //moving task

                    case 'M': case 'm':

                        Console.WriteLine("\nChoices: \n 1 - Move task from To Do List to Doing List\t\t\t 3 - Move task from Doing List to Done List");
                        Console.WriteLine(" 2 - Move task from To Do List to Done List \t\t\t 4 - Move task from Doing List to To Do List");
                        Console.WriteLine(" 5 - Move task from Done List to To Do List \t\t\t 6 - Move task from Done List to Doing List\n");

                        Console.Write("\nWhat do you want to do? Enter you Choice: ");
                        optionSelected = Console.ReadLine()[0];

                        switch (optionSelected)
                        {

                    //moving task from To Do to Doing
                            case '1' :

                                if (taskToDo.Count==0)
                                {
                                    Console.WriteLine("\nUnfornately, To Do Task List is empty no task can  be move!");
                                    BoardTask();
                                }
                                else
                                {
                                    do
                                    {
                                        DisplayTaskListToDo();

                                        Console.Write("\n\nEnter task number you want to move in Doing Task List: ");
                                        taskListIndex = int.Parse(Console.ReadLine());
                                       
                                        if (taskToDo.Count < taskListIndex) {
                                            Console.WriteLine("The task number you've been entered is not on the list!\n");
                                        }

                                        else
                                        {
                                            Console.WriteLine("Successfully task number " + taskListIndex + " in To Do List moved to Doing List!\n");
                                            moveTask = taskToDo[taskListIndex - 1];
                                            taskDoing.Add(moveTask);
                                            taskToDo.Remove(moveTask);
                                            
                                        }

                                        Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                        optionSelected = Console.ReadLine()[0];

                                    } while (optionSelected == 'Y' || optionSelected == 'y');
                                    BoardTask();
                                }

                            break;

                   //moving task from To Do to Done

                            case '2':


                                if (taskToDo.Count == 0)
                                {
                                    Console.WriteLine("\nUnfornately, To Do Task List is empty no task can  be move!");
                                    BoardTask();
                                }
                                else
                                {
                                    do
                                    {
                                        DisplayTaskListToDo();

                                        Console.Write("\n\nEnter task number you want to move in Done List: ");
                                        taskListIndex = int.Parse(Console.ReadLine());

                                        if (taskToDo.Count < taskListIndex)
                                        {
                                            Console.WriteLine("The task number you've been entered is not on the list!\n");
                                        }

                                        else
                                        {
                                            Console.WriteLine("Successfully task number " + taskListIndex + " in To Do List moved to Done List!\n");
                                            moveTask = taskToDo[taskListIndex - 1];
                                            taskDone.Add(moveTask);
                                            taskToDo.Remove(moveTask);
                                        }

                                        Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                        optionSelected = Console.ReadLine()[0];

                                    } while (optionSelected == 'Y' || optionSelected == 'y');
                                    BoardTask();
                                }

                                break;

                   //moving task from Doing to Done
                            case '3':

                                if (taskDoing.Count == 0)
                                {
                                    Console.WriteLine("\nUnfornately, Doing Task List is empty no task can  be move!");
                                    BoardTask();
                                }
                                else
                                {
                                    do
                                    {
                                        DisplayTaskListDoing();

                                        Console.Write("\n\nEnter task number you want to move in Done Task List: ");
                                        taskListIndex = int.Parse(Console.ReadLine());

                                        if (taskDoing.Count < taskListIndex)
                                        {
                                            Console.WriteLine("The task number you've been entered is not on the list!\n");
                                        }

                                        else
                                        {
                                            Console.WriteLine("Successfully task number " + taskListIndex + " in Doing List moved to Done List!\n");
                                            moveTask = taskDoing[taskListIndex - 1];
                                            taskDone.Add(moveTask);
                                            taskDoing.Remove(moveTask);
                                        }

                                        Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                        optionSelected = Console.ReadLine()[0];

                                    } while (optionSelected == 'Y' || optionSelected == 'y');
                                    BoardTask();
                                }
                                break;

                  //moving task from Doing to To Do
                            case '4':


                                if (taskDoing.Count == 0)
                                {
                                    Console.WriteLine("\nUnfornately, Doing Task List is empty no task can  be move!");
                                    BoardTask();
                                }
                                else
                                {
                                    do
                                    {
                                        DisplayTaskListDoing();

                                        Console.Write("\n\nEnter task number you want to move in Doing Task List: ");
                                        taskListIndex = int.Parse(Console.ReadLine());

                                        if (taskDoing.Count < taskListIndex)
                                        {
                                            Console.WriteLine("The task number you've been entered is not on the list!\n");
                                        }

                                        else
                                        {
                                            Console.WriteLine("Successfully task number " + taskListIndex + " in Doing List moved to To Do List!\n");
                                            moveTask = taskDoing[taskListIndex - 1];
                                            taskToDo.Add(moveTask);
                                            taskDoing.Remove(moveTask);
                                        }

                                        Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                        optionSelected = Console.ReadLine()[0];

                                    } while (optionSelected == 'Y' || optionSelected == 'y');
                                    BoardTask();
                                }

                                break;

                  //moving task from Done to Doing
                            case '5':


                                if (taskDone.Count == 0)
                                {
                                    Console.WriteLine("\nUnfornately, Done Task List is empty no task can  be move!");
                                    BoardTask();
                                }
                                else
                                {
                                    do
                                    {
                                        DisplayTaskListDone();

                                        Console.Write("\n\nEnter task number you want to move in Doing Task List: ");
                                        taskListIndex = int.Parse(Console.ReadLine());

                                        if (taskDone.Count < taskListIndex)
                                        {
                                            Console.WriteLine("The task number you've been entered is not on the list!\n");
                                        }

                                        else
                                        {
                                            Console.WriteLine("Successfully task number " + taskListIndex + " in Done List moved to Doing List!\n");
                                            moveTask = taskDone[taskListIndex - 1];
                                            taskDoing.Add(moveTask);
                                            taskDone.Remove(moveTask);
                                        }

                                        Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                        optionSelected = Console.ReadLine()[0];

                                    } while (optionSelected == 'Y' || optionSelected == 'y');
                                    BoardTask();
                                }

                                break;

                   //moving task from Done to To Do
                            case '6':


                                if (taskDone.Count == 0)
                                {
                                    Console.WriteLine("\nUnfornately, To Done List is empty no task can  be move!");
                                    BoardTask();
                                }
                                else
                                {
                                    do
                                    {
                                        DisplayTaskListDone();

                                        Console.Write("\nEnter task number you want to move in Doing Task List: ");
                                        taskListIndex = int.Parse(Console.ReadLine());

                                        if (taskDone.Count < taskListIndex)
                                        {
                                            Console.WriteLine("The task number you've been entered is not on the list!\n");
                                        }

                                        else
                                        {
                                            Console.WriteLine("Successfully task number " + taskListIndex + " in Done List moved to To Do List!\n");
                                            moveTask = taskDone[taskListIndex - 1];
                                            taskToDo.Add(moveTask);
                                            taskDone.Remove(moveTask);
                                        }

                                        Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                        optionSelected = Console.ReadLine()[0];

                                    } while (optionSelected == 'Y' || optionSelected == 'y');
                                    BoardTask();
                                }

                                break;

                            default:
                                Console.WriteLine("Invalid Choice");
                                BoardTask();
                             break;
                        }

                        break;

            
            //back to main menu
                    case 'b': case 'B':
                   //2 seconds delay
                        Console.Write("Please Wait.");
                        Thread.Sleep(1000);
                        Console.Write(".");
                        Thread.Sleep(1000);
                        Console.Write(".\n");
                        MainMenu();
                        
                    break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        BoardTask();
                     break;
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Please make it sure you've enter correct input\n");
                BoardTask();
            }
           
        }

  
  //viewing TaskTable
         void TaskTableView () {

        //2 seconds delay
            Console.Write("Viewing table.");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".\n");
     
            if (taskProjectName.Equals(""))
            {

                Console.WriteLine("\nBoard:");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Project Name: No Project had been make!");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            }

            else
            {
                Console.WriteLine("\nBoard:");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Project Name: " + taskProjectName);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");

            }

            DisplayTaskListToDo();
            DisplayTaskListDoing();
            DisplayTaskListDone();

            Console.Write("\n\nPress enter back to Main Menu....");
            Console.ReadLine();

       //2 seconds delay
            Console.Write("Please Wait.");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".\n");

            MainMenu();

        }

    //displaying to do list
        void DisplayTaskListToDo()
        {

            taskNumber = 1;
            Console.WriteLine("\nTo Do Task: ");

            if (taskToDo.Count == 0)
            {
                Console.WriteLine("\nNo Task Available!");
            }

            else
            {
                foreach (var listToDo in taskToDo)
                {
                    Console.WriteLine(taskNumber + " - " + listToDo);
                    taskNumber++;
                }
            }
        }


     //displaying doing task list
        void DisplayTaskListDoing()
        {

            taskNumber = 1;
            Console.WriteLine("\nDoing Task : ");

            if (taskDoing.Count == 0)
            {
                Console.WriteLine("\nNo Task Available!");
            }

            else
            {
                foreach (var listDoing in taskDoing)
                {
                    Console.WriteLine(taskNumber + " - " + listDoing);
                    taskNumber++;
                }
            }
        }


    //displaying done task list
        void DisplayTaskListDone()
        {

            taskNumber = 1;
            Console.WriteLine("\nDone Task: ");
            if (taskDone.Count == 0)
            {
                Console.WriteLine("\nNo Task Available!");
            }

            else
            {
                foreach (var listDone in taskDone)
                {
                    Console.WriteLine(taskNumber + " - " + listDone);
                    taskNumber++;
                }
            }

        }


        //main method
        static void Main(string[] args)
        {
            Program runProgram = new Program();

      //splash screen effects
            Console.Write("Loading.");

         //4 seconds delay
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }

            runProgram.Login();
           
        }
    }
}
