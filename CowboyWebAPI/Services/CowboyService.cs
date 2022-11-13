using CowboyWebAPI.Models;
using CowboyWebAPI.ViewModels;
using CowboyWebAPI.ViewModels.ResponseModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CowboyWebAPI.Services
{
    public class CowboyService : ICowboyService
    {
        private readonly DataContext _context;
        private readonly NameFakeEndpoint nameFakeEndpoint;

        public CowboyService(DataContext context, IOptions<NameFakeEndpoint> options)
        {
            _context = context;
            nameFakeEndpoint = options.Value;
        }

        public async Task<List<CowboyDetails>> GetCowboyDetails()
        {

            List<CowboyDetails> cowboyList;
            try
            {
                cowboyList = await _context.Set<CowboyDetails>().Where(x => x.IsActive == true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return cowboyList;
        }

        public async Task<CowboyDetails> GetCowboyDetailsById(int id)
        {
            CowboyDetails cowboy;
            try
            {
                cowboy = await _context.Set<CowboyDetails>().Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return cowboy;
        }
        public async Task<ResponseModel> SaveCowboyDetails()
        {
            ResponseModel model = new ResponseModel();
            try
            {
                NameFakeModel nameFakeModels = new NameFakeModel();

                #region Call NameFake API
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(nameFakeEndpoint.EndPoint);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        var ObjResponse = Res.Content.ReadAsStringAsync().Result;
                        nameFakeModels = JsonConvert.DeserializeObject<NameFakeModel>(ObjResponse);
                    }
                }
                #endregion

                CowboyDetails cowboyDetails = new CowboyDetails();

                cowboyDetails.Name = nameFakeModels.Name;
                cowboyDetails.DOB = nameFakeModels.BirthData;
                cowboyDetails.Height = nameFakeModels.Height;
                cowboyDetails.Hair = nameFakeModels.Hair;
                cowboyDetails.Longitude = nameFakeModels.Longitude;
                cowboyDetails.Latitude = nameFakeModels.Latitude;
                cowboyDetails.Age = cowboyDetails.CalculateAge(cowboyDetails.DOB);
                cowboyDetails.IsActive = true;
                cowboyDetails.Created_Date = DateTime.UtcNow;
                cowboyDetails.Created_By = "SYSTEM";

                _context.CowboyDetails.Add(cowboyDetails);
                _context.SaveChanges();
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

        public async Task<ResponseModel> DeleteCowboyDetails(int id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                CowboyDetails _temp =await GetCowboyDetailsById(id);
                if (_temp != null)
                {
                    _temp.IsActive = false;
                    _context.Update<CowboyDetails>(_temp);
                    model.IsSuccess = true;
                    model.Messsage = "Record Deleted Successfully";
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public async Task<CowboyDetails> UpdateEmployeePatchAsync(int id, JsonPatchDocument employeeDocument)
        {
            try
            {
                var employeeQuery = await GetCowboyDetailsById(id);
                if (employeeQuery == null)
                {
                    return employeeQuery;
                }
                employeeDocument.ApplyTo(employeeQuery);
                await _context.SaveChangesAsync();
                return employeeQuery;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<DistanceResponse> FindDistanceBetweenCowboys(int id1, int id2)
        {
            ResponseModel model = new ResponseModel();
            DistanceResponse distanceResponse = new DistanceResponse();

            try
            {
                var cowboy1 = await _context.CowboyDetails.Where(x => x.IsActive == true && x.Id == id1).ToListAsync();
                var cowboy2 = await _context.CowboyDetails.Where(x => x.IsActive == true && x.Id == id2).ToListAsync();

                if (cowboy1.Count != 0 && cowboy2.Count != 0)
                {
                    double latitude1 = Convert.ToDouble(cowboy1[0].Latitude);
                    double latitude2 = Convert.ToDouble(cowboy2[0].Latitude);
                    double longitude1 = Convert.ToDouble(cowboy1[0].Longitude);
                    double longitude2 = Convert.ToDouble(cowboy2[0].Longitude);


                    var d1 = latitude1 * (Math.PI / 180.0);
                    var num1 = longitude1 * (Math.PI / 180.0);
                    var d2 = latitude2 * (Math.PI / 180.0);
                    var num2 = longitude2 * (Math.PI / 180.0) - num1;
                    var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                             Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

                    var distance = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
                    model.IsSuccess = true;
                    model.Messsage = "Distance fetched Successfully";
                    distanceResponse.distance = distance;
                    distanceResponse.responseModel = model;
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Distance fetched Unsuccessfully";
                    distanceResponse.responseModel = model;
                }
            }
            catch(Exception)
            {
                throw;
            }

            return distanceResponse;
        }
    }
}
