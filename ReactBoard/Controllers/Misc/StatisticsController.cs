using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Domain.Entities.User;
using ReactBoard.Models.Stats;
using System.Threading.Tasks;

namespace ReactBoard.Controllers.Misc
{
    public class StatisticsController : Controller
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
                TotalPosts = await _postService.GetStatisticAsync(),
                TotalUsers = await _userService.GetStatisticAsync()
            });
        }
    }
}
