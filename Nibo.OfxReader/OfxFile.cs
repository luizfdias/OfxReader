using Nibo.OfxReader.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nibo.OfxReader
{
    public static class OfxFile
    {
        public static BankAccountFile Reader(string fullFileName)
        {
            BankAccountFile bankAccount = null;

            using (var reader = new StreamReader(fullFileName))
            {
                var bankAccountBlock = new StringBuilder();
                var transactionBlock = new StringBuilder();                

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (line.Contains("<BANKACCTFROM>"))
                    {
                        do
                        {
                            bankAccountBlock.AppendLine(line);
                            line = reader.ReadLine();
                        }
                        while (!line.Contains("</BANKACCTFROM>"));

                        bankAccountBlock.AppendLine(line);

                        bankAccount = new BankAccountFile(bankAccountBlock.ToString());
                    }

                    if (line.Contains("<STMTTRN>"))
                    {
                        if (bankAccount == null)
                        {
                            throw new BankAccountNotFoundException();
                        }


                        do
                        {
                            transactionBlock.AppendLine(line);
                            line = reader.ReadLine();
                        }
                        while (!line.Contains("</STMTTRN>"));

                        transactionBlock.AppendLine(line);

                        bankAccount.Transactions.Add(new TransactionFile(transactionBlock.ToString()));

                        transactionBlock.Clear();
                    }
                }
            }

            return bankAccount;
        }
    }
}
