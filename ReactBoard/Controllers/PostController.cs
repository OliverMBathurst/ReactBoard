using Microsoft.AspNetCore.Mvc;
using ReactBoard.API.Models.Post;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.API.Controllers
{
    public class PostController : EntityApiController<Post, long>
    {
        private readonly IPostService _postService;
        private readonly IImageApiHttpService _imageApiHttpService;

        public PostController(
            IPostService postService,
            IImageApiHttpService imageApiHttpService) : base(postService)
        {
            _postService = postService;
            _imageApiHttpService = imageApiHttpService;
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePost([FromRoute] long postId)
        {
            var post = await _postService.GetByIdAsync(postId);
            if (post == null)
                return NotFound();

            if (post.ImageId.HasValue)
                await _imageApiHttpService.DeleteImageAsync(post.ImageId.Value);

            await _postService.DeleteAsync(postId);
            return Ok();
        }

        [HttpGet]
        [Route("thread")]
        public async Task<IActionResult> GetAllPostsForThread([FromQuery] long threadId)
        {
            var posts = _postService.GetAllPostsForThread(threadId)
                .Select(post => new PostDto(post))
                .ToList();

            foreach (var post in posts)
                if (post.ImageId.HasValue)
                    post.Image = await _imageApiHttpService.GetImageAsync(post.ImageId.Value);

            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostDto postDto)
        {
            Post newPost = postDto;
            await _service.SaveOrUpdateAsync(newPost);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPost([FromQuery] long postId)
        {
            var post = await _postService.GetPostAsync(postId);
            if (post == null)
                return NotFound();

            var dto = new PostDto(post);
            if (post.ImageId.HasValue)
                dto.Image = await _imageApiHttpService.GetImageAsync(post.ImageId.Value);

            return Ok(dto);
        }
    }
}