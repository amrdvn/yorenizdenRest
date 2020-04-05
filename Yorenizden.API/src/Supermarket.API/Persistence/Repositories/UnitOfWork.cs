using System.Threading.Tasks;
using Yorenizden.API.Domain.Repositories;
using Yorenizden.API.Persistence.Contexts;

namespace Yorenizden.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}