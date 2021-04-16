using HypermediaAPI.ActionFilters;
using HypermediaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HypermediaAPI.Database.Entities;
using HypermediaAPI.Database.Repositories;
using System.Threading.Tasks;
using System;

namespace HypermediaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IRepository<ShoppingItem> _repo;

        public ShoppingController(IRepository<ShoppingItem> repo)
        {
            _repo = repo;
        }

        [HttpGet("", Name = nameof(GetAll))]
        [HATEOASFilter(nameof(CreateLinksForGetAll))]
        public async Task<ActionResult<IEnumerable<ShoppingItem>>> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        private List<Link> CreateLinksForGetAll()
        {
            return new()
            {
                new Link
                {
                    Href = "byId",
                    Rel = Url.Link(nameof(GetById), new { id = Guid.NewGuid() })
                }
            };
        }

        [HttpGet("{id}", Name = nameof(GetById))]
        [HATEOASFilter(nameof(CreateLinksForGetShoppingItemById))]
        public async Task<ActionResult<IEnumerable<ShoppingItem>>> GetById([FromRoute] Guid id)
        {
            return Ok(await _repo.GetByIdAsync(id));
        }

        private List<Link> CreateLinksForGetShoppingItemById()
        {
            return new()
            {
                new Link
                {
                    Href = "all",
                    Rel = Url.Link(nameof(GetAll), null)
                }
            };
        }
    }
}
