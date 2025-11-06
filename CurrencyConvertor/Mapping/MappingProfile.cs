using AutoMapper;
using CurrencyConvertor.Dto;
using CurrencyConvertor.Models;

namespace CurrencyConvertor.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ✅ 1️⃣ Conversion → ConvertResponseDto
            CreateMap<Conversion, ConvertResponseDto>()
                .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.FromCurrency))
                .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.ToCurrency))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.ConvertedAmount, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.CreatedAt))
                .ReverseMap();

            // ✅ 2️⃣ ConvertRequestDto → Conversion
            CreateMap<ConvertRequestDto, Conversion>()
                .ForMember(dest => dest.FromCurrency, opt => opt.MapFrom(src => src.From))
                .ForMember(dest => dest.ToCurrency, opt => opt.MapFrom(src => src.To))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ReverseMap();

            // ✅ 3️⃣ Conversion → ConversionHistoryDto
            CreateMap<Conversion, ConversionHistoryDto>()
                .ForMember(dest => dest.FromCurrency, opt => opt.MapFrom(src => src.FromCurrency))
                .ForMember(dest => dest.ToCurrency, opt => opt.MapFrom(src => src.ToCurrency))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ReverseMap();

            // ✅ 4️⃣ (Optional) HistoricalRatesDto
            CreateMap<KeyValuePair<string, decimal>, HistoricalRatesDto>()
                .ForMember(dest => dest.Rates, opt => opt.MapFrom(src => new Dictionary<string, decimal> { { src.Key, src.Value } }))
                .ReverseMap();
        }
    }
}
