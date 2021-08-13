using System;

namespace Ivas.Analyzer.Contracts.Dtos.Analysis
{
    public class DividendDto
    {
        public DateTime CalendarDate { get; set; }
        public long NetIncome { get; set; }
        public long MarketCap { get; set; }
        public double EarningsPerShare { get; set; }
        public double DividendsPerShare { get; set; }
        public double DividendYield { get; set; }
        public long TotalDebt { get; set; }
        public long CashAndEquivalents { get; set; }
        public long EBITDA { get; set; }
        public double DividendPayoutRatio { get; set; }
        public double DividendCoverageRatio { get; set; }
        public double NetDebtToEbitda { get; set; }
    }
}