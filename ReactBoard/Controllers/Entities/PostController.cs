using Microsoft.AspNetCore.Mvc;
using ReactBoard.Controllers.Abstract;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Models.Post;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.Controllers.Entities
{
    public class PostController : EntityApiController<Post, long>
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService) : base(postService) 
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostDto postDto) 
        {
            Post newPost = postDto;
            await _service.SaveOrUpdateAsync(newPost);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllPostsForThread([FromQuery] int boardId, [FromQuery] int threadId)
        {
            return Ok(_postService.GetAllPostsForThread(boardId, threadId).ToList());
        }
    }
}