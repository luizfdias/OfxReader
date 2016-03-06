using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nibo.OfxReader.Tests
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void Transaction_DeveConstruirUmaTransacaoAPartirDeUmBloco_DeveRetornarUmaTransacao()
        {
            var transaction = new TransactionFile(@"<STMTTRN><TRNTYPE>DEBIT<DTPOSTED>20140401100000[-03:EST]<TRNAMT>-4500.00<FITID>20140401001<CHECKNUM>20140401001<MEMO>TBI 0304.40719-0     C/C</STMTTRN>");

            var typeExpected = "DEBIT";
            var postDateExpected = "20140401100000[-03:EST]";
            var amountExpected = "-4500.00";
            var FitIdExpected = "20140401001";
            var CheckNumExpected = "20140401001";
            var MemoExpected = "TBI 0304.40719-0     C/C";

            transaction.Type.Should().Be(typeExpected);
            transaction.PostDate.Should().Be(postDateExpected);
            transaction.Amount.Should().Be(amountExpected);
            transaction.FitId.Should().Be(FitIdExpected);
            transaction.CheckNum.Should().Be(CheckNumExpected);
            transaction.Memo.Should().Be(MemoExpected);
        }
    }
}
