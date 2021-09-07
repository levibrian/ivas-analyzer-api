using System;
using System.Data.Common;
using Ivas.Analyzer.Model.Base;

namespace Ivas.Analyzer.Model.Entities
{
    public class DividendEntity : Entity
    {
        /*
         Ratios to cover:
            Dividend payout ratio
            Dividend coverage ratio
            Free cash flow to equity
            Net debt to EBITDA
         */
        public long NetIncome { get; set; }
        public long MarketCap { get; set; }
        public double EarningsPerShare { get; set; }
        public double DividendsPerShare { get; set; }
        public double DividendYield { get; set; }
        public long TotalDebt { get; set; }
        public long CashAndEquivalents { get; set; }
        public long Ebitda { get; set; }

        public bool DoesCompanyPayDividends => DividendYield > 0;
        
        /// <summary>
        /// The dividend payout ratio provides an indication of how much money a company is returning to shareholders versus how much it is keeping on hand to reinvest in growth, pay off debt, or add to cash reserves (retained earnings). 
        /// </summary>
        /// <returns>A double.</returns>
        public double CalculateDividendPayoutRatio()
        {
            var retentionRatio = DoesCompanyPayDividends ? 
                (EarningsPerShare - DividendsPerShare) / EarningsPerShare : 
                1.00;
            
            var dprFormula = 1 - retentionRatio;

            return Math.Round(dprFormula, 3);
        }

        /// <summary>
        /// The Dividend Coverage Ratio, also known as dividend cover, is a financial metric that measures the number of times that a company can pay dividends to its shareholders.
        /// The dividend coverage ratio is the ratio of the company’s net income divided by the dividend paid to shareholders.
        /// </summary>
        /// <returns>A double.</returns>
        public double CalculateDividendCoverageRatio()
        {
            var dcrFormula = DoesCompanyPayDividends ? 
                NetIncome / (MarketCap * DividendYield) : 
                0.00;

            return Math.Round(dcrFormula, 3);
        }

        /// <summary>
        /// The net debt-to-EBITDA ratio is a debt ratio that shows how many years it would take for a company to pay back its debt if net debt and EBITDA are held constant.
        /// If a company has more cash than debt, the ratio can be negative.
        /// Formula: (Total Debt - Cash and Equivalents) / EBITDA
        /// </summary>
        /// <returns></returns>
        public double CalculateNetDebtToEbitda()
        {
            var formula = Ebitda > 0 ? 
                (TotalDebt - CashAndEquivalents) / (double) Ebitda : 
                0.00;

            return Math.Round(formula, 3);
        }
    }
}