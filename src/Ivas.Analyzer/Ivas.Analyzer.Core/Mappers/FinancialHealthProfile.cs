using AutoMapper;
using Ivas.Analyzer.Contracts.Dtos.Analysis;
using Ivas.Analyzer.Contracts.Polygon;
using Ivas.Analyzer.Domain.Objects;
using Ivas.Analyzer.Model.Entities;
using Microsoft.VisualBasic;

namespace Ivas.Analyzer.Core.Mappers
{
    public class FinancialHealthProfile : Profile
    {
        public FinancialHealthProfile()
        {
            CreateMap<FinancialsYearly, FinancialHealthEntity>()
                .ForMember(dest => dest.CalendarDate, 
                    opts => opts.MapFrom(src => src.CalendarDate))
                .ForMember(dest => dest.OperatingIncome, 
                    opts => opts.MapFrom(src => src.OperatingIncome))
                .ForMember(dest => dest.CurrentAssets, 
                    opts => opts.MapFrom(src => src.AssetsCurrent))
                .ForMember(dest => dest.TotalAssets, 
                    opts => opts.MapFrom(src => src.Assets))
                .ForMember(dest => dest.CurrentLiabilities,
                    opts => opts.MapFrom(src => src.CurrentLiabilities))
                .ForMember(dest => dest.TotalLiabilities, 
                    opts => opts.MapFrom(src => src.TotalLiabilities))
                .ForMember(dest => dest.Debt, 
                    opts => opts.MapFrom(src => src.DebtUSD))
                .ForMember(dest => dest.ShareholdersEquity, 
                    opts => opts.MapFrom(src => src.ShareholdersEquityUSD))
                .ForMember(dest => dest.PriceToEarningsRatio, 
                    opts => opts.MapFrom(src => src.PriceToEarningsRatio));

            CreateMap<FinancialHealth, FinancialHealthDto>()
                .ForMember(dest => dest.CalendarDate,
                    opts => opts.MapFrom(src => src.LastRecordedFinancialDate));
        }
    }
}