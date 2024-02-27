using marking_test_task.Context;
using marking_test_task.Models;
using Microsoft.EntityFrameworkCore;

namespace marking_test_task.Repositories
{
    public class PalleteSqlRepository : SequenceMixin, IPalleteRepository
    {
        private readonly ApplicationContext _context;
        protected override string TableName => _context.Palletes.EntityType.GetTableName();

        public PalleteSqlRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Pallete GetSingle(int id)
        {
            return _context.Palletes.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Pallete pallete)
        {
            _context.Palletes.Add(pallete);
        }

        public void AddMany(IEnumerable<Pallete> palletes)
        {
            _context.Palletes.AddRange(palletes);
        }

        public List<Pallete> GetAll()
        {
            return [.. _context.Palletes.OrderBy(x => x.Id)];
        }

        public List<Pallete> GetAllByMissionId(int missionId)
        {
            return [.. _context.Palletes.Where(x => x.MissionId == missionId)];
        }

        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
