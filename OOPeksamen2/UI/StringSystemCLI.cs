using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    public class StringSystemCLI : IStringsystemUI
    {
        StringSystem stringsystem;

        public StringSystemCLI(StringSystem stringsystem)
        {
            this.stringsystem = stringsystem;
            CloseProgram = false;
        }
        public void Start(StringSystemCommandParser parser)
        {
            string input;
            while (CloseProgram == false)
            {
                DisplayActiveProducts();
                input = Console.ReadLine();
                parser.ParseCommand(input);
                Console.WriteLine("press any key to reload screen and hide your informations:");
                Console.ReadKey();
                Console.Clear();
            }
            if (CloseProgram == true)
            {
                Environment.Exit(0);
            }
        }
        public void DisplayActiveProducts()
        {
            Console.WriteLine(string.Format("|{0,6}|{1,-36}|{2,8}|", "ID", "Product", "Price"));
            foreach (var item in stringsystem.Products)
            {
                if (stringsystem.Products[item.Key].Active)
                {
                    DisplayEachProductLine(item.Key);
                    DisplaySeparationLine();
                }
            }

        }
        public void DisplayEachProductLine(uint ID)
        {
            Console.WriteLine(string.Format("|{0,6}|{1,-36}|{2,8:N2}kr.|", stringsystem.Products[ID].ProductID, stringsystem.Products[ID].ProductName,((double) stringsystem.Products[ID].Price/100)));
        }
        public void DisplaySeparationLine()
        {
            Console.WriteLine("|------|------------------------------------|-----------|");
        }

        /*-----iMPLEMENTATION OF INTERFACE----- */

        public void DisplayUserNotFound(string Username)
        {
            Console.WriteLine("User [{0}] not found!", Username);
        }
        public void DisplayProductNotFound(uint ID)
        {
            Console.WriteLine("No Product with the ID: [{0}] was found!", ID);
        }
        public void DisplayUserInfo(string Username)
        {
            foreach (var item in stringsystem.Users)
            {
                if (item.Value.Username.Equals(Username))
                {
                    User User = item.Value;
                    Console.WriteLine("Username: [{0}] \nFull Name: [{1}]\nBalance on account: [{2,8:N2}]\n",Username,User.FirstName + " " + User.LastName,(double)User.Balance/100);
                    List<BuyTransaction> buytranslist = stringsystem.GetBuyTransactions(stringsystem.GetTransactionList(User.UserID));
                    Console.WriteLine("Latest [{0}] bought items:", buytranslist.Count);
                    foreach (BuyTransaction transaction in buytranslist)
                    { Console.WriteLine("\n" + transaction); }
                    if (User.Balance < 50) { Console.WriteLine("low on funds remaining funds: " + (double)User.Balance / 100); }
                    return;
                }
            }
            DisplayUserNotFound(Username);
        }
        public void DisplayTooManyArgumentsError()
        {
            Console.WriteLine("Too many arguments in command! could not compute");
        }
        public void DisplayAdminCommandNotFoundMessage(string arg)
        {
            Console.WriteLine("Admin command [{0}] could not be found!",arg);
        }
        public void DisplayUserBuysProduct(uint id)
        {
            Product product = stringsystem.GetProduct(id);
            Console.WriteLine("ID: [{0,6}]  Name: [{1,36}]  Price: [{2,6}kr.]", product.ProductID, product.ProductName, UintToDouble(product.Price));
        }
        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine("Completed transaction: [{0}]  [{1}]times", transaction.ToString(), count);
        }
        public void Close()
        {
            CloseProgram = true;
        }
        public void DisplayInsufficientCash(User user, uint productID)
        {
            Product product = stringsystem.GetProduct(productID);
            Console.WriteLine("Insufficient funds on [{0}]'s account, [{0}]'s balance is [{1,6:N2}]", user.Username,(double) user.Balance);
            Console.WriteLine("[{1}][{0}] cannot be bought", product.ProductName,product.ProductID);
        }
        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("Error Occured: [{0}]", errorString);
        }
        public double UintToDouble(uint UInteger)
        {
            double doubleinteger = Convert.ToDouble(UInteger);
            doubleinteger = doubleinteger / 100;
            return doubleinteger;
        }
        private bool CloseProgram { get; set; }
    }
}
