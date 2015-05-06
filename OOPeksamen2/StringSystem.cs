using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class StringSystem
    {
        Dictionary<uint, User> Users = new Dictionary<uint, User>();
        Dictionary<uint, Product> Products = new Dictionary<uint, Product>();
        Dictionary<uint, Transactions> Transactions = new Dictionary<uint, Transactions>();

        
        public void BuyProduct(User user,Product product)
        {
            BuyTransaction Purchase = new BuyTransaction((uint) Transactions.Count, user, DateTime.Now, product);
            ExecuteTransaction(Purchase);
        }
        public void AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction Insert = new InsertCashTransaction((uint) Transactions.Count, user, DateTime.Now, amount);
            ExecuteTransaction(Insert);
        }
        public void ExecuteTransaction(Transactions transaction)
        {
            try
            {
                transaction.execute();
                Transactions.Add((uint)Transactions.Count, transaction);
            }
            catch(Exception)
            {
                //implement
            }
        }
        public Product GetProduct(uint id)
        {
            if(!(Products.ContainsKey(id)))
                throw new ProductNotExcistingException("Missing ID");
            return Products[id];
        }
        //get user
        //get transactionlist
        //get active products
    }
}
