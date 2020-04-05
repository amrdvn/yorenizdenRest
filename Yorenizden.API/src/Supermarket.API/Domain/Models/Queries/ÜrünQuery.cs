namespace Yorenizden.API.Domain.Models.Queries
{
    public class ÜrünlerQuery : Query
    {
        public int? CategoryId { get; set; }

        public ÜrünlerQuery(int? categoryId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            CategoryId = categoryId;
        }
    }
}