using DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



namespace DataLayer.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly LotteryAppContext _dbContext;
        public UserRepository(LotteryAppContext dbContext)
        {
           _dbContext = dbContext;
        }
       
        public void Create(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            //  return _dbContext.Set<User>().Find(id);
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

     

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
