using App.Domain.Core.Bank.TransactionAggrigate.Entite;
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
        List<TransAction>? GetTransactions(string cardNo);
        bool CheckFilePass(string userPass);
    }
}
