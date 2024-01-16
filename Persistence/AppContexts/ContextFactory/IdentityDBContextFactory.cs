using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    //public class IdentityDBContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    //{
    //    public IdentityContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
    //        optionsBuilder.UseSqlServer(
    //            "Data Source=.;Initial Catalog=ComplaintTicketingIdentityDB;Integrated Security=True;TrustServerCertificate=True"
    //            );

    //        return new IdentityContext(optionsBuilder.Options);
    //    }
    //}
}
