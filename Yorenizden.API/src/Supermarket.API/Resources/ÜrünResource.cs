namespace Yorenizden.API.Resources
{
    public class ÜrünResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stok { get; set; }
        public string OlcuBirimi { get; set; }
        public KategoriResource Kategori {get;set;}
    }
}