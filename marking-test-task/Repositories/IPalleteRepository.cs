using marking_test_task.Models;

namespace marking_test_task.Repositories
{
    public interface IPalleteRepository : ISequenceMixin
    {
        Pallete GetSingle(int id);
        void Add(Pallete pallete);
        void AddMany(IEnumerable<Pallete> palletes);
        List<Pallete> GetAll();
        List<Pallete> GetAllByMissionId(int missionId);
        bool Save();
    }
}
