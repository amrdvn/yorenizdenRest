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
    [Route("/api/�r�n")]
    [Produces("application/json")]
    [ApiController]
    public class �r�nController : Controller
    {
        private readonly I�r�nlerervice _�r�nlerervice;
        private readonly IMapper _mapper;

        public �r�nController(I�r�nlerervice �r�nlerervice, IMapper mapper)
        {
            _�r�nlerervice = �r�nlerervice;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existing �r�nler.
        /// </summary>
        /// <returns>List of �r�nler.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<�r�nResource>), 200)]
        public async Task<QueryResultResource<�r�nResource>> ListAsync([FromQuery] �r�nlerQueryResource query)
        {
            var �r�nQuery = _mapper.Map<�r�nlerQueryResource, �r�nlerQuery>(query);
            var queryResult = await _�r�nlerervice.ListAsync(�r�nQuery);

            var resource = _mapper.Map<QueryResult<�r�n>, QueryResultResource<�r�nResource>>(queryResult);
            return resource;
        }

        /// <summary>
        /// Saves a new �r�n.
        /// </summary>
        /// <param name="resource">�r�n data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(�r�nResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] Save�r�nResource resource)
        {
            var �r�n = _mapper.Map<Save�r�nResource, �r�n>(resource);
            var result = await _�r�nlerervice.SaveAsync(�r�n);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var �r�nResource = _mapper.Map<�r�n, �r�nResource>(result.Resource);
            return Ok(�r�nResource);
        }

        /// <summary>
        /// Updates an existing �r�n according to an identifier.
        /// </summary>
        /// <param name="id">�r�n identifier.</param>
        /// <param name="resource">�r�n data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(�r�nResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Save�r�nResource resource)
        {
            var �r�n = _mapper.Map<Save�r�nResource, �r�n>(resource);
            var result = await _�r�nlerervice.UpdateAsync(id, �r�n);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var �r�nResource = _mapper.Map<�r�n, �r�nResource>(result.Resource);
            return Ok(�r�nResource);
        }

        /// <summary>
        /// Deletes a given �r�n according to an identifier.
        /// </summary>
        /// <param name="id">�r�n identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(�r�nResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _�r�nlerervice.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<�r�n, �r�nResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}