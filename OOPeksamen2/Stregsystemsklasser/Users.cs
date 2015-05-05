using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOPeksamen2.StregSystemClasses
{
    class User : IComparable
    {
        public User(ulong userID, string username, string firstname, string lastname, string email)
        {
            UserID = userID;
            FirstName = CheckNullOrEmpty(firstname);
            LastName = CheckNullOrEmpty(lastname);
            Username = SetUserName(CheckNullOrEmpty(username));
            EMail = SetEmail(CheckNullOrEmpty(email));
            Balance = 0;
        }
        ulong UserID { get; protected set; }
        string Username { get; protected set; }
        string FirstName { get; protected set; }
        string LastName { get; protected set; }
        string EMail { get; protected set; }
        double Balance { get; private set; }

        #region CheckNullOrEmpty
        private string CheckNullOrEmpty(string name)
        {
            if (!(name == null || name == ""))
                return name;
            //
            else return "forkert indtastning";
        }
        #endregion
        #region Set E-Mail
        private string SetEmail(string mail)
        {
            Regex Mail = new Regex("^[a-zA-Z0-9_.-]+)@([a-zA-Z0-9]+[a-zA-Z0-9.-]+[a-zA-Z0-9]+).([a-zA-Z0-9]+)+$");
            if (Mail.IsMatch(mail))
                return mail;
            else
                throw new ArgumentException("Only alphanumeric characters may be used");
        }
        #endregion
        #region SetUsername
        public string SetUserName(string s)
        {
            Regex r = new Regex("^[a-zA-Z0-9_]+$");
            if (r.IsMatch(s))
                return s;
            else
                throw new ArgumentException("Only alphanumeric characters may be used");
        }
        #endregion

    }
}
