namespace CurrencyConvertor.Models
{
    public class Conversion:BaseEntity
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }

        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal Result { get; set; }
    }
}
