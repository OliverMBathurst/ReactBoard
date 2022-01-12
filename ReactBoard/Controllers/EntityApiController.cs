using Microsoft.AspNetCore.Mvc;
using ReactBoard.Domain.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBoard.Controllers
{
    public abstract class EntityApiController<TEntity, TId> : Controller 
        where TEntity : class, IEntity<TId>
    {
        protected readonly IEntityService<TEntity, TId> _service;

        protected EntityApiController(IEntityService<TEntity, TId> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("all")]
        public virtual IActionResult GetAllEntities()
        {
            return Ok(_service.GetAll().ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> GetEntityById([FromRoute] TId id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }
    }
}