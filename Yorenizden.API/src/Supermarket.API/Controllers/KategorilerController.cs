using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Services;
using Yorenizden.API.Resources;

namespace Yorenizden.API.Controllers
{
    [Route("/api/kategoriler")]
    [Produces("application/json")]
    [ApiController]
    public class KategorilerController : Controller
    {
        private readonly IKategoriService _categoryService;
        private readonly IMapper _mapper;

        public KategorilerController(IKategoriService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all Kategoriler.
        /// </summary>
        /// <returns>List os Kategoriler.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KategoriResource>), 200)]
        public async Task<IEnumerable<KategoriResource>> ListAsync()
        {
            var kategoriler = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Kategori>, IEnumerable<KategoriResource>>(kategoriler);

            return resources;
        }

        /// <summary>
        /// Saves a new category.
        /// </summary>
        /// <param name="resource">Category data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(KategoriResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveKategoriResource resource)
        {
            var kategori = _mapper.Map<SaveKategoriResource, Kategori>(resource);
            var result = await _categoryService.SaveAsync(kategori);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Kategori, KategoriResource>(result.Resource);
            return Ok(categoryResource);
        }

        /// <summary>
        /// Updates an existing category according to an identifier.
        /// </summary>
        /// <param name="id">Category identifier.</param>
        /// <param name="resource">Updated category data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(KategoriResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveKategoriResource resource)
        {
            var kategori = _mapper.Map<SaveKategoriResource, Kategori>(resource);
            var result = await _categoryService.UpdateAsync(id, kategori);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Kategori, KategoriResource>(result.Resource);
            return Ok(categoryResource);
        }

        /// <summary>
        /// Deletes a given category according to an identifier.
        /// </summary>
        /// <param name="id">Category identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(KategoriResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Kategori, KategoriResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}