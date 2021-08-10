using System;

namespace Ivas.Analyzer.Contracts.Requests
{
    public class FundamentalAnalysisRequest
    {
        public DateTime FromDate { get; set; }
        public string Ticker { get; set; }
    }
}