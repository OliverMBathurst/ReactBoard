using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ReactBoard.API.Controllers
{
    public class MessageKeyController : AbstractApiController
    {
        public MessageKeyController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessageKeys()
        {
            //todo

            return Ok();
        }
    }
}
