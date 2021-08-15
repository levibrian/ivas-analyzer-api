using System;
using Ivas.Analyzer.Core.Dtos.Base;

namespace Ivas.Analyzer.Contracts.Dtos.Analysis
{
    /// <summary>
    /// Return on invested capital (ROIC) is a calculation used to assess a company's efficiency at allocating the capital under its control to profitable investments
    /// </summary>
    public class PastGrowthDto : Dto
    {
        public DateTime CalendarDate { get; set; }

        public double ReturnOnInvestedCapital { get; set; }
        public double ReturnOnCapitalEmployed { get; set; }
        public double ReturnOnAssets { get; set; }

        // public string RoicPretty => $"{ReturnOnInvestedCapital * 100}%";
        // public string RocePretty => $"{ReturnOnCapitalEmployed * 100}%";
        // public string RoaPretty => $"{ReturnOnAssets * 100}%";
    }
}
