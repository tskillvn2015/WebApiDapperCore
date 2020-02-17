using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDapperCore.Data.Interface;
using WebApiDapperCore.Data.ViewModel;
using WebApiDapperCore.Filters;

namespace WebApiDapperCore.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("api/User/Login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var result =await _userService.Login(model);
            return Ok(result);
        }
        [HttpPost]
        [Route("api/User")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            await _userService.Register(model);
            return Ok();
        }
    }
}