using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Yorenizden.API.Domain.Models;

namespace Yorenizden.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<�r�n> �r�nler { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Kategori>().ToTable("Kategoriler");
            builder.Entity<Kategori>().HasKey(p => p.Id);
            builder.Entity<Kategori>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Kategori>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Kategori>().HasMany(p => p.�r�nler).WithOne(p => p.Kategori).HasForeignKey(p => p.CategoryId);

            builder.Entity<Kategori>().HasData
            (
                new Kategori { Id = 100, Name = "Kahvalt�l�klar" }, 
                new Kategori { Id = 101, Name = "Hediyelik" },
                new Kategori { Id = 102, Name = "G�da �r�nleri" },
                new Kategori { Id = 103, Name = "Sirkeler" },
                new Kategori { Id = 104, Name = "�ark�teri" },
                new Kategori { Id = 105, Name = "S�t �r�nleri" },
                new Kategori { Id = 106, Name = "Bakliyat" },
                new Kategori { Id = 107, Name = "Sal�a ve Sos" }
            );

            builder.Entity<�r�n>().ToTable("�r�nler");
            builder.Entity<�r�n>().HasKey(p => p.Id);
            builder.Entity<�r�n>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<�r�n>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<�r�n>().Property(p => p.Stok).IsRequired();
            builder.Entity<�r�n>().Property(p => p.Birim).IsRequired();

            builder.Entity<�r�n>().HasData
            (
                new �r�n
                {
                    Id = 100,
                    Name = "Cevizli Zile Pekmezi (250 Gram)",
                    Stok = 250,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat=18.50,
                    Guncel_Fiyat = 18.50,
                    KisaAciklama= "Ad�n� Tokat��n il�esi olan Zile�den alan zile pekmezi; Zile�nin narinmi narin �z�mlerinin yumurta ak�yla kar��t�r�larak yap�l�r. Beyaz renkte olan zile pekmezi �lkemizde �ok sevilerek t�ketilmektedir. Zile pekmezi besin de�eri olarak �ok doludur. Cevizli Zile Pekmezi do�al haliyle sofralar�n�z� �enlendirmeye haz�r.",
                    YildizSayisi=0,
                    IncelemeSayisi=0,
                    Etiketler= "cevizli zile pekmezi, zile pekmezi",
                    UrunResmi= "https://yorenizden.com/wp-content/uploads/2019/09/zile-pekmezi-cevizli-min-600x600.jpg",
                    CategoryId = 100
                },
                new �r�n
                {
                    Id = 101,
                    Name = "Do�al �ekersiz S�zme Bal (850 Gram)",
                    Stok = 850,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 75.00,
                    Guncel_Fiyat = 65.00,
                    KisaAciklama = "Sivas/Zara�n�n engin da�lar�n�n zirvelerinden toplanan �i�eklerin �zleriyle meydana gelen enfes Do�al �ekersiz S�zme Bal.Analiz Raporu A�a��dad�r..",
                    YildizSayisi = 5,
                    IncelemeSayisi = 7,
                    Etiketler = "�ekersiz bal, �ekersiz s�zme bal, s�zme bal sat�n al",
                    UrunResmi= "https://yorenizden.com/wp-content/uploads/2019/02/sekersiz-bal-yorenizden-600x450.jpg"+ "https://yorenizden.com/wp-content/uploads/2019/02/bal-600x600.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 102,
                    Name = "Ev Yap�m� Ayva Re�eli (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 22.50,
                    KisaAciklama = "Tamamen do�al ev yap�m� Ayva Re�eli. Hi�bir katk� maddesi yoktur. Glikoz �urubu i�ermez. Enfes tad�yla sabah kahvalt�lar�n�za lezzet katacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 3,
                    Etiketler = "ayva re�eli, ev yap�m� ayva re�eli",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/ayva-receli-yorenizden.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 103,
                    Name = "Ev Yap�m� �alma Pekmez (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 45.00,
                    Guncel_Fiyat = 37.50,
                    KisaAciklama = "Yap�m� olduk�a emek isteyen ve uzun s�ren �alma Pekmez, her insan�n kahvalt� sofras�nda g�rmek isteyece�i enfes tat.% 100 do�al i�eri�iyle ev yap�m�d�r.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "�alma pekmez, �alma pekmez sat�n al, zile �alma pekmez",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/calma-pekmez-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 104,
                    Name = "Ev Yap�m� �ilek Re�eli (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 23.00,
                    KisaAciklama = "En leziz �ileklerin mevsiminde toplanmas� ile elde edilen Ev Yap�m� �ilek Re�eli. Sabah kahvalt�lar�n�z�n tatl� ve sa�l�kl� orta�� �ilek re�eli, tamamen do�ald�r ve katk� maddesi i�ermez.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "�ilek re�eli, ev yap�m� �ilek re�eli",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/cilek-receli-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 105,
                    Name = "Ev Yap�m� Kay�s� Re�eli (800 Gram)",
                    Stok = 2,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 28.50,
                    Guncel_Fiyat = 22.50,
                    KisaAciklama = "Kendi bah�elerimizde yeti�en taze ve do�al kay�s�lar�m�z� kullanarak tamamen geleneksel usullerle haz�rlad���m�z katk�s�z, do�al ev yap�m� kay�s� re�elimizi mutlaka denemelisiniz.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "Do�al kay�s� re�eli, ev yap�m� kay�s� re�eli, Kay�s� Re�eli, Kay�s� re�eli sat�n al",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/ayva-receli-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 106,
                    Name = "Ev Yap�m� Ke�i Boynuzu Pekmezi (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Faydalar� saymakla bitmeyen, zengin vitamin i�erikli Ke�i Boyunuzu Pekmezi sofralar�n�za lezzet katacak. Tamamen organik ve katk�s�zd�r. Do�al y�ntemlerle �retilmi�tir.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "do�al ke�i boynuzu pekmezi, ev yap�m� ke�i boynuzu pekmezi, ke�i boynuzu pekmezi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/keci-boynuzu-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 107,
                    Name = "Ev Yap�m� Ku�burnu Marmelat� (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 35.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Ev Yap�m� Ku�burnu Marmelat�. Tamamen do�al y�ntemlerle �retilmi�tir. Hi�bir katk� maddesi bulunmamaktad�r. Glikoz i�ermez.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "ev yap�m� ku�burnu marmelat�, ku�burnu marmelat�",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/kusburnu-marmelati-yorenizden-1-600x450.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 108,
                    Name = "Ev Yap�m� �z�m Pekmezi (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 35.00,
                    Guncel_Fiyat = 27.00,
                    KisaAciklama = "Ev yap�m� tamamen organik, do�al, �z�m Pekmezi. Hi�bir katk� maddesi kullan�lmam��t�r.Tokat�n me�hur ba�lar�n�n �z�mleri kullan�lm��t�r.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 4,
                    Etiketler = "ev yap�m� �z�m pekmezi, �z�m pekmezi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/uzum-pekmezi-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 109,
                    Name = "Ev Yap�m� Vi�ne Re�eli (800 Gram)",
                    Stok = 800,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 28.50,
                    Guncel_Fiyat = 22.50,
                    KisaAciklama = "Tamamen do�al vi�nelerden �retilen, katk�s�z Organik Vi�ne Re�eli. Sabah kahvalt�lar�n�z�n vazge�ilmezi olacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 3,
                    Etiketler = "vi�ne re�eli, vi�ne re�eli organik",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/visne-receli-yorenizden-600x450.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 110,
                    Name = "K�y Tereya�� 1 Kg",
                    Stok = 1,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 65.00,
                    Guncel_Fiyat = 55.00,
                    KisaAciklama = "Sabah kahvalt� sofralar�n�za renk katacak, yemeklerinizin lezzetini katlayacak k�y tereya��.(Tuzsuzdur)(K�� aylar�nda tereya� rengi beyazd�r.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "ev tereya��, k�y teraya��, teraya��",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/01/koy-tereyagi-600x447.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 111,
                    Name = "Sade Zile Pekmezi (300 Gram)",
                    Stok = 300,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 17.50,
                    Guncel_Fiyat = 17.50,
                    KisaAciklama = "Ad�n� Tokat��n il�esi olan Zile�den alan zile pekmezi; Zile�nin narinmi narin �z�mlerinin yumurta ak�yla kar��t�r�larak yap�lmas�ndan olu�ur. Beyaz renkte olan zile pekmezi �lkemizde �ok sevilerek t�ketilmektedir. Zile pekmezi besin de�eri olarak �ok doludur. Sade Zile Pekmezi do�al haliyle sofralar�n�z� �enlendirmeye haz�r.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "Sade Zile Pekmezi, zile pekmezi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/12/zile-pekmezi-sade-600x600.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 112,
                    Name = "Taze ��kelek (1 KG)",
                    Stok = 1,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat=20.00,
                    Guncel_Fiyat=20.00,
                    KisaAciklama = "Kahvalt� sofralar�n�n vazge�ilmezi, inek s�t�nden yap�lma, tamamen do�al taze ��kelek.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "��kelek, ��kelek sat�n al, taze ��kelek",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/taze-cokelek-yorenizden.jpg",
                    CategoryId = 100,
                },
                new �r�n
                {
                    Id = 113,
                    Name = "Renkli Tokat Sofra Bezi",
                    Stok = 100,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat =20.00,
                    Guncel_Fiyat =20.00,
                    KisaAciklama = "�ster yer sofralar�n�zda, ister piknik masalar�n�zda kullanabilece�iniz, isterseniz de annenize, e�inize, dostunuza hediye edebilece�iniz Tokat Sofra Bezleri��r�n� al�rken not olarak istedi�iniz rengi belirtmeyi unutmay�n.Tokat Sofra Bezi kaliteli kuma�lardan yap�lm��t�r.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "sofra bezi, sofra bezi sat�n al, tokat sofra bezleri",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/sbezisar%C4%B1siteyey%C3%BCklenecek-600x600.jpg"+
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezibeyazsimlip%C3%BCsk%C3%BCls%C3%BCz-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezikahvesiteye-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezimavisiteye-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezisar%C4%B1siteyey%C3%BCklenecek-1-600x600.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/02/sbezishardalsiteyey%C3%BCklenecek-600x600.jpg",
                    CategoryId = 101,
                },
                new �r�n
                {
                    Id = 114,
                    Name = "Tokat Yazmas�",
                    Stok = 100,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat =10.00,
                    Guncel_Fiyat =8.75,
                    KisaAciklama = "Tokat��n k�lt�rel �zelliklerini simgeleyen ve �lkede �nemli yer edinen diki�li, poliser Nisa �pek Tokat Yazmas��r�n� al�rken not olarak ka��nc� yazmay� istedi�inizi belirtmeyi unutmay�n�z.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "tokat yazmas�, tokat yazmas� sat�n al, yazma sat�n al",
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
                new �r�n
                {
                    Id = 115,
                    Name = "Zile K�mesi (500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat =19.50,
                    Guncel_Fiyat =19.50 ,
                    KisaAciklama = "Me�hur Zile ba�lar�ndan toplanan cevizlerin ve �z�m ��ras�n�n kar��t�r�l�p kurutulmas� ve ni�asta ile birle�imiyle haz�rlanan e�siz cevizli sucuk. Do�al bir �r�nd�r. Katk�s�zd�r.Bol cevizli muhte�em tad� dama��n�zda lezzet ��leni yaratacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "cevizli sucuk, zile k�mesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/zile-komesi-yorenizden-600x450.jpg",
                    CategoryId = 101,
                },
                new �r�n
                {
                    Id = 116,
                    Name = "Do�al �ekersiz S�zme Bal (850 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 75.00,
                    Guncel_Fiyat = 65.00,
                    KisaAciklama = "Sivas/Zara�n�n engin da�lar�n�n zirvelerinden toplanan �i�eklerin �zleriyle meydana gelen enfes Do�al �ekersiz S�zme Bal.Analiz Raporu A�a��dad�r.",
                    YildizSayisi =5,
                    IncelemeSayisi = 7,
                    Etiketler = "�ekersiz bal, �ekersiz s�zme bal, s�zme bal sat�n al",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/sekersiz-bal-yorenizden-600x450.jpg"+
                    "https://yorenizden.com/wp-content/uploads/2019/02/bal-600x600.jpg",
                    CategoryId = 102,
                },
                new �r�n
                {
                    Id = 117,
                    Name = "Tokat �emeni (300 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 7.50,
                    Guncel_Fiyat = 6.50,
                    KisaAciklama = "Hakiki Me�hur Tokat �emeni. En do�al haliyle sofralar�n�za konuk oluyor. Katk�s�z, koruyucusuz, geleneksel y�ntemlerle �retilmi�tir.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 4,
                    Etiketler = "�emen, tokat �emeni",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/tokat-cemeni-yorenizden-1-600x450.jpg",
                    CategoryId = 102,
                },
                new �r�n
                {
                    Id = 118,
                    Name = "Tokat Ev Ekme�i",
                    Stok = 500,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat = 11.00,
                    Guncel_Fiyat = 9.00,
                    KisaAciklama = "Do�al olarak maya ile yo�urulan hamur kabarmak �zere belirli bir s�re bekletilir ve yeterince mayalanmas� sa�land���nda ekmek boyutlar�nda hamurlar, odun ate�inde �s�nm�� ta� f�r�nlarda tamamen geleneksel y�ntemlerle pi�irilir.Her g�n taptaze bir �ekilde �retilen ekmekler sizlere m�mk�n oldu�unca taze bir �ekilde ula�t�r�l�r.Bu lezzet her ���n yemeklerinizde t�ketebilece�iniz hatta bazen can�n�z�n sadece Tokat Ev Ekme�i �ekece�i bir lezzettir.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 3,
                    Etiketler = "ev ekme�i, mayal� ev ekme�i, tokat ev ekme�i",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/ev-ekmegi-2-yorenizden-600x450.jpg"+
                    "https://yorenizden.com/wp-content/uploads/2019/02/ev-ekmegi-yorenizden-600x450.jpg",
                    CategoryId = 102,
                },
                new �r�n
                {
                    Id = 119,
                    Name = "Tokat Yapra�� (1,5 KG)",
                    Stok = 0,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 0,
                    KisaAciklama = "Tokat b�lgesinde yeti�mi�, do�al �z�m ba�lar�ndan toplanm��, tamamen do�al, tad�na doyamayaca��n�z, Tokat��n me�hur yaprak sarmas�na lezzet katacak Tokat Yapra��.Tokat Asma Yapra�� Paket ��eri�i : S�zme 700 Gr �zel Bidonda",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "tokat erbaa yapra��, tokat salamura yaprak, tokat yapra��",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1--600x450.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1.jpg",
                    CategoryId = 102,
                },
                new �r�n
                {
                    Id = 120,
                    Name = "Tokat Yapra�� (3 KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 65.00,
                    Guncel_Fiyat = 55.00,
                    KisaAciklama = "Tokat b�lgesinde yeti�mi�, do�al �z�m ba�lar�ndan toplanm��, tamamen do�al, tad�na doyamayaca��n�z, Tokat��n me�hur yaprak sarmas�na lezzet katacak Tokat Yapra��. Yeni Sezon �r�n�d�rTokat Asma Yapra�� Paket ��eri�i : S�zme 2000 Gr �zel Bidonda",
                    YildizSayisi = 5,
                    IncelemeSayisi = 8,
                    Etiketler = "tokat erbaa yapra��, tokat salamura yaprak, tokat yapra��",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1--600x450.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1.jpg",
                    CategoryId = 102,
                },
                new �r�n
                {
                    Id = 121,
                    Name = "Tokat Yapra�� (5 KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 75.00,
                    Guncel_Fiyat = 65.00,
                    KisaAciklama = "Tokat ba� yapra��, anayurdu Tokat olan ince ve damars�z yap�s� ile sofralar�n�za lezzet katacakt�r. Tamamen do�al ortamda �zel olarak yeti�tirilmi� ve titizlikle haz�rlanm��t�r. Tokat��n me�hur ba� yapra�� ile ��k sofralar�n vazge�ilmez lezzeti olan yaprak sarmas� sunumlar�n�z sofran�za lezzet katacak olup, misafirleriniz de tad�na doyamayacakt�r. 5 kilogram se�ene�i ile kalabal�k ailelerin tercihi olan Tokat ba� yapra��n� siz de denemelisiniz. Yeni Sezon �r�n�d�rTokat Asma Yapra�� Paket ��eri�i : S�zme 3000 Gr �zel Bidonda",
                    YildizSayisi = 5,
                    IncelemeSayisi = 1,
                    Etiketler = "tokat erbaa yapra��, tokat salamura yaprak, tokat yapra��",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1--600x450.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1.jpg",
                    CategoryId = 102,
                },
                new �r�n
                {
                    Id = 122,
                    Name = "Tokat Yapra�� (5 KG) 2�Li Paket",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 130.00,
                    Guncel_Fiyat = 120.00,
                    KisaAciklama = "Tokat b�lgesinde yeti�mi�, do�al �z�m ba�lar�ndan toplanm��, tamamen do�al, tad�na doyamayaca��n�z, Tokat��n me�hur yaprak sarmas�na lezzet katacak Tokat Yapra�� 5 KG�luk bidonda 2�li paket. Yeni Sezon �r�n�d�rTokat Asma Yapra�� Paket ��eri�i :  S�zme 3000 Gr �zel Bidonda",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "tokat erbaa yapra��, tokat salamura yaprak, tokat yapra��",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1--600x450.jpg" +
                    "https://yorenizden.com/wp-content/uploads/2019/04/tokat-yapra%C4%9F%C4%B1.jpg",
                    CategoryId = 102,
                },
                new �r�n
                {
                    Id = 123,
                    Name = "Zile K�mesi(500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 19.50,
                    Guncel_Fiyat = 19.50,
                    KisaAciklama = "Me�hur Zile ba�lar�ndan toplanan cevizlerin ve �z�m ��ras�n�n kar��t�r�l�p kurutulmas� ve ni�asta ile birle�imiyle haz�rlanan e�siz cevizli sucuk. Do�al bir �r�nd�r. Katk�s�zd�r.Bol cevizli muhte�em tad� dama��n�zda lezzet ��leni yaratacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 2,
                    Etiketler = "cevizli sucuk, zile k�mesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/zile-komesi-yorenizden-600x450.jpg",
                    CategoryId = 102,
                },
                new �r�n
                {
                    Id = 124,
                    Name = "Ceviz Sirkesi 500 ml Do�al Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Ceviz sirkesi, do�al olarak ila�s�z ve hormonsuz �ekilde yeti�en yerli cevizlerimizin sirke haline getirilmesi ile elde edilen tamamen do�al bir �r�nd�r.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "ceviz sirkesi, do�al ceviz sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/cevizsirkesi-600x869.jpg",
                    CategoryId = 103,
                },
                new �r�n
                {
                    Id = 125,
                    Name = "Elma Sirkesi 500 ml Do�al Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Elma Sirkesi, elmalar�n do�al ve ila�s�z olanlar� kullan�larak do�al y�ntemler ile  haz�rland�. Sa�l�k a��s�ndan cam �i�ede!�sterseniz suya kar��t�rarak i�ebilirsiniz ortalama bir bardak suya iki yemek ka���� elma sirkesi koyarak,i�imi �ok rahatt�r.Yada salata ve soslar�n�za ekliyerek lezzet katabilirsiniz.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 1,
                    Etiketler = "do�al elma sirkesi, elma sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/elmasirkesi-600x869.jpg",
                    CategoryId = 103,
                },
                new �r�n
                {
                    Id = 126,
                    Name = "Enginar Sirkesi 500 ml Do�al Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Enginar Sirkesi, do�al ve ila�s�z olanlar�n� kullanarak do�al y�ntemler ile Enginar sirkesi haz�rlad�.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "do�al enginar sirkesi, enginar sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/enginarsirkesi-600x936.jpg",
                    CategoryId = 103,
                },
                new �r�n
                {
                    Id = 127,
                    Name = "Kay�s� Sirkesi 500 ml Do�al Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Kay�s� Sirkesi, �ok fazla bulunamayan ender sirke �e�itlerinden biridir. Di�er sirkelere nazaran daha az keskin, yumu�ak i�imli bir sirkedir.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "do�al kay�s� sirkesi, kay�s� sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/kay%C4%B1s%C4%B1sirkesi-600x869.jpg",
                    CategoryId = 103,
                },
                new �r�n
                {
                    Id = 128,
                    Name = "Nar Sirkesi 500 ml Do�al Fermantasyon",
                    Stok = 500,
                    Birim = OlcuBirimi.Milligram,
                    Ilk_Fiyat = 25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "Nar Sirkesi,narlar�n do�al ve ila�s�z olanlar�n� kullanarak do�al y�ntemler ile sizler i�in nar sirkesi haz�rland�.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "do�al nar sirkesi, nar sirkesi",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/narsirkesi-600x869.jpg",
                    CategoryId = 103,
                },
                new �r�n
                {
                    Id = 129,
                    Name = "Dana Ku�ba�� (500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 27.50,
                    Guncel_Fiyat = 27.50,
                    KisaAciklama = "%100 Tosun etinden yap�lan dana ku�ba��, �Lop Et� g�vencesiyle kap�n�za kadar getiriyoruz.(Sadece Tokat / Merkez i�i elden teslimatlarda ge�erlidir.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/03/bebeklere-ozel-kusbasi-600x400.jpg",
                    CategoryId = 104,
                },
                new �r�n
                {
                    Id = 130,
                    Name = "Dana Orta Ya�l� K�yma (500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat =25.00,
                    Guncel_Fiyat = 25.00,
                    KisaAciklama = "%100 Tosun etinden yap�lan dana ku�ba��, �Lop Et� g�vencesiyle kap�n�za kadar getiriyoruz.(Sadece Tokat / Merkez i�i elden teslimatlarda ge�erlidir.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "dana, dana k�yma, tosun, tosun eti",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/03/s1200-600x400.jpg",
                    CategoryId = 104,
                },
                new �r�n
                {
                    Id = 131,
                    Name = "Dana S�f�r Ya�l� K�yma (500 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 30.00,
                    KisaAciklama = "%100 Tosun etinden yap�lan dana ku�ba��, �Lop Et� g�vencesiyle kap�n�za kadar getiriyoruz.(Sadece Tokat / Merkez i�i elden teslimatlarda ge�erlidir.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/03/s1200-600x400.jpg",
                    CategoryId = 104,
                },
                new �r�n
                {
                    Id = 132,
                    Name = "Do�al K�y Tavu�u 1 Adet",
                    Stok = 500,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat = 30.00,
                    Guncel_Fiyat = 30.00,
                    KisaAciklama = "Tahtoba k�y�nde yay�lan k�y tavuklar� do�al y�ntemlerle beslenip 1 sene sonunda kesiliyor.1 Adet Ortalama 1.200 - 1.400 gram aras� de�i�mektedir.(Sadece Tokat / Merkez i�i elden teslimatlarda ge�erlidir.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/03/37a08ab8b58291604dfff2594a5ba106-600x598.jpg",
                    CategoryId = 104,
                },
                new �r�n
                {
                    Id = 133,
                    Name = "Tokat Bez Sucuk (1KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 90.00,
                    Guncel_Fiyat = 80.00,
                    KisaAciklama = "%100 yerli kesim tosun etlerinden, tamamen katk�s�z, koruyucusuz me�hur geleneksel Tokat Bez Sucu�u. Sabah kahvalt�lar�n�za, mangallar�n�za ve sofran�za lezzet katacak.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 12,
                    Etiketler = "bez sucuk, bez sucuk sat�n al, sucuk sat�n al, tokat bez sucuk, Tokat Sucu�u",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/03/bez-sucuk-yorenizden.jpg",
                    CategoryId = 104,
                },
                new �r�n
                {
                    Id = 134,
                    Name = "Tokat Bez Sucuk (300-330 Gram)",
                    Stok = 500,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 29.00,
                    Guncel_Fiyat = 29.00,
                    KisaAciklama = "Tamamen katk�s�z, koruyucusuz me�hur geleneksel Tokat Bez Sucu�u. Sabah kahvalt�lar�n�za, mangallar�n�za ve sofralar�n�za lezzet katacak.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "bez sucuk, tokat bez sucuk",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/03/bez-sucuk-yorenizden.jpg",
                    CategoryId = 104,
                },
                new �r�n
                {
                    Id = 135,
                    Name = "K�y Tereya�� 1 Kg",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 65.00,
                    Guncel_Fiyat = 55.00,
                    KisaAciklama = "Sabah kahvalt� sofralar�n�za renk katacak, yemeklerinizin lezzetini katlayacak k�y tereya��.(Tuzsuzdur)(K�� aylar�nda tereya� rengi beyazd�r.)",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "ev tereya��, k�y teraya��, teraya��",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2020/01/koy-tereyagi-600x447.jpg",
                    CategoryId = 105,
                },
                new �r�n
                {
                    Id = 136,
                    Name = "Taze ��kelek (1 KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 20.00,
                    Guncel_Fiyat = 20.00,
                    KisaAciklama = "Kahvalt� sofralar�n�n vazge�ilmezi, inek s�t�nden yap�lma, tamamen do�al taze ��kelek.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "Kahvalt� sofralar�n�n vazge�ilmezi, inek s�t�nden yap�lma, tamamen do�al taze ��kelek.",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/02/taze-cokelek-yorenizden-600x450.jpg",
                    CategoryId = 105,
                },
                new �r�n
                {
                    Id = 137,
                    Name = "Ev Yap�m� Eri�te (1 KG)",
                    Stok = 500,
                    Birim = OlcuBirimi.Kilogram,
                    Ilk_Fiyat = 22.50,
                    Guncel_Fiyat = 22.50,
                    KisaAciklama = "Tamamen el yap�m�, k�y yumurtal� eri�temiz. Do�al yollarla kurutulmu�tur.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "El yap�m� eri�te, Ev yap�m� eri�te",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/09/eri%C5%9Fte.jpg",
                    CategoryId = 106,
                },
                new �r�n
                {
                    Id = 138,
                    Name = "Tokat Yo�urtma�",
                    Stok = 500,
                    Birim = OlcuBirimi.Adet,
                    Ilk_Fiyat = 9.00,
                    Guncel_Fiyat = 9.00,
                    KisaAciklama = "�lk olarak Tokat��n il�elerinden biri olan Turhal il�esinde yap�lan Tokat Yo�urtma�� di�er ad�yla Turhal Yo�urtma�� T�rkiye�nin bir �ok yerinde me�hurdur.Yap�l��� emek isteyen e�siz lezzet.Yo�urtma� �e�itleri;Cevizli Yo�urtma�, Ha�ha�l� Yo�urtma�, Sade Yo�urtma� l�tfen sipari�inizde belirtmeyi unutmay�n.",
                    YildizSayisi = 5,
                    IncelemeSayisi = 1,
                    Etiketler = "Tokat Yo�urtmac�, Yo�urtma�",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/11/yo%C4%9Furtma%C3%A7-600x415.png",
                    CategoryId = 106,
                },
                new �r�n
                {
                    Id = 139,
                    Name = "Ev Yap�m� Domates Sal�as� (5300 Gram)",
                    Stok = 0,
                    Birim = OlcuBirimi.Gram,
                    Ilk_Fiyat = 85.00,
                    Guncel_Fiyat = 70.00,
                    KisaAciklama = "Domatesin ba�kenti Tokat��n e�siz Kazova domateslerinden yap�lan tamamen ev yap�m� domates sal�as�. Muhte�em tad� ve kokusuyla tad�na doyamayaca��n�z katk�s�z ve koruyucusuz ev yap�m� domates sal�as�.",
                    YildizSayisi = 0,
                    IncelemeSayisi = 0,
                    Etiketler = "do�al domates sal�as�, domates sal�as�, ev yap�m� domates sal�as�",
                    UrunResmi = "https://yorenizden.com/wp-content/uploads/2019/04/domates-salcasi-min.jpg",
                    CategoryId = 107,
                }
                /*
                 new �r�n
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