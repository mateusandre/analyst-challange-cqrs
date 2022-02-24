using Infra.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        AnalystChallangeContext Context { get; }

        Task Commit(CancellationToken cancellationToken);
    }
}
