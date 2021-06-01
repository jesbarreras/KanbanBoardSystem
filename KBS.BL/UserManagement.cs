using System;
using System.Collections.Generic;
using System.Text;

namespace KBS.BL
{
   public class UserManagement
    {
        private List<int> _userID = new List<int>() { 1, 2, 3, 4, 5 };
        private List<string> _userName = new List<string>() { "root", "user", "barre", "bar", "edward" };
        private List<string> _userPassword = new List<string>() { "root", "pass", "1234", "barr", "edward" };

        //public UserManagement()
        //{

        //}

        //public UserManagement (List <int> userID, List <string> userName, List<string>  userPassword)
        //{
        //    this._userID = userID;
        //    this._userName = userName;
        //    this._userPassword = userPassword;
        //}

        public bool Login (int inputID, string inputUserName, string inputPassword)
        {
         
            if (this._userID.Contains(inputID)&& inputUserName.Equals(this._userName[inputID - 1]) && inputPassword.Equals(this._userPassword[inputID - 1]))
            {
                return true;
            }

            else
            {
                return false;
            }

        }

    }
}
