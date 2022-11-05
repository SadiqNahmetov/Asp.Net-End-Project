﻿using AspNetCoreEndProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Languge> Languges { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Setting> Settings{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OurProduct> OurProducts { get; set; }
        public DbSet<Product> Products { get; set; }









    }
}
