using Application.SensorEvent.Commands;
using AutoMapper;
using Infra.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SensorEvent.Handlers
{
    public class CreateSensorEventCommandHandler : IRequestHandler<CreateSensorEventCommand, int>
    {
        protected IRepository<Domain.Entities.SensorEvent> _repo;
        private readonly IMapper _mapper;

        public CreateSensorEventCommandHandler(IRepository<Domain.Entities.SensorEvent> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<int> Handle(CreateSensorEventCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.SensorEvent>(request);

            await _repo.Adicionar(entity, cancellationToken);
            await _repo.Salvar(cancellationToken);

            return entity.Id;
        }
    }
}
