using System;
using Ivas.Analyzer.Core.Dtos.Base;

namespace Ivas.Analyzer.Core.Dtos.Analysis
{
    /// <summary>
    /// Return on invested capital (ROIC) is a calculation used to assess a company's efficiency at allocating the capital under its control to profitable investments
    /// </summary>
    public class RoicDto : Dto
    {
        public DateTime CalendarDate { get; set; }
        public long FreeCashFlow { get; set; }
        public long LongTermDebt { get; set; }
        public long ShareholdersEquity { get; set; }
        public double ReturnOnInvestedCapital { get; set; }
    }
}
