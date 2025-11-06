namespace CurrencyConvertor.Dto
{
    public class HistoricalRatesDto
    {
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public int Days { get; set; }
        public Dictionary<string, decimal> Rates { get; set; } = new();
    }
}
