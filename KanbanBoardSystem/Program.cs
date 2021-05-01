using System;
using System.Threading;

namespace KanbanBoardSystem
{
    class Program
    {
        //main method
        static void Main(string[] args)
        {

            //splash screen effects
            Console.Write("Loading.");

            //4 seconds delay
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }

            LoginSystem login = new LoginSystem();
            login.Login();

        }
    }
}
