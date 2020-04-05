using System.Collections.Generic;
using System.Threading.Tasks;
using Yorenizden.API.Domain.Models;

namespace Yorenizden.API.Domain.Repositories
{
    public interface IKategoriRepository
    {
        Task<IEnumerable<Kategori>> ListAsync();
        Task AddAsync(Kategori kategori);
        Task<Kategori> FindByIdAsync(int id);
        void Update(Kategori kategori);
        void Remove(Kategori kategori);
    }
}