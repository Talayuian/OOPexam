using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    interface IStringSystem
    {
        void BuyProduct(User user, Product product);
        void AddCreditsToAccount(User user, int amount);
        void ExecuteTransaction(Transactions transaction);
        Product GetProduct(uint id);
        User GetUser(string Username);
        List<Transactions> GetTransactionList(uint id);
        List<Product> GetActiveProducts();
        void Logging(string Path, Transactions print);
    }
}
