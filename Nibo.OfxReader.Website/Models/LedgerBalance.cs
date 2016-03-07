using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nibo.OfxReader.Website.Models
{
    public class LedgerBalance
    {
        public LedgerBalance()
        {

        }

        public LedgerBalance(LedgerBalanceFile ledgerBalanceFile)
        {
            this.Amount = long.Parse(ledgerBalanceFile.Amount.Replace(".", string.Empty).Replace(",", string.Empty));

            var balanceDateValue = ledgerBalanceFile.BalanceDate;

            var year = int.Parse(balanceDateValue.Substring(0, 4));
            var month = int.Parse(balanceDateValue.Substring(4, 2));
            var day = int.Parse(balanceDateValue.Substring(6, 2));

            this.BalanceDate = new DateTime(year, month, day);
        }

        [Key]
        public long LedgerBalanceId { get; set; }

        public long Amount { get; set; }

        public DateTime BalanceDate { get; set; }

        public int BankStatementId { get; set; }

        [ForeignKey("BankStatementId")]
        public virtual BankStatement BankStatement { get; set; }
    }
}