using Ivas.Analyzer.Core.Dtos.Base;

namespace Ivas.Analyzer.Contracts.Dtos.Analysis
{
    public class FundamentalAnalysisSummaryDto : Dto
    {
        public PastGrowthDto PastGrowth { get; set; }
        public FinancialHealthDto FinancialHealth { get; set; }
        public DividendDto Dividend { get; set; }
    }
}