using marking_test_task.Models;

namespace marking_test_task.Repositories
{
    public interface IBoxRepository : ISequenceMixin
    {
        Box GetSingle(int id);
        void Add(Box box);
        void AddMany(IEnumerable<Box> boxes);
        List<Box> GetAllByMissionId(int missionId);
        List<Box> GetAll();
        bool Save();
    }
}
