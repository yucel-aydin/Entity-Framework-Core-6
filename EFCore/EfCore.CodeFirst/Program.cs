// See https://aka.ms/new-console-template for more information
using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

//appsettings.json dosyamızı okunabilir hale getirir.
Initializer.Build();

/*
 1-	Add-migration	==> Veritabanına yansıtılacak olan tabloların özelliklerini tip güvenli bir şekilde oluşturur. 
                        O anın tarih zaman bilgisiyle bir sınıf oluşturur. Ve birde snapshot dosyası oluşturur.
                        Migration sınıfında 2 metot vardır Up ve Down metotları. 
                            a-	Up Metodu       ==> update-database komutu Up metodunu çalıştırarak ilgili tablo vs. oluşturur.
                            b-	Down Metodu     ==>	Bu metot ile ilgili migrationu Up metodundaki işlemleri geri almak istediğimizde çalışır. 
                                                    Yani Up metodunda yazanların tam tersi işlemleri yapan kodlar bulunur içerisinde. 
    Snapshot ise database ile entitylerimizin senkron olması için propertyleri tutar. Yani bir migration oluşturduğumuzda 
    önceki snapshotlardan bu migration içerisinde eklediğimiz tablo sütun vs. lerin daha önce db ye yazılıp yazılmadığını anlar 
    ve ona göre migration sınıfını oluşturur. 
    
    “__EFMigrationsHistory” adlı bir tablo oluşturarak bu tabloda migrationlarımızı tutar. İsimleri ve efcore versiyonları tutulur. 
    Migration lar arasında geçiş vs. işlemleri için kullanılır.

 2- Update-database ==> Migration u veritabanına yansıtmak için kullanılır. İlgili entityler yoksa oluşturur, değişiklikleri varsa uygular.

 */
using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();
    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} - {p.Name} - {p.Stock}- {p.Price}");
    });
}