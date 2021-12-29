using Microsoft.AspNetCore.Mvc;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.Thread;
using System;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class ThreadController : EntityApiController<IThread, Guid>
    {
        public ThreadController(IThreadService threadService) : base(threadService) { }
    }
}