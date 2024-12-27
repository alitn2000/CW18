using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace App.Domain.Core.Bank.TransactionAggrigate.Contracts
{
    public interface ITransactionService
    {
        bool Transfer(string source, string destination, float money);
        bool GetTransactions(string cardNo);
        bool CheckFilePass(string userPass);
        void PassCreate();
        void FilePass(object sender, ElapsedEventArgs e);
    }
}
