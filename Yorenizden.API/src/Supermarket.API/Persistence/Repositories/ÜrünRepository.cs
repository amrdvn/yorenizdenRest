using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yorenizden.API.Domain.Models;
using Yorenizden.API.Domain.Models.Queries;
using Yorenizden.API.Domain.Repositories;
using Yorenizden.API.Persistence.Contexts;

namespace Yorenizden.API.Persistence.Repositories
{
	public class ÜrünRepository : BaseRepository, IÜrünRepository
	{
		public ÜrünRepository(AppDbContext context) : base(context) { }

		public async Task<QueryResult<Ürün>> ListAsync(ÜrünlerQuery query)
		{
			IQueryable<Ürün> queryable = _context.Ürünler
													.Include(p => p.Kategori)
													.AsNoTracking();

			// AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
			// tracking makes the code a little faster
			if (query.CategoryId.HasValue && query.CategoryId > 0)
			{
				queryable = queryable.Where(p => p.CategoryId == query.CategoryId);
			}

			// Here I count all items present in the database for the given query, to return as part of the pagination data.
			int totalItems = await queryable.CountAsync();

			// Here I apply a simple calculation to skip a given number of items, according to the current page and amount of items per page,
			// and them I return only the amount of desired items. The methods "Skip" and "Take" do the trick here.
			List<Ürün> Ürünler = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
													.Take(query.ItemsPerPage)
													.ToListAsync();

			// Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
			return new QueryResult<Ürün>
			{
				Items = Ürünler,
				TotalItems = totalItems,
			};
		}

		public async Task<Ürün> FindByIdAsync(int id)
		{
			return await _context.Ürünler
								 .Include(p => p.Kategori)
								 .FirstOrDefaultAsync(p => p.Id == id); // Since Include changes the method's return type, we can't use FindAsync
		}

		public async Task AddAsync(Ürün Ürün)
		{
			await _context.Ürünler.AddAsync(Ürün);
		}

		public void Update(Ürün Ürün)
		{
			_context.Ürünler.Update(Ürün);
		}

		public void Remove(Ürün Ürün)
		{
			_context.Ürünler.Remove(Ürün);
		}
	}
}