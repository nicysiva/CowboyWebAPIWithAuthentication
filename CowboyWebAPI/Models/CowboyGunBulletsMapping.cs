using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CowboyWebAPI.Models
{
    [Table("tbl_CowboyGunBulletsMapping")]
    public class CowboyGunBulletsMapping
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cowboy_Id { get; set; }

        [ForeignKey("Cowboy_Id")]
        public CowboyDetails Cowboy_Details { get; set; }

        [Required]
        public int Gun_Id { get; set; }

        [ForeignKey("Gun_Id")]
        public GunDetails Gun_Details { get; set; }

        public int BulletsLeft { get; set; }
    }
}
