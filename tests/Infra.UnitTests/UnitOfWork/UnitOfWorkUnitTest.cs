using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Infra.UnitTests.UnitOfWork
{
    public class UnitOfWorkUnitTest
    {
        [Fact]
        public async Task Deve_executar_save_changes()
        {
            var options = new DbContextOptionsBuilder<AnalystChallangeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var mockContext = new Mock<AnalystChallangeContext>(options);
            var unitOfWork = new Infra.UnitOfWork.UnitOfWork(mockContext.Object);

            await unitOfWork.Commit(CancellationToken.None);


            mockContext.Verify(x => x.SaveChangesAsync(CancellationToken.None));

        }
    }
}
