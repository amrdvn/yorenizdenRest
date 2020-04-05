using System.Collections.Generic;

namespace Yorenizden.API.Domain.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<�r�n> �r�nler { get; set; } = new List<�r�n>();
    }
}