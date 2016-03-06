using System.Collections.Generic;

namespace Nibo.OfxReader
{
    public class BankAccountFile : OfxEntity
    {
        public BankAccountFile(string bankAccountBlock) : base(bankAccountBlock)
        {
            this.Transactions = new List<TransactionFile>();

            this.BankId = this.GetFieldValue("BANKID").Trim();
            this.Number = this.GetFieldValue("ACCTID").Trim();
        }

        public string BankId { get; set; }

        public string Number { get; set; }

        public List<TransactionFile> Transactions { get; set; }
    }
}
