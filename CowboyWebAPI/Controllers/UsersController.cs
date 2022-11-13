using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CowboyWebAPI.Models;
using CowboyWebAPI.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using CowboyWebAPI.Services;

namespace CowboyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCred userCred)
        {
            try
            {
                var response = await _userService.Authenticate(userCred);
                if (response.Token == null)
                    return Unauthorized();
                return Ok(response);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(Users users)
        {
            try
            {
                var response = await _userService.CreateUser(users);
                return Ok(response);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
