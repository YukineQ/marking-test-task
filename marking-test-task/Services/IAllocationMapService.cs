using marking_test_task.Models.Responce;

namespace marking_test_task.Services
{
    public interface IAllocationMapService
    {
        Task GenerateMap(CurrentTask currentTask);
    }
}
