using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.CreateRound;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace LotteryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICreateRoundService _roundService;

        public AdminController(ICreateRoundService roundService)
        {
            _roundService = roundService;
        }

        [Route("next-round")]
        [HttpPost]
        public IActionResult Post()
        {
            
            return Ok(_roundService.ActivateRound());
        }
    }
}