using App.Domain.Core.Bank.CardAggrigate.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Bank.TransactionAggrigate.Entite
{
    public class TransAction
    {
        [Key]
        public int TransactionId { get; set; }
        public string SourceCardNumber { get; set; }
        public Card SourceCard { get; set; }
        public string DestinationCardNumber { get; set; }
        public Card DestinationCard { get; set; }
        public float Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
