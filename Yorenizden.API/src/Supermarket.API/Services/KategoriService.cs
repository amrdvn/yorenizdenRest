using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Repositories;
using Yorenizden.API.Domain.Services;
using Yorenizden.API.Domain.Services.Communication;
using Yorenizden.API.Infrastructure;

namespace Yorenizden.API.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly IKategoriRepository _kategoriRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public KategoriService(IKategoriRepository kategoriRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _kategoriRepository = kategoriRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<Kategori>> ListAsync()
        {
            // Here I try to get the Kategoriler list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the Kategoriler from the repository.
            var kategoriler = await _cache.GetOrCreateAsync(CacheKeys.KategoriListesi, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _kategoriRepository.ListAsync();
            });
            
            return kategoriler;
        }

        public async Task<KategoriResponse> SaveAsync(Kategori kategori)
        {
            try
            {
                await _kategoriRepository.AddAsync(kategori);
                await _unitOfWork.CompleteAsync();

                return new KategoriResponse(kategori);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new KategoriResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<KategoriResponse> UpdateAsync(int id, Kategori kategori)
        {
            var existingCategory = await _kategoriRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new KategoriResponse("Kategori Bulunamadý.");

            existingCategory.Name = kategori.Name;

            try
            {
                _kategoriRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new KategoriResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new KategoriResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<KategoriResponse> DeleteAsync(int id)
        {
            var existingCategory = await _kategoriRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new KategoriResponse("Kategori Bulunamadý.");

            try
            {
                _kategoriRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new KategoriResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new KategoriResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }

        
    }
}