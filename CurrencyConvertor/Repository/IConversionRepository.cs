using CurrencyConvertor.Models;

namespace CurrencyConvertor.Repository
{
    public interface IConversionRepository : IGenericRepository<Conversion>
    {
        Task<IEnumerable<Conversion>> GetLastConversionsAsync(int limit = 10);
    }
}
