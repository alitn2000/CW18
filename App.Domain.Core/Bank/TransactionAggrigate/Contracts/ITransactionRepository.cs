using App.Domain.Core.Bank.TransactionAggrigate.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Domain.Core.Bank.TransactionAggrigate.Contracts
{
    public interface ITransactionRepository
    {
        void AddTransaction(TransAction trans);
        List<TransAction>? ShowAll(string cartId);
    }
}
