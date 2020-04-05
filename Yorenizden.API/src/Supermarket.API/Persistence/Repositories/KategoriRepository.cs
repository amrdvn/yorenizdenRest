using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Repositories;
using Yorenizden.API.Persistence.Contexts;

namespace Yorenizden.API.Persistence.Repositories
{
    public class KategoriRepository : BaseRepository, IKategoriRepository
    {
        public KategoriRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Kategori>> ListAsync()
        {
            return await _context.Kategoriler
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(Kategori kategori)
        {
            await _context.Kategoriler.AddAsync(kategori);
        }

        public async Task<Kategori> FindByIdAsync(int id)
        {
            return await _context.Kategoriler.FindAsync(id);
        }

        public void Update(Kategori kategori)
        {
            _context.Kategoriler.Update(kategori);
        }

        public void Remove(Kategori kategori)
        {
            _context.Kategoriler.Remove(kategori);
        }
    }
}