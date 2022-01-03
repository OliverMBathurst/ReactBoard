using Microsoft.EntityFrameworkCore;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Infrastructure.Common;
using ReactBoard.Infrastructure.DAL;
using System.Threading.Tasks;
using _Board = ReactBoard.Domain.Entities.Board.Board;

namespace ReactBoard.Infrastructure.Repositories.Board
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