using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.utils
{
    public static class ModelBuilderExtensions
    {
        public static void AddAppSeed(this ModelBuilder modelBuilder)
        {

        }

        public static void AddIdentitySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("IdentitySchema");


            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = 2, Name = "User", NormalizedName = "USER" }
                );


            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Email = "admin@admin.com",
                    NormalizedEmail = "admin@admin.com".ToUpper(),
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "adminadmin")
                }
                );

            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 });
        }


    }
}
