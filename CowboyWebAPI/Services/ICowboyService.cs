using CowboyWebAPI.Models;
using CowboyWebAPI.ViewModels;
using CowboyWebAPI.ViewModels.ResponseModels;
using Microsoft.AspNetCore.JsonPatch;
using System;


namespace CowboyWebAPI.Services
{
    public interface ICowboyService
    {
        Task<List<CowboyDetails>> GetCowboyDetails();
        Task<CowboyDetails> GetCowboyDetailsById(int id);

        Task<ResponseModel> SaveCowboyDetails();

        Task<ResponseModel> DeleteCowboyDetails(int id);

        Task<CowboyDetails> UpdateEmployeePatchAsync(int id, JsonPatchDocument cowboy);

        Task<DistanceResponse> FindDistanceBetweenCowboys(int id1, int id2);
    }
}
