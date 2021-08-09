using System.Collections.Generic;
using System.Threading.Tasks;
using Ivas.Analyzer.Core.Dtos.Analysis;

namespace Ivas.Analyzer.Core.Interfaces.Services
{
    public interface IRoicService
    {
        Task<IEnumerable<RoicDto>> CalculateRoic(string ticker);
    }
}
