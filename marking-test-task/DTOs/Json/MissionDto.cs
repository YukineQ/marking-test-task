namespace marking_test_task.DTOs.Json
{
    public class MissionDto
    {
        public int MissionId { get; set; }
        public string Gtin { get; set; }
        public int BoxCapacity { get; set; }
        public int PalleteCapacity { get; set; }
        public List<PalleteDto> Palletes { get; set; } = [];
    }
}
