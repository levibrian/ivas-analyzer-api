using System.Collections.Generic;
using System.Threading.Tasks;
using Ivas.Analyzer.Contracts.Polygon;
using Ivas.Analyzer.Networking.Base;
using Ivas.Analyzer.Networking.Constants;
using Ivas.Analyzer.Networking.Enums;
using Ivas.Analyzer.Networking.Interfaces.Brokers;

namespace Ivas.Analyzer.Networking.Brokers
{
    public class FinancialsBroker : PolygonBroker, IFinancialsBroker
    {
        public async Task<IEnumerable<FinancialsYearly>> GetYearlyByTicker(string ticker)
        {
            var results = await base.Get<FinancialsYearly>(PolygonApiRoutes.GetFinancialsApiRouteByType(ticker, FinancialsTypes.Y));

            return results;
        }
    }
}
