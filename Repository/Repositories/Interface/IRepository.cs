using Domain.Models.Common;
using System.Linq.Expressions;


namespace Repository.Repositories.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SoftDelete(T entity);

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> expression);

    }
}
