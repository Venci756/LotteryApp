using System;
using System.Collections.Generic;
using System.Text;
using DtoModels;
using System.Linq;

namespace DataLayer.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        private readonly LotteryAppContext _dbContext;
        public TicketRepository(LotteryAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Ticket entity)
        {
            _dbContext.Tickets.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Ticket entity)
        {
            _dbContext.Tickets.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _dbContext.Tickets;
        }

        public Ticket GetById(int id)
        {
            return _dbContext.Tickets.SingleOrDefault(t => t.Id == id);
        }

        public Ticket GetUserById(int id)
        {
            //  return _dbContext.Set<User>().Find(id);
            return _dbContext.Tickets.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Ticket entity)
        {
            _dbContext.Tickets.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
