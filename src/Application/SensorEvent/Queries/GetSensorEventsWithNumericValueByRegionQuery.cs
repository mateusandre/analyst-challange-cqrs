using MediatR;
using System.Collections.Generic;

namespace Application.SensorEvent.Queries
{
    public class GetSensorEventsWithNumericValueByRegionQuery : IRequest<IEnumerable<object>>
    {
    }
}
