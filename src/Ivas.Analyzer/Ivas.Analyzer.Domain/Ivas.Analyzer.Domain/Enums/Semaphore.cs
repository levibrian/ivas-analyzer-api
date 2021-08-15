using System.ComponentModel;

namespace Ivas.Analyzer.Domain.Enums
{
    public enum Semaphore
    {
        [Description("Green")]
        Green = 1,
        
        [Description("Yellow")]
        Yellow,
        
        [Description("Red")]
        Red
    }
}