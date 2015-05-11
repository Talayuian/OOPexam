﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace OOPeksamen2
{
    public class StringSystem : IStringSystem
    {
        public Dictionary<uint, User> Users = new Dictionary<uint, User>();
        public Dictionary<uint, Product> Products = new Dictionary<uint, Product>();
        public Dictionary<uint, Transactions> Transactions = new Dictionary<uint, Transactions>();

        public StringSystem()
        {
            ProductsReader productreader = new ProductsReader();
            productreader.Productreader();
            Products = productreader.productsdic;
        }
        public void BuyProduct(User user, uint productID)
        {
            Product product = GetProduct(productID);
            BuyTransaction Purchase = new BuyTransaction((uint)Transactions.Count, user, product);
            ExecuteTransaction(Purchase);
        }
        public void AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction Insert = new InsertCashTransaction((uint)Transactions.Count, user, amount);
            ExecuteTransaction(Insert);
        }
        public void ExecuteTransaction(Transactions transaction)
        {
            transaction.execute();
            Transactions.Add((uint)Transactions.Count, transaction);
            Logging(transaction);
        }
        public Product GetProduct(uint id)
        {
            if (!(Products.ContainsKey(id)))
                throw new ProductNotExcistingException("Missing ID");
            return Products[id];
        }
        public User GetUser(string Username)
        {
            foreach (var user in Users)
            {
                if (user.Value.Username.Equals(Username))
                    return user.Value;
            }
            throw new UserNotExcistingException("Missing User");
        }
        public List<Transactions> GetTransactionList(uint id)
        {
            List<Transactions> TransactionList = new List<Transactions>();
            int TempI = Transactions.Count;
            for (uint i = 0; i < TempI; i++)
            {
                if (Transactions[i].User.UserID == id)
                    TransactionList.Add(Transactions[i]);
            }
            if (TransactionList.Count == 0)
                throw new NoTransactionsFoundException("couldn't find BuyTransactions for this user");
            return TransactionList;
        }
        public List<BuyTransaction> GetBuyTransactions(List<Transactions> translist)
        {
            List<BuyTransaction> BuyTransList = new List<BuyTransaction>();
            translist.Reverse();
            foreach (Transactions item in translist)
            {
                if (item is BuyTransaction)
                    BuyTransList.Add(item as BuyTransaction);
                if (BuyTransList.Count == 10)
                {
                    break;
                }
            }
            if (BuyTransList.Count == 0)
            {
                throw new NoTransactionsFoundException("no buy transactions found!!!");
            }
            return BuyTransList;
        }
        public List<Product> GetActiveProducts()
        {
            List<Product> ActiveProductsList = new List<Product>();
            int ProductsLength = Products.Count;
            for (int i = 0; i < ProductsLength; i++)
            {
                if (Products[(uint)i].Active == true)
                    ActiveProductsList.Add(Products[(uint)i]);
            }
            if (ActiveProductsList.Count == 0)
                throw new NoActiveProductsException("No Active Products added yet");
            return ActiveProductsList;
        }
        public void Logging(Transactions print)
        {
            string printline = print.ToString();
            File.AppendAllText(("../../resourcer/transactions.log"), printline + Environment.NewLine);
        }
        public User adduser(uint ID,string[] userInfo)
        {
            for (uint i = 0; i < Users.Count; i++)
            {
                if (Users[i].Username == userInfo[3])
                    throw new ArgumentException();
            }
            for (int j = 5; j < userInfo.Length; j++)
            {
                userInfo[1] += " " + userInfo[j];
            }
            User user = new User(ID, userInfo[1], userInfo[2], userInfo[3], userInfo[4]);
            return user;
        }
    }
}
