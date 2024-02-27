using AutoMapper;
using marking_test_task.Config;
using marking_test_task.DTOs.Json;
using marking_test_task.Models.Responce;
using marking_test_task.Repositories;
using Newtonsoft.Json;

namespace marking_test_task.Services
{
    public class AllocationMapService : IAllocationMapService
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;

        public AllocationMapService(
            IMissionRepository missionRepository, 
            IMapper mapper
        )
        {
            _missionRepository = missionRepository;
            _mapper = mapper;
        }

        public async Task GenerateMap(CurrentTask currentTask)
        {
            var missionId = currentTask.MissionResponce.Id;
            var gtin = currentTask.MissionResponce.Lot.Product.Gtin;

            var mission = _missionRepository.GetSingleById(missionId) 
                ?? throw new Exception($"Mission with ID {missionId} does not exist.");

            var mappedMission = _mapper.Map<MissionDto>(mission);

            var serializedMission = JsonConvert.SerializeObject(
                mappedMission,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }
            );

            FileService.WriteAll(FileNameRule.GetFileName(gtin), serializedMission);
        }
    }
}
