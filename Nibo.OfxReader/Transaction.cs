using System;

namespace Nibo.OfxReader
{
    public class Transaction : OfxEntity
    {
        public Transaction(string transactionBlock) : base(transactionBlock)
        {
            this.Type = TransactionTypeBuilder.GetTransactionType(this.GetFieldValue("TRNTYPE"));
            this.CheckNum = long.Parse(this.GetFieldValue("CHECKNUM"));
            this.FitId = long.Parse(this.GetFieldValue("FITID"));            
            this.Memo = this.GetFieldValue("MEMO");
            this.Amount = long.Parse(this.GetFieldValue("TRNAMT").Replace(".", string.Empty));

            var postDateValue = this.GetFieldValue("DTPOSTED");

            var year = int.Parse(postDateValue.Substring(0, 4));
            var month = int.Parse(postDateValue.Substring(4, 2));
            var day = int.Parse(postDateValue.Substring(6, 2));

            this.PostDate = new DateTime(year, month, day);            
        }

        public TransactionType Type { get; set; }

        public DateTime PostDate { get; set; }

        public long Amount { get; set; }

        public long CheckNum { get; set; }

        public long FitId { get; set; }

        public string Memo { get; set; }
    }
}
