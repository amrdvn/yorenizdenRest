using System.Collections.Generic;
using System.Threading.Tasks;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Services.Communication;

namespace Yorenizden.API.Domain.Services
{
    public interface IKategoriService
    {
         Task<IEnumerable<Kategori>> ListAsync();
         Task<KategoriResponse> SaveAsync(Kategori kategori);
         Task<KategoriResponse> UpdateAsync(int id, Kategori kategori);
         Task<KategoriResponse> DeleteAsync(int id);
    }
}