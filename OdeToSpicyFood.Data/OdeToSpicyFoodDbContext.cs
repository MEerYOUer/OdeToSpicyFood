using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OdeToSpicyFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToSpicyFood.Data
{
    public class OdeToSpicyFoodDbContext : DbContext
    {

        public OdeToSpicyFoodDbContext(DbContextOptions<OdeToSpicyFoodDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
