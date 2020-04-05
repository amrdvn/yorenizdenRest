using System.Collections.Generic;
using System.Threading.Tasks;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Models.Queries;

namespace Yorenizden.API.Domain.Repositories
{
    public interface I�r�nRepository
    {
        Task<QueryResult<�r�n>> ListAsync(�r�nlerQuery query);
        Task AddAsync(�r�n �r�n);
        Task<�r�n> FindByIdAsync(int id);
        void Update(�r�n �r�n);
        void Remove(�r�n �r�n);
    }
}