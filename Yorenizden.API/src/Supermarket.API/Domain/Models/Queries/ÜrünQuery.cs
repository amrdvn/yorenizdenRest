namespace Yorenizden.API.Domain.Models.Queries
{
    public class �r�nlerQuery : Query
    {
        public int? CategoryId { get; set; }

        public �r�nlerQuery(int? categoryId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            CategoryId = categoryId;
        }
    }
}