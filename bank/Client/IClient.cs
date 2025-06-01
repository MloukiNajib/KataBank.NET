using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;

namespace Bank.Client
{
    public interface IClient
    {
        public string GetEmail();

        public IEnumerable<object> GetProductList();

        public decimal GetMonthlyBalance();

        public void AddProduct(string productType, double amount);
    }
}