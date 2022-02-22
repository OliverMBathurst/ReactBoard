using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBoard.API.Models.Board;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Domain.Entities.Thread;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.API.Controllers
{
    public class BoardController : EntityApiController<Board, int>
    {
        private readonly IBoardService _boardService;
        private readonly IThreadService _threadService;

        public BoardController(
            IBoardService boardService,
            IThreadService threadService) : base(boardService)
        {
            _boardService = boardService;
            _threadService = threadService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllBoards() 
        {
            return Ok(_service.GetAll().ToList());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{boardUrlName}/catalog")]
        public async Task<IActionResult> GetCatalog([FromRoute] string boardUrlName)
        {
            if (string.IsNullOrWhiteSpace(boardUrlName))
                return BadRequest();

            var board = await _boardService.GetByUrlNameAsync(boardUrlName);
            if (board == null)
                return NotFound();

            var dtos = _threadService.GetAllBoardThreads(board.Id)
                .Select(x => new BoardCatalogItemDto
                {
                    TotalReplies = x.Posts.Count - 1,
                    TotalImages = x.Posts.Count(x => x.ImageId.HasValue),
                    OriginalPost = x.Posts.OrderBy(x => x.Time).First()
                }).ToList();

            return Ok(new BoardCatalogDto { Items = dtos });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetBoardByUrlName([FromRoute] string urlName)
        {
            if (string.IsNullOrWhiteSpace(urlName))
                return BadRequest("Invalid Board identifier");

            var board = await _boardService.GetByUrlNameAsync(urlName);
            if (board == null)
                return NotFound();

            return Ok(board);
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteBoard([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewBoard([FromBody] CreateBoardDto dto)
        {
            Board newBoard = dto;
            await _service.SaveOrUpdateAsync(newBoard);
            return Ok();
        }
    }
}