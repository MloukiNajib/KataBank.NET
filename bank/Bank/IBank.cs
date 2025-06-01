using System.Collections.Generic;
using Bank.Client;

namespace Bank.Bank
{
    public interface IBank
    {
        IList<IClient> GetClientList();

        void AddClient(IClient client);

        IClient SearchClient(string email);

        decimal GetMonthlyPNL();
    }
}