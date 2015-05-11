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
        // boolean til at stoppe lykke som holder programmet kørende.
        private bool CloseProgram { get; set; }

        //starter med at printe information til bruger, og scanne input fra brugeren i wn løkke der fortsætter indtil at brugeren beder programmet stoppe.
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
                //closeing program if loop was closed correctly
                Environment.Exit(0);
            }
        }
        // displays all active products
        public void DisplayActiveProducts()
        {
            //formatting string to make a grid with data.
            Console.WriteLine(string.Format("|{0,6}|{1,-36}|{2,8}|", "ID", "Product", "Price"));
            List<Product> activeProductList = new List<Product>();

            //getting a list of all active products
            activeProductList = stringsystem.GetActiveProducts();
            foreach (var item in activeProductList)
            {
                if (item.Active)
                {
                    //prints a single product in the console
                    DisplayEachProductLine(item.ProductID);
                    //prints the separtion line
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
            // first part contains 6x '-' then 36x '-' then lastly 8x '-'
            Console.WriteLine("|------|------------------------------------|-----------|");
        }
        //informs user of insufficient funds for multipurchase
        public void DisplayInsufficientFundsMultiBuy(int numberofproducts, Product product)
        {
            Console.WriteLine("insufficient funds to buy [{0}] of [{1}]",numberofproducts,product.ProductName);
        }
        //informs user of low balance on account
        public void DisplayLowBalance(User user)
        {
            Console.WriteLine("running low on funds, remaining funds is [{0,8:N2}], buy more credits soon",((double)user.Balance /100));
        }

        /*-----iMPLEMENTATION OF INTERFACE----- */

        //for informing the user, when user isn't found
        public void DisplayUserNotFound(string Username)
        {
            Console.WriteLine("User [{0}] not found!", Username);
        }
        //to inform user about product not found
        public void DisplayProductNotFound(uint ID)
        {
            Console.WriteLine("No Product with the ID: [{0}] was found!", ID);
        }
        // if only username is sent to parser, it will check for the user in the dictionary, and displays it
        public void DisplayUserInfo(string Username)
        {
            User User = stringsystem.GetUser(Username);
            Console.WriteLine("Username: [{0}] \nFull Name: [{1}]\nBalance on account: [{2,8:N2}]\n",Username,User.FirstName + " " + User.LastName,(double)User.Balance/100);
            List<BuyTransaction> buytranslist = stringsystem.GetBuyTransactions(stringsystem.GetTransactionList(User.UserID));
            Console.WriteLine("Latest [{0}] bought items:", buytranslist.Count);
            foreach (BuyTransaction transaction in buytranslist)
            { Console.WriteLine("\n" + transaction); }
            if (User.Balance < 50) { Console.WriteLine("low on funds remaining funds: " + (double)User.Balance / 100); }

        }
        //shows user the purchase the user just took
        public void DisplayUserBuysProduct(uint id)
        {
            Product product = stringsystem.GetProduct(id);
            Console.WriteLine("ID: [{0,6}]  Name: [{1,36}]  Price: [{2,6}kr.]", product.ProductID, product.ProductName, UintToDouble(product.Price));
        }
        //shows the user the multi-purchase the user just took
        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine("Completed transaction: [{0}]  [{1}]times", transaction.ToString(), count);
        }
        //closing program when asked to.
        public void Close()
        {
            CloseProgram = true;
        }
        //converts unsigned integer to a double float
        public double UintToDouble(uint UInteger)
        {
            double doubleinteger = Convert.ToDouble(UInteger);
            doubleinteger = doubleinteger / 100;
            return doubleinteger;
        }
        
        /*-----informing about errors-----*/
        //tells user if to many arguments is stated
        public void DisplayTooManyArgumentsError(string location)
        {
            Console.WriteLine("Too many arguments in command![{0}] could not compute",location);
        }
        //informs admin if admin used wrong command
        public void DisplayAdminCommandNotFoundMessage(string arg)
        {
            Console.WriteLine("Admin command [{0}] could not be found!",arg);
        }
        //informs user if user has insufficient cash on account
        public void DisplayInsufficientCash(User user, uint productID)
        {
            Product product = stringsystem.GetProduct(productID);
            Console.WriteLine("Insufficient funds on [{0}]'s account, [{0}]'s balance is [{1,6:N2}]", user.Username,(double) user.Balance);
            Console.WriteLine("[{1}][{0}] cannot be bought", product.ProductName,product.ProductID);
        }
        //inform on error with not a number exception
        public void DisplayNotANumberError(string message)
        {
            Console.WriteLine(message);
        }
        //informs user of error happening
        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("Error Occured: [{0}]", errorString);
        }


       
    }
}
