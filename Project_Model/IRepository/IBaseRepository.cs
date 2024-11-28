using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model.IRepository
{
    public interface IBaseRepositoty<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression = null);
      
        Task<IEnumerable<Product>> getByCategoryIdAsync(int id);

        Task<IEnumerable<Product>> getByMaterialIdAsync(int id);

        Task<T> CreateAsync(T TEntity);
        Task<IEnumerable<T>> CreateAsync(IEnumerable<T> entities);
        Task DeleteAsync(int id);
        Task DeleteAsync(Expression<Func<T, bool>> expression);
        Task<T> UpdateASync(T entity);
        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities);

        Task<int> CountAsync(Expression<Func<T, bool>> expression = null);

        Task<int> CountAsync(string include, Expression<Func<T, bool>> expression = null);
    }
}
