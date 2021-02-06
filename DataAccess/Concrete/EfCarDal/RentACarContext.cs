using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EfCarDal
{
    public class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TFU65PN\MSSQLSERVER14;Database=RENTACAR;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
