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
    public class StringSystem
    {
        public Dictionary<uint, User> Users = new Dictionary<uint, User>();
        public Dictionary<uint, Product> Products = new Dictionary<uint, Product>();
        public Dictionary<uint, Transactions> Transactions = new Dictionary<uint, Transactions>();


        public void BuyProduct(User user, Product product)
        {
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
            Logging("Logfile.txt", transaction);
        }
        public Product GetProduct(uint id)
        {
            if (!(Products.ContainsKey(id)))
                throw new ProductNotExcistingException("Missing ID");
            return Products[id];
        }
        public User GetUser(uint id)
        {
            if (!(Users.ContainsKey(id)))
                throw new UserNotExcistingException("Missing User");
            return Users[id];
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
                throw new NoTransactionsFoundException("couldn't find Transactions for this user");
            return TransactionList;
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
        public void Logging(string Path, Transactions print)
        {
            StreamWriter File = new StreamWriter(Path);
            File.WriteLine(print.ToString());
        }
    }
}
