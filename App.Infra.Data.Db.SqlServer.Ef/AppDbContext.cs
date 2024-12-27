using App.Domain.Core.Bank.CardAggrigate.Entites;
using App.Domain.Core.Bank.TransactionAggrigate.Entite;
using App.Domain.Core.Bank.UserAggrigate.Entite;
using App.Infra.Data.Db.SqlServer.Ef.Configs;
using App.Infra.Data.Db.SqlServer.Ef.Configs.CardAggrigate;
using App.Infra.Data.Db.SqlServer.Ef.Configs.TranactionAggrigate;
using App.Infra.Data.Db.SqlServer.Ef.Configs.UserAggrigate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-URA992G\SQLEXPRESS; Initial Catalog=BankManager2; Integrated Security=true ;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionConfig());
            modelBuilder.ApplyConfiguration(new CardConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<TransAction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
