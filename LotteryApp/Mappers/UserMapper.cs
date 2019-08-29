using DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
            };
        }
    }
}
