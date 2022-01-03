using Microsoft.AspNetCore.Mvc;
using ReactBoard.Attributes;
using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.Thread;
using System.Threading.Tasks;
using static ReactBoard.Domain.Entities.User.Enums;

namespace ReactBoard.Controllers.Entities
{
    [ApiController]
    public class ThreadController : EntityApiController<Thread, ThreadKey>
    {
        public ThreadController(IThreadService threadService) : base(threadService) { }

        [HttpDelete]
        [Route("delete")]
        [Authorise(UserRole.Admin, UserRole.BoardAdmin)]
        public async Task<IActionResult> DeleteThread([FromRoute] ThreadKey key)
        {
            //todo: check board admin has admin access to board thread is in

            await _service.DeleteAsync(key);

            return Ok();
        }
    }
}