using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task Create(TEntity entity);

        public Task Update(TEntity entity);

        public Task Delete(object id);



        public Task<TEntity?> GetByID(object id);
        public Task<IEnumerable<TEntity>> GetAll();



        public Task<bool> SaveChanges();
    }
}
