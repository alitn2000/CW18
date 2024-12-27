using App.Domain.Core.Bank.CardAggrigate.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configs.CardAggrigate;

public class CardConfig : IEntityTypeConfiguration<Card>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.CardNumber);
        builder.HasOne(u => u.User).WithMany(c => c.Cards).HasForeignKey(u => u.HolderName).OnDelete(DeleteBehavior.Restrict);


        builder.HasData(
            new Card { CardNumber = "5892101407708383", Password = "123", Balance = 500000, DailyTransferAmount = 0, HolderName = "alitn", IsActive = true },
            new Card { CardNumber = "5892101407708384", Password = "123", Balance = 500000, DailyTransferAmount = 0, HolderName = "reza", IsActive = true },
            new Card { CardNumber = "5892101407708385", Password = "123", Balance = 500000, DailyTransferAmount = 0, HolderName = "mamali", IsActive = true }
            );
    }
}
