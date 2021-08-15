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
            /*
             * ROCE can be especially useful when comparing the performance of companies in capital-intensive sectors, such as utilities and telecoms.
             * This is because unlike other fundamentals such as return on equity (ROE), which only analyzes profitability related to a company’s shareholders’ equity, ROCE considers debt and equity.
             * This can help neutralize financial performance analysis for companies with significant debt.
             */
            
            var roceFormula = (double) EarningsBeforeIncomeTax / (TotalAssets - CurrentLiabilities);

            return Math.Round(roceFormula, 3);
        }

        /// <summary>
        /// Return on assets (ROA) is an indicator of how profitable a company is relative to its total assets. ROA gives a manager, investor, or analyst an idea as to how efficient a company's management is at using its assets to generate earnings.
        /// </summary>
        /// <returns>A double.</returns>
        public double CalculateReturnOnAssets()
        {
            /*
             * Higher ROA indicates more asset efficiency.
             * For example, pretend Spartan Sam and Fancy Fran both start hot dog stands.
             * Sam spends $1,500 on a bare-bones metal cart, while Fran spends $15,000 on a zombie apocalypse-themed unit, complete with costume.
             * Let's assume that those were the only assets each firm deployed. If over some given period Sam had earned $150 and Fran had earned $1,200, Fran would have the more valuable business but Sam would have the more efficient one.
             * Using the formula, we see Sam’s simplified ROA is $150 / $1,500 = 10%, while Fran’s simplified ROA is $1,200/$15,000 = 8%.
             */
            
            var roaFormula = (double) NetIncome / TotalAssets;

            return Math.Round(roaFormula, 3);
        }
    }
}