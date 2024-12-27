using App.Domain.Core.Bank.TransactionAggrigate.Contracts;
using App.Domain.Core.Bank.TransactionAggrigate.Entite;
using App.Infra.Data.Db.SqlServer.Ef;
using App.Infra.DataAccess.EF.CardAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Infra.DataAccess.EF.TransactionAggrigate;

public class TransactionRepository : ITransactionRepository
{

    private readonly AppDbContext _context;
    private readonly CardRepository _cardRepository;

    public TransactionRepository()
    {
        _context = new AppDbContext();
        _cardRepository = new CardRepository();
    }
    public void AddTransaction(TransAction trans)
    {
        _context.Transactions.Add(trans);
        _context.SaveChanges();
    }

    public List<TransAction>? ShowAll(string cartId)
    {
        return _context.Transactions.Where(c => c.SourceCardNumber == cartId || c.DestinationCardNumber == cartId).ToList();
    }
}


