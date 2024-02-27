using marking_test_task.Context;
using marking_test_task.Models;
using Microsoft.EntityFrameworkCore;

namespace marking_test_task.Repositories
{
    public abstract class SequenceMixin : ISequenceMixin
    {
        protected abstract string TableName { get; }
        private readonly ApplicationContext _context;

        public SequenceMixin(ApplicationContext context)
        {
            _context = context;
        }

        public Sequence GetSequence()
        {
            var sequence = _context.Database.SqlQuery<Sequence>(
                @$"select * from sqlite_sequence")
                .Where(x => x.Name == TableName)
                .First();

            return sequence;
        }
    }
}
