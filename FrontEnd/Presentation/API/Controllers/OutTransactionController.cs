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
    public class OutTransactionController : ControllerBase
    {
        private readonly IOutTransactionService _outTransactionService;

        public OutTransactionController(IOutTransactionService outTransactionService)
        {
            _outTransactionService = outTransactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutTransactionDTO>>> GetTransactions()
        {
            List<OutTransactionDTO> transactions = new();

            var response = await _outTransactionService.GetIncomingTransactionsAsync<ResponseDTO>();

            if (response != null && response.IsSuccess)
            {
                transactions = JsonConvert.DeserializeObject<List<OutTransactionDTO>>(Convert.ToString(response.Result));
            }

            return transactions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutTransactionDTO>> GetTransaction(int id)
        {
            var response = await _outTransactionService.GetTransactionByIdAsync<ResponseDTO>(id);

            if (response != null && response.IsSuccess)
            {
                OutTransactionDTO transactionDTO = JsonConvert.DeserializeObject<OutTransactionDTO>(Convert.ToString(response.Result)); 
                return Ok(transactionDTO);
            }

            return BadRequest();
        }

        [HttpGet("account/{accountId}")]
        public async Task<ActionResult<IEnumerable<OutTransactionDTO>>> GetTransactionsByAccountId(int accountId)
        {
            var response = await _outTransactionService.GetTrsansactionsByAccountId<ResponseDTO>(accountId);

            if (response != null && response.IsSuccess)
            {
                var transactions = JsonConvert.DeserializeObject<IEnumerable<OutTransactionDTO>>(Convert.ToString(response.Result));
                return Ok(transactions);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] OutTransactionDTO transaction)
        {
            var response = await _outTransactionService.AddIncomingTransactionAsync<ResponseDTO>(transaction);

            if (response != null && response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromBody] OutTransactionDTO transaction, int id)
        {
            if(id != transaction.Id)
            {
                return BadRequest("Different ids");
            }

            var response = await _outTransactionService.UpdateIncomingTransactionAsync<ResponseDTO>(transaction, id);

            if(response != null && response.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var response = await _outTransactionService.DeleteIncomingTransactionAsync<ResponseDTO>(id);

            if(response != null && response.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
