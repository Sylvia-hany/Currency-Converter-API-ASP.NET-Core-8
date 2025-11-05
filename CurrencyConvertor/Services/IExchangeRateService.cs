namespace CurrencyConvertor.Services
{
    public interface IExchangeRateService
    {
        Task<Dictionary<string, decimal>> GetHistoricalRatesAsync(string from, string to, int days);
    }
}
