using System.Collections.Generic;
using System.Threading.Tasks;
using Application.SensorEvent.Commands;
using Application.SensorEvent.DTO;
using Application.SensorEvent.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorEventController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSensorEventCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<IEnumerable<SensorEventsDTO>> Get()
        {
            return await Mediator.Send(new GetSensorEventsQuery());
        }

        [HttpGet]
        [Route("by-region")]
        public async Task<IEnumerable<object>> GetByRegion()
        {
            return await Mediator.Send(new GetSensorEventsByRegionQuery());
        }

        [HttpGet]
        [Route("numeric-event-value-by-region")]
        public async Task<IEnumerable<object>> GetNumericEventValueByRegion()
        {
            return await Mediator.Send(new GetSensorEventsWithNumericValueByRegionQuery());
        }
    }
}
