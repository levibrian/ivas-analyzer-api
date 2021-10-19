using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ivas.Analyzer.Contracts.Polygon.Base
{
    public class PolygonRoot<T> where T : class
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<T> Results { get; set; }
    }
}
