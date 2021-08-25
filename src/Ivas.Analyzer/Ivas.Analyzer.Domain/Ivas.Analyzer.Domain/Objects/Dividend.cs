using System;
using System.Collections.Generic;
using System.Linq;
using Ivas.Analyzer.Model.Entities;

namespace Ivas.Analyzer.Domain.Objects
{
    public class Dividend : Base.Domain
    {
        public const double NotableDividendPct = 0.0131;
        
        public const double HighDividendPct = 0.0351;

        public const double DesiredCoverageRatio = 0.6;
        
        public bool IsDividendStable { get; set; }
        
        public bool IsDividendGrowing { get; set; }

        public double DividendPerShare { get; set; }

        public double DividendYield { get; set; }
        
        public double DividendCoverageRatio { get; set; }

        public double DividendPayoutRatio { get; set; }

        private readonly IEnumerable<DividendEntity> _dividendHistory;

        private readonly DividendEntity _lastFiscalYearDividend;
        
        private readonly int _lastFiscalYear;
        
        public Dividend(IEnumerable<DividendEntity> dividendHistory)
        {
            _dividendHistory = dividendHistory ?? throw new ArgumentNullException(nameof(dividendHistory));

            _lastFiscalYearDividend = dividendHistory
                .OrderByDescending(x => x.CalendarDate.Year)
                .FirstOrDefault();
            
            _lastFiscalYear = DateTime.Now.Year - 2;
        }
        
        
    }
}