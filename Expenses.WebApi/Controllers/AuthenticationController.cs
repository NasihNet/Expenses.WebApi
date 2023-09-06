using Expenses.Db;
using ExpensesCore;
using ExpensesCore.CustomException;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {   
        private readonly IUserServices _userServices;
        public AuthenticationController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(User  user)
        {

            try
            {

                var result = await _userServices.SignUp(user);
                return Created("", result);
            }
            catch (UsernameAlreadyExistException e)
            {

                return StatusCode(409, e.Message);
            }
          
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(User user)
        {

       
            try
            {
                var result = await _userServices.SignIn(user);
                return Ok(result);
            }
            catch (UsernameAlreadyExistException e)
            {

                return StatusCode(409, e.Message);
            }
        }
    }
}
