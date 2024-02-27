using marking_test_task.DTOs.Json;
using marking_test_task.Models;

namespace marking_test_task.Mappers
{
    public class MissionMapper : BaseMappper
    {
        public MissionMapper()
        {
            CreateMap<Mission, MissionDto>()
                .ForMember(dest => dest.MissionId, opt => opt.MapFrom(src => src.MissionId))
                .ForMember(dest => dest.Gtin, opt => opt.MapFrom(src => src.Gtin))
                .ForMember(dest => dest.PalleteCapacity, opt => opt.MapFrom(src => src.PalleteCapacity))
                .ForMember(dest => dest.BoxCapacity, opt => opt.MapFrom(src => src.BoxCapacity))
                .ForMember(dest => dest.Palletes, opt => opt.MapFrom(src => src.Palletes));
        }
    }
}
