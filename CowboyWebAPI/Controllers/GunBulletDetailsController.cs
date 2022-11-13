using CowboyWebAPI.Services;
using CowboyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CowboyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GunBulletDetailsController : ControllerBase
    {
        IGunBulletService _gunBulletService;

        public GunBulletDetailsController(IGunBulletService gunBulletService)
        {
            _gunBulletService = gunBulletService;
        }

        [HttpPost("SaveGunDetails")]
        public async Task<IActionResult> SaveGunDetails(GunDetails gunDetails)
        {
            try
            {
                var model = await _gunBulletService.SaveGunDetails(gunDetails);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("SaveCowboyGunBulletMapping")]
        public async Task<IActionResult> SaveCowboyGunBulletMapping(List<CowboyGunBulletsMapping> gunBulletsMapping)
        {
            try
            {
                var model = await _gunBulletService.SaveCowboyGunBulletMapping(gunBulletsMapping);
                return Ok(model);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("ShootGun")]
        public async Task<IActionResult> ShootGun(List<CowboyGunBulletsMapping> cowboyGunBulletsMappings)
        {
            try
            {
                var model = await _gunBulletService.ShootGun(cowboyGunBulletsMappings);
                return Ok(model);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("ReloadGun")]
        public async Task<IActionResult> ReloadGun(List<CowboyGunBulletsMapping> cowboyGunBulletsMappings)
        {
            try
            {
                var model = await _gunBulletService.ReloadGun(cowboyGunBulletsMappings);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
