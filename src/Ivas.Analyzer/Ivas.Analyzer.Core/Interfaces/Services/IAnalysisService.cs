using System.Collections.Generic;
using System.Threading.Tasks;
using Ivas.Analyzer.Contracts.Dtos.Analysis;
using Ivas.Analyzer.Contracts.Requests;
using Ivas.Analyzer.Model.Entities;

namespace Ivas.Analyzer.Core.Interfaces.Services
{
    public interface IAnalysisService
    {
        Task<IEnumerable<FundamentalAnalysisDto>> GetFundamentalAnalysis(FundamentalAnalysisRequest request);

        Task<FundamentalAnalysisSummaryDto> GetSummary(FundamentalAnalysisRequest request);
    }
}