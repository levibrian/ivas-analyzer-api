using System;
using System.Collections.Generic;
using Ivas.Analyzer.Core.Dtos.Base;

namespace Ivas.Analyzer.Contracts.Dtos.Analysis
{
    public class 
        FundamentalAnalysisDto : Dto
    {
        public DateTime Year { get; set; }
        
        public PastGrowthDto PastPerformance { get; set; }

        public FinancialHealthDto FinancialHealth { get; set; }
        
        public DividendDto Dividend { get; set; }
    }
}
