using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppContexts.Contexts
{
    public class AppDBContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=ComplaintTicketingDB;Integrated Security=True;TrustServerCertificate=True"
                );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddIdentitySeed();
            //builder.AddAppRelations();
        }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
