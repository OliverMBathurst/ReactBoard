using Microsoft.AspNetCore.Mvc;
using ReactBoard.Attributes;
using ReactBoard.Domain.Entities.Thread;
using System.Threading.Tasks;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Controllers
{
    [Route("[controller]")]
    public class ThreadController : EntityApiController<Thread, long>
    {
        private readonly IThreadService _threadService;

        public ThreadController(IThreadService threadService) : base(threadService) 
        {
            _threadService = threadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetThread([FromQuery] long threadId, [FromQuery] int boardId)
        {
            return Ok(await _threadService.GetThreadAsync(threadId, boardId));
        }

        [HttpDelete]
        [Authorise(UserRole.Admin, UserRole.BoardAdmin)]
        public async Task<IActionResult> DeleteThread([FromQuery] long threadId, [FromQuery] int boardId)
        {
            //todo: check board admin has admin access to board thread is in

            await _threadService.DeleteThreadAsync(threadId, boardId);

            return Ok();
        }
    }
}