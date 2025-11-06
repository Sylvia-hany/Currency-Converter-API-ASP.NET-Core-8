using System.Text.Json;

namespace CurrencyConvertor.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiKey = "WoQURzf3hi4hastbhJqJ4R3RYGiYbqx2";
        private const string BaseUrl = "https://api.apilayer.com/exchangerates_data";

        public ExchangeRateService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Dictionary<string, decimal>> GetHistoricalRatesAsync(string from, string to, int days)
        {
            var client = _httpClientFactory.CreateClient();

            // Add API key to header
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("apikey", ApiKey);

            // Build dates
            var endDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var startDate = DateTime.UtcNow.AddDays(-days).ToString("yyyy-MM-dd");

            // Build API URL
            var apiUrl = $"{BaseUrl}/timeseries?start_date={startDate}&end_date={endDate}&base={from}&symbols={to}";

            // Send request
            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            // Check for success = false
            if (!root.GetProperty("success").GetBoolean())
            {
                var error = root.GetProperty("error").GetProperty("info").GetString();
                throw new Exception($"Exchange API Error: {error}");
            }

            // Parse rates
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
