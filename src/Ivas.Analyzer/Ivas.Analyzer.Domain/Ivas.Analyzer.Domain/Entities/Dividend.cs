using System;
using Ivas.Analyzer.Domain.Base;

namespace Ivas.Analyzer.Domain.Entities
{
    public class Dividend : DomainEntity
    {
        /*
         Ratios to cover:
            Dividend payout ratio
            Dividend coverage ratio
            Free cash flow to equity
            Net debt to EBITDA
         */

        public DateTime CalendarDate { get; set; }
        public long NetIncome { get; set; }
        public long MarketCap { get; set; }
        public double EarningsPerShare { get; set; }
        public double DividendsPerShare { get; set; }
        public double DividendYield { get; set; }
        public long TotalDebt { get; set; }
        public long CashAndEquivalents { get; set; }
        public long EBITDA { get; set; }
        
        
        
        /// <summary>
        /// The dividend payout ratio provides an indication of how much money a company is returning to shareholders versus how much it is keeping on hand to reinvest in growth, pay off debt, or add to cash reserves (retained earnings). 
        /// </summary>
        /// <returns>A double.</returns>
        public double CalculateDividendPayoutRatio()
        {
            var retentionRatio = (EarningsPerShare - DividendsPerShare) / EarningsPerShare;
            
            return 1 - retentionRatio;
        }

        /// <summary>
        /// The Dividend Coverage Ratio, also known as dividend cover, is a financial metric that measures the number of times that a company can pay dividends to its shareholders.
        /// The dividend coverage ratio is the ratio of the company’s net income divided by the dividend paid to shareholders.
        /// </summary>
        /// <returns>A double.</returns>
        public double CalculateDividendCoverageRatio()
        {
            var dcrFormula = NetIncome / (MarketCap * DividendYield);

            return dcrFormula;
        }

        /// <summary>
        /// The net debt-to-EBITDA ratio is a debt ratio that shows how many years it would take for a company to pay back its debt if net debt and EBITDA are held constant.
        /// If a company has more cash than debt, the ratio can be negative.
        /// Formula: (Total Debt - Cash and Equivalents) / EBITDA
        /// </summary>
        /// <returns></returns>
        public double CalculateNetDebtToEbitda()
        {
            var formula = (double) (TotalDebt - CashAndEquivalents) / EBITDA;

            return formula;
        }
    }
}