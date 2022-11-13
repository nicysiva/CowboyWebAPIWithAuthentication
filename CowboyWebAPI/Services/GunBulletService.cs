using CowboyWebAPI.Models;
using CowboyWebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CowboyWebAPI.Services
{
    public class GunBulletService : IGunBulletService
    {
        private readonly DataContext _context;

        public GunBulletService(DataContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel> SaveGunDetails(GunDetails gunDetails)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                _context.GunDetails.Add(gunDetails);
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

        public async Task<ResponseModel> ShootGun(List<CowboyGunBulletsMapping> listcowboyGunBulletsMapping)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                foreach (var a in listcowboyGunBulletsMapping)
                {
                    CowboyGunBulletsMapping cowboyGunBulletsMapping = new CowboyGunBulletsMapping();
                    var shoot = _context.CowboyGunBulletsMapping.Where(x=> x.Cowboy_Id == a.Cowboy_Id && x.Gun_Id == a.Gun_Id).FirstOrDefault();
                    if (shoot.BulletsLeft > 0)
                    {
                        shoot.BulletsLeft = shoot.BulletsLeft - 1;
                        model.Messsage = "Record Updated Successfully";
                        model.IsSuccess = true;
                    }
                    else
                    {
                        model.Messsage = "Gun is empty. Please reload";
                        model.IsSuccess = true;
                    }
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public async Task<ResponseModel> SaveCowboyGunBulletMapping(List<CowboyGunBulletsMapping> listcowboyGunBulletsMapping)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                foreach(var a in listcowboyGunBulletsMapping)
                {
                    CowboyGunBulletsMapping cowboyGunBulletsMapping = new CowboyGunBulletsMapping();
                    cowboyGunBulletsMapping.Cowboy_Id = a.Cowboy_Id;
                    cowboyGunBulletsMapping.Gun_Id = a.Gun_Id;
                    cowboyGunBulletsMapping.BulletsLeft = a.BulletsLeft;
                    _context.CowboyGunBulletsMapping.Add(cowboyGunBulletsMapping);
                }

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

        public async Task<ResponseModel> ReloadGun(List<CowboyGunBulletsMapping> listcowboyGunBulletsMapping)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                foreach (var a in listcowboyGunBulletsMapping)
                {
                    CowboyGunBulletsMapping cowboyGunBulletsMapping = new CowboyGunBulletsMapping();
                    var shoot = _context.CowboyGunBulletsMapping.Where(x => x.Cowboy_Id == a.Cowboy_Id && x.Gun_Id == a.Gun_Id).FirstOrDefault();
                    var gun = _context.GunDetails.Where(x => x.Id == a.Gun_Id).FirstOrDefault();
                    shoot.BulletsLeft = gun.MaxNumberOfBullets;
                    await _context.SaveChangesAsync();

                }
                model.Messsage = "Record Updated Successfully";
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
