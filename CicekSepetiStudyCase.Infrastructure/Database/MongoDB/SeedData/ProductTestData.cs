using CicekSepetiStudyCase.Domain.Entities;
using System.Collections.Generic;

namespace CicekSepetiStudyCase.Infrastructure.Database.MongoDB.SeedData
{
    public static class ProductTestData
    {
        /// <summary>
        /// Returns Product Test Data
        /// </summary>
        /// <returns></returns>
        public static List<Product> FillProductCollectionWithTestData()
        {
            var products = new List<Product>
            {
                new Product()
                {
                    Name = "Yaz Sürprizi Lisyantus Aranjmanı",
                    Description = "Sürprizlerin en renklisi,en özeli bu eşsiz aranjmanda sevdiklerinizi bekliyor. Konik cam vazoda yeşilliklerle süslenmiş renkli lisyantuslar ile hazırlanan Yaz Sürprizi çiçek aranjmanı, bu yazın en renkli sürprizi olacak.",
                    Price = 80,
                    UnitInStock = 40
                },
                new Product()
                {
                    Name = "Doğal Ahşap Kütükte Lisyantus Aranjmanı",
                    Description = "Doğallık herkesin sevdiği ve her zaman iyi hissettiren bir yapıya sahiptir. Doğallığı seven ve hayat tarzını buna göre inşa eden tüm sevdiklerinize hem anlamlı hem de doğal bir hediye vermek isterseniz; Doğal Ahşap Kütükte Lisyantus Aranjmanı muhteşem bir seçim olacaktır. ",
                    Price = 55,
                    UnitInStock = 200
                },
                new Product()
                {
                    Name = "Romantik ve Zarif Beyaz Çiçekler - Paşabahçe Vazoda",
                    Description = "Sevdiklerinize özel günlerinde eşlik edecek bir çiçek mi arıyorsunuz? Barışın, sevginin, saflığın ve masumiyetin simgesi olan beyazın lisyantus ve güller ile somutlaştırıldığı Romantik ve Zarif Beyaz Çiçekler Aranjmanı ile sevdiklerinizi mutlu etmek çok kolay! ÇiçekSepeti'nin farklı ödeme seçenekleri ve aynı gün teslimatı sayesinde hemen şimdi onu mutlu edebilirsiniz!",
                    Price = 125,
                    UnitInStock = 20
                },
                new Product()
                {
                    Name = "Yenilenmiş Apple iPhone 6 16 GB (12 Ay Garantili)",
                    Description = "EasyCep yenilenmiş telefonlar için bir pazar yeri uygulamasıdır. Aldığınız ürünü sizin adınıza inceler ve kargolar. Ayrıca, EasyCep'te satılan bütün yenilenmiş telefonlar 12 ay EasyCep garantisi altındadır.",
                    Price = 7500,
                    UnitInStock = 40
                },
                new Product()
                {
                    Name = "Xiaomi Mi Band 5 Akıllı Bileklik için Baklalı Metal Model Kordon",
                    Description = "Xiaomi Mi Band 5 akıllı bileklik ile uyumlu metal stainless steel baklalı kordonlar kaliteli malzemeden üretilmiş, suya dayanıklı ürünlerdir.",
                    Price = 250,
                    UnitInStock = 100
                },
                new Product()
                {
                    Name = "Lenovo ThinkPad P73 20QR002WTX i9-9880H 32GB 512SSD RTX4000 17.3'",
                    Description = "ThinkPad P73 mobil iş istasyonu, Intel®'in en son yüksek performanslı işlemcileri sayesinde azami güç sunuyor.Sekiz çekirdekli i9 işlemcisine kadar işlemci seçenekleri ve güçlü yeni NVIDIA®RTX Quadro® 5000 serisinekadar grafik donanımı ile gerçek zamanlı sanal gerçeklik oluşturma hızlarına ve aynı zamanda yoğun bilgi işlemgerektiren herhangi bir sektörde iş akışlarının yürütülmesi için yapay zekâ ile güçlendirilmiş araçlara sahip olacaksınız.",
                    Price = 47500,
                    UnitInStock = 8
                },
                new Product()
                {
                    Name = "Lenovo IdeaPad 5 AMD Ryzen 3 5300U 8GB 512GB SSD Freedos 14'",
                    Description = "Lenovo IdeaPad 5 AMD Ryzen 3 5300U 8GB 512GB SSD Freedos 14' 82LM0093TX",
                    Price = 5000,
                    UnitInStock = 15
                },
                new Product()
                {
                    Name = "Samsung Galaxy Tab E T562 8 GB Siyah Tablet VİTRİN (EBA+ZOOM)",
                    Description = "Ürün Fiziki Durumu : Herhangi Bir Sorunu mevcut değildir. Temiz Ürünlerdir",
                    Price = 699,
                    UnitInStock = 10
                },
                new Product()
                {
                    Name = "Turbox Tx383 i5 650 Turbo 3.46GHz 8GB Ram 500GB HDD 19.5'' Mon. Masaüstü",
                    Description = "Intel i5 + 8GB RAM + 500GB HDD + 250W TURBOX KASA",
                    Price = 2459,
                    UnitInStock = 0
                },
            };

            return products;
        }
    }
}
