using App.Domain.Core.Bank.TransactionAggrigate.Entite;
using App.Domain.Core.Bank.UserAggrigate.Entite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Domain.Core.Bank.CardAggrigate.Entites
{
    public class Card
    {
        [Key]
        public string CardNumber { get; set; }
        public float Balance { get; set; }
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
        public float? DailyTransferAmount { get; set; } = 0;
        public DateTime? TodayTransaction { get; set; }
        public virtual List<TransAction> SourceCards { get; set; }
        public virtual List<TransAction> DestinationCards { get; set; }
        public User User { get; set; }
        public string HolderName { get; set; }

        public override string ToString()
        {
            return $"CardNo = {CardNumber}\nHolderName = {HolderName}";
        }
    }
}
