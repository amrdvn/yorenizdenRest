namespace Yorenizden.API.Domain.Models
{
    public class Ürün
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Stok { get; set; }

        public double Ilk_Fiyat { get; set; }
        public double Guncel_Fiyat { get; set; }
        public double ÝndirimMiktari {get;set;}
        public string KisaAciklama { get; set; }
        public int IncelemeSayisi { get; set; }
        public int YildizSayisi { get; set; }
        public string UrunResmi { get; set; }
        public string Etiketler { get; set; }


        //  public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public OlcuBirimi Birim { get; set; }
        public int CategoryId { get; set; }
        public Kategori Kategori { get; set; }

    }
}