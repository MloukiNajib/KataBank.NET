using System;
using Bank.Bank;
using Bank.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest.UnitTests
{
    [TestClass()]
    public class Step1
    {
        private IBank Bank;

        public Step1()
        {
            Bank = new KataBank();
            Bank.AddClient(new Client("client1@test.com"));
            Bank.AddClient(new Client("client2@test.com"));
            Bank.AddClient(new Client("client3@test.com"));
        }

        [TestMethod()]
        public void ClientEmailMustBeWellFormatted()
        {
            try
            {
                var obj = new Client("client1");
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("client1 is not a valid email", ae.Message);
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
        public void ClientMustBeUnique()
        {
            try
            {
                Bank.AddClient(new Client("client1@test.com"));
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Client client1@test.com already exist", ae.Message);
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
        public void BankHas3Clients()
        {
            Assert.IsNotNull(Bank.GetClientList(), "Client list should not be null");
            Assert.AreEqual(3, Bank.GetClientList().Count);
        }

        [TestMethod()]
        public void ClientMustBeFound()
        {
            var client = Bank.SearchClient("client3@test.com");
            Assert.IsNotNull(client, "Client client3@test.com should be found");
            Assert.AreEqual("client3@test.com", client.GetEmail());
        }

    }
}
