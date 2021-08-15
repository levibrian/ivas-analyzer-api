using System;
using System.Threading.Tasks;
using Ivas.Analyzer.Contracts.Requests;
using Ivas.Analyzer.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ivas.Analyzer.Api.Controllers
{
    [Route("api/[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;

        public AnalysisController(IAnalysisService analysisService)
        {
            _analysisService = analysisService ?? throw new ArgumentNullException(nameof(analysisService));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] FundamentalAnalysisRequest request)
        {
            //var fundamentalAnalysis = await _analysisService.GetFundamentalAnalysis(request);

            var financialTest = await _analysisService.GetSummary(request);
            
            return Ok(financialTest);
        }
    }
}