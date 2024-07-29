using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Core.Interfaces.Services;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    public class TransferTransactionController : ControllerBase
    {
        private readonly ITransferTransactionService _transferTransactionService;
        private readonly IMapper _mapper;
        protected ResponseDTO _responseDTO;

        public TransferTransactionController(ITransferTransactionService transferTransactionService, IMapper mapper)
        {
            _transferTransactionService = transferTransactionService;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetTransactions()
        {
            var transactions = await _transferTransactionService.GetTransactionsAsync();
            var transactionsDTO = _mapper.Map<IEnumerable<TransferTransactionDTO>>(transactions);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionsDTO;
            return Ok(_responseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddTransaction([FromBody] TransferTransactionDTO transactionDTO)
        {
            try
            {
                var transaction = _mapper.Map<TransferTransaction>(transactionDTO);
                await _transferTransactionService.AddTransactionAsync(transaction);
                _responseDTO.IsSuccess = true;
            }
            catch (Exception e)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { Convert.ToString(e.ToString()) };
            }

            return Ok(_responseDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetTransaction(int id)
        {
            var transaction = await _transferTransactionService.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Transactions by id {id} not found" };
                return Ok(_responseDTO);
            }

            var transactionDTO = _mapper.Map<TransferTransactionDTO>(transaction);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionDTO;

            return Ok(_responseDTO);
        }

        [HttpGet("sourceAccount/{accountId}")]
        public async Task<ActionResult<ResponseDTO>> GetTransactionBySourceAccountId(int accountId)
        {
            var transaction = await _transferTransactionService.GetTransactionsBySourceAccountIdAsync(accountId);

            if (transaction == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Transactions by accountId {accountId} not found" };
                return Ok(_responseDTO);
            }

            var transactionDTO = _mapper.Map<IEnumerable<TransferTransactionDTO>>(transaction);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionDTO;

            return Ok(_responseDTO);
        }

        [HttpGet("destinationAccount/{accountId}")]
        public async Task<ActionResult<ResponseDTO>> GetTransactionByDestinationAccountId(int accountId)
        {
            var transaction = await _transferTransactionService.GetTransactionsByDestinationAccountIdAsync(accountId);

            if (transaction == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Transaction by accountId {accountId} not found" };
                return Ok(_responseDTO);
            }

            var transactionDTO = _mapper.Map<IEnumerable<TransferTransactionDTO>>(transaction);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionDTO;

            return Ok(_responseDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO>> UpdateTransaction([FromBody] TransferTransactionDTO transactionDTO, int id)
        {

            if(id != transactionDTO.Id)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Ids is different" };
                return Ok(_responseDTO);
            }

            try
            {
                var incomingTransaction = _mapper.Map<TransferTransaction>(transactionDTO);
                await _transferTransactionService.UpdateTransactionAsync(incomingTransaction);
                _responseDTO.IsSuccess = true;
            }
            catch (Exception e)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { Convert.ToString(e.ToString()) };
            }

            return Ok(_responseDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO>> DeleteTransaction(int id)
        {
            try
            {
                await _transferTransactionService.DeleteTransactionAsync(id);
                _responseDTO.IsSuccess = true;
            }
            catch (Exception e)
            {

                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { Convert.ToString(e.ToString()) };
            }

            return Ok(_responseDTO);
        }

    }
}
