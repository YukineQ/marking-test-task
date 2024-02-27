using marking_test_task.Models;

namespace marking_test_task.Repositories
{
    public interface IMissionRepository
    {
        Mission GetSingleById(int id);
        void Add(Mission mission);
        bool Save();
    }
}
