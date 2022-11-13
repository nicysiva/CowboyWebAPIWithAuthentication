using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CowboyWebAPI.Models
{
    [Table("tbl_GunDetails")]
    public class GunDetails
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string GunName { get; set; }

        [Required]
        public int MaxNumberOfBullets { get; set; }
    }
}
