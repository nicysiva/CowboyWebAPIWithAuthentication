using CowboyWebAPI.Models;
using CowboyWebAPI.ViewModels;
using CowboyWebAPI.ViewModels.ResponseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CowboyWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly JwtSettings jwtSettings;

        public UserService(DataContext context, IOptions<JwtSettings> options)
        {
            _context = context;
            this.jwtSettings = options.Value;
        }
        public async Task<AuthTokenResponse> Authenticate(UserCred userCred)
        {
            ResponseModel model = new ResponseModel();
            AuthTokenResponse tokenResponse = new AuthTokenResponse();
            try
            {
                var user = await this._context.Users.FirstOrDefaultAsync(item => item.UserName == userCred.username && item.Password == userCred.password);
                if (user == null)
                {
                    model.IsSuccess = false;
                    model.Messsage = "Invalid credentials";
                    tokenResponse.responseModel = model;
                    tokenResponse.Token = null;

                    return tokenResponse;
                }
                /// Generate Token
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(this.jwtSettings.securitykey);
                var tokendesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new Claim[] { new Claim(ClaimTypes.Name, user.UserName) }
                    ),
                    Expires = DateTime.Now.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenhandler.CreateToken(tokendesc);
                string finaltoken = tokenhandler.WriteToken(token);

                model.IsSuccess = true;
                model.Messsage = "Valid credentials";
                tokenResponse.responseModel = model;
                tokenResponse.Token = finaltoken;

                return tokenResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseModel> CreateUser(Users users)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                _context.Users.Add(users);
                await _context.SaveChangesAsync();
                model.Messsage = "Record Inserted Successfully";
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
            
    }
}
