using AutoMapper;
using CurrencyConvertor.Dto;
using CurrencyConvertor.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConvertor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IExchangeRateService _exchangeRateService;
        private readonly IConversionHistoryService _conversionHistoryService;
        private readonly IMapper _mapper;

        public CurrencyController(
            ICurrencyService currencyService,
            IExchangeRateService exchangeRateService,
            IConversionHistoryService conversionHistoryService,
            IMapper mapper)
        {
            _currencyService = currencyService;
            _exchangeRateService = exchangeRateService;
            _conversionHistoryService = conversionHistoryService;
            _mapper = mapper;
        }

        // ✅ 1️⃣ Convert Currency Endpoint
        [HttpGet("convert")]
        public async Task<IActionResult> ConvertCurrency([FromQuery] ConvertRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.From) ||
                string.IsNullOrWhiteSpace(request.To) ||
                request.Amount <= 0)
            {
                return BadRequest("Please provide valid 'from', 'to', and 'amount' values.");
            }

            try
            {
                var conversion = await _currencyService.ConvertCurrencyAsync(
                    request.From.ToUpper(),
                    request.To.ToUpper(),
                    request.Amount
                );

                var response = _mapper.Map<ConvertResponseDto>(conversion);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Currency conversion failed", error = ex.Message });
            }
        }

        // ✅ 2️⃣ Get Conversion History
        [HttpGet("history")]
        public async Task<IActionResult> GetConversionHistory([FromQuery] int limit = 10)
        {
            try
            {
                var history = await _conversionHistoryService.GetLastConversionsAsync(limit);
                var historyDto = _mapper.Map<IEnumerable<ConversionHistoryDto>>(history);
                return Ok(historyDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to retrieve conversion history", error = ex.Message });
            }
        }

        // ✅ 3️⃣ Get Historical Exchange Rates
        [HttpGet("historical")]
        public async Task<IActionResult> GetHistoricalRates(
             [FromQuery] string from,
             [FromQuery] string to,
             [FromQuery] int days = 7)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to) || days <= 0)
                return BadRequest("Please provide valid 'from', 'to', and 'days' values.");

            try
            {
                var rates = await _exchangeRateService.GetHistoricalRatesAsync(from.ToUpper(), to.ToUpper(), days);
 
                var result = new HistoricalRatesDto
                {
                    From = from.ToUpper(),
                    To = to.ToUpper(),
                    Days = days,
                    Rates = rates
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to retrieve historical rates", error = ex.Message });
            }
        }

    }
}
