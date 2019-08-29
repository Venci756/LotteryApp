using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace BusinessLayer
{
    public interface IUserService
    {
        void Register(RegisterUserViewModel model);
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel Authenticate(LoginViewModel model);
    }
}
