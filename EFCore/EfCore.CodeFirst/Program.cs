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

 2- Update-database ==> Son migration u veritabanına yansıtmak için kullanılır. İlgili entityler  yoksa oluşturur varsa değişiklikleri uygular. 
                        Aynı zamanda update-database <migrationname> Şeklinge bir migrationa dönme işlemi yapılabilir. 
                        Dönmek istediğimiz migrationdan sonraki tüm migration sınıflarında ki down metotlarını çalıştırarak aradaki işlemleri geri alır. 
                        Geri alınan migration sınıfları tekrar remove-migration metoduyla silinebilir.

 3- Remove-migration ==> Bu son oluşturulan ve database e yansıtılmamış migration ı silmek için kullanılır.
                        Eğer Db ye yansıtılan bir migrationu silmek istiyorsak önce update-database ile dönemk istediğimiz migrationa dönüp 
                        sonra silmek istediğimizi silebiliriz. 

 4-	Script-migration ==> Migrationların bir sql scriptini oluşturur ve bunları manuel olarak db tarafında kullanabiliriz.
 */
using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();
    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} - {p.Name} - {p.Stock}- {p.Price}");
    });
}