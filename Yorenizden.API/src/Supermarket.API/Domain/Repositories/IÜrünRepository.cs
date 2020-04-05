using System.Collections.Generic;
using System.Threading.Tasks;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Models.Queries;

namespace Yorenizden.API.Domain.Repositories
{
    public interface IÜrünRepository
    {
        Task<QueryResult<Ürün>> ListAsync(ÜrünlerQuery query);
        Task AddAsync(Ürün ürün);
        Task<Ürün> FindByIdAsync(int id);
        void Update(Ürün ürün);
        void Remove(Ürün ürün);
    }
}