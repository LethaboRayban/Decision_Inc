using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeatherService
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("DefaultConnection"){

        }

        public DbSet<City> City { get; set; }
        public DbSet<Image> Image { get; set; }
    }
} 