using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CowboyWebAPI.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using CowboyWebAPI.ViewModels;
using CowboyWebAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace CowboyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CowboyDetailsController : ControllerBase
    {
        private readonly DataContext _context;
        ICowboyService _cowboyService;

        public CowboyDetailsController(ICowboyService cowboyService)
        {
            _cowboyService = cowboyService;
        }

        // GET: api/CowboyDetails
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCowboyDetails()
        {
            try
            {
                var cowboys = await _cowboyService.GetCowboyDetails();
                if (cowboys == null)
                    return NotFound();
                return Ok(cowboys);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/CowboyDetails/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCowboyDetails(int id)
        {
            try
            {
                var cowboy = await _cowboyService.GetCowboyDetailsById(id);
                if (cowboy == null)
                    return NotFound();
                return Ok(cowboy);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/CowboyDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCowboyDetails(int id, CowboyDetails cowboyDetails)
        {
            if (id != cowboyDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(cowboyDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CowboyDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CowboyDetails
        [HttpPost]
        public async Task<IActionResult> PostCowboyDetails()
        {
            try
            {
                NameFakeModel nameFakeModels = new NameFakeModel();

                var model = await _cowboyService.SaveCowboyDetails();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/CowboyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCowboyDetails(int id)
        {
            try
            {
                var cowboys = await _cowboyService.DeleteCowboyDetails(id);
                if (cowboys == null)
                    return NotFound();
                return Ok(cowboys);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEmployee([FromRoute] int id, [FromBody] JsonPatchDocument employeeDocument)
        {
            var updatedEmployee = await _cowboyService.UpdateEmployeePatchAsync(id, employeeDocument);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

        private bool CowboyDetailsExists(int id)
        {
            return _context.CowboyDetails.Any(e => e.Id == id);
        }

        [HttpGet("FindDistanceBetweenCowboys")]
        public async Task<IActionResult> FindDistanceBetweenCowboys(int id1, int id2)
        {
            try
            {
                var model = await _cowboyService.FindDistanceBetweenCowboys(id1, id2);
                return Ok(model);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
