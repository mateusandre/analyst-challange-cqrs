using Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Adicionar(T entity, CancellationToken cancellationToken)
        {
            await _unitOfWork.Context.Set<T>().AddAsync(entity, cancellationToken);
        }

        public async Task Salvar(CancellationToken cancellationToken)
        {
            await _unitOfWork.Commit(cancellationToken);
        }

        public async void Dispose()
        {
            await _unitOfWork.Context.DisposeAsync();
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}