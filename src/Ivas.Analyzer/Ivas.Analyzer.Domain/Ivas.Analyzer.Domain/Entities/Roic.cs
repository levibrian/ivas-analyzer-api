using System;
using System.Diagnostics.CodeAnalysis;
using Ivas.Analyzer.Domain.Base;

namespace Ivas.Analyzer.Domain.Entities
{
    public class Roic : DomainEntity
    {
        public Roic()
        {
        }
        
        public Roic(DateTime calendarDate, long freeCashFlow, long longTermDebt, long shareholdersEquity)
        {
            CalendarDate = calendarDate;
            FreeCashFlow = freeCashFlow;
            LongTermDebt = longTermDebt;
            ShareholdersEquity = shareholdersEquity;
        }
        
        public DateTime CalendarDate { get; set; }
        public long FreeCashFlow { get; set; }
        public long LongTermDebt { get; set; }
        public long ShareholdersEquity { get; set; }

        public double CalculateRoic()
        {
            var roicFormula = (double) FreeCashFlow / (Math.Abs(LongTermDebt) + ShareholdersEquity) * 10;
            
            return Math.Round(roicFormula, 3);
        }
    }
}