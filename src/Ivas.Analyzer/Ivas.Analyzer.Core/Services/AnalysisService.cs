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
using Ivas.Analyzer.Domain.Objects;
using Ivas.Analyzer.Model.Entities;
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
            var domainEntities = await GetFinancials(request);

            return _mapper.Map<IEnumerable<FundamentalAnalysisEntity>, IEnumerable<FundamentalAnalysisDto>>(domainEntities);
        }

        // This should be moved to a repository.
        public async Task<IEnumerable<FundamentalAnalysisEntity>> GetFinancials(FundamentalAnalysisRequest request)
        {
            var stockData = (await _financialsBroker.GetByTicker(request.Ticker))
                .Take(request.HistoricalYears)
                .ToList();

            if (!stockData.Any())
            {
                throw new DomainException(ErrorMessages.FinancialsNotFound);
            }
            
            return _mapper.Map<IEnumerable<FinancialsYearly>, IEnumerable<FundamentalAnalysisEntity>>(stockData);
        }
        
        public async Task<FundamentalAnalysisSummaryDto> GetSummary(FundamentalAnalysisRequest request)
        {
            var stockFinancials = await GetFinancials(request);

            var financialHealth = new FinancialHealth(stockFinancials.Select(x => x.FinancialHealth));

            var dividendSummary = new Dividend(stockFinancials.Select(x => x.Dividend));
            
            var financialHealthDto = _mapper.Map<FinancialHealth, FinancialHealthDto>(financialHealth);
            
            var dividendSummaryDto = _mapper.Map<Dividend, DividendDto>(dividendSummary);
            
            return new FundamentalAnalysisSummaryDto()
            {
                FinancialHealth = financialHealthDto,
                Dividend = dividendSummaryDto
            };
        }
    }
}