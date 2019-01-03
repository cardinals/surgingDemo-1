using LZN.Core;
using LZN.Core.Data;
using LZN.EntityFramwork.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZN.EntityFramwork
{
    public abstract class RespositoryBase<TEntity>
       : RespositoryBase<TEntity, string>, IRespositoryBase<TEntity, string>
       where TEntity : class,IEntity<string>
    {
      
        public RespositoryBase(IUnitOfWorkDbContext dbDbContext) : base(dbDbContext)
        {
        }
    }


    public abstract class RespositoryBase<TEntity, TPrimaryKey> :
        LZN.Core.Data.IUnitOfWork,
         IRespositoryBase<TEntity, TPrimaryKey>
          where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly DbSet<TEntity> _dbSet;

        protected readonly UnitOfWorkDbContext _dbContext;

        //public DbContext GetDbContext()
        //{
        //    return _dbContext;
        //}

        public DbContext GetDbContext()
        {
            return _dbContext;
        }
        public async Task<int> SaveChangesAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }


        public RespositoryBase(IUnitOfWorkDbContext dbContext)
        {

            _dbContext = (UnitOfWorkDbContext)dbContext;
            _dbSet = _dbContext.Set<TEntity>();

        }
        public IQueryable<TEntity> Entities()
        {


            return _dbSet;
            
        }
        public async Task Add(TEntity entity, bool isSave = true)
        {
            await _dbSet.AddAsync(entity);
        }

     
    }
}
