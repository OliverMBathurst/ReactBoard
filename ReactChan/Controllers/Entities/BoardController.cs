using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.Board;
using ReactChan.Domain.Entities.User;
using ReactChan.Models.Board;
using System;
using System.Threading.Tasks;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class BoardController : EntityApiController<IBoard, Guid>
    {
        public BoardController(IBoardService boardService) : base(boardService) { }

        [HttpPost]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<IActionResult> CreateNewBoard([FromBody] CreateBoardDto dto)
        {
            Board newBoard = dto;
            await _service.SaveOrUpdateAsync(newBoard);
            return Ok();
        }

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