using AutoMapper;
using Ivas.Analyzer.Contracts.Dtos.Analysis;
using Ivas.Analyzer.Contracts.Polygon;
using Ivas.Analyzer.Model.Entities;

namespace Ivas.Analyzer.Core.Mappers
{
    public class FundamentalAnalysisProfile : Profile
    {
        public FundamentalAnalysisProfile()
        {
            CreateMap<FinancialsYearly, FundamentalAnalysisEntity>()
                .ForMember(dest => dest.Year, opts => opts.MapFrom(src => src.CalendarDate))
                .ForMember(dest => dest.PastPerformance, opts => opts.MapFrom(src => src))
                .ForMember(dest => dest.FinancialHealth, opts => opts.MapFrom(src => src))
                .ForMember(dest => dest.Dividend, opts => opts.MapFrom(src => src));

            CreateMap<FundamentalAnalysisEntity, FundamentalAnalysisDto>()
                .ReverseMap();
        }
    }
}