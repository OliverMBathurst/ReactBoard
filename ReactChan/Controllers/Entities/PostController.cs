using Microsoft.AspNetCore.Mvc;
using ReactChan.Controllers.Abstract;
using ReactChan.Domain.Entities.Post;
using ReactChan.Models.Post;
using System;
using System.Threading.Tasks;

namespace ReactChan.Controllers.Entities
{
    [ApiController]
    public class PostController : EntityApiController<Post, Guid>
    {
        public PostController(IPostService postService) : base(postService) { }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostDto postDto) 
        {
            //Add post


            return Ok();
        }
    }
}