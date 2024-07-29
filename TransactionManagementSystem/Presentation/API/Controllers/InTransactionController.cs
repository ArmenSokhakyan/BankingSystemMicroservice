using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Core.Interfaces.Services;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    public class InTransactionController : ControllerBase
    {
        private readonly IInTransactionService _inTransactionService;
        private readonly IMapper _mapper;
        protected ResponseDTO _responseDTO;

        public InTransactionController(IInTransactionService incomingTransactionService, IMapper mapper)
        {
            _inTransactionService = incomingTransactionService;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetTransactions()
        {
            var transactions = await _inTransactionService.GetTransactionsAsync();
            var transactionsDTO = _mapper.Map<IEnumerable<InTransactionDTO>>(transactions);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionsDTO;
            return Ok(_responseDTO);
        }

        [HttpPost("summery")]
        public async Task<ActionResult<IEnumerable<SummeryDTO>>> GetAccountSummery([FromBody] SummeryQueryDTO summeryQueryDTO)
        {
            var accountSummeries = await _inTransactionService.GetAccountSummeryAsync(summeryQueryDTO.StartDate, summeryQueryDTO.EndDate);
            return Ok(accountSummeries);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddTransaction([FromBody] InTransactionDTO incomingTransactionDTO)
        {
            try
            {
                var transaction = _mapper.Map<InTransaction>(incomingTransactionDTO);
                await _inTransactionService.AddTransactionAsync(transaction);
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
            var transaction = await _inTransactionService.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Transaction by id {id} not found" };
                return Ok(_responseDTO);
            }

            var transactionDTO = _mapper.Map<InTransactionDTO>(transaction);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionDTO;

            return Ok(_responseDTO);
        }

        [HttpGet("account/{accountId}")]
        public async Task<ActionResult<ResponseDTO>> GetTransactionByAccountId(int accountId)
        {
            var transaction = await _inTransactionService.GetTransactionsByAccountIdAsync(accountId);

            if (transaction == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Transaction by accountId {accountId} not found" };
                return Ok(_responseDTO);
            }

            var transactionDTO = _mapper.Map<IEnumerable<InTransactionDTO>>(transaction);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionDTO;

            return Ok(_responseDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO>> UpdateTransaction([FromBody] InTransactionDTO incomingTransactionDTO, int id)
        {

            if(id != incomingTransactionDTO.Id)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Ids is different" };
                return Ok(_responseDTO);
            }

            try
            {
                var incomingTransaction = _mapper.Map<InTransaction>(incomingTransactionDTO);
                await _inTransactionService.UpdateTransactionAsync(incomingTransaction);
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
                await _inTransactionService.DeleteTransactionAsync(id);
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
