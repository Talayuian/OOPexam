using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    public class BuyTransaction:Transactions
    {
        public BuyTransaction(uint id, User user, Product product)
        {
            TransactionID = id;
            User = SetUser(user);
            Date = SetDate(DateTime.Now);
            Product = product;
            Amount = (int) product.Price;
        }
        public Product Product { get; protected set; }

        public override string ToString()
        {
            return "Produkt: "+Product.ProductName +" pris: "+Amount+" User Buying Product: "+User+" Tidspunkt: "+Date+" ID på Transaktion: "+TransactionID;
        }
        public override void execute()
        {
            if (Amount > User.Balance)
                if (Product.CanBeBoughtOnCredit == false)
                {
                    InsufficientCreditsException InsufficientCreditsException = new InsufficientCreditsException("insufficient funds for the chosen item");
                    InsufficientCreditsException.Data["User"] = User.Username;
                    InsufficientCreditsException.Data["Product"] = Product.ProductID;
                    throw InsufficientCreditsException;
                }

                else
                    User.SubtractSaldo(Amount);
            else User.SubtractSaldo(Amount);
            
        }
    }
}
