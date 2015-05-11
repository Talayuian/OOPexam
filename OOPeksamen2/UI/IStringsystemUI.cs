using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPeksamen2
{
    public interface IStringsystemUI
    {
        void DisplayUserNotFound(string Username);
        void DisplayProductNotFound(uint ID);
        void DisplayUserInfo(string Username);
        void DisplayTooManyArgumentsError(string arg);
        void DisplayAdminCommandNotFoundMessage(string arg);
        void DisplayUserBuysProduct(uint id);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(User user,uint productID);
        void DisplayGeneralError(string errorString);
        void DisplayLowBalance(User user);
    }
}
