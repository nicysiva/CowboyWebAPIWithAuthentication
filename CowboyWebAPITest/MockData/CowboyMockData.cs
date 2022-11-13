using CowboyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowboyWebAPITest.MockData
{
    public class CowboyMockData
    {
        public static List<CowboyDetails> GetCowboys()
        {
            return new List<CowboyDetails>
            {
                new CowboyDetails
                {
                    Id = 1,
                    Age = 20,
                    Created_By = "Siva",
                    Created_Date = DateTime.UtcNow,
                    DOB = DateTime.UtcNow,
                    Hair = "Blonde",
                    Height = 170,
                    IsActive = true,
                    Latitude = Convert.ToDouble(20.122345),
                    Longitude = Convert.ToDouble(21.122345),
                    Name = "Siva",
                    Updated_By = null,
                    Updated_Date = null
                },
                new CowboyDetails
                {
                    Id = 2,
                    Age = 21,
                    Created_By = "Siva",
                    Created_Date = DateTime.UtcNow,
                    DOB = DateTime.UtcNow,
                    Hair = "Black",
                    Height = 175,
                    IsActive = true,
                    Latitude = Convert.ToDouble(30.122345),
                    Longitude = Convert.ToDouble(31.122345),
                    Name = "Peter",
                    Updated_By = null,
                    Updated_Date = null
                },

            };
        }

        public static List<CowboyDetails>? Emptydetails()
        {
            //return new List<CowboyDetails>();
            return null;
        }
    }
}
