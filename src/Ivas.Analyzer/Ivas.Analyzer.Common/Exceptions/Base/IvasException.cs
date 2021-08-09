using System;
using System.Threading;

namespace Ivas.Analyzer.Common.Exceptions.Base
{
    public class IvasException : Exception
    {
        public IvasException()
        {
            
        }

        public IvasException(string message) : base(message)
        {
        }
    }
}