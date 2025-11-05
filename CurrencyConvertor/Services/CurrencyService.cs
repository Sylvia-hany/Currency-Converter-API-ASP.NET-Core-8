using CurrencyConvertor.Models;
using CurrencyConvertor.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CurrencyConvertor.Services
{
    public class CurrencyService: ICurrencyService
    {
        private readonly IConversionRepository _conversionRepo;
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiKey = "WoQURzf3hi4hastbhJqJ4R3RYGiYbqx2";
        private const string BaseUrl = "https://api.apilayer.com/exchangerates_data";

        public CurrencyService(IConversionRepository conversionRepo, IHttpClientFactory httpClientFactory)
        {
            _conversionRepo = conversionRepo;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Conversion> ConvertCurrencyAsync(string from, string to, decimal amount)
        {
            var client = _httpClientFactory.CreateClient();

            // Add the API key to headers
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("apikey", ApiKey);

            // Build the API URL
            var apiUrl = $"{BaseUrl}/convert?from={from}&to={to}&amount={amount}";

            // Make the API call
            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            // Handle cases when "success" = false
            if (!root.GetProperty("success").GetBoolean())
            {
                var error = root.GetProperty("error").GetProperty("info").GetString();
                throw new Exception($"Exchange API Error: {error}");
            }

            // Extract data
            var rate = root.GetProperty("info").GetProperty("rate").GetDecimal();
            var result = root.GetProperty("result").GetDecimal();

            // Save to database
            var conversion = new Conversion
            {
                FromCurrency = from,
                ToCurrency = to,
                Amount = amount,
                Rate = rate,
                Result = result,
                CreatedAt = DateTime.UtcNow
            };

            await _conversionRepo.AddAsync(conversion);
            await _conversionRepo.SaveChangesAsync();

            return conversion;
        }
        public async Task<IEnumerable<Conversion>> GetLastConversionsAsync(int count = 10)
        {
            var conversions = await _conversionRepo.GetLastConversionsAsync(count);
            return conversions;
        }

    }
}
