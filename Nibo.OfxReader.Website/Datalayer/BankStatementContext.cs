using Nibo.OfxReader.Website.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Nibo.OfxReader.Website.Datalayer
{
    public class BankStatementContext: DbContext
    {
        public BankStatementContext(): base("BankStatementContext")
        {

        }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<BankStatement> BankStatements { get; set; }

        public DbSet<LedgerBalance> LedgerBalances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}