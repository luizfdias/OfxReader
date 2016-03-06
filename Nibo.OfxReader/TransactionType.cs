namespace Nibo.OfxReader
{
    public enum TransactionType
    {
        Debit = 1,
        Credit = 2,
        Other = 99
    }

    public class TransactionTypeBuilder
    {
        public static TransactionType GetTransactionType(string transactionType)
        {
            switch (transactionType)
            {
                case "DEBIT":
                    return TransactionType.Debit;
                case "CREDIT":
                    return TransactionType.Credit;
                default:
                    return TransactionType.Other;
            }
        }
    }
}
