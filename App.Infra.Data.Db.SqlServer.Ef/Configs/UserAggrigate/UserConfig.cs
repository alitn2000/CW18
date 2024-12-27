using App.Domain.Core.Bank.UserAggrigate.Entite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configs.UserAggrigate
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.UserName);
            builder.HasData(
                new User { FirstName = "ali", LastName = "tahmasebinia", NationalId = "0023527676", Password = "123", UserName = "alitn" },
                new User { FirstName = "reza", LastName = "rezayi", NationalId = "0023527677", Password = "123", UserName = "reza" },
                new User { FirstName = "mamad", LastName = "mamali", NationalId = "0023527678", Password = "123", UserName = "mamali" }
                );
        }
    }
}
