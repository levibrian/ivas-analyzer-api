using Ivas.Analyzer.Common.Enums;
using Ivas.Analyzer.Common.Exceptions.Base;

namespace Ivas.Analyzer.Common.Exceptions
{
    public class DomainException : IvasException
    {
        private readonly ErrorMessages _errorKey;

        public override string Message { get; }
        
        public DomainException(string message) : base(message)
        {
        }

        public DomainException(ErrorMessages errorKey)
        {
            _errorKey = errorKey;
            Message = errorKey.ToString();
        }
    }
}