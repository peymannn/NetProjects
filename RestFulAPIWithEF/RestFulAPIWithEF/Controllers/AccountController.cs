using Microsoft.AspNetCore.Mvc;
using RestFulAPIWithEF.Data.Model;
using RestFulAPIWithEF.Data.UnitOfWork.Abstract;
using Serilog;
using System.Security.Principal;

namespace RestFulAPIWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork; 
        public AccountController(IUnitOfWork unitOfWork) { 
        
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accounts = await unitOfWork.AccountRepository.GetAllAsync();
            return Ok(accounts);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Debug("AccountContoller.GetById");
            var account = await unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account is null)
            {
                return NotFound();
            }
            return Ok(account);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            account.CreatedAt = DateTime.Now;
            account.CreatedBy = "SystemUser";
            await unitOfWork.AccountRepository.InsertAsync(account);
            await unitOfWork.CompleteAsync();



            return CreatedAtAction("GetById", new { account.Id }, account);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Account account)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var item = await unitOfWork.AccountRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            item.Email = account.Email;
            item.Name = account.Name;
            item.LastActivity = DateTime.Now;

            unitOfWork.AccountRepository.Update(item);
            await unitOfWork.CompleteAsync();

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await unitOfWork.AccountRepository.GetByIdAsync(id);
            if (item is null)
            {
                return NotFound();
            }


            unitOfWork.AccountRepository.RemoveAsync(item);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }



    }
}
