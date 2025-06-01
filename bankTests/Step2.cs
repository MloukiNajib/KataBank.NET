using Bank.Bank;
using Bank.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTest.UnitTests
{
    [TestClass()]
    public class Step2
    {
        private IBank Bank;

        public Step2()
        {
            Bank = new KataBank();
            Bank.AddClient(new Client("client1@test.com"));
            Bank.AddClient(new Client("client2@test.com"));
            Bank.AddClient(new Client("client3@test.com"));
        }

        [TestMethod()]
        public void If1000OnLivretACost0625()
        {
            var client = Bank.SearchClient("client1@test.com");

            Assert.IsNotNull(client, "client1@test.com should exist");

            client.AddProduct("LivretA", 1000.0);
            Assert.AreEqual(0.625M, client.GetMonthlyBalance());
        }

        [TestMethod()]
        public void If2100OnLDDCost175()
        {
            var client = Bank.SearchClient("client2@test.com");

            Assert.IsNotNull(client, "client2@test.com should exist");

            client.AddProduct("LDD", 2100.0);

            Assert.AreEqual(1.75M, client.GetMonthlyBalance());
        }

        [TestMethod()]
        public void If3000OnCompteAVueCost125()
        {


            var client = Bank.SearchClient("client3@test.com");

            Assert.IsNotNull(client, "client3@test.com should exist");


            client.AddProduct("CompteAVue", 3000.0);
            Assert.AreEqual(1.25M, client.GetMonthlyBalance());
        }

        [TestMethod()]
        public void ClientCannotHave2LDD()
        {
            var client = Bank.SearchClient("client1@test.com");

            Assert.IsNotNull(client, "client1@test.com should exist");

            try
            {
                client.AddProduct("LDD", 3000.0);
                client.AddProduct("LDD", 5000.0);
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("client1@test.com cannot have two LDD", ae.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(
                     string.Format("Unexpected exception of type {0} caught: {1}",
                                    e.GetType(), e.Message)
                );
            }

        }

        [TestMethod()]
        public void ClientCannotHave2LivretA()
        {
            var client = Bank.SearchClient("client1@test.com");

            Assert.IsNotNull(client, "client1@test.com should exist");

            try
            {
                client.AddProduct("LivretA", 1000.0);
                client.AddProduct("LivretA", 6000.0);
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("client1@test.com cannot have two LivretA", ae.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(
                     string.Format("Unexpected exception of type {0} caught: {1}",
                                    e.GetType(), e.Message)
                );
            }
        }

        [TestMethod()]
        public void Client_cannot_have_2_CAV()
        {
            var client = Bank.SearchClient("client1@test.com");

            Assert.IsNotNull(client, "client1@test.com should exist");

            try
            {
                client.AddProduct("CompteAVue", 3000.0);
                client.AddProduct("CompteAVue", 1000.0);
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("client1@test.com cannot have two CompteAVue", ae.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(
                     string.Format("Unexpected exception of type {0} caught: {1}",
                                    e.GetType(), e.Message)
                );
            }
        }
    }
}