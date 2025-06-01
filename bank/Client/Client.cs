using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Bank.Product;
using Bank.Product.Imp;

namespace Bank.Client
{
    public class Client : IClient
    {
        private string email;
        private IList<IProduct> productList = new List<IProduct>();

        public Client(string email)
        {
            if (!IsValidEmail(email))
            {
                throw new ArgumentException($"{email} is not a valid email");
            }
            this.email = email;
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        public void AddProduct(string productType, double amount)
        {
            if (string.IsNullOrEmpty(productType))
            {
                throw new ArgumentException("Product type cannot be null or empty");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero");
            }

            // parser la chaîne en enum car productType est censé correspondre à un ProductTypeEnum
            if (!Enum.TryParse(productType, true, out ProductTypeEnum parsedType))
                throw new ArgumentException($"Unknown product type: {productType}");

            // Assert.Equal("client1@test.com cannot have two LDD", ex.Message);

            // Vérifier si le produit existe déjà dans la liste
            if (productList.Any(p => p.GetType().Name.Equals(parsedType.ToString(), StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"{email} cannot have two {productType}");
            }

            switch (parsedType)
            {
                case ProductTypeEnum.LDD:
                    productList.Add(new LDD(amount));
                    break;
                case ProductTypeEnum.Pret:
                    productList.Add(new Pret(amount));
                    break;
                case ProductTypeEnum.CompteAVue:
                    productList.Add(new CompteAVue(amount));
                    break;
                case ProductTypeEnum.LivretA:
                    productList.Add(new LivretA(amount));
                    break;
                default:
                    throw new ArgumentException($"Unmanaged product type: {productType}");
            }
        }

        public string GetEmail()
        {
            return email;
        }

        public decimal GetMonthlyBalance()
        {
           return productList.Sum(p => p.getMonthlyValue());
        }

        public IEnumerable<object> GetProductList()
        {
            return new List<object>(productList);
        }
    }
}
