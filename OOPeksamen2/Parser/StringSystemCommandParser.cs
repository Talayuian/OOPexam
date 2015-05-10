using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    class StringSystemCommandParser
    {
        IStringSystem stringsystem;
        IStringsystemUI CLI;
        Dictionary<string, Action<string[]>> admincmd = new Dictionary<string, Action<string[]>>();
        public StringSystemCommandParser(StringSystem stringsystem, StringSystemCLI CLI)
        {
            this.stringsystem = stringsystem;
            this.CLI = CLI;
            admincmd.Add(":q", s => CLI.Close());
            admincmd.Add(":quit", s => CLI.Close());
            admincmd.Add(":Q", s => CLI.Close());
            admincmd.Add(":Quit", s => CLI.Close());
            admincmd.Add(":deactivate", s => stringsystem.Products[uint.Parse(s[1])].SetActive(false));
            admincmd.Add(":activate", s => stringsystem.Products[uint.Parse(s[1])].SetActive(true));
            admincmd.Add(":crediton", s => stringsystem.Products[uint.Parse(s[1])].SetCanBeBoughtOnCredit(true));
            admincmd.Add(":creditoff", s => stringsystem.Products[uint.Parse(s[1])].SetCanBeBoughtOnCredit(false));
            admincmd.Add(":addcredits", s => stringsystem.Users[stringsystem.GetUser(s[1]).UserID].AddToSaldo(int.Parse(s[2])));

        }

        public void ParseCommand(string command)
        {
            string[] split = command.Split(' ');
            if (split[0].StartsWith(":"))
            {
                admincmd[split[0]].Invoke(split);
            }
            else
            {
                User user = ParserGetUser(split);
                if (split.Length == 1)
                {
                    CLI.DisplayUserInfo(split[0]);
                }
                else if (split.Length == 2)
                {

                    uint productID;
                    bool IsNumber = uint.TryParse(split[1], out productID);
                    if (IsNumber == false) { /* throw custom exception*/}
                    ParserBuyProduct(user, productID);

                }
                else if (split.Length == 3)
                {
                    uint productID;
                    int count;
                    bool IsNumberCount = int.TryParse(split[1], out count);
                    if (IsNumberCount == false) { /* throw custom exception*/}
                    bool IsNumberID = uint.TryParse(split[2], out productID);
                    if (IsNumberID == false) { /* throw custom exception*/}
                    for (int i = 0; i <= count-1; i++)
                    {
                        ParserBuyProduct(user, productID);
                    }
                    
                }
            }
        }

        public void ParserBuyProduct(User user, uint productID)
        {
            stringsystem.BuyProduct(user, productID);
            CLI.DisplayUserBuysProduct(productID);
        }
        public User ParserGetUser(string[] split)
        {
            User user;
            user = stringsystem.GetUser(split[0]);
            return user;
        }


    }
}
