using System;
using System.Threading;
using KBS.BL;

namespace KBS.UI
{
    class BoardTask : BoardTaskTable
    {
        public void ShowTable()
        {
            Console.Clear();
            BoardTaskBL boardTaskBL = new BoardTaskBL();

            if (string.IsNullOrEmpty(boardTaskBL.taskProjectName))
            {
          
           try
                {
                    Console.Write("Enter Project Name: ");
                    var inputProjectName = Console.ReadLine();

                    Console.Write("Enter Due Date: (eg.01/11/2021): ");
                    var inputDueDate = DateTime.Parse(Console.ReadLine());

                    boardTaskBL.SetProject(inputProjectName, inputDueDate);
                    Console.Clear();
                    DisplayBoardTaskTable();

                }
                catch (Exception)
                {
                    Console.WriteLine("Program Error!");
                    Console.WriteLine("Please check your input carefully!");
                    Console.Clear();
                    ShowTable();
                }
            }

                DisplayBoardTaskTable();
                DisplayMenu();            
        } 


        public void DisplayMenu()
        {
            Console.Write("Choices:\n A - Adding Task \t\tB - Back to Main Menu\n");
            Console.Write(" M - Move Task \t\t\tS - Set WIP Limit\n");

            Console.Write("Enter your choice: ");
            var optionSelected = Console.ReadLine().ToUpper()[0];

            switch (optionSelected)
            {
            //adding task
                case 'A':
                    AddTask();
                    break;
            //setting wip limit
                case 'S':
                    SetWIPLimit();
                    break;
            //back to mainmenu
                case 'B':
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.ShowMenu();
                    Console.Clear();
                    break;

                //moving task
                case 'M':
                    MoveTask();
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                break;
            }

        }

        public void AddTask()
        {
            try
            {
                Console.Write("Enter a task: ");
                var addedTask = Console.ReadLine();

                BoardTaskBL boardTaskBL = new BoardTaskBL();

                if (boardTaskBL.AddTask(addedTask))
                {
                    Console.WriteLine("Successfully Added, this task automatical add only in To Do List!\n");


                    Console.Write("Do you want to add task again? Press Y to proceed or any key to stop: ");
                    var optionSelected = Console.ReadLine().ToUpper()[0];

                    if (optionSelected == 'Y')
                    {
                        AddTask();
                    }

                    else
                    {
                        ShowTable();
                    }
                }
                else
                {
                    Console.WriteLine("Please fill the blank!");
                    AddTask();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Program Error!, Invalid Input!");
                AddTask();
            }
        }

        public void SetWIPLimit()


        {
            Console.Clear();
            BoardTaskBL boardTaskBL = new BoardTaskBL();
            try
            {
                if (boardTaskBL.taskWIPLimit == 0)
                {
                    Console.Write("Enter a WIP Limit number: ");
                    var inputWIPLimit = int.Parse(Console.ReadLine());

                    boardTaskBL.SetWIPLimit(inputWIPLimit);

                    Console.WriteLine("Succefully WIP Limit Set!\n");

                    ShowTable();
                }

                else
                {
                    Console.Write("WIP Limit is already set!\nDo you want to change it? Press Y to proceed or any key to stop: ");
                    var optionSelected = Console.ReadLine().ToUpper()[0];

                    if (optionSelected == 'Y')
                    {
                        Console.Clear();
                        Console.Write("Enter a WIP Limit number: ");
                        var inputWIPLimit = int.Parse(Console.ReadLine());

                        boardTaskBL.SetWIPLimit(inputWIPLimit);

                        Console.WriteLine("Succefully WIP Limit Set!\n");
                        ShowTable();
                    }
                    else
                    {
                        ShowTable();
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("\nProgram Error!");
                Console.WriteLine("Please check your input!\n");
                SetWIPLimit();
            }
          
        }

        public void MoveTask()
        {
            BoardTaskBL boardTaskBL = new BoardTaskBL();
            var taskNumber = 1;

            Console.Clear();
            try
            {
       
                Console.Write("Choices:\n 1 - Move a task from To Do List to Doing List       2 - Move a task from Doing List to Test List\n");
                Console.Write(" 3 - Move a task from Test List to Approval List     4 - Move a task from Approval List to Done List\n");
                Console.WriteLine(" 5 - Back to Board \n");
                Console.Write("\nEnter your choice: ");
                var optionSelected = int.Parse(Console.ReadLine());

                switch (optionSelected)
                {
                //moving task from to do to doing
                    case 1:

                        if (boardTaskBL.taskListToDo.Count == 0)
                        {
                            Console.WriteLine("This task list is empty no task can be move!");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            MoveTask();
                        }
                        else
                        {
                            Console.WriteLine("Task To Do: " + boardTaskBL.taskListToDo.Count);

                            foreach (var item in boardTaskBL.taskListToDo)
                            {
                                Console.WriteLine($"{taskNumber} - {item}");
                                ++taskNumber;
                            }

                            Console.Write("Enter a task number you want to move to Doing List: ");
                            var inputTaskNumber = int.Parse(Console.ReadLine());

                            if (boardTaskBL.taskListToDo.Count > 0 || boardTaskBL.taskListToDo.Count > inputTaskNumber )
                            {
                                boardTaskBL.MoveTask(optionSelected, inputTaskNumber);
                                Console.WriteLine("Successfully Move task from To Do List to Done!");
                                Console.ReadKey();
                                MoveTask();
                            }
                            else
                            {
                                Console.WriteLine("This task number doesn't exist!\n");
                                MoveTask();
                            }
                        }
                        break;
            //moving a task from doing list to test list
                    case 2:

                        if (boardTaskBL.taskListDoing.Count == 0)
                        {
                            Console.Write("This task list is empty no task can be move!");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            MoveTask();
                        }
                        else
                        {
                            Console.WriteLine("Task Doing: " + boardTaskBL.taskListDoing.Count);

                            foreach (var item in boardTaskBL.taskListDoing)
                            {
                                Console.WriteLine($"{taskNumber} - {item}");
                                ++taskNumber;
                            }

                            Console.Write("Enter a task number you want to move to Test List: ");
                            var inputTaskNumber = int.Parse(Console.ReadLine());

                            if (boardTaskBL.taskListDoing.Count > 0 || boardTaskBL.taskListDoing.Count > inputTaskNumber)
                            {
                                boardTaskBL.MoveTask(optionSelected, inputTaskNumber);
                                Console.WriteLine("Successfully Move task from To Do List to Done!");
                                Console.ReadKey();
                                MoveTask();
                            }
                            else
                            {
                                Console.WriteLine("This task number doesn't exist!\n");
                                MoveTask();
                            }
                        }
                        break;
     //moving a task form test list to approval list
                    case 3:

                        if (boardTaskBL.taskListTest.Count == 0)
                        {
                            Console.Write("This task list is empty no task can be move!");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            MoveTask();
                        }
                        else
                        {
                            Console.WriteLine("Task List Test: " + boardTaskBL.taskListTest.Count);

                            foreach (var item in boardTaskBL.taskListToDo)
                            {
                                Console.WriteLine($"{taskNumber} - {item}");
                                ++taskNumber;
                            }

                            Console.Write("Enter a task number you want to move to Approval List: ");
                            var inputTaskNumber = int.Parse(Console.ReadLine());

                            if (boardTaskBL.taskListTest.Count > 0 || boardTaskBL.taskListTest.Count > inputTaskNumber)
                            {
                                boardTaskBL.MoveTask(optionSelected, inputTaskNumber);
                                Console.WriteLine("Successfully Move task from To Do List to Done!");
                                Console.ReadKey();
                                MoveTask();
                            }
                            else
                            {
                                Console.WriteLine("This task number doesn't exist!\n");
                                MoveTask();
                            }
                        }
                        break;
               //move from approval to done
                    case 4:

                        if (boardTaskBL.taskListApproval.Count == 0)
                        {
                            Console.Write("This task list is empty no task can be move!.");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            MoveTask();
                        }
                        else
                        {
                            Console.WriteLine("Task List Approval: " + boardTaskBL.taskListApproval.Count);

                            foreach (var item in boardTaskBL.taskListApproval)
                            {
                                Console.WriteLine($"{taskNumber} - {item}");
                                ++taskNumber;
                            }

                            Console.Write("Enter a task number you want to move to Done List: ");
                            var inputTaskNumber = int.Parse(Console.ReadLine());

                            if (boardTaskBL.taskListApproval.Count > 0 || boardTaskBL.taskListApproval.Count > inputTaskNumber)
                            {
                                boardTaskBL.MoveTask(optionSelected, inputTaskNumber);
                                Console.WriteLine("Successfully Move task from Approval task List to Done!");
                                Console.ReadKey();
                                MoveTask();
                            }
                            else
                            {
                                Console.WriteLine("This task number doesn't exist!\n");
                                MoveTask();
                            }
                        }
                        break;

                    case 5:
                        ShowTable();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!\n");
                        Console.Clear();
                        MoveTask();
                    break;
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Program Error!, Invalid Input!\n");
                ShowTable();
            }
        }
    }
}
