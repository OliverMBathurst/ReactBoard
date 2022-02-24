using Microsoft.AspNetCore.Mvc;

namespace ReactBoard.ImageAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class AbstractApiController : Controller
    {
    }
}
