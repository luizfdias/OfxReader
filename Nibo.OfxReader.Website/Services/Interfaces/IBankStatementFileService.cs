using System.Threading.Tasks;

namespace Nibo.OfxReader.Website.Services.Interfaces
{
    public interface IBankStatementFileService
    {
        Task<bool> ProcessFileAsync(string fullFileName);
    }
}