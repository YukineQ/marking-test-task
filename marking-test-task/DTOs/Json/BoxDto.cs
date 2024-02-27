namespace marking_test_task.DTOs.Json
{
    public class BoxDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public List<BottleDto> Bottles { get; set; } = new();
    }
}
