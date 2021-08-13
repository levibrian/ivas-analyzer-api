using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ivas.Analyzer.Common.Enums;
using Ivas.Analyzer.Common.Exceptions;
using Ivas.Analyzer.Contracts.Dtos.Analysis;
using Ivas.Analyzer.Contracts.Polygon;
using Ivas.Analyzer.Contracts.Requests;
using Ivas.Analyzer.Core.Interfaces.Services;
using Ivas.Analyzer.Domain.Entities;
using Ivas.Analyzer.Networking.Interfaces.Brokers;

namespace Ivas.Analyzer.Core.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IFinancialsBroker _financialsBroker;

        private readonly IMapper _mapper;

        public AnalysisService(IFinancialsBroker financialsBroker, IMapper mapper)
        {
            _financialsBroker = financialsBroker ?? throw new ArgumentNullException(nameof(financialsBroker));
            _mapper = mapper;
        }


        public async Task<IEnumerable<FundamentalAnalysisDto>> GetFundamentalAnalysis(FundamentalAnalysisRequest request)
        {
            var stockData = (await _financialsBroker.GetByTicker(request.Ticker))
                .Where(item => Convert.ToDateTime(item.CalendarDate).Year >= request.FromDate.Year)
                .ToList();

            if (!stockData.Any())
            {
                throw new DomainException(ErrorMessages.FinancialsNotFound);
            }

            var domainEntities =
                _mapper.Map<IEnumerable<FinancialsYearly>, IEnumerable<FundamentalAnalysis>>(stockData);

            return _mapper.Map<IEnumerable<FundamentalAnalysis>, IEnumerable<FundamentalAnalysisDto>>(domainEntities);
        }
    }
}