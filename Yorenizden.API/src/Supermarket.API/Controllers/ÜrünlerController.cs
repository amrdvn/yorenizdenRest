using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Models.Queries;
using Yorenizden.API.Domain.Services;
using Yorenizden.API.Resources;

namespace Yorenizden.API.Controllers
{
    [Route("/api/Ürün")]
    [Produces("application/json")]
    [ApiController]
    public class ÜrünController : Controller
    {
        private readonly IÜrünlerervice _Ürünlerervice;
        private readonly IMapper _mapper;

        public ÜrünController(IÜrünlerervice Ürünlerervice, IMapper mapper)
        {
            _Ürünlerervice = Ürünlerervice;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existing Ürünler.
        /// </summary>
        /// <returns>List of Ürünler.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<ÜrünResource>), 200)]
        public async Task<QueryResultResource<ÜrünResource>> ListAsync([FromQuery] ÜrünlerQueryResource query)
        {
            var ÜrünQuery = _mapper.Map<ÜrünlerQueryResource, ÜrünlerQuery>(query);
            var queryResult = await _Ürünlerervice.ListAsync(ÜrünQuery);

            var resource = _mapper.Map<QueryResult<Ürün>, QueryResultResource<ÜrünResource>>(queryResult);
            return resource;
        }

        /// <summary>
        /// Saves a new Ürün.
        /// </summary>
        /// <param name="resource">Ürün data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ÜrünResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveÜrünResource resource)
        {
            var Ürün = _mapper.Map<SaveÜrünResource, Ürün>(resource);
            var result = await _Ürünlerervice.SaveAsync(Ürün);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var ÜrünResource = _mapper.Map<Ürün, ÜrünResource>(result.Resource);
            return Ok(ÜrünResource);
        }

        /// <summary>
        /// Updates an existing Ürün according to an identifier.
        /// </summary>
        /// <param name="id">Ürün identifier.</param>
        /// <param name="resource">Ürün data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ÜrünResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveÜrünResource resource)
        {
            var Ürün = _mapper.Map<SaveÜrünResource, Ürün>(resource);
            var result = await _Ürünlerervice.UpdateAsync(id, Ürün);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var ÜrünResource = _mapper.Map<Ürün, ÜrünResource>(result.Resource);
            return Ok(ÜrünResource);
        }

        /// <summary>
        /// Deletes a given Ürün according to an identifier.
        /// </summary>
        /// <param name="id">Ürün identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ÜrünResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _Ürünlerervice.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Ürün, ÜrünResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}