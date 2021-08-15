using AutoMapper;
using Ivas.Analyzer.Contracts.Dtos.Analysis;
using Ivas.Analyzer.Contracts.Polygon;
using Ivas.Analyzer.Model.Entities;

namespace Ivas.Analyzer.Core.Mappers
{
    public class RoicProfile : Profile
    {
        public RoicProfile()
        {
            CreateMap<FinancialsYearly, PastGrowthEntity>()
                .ForMember(dest => dest.CalendarDate, opts => opts.MapFrom(src => src.CalendarDate))
                .ForMember(dest => dest.EarningsBeforeIncomeTax, opts => opts.MapFrom(src => src.EarningsBeforeTax))
                .ForMember(dest => dest.NetIncome, opts => opts.MapFrom(src => src.NetIncome))
                .ForMember(dest => dest.TotalAssets, opts => opts.MapFrom(src => src.Assets))
                .ForMember(dest => dest.ProfitMargin, opts => opts.MapFrom(src => src.ProfitMargin))
                .ForMember(dest => dest.CurrentLiabilities, opts => opts.MapFrom(src => src.CurrentLiabilities))
                .ForMember(dest => dest.ReturnOnInvestedCapital, opts => opts.MapFrom(src => src.ReturnOnInvestedCapital));

            CreateMap<PastGrowthEntity, PastGrowthDto>()
                .ForMember(destinationMember: dest => dest.ReturnOnCapitalEmployed, memberOptions: act => act.MapFrom(mapExpression: src => src.CalculateRoce()))
                .ForMember(destinationMember: dest => dest.ReturnOnAssets, memberOptions: act => act.MapFrom(mapExpression: src => src.CalculateReturnOnAssets()));
        }
    }
}