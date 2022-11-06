// See https://aka.ms/new-console-template for more information
using EFCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;

DbContextInitializer.Build();

// DbContextInitializer kullanmak istersek bu şekilde yazılmalı
//using (var _context = new AppDbContext(DbContextInitializer.OptionsBuilder.Options))


using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();
    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} - {p.Name} - {p.Stock}- {p.Price}");
    });
}