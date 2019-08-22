using DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace BusinessLayer
{
    public interface ITicketService
    {
        IEnumerable<TicketViewModel> GetAllTickets();
        void CreateTicket(CreateTicketViewModel model);
        TicketViewModel GetTicketById(int id);
    }
}
