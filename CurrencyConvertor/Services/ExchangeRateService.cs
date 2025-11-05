using System.Text.Json;

namespace CurrencyConvertor.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExchangeRateService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Dictionary<string, decimal>> GetHistoricalRatesAsync(string from, string to, int days)
        {
            var client = _httpClientFactory.CreateClient();

            var endDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var startDate = DateTime.UtcNow.AddDays(-days).ToString("yyyy-MM-dd");

            var apiUrl = $"https://api.exchangerate.host/timeseries?start_date={startDate}&end_date={endDate}&base={from}&symbols={to}";

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var rates = new Dictionary<string, decimal>();
            foreach (var day in root.GetProperty("rates").EnumerateObject())
            {
                var date = day.Name;
                var rate = day.Value.GetProperty(to).GetDecimal();
                rates.Add(date, rate);
            }

            return rates;
        }
    }
}
