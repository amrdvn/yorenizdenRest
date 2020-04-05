using System.Threading.Tasks;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Models.Queries;
using Yorenizden.API.Domain.Services.Communication;

namespace Yorenizden.API.Domain.Services
{
    public interface I�r�nlerervice
    {
        Task<QueryResult<�r�n>> ListAsync(�r�nlerQuery query);
        Task<�r�nResponse> SaveAsync(�r�n �r�n);
        Task<�r�nResponse> UpdateAsync(int id, �r�n �r�n);
        Task<�r�nResponse> DeleteAsync(int id);
    }
}