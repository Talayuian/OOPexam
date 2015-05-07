using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class StringSystemCommandParser : IStregsystemUI, IStringSystem
    {
        StringSystem stringsystem;
        StringSystemCLI CLI;
        public StringSystemCommandParser(StringSystem stringsystem, StringSystemCLI CLI)
        {
            this.stringsystem = stringsystem;
            this.CLI = CLI;
        }

       /* public void ParseCommand(string command)
        {
            if (command.StartsWith(":"))
                //AdminCommand(command)
            else
	        {

	        }
        }
        public void AdminCommand(string admCommand)
        {
            switch (admCommand)
            {
                case(":q",":Q",":quit",":Quit"):

                default:
                    break;
            }
        }
        */




        // ----- IMPLEMENTING INTERFACE IStringsystemUI-----//
        public void DisplayUserNotFound(string Username)
        {
            throw new NotImplementedException();
        }

        public void DisplayProductNotFound(uint ID)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserInfo(string Username)
        {
            throw new NotImplementedException();
        }

        public void DisplayTooManyArgumentsError()
        {
            throw new NotImplementedException();
        }

        public void DisplayAdminCommandNotFoundMessage(string arg)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void DisplayInsufficientCash(User user)
        {
            throw new NotImplementedException();
        }

        public void DisplayGeneralError(string errorString)
        {
            throw new NotImplementedException();
        }
        // ----- IMPLEMENTING INTERFACE IStringsystem-----//

        public void BuyProduct(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public void AddCreditsToAccount(User user, int amount)
        {
            throw new NotImplementedException();
        }

        public void ExecuteTransaction(Transactions transaction)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(uint id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(uint id)
        {
            throw new NotImplementedException();
        }

        public List<Transactions> GetTransactionList(uint id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetActiveProducts()
        {
            throw new NotImplementedException();
        }

        public void Logging(string Path, Transactions print)
        {
            throw new NotImplementedException();
        }
    }
}
