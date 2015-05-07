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
            Start();

        }
        public void Start()
        {
            DisplayActiveProducts();
        }
        public void DisplayActiveProducts()
        {
            Console.WriteLine(string.Format("|{0,6}|{1,-36}|{2,8}|","ID","Product","Price"));
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
            Console.WriteLine(string.Format("|{0,6}|{1,-36}|{2,8}|", stringsystem.Products[ID].ProductID, stringsystem.Products[ID].ProductName, stringsystem.Products[ID].Price));
        }
        public void DisplaySeparationLine()
        {
            Console.WriteLine("|------|------------------------------------|--------|");
        }

        /*-----iMPLEMENTATION OF INTERFACE----- */

        public void DisplayUserNotFound(string Username)
        {
            Console.WriteLine("User [{0}] not found!",Username);
        }
        public void DisplayProductNotFound(uint ID)
        {
            Console.WriteLine("No Product with the ID: [{0}] was found!",ID);
        }
        public void DisplayUserInfo(string Username)
        {
            foreach (var item in stringsystem.Users)
            {
                if (item.Value.Username.Equals(Username))
                {
                    User User = item.Value;
                    Console.WriteLine("Username: " + Username + " Full Name: " + User.FirstName + " " + User.LastName + " Balance on account: " + User.Balance+ "\n\n");
                    List<BuyTransaction> buytranslist =stringsystem.GetBuyTransactions(stringsystem.GetTransactionList(User.UserID));
                    Console.WriteLine("Latest [{0}] bought items:", buytranslist.Count);
                    foreach (BuyTransaction transaction in buytranslist)
                    { Console.WriteLine("\n" +transaction); }
                    if (User.Balance < 50) { Console.WriteLine("low on funds remaining funds: "+User.Balance); }
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
            
            Console.WriteLine(stringsystem.GetProduct(id));
        }
        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine("Completed transaction: [{0}]  [{1}]times",transaction,count);
        }
        public void Close()
        {
            System.Environment.Exit(0);
        }
        public void DisplayInsufficientCash(User user)
        {
            Console.WriteLine("Insufficient funds on [{0}]'s account, [{0}]'s balance is [{1}]",user.Username,user.Balance);
        }
        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("Error Occured: [{0}]",errorString);
        }
    }
}
