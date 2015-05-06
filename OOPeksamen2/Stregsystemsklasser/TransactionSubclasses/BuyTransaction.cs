using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2.Stregsystemsklasser.TransactionSubclasses
{
    class BuyTransaction:Transactions
    {
        public BuyTransaction(uint id, User user, DateTime date, Product product)
        {
            TransactionID = id;
            User = SetUser(user);
            Date = SetDate(date);
            Product = product;
            Amount = product.Price;
        }
        protected Product Product { get; protected set; }
        protected uint Amount { get; protected set; }

        public override string ToString()
        {
            return "Produkt: "+Product.ProductName +" pris: "+Amount+" User Buying Product: "+User+" Tidspunkt: "+Date+" ID på Transaktion: "+TransactionID;
        }
        public override void execute()
        {
            if (Amount > User.Balance)
                throw new Exception();
            else
                User.SubtractSaldo((int)Amount);
            
        }
    }
}
