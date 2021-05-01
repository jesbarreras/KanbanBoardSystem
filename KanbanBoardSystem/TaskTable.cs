using System;

namespace KanbanBoardSystem
{
    class TaskTable
    {

    //variable
        int taskNumber;

    //displaying table
          public void DiplayingTaskTableList()
        {


            if (TaskListData.taskProjectName.Equals(""))
            {
                Console.WriteLine("\n\nBoard:");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Project Name: No project had been plan to make!\t\t Due Date: No Set Date");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("\n\nBoard:");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Project Name: {TaskListData.taskProjectName}\t\t Due Date: {TaskListData.dueDate}" );
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            }
            DisplayTaskListToDo();
            DisplayTaskListDoing();
            DisplayTaskListDone();

        }

    //displaying taskList To do
       public void DisplayTaskListToDo()
        {
            taskNumber = 1;
            Console.WriteLine($"\nTask To Do: {TaskListData.listToDo.Count}\n");
            
            if (TaskListData.listToDo.Count == 0)
            {
                Console.WriteLine("No task Available!");
            }
            else
            {
                foreach (var tasklist in TaskListData.listToDo)
                {
                    Console.WriteLine($"{taskNumber} - {tasklist}");
                    taskNumber++;
                }

            }
        }

   //displaying taskList Doing
        public void DisplayTaskListDoing()
        {
            taskNumber = 1;

            Console.WriteLine($"\nTask Doing:\n  Limit: {TaskListData.listDoing.Count}/{TaskListData.taskWIPLimit}\n");

            if (TaskListData.listDoing.Count == 0)
            {
                Console.WriteLine("No task Available!");
            }
            else
            {               
                foreach (var tasklist in TaskListData.listDoing)
                {
                    Console.WriteLine($"{taskNumber} - {tasklist}");
                    taskNumber++;
                }
            }
        }

    //displaying taskList Done
        public void DisplayTaskListDone()
        {
            taskNumber = 1;
            Console.WriteLine($"\nTask Done: {TaskListData.listDone.Count}\n");

            if (TaskListData.listDone.Count == 0)
           {
                Console.WriteLine("No task Available!");
            }
            else
            {
               
                foreach (var tasklist in TaskListData.listDone)
                {
                    Console.WriteLine($"{taskNumber} - {tasklist}");
                    taskNumber++;
                }
            }
        }
    }
}
