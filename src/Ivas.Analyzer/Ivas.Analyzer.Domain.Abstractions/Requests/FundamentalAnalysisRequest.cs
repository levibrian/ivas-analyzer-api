using System;

namespace Ivas.Analyzer.Contracts.Requests
{
    public class FundamentalAnalysisRequest
    {
        public DateTime FromDate { get; set; }
        public string Ticker { get; set; }

        public int HistoricalYears => DateTime.Now.Year - FromDate.Year;
    }
}