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
        private readonly IRoicService _roicService;

        public AnalysisController(IAnalysisService analysisService, IRoicService roicService)
        {
            _analysisService = analysisService ?? throw new ArgumentNullException(nameof(analysisService));
            _roicService = roicService ?? throw new ArgumentNullException(nameof(roicService));
        }

        [HttpGet("full")]
        public async Task<IActionResult> GetFull([FromBody] FundamentalAnalysisRequest request)
        {
            return Ok();
        }
        
        [HttpGet("roic")]
        public async Task<IActionResult> GetRoic([FromBody] FundamentalAnalysisRequest request)
        {
            var roicAnalysis = await _roicService.CalculateRoic(request);

            return Ok(roicAnalysis);
        }
    }
}