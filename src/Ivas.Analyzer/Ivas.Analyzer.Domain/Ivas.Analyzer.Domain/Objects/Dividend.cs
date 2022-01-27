using System;
using System.Collections.Generic;
using System.Linq;
using Ivas.Analyzer.Domain.Base;
using Ivas.Analyzer.Model.Entities;

namespace Ivas.Analyzer.Domain.Objects
{
    public class Dividend : DomainEntity
    {
        public const double NotableDividendPct = 0.0132;
        
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

            if (_lastFiscalYearDividend == null)
            {
                throw new ArgumentNullException(nameof(_lastFiscalYearDividend));
            }
            
            _lastFiscalYear = _lastFiscalYearDividend != null ? 
                _lastFiscalYearDividend.CalendarDate.Year : 
                DateTime.Now.Year - 2;
        }

        public bool IsDividendStable()
        {
            var isDividendStable = _dividendHistory.Count(x => x.DividendsPerShare > 0);
            
            return isDividendStable >= 8;
        }

        public bool IsDividendGrowing()
        {
            var orderedDividendHistory = _dividendHistory
                .OrderByDescending(x => x.CalendarDate.Year)
                .ToList();
            
            var oldestDividendEntry = orderedDividendHistory
                .LastOrDefault();
            
            var earliestDividendEntry = orderedDividendHistory
                .FirstOrDefault();
            
            return 
                oldestDividendEntry != null && 
                earliestDividendEntry != null && 
                earliestDividendEntry.DividendsPerShare > oldestDividendEntry.DividendsPerShare;
        }
    }
}