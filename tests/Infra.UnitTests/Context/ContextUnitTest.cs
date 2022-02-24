using Domain.Entities;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Infra.UnitTests.Context
{
    public class ContextUnitTest : IDisposable
    {
        private readonly AnalystChallangeContext _context;

        public ContextUnitTest()
        {            
            var options = new DbContextOptionsBuilder<AnalystChallangeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new AnalystChallangeContext(options);
            _context.Evento.Add(new Domain.Entities.SensorEvent() { 
                Timestamp = 1539112021301,
                Tag = "brasil.sudeste.sensor01",
                Valor = "Teste"
            });

            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public async Task SaveChangesAsync_deve_criar_novo_evento()
        {
            //Arrange
            var data = new SensorEvent()
            {
                Timestamp = 1539112021301,
                Tag = "brasil.norte.sensor01",
                Valor = "Teste"
            };

            //Act
            await _context.Evento.AddAsync(data);
            await _context.SaveChangesAsync(CancellationToken.None);

            //Assert
            Assert.NotInRange(data.Id, 0, 0);
        }

    }
}
