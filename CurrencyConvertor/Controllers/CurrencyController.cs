using CurrencyConvertor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConvertor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("convert")]
        public async Task<IActionResult> ConvertCurrency([FromQuery] string from, [FromQuery] string to, [FromQuery] decimal amount)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to) || amount <= 0)
                return BadRequest("Please provide valid 'from', 'to', and 'amount'.");

            try
            {
                var conversion = await _currencyService.ConvertCurrencyAsync(from.ToUpper(), to.ToUpper(), amount);
                return Ok(new
                {
                    from = conversion.FromCurrency,
                    to = conversion.ToCurrency,
                    rate = conversion.Rate,
                    convertedAmount = conversion.Result,
                    timestamp = conversion.CreatedAt
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Conversion failed", error = ex.Message });
            }
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetConversionHistory()
        {
            var history = await _currencyService.GetLastConversionsAsync(10);
            return Ok(history);
        }




    }
}
