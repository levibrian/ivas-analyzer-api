using System;
using AutoMapper;
using Ivas.Analyzer.Core.Interfaces.Services;
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
    }
}