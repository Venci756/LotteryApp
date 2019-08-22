using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ViewModels;

namespace LotteryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/values
        [Route("register")]
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserViewModel model)
        {
            _userService.Register(model);
            return Ok("User successfully registered.");
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok( _userService.GetAllUsers().ToList());
        }
    }
}