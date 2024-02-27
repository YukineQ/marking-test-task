using marking_test_task.DTOs.Json;
using marking_test_task.Models;

namespace marking_test_task.Mappers
{
    public class BoxMapper : BaseMappper
    {
        public BoxMapper()
        {
            CreateMap<Box, BoxDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Bottles, opt => opt.MapFrom(src => src.Bottles));
        }
    }
}
