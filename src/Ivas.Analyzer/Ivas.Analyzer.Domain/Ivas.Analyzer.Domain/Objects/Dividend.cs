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
    }
}