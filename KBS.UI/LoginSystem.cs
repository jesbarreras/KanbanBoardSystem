using System;
using KBS.BL;

namespace KBS.UI
{
    class LoginSystem
    {

        public void UserLogin (int inputID, string inputUserName, string inputPassword)
        {
            try
            {
                Console.WriteLine(" -------------------------------- Welcome to Barre Kanban Board System  -------------------------------- \n");

                Console.Write("\n\t\t\t\tEnter ID number: ");
                inputID = int.Parse(Console.ReadLine());
                
                Console.Write("\t\t\t\tEnter User Name: ");
                inputUserName = Console.ReadLine();

                Console.Write("\t\t\t\tEnter Password: ");
                inputPassword = Console.ReadLine();

                UserManagement userManagementBL = new UserManagement();

                Console.Clear();
                if (userManagementBL.Login(inputID, inputUserName, inputPassword))
                {
                    Console.WriteLine("\nSuccesfully Login");
                    MainMenu mainmenu = new MainMenu();
                    mainmenu.ShowMenu();

                }

                else
                {
                    Console.WriteLine("\nIncorrect ID number or Username or Password!");
                    Console.Clear();
                    UserLogin(0,null,null);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nProgram Error!");
                Console.WriteLine("Program Exiting.");
            }
          
        }      
   
    }
}
