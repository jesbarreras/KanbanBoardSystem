using System;
using System.Collections.Generic;


namespace KBS.BL
{
  public class BoardTaskBL
    {
    
       //variables

        static private int _taskWIPLimit = 0;
        static private string _taskProjectName;
        static private DateTime _projectDueDate;


        static private List<string> _taskListToDo = new List<string>();
        static private List<string> _taskListDoing =new List<string>();
        static private List<string> _taskListApproval = new List<string>();
        static private List<string> _taskListTest =new List<string>();
        static private List<string> _taskListDone  = new List<string>();

        //properties
         public List <string> taskListToDo
        {
            get => _taskListToDo;
            set => _taskListToDo = taskListToDo;
        }
         public List<string> taskListDoing
        {
            get => _taskListDoing;
            set => _taskListToDo = taskListDoing;
        }
         public List<string> taskListTest
        {
            get => _taskListTest;
            set => _taskListTest = taskListTest;
        }
         public List<string> taskListApproval
        {
            get => _taskListApproval;
            set => _taskListApproval = taskListApproval;
        }
         public List<string> taskListDone
        {
            get => _taskListDone;
            set => _taskListDone = taskListDone;
        }

       public int taskWIPLimit
        {
            get
            {
                return _taskWIPLimit;
            }
        }
       public string taskProjectName
        {
            get
            {
                return _taskProjectName;
            }
        }
       public DateTime projectDueDate
        {
            get
            {
                return _projectDueDate;
            }
        }
   

       //methods
        public bool AddTask (string addedTask)
        {
        //adding task
            if (!string.IsNullOrEmpty(addedTask))
            {

                taskListToDo.Add(addedTask);
                return true;
            }

            else
            {
                return false;
            }

        }

        public void MoveTask(int numListChoice, int moveTaskIndex)
        {
            //move from To Do to Doing
            if (numListChoice == 1)
            {  
                    var moveTask = taskListToDo[moveTaskIndex - 1];
                   taskListToDo.Remove(moveTask);
                   taskListDoing.Add(moveTask);
                   
            }

            //move from Doing to Test
            else if (numListChoice == 2)
            {
                
                    var moveTask = taskListDoing[moveTaskIndex - 1];
                    taskListTest.Add(moveTask);
                    taskListDoing.Remove(moveTask);
      
            
            }

            //move from Test to Approval
           else  if (numListChoice == 3)
            {

             var moveTask = taskListTest[moveTaskIndex - 1];
                    taskListApproval.Add(moveTask);
                    taskListTest.Remove(moveTask);
               
              
            }

            //move from Approval to Done
            else if (numListChoice == 4)
            {
               
                    var moveTask = taskListApproval[moveTaskIndex - 1];
                    taskListDone.Add(moveTask);
                    taskListApproval.Remove(moveTask);
            
             
            }

            else
            {
                
            }

        }

        public void SetWIPLimit (int inputWIPLimit)
        {
             _taskWIPLimit = inputWIPLimit;
        }

        public void SetProject (string inputProjectName,  DateTime dueDate)
        {
            _taskProjectName = inputProjectName;
            _projectDueDate = dueDate;
        }


    }
}
