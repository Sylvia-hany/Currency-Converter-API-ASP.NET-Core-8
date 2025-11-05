using CurrencyConvertor.Models;

namespace CurrencyConvertor.Services
{
    public interface IConversionHistoryService
    {
        Task<IEnumerable<Conversion>> GetLastConversionsAsync(int limit = 10);
    }

}
