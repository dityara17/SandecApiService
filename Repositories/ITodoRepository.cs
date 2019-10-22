using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceSandec.Models;

namespace ServiceSandec.Repositories
{
    public interface  ITodoRepository<TEntity>
    { 
        Task<List<Todo>> GetAll();
        TEntity Get(long id);
        Task Add(TEntity entity);
        Task Update(TEntity dbEntity, TEntity entity);
        Task Delete(TEntity entity);
    }
}
