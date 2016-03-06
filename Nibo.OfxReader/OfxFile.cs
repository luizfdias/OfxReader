using Nibo.OfxReader.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nibo.OfxReader
{
    public static class OfxFile
    {
        public static BankAccount Reader(string fullFileName)
        {
            BankAccount bankAccount = null;

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

                        bankAccount = new BankAccount(bankAccountBlock.ToString());
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

                        bankAccount.Transactions.Add(new Transaction(transactionBlock.ToString()));
                    }
                }
            }

            return bankAccount;
        }
    }
}
