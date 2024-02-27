using marking_test_task.Context;
using marking_test_task.Models;
using Microsoft.EntityFrameworkCore;

namespace marking_test_task.Repositories
{
    public class BoxSqlRepository : SequenceMixin, IBoxRepository
    {
        private readonly ApplicationContext _context;
        protected override string TableName => _context.Boxes.EntityType.GetTableName();

        public BoxSqlRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public Box GetSingle(int id)
        {
            return _context.Boxes.FirstOrDefault(x => x.Id == id);
        }

        public List<Box> GetAllByMissionId(int missionId)
        {
            return [.. _context.Boxes.Where(x => x.Pallete.MissionId == missionId).ToList()];
        }

        public void Add(Box box)
        {
            _context.Boxes.Add(box);
        }

        public void AddMany(IEnumerable<Box> boxes)
        {
            _context.Boxes.AddRange(boxes);
        }

        public List<Box> GetAll()
        {
            return [.. _context.Boxes];
        }

        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
