using System.Collections.Generic;

namespace Ivas.Analyzer.Contracts.Dtos.Analysis
{
    public class FundamentalAnalysisDto
    {
        public IEnumerable<PastGrowthDto> PastGrowth { get; set; }
        public IEnumerable<DividendDto> Dividend { get; set; }
    }
}
