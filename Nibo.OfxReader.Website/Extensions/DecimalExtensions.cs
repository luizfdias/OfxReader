namespace Nibo.OfxReader.Website.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToCurrency(this decimal value)
        {
            return string.Format("{0:C}", value);
        }
    }
}