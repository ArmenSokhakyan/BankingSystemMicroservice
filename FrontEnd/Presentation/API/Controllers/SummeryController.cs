using FrontEnd.Core.Interfaces.Services.Transactions;
using FrontEnd.Presentation.API.DTOs;
using FrontEnd.Presentation.API.DTOs.Transactions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Presentation.API.Controllers
{
    [Route("api/summery")]
    [ApiController]
    public class SummeryController : ControllerBase
    {
        private readonly ISummeryService _summeryService;

        public SummeryController(ISummeryService summeryService)
        {
            _summeryService = summeryService;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<SummeryDTO>>> GetSummeries([FromBody] SummeryQueryDTO summeryQuery)
        {
            List<SummeryDTO> summeries = new();

            var response = await _summeryService.AccountSummeriesAsync<ResponseDTO>(summeryQuery);

            if (response != null && response.IsSuccess)
            {
                summeries = JsonConvert.DeserializeObject<List<SummeryDTO>>(Convert.ToString(response.Result));
                return Ok(summeries);
            }

            return NotFound();
        }

        [HttpPost("account")]
        public async Task<ActionResult<IEnumerable<SummeryDTO>>> GetSummery([FromBody] SummeryQueryDTO summeryQuery)
        {
            SummeryDTO summery = new();

            var response = await _summeryService.AccountSummeryAsync<ResponseDTO>(summeryQuery);

            if(response != null && response.IsSuccess)
            {
                summery = JsonConvert.DeserializeObject<SummeryDTO>(Convert.ToString(response.Result));
                return Ok(summery);
            }

            return NotFound();
        }
    }
}
