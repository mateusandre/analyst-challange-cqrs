using MediatR;

namespace Application.SensorEvent.Commands
{
    public class CreateSensorEventCommand : IRequest<int>
    {
        public long Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}
