using Bank.Bank;
using Bank.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest.UnitTests
{
    [TestClass()]
    public class Step3
    {
        private IBank Bank;

        public Step3()
        {
            Bank = new KataBank();
            Bank.AddClient(new Client("client1@test.com"));
            Bank.AddClient(new Client("client2@test.com"));
            Bank.AddClient(new Client("client3@test.com"));
        }

        [TestMethod()]
        public void IfWeLend15000WeGetMinus25()
        {
            var client = Bank.SearchClient("client1@test.com");

            Assert.IsNotNull(client, "client1@test.com should exist");

            client.AddProduct("Pret", 15000.0);
            Assert.AreEqual(-25.0M, client.GetMonthlyBalance());
        }

        [TestMethod()]
        public void MonthlyShouldBe()
        {
            var client1 = Bank.SearchClient("client1@test.com");
            Assert.IsNotNull(client1, "client1@test.com should exist");

            var client2 = Bank.SearchClient("client2@test.com");
            Assert.IsNotNull(client2, "client2@test.com should exist");

            var client3 = Bank.SearchClient("client3@test.com");
            Assert.IsNotNull(client3, "client3@test.com should exist");


            client1.AddProduct("LivretA", 1000.0);
            client1.AddProduct("Pret", 42000.0);
            Assert.AreEqual(-69.375M, client1.GetMonthlyBalance());

            client2.AddProduct("LivretA", 1000.0);
            client2.AddProduct("LDD", 2100.0);
            client2.AddProduct("CompteAVue", 6000.0);
            Assert.AreEqual(4.875M, client2.GetMonthlyBalance());

            client3.AddProduct("LivretA", 2400.0);
            client3.AddProduct("LDD", 9000.0);
            client3.AddProduct("CompteAVue", 3000.0);
            client3.AddProduct("Pret", 12000.0);
            Assert.AreEqual(-9.75M, client3.GetMonthlyBalance());
            Assert.AreEqual(74.250M, Bank.GetMonthlyPNL());
        }
    }
}
