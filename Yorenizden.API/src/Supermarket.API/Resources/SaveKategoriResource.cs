using System.ComponentModel.DataAnnotations;

namespace Yorenizden.API.Resources
{
    public class SaveKategoriResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}