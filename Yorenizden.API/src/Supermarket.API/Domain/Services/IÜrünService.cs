using System.Threading.Tasks;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Models.Queries;
using Yorenizden.API.Domain.Services.Communication;

namespace Yorenizden.API.Domain.Services
{
    public interface IÜrünlerervice
    {
        Task<QueryResult<Ürün>> ListAsync(ÜrünlerQuery query);
        Task<ÜrünResponse> SaveAsync(Ürün ürün);
        Task<ÜrünResponse> UpdateAsync(int id, Ürün Ürün);
        Task<ÜrünResponse> DeleteAsync(int id);
    }
}