using NewSystem.Business.Models;
using System.Linq.Expressions;

namespace NewSystem.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Filtrar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();

    }
}
