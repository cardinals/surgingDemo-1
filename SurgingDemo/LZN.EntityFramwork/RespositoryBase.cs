using LZN.Core;
using LZN.Core.Data;
using LZN.Data.Ext;
using LZN.EntityFramwork.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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



          void AttachIfNot(TEntity entity)
        {
            var entry = _dbContext.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            _dbSet.Attach(entity);
        }
          Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
        public RespositoryBase(IUnitOfWorkDbContext dbContext)
        {

            _dbContext = (UnitOfWorkDbContext)dbContext;
            _dbSet = _dbContext.Set<TEntity>();

        }
        //public IQueryable<TEntity> Entities()
        //{

        //    return _dbSet;
            
        //}
        #region Select/Get/Query
        public IQueryable<TEntity> GetAll()
        {
            return GetAllIncluding();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = _dbSet.AsQueryable();

            if (!propertySelectors.IsNullOrEmpty())
            {
                foreach (var propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }

            return query;
        }

        public List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        public Task<List<TEntity>> GetAllListAsync()
        {
            return Task.FromResult(GetAllList());
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(GetAllList(predicate));
        }

        public T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            return queryMethod(GetAll());
        }

        public TEntity Get(TPrimaryKey id)
        {
            var entity = FirstOrDefault(id);
            if (entity == null)
            {
                //throw new EntityNotFoundException(typeof(TEntity), id);
                throw new Exception($"TEntity{id}");
            }

            return entity;
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            var entity = await FirstOrDefaultAsync(id);
            if (entity == null)
            {
                // throw new EntityNotFoundException(typeof(TEntity), id);
                throw new Exception($"TEntity{id}");
            }

            return entity;
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Single(predicate);
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(Single(predicate));
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await Task.FromResult(FirstOrDefault(id));
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(FirstOrDefault(predicate));
        }

        public TEntity Load(TPrimaryKey id)
        {
            return Get(id);
        }

        #endregion

        #region Insert

        public async Task Add(TEntity entity, bool isSave = true)
        {
            await _dbSet.AddAsync(entity);
        }
        public TEntity Insert(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await Task.FromResult(Insert(entity));
        }

        public TPrimaryKey InsertAndGetId(TEntity entity)
        {
            entity = Insert(entity);

            if (entity.IsTransient())
            {
                _dbContext.SaveChanges();
            }

            return entity.Id;
        }

        public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            entity = await InsertAsync(entity);

            if (entity.IsTransient())
            {
                await _dbContext.SaveChangesAsync();
            }

            return entity.Id;
        }
        public TEntity InsertOrUpdate(TEntity entity)
        {
            return entity.IsTransient()
                ? Insert(entity)
                : Update(entity);
        }

        public TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            entity = InsertOrUpdate(entity);

            if (entity.IsTransient())
            {
                _dbContext.SaveChanges();
            }

            return entity.Id;
        }
        public async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return entity.IsTransient()
                ? await InsertAsync(entity)
                : await UpdateAsync(entity);
        }
        public async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            entity = await InsertOrUpdateAsync(entity);

            if (entity.IsTransient())
            {
                await _dbContext.SaveChangesAsync();
            }

            return entity.Id;
        } 
        #endregion

        #region Update
        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.FromResult(Update(entity));
        }

        public TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            var entity = Get(id);
            updateAction(entity);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            var entity = await GetAsync(id);
            await updateAction(entity);
            return entity;
        } 
        #endregion

        #region Aggregates
        public int Count()
        {
            return GetAll().Count();
        }

        public async Task<int> CountAsync()
        {
            return await Task.FromResult(Count());
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(Count(predicate));
        }

        public long LongCount()
        {
            return GetAll().LongCount();
        }

        public async Task<long> LongCountAsync()
        {
            return await Task.FromResult(LongCount());
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).LongCount();
        }

        public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(LongCount(predicate));
        } 
        #endregion

    }
}
