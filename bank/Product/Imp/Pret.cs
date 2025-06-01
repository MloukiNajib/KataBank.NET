using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Product.Imp
{
    public class Pret : Product
    {
        public Pret(double amount) : base(amount)
        {
            rate = -2;
        }
    }
}