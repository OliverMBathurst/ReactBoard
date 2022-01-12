using Microsoft.AspNetCore.Mvc;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Models.Post;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.Controllers
{
    [Route("[controller]")]
    public class PostController : EntityApiController<Post, long>
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService) : base(postService) 
        {
            _postService = postService;
        }

        [HttpGet]
        [Route("thread")]
        public IActionResult GetAllPostsForThread([FromQuery] long threadId, [FromQuery] int boardId) 
        {
            return Ok(_postService.GetAllPostsForThread(threadId, boardId).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostDto postDto) 
        {
            Post newPost = postDto;
            await _service.SaveOrUpdateAsync(newPost);

            return Ok();
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetPost([FromQuery] long postId)
        {
            var entity = await _postService.GetPostAsync(postId);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
    }
}