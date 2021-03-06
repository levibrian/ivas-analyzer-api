using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ivas.Analyzer.Networking.Base.Interfaces
{
    public interface IPolygonBroker
    {
        Task<IEnumerable<T>> Get<T>(string api) where T : class;
    }
}
