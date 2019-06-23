using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodMarket.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseRestController<TEntity> : ControllerBase
        where TEntity : class, new()
    {
        protected GoodMarketDbContext _db;
        protected DbSet<TEntity> _set;
        protected IMediator _mediator;

        public BaseRestController(GoodMarketDbContext context, IMediator mediator)
        {
            _db = context;
            _set = _db.Set<TEntity>();
            _mediator = mediator;
        }

        [HttpGet("default")]
        public virtual async Task<TEntity> GetDefaultEntity()
        {
            var result = new TEntity();
            return await Task.FromResult(result);
        }


        // GET api/values
        [HttpGet("")]
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _mediator.Send(new BaseGetAllQuery<TEntity>());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> Get(int id)
        {
            return await _mediator.Send(new BaseGetQuery<TEntity>(id));
        }

        // POST api/values
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntity value)
        {
            var result = await _mediator.Send(new BaseCreateCommand<TEntity>(value));
            return Ok(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] TEntity value)
        {
            var result = await _mediator.Send(new BaseUpdateCommand<TEntity>(id, value));
            if (result == null) return NotFound();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var rem = await _set.FindAsync(id);
            if (rem == null) return NotFound();
            var result = await _mediator.Send(new BaseDeleteCommand<TEntity>(rem));
            return Ok();
        }
    }
}
