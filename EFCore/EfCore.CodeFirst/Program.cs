// See https://aka.ms/new-console-template for more information
using EfCore.CodeFirst;
using EfCore.CodeFirst.DAL;

//appsettings.json dosyamızı okunabilir hale getirir.
Initializer.Build();



using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();
    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} - {p.Name} - {p.Stock}- {p.Price}");
    });
}