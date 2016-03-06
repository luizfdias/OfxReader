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
                var bankStatementFile = OfxFile.Reader(fullFileName);
                var bankAccount = new BankAccount(bankStatementFile.BankAccountFile);

                var bankAccountFromContext = this._bankStatementContext.BankAccounts.AddIfNotExists(bankAccount, x => x.BankId == bankAccount.BankId && x.Number == bankAccount.Number);

                foreach (var transaction in bankAccount.Transactions)
                {
                    transaction.BankAccountId = bankAccountFromContext.BankAccountId;

                    this._bankStatementContext.Transactions.AddIfNotExists(
                        transaction, x =>
                        x.BankAccount.BankAccountId == transaction.BankAccountId &&
                        x.PostDate == transaction.PostDate &&
                        x.Amount == transaction.Amount);
                }


                this._bankStatementContext.SaveChanges();
            });

            this._bankStatementContext.Dispose();

            return true;
        }
    }
}