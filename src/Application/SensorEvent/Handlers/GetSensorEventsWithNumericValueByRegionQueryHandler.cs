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
    public class GetSensorEventsWithNumericValueByRegionQueryHandler : IRequestHandler<GetSensorEventsWithNumericValueByRegionQuery, IEnumerable<object>>
    {
        protected IRepository<Domain.Entities.SensorEvent> _repo;
        private readonly IMapper _mapper;

        public GetSensorEventsWithNumericValueByRegionQueryHandler(IRepository<Domain.Entities.SensorEvent> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<IEnumerable<object>> Handle(GetSensorEventsWithNumericValueByRegionQuery request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAll(cancellationToken);
            var mappedData = _mapper.Map<IEnumerable<SensorEventsDTO>>(data);
            return mappedData.Where(x => int.TryParse(x.Valor, out _))
                    .GroupBy(x => x.Regiao)
                    .Select(x => new
                    {
                        Regiao = x.Key,
                        Eventos = x.ToList()
                    }).ToList();
        }
    }
}
