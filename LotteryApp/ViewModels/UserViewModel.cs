using DtoModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Balance { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
    }
}
