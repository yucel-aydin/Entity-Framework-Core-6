// See https://aka.ms/new-console-template for more information
using EFCore.DatabaseFirstByScaffold.Models;
using Microsoft.EntityFrameworkCore;

using (var _context = new EfCoreDBFirstContext())
{
    var products = await _context.Products.ToListAsync();
    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} - {p.Name} - {p.Stock}- {p.Price}");
    });
}
//Scaffold-DbContext "Data Source=.;Initial Catalog=EfCoreDBFirst;User ID=sa;Password=951753;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models 