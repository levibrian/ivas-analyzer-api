using AutoMapper;
using Ivas.Analyzer.Contracts.Polygon;
using Ivas.Analyzer.Core.Dtos.Analysis;
using Ivas.Analyzer.Domain.Entities;

namespace Ivas.Analyzer.Core.Mappers
{
    public class RoicProfile : Profile
    {
        public RoicProfile()
        {
            CreateMap<FinancialsYearly, Roic>()
                .ForMember(dest => dest.CalendarDate, opts => opts.MapFrom(src => src.CalendarDate))
                .ForMember(dest => dest.FreeCashFlow, opts => opts.MapFrom(src => src.FreeCashFlow))
                .ForMember(dest => dest.ShareholdersEquity, opts => opts.MapFrom(src => src.ShareholdersEquityUSD))
                .ForMember(dest => dest.LongTermDebt, opts => opts.MapFrom(src => src.DebtUSD));
            
            CreateMap<Roic, RoicDto>().ForMember(destinationMember: dest => dest.ReturnOnInvestedCapital,
                memberOptions: act => act.MapFrom(mapExpression: src => src.CalculateRoic()));
        }
    }
}