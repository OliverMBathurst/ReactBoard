using Microsoft.AspNetCore.Mvc;
using ReactChan.Domain.Entities.Board;

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

        [Route("all")]
        public IActionResult GetAllBoards()
        {
            return Ok(_boardService.GetAll());
        }
    }
}