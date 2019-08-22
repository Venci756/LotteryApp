using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace LotteryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Post([FromBody] CreateTicketViewModel model)
        {
            _ticketService.CreateTicket(model);
            return Ok("Successfully created ticket");
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok( _ticketService.GetAllTickets().ToList());
        }
    }
}