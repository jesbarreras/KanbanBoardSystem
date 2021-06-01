using System;

namespace KBS.UI
{
    class MainMenu
    {

        public void ShowMenu ()
        {
            Console.Clear();

            Console.WriteLine($" ---------------------------------------------------- Main Menu  ----------------------------------------------------");

            Console.WriteLine("\nB - BoardTask");
            Console.WriteLine("L - Logout\n");

            UserChoice();

        }

        public void UserChoice ()
        {
            Console.Write("Enter your Choice: ");
            var optionSelected = Console.ReadLine().ToUpper()[0];

            switch (optionSelected)
            {
                case 'B':
                    Console.Clear();
                    BoardTask boardTask = new BoardTask();
                    boardTask.ShowTable();

                break;

                case 'L':

                    Console.WriteLine("Logging out.");
                    Console.Clear();
                    LoginSystem loginSystem = new LoginSystem();
                    loginSystem.UserLogin(0, null, null);

                break;

                default:
                Console.WriteLine("Invalid Choice");
                break;
            }
        }


    }
}
