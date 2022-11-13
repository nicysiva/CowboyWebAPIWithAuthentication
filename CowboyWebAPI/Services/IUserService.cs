using CowboyWebAPI.Models;
using CowboyWebAPI.ViewModels;
using CowboyWebAPI.ViewModels.ResponseModels;

namespace CowboyWebAPI.Services
{
    public interface IUserService
    {
        Task<AuthTokenResponse> Authenticate(UserCred userCred);

        Task<ResponseModel> CreateUser(Users users);
    }
}
