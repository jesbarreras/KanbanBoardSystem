using System;
using System.Threading;

namespace KanbanBoardSystem
{
   public class LoginSystem 
    {
        //variables
        public static string inputUserName, inputPassword, userName = "root", userPassword = "root";
        public  int loginAttempt = 3;
        string message;

        //login system
       public  void Login()
        {
            try
            {

                do
                {
                    Console.WriteLine("\n\n\t\t ------------------------------ Welcome To Barre Kaban Board System ------------------------------\n\n");
                    Console.WriteLine("Log-in Attempt: " + loginAttempt);
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

                        message = TaskListData.actionsList[0];
                        TaskListData.logActivities.Push($" {userName} , {message}  {DateTime.Now.ToString()}");


                        message = TaskListData.actionsList[10];
                        TaskListData.logActivities.Push($" {userName} , {message}  {DateTime.Now.ToString()}");
                        MainMenu mainmenu = new MainMenu();
                        mainmenu.DisplayMenu();
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
                            for (int i = 0; i < 4; i++)
                            {
                                Thread.Sleep(1000);
                                Console.Write(".");
                            }

                            loginAttempt = 3;
                        }

                    }
                } while (!inputUserName.Equals(userName) || !inputPassword.Equals(userPassword));

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


    }
}
