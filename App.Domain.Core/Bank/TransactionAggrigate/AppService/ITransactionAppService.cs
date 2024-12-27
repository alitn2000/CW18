using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Bank.TransactionAggrigate.AppService
{
    public interface ITransactionAppService
    {
        bool Transfer(string source, string destination, float money);
        bool GetTransactions(string cardNo);
        bool CheckFilePass(string userPass);
    }
}
