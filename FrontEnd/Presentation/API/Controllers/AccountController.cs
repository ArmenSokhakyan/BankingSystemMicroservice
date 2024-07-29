using FrontEnd.Core.Interfaces.Services.Referances;
using FrontEnd.Presentation.API.DTOs;
using FrontEnd.Presentation.API.DTOs.Referances;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccounts()
        {
            List<AccountDTO> accounts = new();

            var response = await _accountService.GetAccountsAsync<ResponseDTO>();

            if (response != null && response.IsSuccess)
            {
                accounts = JsonConvert.DeserializeObject<List<AccountDTO>>(Convert.ToString(response.Result));
            }

            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccount(int id)
        {
            AccountDTO accountDTO = new();
            var response = await _accountService.GetAccountAsync<ResponseDTO>(id);

            if (response != null && response.IsSuccess)
            {
                accountDTO = JsonConvert.DeserializeObject<AccountDTO>(Convert.ToString(response.Result));
            }

            return Ok(accountDTO);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDTO>> AddAccount([FromBody] AccountDTO accountDTO)
        {
            var response = await _accountService.AddAccount<ResponseDTO>(accountDTO);

            if (response != null)
            {
                if (response.IsSuccess)
                {
                    AccountDTO account = JsonConvert.DeserializeObject<AccountDTO>(Convert.ToString(response.Result.ToString()));
                    return Ok(account);
                }
                else
                {
                    return BadRequest(new { response.DisplayMessage, response.Errors });
                }
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountDTO accountDTO, int id)
        {
            var response = await _accountService.UpdateAccount<ResponseDTO>(id, accountDTO);

            if (response != null)
            {

                if (response.IsSuccess)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest(new { response.DisplayMessage, response.Errors });
                }
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var response = await _accountService.DeleteAccount<ResponseDTO>(id);

            if (response != null)
            {

                if (response.IsSuccess)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest(new { response.DisplayMessage, response.Errors });
                }
            }

            return BadRequest();
        }

    }
}
