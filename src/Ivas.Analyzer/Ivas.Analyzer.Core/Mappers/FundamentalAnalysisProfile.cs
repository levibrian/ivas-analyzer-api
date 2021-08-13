using AutoMapper;
using Ivas.Analyzer.Contracts.Dtos.Analysis;
using Ivas.Analyzer.Contracts.Polygon;
using Ivas.Analyzer.Domain.Entities;

namespace Ivas.Analyzer.Core.Mappers
{
    public class FundamentalAnalysisProfile : Profile
    {
        public FundamentalAnalysisProfile()
        {
            CreateMap<FinancialsYearly, FundamentalAnalysis>()
                .ForMember(dest => dest.Year, opts => opts.MapFrom(src => src.CalendarDate))
                .ForMember(dest => dest.PastPerformance, opts => opts.MapFrom(src => src))
                .ForMember(dest => dest.Dividend, opts => opts.MapFrom(src => src));

            CreateMap<FundamentalAnalysis, FundamentalAnalysisDto>();
        }
    }
}