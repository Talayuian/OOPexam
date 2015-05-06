using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2.Stregsystemsklasser
{
    class Transactions
    {
        public Transactions(uint id, User user, DateTime date, int amount)
        {
            TransactionID = id;
            User = SetUser(user);
            Date = SetDate(date);
            Amount = amount;
        }
        protected Transactions() { }
        public uint TransactionID { get; protected set; }
        public User User { get; protected set; }
        public DateTime Date { get; protected set; }
        public int Amount { get; protected set; }

        #region Setters
        protected User SetUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("need new user");
            else return user;
        }
        protected DateTime SetDate(DateTime date)
        {
            if (date == null)
                throw new ArgumentNullException("need date");
            else return date;

        }
        #endregion
        public override string ToString()
        {
            return "ID: " + TransactionID + " Amount: " + Amount + " Time: " + Date;
        }
        public virtual void execute() { }
    }
}
