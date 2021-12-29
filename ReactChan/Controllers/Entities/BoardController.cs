using Microsoft.AspNetCore.Mvc;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.Board;
using System;
using System.Threading.Tasks;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class BoardController : EntityApiController<IBoard, Guid>
    {
        public BoardController(IBoardService boardService) : base(boardService) { }

        [HttpGet]
        [Route("{boardId}/catalog")]
        public async Task<IActionResult> GetBoardCatalog([FromRoute] Guid boardId) 
        {
            if (boardId == Guid.Empty)
                return BadRequest("Invalid identifier");

            var board = await _service.GetByIdAsync(boardId);
            if (board == null)
                return NotFound();

            return Ok(board.Threads);
        }
    }
}