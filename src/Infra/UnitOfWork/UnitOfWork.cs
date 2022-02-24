using Infra.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public AnalystChallangeContext Context { get; }

        public UnitOfWork(AnalystChallangeContext context)
        {
            Context = context;
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
