using Microsoft.AspNetCore.Mvc;
using ReactBoard.API.Models.Thread;
using ReactBoard.Domain.Entities.Thread;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.API.Controllers
{
    public class ThreadController : EntityApiController<Thread, long>
    {
        private readonly IThreadService _threadService;

        public ThreadController(IThreadService threadService) : base(threadService)
        {
            _threadService = threadService;
        }

        [HttpPost]
        [Route("updates")]
        public async Task<IActionResult> GetUpdates([FromBody] ThreadUpdateRequestDto updateRequestDto)
        {
            var newPosts = await _threadService.GetNewPosts(updateRequestDto.ThreadId, updateRequestDto.Latest);
            return Ok(newPosts.ToList());
        }

        [HttpGet]
        [Route("pagination")]
        public async Task<IActionResult> GetPaginatedThreads([FromQuery] int boardId, [FromQuery] int pageNumber)
        {
            return Ok(await _threadService.GetPaginatedThreadsForBoard(boardId, pageNumber));
        }

        [HttpPost]
        public async Task<IActionResult> PostNewThread([FromBody] CreateThreadDto thread)
        {
            Thread newThread = thread;
            await _threadService.SaveOrUpdateAsync(newThread);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetThread([FromQuery] long threadId)
        {
            return Ok(await _threadService.GetThreadAsync(threadId));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteThread([FromQuery] long threadId)
        {
            //todo: check board admin has admin access to board thread is in

            await _threadService.DeleteThreadAsync(threadId);

            return Ok();
        }
    }
}