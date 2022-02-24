using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBoard.API.Models.Stats;
using ReactBoard.Domain.Entities.Post;
using ReactBoard.Domain.Entities.User;
using ReactBoard.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactBoard.API.Controllers
{
    public class StatisticsController : AbstractApiController
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly IImageApiHttpService _imageApiHttpService;

        public StatisticsController(
            IUserService userService,
            IPostService postService,
            IImageApiHttpService imageApiHttpService)
        {
            _userService = userService;
            _postService = postService;
            _imageApiHttpService = imageApiHttpService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSiteStatistics()
        {
            return Ok(new List<SiteStatisticDto>
            {
                new SiteStatisticDto {
                    Placeholder = "Total Posts",
                    Value = (await _postService.GetEntityCountAsync()).ToString()
                },
                new SiteStatisticDto {
                    Placeholder = "Total Users",
                    Value = (await _userService.GetEntityCountAsync()).ToString()
                },
                new SiteStatisticDto {
                    Placeholder = "Total Images",
                    Value = (await _imageApiHttpService.GetEntityCountAsync()).ToString()
                }
            });
        }
    }
}
