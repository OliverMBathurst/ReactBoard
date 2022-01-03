using Microsoft.AspNetCore.Mvc;
using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Models.Post;
using System.Threading.Tasks;

namespace ReactBoard.Controllers.Entities
{
    [ApiController]
    public class PostController : EntityApiController<Post, PostKey>
    {
        public PostController(IPostService postService) : base(postService) { }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostDto postDto) 
        {
            Post newPost = postDto;
            await _service.SaveOrUpdateAsync(newPost);

            return Ok();
        }
    }
}