using AutoMapper;
using Ivas.Analyzer.Contracts.Dtos.Analysis;
using Ivas.Analyzer.Contracts.Polygon;
using Ivas.Analyzer.Domain.Objects;
using Ivas.Analyzer.Model.Entities;

namespace Ivas.Analyzer.Core.Mappers
{
    public class DividendProfile : Profile
    {
        public DividendProfile()
        {
            CreateMap<FinancialsYearly, DividendEntity>()
                .ForMember(dest => dest.CalendarDate, 
                    opts => opts.MapFrom(src => src.CalendarDate))
                .ForMember(dest => dest.NetIncome, 
                    opts => opts.MapFrom(src => src.NetIncome))
                .ForMember(dest => dest.MarketCap, 
                    opts => opts.MapFrom(src => src.MarketCapitalization))
                .ForMember(dest => dest.DividendYield, 
                    opts => opts.MapFrom(src => src.DividendYield))
                .ForMember(dest => dest.DividendsPerShare,
                    opts => opts.MapFrom(src => src.DividendsPerBasicCommonShare))
                .ForMember(dest => dest.EarningsPerShare, 
                    opts => opts.MapFrom(src => src.EarningsPerBasicShareUSD))
                .ForMember(dest => dest.TotalDebt, 
                    opts => opts.MapFrom(src => src.DebtUSD))
                .ForMember(dest => dest.CashAndEquivalents, 
                    opts => opts.MapFrom(src => src.CashAndEquivalentsUSD))
                .ForMember(dest => dest.Ebitda, 
                    opts => opts.MapFrom(src => src.EarningsBeforelongerestTaxesDepreciationAmortizationUSD));

            CreateMap<Dividend, DividendDto>().ReverseMap();
        }
    }
}