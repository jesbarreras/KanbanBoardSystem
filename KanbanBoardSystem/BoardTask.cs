using System;
using System.Threading;


namespace KanbanBoardSystem
{
   class BoardTask 
    {
    //variables
         string moveTask, addedTask, message;
         int taskListIndex, inputTaskWIPLimit;
         char optionSelected;
      
  //displaying board task
        public void DisplayBoardTask()
        {
            try
            {
                //2 seconds delay
                Console.Write("Please Wait.");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".\n");

                if (TaskListData.taskProjectName.Equals(""))
                {
                    do
                    {
                        Console.Write("\nEnter Project Name: ");
                        TaskListData.taskProjectName = Console.ReadLine();

                        if (TaskListData.taskProjectName.Equals(""))
                        {
                            Console.WriteLine("\nPlease fill the blank!\n");
                        }

                    } while (TaskListData.taskProjectName.Equals(""));

                    do
                    {
                        Console.Write("Set a Due Date: eg. 01/22/2021: ");
                        TaskListData.dueDate = DateTime.Parse(Console.ReadLine());

                        if (TaskListData.dueDate < DateTime.Now)
                        {
                            Console.WriteLine("Invalid Date Time!\n");
                        }

                    } while (TaskListData.dueDate < DateTime.Now);

                    message = TaskListData.actionsList[12];
                    TaskListData.logActivities.Push($" {LoginSystem.userName} , {message} as {TaskListData.taskProjectName} and set due date  {DateTime.Now.ToString()}");
                }

                TaskTable tasktable = new TaskTable();

                tasktable.DiplayingTaskTableList();

                Console.WriteLine("\nChoices: \n");
                Console.Write(" A or a - Add Task ");
                Console.Write("\t\t\t B or b - Back to Main Menu\n");
                Console.WriteLine(" M or m - Move Task \t\t\t W or w - Set WIP Limit\n");

                Console.Write("What do you want to do? ");
                optionSelected = Console.ReadLine()[0];

                switch (optionSelected)
                {

            //adding task
                    case 'A': case 'a':
                        message = TaskListData.actionsList[4];
                        TaskListData.logActivities.Push($" {LoginSystem.userName} , {message}  {DateTime.Now.ToString()}");

                        AddingTask();

                        break;

             //moving task

                    case 'M': case 'm':
                        message = TaskListData.actionsList[6];
                        TaskListData.logActivities.Push($" {LoginSystem.userName} , {message}  {DateTime.Now.ToString()}");

                        MovingTask();
                        break;

            //setting wip
                    case 'w': case 'W':

                        message = TaskListData.actionsList[13];
                        TaskListData.logActivities.Push($" {LoginSystem.userName} , {message}  {DateTime.Now.ToString()}");

                        SetWIPLimit();

                     break;


         //back to main menu
                    case 'b': case 'B':
                        //2 seconds delay
                        Console.Write("Please Wait.");
                        Thread.Sleep(1000);
                        Console.Write(".");
                        Thread.Sleep(1000);
                        Console.Write(".\n");

                        message = TaskListData.actionsList[10];
                        TaskListData.logActivities.Push($" {LoginSystem.userName} , {message}   {DateTime.Now.ToString()}");

                        MainMenu menu = new MainMenu();
                        menu.DisplayMenu();

                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        DisplayBoardTask();
                        break;
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Input");
                Console.Write("Program exiting.");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
            }

        }

    //adding task
      private void AddingTask()
        {
            try
            {
                do
                {
                    Console.Write("\nEnter a task you want to add: ");
                    addedTask = Console.ReadLine();

                    if (addedTask.Equals(""))
                    {
                        Console.WriteLine("\nPlease fill the blank\n");
                    }

                    else
                    {
                        TaskListData.listToDo.Add(addedTask);
                        Console.WriteLine("\nSuccessfully Added!The added task automatically goes to To Do List!");
                        Console.Write("\n\nDo you want to add task again? press Y or y to proceed or any key to stop: ");
                        optionSelected = Console.ReadLine()[0];
                        message = TaskListData.actionsList[5];
                        TaskListData.logActivities.Push($" {LoginSystem.userName} , {addedTask} {message}   {DateTime.Now.ToString()}");
                    }

                } while (optionSelected == 'y' || optionSelected == 'Y' || addedTask.Equals(""));
                DisplayBoardTask();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

     //moving task
       private void MovingTask()
        {
            try {

                Console.WriteLine("\nChoices: \n 1 - Move task from To Do List to Doing List\t\t\t 3 - Move task from Doing List to Done List");
                Console.WriteLine(" 2 - Move task from To Do List to Done List \t\t\t 4 - Move task from Doing List to To Do List");
                Console.WriteLine(" 5 - Move task from Done List to Doing List \t\t\t 6 - Move task from Done List to To Do List\n");

                Console.Write("\nWhat do you want to do? Enter you Choice: ");
                optionSelected = Console.ReadLine()[0];

                switch (optionSelected)
                {
      //moving task from To Do to Doing
                    case '1':
        
                    if (TaskListData.listToDo.Count == 0)
                        {
                            Console.WriteLine("\nUnfornately, To Do Task List is empty no task can  be move!");
                            DisplayBoardTask();
                        }

                    else if (TaskListData.taskWIPLimit == 0)
                        {
                            Console.Write("\nYou can't move a task! You need to set WIPLimit First!\nDo you want to set it ? Press y or Y to proceed or press any key to exit: ");
                            optionSelected = Console.ReadLine()[0];

                            if (optionSelected == 'Y' || optionSelected == 'y')
                            {
                                SetWIPLimit();
                            }
                            else
                            {
                                DisplayBoardTask();
                            }

                        }

                    else
                        {
                            do
                            {
                                TaskTable tasktable = new TaskTable();
                                tasktable.DisplayTaskListToDo();

                                Console.Write("\n\nEnter task number you want to move in Doing Task List: ");
                                taskListIndex = int.Parse(Console.ReadLine());

                                if (TaskListData.listToDo.Count < taskListIndex || taskListIndex < 1)
                                {
                                    Console.WriteLine("The task number you've been entered is not on the list!\n");
                                }

                                else
                                {
                                    if (TaskListData.listDoing.Count >= TaskListData.taskWIPLimit)
                                    {
                                        Console.WriteLine("You already reached the maximum WIP Limit!");
                                    }

                                    else {
                                        Console.WriteLine("Successfully task number " + taskListIndex + " in To Do List moved to Doing List!\n");
                                        moveTask = TaskListData.listToDo[taskListIndex - 1];
                                        TaskListData.listDoing.Add(moveTask);
                                        TaskListData.listToDo.Remove(moveTask);

                                        message = TaskListData.actionsList[7];
                                        TaskListData.logActivities.Push($" {LoginSystem.userName} ,from To Do {moveTask} {message} Doing List  {DateTime.Now.ToString()}");

                                    }
                                }

                                Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                optionSelected = Console.ReadLine()[0];

                            } while (optionSelected == 'Y' || optionSelected == 'y');
                            DisplayBoardTask();
                        }

                        break;

       //moving task from To Do to Done

                    case '2':



                        if (TaskListData.listToDo.Count == 0)
                        {
                            Console.WriteLine("\nUnfornately, To Do Task List is empty no task can  be move!");
                            DisplayBoardTask();
                        }
                        else
                        {
                            do
                            {
                                TaskTable tasktable = new TaskTable();
                                tasktable.DisplayTaskListToDo();

                                Console.Write("\n\nEnter task number you want to move in Done List: ");
                                taskListIndex = int.Parse(Console.ReadLine());

                                if (TaskListData.listToDo.Count < taskListIndex || taskListIndex < 1)
                                {
                                    Console.WriteLine("The task number you've been entered is not on the list!\n");
                                }

                                else
                                {
                                    Console.WriteLine("Successfully task number " + taskListIndex + " in To Do List moved to Done List!\n");
                                    moveTask = TaskListData.listToDo[taskListIndex - 1];
                                    TaskListData.listDone.Add(moveTask);
                                    TaskListData.listToDo.Remove(moveTask);

                                    message = TaskListData.actionsList[7];
                                    TaskListData.logActivities.Push($" {LoginSystem.userName} , from To Do {moveTask} {message} Done List  {DateTime.Now.ToString()}");
                                }

                                Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                optionSelected = Console.ReadLine()[0];

                            } while (optionSelected == 'Y' || optionSelected == 'y');
                            DisplayBoardTask();
                        }

                        break;

       //moving task from Doing to Done
                    case '3':

                        if (TaskListData.listDoing.Count == 0)
                        {
                            Console.WriteLine("\nUnfornately, Doing Task List is empty no task can  be move!");
                            DisplayBoardTask();
                        }
                        else
                        {
                            do
                            {
                                TaskTable tasktable = new TaskTable();
                                tasktable.DisplayTaskListDoing();

                                Console.Write("\n\nEnter task number you want to move in Done Task List: ");
                                taskListIndex = int.Parse(Console.ReadLine());

                                if (TaskListData.listDoing.Count < taskListIndex || taskListIndex < 1)
                                {
                                    Console.WriteLine("The task number you've been entered is not on the list!\n");
                                }

                                else
                                {
                                    Console.WriteLine("Successfully task number " + taskListIndex + " in Doing List moved to Done List!\n");
                                    moveTask = TaskListData.listDoing[taskListIndex - 1];
                                    TaskListData.listDone.Add(moveTask);
                                    TaskListData.listDoing.Remove(moveTask);

                                    message = TaskListData.actionsList[7];
                                    TaskListData.logActivities.Push($" {LoginSystem.userName} , from Doing {moveTask} {message} Done List  {DateTime.Now.ToString()}");
                                }

                                Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                optionSelected = Console.ReadLine()[0];

                            } while (optionSelected == 'Y' || optionSelected == 'y');
                            DisplayBoardTask();
                        }
                        break;

          //moving task from Doing to To Do
                    case '4':


                        if (TaskListData.listDoing.Count == 0)
                        {
                            Console.WriteLine("\nUnfornately, Doing Task List is empty no task can  be move!");
                            DisplayBoardTask();
                        }
                        else
                        {
                            do
                            {
                                TaskTable tasktable = new TaskTable();
                                tasktable.DisplayTaskListDoing();

                                Console.Write("\n\nEnter task number you want to move in Doing Task List: ");
                                taskListIndex = int.Parse(Console.ReadLine());

                                if (TaskListData.listDoing.Count < taskListIndex || taskListIndex < 1)
                                {
                                    Console.WriteLine("The task number you've been entered is not on the list!\n");
                                }

                                else
                                {
                                    Console.WriteLine("Successfully task number " + taskListIndex + " in Doing List moved to To Do List!\n");
                                    moveTask = TaskListData.listDoing[taskListIndex - 1];
                                    TaskListData.listToDo.Add(moveTask);
                                    TaskListData.listDoing.Remove(moveTask);

                                    message = TaskListData.actionsList[7];
                                    TaskListData.logActivities.Push($" {LoginSystem.userName} , from Doing {moveTask} {message} To Do List  {DateTime.Now.ToString()}");
                                }

                                Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                optionSelected = Console.ReadLine()[0];

                            } while (optionSelected == 'Y' || optionSelected == 'y');
                            DisplayBoardTask();
                        }

                        break;

            //moving task from Done to Doing
                    case '5':

                   if (TaskListData.listDone.Count == 0)
                            {
                                Console.WriteLine("\nUnfornately, Done Task List is empty no task can  be move!");
                                DisplayBoardTask();
                            }

                    else if (TaskListData.taskWIPLimit == 0)
                        {
                            Console.Write("\nYou can't move a task! You need to set WIPLimit First!\nDo you want to set it ? Press y or Y to proceed or press any key to exit: ");
                            optionSelected = Console.ReadLine()[0];

                            if (optionSelected == 'Y' || optionSelected == 'y')
                            {
                                SetWIPLimit();
                            }
                            else
                            {
                                DisplayBoardTask();
                            }

                        }

                     else
                            {

                                do
                                {
                                    TaskTable tasktable = new TaskTable();
                                    tasktable.DisplayTaskListDone();

                                    Console.Write("\n\nEnter task number you want to move in Doing Task List: ");
                                    taskListIndex = int.Parse(Console.ReadLine());

                                    if (TaskListData.listDone.Count < taskListIndex || taskListIndex < 1)
                                    {
                                        Console.WriteLine("The task number you've been entered is not on the list!\n");
                                    }

                                    else
                                    {
                                        if (TaskListData.listDoing.Count >= TaskListData.taskWIPLimit)
                                        {
                                            Console.WriteLine("You already reached the maximum WIP Limit!");
                                            DisplayBoardTask();
                                        }

                                        else
                                        {
                                            Console.WriteLine("Successfully task number " + taskListIndex + " in Done List moved to Doing List!\n");
                                            moveTask = TaskListData.listDone[taskListIndex - 1];
                                        TaskListData.listDoing.Add(moveTask);
                                        TaskListData.listDone.Remove(moveTask);
                                        message = TaskListData.actionsList[7];
                                        TaskListData.logActivities.Push($" {LoginSystem.userName} , from Done {moveTask} {message} Doing List  {DateTime.Now.ToString()}");
                                    }
                                    }
                                    Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                    optionSelected = Console.ReadLine()[0];

                                } while (optionSelected == 'Y' || optionSelected == 'y');
                                DisplayBoardTask();
                            }

                        break;

            //moving task from Done to To Do
                    case '6':


                        if (TaskListData.listDone.Count == 0)
                        {
                            Console.WriteLine("\nUnfornately, To Done List is empty no task can  be move!");
                            DisplayBoardTask();
                        }
                        else
                        {
                            do
                            {
                                TaskTable tasktable = new TaskTable();
                                tasktable.DisplayTaskListDone();

                                Console.Write("\nEnter task number you want to move in Doing Task List: ");
                                taskListIndex = int.Parse(Console.ReadLine());

                                if (TaskListData.listDone.Count < taskListIndex || taskListIndex < 1)
                                {
                                    Console.WriteLine("The task number you've been entered is not on the list!\n");
                                }

                                else
                                {
                                    Console.WriteLine("Successfully task number " + taskListIndex + " in Done List moved to To Do List!\n");
                                    moveTask = TaskListData.listDone[taskListIndex - 1];
                                    TaskListData.listToDo.Add(moveTask);
                                    TaskListData.listDone.Remove(moveTask);

                                    message = TaskListData.actionsList[7];
                                    TaskListData.logActivities.Push($" {LoginSystem.userName} , from Done {moveTask} {message} To Do List  {DateTime.Now.ToString()}");
                                }

                                Console.Write("\n\nDo you want to move a task again? press Y or y to proceed or any key to stop: ");
                                optionSelected = Console.ReadLine()[0];

                            } while (optionSelected == 'Y' || optionSelected == 'y');
                            DisplayBoardTask();
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        MovingTask();
                        break;
                }
            } catch (Exception )
            {
                Console.WriteLine("Invalid Input");
                Console.Write("Program exiting.");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
            }

      }

  //setting wip limit
      private void SetWIPLimit() { 
         
    // if taskWIP Limit is equal to 0
          try
            {
                if (TaskListData.taskWIPLimit == 0)
                {
                    do
                    {
                        Console.WriteLine("\nWork In Progress Limit task\n");
                        Console.Write("Enter a WIP Limit number : ");
                        inputTaskWIPLimit = int.Parse(Console.ReadLine());

                        if (inputTaskWIPLimit <= 0)
                        {
                            Console.WriteLine("Please enter a valid input for WIP Limit!/n");
                        }

                        else
                        {
                            TaskListData.taskWIPLimit = inputTaskWIPLimit;
                        }
                        
                     } while (inputTaskWIPLimit <= 0);

                    message = TaskListData.actionsList[8];
                    TaskListData.logActivities.Push($" {LoginSystem.userName} , {message} in {TaskListData.taskWIPLimit}  {DateTime.Now.ToString()}");
                }

    // Changing the current value of WIP Limit
                else
                {
                    Console.Write("\n\nThe task limit is already set!\nDo you want to change it? Press y or Y to proceed or any key to cancel : ");
                    optionSelected = Console.ReadLine()[0];

                    if (optionSelected=='Y'||optionSelected=='y')
                    {
                        do
                        {
                            Console.Write("\nEnter a new WIP Limit number : ");
                            inputTaskWIPLimit = int.Parse(Console.ReadLine());
                          

                            if (inputTaskWIPLimit < TaskListData.taskWIPLimit)
                            {
                                Console.WriteLine("Please enter a valid input for WIP Limit!\n");
                            }

                            else
                            {
                                TaskListData.taskWIPLimit = inputTaskWIPLimit;
                            }
                          

                        } while (inputTaskWIPLimit < TaskListData.taskWIPLimit);

                        message = TaskListData.actionsList[9];
                        TaskListData.logActivities.Push($" {LoginSystem.userName} , {message} in { TaskListData.taskWIPLimit}  {DateTime.Now.ToString()}");
                    }
                    else
                    {
                        DisplayBoardTask();
                    }

                }
                Console.WriteLine("\nThe WIP Limit are already set! WIP Limit can apply only in Task List Doing!");
                DisplayBoardTask();
            } catch (Exception)
            {
                Console.WriteLine("Invalid Input");
                Console.Write("Program exiting.");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
            }
        }

      

    }
}
