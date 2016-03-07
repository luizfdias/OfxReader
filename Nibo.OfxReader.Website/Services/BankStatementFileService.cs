using System.Threading.Tasks;
using Nibo.OfxReader.Website.Services.Interfaces;
using Nibo.OfxReader.Website.Datalayer;
using Nibo.OfxReader.Website.Models;
using Nibo.OfxReader.Website.Datalayer.Extensions;

namespace Nibo.OfxReader.Website.Services
{
    public class BankStatementFileService : IBankStatementFileService
    {
        private BankStatementContext _bankStatementContext;

        public BankStatementFileService(BankStatementContext bankStatementContext)
        {
            this._bankStatementContext = bankStatementContext;
        }

        public async Task<bool> ProcessFileAsync(string fullFileName)
        {
            await Task.Run(() =>
            {
                var bankStatementFile = OfxFile.Read(fullFileName);
                var bankStatement = new BankStatement(bankStatementFile);                

                var bankStatementFromContext = this._bankStatementContext.BankStatements.AddIfNotExists(bankStatement, x => x.BankId == bankStatement.BankId && x.Number == bankStatement.Number);

                foreach (var transaction in bankStatement.Transactions)
                {
                    transaction.BankStatementId = bankStatementFromContext.BankStatementId;

                    this._bankStatementContext.Transactions.AddIfNotExists(
                        transaction, x =>
                        x.BankStatement.BankStatementId == transaction.BankStatementId &&
                        x.PostDate == transaction.PostDate &&
                        x.Amount == transaction.Amount);
                }

                foreach (var ledgerBalance in bankStatement.LedgerBalances)
                {
                    ledgerBalance.BankStatementId = bankStatementFromContext.BankStatementId;

                    this._bankStatementContext.LedgerBalances.AddIfNotExists(ledgerBalance, x =>
                        x.BalanceDate == ledgerBalance.BalanceDate &&
                        x.BankStatement.BankStatementId == ledgerBalance.BankStatementId);
                }


                this._bankStatementContext.SaveChanges();
            });

            this._bankStatementContext.Dispose();

            return true;
        }
    }
}