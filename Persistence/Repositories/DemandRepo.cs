using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.AppContexts.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class DemandRepo : GenericRepository<Demand>, IDemandRepo
    {
        private readonly AppDBContext _context;

        public DemandRepo(AppDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Demand>> GetAllByComplaint(int complaintID)
        {
            return await _context.Demands.Where(d => d.ComplaintID == complaintID).ToListAsync(); 
        }
    }
}
