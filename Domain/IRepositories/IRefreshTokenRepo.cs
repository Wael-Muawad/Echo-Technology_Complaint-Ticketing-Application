using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRefreshTokenRepo : IGenericRepository<RefreshToken>
    {

        public Task<RefreshToken?> GetByToken(string token);
    }
}
