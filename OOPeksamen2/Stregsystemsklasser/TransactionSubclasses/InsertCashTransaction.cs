using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    public class InsertCashTransaction : Transactions
    {
        public InsertCashTransaction(uint id, User user, int amount)
        {
            TransactionID = id;
            User = SetUser(user);
            Date = SetDate(DateTime.Now);
            Amount = (int)amount;
        }
        public override string ToString()
        {
            return "Transaktion nr.[" +Date + "] Beløb: [" + Amount + "]kr. optankes på " + User.Username + "'s konto, tispunkt for optankning: [" + Date +"]";
        }
        public override void execute()
        {
            User.AddToSaldo((int)Amount);
        }
    }
}
