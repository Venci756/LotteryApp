using DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserById(int id);
      //  void Add(User user);
    }
}
