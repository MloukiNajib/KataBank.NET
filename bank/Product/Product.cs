namespace Bank.Product
{
    public abstract class Product : IProduct
    {
        // annual rate
        protected double rate;
        private double amount;

        public Product(double amount)
        {
            this.amount = amount;
        }

        public double getAmount()
        {
            return amount;
        }

        public decimal getMonthlyValue()
        {
            return (decimal)(amount * (rate / 100) / 12);
        }

        public double getRate()
        {
            return rate;
        }
    }
}
