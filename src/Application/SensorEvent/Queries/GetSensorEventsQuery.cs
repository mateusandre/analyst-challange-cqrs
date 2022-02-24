using Application.SensorEvent.DTO;
using MediatR;
using System.Collections.Generic;

namespace Application.SensorEvent.Queries
{
    public class GetSensorEventsQuery : IRequest<IEnumerable<SensorEventsDTO>>
    {
    }
}
