using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Yorenizden.API.Domain.Models;

namespace Yorenizden.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Ürün> Ürünler { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Kategori>().ToTable("Kategoriler");
            builder.Entity<Kategori>().HasKey(p => p.Id);
            builder.Entity<Kategori>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Kategori>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Kategori>().HasMany(p => p.Ürünler).WithOne(p => p.Kategori).HasForeignKey(p => p.CategoryId);

            builder.Entity<Kategori>().HasData
            (
                new Kategori { Id = 100, Name = "Kahvaltýlýklar" }, 
                new Kategori { Id = 101, Name = "Hediyelik" },
                new Kategori { Id = 102, Name = "Gýda Ürünleri" },
                new Kategori { Id = 103, Name = "Sirkeler" },
                new Kategori { Id = 104, Name = "Þarküteri" },
                new Kategori { Id = 105, Name = "Süt Ürünleri" },
                new Kategori { Id = 106, Name = "Bakliyat" },
                new Kategori { Id = 107, Name = "Salça ve Sos" }
            );

            builder.Entity<Ürün>().ToTable("Ürünler");
            builder.Entity<Ürün>().HasKey(p => p.Id);
            builder.Entity<Ürün>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Ürün>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Ürün>().Property(p => p.Stok).IsRequired();
            builder.Entity<Ürün>().Property(p => p.Birim).IsRequired();

            builder.Entity<Ürün>().HasData
            (
                new Ürün
                {
                    Id = 100,
                    Name = "Cevizli Zile Pekmezi (250 Gram)",
                    Stok = 250,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat=18.50,
                    Guncel_Fiyat = 18.50,
                    KisaAciklama= "Adýný Tokat’ýn ilçesi olan Zile’den alan zile pekmezi; Zile’nin narinmi narin üzümlerinin yumurta akýyla karýþtýrýlarak yapýlýr. Beyaz renkte olan zile pekmezi ülkemizde çok sevilerek tüketilmektedir. Zile pekmezi besin deðeri olarak çok doludur. Cevizli Zile Pekmezi doðal haliyle sofralarýnýzý þenlendirmeye hazýr.",
                    YildizSayisi=0,
                    IncelemeSayisi=0,
                    Etiketler= "cevizli zile pekmezi, zile pekmezi",
                    UrunResmi= "https://yorenizden.com/wp-content/uploads/2019/09/zile-pekmezi-cevizli-min-600x600.jpg",
                    CategoryId = 100
                },
                new Ürün
                {
                    Id = 101,
                    Name = "Doðal Þekersiz Süzme Bal (850 Gram)",
                    Stok = 850,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 75.00,
                    Guncel_Fiyat = 65.00,
                    KisaAciklama = "Sivas/Zara’nýn engin daðlarýnýn zirvelerinden toplanan çiçeklerin özleriyle meydana gelen enfes Doðal Þekersiz Süzme Bal.Analiz Raporu Aþaðýdadýr..",
                    YildizSayisi = 5,
                    IncelemeSayisi = 7,
                    Etiketler = "þekersiz bal, þekersiz süzme bal, süzme bal satýn al",
                    UrunResmi= "https://yorenizden.com/wp-content/uploads/2019/02/sekersiz-bal-yorenizden-600x450.jpg"+ "https://yorenizden.com/wp-content/uploads/2019/02/bal-600x600.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 102,
                    Name = "Ev Yapýmý Ayva Reçeli (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 22.50,
                    KisaAciklama = "Tamamen doðal ev yapýmý Ayva Reçeli. Hiçbir katký maddesi yoktur. Glikoz þurubu içermez. Enfes tadýyla sabah kahvaltýlarýnýza lezzet katacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 3,
                    Etiketler = "ayva reçeli, ev yapýmý ayva reçeli",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/ayva-receli-yorenizden.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 103,
                    Name = "Ev Yapýmý Çalma Pekmez (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 45.00,
                    Guncel_Fiyat = 37.50,
                    KisaAciklama = "Yapýmý oldukça emek isteyen ve uzun süren Çalma Pekmez, her insanýn kahvaltý sofrasýnda görmek isteyeceði enfes tat.% 100 doðal içeriðiyle ev yapýmýdýr.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "çalma pekmez, çalma pekmez satýn al, zile çalma pekmez",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/calma-pekmez-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 104,
                    Name = "Ev Yapýmý Çilek Reçeli (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 23.00,
                    KisaAciklama = "En leziz çileklerin mevsiminde toplanmasý ile elde edilen Ev Yapýmý Çilek Reçeli. Sabah kahvaltýlarýnýzýn tatlý ve saðlýklý ortaðý çilek reçeli, tamamen doðaldýr ve katký maddesi içermez.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "çilek reçeli, ev yapýmý çilek reçeli",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/cilek-receli-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 105,
                    Name = "Ev Yapýmý Kayýsý Reçeli (800 Gram)",
                    Stok = 2,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 28.50,
                    Guncel_Fiyat = 22.50,
                    KisaAciklama = "Kendi bahçelerimizde yetiþen taze ve doðal kayýsýlarýmýzý kullanarak tamamen geleneksel usullerle hazýrladýðýmýz katkýsýz, doðal ev yapýmý kayýsý reçelimizi mutlaka denemelisiniz.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "Doðal kayýsý reçeli, ev yapýmý kayýsý reçeli, Kayýsý Reçeli, Kayýsý reçeli satýn al",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/ayva-receli-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 106,
                    Name = "Ev Yapýmý Keçi Boynuzu Pekmezi (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Faydalarý saymakla bitmeyen, zengin vitamin içerikli Keçi Boyunuzu Pekmezi sofralarýnýza lezzet katacak. Tamamen organik ve katkýsýzdýr. Doðal yöntemlerle üretilmiþtir.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "doðal keçi boynuzu pekmezi, ev yapýmý keçi boynuzu pekmezi, keçi boynuzu pekmezi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/keci-boynuzu-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 107,
                    Name = "Ev Yapýmý Kuþburnu Marmelatý (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 35.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Ev Yapýmý Kuþburnu Marmelatý. Tamamen doðal yöntemlerle üretilmiþtir. Hiçbir katký maddesi bulunmamaktadýr. Glikoz içermez.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "ev yapýmý kuþburnu marmelatý, kuþburnu marmelatý",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/kusburnu-marmelati-yorenizden-1-600x450.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 108,
                    Name = "Ev Yapýmý Üzüm Pekmezi (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 35.00,
                    Guncel_Fiyat = 27.00,
                    KisaAciklama = "Ev yapýmý tamamen organik, doðal, Üzüm Pekmezi. Hiçbir katký maddesi kullanýlmamýþtýr.Tokatýn meþhur baðlarýnýn üzümleri kullanýlmýþtýr.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 4,
                    Etiketler = "ev yapýmý üzüm pekmezi, üzüm pekmezi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/uzum-pekmezi-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 109,
                    Name = "Ev Yapýmý Viþne Reçeli (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 28.50,
                    Guncel_Fiyat = 22.50,
                    KisaAciklama = "Tamamen doðal viþnelerden üretilen, katkýsýz Organik Viþne Reçeli. Sabah kahvaltýlarýnýzýn vazgeçilmezi olacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 3,
                    Etiketler = "viþne reçeli, viþne reçeli organik",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/visne-receli-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 110,
                    Name = "Köy Tereyaðý 1 Kg",
                    Stok = 1,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 65.00,
                    Guncel_Fiyat = 55.00,
                    KisaAciklama = "Sabah kahvaltý sofralarýnýza renk katacak, yemeklerinizin lezzetini katlayacak köy tereyaðý.(Tuzsuzdur)(Kýþ aylarýnda tereyað rengi beyazdýr.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "ev tereyaðý, köy terayaðý, terayaðý",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/01/koy-tereyagi-600x447.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 111,
                    Name = "Sade Zile Pekmezi (300 Gram)",
                    Stok = 300,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 17.50,
                    Guncel_Fiyat = 17.50,
                    KisaAciklama = "Adýný Tokat’ýn ilçesi olan Zile’den alan zile pekmezi; Zile’nin narinmi narin üzümlerinin yumurta akýyla karýþtýrýlarak yapýlmasýndan oluþur. Beyaz renkte olan zile pekmezi ülkemizde çok sevilerek tüketilmektedir. Zile pekmezi besin deðeri olarak çok doludur. Sade Zile Pekmezi doðal haliyle sofralarýnýzý þenlendirmeye hazýr.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "Sade Zile Pekmezi, zile pekmezi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/12/zile-pekmezi-sade-600x600.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 112,
                    Name = "Taze Çökelek (1 KG)",
                    Stok = 1,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat=20.00,
                    Guncel_Fiyat=20.00,
                    KisaAciklama = "Kahvaltý sofralarýnýn vazgeçilmezi, inek sütünden yapýlma, tamamen doðal taze çökelek.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "çökelek, çökelek satýn al, taze çökelek",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/taze-cokelek-yorenizden.jpg",
                    CategoryId = 100,
                },
                new Ürün
                {
                    Id = 113,
                    Name = "Renkli Tokat Sofra Bezi",
                    Stok = 100,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat =20.00,
                    Guncel_Fiyat =20.00,
                    KisaAciklama = "Ýster yer sofralarýnýzda, ister piknik masalarýnýzda kullanabileceðiniz, isterseniz de annenize, eþinize, dostunuza hediye edebileceðiniz Tokat Sofra Bezleri…Ürünü alýrken not olarak istediðiniz rengi belirtmeyi unutmayýn.Tokat Sofra Bezi kaliteli kumaþlardan yapýlmýþtýr.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "sofra bezi, sofra bezi satýn al, tokat sofra bezleri",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/sbezisar%C4%B1siteyey%C3%BCklenecek-600x600.jpg"+
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezibeyazsimlip%C3%BCsk%C3%BCls%C3%BCz-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezikahvesiteye-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezimavisiteye-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezisar%C4%B1siteyey%C3%BCklenecek-1-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezishardalsiteyey%C3%BCklenecek-600x600.jpg",
                    CategoryId = 101,
                },
                new Ürün
                {
                    Id = 114,
                    Name = "Tokat Yazmasý",
                    Stok = 100,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat =10.00,
                    Guncel_Fiyat =8.75,
                    KisaAciklama = "Tokat’ýn kültürel özelliklerini simgeleyen ve ülkede önemli yer edinen dikiþli, poliser Nisa Ýpek Tokat YazmasýÜrünü alýrken not olarak kaçýncý yazmayý istediðinizi belirtmeyi unutmayýnýz.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "tokat yazmasý, tokat yazmasý satýn al, yazma satýn al",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/yazma10siteyey%C3%BCk-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/yazma1siteyey%C3%BCk-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/yazma2siteyey%C3%BCk-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/yazma3siteyey%C3%BCk-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/yazma4siteyey%C3%BCk-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/yazma5siteyey%C3%BCk-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/yazma6siteyey%C3%BCk-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/yazma7siteyey%C3%BCk-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/yazma8sitey%C3%BCk-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/yazma9siteyey%C3%BCk-600x600.jpg",
                    CategoryId = 101,
                },
                new Ürün
                {
                    Id = 115,
                    Name = "Zile Kömesi (500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat =19.50,
                    Guncel_Fiyat =19.50 ,
                    KisaAciklama = "Meþhur Zile baðlarýndan toplanan cevizlerin ve üzüm þýrasýnýn karýþtýrýlýp kurutulmasý ve niþasta ile birleþimiyle hazýrlanan eþsiz cevizli sucuk. Doðal bir üründür. Katkýsýzdýr.Bol cevizli muhteþem tadý damaðýnýzda lezzet þöleni yaratacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "cevizli sucuk, zile kömesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/zile-komesi-yorenizden-600x450.jpg",
                    CategoryId = 101,
                },
                new Ürün
                {
                    Id = 116,
                    Name = "Doðal Þekersiz Süzme Bal (850 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 75.00,
                    Guncel_Fiyat = 65.00,
                    KisaAciklama = "Sivas/Zara’nýn engin daðlarýnýn zirvelerinden toplanan çiçeklerin özleriyle meydana gelen enfes Doðal Þekersiz Süzme Bal.Analiz Raporu Aþaðýdadýr.",
                    YildizSayisi =5,
                    IncelemeSayisi = 7,
                    Etiketler = "þekersiz bal, þekersiz süzme bal, süzme bal satýn al",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/sekersiz-bal-yorenizden-600x450.jpg"+
                    "https://yorenizden.com/wp-content/uploads/2019/02/bal-600x600.jpg",
                    CategoryId = 102,
                },
                new Ürün
                {
                    Id = 117,
                    Name = "Tokat Çemeni (300 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 7.50,
                    Guncel_Fiyat = 6.50,
                    KisaAciklama = "Hakiki Meþhur Tokat Çemeni. En doðal haliyle sofralarýnýza konuk oluyor. Katkýsýz, koruyucusuz, geleneksel yöntemlerle üretilmiþtir.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 4,
                    Etiketler = "çemen, tokat çemeni",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/tokat-cemeni-yorenizden-1-600x450.jpg",
                    CategoryId = 102,
                },
                new Ürün
                {
                    Id = 118,
                    Name = "Tokat Ev Ekmeði",
                    Stok = 500,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat = 11.00,
                    Guncel_Fiyat = 9.00,
                    KisaAciklama = "Doðal olarak maya ile yoðurulan hamur kabarmak üzere belirli bir süre bekletilir ve yeterince mayalanmasý saðlandýðýnda ekmek boyutlarýnda hamurlar, odun ateþinde ýsýnmýþ taþ fýrýnlarda tamamen geleneksel yöntemlerle piþirilir.Her gün taptaze bir þekilde üretilen ekmekler sizlere mümkün olduðunca taze bir þekilde ulaþtýrýlýr.Bu lezzet her öðün yemeklerinizde tüketebileceðiniz hatta bazen canýnýzýn sadece Tokat Ev Ekmeði çekeceði bir lezzettir.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 3,
                    Etiketler = "ev ekmeði, mayalý ev ekmeði, tokat ev ekmeði",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/ev-ekmegi-2-yorenizden-600x450.jpg"+
                    "https://yorenizden.com/wp-content/uploads/2019/02/ev-ekmegi-yorenizden-600x450.jpg",
                    CategoryId = 102,
                },
                new Ürün
                {
                    Id = 119,
                    Name = "Tokat Yapraðý (1,5 KG)",
                    Stok = 0,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 0,
                    KisaAciklama = "Tokat bölgesinde yetiþmiþ, doðal üzüm baðlarýndan toplanmýþ, tamamen doðal, tadýna doyamayacaðýnýz, Tokat’ýn meþhur yaprak sarmasýna lezzet katacak Tokat Yapraðý.Tokat Asma Yapraðý Paket Ýçeriði : Süzme 700 Gr Özel Bidonda",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "tokat erbaa yapraðý, tokat salamura yaprak, tokat yapraðý",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1--600x450.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1.jpg",
                    CategoryId = 102,
                },
                new Ürün
                {
                    Id = 120,
                    Name = "Tokat Yapraðý (3 KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 65.00,
                    Guncel_Fiyat = 55.00,
                    KisaAciklama = "Tokat bölgesinde yetiþmiþ, doðal üzüm baðlarýndan toplanmýþ, tamamen doðal, tadýna doyamayacaðýnýz, Tokat’ýn meþhur yaprak sarmasýna lezzet katacak Tokat Yapraðý. Yeni Sezon ÜrünüdürTokat Asma Yapraðý Paket Ýçeriði : Süzme 2000 Gr Özel Bidonda",
                    YildizSayisi = 5,
                    IncelemeSayisi = 8,
                    Etiketler = "tokat erbaa yapraðý, tokat salamura yaprak, tokat yapraðý",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1--600x450.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1.jpg",
                    CategoryId = 102,
                },
                new Ürün
                {
                    Id = 121,
                    Name = "Tokat Yapraðý (5 KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 75.00,
                    Guncel_Fiyat = 65.00,
                    KisaAciklama = "Tokat bað yapraðý, anayurdu Tokat olan ince ve damarsýz yapýsý ile sofralarýnýza lezzet katacaktýr. Tamamen doðal ortamda özel olarak yetiþtirilmiþ ve titizlikle hazýrlanmýþtýr. Tokat’ýn meþhur bað yapraðý ile þýk sofralarýn vazgeçilmez lezzeti olan yaprak sarmasý sunumlarýnýz sofranýza lezzet katacak olup, misafirleriniz de tadýna doyamayacaktýr. 5 kilogram seçeneði ile kalabalýk ailelerin tercihi olan Tokat bað yapraðýný siz de denemelisiniz. Yeni Sezon ÜrünüdürTokat Asma Yapraðý Paket Ýçeriði : Süzme 3000 Gr Özel Bidonda",
                    YildizSayisi = 5,
                    IncelemeSayisi = 1,
                    Etiketler = "tokat erbaa yapraðý, tokat salamura yaprak, tokat yapraðý",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1--600x450.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1.jpg",
                    CategoryId = 102,
                },
                new Ürün
                {
                    Id = 122,
                    Name = "Tokat Yapraðý (5 KG) 2’Li Paket",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 130.00,
                    Guncel_Fiyat = 120.00,
                    KisaAciklama = "Tokat bölgesinde yetiþmiþ, doðal üzüm baðlarýndan toplanmýþ, tamamen doðal, tadýna doyamayacaðýnýz, Tokat’ýn meþhur yaprak sarmasýna lezzet katacak Tokat Yapraðý 5 KG’luk bidonda 2’li paket. Yeni Sezon ÜrünüdürTokat Asma Yapraðý Paket Ýçeriði :  Süzme 3000 Gr Özel Bidonda",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "tokat erbaa yapraðý, tokat salamura yaprak, tokat yapraðý",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1--600x450.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1.jpg",
                    CategoryId = 102,
                },
                new Ürün
                {
                    Id = 123,
                    Name = "Zile Kömesi(500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 19.50,
                    Guncel_Fiyat = 19.50,
                    KisaAciklama = "Meþhur Zile baðlarýndan toplanan cevizlerin ve üzüm þýrasýnýn karýþtýrýlýp kurutulmasý ve niþasta ile birleþimiyle hazýrlanan eþsiz cevizli sucuk. Doðal bir üründür. Katkýsýzdýr.Bol cevizli muhteþem tadý damaðýnýzda lezzet þöleni yaratacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "cevizli sucuk, zile kömesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/zile-komesi-yorenizden-600x450.jpg",
                    CategoryId = 102,
                },
                new Ürün
                {
                    Id = 124,
                    Name = "Ceviz Sirkesi 500 ml Doðal Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Ceviz sirkesi, doðal olarak ilaçsýz ve hormonsuz þekilde yetiþen yerli cevizlerimizin sirke haline getirilmesi ile elde edilen tamamen doðal bir üründür.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "ceviz sirkesi, doðal ceviz sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/cevizsirkesi-600x869.jpg",
                    CategoryId = 103,
                },
                new Ürün
                {
                    Id = 125,
                    Name = "Elma Sirkesi 500 ml Doðal Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Elma Sirkesi, elmalarýn doðal ve ilaçsýz olanlarý kullanýlarak doðal yöntemler ile  hazýrlandý. Saðlýk açýsýndan cam þiþede!Ýsterseniz suya karýþtýrarak içebilirsiniz ortalama bir bardak suya iki yemek kaþýðý elma sirkesi koyarak,içimi çok rahattýr.Yada salata ve soslarýnýza ekliyerek lezzet katabilirsiniz.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 1,
                    Etiketler = "doðal elma sirkesi, elma sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/elmasirkesi-600x869.jpg",
                    CategoryId = 103,
                },
                new Ürün
                {
                    Id = 126,
                    Name = "Enginar Sirkesi 500 ml Doðal Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Enginar Sirkesi, doðal ve ilaçsýz olanlarýný kullanarak doðal yöntemler ile Enginar sirkesi hazýrladý.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "doðal enginar sirkesi, enginar sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/enginarsirkesi-600x936.jpg",
                    CategoryId = 103,
                },
                new Ürün
                {
                    Id = 127,
                    Name = "Kayýsý Sirkesi 500 ml Doðal Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Kayýsý Sirkesi, çok fazla bulunamayan ender sirke çeþitlerinden biridir. Diðer sirkelere nazaran daha az keskin, yumuþak içimli bir sirkedir.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "doðal kayýsý sirkesi, kayýsý sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/kay%C4%B1s%C4%B1sirkesi-600x869.jpg",
                    CategoryId = 103,
                },
                new Ürün
                {
                    Id = 128,
                    Name = "Nar Sirkesi 500 ml Doðal Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Nar Sirkesi,narlarýn doðal ve ilaçsýz olanlarýný kullanarak doðal yöntemler ile sizler için nar sirkesi hazýrlandý.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "doðal nar sirkesi, nar sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/narsirkesi-600x869.jpg",
                    CategoryId = 103,
                },
                new Ürün
                {
                    Id = 129,
                    Name = "Dana Kuþbaþý (500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 27.50,
                    Guncel_Fiyat = 27.50,
                    KisaAciklama = "%100 Tosun etinden yapýlan dana kuþbaþý, ”Lop Et” güvencesiyle kapýnýza kadar getiriyoruz.(Sadece Tokat / Merkez içi elden teslimatlarda geçerlidir.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/03/bebeklere-ozel-kusbasi-600x400.jpg",
                    CategoryId = 104,
                },
                new Ürün
                {
                    Id = 130,
                    Name = "Dana Orta Yaðlý Kýyma (500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat =25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "%100 Tosun etinden yapýlan dana kuþbaþý, ”Lop Et” güvencesiyle kapýnýza kadar getiriyoruz.(Sadece Tokat / Merkez içi elden teslimatlarda geçerlidir.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "dana, dana kýyma, tosun, tosun eti",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/03/s1200-600x400.jpg",
                    CategoryId = 104,
                },
                new Ürün
                {
                    Id = 131,
                    Name = "Dana Sýfýr Yaðlý Kýyma (500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 30.00,
                    KisaAciklama = "%100 Tosun etinden yapýlan dana kuþbaþý, ”Lop Et” güvencesiyle kapýnýza kadar getiriyoruz.(Sadece Tokat / Merkez içi elden teslimatlarda geçerlidir.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/03/s1200-600x400.jpg",
                    CategoryId = 104,
                },
                new Ürün
                {
                    Id = 132,
                    Name = "Doðal Köy Tavuðu 1 Adet",
                    Stok = 500,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 30.00,
                    KisaAciklama = "Tahtoba köyünde yayýlan köy tavuklarý doðal yöntemlerle beslenip 1 sene sonunda kesiliyor.1 Adet Ortalama 1.200 - 1.400 gram arasý deðiþmektedir.(Sadece Tokat / Merkez içi elden teslimatlarda geçerlidir.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/03/37a08ab8b58291604dfff2594a5ba106-600x598.jpg",
                    CategoryId = 104,
                },
                new Ürün
                {
                    Id = 133,
                    Name = "Tokat Bez Sucuk (1KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 90.00,
                    Guncel_Fiyat = 80.00,
                    KisaAciklama = "%100 yerli kesim tosun etlerinden, tamamen katkýsýz, koruyucusuz meþhur geleneksel Tokat Bez Sucuðu. Sabah kahvaltýlarýnýza, mangallarýnýza ve sofranýza lezzet katacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 12,
                    Etiketler = "bez sucuk, bez sucuk satýn al, sucuk satýn al, tokat bez sucuk, Tokat Sucuðu",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/03/bez-sucuk-yorenizden.jpg",
                    CategoryId = 104,
                },
                new Ürün
                {
                    Id = 134,
                    Name = "Tokat Bez Sucuk (300-330 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 29.00,
                    Guncel_Fiyat = 29.00,
                    KisaAciklama = "Tamamen katkýsýz, koruyucusuz meþhur geleneksel Tokat Bez Sucuðu. Sabah kahvaltýlarýnýza, mangallarýnýza ve sofralarýnýza lezzet katacak.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "bez sucuk, tokat bez sucuk",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/03/bez-sucuk-yorenizden.jpg",
                    CategoryId = 104,
                },
                new Ürün
                {
                    Id = 135,
                    Name = "Köy Tereyaðý 1 Kg",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 65.00,
                    Guncel_Fiyat = 55.00,
                    KisaAciklama = "Sabah kahvaltý sofralarýnýza renk katacak, yemeklerinizin lezzetini katlayacak köy tereyaðý.(Tuzsuzdur)(Kýþ aylarýnda tereyað rengi beyazdýr.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "ev tereyaðý, köy terayaðý, terayaðý",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/01/koy-tereyagi-600x447.jpg",
                    CategoryId = 105,
                },
                new Ürün
                {
                    Id = 136,
                    Name = "Taze Çökelek (1 KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 20.00,
                    Guncel_Fiyat = 20.00,
                    KisaAciklama = "Kahvaltý sofralarýnýn vazgeçilmezi, inek sütünden yapýlma, tamamen doðal taze çökelek.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "Kahvaltý sofralarýnýn vazgeçilmezi, inek sütünden yapýlma, tamamen doðal taze çökelek.",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/taze-cokelek-yorenizden-600x450.jpg",
                    CategoryId = 105,
                },
                new Ürün
                {
                    Id = 137,
                    Name = "Ev Yapýmý Eriþte (1 KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 22.50,
                    Guncel_Fiyat = 22.50,
                    KisaAciklama = "Tamamen el yapýmý, köy yumurtalý eriþtemiz. Doðal yollarla kurutulmuþtur.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "El yapýmý eriþte, Ev yapýmý eriþte",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/09/eri%C5%9Fte.jpg",
                    CategoryId = 106,
                },
                new Ürün
                {
                    Id = 138,
                    Name = "Tokat Yoðurtmaç",
                    Stok = 500,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat = 9.00,
                    Guncel_Fiyat = 9.00,
                    KisaAciklama = "Ýlk olarak Tokat’ýn ilçelerinden biri olan Turhal ilçesinde yapýlan Tokat Yoðurtmaçý diðer adýyla Turhal Yoðurtmaçý Türkiye’nin bir çok yerinde meþhurdur.Yapýlýþý emek isteyen eþsiz lezzet.Yoðurtmaç Çeþitleri;Cevizli Yoðurtmaç, Haþhaþlý Yoðurtmaç, Sade Yoðurtmaç lütfen sipariþinizde belirtmeyi unutmayýn.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 1,
                    Etiketler = "Tokat Yoðurtmacý, Yoðurtmaç",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/11/yo%C4%9Furtma%C3%A7-600x415.png",
                    CategoryId = 106,
                },
                new Ürün
                {
                    Id = 139,
                    Name = "Ev Yapýmý Domates Salçasý (5300 Gram)",
                    Stok = 0,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 85.00,
                    Guncel_Fiyat = 70.00,
                    KisaAciklama = "Domatesin baþkenti Tokat’ýn eþsiz Kazova domateslerinden yapýlan tamamen ev yapýmý domates salçasý. Muhteþem tadý ve kokusuyla tadýna doyamayacaðýnýz katkýsýz ve koruyucusuz ev yapýmý domates salçasý.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "doðal domates salçasý, domates salçasý, ev yapýmý domates salçasý",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/domates-salcasi-min.jpg",
                    CategoryId = 107,
                }
                /*
                 new Ürün
                {
                    Id = 115,
                    Name = "",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = ,
                    Guncel_Fiyat = ,
                    KisaAciklama = "",
                    YildizSayisi =0,
                    IncelemeSayisi = 0,
                    Etiketler = "",
                    UrunResmi = "",
                    CategoryId = 102,
                },
                 */
            ) ; 
        }
    }
}