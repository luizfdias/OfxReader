using System;
using System.Collections.Generic;

namespace Nibo.OfxReader
{
    public class TransactionFile : OfxEntity
    {
        public TransactionFile(string transactionBlock) : base(new List<string> { transactionBlock })
        {
            this.Type = this.GetFieldValue("TRNTYPE").Trim();
            this.CheckNum = this.GetFieldValue("CHECKNUM").Trim();
            this.FitId = this.GetFieldValue("FITID").Trim();
            this.Memo = this.GetFieldValue("MEMO").Trim();
            this.Amount = this.GetFieldValue("TRNAMT").Trim();
            this.PostDate = this.GetFieldValue("DTPOSTED").Trim();
        }

        public string Type { get; set; }

        public string PostDate { get; set; }

        public string Amount { get; set; }

        public string CheckNum { get; set; }

        public string FitId { get; set; }

        public string Memo { get; set; }
    }
}
