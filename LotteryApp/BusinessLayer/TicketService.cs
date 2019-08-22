using DataLayer.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels;
using DomainModels;
using DtoModels;

namespace BusinessLayer
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void CreateTicket(CreateTicketViewModel model)
        {
            var ticket = new Ticket()
            {
                Combination = model.Combination,
               // Prize = model.Prize,
                Round = model.Round,
                Status = model.Status,
                UserId = model.UserId
            };
          
                _ticketRepository.Create(ticket);
          
           
            
        }


        public IEnumerable<TicketViewModel> GetAllTickets()
        {
            var users = _ticketRepository.GetAll().ToList();
            return users.Select(t => new TicketViewModel
            {
                Combination = t.Combination,
                Round = t.Round,
                Prize = t.Prize,
                Status = t.Status
                
            });

        }

        public TicketViewModel GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        //public TicketViewModel GetTicketById(int id)
        //{
        //    return _ticketRepository.GetById(id);
        //}
    }
    
}
