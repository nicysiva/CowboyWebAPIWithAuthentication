using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CowboyWebAPI.Models
{
    [Table("tbl_CowboyDetails")]
    public class CowboyDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public int Age { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public string Hair { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        public bool IsActive { get; set; }

        public string Created_By { get; set; }

        public DateTimeOffset? Created_Date { get; set; }

        public string Updated_By { get; set; }

        public DateTimeOffset? Updated_Date { get; set; }

        public int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.UtcNow.Year - dateOfBirth.Year;
            if (DateTime.UtcNow.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

    }
}
