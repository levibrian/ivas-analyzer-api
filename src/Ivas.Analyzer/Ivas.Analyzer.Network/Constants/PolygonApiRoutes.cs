using Ivas.Analyzer.Networking.Enums;

namespace Ivas.Analyzer.Networking.Constants
{
    public static class PolygonApiRoutes
    {
        internal const string ApiBaseRoute = "https://api.polygon.io/v2/reference";

        public static string FinancialsApiRoute
        {
            get
            {
                return $"{ApiBaseRoute}/financials";
            }
        }

        public static string GetFinancialsApiRouteByType(string ticker, FinancialsTypes type)
        {
            return $"{FinancialsApiRoute}/{ticker}?apiKey={PolygonApiConfiguration.ApiKey}&type={type}";
        }
    }
}
