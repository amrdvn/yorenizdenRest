using System.Threading.Tasks;

namespace Yorenizden.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}