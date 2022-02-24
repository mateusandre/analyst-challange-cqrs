using Application.SensorEvent.Commands;
using Application.SensorEvent.DTO;
using AutoMapper;

namespace Application.SensorEvent.MappingProfiles
{
    public class SensorEventMappingProfile : Profile
    {
        public SensorEventMappingProfile()
        {
            CreateMap<Domain.Entities.SensorEvent, SensorEventsDTO>();            
            CreateMap<CreateSensorEventCommand, Domain.Entities.SensorEvent>();
        }
    }
}
