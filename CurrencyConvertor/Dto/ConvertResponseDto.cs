namespace CurrencyConvertor.Dto
{
    public class ConvertResponseDto
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public decimal ConvertedAmount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
