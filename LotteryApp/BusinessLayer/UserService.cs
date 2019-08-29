using DataLayer.Users;
using DtoModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ViewModels;
using Mappers;

namespace BusinessLayer
{
     public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;
        public UserService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public void Register(RegisterUserViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username))
                throw new Exception("Username is required.");

            if (string.IsNullOrEmpty(model.FirstName))
                throw new Exception("FirstName is required.");

            if (string.IsNullOrEmpty(model.LastName))
                throw new Exception("LastName is required.");

            if (string.IsNullOrEmpty(model.Password))
                throw new Exception("Password is required.");

            if (model.Password != model.ConfirmPassword)
                throw new Exception("Password and Confirm Password must be the same.");

            if (_userRepository
                .GetAll()
                .Any(x => x.Username == model.Username))
                throw new Exception("The username is already in use.");

            var md5 = new MD5CryptoServiceProvider();
            var passwordBytes = Encoding.ASCII.GetBytes(model.Password);
            var hashBytes = md5.ComputeHash(passwordBytes);
            var hash = Encoding.ASCII.GetString(hashBytes);

         


            var user = new User
            {
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Balance = 1000,
                Password = hash
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

        public User GetUser (int id)
        {
           var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found ");
            }
            return user;
        }

        public UserViewModel Authenticate(LoginViewModel model)
        {
            var md5 = new MD5CryptoServiceProvider();
            var passwordBytes = Encoding.ASCII.GetBytes(model.Password);
            var hashBytes = md5.ComputeHash(passwordBytes);
            var hash = Encoding.ASCII.GetString(hashBytes);

            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Password == hash && x.Username == model.Username);

            if (user == null)
                throw new Exception("Username or password is wrong.");

            //Create token
            var keyBytes = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var jwtTokenHandler = new JwtSecurityTokenHandler();


            var descriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                })
            };

            var token = jwtTokenHandler.CreateToken(descriptor);
            var tokenString = jwtTokenHandler.WriteToken(token);

            var userModel = user.ToModel();
            userModel.Token = tokenString;
            return userModel;
        }
    
    }
}
