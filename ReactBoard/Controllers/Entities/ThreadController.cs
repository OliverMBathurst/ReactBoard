using Microsoft.AspNetCore.Mvc;
using ReactBoard.Attributes;
using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.Thread;
using System.Threading.Tasks;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Controllers.Entities
{
    public class ThreadController : EntityApiController<Thread, long>
    {
        private readonly IThreadService _threadService;

        public ThreadController(IThreadService threadService) : base(threadService) 
        {
            _threadService = threadService;
        }

        [HttpDelete]
        [Authorise(UserRole.Admin, UserRole.BoardAdmin)]
        [Route("{threadId}/board/{boardId}")]
        public async Task<IActionResult> DeleteThread([FromRoute] int boardId, [FromRoute] long threadId)
        {
            //todo: check board admin has admin access to board thread is in

            await _threadService.DeleteThread(boardId, threadId);

            return Ok();
        }
    }
}