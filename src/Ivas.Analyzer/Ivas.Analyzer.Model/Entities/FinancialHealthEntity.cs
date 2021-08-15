using System;
using Ivas.Analyzer.Model.Base;

namespace Ivas.Analyzer.Model.Entities
{
    public class FinancialHealthEntity : Entity
    {
        public long CurrentAssets { get; set; }
        
        public long TotalAssets { get; set; }
        
        public long CurrentLiabilities { get; set; }
        
        public long TotalLiabilities { get; set; }

        public long OperatingIncome { get; set; }
        
        public long Debt { get; set; }
        
        public long ShareholdersEquity { get; set; }
        
        public double PriceToEarningsRatio { get; set; }

        /// <summary>
        /// The current ratio is a liquidity ratio that measures a company's ability to pay short-term obligations or those due within one year. 
        /// Formula: Current Assets / Current Liabilities
        /// </summary>
        /// <returns></returns>
        public double CalculateCurrentRatio()
        {
            var crFormula = (double) CurrentAssets / CurrentLiabilities;

            return Math.Round(crFormula, 3);
        }

        /// <summary>
        /// It is a measure of the degree to which a company is financing its operations through debt versus wholly owned funds.
        /// Formula: Total Liabilities / Total Shareholders Equity
        /// </summary>
        /// <returns></returns>
        public double CalculateDebtToEquityRatio()
        {
            var deFormula = ShareholdersEquity > 0 ? 
                (double) TotalLiabilities / ShareholdersEquity : 
                0.00;

            return Math.Round(deFormula, 3);
        }

        /// <summary>
        /// The debt service coverage ratio (DSCR) measures how well a company is able to pay its entire debt service.
        /// Formula: Operating Income / Debt
        /// </summary>
        /// <returns>A double.</returns>
        public double CalculateDebtCoverageRatio()
        {
            var dcrFormula = Debt > 0 ? (double) OperatingIncome / Debt : 0.00;

            return Math.Round(dcrFormula, 3);
        }
    }
}