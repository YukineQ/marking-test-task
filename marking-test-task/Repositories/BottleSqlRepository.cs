using marking_test_task.Context;
using marking_test_task.Models;
using Microsoft.EntityFrameworkCore;

namespace marking_test_task.Repositories
{
    public class BottleSqlRepository(ApplicationContext context) : IBottleRepository
    {
        private readonly ApplicationContext _context = context;

        public Bottle GetSingle(int id)
        {
            return _context.Bottles.FirstOrDefault(x => x.Id == id);
        }

        public List<Bottle> GetAllByMissionId(int missionId)
        {
            return [.. _context.Bottles.Where(x => x.Boxses.Pallete.MissionId == missionId)];
        }
        public void Add(Bottle bottle)
        {
            _context.Bottles.Add(bottle);
        }

        public List<Bottle> GetAll()
        {
            return [.. _context.Bottles];
        }
    }
}
