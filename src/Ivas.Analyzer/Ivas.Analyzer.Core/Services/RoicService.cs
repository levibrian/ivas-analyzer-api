using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ivas.Analyzer.Common.Enums;
using Ivas.Analyzer.Common.Exceptions;
using Ivas.Analyzer.Contracts.Polygon;
using Ivas.Analyzer.Contracts.Requests;
using Ivas.Analyzer.Core.Dtos.Analysis;
using Ivas.Analyzer.Core.Interfaces.Services;
using Ivas.Analyzer.Domain.Entities;
using Ivas.Analyzer.Networking.Interfaces.Brokers;

namespace Ivas.Analyzer.Core.Services
{
    public class RoicService : IRoicService
    {
        private readonly IFinancialsBroker _financialsBroker;

        private readonly IMapper _mapper;

        public RoicService(IFinancialsBroker financialsBroker, IMapper mapper)
        {
            _financialsBroker = financialsBroker ?? throw new ArgumentNullException(nameof(financialsBroker));
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoicDto>> CalculateRoic(FundamentalAnalysisRequest request)
        {
            var stockData = (await _financialsBroker.GetYearlyByTicker(request.Ticker)).ToList();

            if (!stockData.Any())
            {
                throw new DomainException(ErrorMessages.FinancialsNotFound);
            }
            
            var roicAnalysis = _mapper.Map<IEnumerable<FinancialsYearly>, IEnumerable<Roic>>(stockData);

            return _mapper.Map<IEnumerable<Roic>, IEnumerable<RoicDto>>(roicAnalysis);
        }
    }
}
