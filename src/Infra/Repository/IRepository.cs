using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task Adicionar(T entity, CancellationToken cancellationToken);
        Task Salvar(CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
    }
}
