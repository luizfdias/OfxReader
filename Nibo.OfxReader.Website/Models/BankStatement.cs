using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nibo.OfxReader.Website.Models
{
    public class BankStatement
    {
        public BankStatement()
        {
            this.Transactions = new List<Transaction>();
        }

        public BankStatement(BankStatementFile bankStatementFile)
        {
            this.Transactions = new List<Transaction>();
            this.LedgerBalances = new List<LedgerBalance>();

            this.BankId = int.Parse(bankStatementFile.BankAccountFile.BankId);
            this.Number = long.Parse(bankStatementFile.BankAccountFile.Number);

            foreach (var transactionFile in bankStatementFile.BankAccountFile.Transactions)
            {
                this.Transactions.Add(new Transaction(transactionFile));
            }

            foreach (var ledgerBalance in bankStatementFile.BankAccountFile.LedgerBalances)
            {
                this.LedgerBalances.Add(new LedgerBalance(ledgerBalance));
            }
        }
        
        [Key]
        public int BankStatementId { get; set; }

        public int BankId { get; set; }

        public long Number { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public virtual ICollection<LedgerBalance> LedgerBalances { get; set; }
    }
}