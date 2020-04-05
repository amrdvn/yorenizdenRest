using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Models.Queries;
using Yorenizden.API.Domain.Repositories;
using Yorenizden.API.Domain.Services;
using Yorenizden.API.Domain.Services.Communication;
using Yorenizden.API.Infrastructure;

namespace Yorenizden.API.Services
{
    public class Ürünlerervice : IÜrünlerervice
    {
        private readonly IÜrünRepository _ÜrünRepository;
        private readonly IKategoriRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public Ürünlerervice(IÜrünRepository ÜrünRepository, IKategoriRepository categoryRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _ÜrünRepository = ÜrünRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<QueryResult<Ürün>> ListAsync(ÜrünlerQuery query)
        {
            // Here I list the query result from cache if they exist, but now the data can vary according to the category ID, page and amount of
            // items per page. I have to compose a cache to avoid returning wrong data.
            string cacheKey = GetCacheKeyForÜrünlerQuery(query);
            
            var Ürünler = await _cache.GetOrCreateAsync(cacheKey, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _ÜrünRepository.ListAsync(query);
            });

            return Ürünler;
        }

        public async Task<ÜrünResponse> SaveAsync(Ürün Ürün)
        {
            try
            {
                /*
                 Notice here we have to check if the category ID is valid before adding the Ürün, to avoid errors.
                 You can create a method into the CategoryService class to return the category and inject the service here if you prefer, but 
                 it doesn't matter given the API scope.
                */
                var existingCategory = await _categoryRepository.FindByIdAsync(Ürün.CategoryId);
                if (existingCategory == null)
                    return new ÜrünResponse("Invalid category.");

                await _ÜrünRepository.AddAsync(Ürün);
                await _unitOfWork.CompleteAsync();

                return new ÜrünResponse(Ürün);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ÜrünResponse($"An error occurred when saving the Ürün: {ex.Message}");
            }
        }

        public async Task<ÜrünResponse> UpdateAsync(int id, Ürün Ürün)
        {
            var existingÜrün = await _ÜrünRepository.FindByIdAsync(id);

            if (existingÜrün == null)
                return new ÜrünResponse("Ürün not found.");

            var existingCategory = await _categoryRepository.FindByIdAsync(Ürün.CategoryId);
            if (existingCategory == null)
                return new ÜrünResponse("Invalid category.");

            existingÜrün.Name = Ürün.Name;
            existingÜrün.Birim = Ürün.Birim;
            existingÜrün.Stok = Ürün.Stok;
            existingÜrün.CategoryId = Ürün.CategoryId;

            try
            {
                _ÜrünRepository.Update(existingÜrün);
                await _unitOfWork.CompleteAsync();

                return new ÜrünResponse(existingÜrün);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ÜrünResponse($"An error occurred when updating the Ürün: {ex.Message}");
            }
        }

        public async Task<ÜrünResponse> DeleteAsync(int id)
        {
            var existingÜrün = await _ÜrünRepository.FindByIdAsync(id);

            if (existingÜrün == null)
                return new ÜrünResponse("Ürün not found.");

            try
            {
                _ÜrünRepository.Remove(existingÜrün);
                await _unitOfWork.CompleteAsync();

                return new ÜrünResponse(existingÜrün);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ÜrünResponse($"An error occurred when deleting the Ürün: {ex.Message}");
            }
        }

        private string GetCacheKeyForÜrünlerQuery(ÜrünlerQuery query)
        {
            string key = CacheKeys.ÜrünListesi.ToString();
            
            if (query.CategoryId.HasValue && query.CategoryId > 0)
            {
                key = string.Concat(key, "_", query.CategoryId.Value);
            }

            key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
            return key;
        }
    }
}