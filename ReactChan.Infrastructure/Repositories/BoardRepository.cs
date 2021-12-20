using ReactChan.Domain.Entities.Board;
using ReactChan.Infrastructure.DAL;
using System;
using System.Linq;

namespace ReactChan.Infrastructure.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ApplicationDbContext _context;

        public BoardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<IBoard> GetAll()
        {
            return _context.Boards;
        }

        public IQueryable<IBoard> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}