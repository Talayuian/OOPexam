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
        public User(uint userID, string username, string firstname, string lastname, string email)
        {
            UserID = userID;
            FirstName = CheckNullOrEmpty(firstname);
            LastName = CheckNullOrEmpty(lastname);
            Username = SetUserName(CheckNullOrEmpty(username));
            EMail = SetEmail(CheckNullOrEmpty(email));
            Balance = 0;
            
        }
        uint UserID { get; private set; }
        string Username { get; private set; }
        string FirstName { get; private set; }
        string LastName { get; private set; }
        string EMail { get; private set; }
        uint Balance { get; private set; }
        #region Setters
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
        #endregion
        #region Saldo interactions
        public uint Saldoforespørgelse() { return Balance; }

        public uint AddToSaldo(uint Beløb)
        {
            Balance += Beløb;
            return Balance;
        }

        public uint SubtractSaldo(uint Beløb)
        {
            Balance -= Beløb;
            return Balance;
        }
        #endregion

        public override string ToString()
        {
            return FirstName + ' ' + LastName + ' ' + EMail;
        }

        

    }
}
