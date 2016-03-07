using System;

namespace Nibo.OfxReader.Website.Models.Reports
{
    public class BankPosting
    {
        public DateTime PostDate { get; set; }

        public decimal Amount { get; set; }

        public string Memo { get; set; }

        public long CheckNum { get; set; }

        public bool IsBalance { get; set; }
    }
}