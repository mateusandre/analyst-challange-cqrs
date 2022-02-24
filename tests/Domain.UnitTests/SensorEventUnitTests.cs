using Domain.Entities;
using Xunit;

namespace Domain.UnitTests
{
    public class SensorEventUnitTests
    {
        [Fact]
        public void Deve_adicionar_o_status_processado_no_sensor_event()
        {
            var sensorEvent = new SensorEvent
            {
                Timestamp = 1615600934,
                Tag = "brasil.sudeste.sensor01",
                Valor = "Teste"
            };

            Assert.Equal("Processado", sensorEvent.Status);
        }

        [Fact]
        public void Deve_adicionar_o_status_erro_no_sensor_event_quando_iniciar_vazio()
        {
            var sensorEvent = new SensorEvent();

            Assert.Equal("Erro", sensorEvent.Status);
        }

        [Fact]
        public void Deve_adicionar_o_status_erro_no_sensor_event_quando_passar_string_vazia()
        {
            var sensorEvent = new SensorEvent
            {
                Timestamp = 1615600934,
                Tag = "brasil.sudeste.sensor01",
                Valor = ""
            };

            Assert.Equal("Erro", sensorEvent.Status);
        }
    }
}
