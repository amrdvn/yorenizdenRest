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
    public class �r�nlerervice : I�r�nlerervice
    {
        private readonly I�r�nRepository _�r�nRepository;
        private readonly IKategoriRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public �r�nlerervice(I�r�nRepository �r�nRepository, IKategoriRepository categoryRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _�r�nRepository = �r�nRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<QueryResult<�r�n>> ListAsync(�r�nlerQuery query)
        {
            // Here I list the query result from cache if they exist, but now the data can vary according to the category ID, page and amount of
            // items per page. I have to compose a cache to avoid returning wrong data.
            string cacheKey = GetCacheKeyFor�r�nlerQuery(query);
            
            var �r�nler = await _cache.GetOrCreateAsync(cacheKey, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _�r�nRepository.ListAsync(query);
            });

            return �r�nler;
        }

        public async Task<�r�nResponse> SaveAsync(�r�n �r�n)
        {
            try
            {
                /*
                 Notice here we have to check if the category ID is valid before adding the �r�n, to avoid errors.
                 You can create a method into the CategoryService class to return the category and inject the service here if you prefer, but 
                 it doesn't matter given the API scope.
                */
                var existingCategory = await _categoryRepository.FindByIdAsync(�r�n.CategoryId);
                if (existingCategory == null)
                    return new �r�nResponse("Invalid category.");

                await _�r�nRepository.AddAsync(�r�n);
                await _unitOfWork.CompleteAsync();

                return new �r�nResponse(�r�n);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new �r�nResponse($"An error occurred when saving the �r�n: {ex.Message}");
            }
        }

        public async Task<�r�nResponse> UpdateAsync(int id, �r�n �r�n)
        {
            var existing�r�n = await _�r�nRepository.FindByIdAsync(id);

            if (existing�r�n == null)
                return new �r�nResponse("�r�n not found.");

            var existingCategory = await _categoryRepository.FindByIdAsync(�r�n.CategoryId);
            if (existingCategory == null)
                return new �r�nResponse("Invalid category.");

            existing�r�n.Name = �r�n.Name;
            existing�r�n.Birim = �r�n.Birim;
            existing�r�n.Stok = �r�n.Stok;
            existing�r�n.CategoryId = �r�n.CategoryId;

            try
            {
                _�r�nRepository.Update(existing�r�n);
                await _unitOfWork.CompleteAsync();

                return new �r�nResponse(existing�r�n);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new �r�nResponse($"An error occurred when updating the �r�n: {ex.Message}");
            }
        }

        public async Task<�r�nResponse> DeleteAsync(int id)
        {
            var existing�r�n = await _�r�nRepository.FindByIdAsync(id);

            if (existing�r�n == null)
                return new �r�nResponse("�r�n not found.");

            try
            {
                _�r�nRepository.Remove(existing�r�n);
                await _unitOfWork.CompleteAsync();

                return new �r�nResponse(existing�r�n);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new �r�nResponse($"An error occurred when deleting the �r�n: {ex.Message}");
            }
        }

        private string GetCacheKeyFor�r�nlerQuery(�r�nlerQuery query)
        {
            string key = CacheKeys.�r�nListesi.ToString();
            
            if (query.CategoryId.HasValue && query.CategoryId > 0)
            {
                key = string.Concat(key, "_", query.CategoryId.Value);
            }

            key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
            return key;
        }
    }
}