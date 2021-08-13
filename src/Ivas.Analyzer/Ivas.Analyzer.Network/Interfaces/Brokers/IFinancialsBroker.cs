using System.Collections.Generic;
using System.Threading.Tasks;
using Ivas.Analyzer.Contracts.Polygon;

namespace Ivas.Analyzer.Networking.Interfaces.Brokers
{
    public interface IFinancialsBroker
    {
        Task<IEnumerable<FinancialsYearly>> GetByTicker(string ticker);
    }
}
