using CowboyWebAPI.Models;
using CowboyWebAPI.ViewModels;

namespace CowboyWebAPI.Services
{
    public interface IGunBulletService
    {
        Task<ResponseModel> SaveGunDetails(GunDetails gunDetails);

        Task<ResponseModel> SaveCowboyGunBulletMapping(List<CowboyGunBulletsMapping> cowboyGunBulletsMapping);

        Task<ResponseModel> ShootGun(List<CowboyGunBulletsMapping> listcowboyGunBulletsMapping);

        Task<ResponseModel> ReloadGun(List<CowboyGunBulletsMapping> listcowboyGunBulletsMapping);
    }
}
