using FrontEnd.Core.Interfaces.Services.Transactions;
using FrontEnd.Core.Services.Transactions;
using FrontEnd.Presentation.API.DTOs;
using FrontEnd.Presentation.API.DTOs.Transactions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InTransactionController : ControllerBase
    {
        private readonly IInTransactionService _inTransactionService;

        public InTransactionController(IInTransactionService incomingTransactionService)
        {
            _inTransactionService = incomingTransactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InTransactionDTO>>> GetTransactions()
        {
            List<InTransactionDTO> transactions = new();

            var response = await _inTransactionService.GetIncomingTransactionsAsync<ResponseDTO>();

            if (response != null && response.IsSuccess)
            {
                transactions = JsonConvert.DeserializeObject<List<InTransactionDTO>>(Convert.ToString(response.Result));
            }

            return transactions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InTransactionDTO>> GetTransaction(int id)
        {
            var response = await _inTransactionService.GetTransactionByIdAsync<ResponseDTO>(id);

            if (response != null && response.IsSuccess)
            {
                InTransactionDTO transactionDTO = JsonConvert.DeserializeObject<InTransactionDTO>(Convert.ToString(response.Result)); 
                return Ok(transactionDTO);
            }

            return BadRequest();
        }

        [HttpGet("account/{accountId}")]
        public async Task<ActionResult<IEnumerable<InTransactionDTO>>> GetTransactionsByAccountId(int accountId)
        {
            var response = await _inTransactionService.GetTrsansactionsByAccountId<ResponseDTO>(accountId);

            if (response != null && response.IsSuccess)
            {
                var transactions = JsonConvert.DeserializeObject<IEnumerable<InTransactionDTO>>(Convert.ToString(response.Result));
                return Ok(transactions);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] InTransactionDTO transaction)
        {
            var response = await _inTransactionService.AddIncomingTransactionAsync<ResponseDTO>(transaction);

            if (response != null && response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromBody] InTransactionDTO incomingTransactionDTO, int id)
        {
            if(id != incomingTransactionDTO.Id)
            {
                return BadRequest("Different ids");
            }

            var response = await _inTransactionService.UpdateIncomingTransactionAsync<ResponseDTO>(incomingTransactionDTO, id);

            if(response != null && response.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var response = await _inTransactionService.DeleteIncomingTransactionAsync<ResponseDTO>(id);

            if(response != null && response.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
