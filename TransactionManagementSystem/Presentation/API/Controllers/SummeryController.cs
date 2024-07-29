using Microsoft.AspNetCore.Mvc;
using TransactionManagementSystem.Core.Interfaces.Services;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Presentation.API.Controllers
{
    [Route("api/summery")]
    [ApiController]
    public class SummeryController : ControllerBase
    {
        private readonly ISummeryService _summeryService;
        protected ResponseDTO _responseDTO;

        public SummeryController(ISummeryService summeryService)
        {
            _summeryService = summeryService;
            _responseDTO = new ResponseDTO();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> GetSummeries([FromBody] SummeryQueryDTO summeryQuery)
        {
            var summeries = await _summeryService.AccountSummeriesAsync(summeryQuery.StartDate, summeryQuery.EndDate);
            _responseDTO.IsSuccess = true;
            _responseDTO.Result = summeries;
            return Ok(_responseDTO);
        }

        [HttpPost("account")]
        public async Task<ActionResult<ResponseDTO>> GetSummery([FromBody] SummeryQueryDTO summeryQuery)
        {
            var summery = await _summeryService.AccountSummeryAsync(summeryQuery.AccountID, summeryQuery.StartDate, summeryQuery.EndDate);
            _responseDTO.IsSuccess = true;
            _responseDTO.Result = summery;

            return Ok(_responseDTO);
        }
    }
}
