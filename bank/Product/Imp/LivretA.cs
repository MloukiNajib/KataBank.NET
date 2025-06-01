using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Product.Imp
{
    public class LivretA : Product
    {
        public LivretA(double amount) : base(amount)
        {
            rate = 0.75; 
        }
    }
}