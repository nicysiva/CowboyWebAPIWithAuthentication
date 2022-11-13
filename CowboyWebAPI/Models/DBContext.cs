using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CowboyWebAPI.Models
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app.settings
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
        }
        public DbSet<CowboyDetails> CowboyDetails { get; set; }

        public DbSet<GunDetails> GunDetails { get; set; }

        public DbSet<CowboyGunBulletsMapping> CowboyGunBulletsMapping { get; set; }

        public DbSet<Users> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CowboyDetails>().Property(x => x.Longitude).HasPrecision(12, 9);
        //    modelBuilder.Entity<CowboyDetails>().Property(x => x.Latitude).HasPrecision(12, 9);
        //}
    }
}
