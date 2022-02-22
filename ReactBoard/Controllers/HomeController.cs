using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReactBoard.API.Models.Thread;
using ReactBoard.Domain.Entities.Board;
using ReactBoard.Domain.Entities.Thread;
using ReactBoard.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ReactBoard.Domain.Entities.Thread.Enums;

namespace ReactBoard.API.Controllers
{
    public class HomeController : AbstractApiController
    {
        private readonly AppSettings _appSettings;
        private readonly IThreadService _threadService;
        private readonly IBoardService _boardService;

        public HomeController(
            IOptions<AppSettings> options,
            IThreadService threadService,
            IBoardService boardService)
        {
            _appSettings = options.Value;
            _threadService = threadService;
            _boardService = boardService;
        }

        [HttpGet]
        [Route("featured/{threadFilter}")]
        public async Task<IActionResult> GetFeaturedThreads([FromRoute] ThreadFilter threadFilter)
        {
            IEnumerable<IBoard> boards = _boardService.GetAll().Where(x => x.Threads.Count > 0);

            if (threadFilter == ThreadFilter.ShowNSFWContentOnly)
            {
                boards = boards.Where(board => !board.IsWorkSafe);
            }
            else if (threadFilter == ThreadFilter.ShowSFWContentOnly)
            {
                boards = boards.Where(board => board.IsWorkSafe);
            }

            boards = boards.OrderBy(x => Guid.NewGuid())
                .Take(_appSettings.MaxFeaturedThreads)
                .ToList();

            var tasks = boards.Select(async board =>
            {
                var thread = await _threadService.GetTopThreadByBoardIdAsync(board.Id);
                return new FeaturedThreadDto(thread)
                {
                    BoardName = board.Name,
                    BoardUrlName = board.UrlName
                };
            });

            return Ok(await Task.WhenAll(tasks));
        }
    }
}
