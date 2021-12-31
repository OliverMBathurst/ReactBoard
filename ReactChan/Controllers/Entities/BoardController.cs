using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactChan.Attributes;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.Board;
using ReactChan.Models.Board;
using System;
using System.Linq;
using System.Threading.Tasks;
using static ReactChan.Domain.Entities.User.Enums;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class BoardController : EntityApiController<Board, Guid>
    {
        public BoardController(IBoardService boardService) : base(boardService) { }

        [HttpPost]
        [Attributes.Authorise(UserRole.Admin)]
        public async Task<IActionResult> CreateNewBoard([FromBody] CreateBoardDto dto)
        {
            Board newBoard = dto;
            await _service.SaveOrUpdateAsync(newBoard);
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        [Attributes.Authorise(UserRole.Admin, UserRole.BoardAdmin)]
        public async Task<IActionResult> DeleteBoard([FromRoute] Guid boardId) 
        {
            if (boardId == Guid.Empty)
                return BadRequest("Invalid board identifier");

            await _service.DeleteAsync(boardId);

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBoardByUrlName([FromRoute] string boardUrlName)
        {
            if (string.IsNullOrWhiteSpace(boardUrlName))
                return BadRequest("Invalid Board identifier");

            var board = _service.Fetch(x => x.BoardUrlName.Equals(boardUrlName)).FirstOrDefault();
            if (board == null)
                return NotFound();

            return Ok(board);
        }

        [HttpGet]
        [AllowAnonymous]
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