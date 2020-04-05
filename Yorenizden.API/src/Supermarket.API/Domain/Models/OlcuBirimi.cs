using System.ComponentModel;

namespace Yorenizden.API.Domain.Models
{
    public enum OlcuBirimi : byte
    {
        [Description("Adet")]
        Adet = 1,

        [Description("MG")]
        Milligram = 2,

        [Description("Gr")]
        Gram = 3,

        [Description("KG")]
        Kilogram = 4,

        [Description("L")]
        Litre = 5
    }
}