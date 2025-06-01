using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Product
{
    internal interface IProduct
    {
        public double getAmount();

        public double getRate();

        public decimal getMonthlyValue();
    }
}
