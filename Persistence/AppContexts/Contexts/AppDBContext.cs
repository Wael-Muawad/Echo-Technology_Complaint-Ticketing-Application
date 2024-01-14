using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppContexts.Contexts
{
    public class AppDBContext : DbContext
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

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Demand> Demands { get; set; }

    }
}
