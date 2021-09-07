using System;
using Ivas.Analyzer.Core.Dtos.Base;

namespace Ivas.Analyzer.Contracts.Dtos.Analysis
{
    public class DividendDto : Dto
    {
        public DateTime CalendarDate { get; set; }
        
        public double DividendsPerShare { get; set; }
        
        public double DividendYield { get; set; }
        
        public double DividendPayoutRatio { get; set; }
        
        public double DividendCoverageRatio { get; set; }
        
        public double NetDebtToEbitda { get; set; }

        public bool IsCoverageRatioDesired { get; set; }

        public bool IsDividendYieldNotable { get; set; }

        public bool IsDividendYieldHigh { get; set; }
        
        public bool IsDividendStable { get; set; }

        public bool IsDividendGrowing { get; set; }
    }
}