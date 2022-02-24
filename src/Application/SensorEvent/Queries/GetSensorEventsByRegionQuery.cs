using Application.SensorEvent.DTO;
using MediatR;
using System.Collections.Generic;

namespace Application.SensorEvent.Queries
{
    public class GetSensorEventsByRegionQuery : IRequest<IEnumerable<object>>
    {
    }
}
