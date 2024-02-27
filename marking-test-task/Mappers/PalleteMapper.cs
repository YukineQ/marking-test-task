using marking_test_task.DTOs.Json;
using marking_test_task.Models;

namespace marking_test_task.Mappers
{
    public class PalleteMapper : BaseMappper
    {
        public PalleteMapper()
        {
            CreateMap<Pallete, PalleteDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Boxes, opt => opt.MapFrom(src => src.Boxes));
        }
    }
}
