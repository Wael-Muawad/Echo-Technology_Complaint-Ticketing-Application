using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.AppContexts.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppContexts.ContextFactory
{
    public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=ComplaintTicketingDB;Integrated Security=True;TrustServerCertificate=True"
                );

            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
