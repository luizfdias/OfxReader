using System.Collections.Generic;

namespace Nibo.OfxReader
{
    public class BankAccount : OfxEntity
    {
        public BankAccount(string bankAccountBlock) : base(bankAccountBlock)
        {
            this.Transactions = new List<Transaction>();

            this.BankId = int.Parse(this.GetFieldValue("BANKID"));
            this.Number = long.Parse(this.GetFieldValue("ACCTID"));
        }

        public int BankId { get; set; }

        public long Number { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
