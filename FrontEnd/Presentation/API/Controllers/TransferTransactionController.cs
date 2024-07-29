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
    public class TransferTransactionController : ControllerBase
    {
        private readonly ITransferTransactionService _transferTransactionService;

        public TransferTransactionController(ITransferTransactionService transferTransactionService)
        {
            _transferTransactionService = transferTransactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferTransactionDTO>>> GetTransactions()
        {
            List<TransferTransactionDTO> transactions = new();

            var response = await _transferTransactionService.GetIncomingTransactionsAsync<ResponseDTO>();

            if (response != null && response.IsSuccess)
            {
                transactions = JsonConvert.DeserializeObject<List<TransferTransactionDTO>>(Convert.ToString(response.Result));
            }

            return transactions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransferTransactionDTO>> GetTransaction(int id)
        {
            var response = await _transferTransactionService.GetTransactionByIdAsync<ResponseDTO>(id);

            if (response != null && response.IsSuccess)
            {
                TransferTransactionDTO transactionDTO = JsonConvert.DeserializeObject<TransferTransactionDTO>(Convert.ToString(response.Result)); 
                return Ok(transactionDTO);
            }

            return BadRequest();
        }

        [HttpGet("sourceAccount/{accountId}")]
        public async Task<ActionResult<IEnumerable<TransferTransactionDTO>>> GetTransactionsBySourceAccountId(int accountId)
        {
            var response = await _transferTransactionService.GetTrsansactionsBySourceAccountId<ResponseDTO>(accountId);

            if (response != null && response.IsSuccess)
            {
                var transactions = JsonConvert.DeserializeObject<IEnumerable<TransferTransactionDTO>>(Convert.ToString(response.Result));
                return Ok(transactions);
            }

            return BadRequest();
        }

        [HttpGet("destinationAccount/{accountId}")]
        public async Task<ActionResult<IEnumerable<TransferTransactionDTO>>> GetTransactionsByDestinationAccountId(int accountId)
        {
            var response = await _transferTransactionService.GetTrsansactionsByDestinationAccountId<ResponseDTO>(accountId);

            if (response != null && response.IsSuccess)
            {
                var transactions = JsonConvert.DeserializeObject<IEnumerable<TransferTransactionDTO>>(Convert.ToString(response.Result));
                return Ok(transactions);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] TransferTransactionDTO transaction)
        {
            var response = await _transferTransactionService.AddIncomingTransactionAsync<ResponseDTO>(transaction);

            if (response != null && response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromBody] TransferTransactionDTO transaction, int id)
        {
            if(id != transaction.Id)
            {
                return BadRequest("Different ids");
            }

            var response = await _transferTransactionService.UpdateIncomingTransactionAsync<ResponseDTO>(transaction, id);

            if(response != null && response.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var response = await _transferTransactionService.DeleteIncomingTransactionAsync<ResponseDTO>(id);

            if(response != null && response.IsSuccess)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
