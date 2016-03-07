using System;
using System.Collections.Generic;
using System.Linq;

namespace Nibo.OfxReader.Website.Models.Reports
{
    public class BankStatementDetail
    {
        public BankStatementDetail()
        {
            this.BankPostingList = new List<BankPosting>();
        }

        public BankStatementDetail(BankStatement bankStatement)
        {
            this.BankPostingList = new List<BankPosting>();

            this.BankId = bankStatement.BankId;
            this.AccountNumber = bankStatement.Number;

            bankStatement.Transactions.ToList().ForEach(x => BankPostingList.Add(new BankPosting
            {
                Amount = Convert.ToDecimal(x.Amount) / 100,
                CheckNum = x.CheckNum,
                IsBalance = false,
                Memo = x.Memo,
                PostDate = x.PostDate
            }));

            bankStatement.LedgerBalances.ToList().ForEach(x => BankPostingList.Add(new BankPosting
            {
                Amount = Convert.ToDecimal(x.Amount) / 100,                
                IsBalance = true,                
                PostDate = x.BalanceDate
            }));
        }

        public int BankId { get; set; }

        public long AccountNumber { get; set; }

        public List<BankPosting> BankPostingList { get; set; }
    }
}