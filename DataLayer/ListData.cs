
using System.Collections.Generic;

namespace DataLayer
{
    public class ListData
    {
        public static List<string> taskListToDo = new List<string>();
        public static List<string> taskListDoing = new List<string>();
        public static List<string> taskListDone = new List<string>();
        public static Stack<string> loggingActivities = new Stack<string>();
        public static string taskProjectName = "";
        public static int taskWIPLimit;
    }
}
