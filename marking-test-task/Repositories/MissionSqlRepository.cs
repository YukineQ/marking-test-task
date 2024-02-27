using marking_test_task.Context;
using marking_test_task.Models;
using Microsoft.EntityFrameworkCore;

namespace marking_test_task.Repositories
{
    public class MissionSqlRepository(ApplicationContext context) : IMissionRepository
    {
        private readonly ApplicationContext _context = context;

        public void Add(Mission mission)
        {
            _context.Missions.Add(mission);
        }

        public Mission GetSingleById(int id)
        {
            var missionWithNestedObj =
                _context.Missions
                    .Include(p => p.Palletes)
                    .ThenInclude(b => b.Boxes)
                    .ThenInclude(btl => btl.Bottles)
                    .AsSplitQuery()
                    .FirstOrDefault(p => p.MissionId == id);

            return missionWithNestedObj;
        }

        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
