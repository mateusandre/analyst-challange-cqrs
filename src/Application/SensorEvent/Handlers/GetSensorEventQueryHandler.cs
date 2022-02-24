using Application.SensorEvent.DTO;
using Application.SensorEvent.Queries;
using AutoMapper;
using Infra.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SensorEvent.Handlers
{
    public class GetSensorEventQueryHandler : IRequestHandler<GetSensorEventsQuery, IEnumerable<SensorEventsDTO>>
    {
        protected IRepository<Domain.Entities.SensorEvent> _repo;
        private readonly IMapper _mapper;

        public GetSensorEventQueryHandler(IRepository<Domain.Entities.SensorEvent> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<IEnumerable<SensorEventsDTO>> Handle(GetSensorEventsQuery request, CancellationToken cancellationToken)
        {           
            var data = await _repo.GetAll(cancellationToken);
            return _mapper.Map<IEnumerable<SensorEventsDTO>>(data);
        }
    }
}
