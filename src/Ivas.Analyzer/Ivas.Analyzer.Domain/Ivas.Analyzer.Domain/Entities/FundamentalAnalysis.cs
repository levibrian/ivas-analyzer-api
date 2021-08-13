using System;

namespace Ivas.Analyzer.Domain.Entities
{
    public class FundamentalAnalysis
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
        public PastGrowth PastPerformance { get; set; }
        public Dividend Dividend { get; set; }
    }
}