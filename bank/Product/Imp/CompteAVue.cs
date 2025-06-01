using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Product.Imp
{
    public class CompteAVue : Product
    {
        public CompteAVue(double amount) : base(amount)
        {
            rate = 0.5;  
        }

    }
}