using Microsoft.AspNetCore.Mvc;
using ReactChan.Attributes;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.Thread;
using System;
using System.Threading.Tasks;
using static ReactChan.Domain.Entities.User.Enums;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class ThreadController : EntityApiController<Thread, Guid>
    {
        public ThreadController(IThreadService threadService) : base(threadService) { }

        [HttpDelete]
        [Route("delete")]
        [Authorise(UserRole.Admin, UserRole.BoardAdmin)]
        public async Task<IActionResult> DeleteThread([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            //todo: check board admin has admin access to board thread is in

            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}