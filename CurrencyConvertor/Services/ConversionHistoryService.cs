using CurrencyConvertor.Models;
using CurrencyConvertor.Repository;

namespace CurrencyConvertor.Services
{
    public class ConversionHistoryService : IConversionHistoryService
    {
        private readonly IConversionRepository _conversionRepo;

        public ConversionHistoryService(IConversionRepository conversionRepo)
        {
            _conversionRepo = conversionRepo;
        }

        public async Task<IEnumerable<Conversion>> GetLastConversionsAsync(int count = 10)
        {
            var conversions = await _conversionRepo.GetLastConversionsAsync(count);
            return conversions;
        }
      
    }
}