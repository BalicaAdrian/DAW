using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Mapper;
using WebApplication1.Model;
using WebApplication1.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;


namespace WebApplication1.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepostiory;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            this._userRepostiory = userRepository;
            this._appSettings = appSettings.Value;
        }

        public bool Delete(Guid id)
        {
            var user = _userRepostiory.FindById(id);
            _userRepostiory.Delete(user);
            return _userRepostiory.SaveChanges();
        }

        public bool Register(AuthenticationRequest request)
        {
            var entity = request.ToUserExtension(Enums.UserTypeEnum.User);

            _userRepostiory.Create(entity);
            return _userRepostiory.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _userRepostiory.GetAllActive();
        }

        public User GetById(Guid id)
        {
            return _userRepostiory.FindById(id);
        }

        public bool Update(User user)
        {
            _userRepostiory.Update(user);
            return _userRepostiory.SaveChanges();

        }
        public AuthenticationResponse Login(AuthenticationRequest request)
        {
            // find user
            var user = _userRepostiory.GetByUserAndPassword(request.username, request.password);
            if (user == null)
                return null;

            // attach token
            var token = GenerateJwtForUser(user);

            // return user & token
            return new AuthenticationResponse
            {
                Id = user.Id,
                username = user.username,
                Type = user.Type,
                token = token,
                email = user.email
            };
        }

        private string GenerateJwtForUser(User user)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetByIdAndDetails(Guid id)
        {
            return _userRepostiory.GetUserWithDetails(id);
        }

    }
}

