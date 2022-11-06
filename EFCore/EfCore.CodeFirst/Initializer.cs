using EfCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst
{
    public class Initializer
    {
        public static IConfigurationRoot Configuration;

        public static void Build()
        {
            // optional : bu dosya olabilirde olmayabilirde.
            // reloadOnChange : her değişiklik yapıldığında yeniden yüklensinmi
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
       
        }
    }
}
