using Microsoft.AspNetCore.Mvc;
using ReactChan.Domain.Entities.Thread;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReactChan.Controllers
{
    [ApiController]
    public class ThreadController : Controller
    {
        private readonly IThreadService _threadService;

        public ThreadController(IThreadService threadService) 
        {
            _threadService = threadService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllThreads()
        {
            return Ok(_threadService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetThread([FromRoute] Guid threadId)
        {
            if (threadId == Guid.Empty)
                return BadRequest("Invalid thread identifier");

            var thread = await _threadService.GetByIdAsync(threadId);
            if (thread == null)
                return NotFound();

            return Ok(thread);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllThreadsForBoard([FromRoute] Guid boardId)
        {
            if (boardId == Guid.Empty)
                return BadRequest("Invalid board identifier");

            return Ok(_threadService.Fetch(x => x.BoardId == boardId).ToList());
        }
    }
}