using System.Collections.Generic;
using System.Text;

namespace Nibo.OfxReader
{
    public class BankAccountFile : OfxEntity
    {
        public BankAccountFile(List<string> bankAccountBlock) : base(bankAccountBlock)
        {
            this.Transactions = new List<TransactionFile>();
            this.LedgerBalances = new List<LedgerBalanceFile>();

            this.BankId = this.GetFieldValue("BANKID").Trim();
            this.Number = this.GetFieldValue("ACCTID").Trim();

            var transactionBlocks = this.GetSpecificBlock("STMTTRN");

            foreach (var transactionBlock in transactionBlocks)
            {
                this.Transactions.Add(new TransactionFile(transactionBlock));
            }

            var ledgerBalanceBlocks = this.GetSpecificBlock("LEDGERBAL");

            foreach (var ledgerBalanceBlock in ledgerBalanceBlocks)
            {
                this.LedgerBalances.Add(new LedgerBalanceFile(ledgerBalanceBlock));
            }
        }

        public string BankId { get; set; }

        public string Number { get; set; }

        public List<TransactionFile> Transactions { get; set; }

        public List<LedgerBalanceFile> LedgerBalances { get; set; }
    }
}
