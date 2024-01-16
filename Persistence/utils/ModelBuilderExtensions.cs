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
            modelBuilder.HasDefaultSchema("App");


            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new AppRole { Id = 2, Name = "User", NormalizedName = "USER" }
                );


            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
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


        //public static void AddAppRelations(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Complaint>()
        //        .HasKey(e => e.ID);

        //    modelBuilder.Entity<Complaint>()
        //        .HasOne(e => e.User)
        //        .WithMany(e => e.Complaints)
        //        .HasForeignKey(e => e.UserID)
        //        .IsRequired();
        //}

        //public static void AddIdentityRelations(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.Complaints)
        //        .WithOne(u => u.User)
        //        .HasForeignKey(u => u.UserID)
        //        .IsRequired();
        //}

    }
}
