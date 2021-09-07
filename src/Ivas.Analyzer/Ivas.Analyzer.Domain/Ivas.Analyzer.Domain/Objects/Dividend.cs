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

        public DateTime LastRecordedDate => _lastFiscalYearDividend.CalendarDate;
        
        public double DividendPerShare => _lastFiscalYearDividend.DividendsPerShare;

        public double DividendYield => _lastFiscalYearDividend.DividendYield;
        public double DividendCoverageRatio => _lastFiscalYearDividend.CalculateDividendCoverageRatio();

        public double DividendPayoutRatio => _lastFiscalYearDividend.CalculateDividendPayoutRatio();
        
        public double NetDebtToEbitda => _lastFiscalYearDividend.CalculateNetDebtToEbitda();

        public bool IsCoverageRatioDesired => DividendCoverageRatio > DesiredCoverageRatio;

        public bool IsDividendYieldNotable => DividendYield > NotableDividendPct;

        public bool IsDividendYieldHigh => DividendYield > HighDividendPct;

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

        public bool IsDividendStable()
        {
            return _dividendHistory.All(x => x.DividendsPerShare > 0);
        }

        public bool IsDividendGrowing()
        {
            var latestDividendEntry = _dividendHistory
                .OrderBy(x => x.CalendarDate.Year)
                .LastOrDefault();
            
            var earliestDividendEntry = _dividendHistory
                .OrderBy(x => x.CalendarDate.Year)
                .FirstOrDefault();
            
            return 
                latestDividendEntry != null && 
                earliestDividendEntry != null && 
                earliestDividendEntry.DividendsPerShare > latestDividendEntry.DividendsPerShare;
        }
    }
}