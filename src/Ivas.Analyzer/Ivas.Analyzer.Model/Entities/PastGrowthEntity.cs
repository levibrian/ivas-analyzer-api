using System;
using Ivas.Analyzer.Model.Base;

namespace Ivas.Analyzer.Model.Entities
{
    public class PastGrowthEntity : Entity
    {
        /*
         * What do we analyze in Past Growth?
         * *** Return on Equity
         * *** Earnings:
         * ****** Earnings Trend (This will be made in the analysis summary)
         * ****** Profit Margins 
         * ****** Earnings vs Industry (Is it necessary?) 
         * *** Return on Assets
         * *** Return on Capital Employed
         * *** Return on Invested Capital
         */
        public long EarningsBeforeIncomeTax { get; set; }
        
        public long NetIncome { get; set; }
        
        public long TotalAssets { get; set; }
        
        public long CurrentLiabilities { get; set; }
        
        public double ReturnOnInvestedCapital { get; set; }
        
        public double ProfitMargin { get; set; }
        
        /// <summary>
        /// Return on capital employed (ROCE) is a financial ratio that can be used in assessing a company's profitability and capital efficiency.
        /// In other words, this ratio can help to understand how well a company is generating profits from its capital as it is put to use.
        /// </summary>
        /// <returns>A double.</returns>
        public double CalculateRoce()
        {
            var roceFormula = (double) EarningsBeforeIncomeTax / (TotalAssets - CurrentLiabilities);

            return Math.Round(roceFormula, 3);
        }

        /// <summary>
        /// Return on assets (ROA) is an indicator of how profitable a company is relative to its total assets. ROA gives a manager, investor, or analyst an idea as to how efficient a company's management is at using its assets to generate earnings.
        /// </summary>
        /// <returns>A double.</returns>
        public double CalculateReturnOnAssets()
        {
            var roaFormula = (double) NetIncome / TotalAssets;

            return Math.Round(roaFormula, 3);
        }
    }
}