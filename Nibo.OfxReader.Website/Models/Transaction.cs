using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nibo.OfxReader.Website.Models
{
    public class Transaction
    {
        public Transaction()
        {

        }

        public Transaction(TransactionFile transactionFile)
        {
            this.Type = TransactionTypeBuilder.GetTransactionType(transactionFile.Type);
            this.CheckNum = long.Parse(transactionFile.CheckNum);
            this.FitId = long.Parse(transactionFile.FitId);
            this.Memo = transactionFile.Memo;
            this.Amount = long.Parse(transactionFile.Amount.Replace(".", string.Empty).Replace(",", string.Empty));

            var postDateValue = transactionFile.PostDate;

            var year = int.Parse(postDateValue.Substring(0, 4));
            var month = int.Parse(postDateValue.Substring(4, 2));
            var day = int.Parse(postDateValue.Substring(6, 2));

            this.PostDate = new DateTime(year, month, day);
        }

        [Key]
        public long TransactionId { get; set; }

        public TransactionType Type { get; set; }

        public DateTime PostDate { get; set; }

        public long Amount { get; set; }

        public long CheckNum { get; set; }

        public long FitId { get; set; }

        public string Memo { get; set; }

        public int BankStatementId { get; set; }

        [ForeignKey("BankStatementId")]
        public virtual BankStatement BankStatement { get; set; }
    }
}