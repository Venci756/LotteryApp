using DataLayer.Users;
using DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModels;

namespace BusinessLayer
{
     public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(RegisterUserViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username))
                throw new Exception("Username is required.");

            if (string.IsNullOrEmpty(model.FirstName))
                throw new Exception("FirstName is required.");

            if (string.IsNullOrEmpty(model.LastName))
                throw new Exception("LastName is required.");

          

            if (_userRepository
                .GetAll()
                .Any(x => x.Username == model.Username))
                throw new Exception("The username is already in use.");

            

           

            var user = new User
            {
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Balance = 1000,
                //Role = model.Role
            };

            _userRepository.Create(user);
        }

        public IEnumerable<UserViewModel> GetAllUsers() {
            var users = _userRepository.GetAll().ToList();
            return users.Select(u => new UserViewModel
            {
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Balance = u.Balance,
                Role = u.Role
            });
           
        }

    
    }
}
