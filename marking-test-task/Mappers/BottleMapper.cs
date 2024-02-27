using marking_test_task.DTOs.Json;
using marking_test_task.Models;

namespace marking_test_task.Mappers
{
    public class BottleMapper : BaseMappper
    {
        public BottleMapper()
        {
            CreateMap<Bottle, BottleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code));
        }
    }
}
