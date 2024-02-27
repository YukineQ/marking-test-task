namespace marking_test_task.DTOs.Json
{
    public class PalleteDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public List<BoxDto> Boxes { get; set; } = [];
    }
}
