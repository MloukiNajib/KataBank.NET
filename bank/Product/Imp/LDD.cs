using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Product.Imp
{
    public class LDD : Product
    {
        public LDD(double amount) : base(amount)
        {
            rate = 1;
        }
    }
}