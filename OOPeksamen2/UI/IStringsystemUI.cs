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
        void DisplayTooManyArgumentsError();
        void DisplayAdminCommandNotFoundMessage(string arg);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(User user);
        void DisplayGeneralError(string errorString);
    }
}
