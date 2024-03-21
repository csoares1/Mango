﻿using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace Mango.Services.CouponAPI.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode= "1FG",
                DiscountAmount=10,
                MinAmount=10
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "18FG",
                DiscountAmount = 18,
                MinAmount = 18
            });
        }

    }
}
