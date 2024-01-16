using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IDemandRepo : IGenericRepository<Demand>
    {

        public Task<IEnumerable<Demand>> GetAllByComplaint(int complaintID);
    }
}
