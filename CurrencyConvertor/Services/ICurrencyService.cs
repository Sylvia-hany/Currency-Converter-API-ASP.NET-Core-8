using CurrencyConvertor.Models;

namespace CurrencyConvertor.Services
{
    public interface ICurrencyService
    {
        Task<Conversion> ConvertCurrencyAsync(string from, string to, decimal amount);


    }
}
