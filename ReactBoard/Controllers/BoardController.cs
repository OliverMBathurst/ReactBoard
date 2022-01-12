using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBoard.Attributes;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Models.Board;
using System.Linq;
using System.Threading.Tasks;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Controllers
{
    [Route("[controller]")]
    public class BoardController : EntityApiController<Board, int>
    {
        public BoardController(IBoardService boardService) : base(boardService) { }

        [HttpPost]
        [Authorise(UserRole.Admin)]
        public async Task<IActionResult> CreateNewBoard([FromBody] CreateBoardDto dto)
        {
            Board newBoard = dto;
            await _service.SaveOrUpdateAsync(newBoard);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}/delete")]
        [Authorise(UserRole.Admin, UserRole.BoardAdmin)]
        public async Task<IActionResult> DeleteBoard([FromRoute] int key) 
        {
            await _service.DeleteAsync(key);

            return Ok();
        }

        [HttpGet]
        [Route("{urlName}")]
        [AllowAnonymous]
        public IActionResult GetBoardByUrlName([FromRoute] string urlName)
        {
            if (string.IsNullOrWhiteSpace(urlName))
                return BadRequest("Invalid Board identifier");

            var board = _service.Fetch(x => x.UrlName.Equals(urlName)).FirstOrDefault();
            if (board == null)
                return NotFound();

            return Ok(board);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{boardId}/catalog")]
        public async Task<IActionResult> GetBoardCatalog([FromRoute] int boardId)
        {
            var board = await _service.GetByIdAsync(boardId);
            if (board == null)
                return NotFound();

            return Ok(board.Threads);
        }
    }
}