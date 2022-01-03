using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBoard.Attributes;
using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Models.Board;
using System.Linq;
using System.Threading.Tasks;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Controllers.Entities
{
    [ApiController]
    public class BoardController : EntityApiController<Board, BoardKey>
    {
        public BoardController(IBoardService boardService) : base(boardService) { }

        [HttpPost]
        [Route("create")]
        [Authorise(UserRole.Admin)]
        public async Task<IActionResult> CreateNewBoard([FromBody] CreateBoardDto dto)
        {
            Board newBoard = dto;
            await _service.SaveOrUpdateAsync(newBoard);
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        [Authorise(UserRole.Admin, UserRole.BoardAdmin)]
        public async Task<IActionResult> DeleteBoard([FromBody] BoardKey key) 
        {
            await _service.DeleteAsync(key);

            return Ok();
        }

        [HttpGet]
        [Route("{boardUrlName}")]
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
        public async Task<IActionResult> GetBoardCatalog([FromBody] BoardKey key)
        {
            var board = await _service.GetByIdAsync(key);
            if (board == null)
                return NotFound();

            return Ok(board.Threads);
        }
    }
}