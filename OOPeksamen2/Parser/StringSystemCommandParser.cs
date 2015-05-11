using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    public class StringSystemCommandParser
    {
        const int LowBalanceAmount = 50;
        StringSystem stringsystem;
        StringSystemCLI CLI;
        Dictionary<string, Action<string[]>> admincmd = new Dictionary<string, Action<string[]>>();
        public StringSystemCommandParser(StringSystem stringsystem, StringSystemCLI CLI)
        {
            this.stringsystem = stringsystem;
            this.CLI = CLI;
            //admin commands for closing the program:
            admincmd.Add(":q", s => CLI.Close());
            admincmd.Add(":quit", s => CLI.Close());
            admincmd.Add(":Q", s => CLI.Close());
            admincmd.Add(":Quit", s => CLI.Close());
            //admin commands setting  if product is active or not
            //command is :activate/deactivate productID
            admincmd.Add(":deactivate", s => stringsystem.Products[uint.Parse(s[1])].SetActive(false));
            admincmd.Add(":activate", s => stringsystem.Products[uint.Parse(s[1])].SetActive(true));
            //admin commands to enable credit or disable credit, 
            //
            admincmd.Add(":crediton", s => stringsystem.Products[uint.Parse(s[1])].SetCanBeBoughtOnCredit(true));
            admincmd.Add(":creditoff", s => stringsystem.Products[uint.Parse(s[1])].SetCanBeBoughtOnCredit(false));
            admincmd.Add(":addcredits", s => stringsystem.AddCreditsToAccount(stringsystem.GetUser(s[1]),int.Parse(s[2])));
            admincmd.Add(":adduser", s => stringsystem.Users.Add((uint) stringsystem.Users.Count, stringsystem.adduser((uint)stringsystem.Users.Count,s)));
            admincmd.Add(":setprise", s => stringsystem.Products[uint.Parse(s[1])].SetPrice(uint.Parse(s[2])));
        }
        // user input sent correct places by parsecommand:
        public void ParseCommand(string command)
        {
            //spilts command into a string array
            string[] split = command.Split(' ');
            try
            {
                //checking if it's an admin command or user command
                if (command.StartsWith(":"))
                {
                    admincmd[split[0]].Invoke(split);
                }
                else
                {
                    User user = ParserGetUser(split);
                    //checks how many parts the command is split into to determine
                    //which type of command there should be serched for.

                    //user info
                    if (split.Length == 1)
                    {
                        CLI.DisplayUserInfo(split[0]);
                    }
                        //single purchse
                    else if (split.Length == 2)
                    {

                        uint productID;
                        bool IsNumber = uint.TryParse(split[1], out productID);
                        if (IsNumber == false) { throw new NotANumberException("productID is not a number");}
                        ParserBuyProduct(user, productID);

                    }
                        //multi purchase
                    else if (split.Length == 3)
                    {
                        uint productID;
                        int count;
                        bool IsNumberCount = int.TryParse(split[1], out count);
                        if (IsNumberCount == false) { throw new NotANumberException("numbers of items you want to buy is not a number");}
                        bool IsNumberID = uint.TryParse(split[2], out productID);
                        if (IsNumberID == false) { throw new NotANumberException("productID is not a number");}
                        //check if user can afford purchase, and do purchase if affordable.
                        int totalprice = count*(int)stringsystem.Products[productID].Price;
                        if (totalprice <= user.Balance)
                        {
                            for (int i = 0; i <= count - 1; i++)
                            {
                                ParserBuyProduct(user, productID);
                            }
                        }
                        else
                            CLI.DisplayInsufficientFundsMultiBuy(count,stringsystem.Products[productID]);

                    }
                    else throw new ArgumentException("number of command input");
                }

            }
            // Exception handeling:
            //user defined exceptions:
            catch (InsufficientCreditsException ex)
            {
                CLI.DisplayInsufficientCash(stringsystem.GetUser((string) ex.Data["User"]),(uint)ex.Data["Product"]);
            }
            catch (NoActiveProductsException ex)
            {
                
            }
            catch (NotActiveException ex)
            {
                
            }
            catch (NotANumberException ex)
            {
                CLI.DisplayNotANumberError(ex.Message);
            }
            catch (NoTransactionsFoundException ex)
            {
                
            }
            catch (ProductNotExcistingException ex)
            {
                CLI.DisplayProductNotFound((uint)ex.Data["Product"]);
            }
            catch (UserNotExcistingException ex)
            {
                CLI.DisplayUserNotFound((string)ex.Data["User"]);
            }
            // .net exceptions
            catch (KeyNotFoundException)
            {
                CLI.DisplayAdminCommandNotFoundMessage(command);
            }
            catch (ArgumentException ex)
            {
                CLI.DisplayTooManyArgumentsError(ex.Message);
            }
        }
        public void ParserBuyProduct(User user, uint productID)
        {
            stringsystem.BuyProduct(user, productID);
            //checks if low balance and calls appropiate method to inform user.
            if (user.Balance <= LowBalanceAmount)
                CLI.DisplayLowBalance(user);
            CLI.DisplayUserBuysProduct(productID);
        }
        public User ParserGetUser(string[] split)
        {
            return stringsystem.GetUser(split[0]);
        }


    }
}
