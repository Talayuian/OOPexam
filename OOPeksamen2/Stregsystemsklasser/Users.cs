using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOPeksamen2
{
    class User //: IComparable
    {
        public User(uint userID, string firstname, string lastname, string username, string email)
        {
            UserID = userID;
            FirstName = CheckNullOrEmpty(firstname);
            LastName = CheckNullOrEmpty(lastname);
            Username = SetUserName(CheckNullOrEmpty(username));
            EMail = SetEmail(CheckNullOrEmpty(email));
            Balance = 1;
            
        }
        public uint UserID { get; private set; }
        public string Username { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EMail { get; private set; }
        public int Balance { get; private set; }
        #region Setters
        #region CheckNullOrEmpty
        private string CheckNullOrEmpty(string name)
        {
            if (!(name == null || name == ""))
                return name;
            //
            else throw new ArgumentNullException("forkert indtastning");
        }
        #endregion
        #region Set E-Mail
        private string SetEmail(string mail)
        {
            Regex Mail = new Regex("^([a-zA-Z0-9\\.-_]+)\\@([a-zA-Z0-9]{1,})([a-zA-Z0-9\\.]+)([a-zA-Z0-9]{1,})\\.([a-zA-Z0-9]{2,3})");
            //Regex Mail = new Regex("^[\\w]+\\@+\\b[a-zA-Z0-9]+[a-zA-Z0-9-.]+[a-zA-Z0-9]\\b+\\.[a-zA-Z0-9]{2,4}$");
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
        public int Saldoforespørgelse() { return Balance; }

        public int AddToSaldo(int Beløb)
        {
            Balance += Beløb;
            return Balance;
        }

        public int SubtractSaldo(int Beløb)
        {
            Balance -= Beløb;
            if (Balance < 50){
                throw new ArgumentOutOfRangeException();
            }
            return Balance;
        }
        #endregion

        public override string ToString()
        {
            return EMail;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("forgotten an object?");

            User user = obj as User;
            if (user != null)
                return (int)(UserID - user.UserID);
            else
                throw new ArgumentException("Comparison failed");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            User user = obj as User;
            if (user != null)
                return UserID.Equals(user.UserID);
            else
                throw new ArgumentException("Comparison failed");
        }
        
        public override int GetHashCode()
        {
            return this.UserID.GetHashCode();
        }
    }
}
