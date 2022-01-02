using Microsoft.EntityFrameworkCore;
using ReactChan.Domain.Entities.Board;
using ReactChan.Infrastructure.Common;
using ReactChan.Infrastructure.DAL;
using System.Threading.Tasks;
using _Board = ReactChan.Domain.Entities.Board.Board;

namespace ReactChan.Infrastructure.Repositories.Board
{
    public class BoardRepository : EntityRepository<_Board, BoardKey>, IBoardRepository
    {
        public BoardRepository(ApplicationDbContext context) : base(context) { }

        public override async Task DeleteAsync(BoardKey id)
        {
            var removal = await _context.Set<_Board>()
                .Include(x => x.Threads)
                .ThenInclude(x => x.Posts)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (removal != null)
            {
                _context.Remove(removal);
                await _context.SaveChangesAsync();
            }
        }
    }
}