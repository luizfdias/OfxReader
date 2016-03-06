using System.IO;

namespace Nibo.OfxReader.Tests.Helpers
{
    public static class OfxFileCreater
    {
        public static void Create(string fullFileName, string content)
        {
            File.WriteAllText(fullFileName, content);
        }
    }
}
