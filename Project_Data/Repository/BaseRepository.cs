using Microsoft.EntityFrameworkCore;
using Project_Data.Data;
using Project_Model.Entities;
using Project_Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_Data.Repository
{
    public class BaseRepository<T> : IBaseRepositoty<T> where T : class
    {
        protected IDBContext _idbContext = null;
        protected DbSet<T> _dbSet;
        protected DbContext _dbContext;
        protected DbSet<T> DBSet
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = _dbContext.Set<T>() as DbSet<T>;
                }
                return _dbSet;
            }
        }

        //  protected IDBContext _IDbcontext;
        // private readonly AppDBContext _dbContext;
        //  private readonly DbSet<T> _dbSet;

        /*  public BaseRepository(AppDBContext dbcontext)
          {
              _dbContext = dbcontext;
              _dbSet = _dbContext.Set<T>();
          }*/
        public BaseRepository(IDBContext dbContext)
        {
            _idbContext = dbContext;
            _dbContext = (DbContext)dbContext;
        }


        public async Task<int> CountAsync(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = expression != null ? _dbSet.Where(expression) : _dbSet;
            return await query.CountAsync();
        }

        public async Task<int> CountAsync(string include, Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query;
            if (!string.IsNullOrEmpty(include))
            {
                query = BuiderQueryable(new List<string> { include }, expression);
                return await query.CountAsync();
            }
            return await CountAsync(expression);

        }
        protected IQueryable<T> BuiderQueryable(List<string> includes, Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null && includes.Count > 0)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include.Trim());
                }
            }
            return query;
        }
        //
        public async Task<T> CreateAsync(T TEntity)
        {
            DBSet.Add(TEntity);
            await _idbContext.CommitChangesAsync();
            return TEntity;

        }

        public async Task<IEnumerable<T>> CreateAsync(IEnumerable<T> entities)
        {
            DBSet.AddRange(entities);
            await _idbContext.CommitChangesAsync();
            return entities;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await DBSet.FindAsync(id);

            if (data != null)
            {
                _dbSet.Remove(data);
                await _idbContext.CommitChangesAsync();
            }
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = expression != null ? DBSet.Where(expression) : DBSet;
            var dataQuery = query;
            if (dataQuery != null)
            {
                DBSet.RemoveRange(dataQuery);
                await _idbContext.CommitChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = expression != null ? DBSet.Where(expression) : DBSet;
            return query;

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await DBSet.FirstOrDefaultAsync(expression);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await DBSet.FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> expression = null)
        {
            return await DBSet.FirstOrDefaultAsync(expression);
        }

        public async Task<T> UpdateASync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _idbContext.CommitChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;

            }
            await _idbContext.CommitChangesAsync();
            return entities;
        }

        public async Task<IEnumerable<Product>> getByCategoryIdAsync(int id)
        {
            var query = DBSet.OfType<Product>().Where(p => p.CateId == id)
                  .Include(p => p.Cate);  // Include thông tin Category

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Product>> getByMaterialIdAsync(int id)
        {
            var query = DBSet.OfType<Product>().Where(p => p.MateId == id)
                 .Include(p => p.Cate);  // Include thông tin Mategory

            return await query.ToListAsync();
        }
    }
}
