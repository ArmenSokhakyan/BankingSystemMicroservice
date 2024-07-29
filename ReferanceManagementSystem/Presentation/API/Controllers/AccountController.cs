using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReferanceManagementSystem.Core.Entities;
using ReferanceManagementSystem.Core.Interfaces.Services;
using ReferanceManagementSystem.Presentation.API.DTOs;

namespace ReferanceManagementSystem.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        protected ResponseDTO _responseDTO;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseDTO>>> GetAccounts()
        {
            var accounts = await _accountService.GetAccountsAsync();
            var accountsDTO = _mapper.Map<IEnumerable<AccountDTO>>(accounts);

            if (accountsDTO == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                return Ok(_responseDTO);
            }

            _responseDTO.IsSuccess = true;
            _responseDTO.Result = accountsDTO;

            return Ok(_responseDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetAccount(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);

            if (account == null)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { $"Account by id {id} not found" };
                return Ok(_responseDTO);
            }

            var accountDTO = _mapper.Map<AccountDTO>(account);
            _responseDTO.IsSuccess = true;
            _responseDTO.Result = accountDTO;

            return Ok(_responseDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddAccount([FromBody] AccountDTO accountDTO)
        {
            var account = _mapper.Map<Account>(accountDTO);
            await _accountService.AddAccountAsync(account);
            _responseDTO.Result = account;
            return Ok(_responseDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDTO>> UpdateAccount([FromBody] AccountDTO accountDTO, int id)
        {
            if (id != accountDTO.Id)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.DisplayMessage = "Error";
                _responseDTO.Errors = new List<string> { "Ids are different" };
                return Ok(_responseDTO);
            }

            try
            {
                var account = _mapper.Map<Account>(accountDTO);
                await _accountService.UpdateAccountAsync(account);
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
        public async Task<ActionResult<ResponseDTO>> DeleteAccount(int id)
        {
            try
            {
                await _accountService.DeleteAccountAsync(id);
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
