using App.Domain.Core.Bank.TransactionAggrigate.Entite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configs.TranactionAggrigate
{
    public class TransactionConfig : IEntityTypeConfiguration<TransAction>
    {
        public void Configure(EntityTypeBuilder<TransAction> builder)
        {
            builder.HasOne(t => t.SourceCard).WithMany(t => t.SourceCards).HasForeignKey(c => c.SourceCardNumber).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne(t => t.DestinationCard).WithMany(t => t.DestinationCards).HasForeignKey(c => c.DestinationCardNumber).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
