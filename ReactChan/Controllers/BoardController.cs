using Microsoft.AspNetCore.Mvc;
using ReactChan.Domain.Entities.Board;
using System;
using System.Threading.Tasks;

namespace ReactChan.Controllers
{
    [ApiController]
    public class BoardController : Controller
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService) 
        { 
            _boardService = boardService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllBoards()
        {
            return Ok(_boardService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetBoard([FromRoute] Guid boardId)
        {
            if (boardId == Guid.Empty)
                return BadRequest("Invalid board identifier");

            var board = await _boardService.GetByIdAsync(boardId);
            if (board == null)
                return BadRequest();

            return Ok(board);
        }
    }
}