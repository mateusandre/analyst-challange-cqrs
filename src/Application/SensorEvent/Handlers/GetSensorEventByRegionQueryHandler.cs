using Application.SensorEvent.DTO;
using Application.SensorEvent.Queries;
using AutoMapper;
using Infra.Repository;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SensorEvent.Handlers
{
    public class GetSensorEventByRegionQueryHandler : IRequestHandler<GetSensorEventsByRegionQuery, IEnumerable<object>>
    {
        protected IRepository<Domain.Entities.SensorEvent> _repo;
        private readonly IMapper _mapper;

        public GetSensorEventByRegionQueryHandler(IRepository<Domain.Entities.SensorEvent> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<IEnumerable<object>> Handle(GetSensorEventsByRegionQuery request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAll(cancellationToken);
            var mappedData = _mapper.Map<IEnumerable<SensorEventsDTO>>(data);
            return mappedData
                    .GroupBy(x => x.Regiao)
                    .Select(x => new
                    {
                        Regiao = x.Key,
                        Sensores = x.GroupBy(y => y.Sensor).Select(y => new
                        {
                            Sensor = y.Key,
                            Eventos = y.ToList()
                        }).ToList()
                    }).ToList();
        }
    }
}
