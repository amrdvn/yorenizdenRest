using System.Collections.Generic;

namespace Yorenizden.API.Domain.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Ürün> Ürünler { get; set; } = new List<Ürün>();
    }
}