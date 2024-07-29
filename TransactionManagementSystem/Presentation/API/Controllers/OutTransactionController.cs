using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransactionManagementSystem.Core.Entities;
using TransactionManagementSystem.Core.Interfaces.Services;
using TransactionManagementSystem.Presentation.API.DTOs;

namespace TransactionManagementSystem.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    public class OutTransactionController : ControllerBase
    {
        private readonly IOutTransactionService _outTransactionService;
        private readonly IMapper _mapper;
        protected ResponseDTO _responseDTO;

        public OutTransactionController(IOutTransactionService outTransactionService, IMapper mapper)
        {
            _outTransactionService = outTransactionService;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetTransactions()
        {
            var transactions = await _outTransactionService.GetTransactionsAsync();
            var transactionsDTO = _mapper.Map<IEnumerable<OutTransactionDTO>>(transactions);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionsDTO;
            return Ok(_responseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddTransaction([FromBody] OutTransactionDTO outTransactionDTO)
        {
            try
            {
                var transaction = _mapper.Map<OutTransaction>(outTransactionDTO);
                await _outTransactionService.AddTransactionAsync(transaction);
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
            var transaction = await _outTransactionService.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Transaction by id {id} not found" };
                return Ok(_responseDTO);
            }

            var transactionDTO = _mapper.Map<OutTransactionDTO>(transaction);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionDTO;

            return Ok(_responseDTO);
        }

        [HttpGet("account/{accountId}")]
        public async Task<ActionResult<ResponseDTO>> GetTransactionByAccountId(int accountId)
        {
            var transaction = await _outTransactionService.GetTransactionsByAccountIdAsync(accountId);

            if (transaction == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Transaction by accountId {accountId} not found" };
                return Ok(_responseDTO);
            }

            var transactionDTO = _mapper.Map<IEnumerable<OutTransactionDTO>>(transaction);

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = transactionDTO;

            return Ok(_responseDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO>> UpdateTransaction([FromBody] OutTransactionDTO incomingTransactionDTO, int id)
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
                var incomingTransaction = _mapper.Map<OutTransaction>(incomingTransactionDTO);
                await _outTransactionService.UpdateTransactionAsync(incomingTransaction);
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
                await _outTransactionService.DeleteTransactionAsync(id);
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
