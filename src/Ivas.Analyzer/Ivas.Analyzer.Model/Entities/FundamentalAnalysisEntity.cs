using System;
using Ivas.Analyzer.Model.Base;

namespace Ivas.Analyzer.Model.Entities
{
    public class FundamentalAnalysisEntity : Entity
    {
        /*
         * Analysis features:
         * Past Growth
         * Financial Health
         * Valuation
         * Valuation against current price
         * Future Growth
         * Dividend
         */
        public DateTime Year { get; set; }
        
        public PastGrowthEntity PastPerformance { get; set; }
        
        public FinancialHealthEntity FinancialHealth { get; set; }
        
        public DividendEntity Dividend { get; set; }
    }
}