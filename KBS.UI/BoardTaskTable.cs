using System;
using System.Collections.Generic;
using System.Text;
using KBS.BL;

namespace KBS.UI
{
    class BoardTaskTable
    {
        int taskNumber;

        public void DisplayBoardTaskTable()
        {

            BoardTaskBL boardTaskBL = new BoardTaskBL();


            Console.WriteLine("Board:");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Project Name: { boardTaskBL.taskProjectName}                 Due Date: { boardTaskBL.projectDueDate}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------\n");

            ShowTaskListToDo();
            ShowTaskListDoing();
            ShowTaskListTest();
            ShowTaskListApproval();
            ShowTaskListDone();
       
        }


        public void ShowTaskListToDo()
        {
            taskNumber = 1;

            BoardTaskBL boardTaskBL = new BoardTaskBL();
            Console.WriteLine($" To Do: {boardTaskBL.taskListToDo.Count}\n");

            if (boardTaskBL.taskListToDo.Count == 0)
            {
                Console.WriteLine("No task Available!\n");

            }
            else
            {
                foreach (var item in boardTaskBL.taskListToDo)
                {
                    Console.WriteLine($"{taskNumber} - {item}");
                    ++taskNumber;
                }
            }
        }

        public void ShowTaskListDoing()
        {
            taskNumber = 1;
            BoardTaskBL boardTaskBL = new BoardTaskBL();
            Console.WriteLine($" \nDoing: \n WIP Limit: {boardTaskBL.taskListDoing.Count}/{boardTaskBL.taskWIPLimit}\n");

            if (boardTaskBL.taskListDoing.Count == 0)
            {

                Console.WriteLine("No task Available!\n");

            }
            else
            {
                foreach (var item in boardTaskBL.taskListDoing)
                {
                    Console.WriteLine($"{taskNumber} - {item}");
                    ++taskNumber;
                }
            }

        }

        public void ShowTaskListTest()
        {
            taskNumber = 1;
            BoardTaskBL boardTaskBL = new BoardTaskBL();

            Console.WriteLine($" \nTesting: \n WIP Limit: {boardTaskBL.taskListTest.Count}/{boardTaskBL.taskWIPLimit}\n");

            if (boardTaskBL.taskListTest.Count == 0)
            {
                Console.WriteLine("No task Available!\n");
            }
            else
            {
              
                foreach (var item in boardTaskBL.taskListTest)
                {
                    Console.WriteLine($"{taskNumber} - {item}");
                    ++taskNumber;
                }
            }
        }

        public void ShowTaskListApproval()
        {
            taskNumber = 1;
            BoardTaskBL boardTaskBL = new BoardTaskBL();

            Console.WriteLine($" \nApproval: \n WIP Limit: {boardTaskBL.taskListApproval.Count}/{boardTaskBL.taskWIPLimit}\n");

            if (boardTaskBL.taskListApproval.Count == 0)
            {
                Console.WriteLine("No task Available!\n");
            }
            else
            {
               
                foreach (var item in boardTaskBL.taskListApproval)
                {
                    Console.WriteLine($"{taskNumber} - {item}");
                    ++taskNumber;
                }
            }

        }

        public void ShowTaskListDone()
        {
            taskNumber = 1;
            BoardTaskBL boardTaskBL = new BoardTaskBL();

            Console.WriteLine($" \nDone: {boardTaskBL.taskListDone.Count}\n");

            if (boardTaskBL.taskListDone.Count == 0)
            {

                Console.WriteLine("No task Available!\n");

            }
            else
            {   foreach (var item in boardTaskBL.taskListDone)
                {
                    Console.WriteLine($"{taskNumber} - {item}");
                    ++taskNumber;
                }
            }

        }

    }
}
