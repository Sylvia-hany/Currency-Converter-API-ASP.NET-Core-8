using CurrencyConvertor.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConvertor.Repository
{
    public class ConversionRepository : GenericRepository<Conversion>, IConversionRepository
    {
        public ConversionRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Conversion>> GetLastConversionsAsync(int limit = 10)
        {
            return await _dbSet
                .Where(c => !c.IsDeleted)
                .OrderByDescending(c => c.CreatedAt)
                .Take(limit)
                .ToListAsync();
        }
    }
}
