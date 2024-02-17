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
    public class RefreshTokenRepo : GenericRepository<RefreshToken>, IRefreshTokenRepo
    {
        private readonly AppDBContext _dbContext;

        public RefreshTokenRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RefreshToken?> GetByToken(string token)
        {
            return await _dbContext.RefreshTokens.SingleAsync(r => r.Token == token);
        }
    }
}
