using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DatabaseFirst.DAL
{
    //Ef DbContext sınıfından miras alan dbcontext imiz
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }
        // :base(options) bu şekilde optionsları miras aldığımız DbContext sınıfımızın constrocturına gönderiyoruz.
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        // İstersek OnConfiguring ile istersek DBContextInitializer ile connection tanımlanabilir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
        }
    }
}
