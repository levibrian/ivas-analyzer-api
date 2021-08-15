using System;
using Ivas.Analyzer.Core.Dtos.Base;

namespace Ivas.Analyzer.Contracts.Dtos.Analysis
{
    public class FinancialHealthDto : Dto
    {
        public DateTime CalendarDate { get; set; }
        
        public double PriceToEarningsRatio { get; set; }

        public double CurrentRatio { get; set; }
        
        public double DebtCoverageRatio { get; set; }
        
        public double DebtToEquityRatio { get; set; }
        
        public bool IsDebtToEquitySatisfactory { get; set; }
        
        public bool IsDebtReducingOverPastFiveYears { get; set; }

        public bool IsDebtWellCovered { get; set; }
        
        public bool IsCurrentRatioAcceptable { get; set; }

        public bool IsCurrentRatioSatisfactory { get; set; }

        public bool IsPeRatioSatisfactory { get; set; }
    }
}