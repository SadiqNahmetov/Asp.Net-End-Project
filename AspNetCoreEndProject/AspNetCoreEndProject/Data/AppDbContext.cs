﻿using AspNetCoreEndProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
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
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<TopSeller> TopSellers { get; set; }
        public DbSet<ProductBanner> ProductBanners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<OurBlog> OurBlogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Social> Socials { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
