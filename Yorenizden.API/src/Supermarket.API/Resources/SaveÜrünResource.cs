using System.ComponentModel.DataAnnotations;

namespace Yorenizden.API.Resources
{
    public class Save�r�nResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public short Stok { get; set; }

        [Required]
        [Range(1, 5)]
        public int OlcuBirimi { get; set; } // AutoMapper is going to cast it to the respective enum value
        
        [Required]
        public int CategoryId { get; set; }
    }
}