namespace CurrencyConvertor.Dto
{
    public class ConversionHistoryDto
    {
        public string FromCurrency { get; set; } = string.Empty;
        public string ToCurrency { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal Result { get; set; }
        public decimal Rate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
