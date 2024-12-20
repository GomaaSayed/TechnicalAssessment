﻿using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace TechnicalAssessment.Infrastructure.Contexts
{
    public class TechnicalAssessmentDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public TechnicalAssessmentDbContext(DbContextOptions<TechnicalAssessmentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        
            modelBuilder.Entity<Order>()
          .Property(i => i.OrderNumber)
          .ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>(b => { b.ToTable("Users"); });
            modelBuilder.Entity<IdentityRole>(b => { b.ToTable("Roles"); });
            modelBuilder.Entity<IdentityUserRole<string>>(b => { b.ToTable("UserRoles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(b => { b.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(b => { b.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(b => { b.ToTable("RoleClaims"); });
            modelBuilder.Entity<IdentityUserToken<string>>(b => { b.ToTable("UserTokens"); });
            var hasher = new PasswordHasher<User>();
            // بيانات افتراضية للتصنيفات
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = Guid.NewGuid(), Name = "Electronics", Description = "Devices and gadgets", CreatedOn = DateTime.Now },
                new Category { Id = Guid.NewGuid(), Name = "Clothing", Description = "Apparel and accessories", CreatedOn = DateTime.Now },
                new Category { Id = Guid.NewGuid(), Name = "Books", Description = "Fiction and non-fiction books", CreatedOn = DateTime.Now },
                new Category { Id = Guid.NewGuid(), Name = "Sports", Description = "Sports equipment and accessories", CreatedOn = DateTime.Now }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@1234"),
                    SecurityStamp = "admin_security_stamp",
                    ConcurrencyStamp = "admin_concurrency_stamp",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User@1234"),
                    SecurityStamp = "user_security_stamp",
                    ConcurrencyStamp = "user_concurrency_stamp",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                }
            );
        }

    }
}
