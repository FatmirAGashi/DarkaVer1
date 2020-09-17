using Darka.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darka.Data
{
    public class DarkaDbContext : DbContext
    {
        public DarkaDbContext(DbContextOptions<DarkaDbContext> options) : base(options)
        {
                
        }

        public DbSet<Restaurant>  Restaurants { get; set;}
    }
}
