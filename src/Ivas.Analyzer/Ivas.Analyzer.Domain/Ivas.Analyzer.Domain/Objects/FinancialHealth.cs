using System;
using System.Collections.Generic;
using System.Linq;
using Ivas.Analyzer.Common.Extensions;
using Ivas.Analyzer.Domain.Enums;
using Ivas.Analyzer.Model.Entities;
using Microsoft.VisualBasic;

namespace Ivas.Analyzer.Domain.Objects
{
    public class FinancialHealth : Base.Domain
    {
        private const double MaximumDebtLevel = 0.40;

        private const double MinimumDebtCoveragePct = 0.20;

        private const double DesiredCurrentRatio = 2.00;

        private const double MinimumCurrentRatio = 1.00;

        private const double MinimumPeRatio = 0.20;

        public DateTime LastRecordedFinancialDate => GetLastRecordedFinancials().CalendarDate;
        
        public double PriceToEarningsRatio => GetLastRecordedFinancials().PriceToEarningsRatio;

        public double CurrentRatio => GetLastRecordedFinancials().CalculateCurrentRatio();
        
        public double DebtCoverageRatio => GetLastRecordedFinancials().CalculateDebtCoverageRatio();
        
        public double DebtToEquityRatio => GetLastRecordedFinancials().CalculateDebtToEquityRatio();
        
        private readonly int _lastFiscalYear;

        private readonly IEnumerable<FinancialHealthEntity> _financialHistory;
        
        public FinancialHealth(IEnumerable<FinancialHealthEntity> financialHistory)
        {
            _financialHistory = financialHistory ?? throw new ArgumentNullException(nameof(financialHistory));
            _lastFiscalYear = DateTime.Now.Year - 2;
        }

        public bool IsDebtToEquitySatisfactory()
        {
            var lastRecordedFinancials = GetLastRecordedFinancials();

            return lastRecordedFinancials != null && lastRecordedFinancials.CalculateDebtToEquityRatio() < MaximumDebtLevel;
        }

        public bool IsDebtReducingOverPastFiveYears()
        {
            var lastFiveYearsFinancials = _financialHistory
                .Where(x => x.CalendarDate.Year > _lastFiscalYear - 5)
                .OrderByDescending(x => x.CalendarDate.Year);
            
            var earliestFinancial = lastFiveYearsFinancials.FirstOrDefault();
            var oldestFinancial = lastFiveYearsFinancials.LastOrDefault();

            if (earliestFinancial == null || oldestFinancial == null)
            {
                return false;
            }

            var earliestDebtToEquityRatio = earliestFinancial.CalculateDebtToEquityRatio();
            var oldestDebtToEquityRatio = oldestFinancial.CalculateDebtToEquityRatio();

            return earliestDebtToEquityRatio < oldestDebtToEquityRatio;
        }

        public bool IsDebtWellCovered()
        {
            var lastRecordedFinancials = GetLastRecordedFinancials();
            
            return lastRecordedFinancials != null &&
                   lastRecordedFinancials.CalculateDebtCoverageRatio() > MinimumDebtCoveragePct;
        }
        
        public bool IsCurrentRatioAcceptable()
        {
            var currentRatioSemaphore = CalculateCurrentRatioOutput();

            return currentRatioSemaphore != Semaphore.Red;
        }

        public bool IsCurrentRatioSatisfactory()
        {
            var currentRatioSemaphore = CalculateCurrentRatioOutput();

            return currentRatioSemaphore == Semaphore.Green;
        }

        public bool IsPeRatioSatisfactory()
        {
            var lastRecordedFinancials = GetLastRecordedFinancials();

            return lastRecordedFinancials != null && lastRecordedFinancials.PriceToEarningsRatio < MinimumPeRatio;
        }
        
        private Semaphore CalculateCurrentRatioOutput()
        {
            var lastRecordedFinancials = GetLastRecordedFinancials();
            var currentRatio = lastRecordedFinancials.CalculateCurrentRatio();

            return currentRatio < MinimumCurrentRatio ? 
                Semaphore.Red :
                MinimumCurrentRatio < currentRatio && currentRatio < DesiredCurrentRatio ? 
                    Semaphore.Yellow : 
                    Semaphore.Green;
        }

        private FinancialHealthEntity GetFinancialsByYear(int year)
        {
            return _financialHistory.FirstOrDefault(x => x.CalendarDate.Year.Equals(year));
        }

        private FinancialHealthEntity GetLastRecordedFinancials()
        {
            return _financialHistory
                .OrderByDescending(x => x.CalendarDate.Year)
                .FirstOrDefault();
        }
    }
}