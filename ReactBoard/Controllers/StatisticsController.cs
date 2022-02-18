using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBoard.API.Models.Stats;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Domain.Entities.User;
using System.Threading.Tasks;

namespace ReactBoard.API.Controllers
{
    public class StatisticsController : AbstractApiController
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;

        public StatisticsController(
            IUserService userService,
            IPostService postService)
        {
            _userService = userService;
            _postService = postService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSiteStatistics()
        {
            return Ok(new SiteStatisticsDto
            {
                TotalPosts = await _postService.GetEntityCountAsync(),
                TotalUsers = await _userService.GetEntityCountAsync()
            });
        }
    }
}
