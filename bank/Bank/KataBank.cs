using System;
using System.Collections.Generic;
using System.Linq;
using Bank.Client;

namespace Bank.Bank
{
    public class KataBank : IBank
    {
        private IDictionary<string, IClient> clients = new Dictionary<string, IClient>();

        public void AddClient(IClient client)
        {
            if (clients.ContainsKey(client.GetEmail()))
              throw new ArgumentException($"Client {client.GetEmail()} already exist");
            
            clients.Add(client.GetEmail(), client);
        }

        public IList<IClient> GetClientList()
        {
            return clients.Values.ToList();
        }

        public decimal GetMonthlyPNL()
        {
            return -clients.Sum(c => c.Value.GetMonthlyBalance());
        }

        public IClient SearchClient(string email)
        {
            if(string.IsNullOrEmpty(email)) 
                throw new ArgumentException("Email cannot be null or empty");
            
            return clients.ContainsKey(email) ? clients[email] : null;
        }
    }
}
