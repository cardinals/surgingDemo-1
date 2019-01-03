using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZN.Core
{
    public interface IRespositoryBase<TEntity> : IRespositoryBase<TEntity, Guid>
       where TEntity : class
    {

    }


    public interface IRespositoryBase<TEntity, TPrimaryKey> where TEntity :class
    {


        IQueryable<TEntity> Entities();
        Task Add(TEntity entity, bool isSave = true);

      //  Task<TEntity> GetEntityById(string Id);


    }
}
