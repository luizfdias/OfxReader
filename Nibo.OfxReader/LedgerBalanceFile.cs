using System.Collections.Generic;

namespace Nibo.OfxReader
{
    public class LedgerBalanceFile : OfxEntity
    {
        public LedgerBalanceFile(string ledgerBalanceBlock) : base(new List<string> { ledgerBalanceBlock })
        {
            this.Amount = this.GetFieldValue("BALAMT").Trim();
            this.BalanceDate = this.GetFieldValue("DTASOF").Trim();
        }

        public string Amount { get; set; }

        public string BalanceDate { get; set; }
    }
}
