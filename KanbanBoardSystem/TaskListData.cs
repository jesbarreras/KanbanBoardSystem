using System;
using System.Collections.Generic;

namespace KanbanBoardSystem
{
   public class TaskListData
    {
     
      //variables

        private static List<string> taskListToDo = new List<string>();
        private static List<string> taskListDoing = new List<string>();
        private static List<string> taskListDone = new List<string>();
        private static Stack<string> loggingActivities = new Stack<string>();
        private static List<string> actionLogs = new List<string>()
        {
            "login","goes to Board Task",
            "viewing Task List Table","logging-out",
            "goes to Adding task","task added in To Do List",
            "goes to Moving", "task moved in", "set WIP Limit",
            "change WIP Limit","goes to Main Menu", "viewing Logs"
            ,"entering Project Name", "goes to WIP Limit"
        };
        public static string taskProjectName = string.Empty;
        public static int taskWIPLimit = 0;
        public static DateTime dueDate;

   // properties of To Do List
        public static List <string> listToDo
        {
            get
            {
                return taskListToDo;
            }

            set
            {
                taskListToDo = listToDo;
            }
        }

   // properties of Doing List
        public static List<string> listDoing
        {
            get
            {
                return taskListDoing;
            }

            set
            {
                taskListDoing = listDoing;
            }
        }

   // properties of Done List
        public static List<string> listDone
        {
            get
            {
                return taskListDone;
            }

            set
            {
                taskListDone = listDone;
            }
        }

   // properties of loggingActivities

        public static Stack<string> logActivities
        {
            get
            {
                return loggingActivities;
            }

            set
            {
                loggingActivities = logActivities;
            }
        }

    // properties of Action Logs
        public static List<string> actionsList
        {
            get
            {
                return actionLogs;
            }
           
        }


    }

    
}
