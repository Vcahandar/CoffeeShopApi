using Domain.Models.Common;
using System.Linq.Expressions;


namespace Repository.Repositories.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        
        Task<T> GetByIdAsync(int? id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SoftDeleteAsync(T entity);
        Task<IEnumerable<T>> FindAllAsycn(Expression<Func<T,bool>> expression = null); 

        

    }
}
