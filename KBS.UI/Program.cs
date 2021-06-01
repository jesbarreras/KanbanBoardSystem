using System;

namespace KBS.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            LoginSystem loginSystem = new LoginSystem();
            loginSystem.UserLogin(0, null, null);
        }
    }
}
