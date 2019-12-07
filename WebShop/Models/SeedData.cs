using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Infrastructure;

namespace WebShop.Models
{
    public class SeedData
    {
        /// <summary>
        /// If there is no page entries in the DB, create them.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new WebShopContext(serviceProvider.GetRequiredService<DbContextOptions<WebShopContext>>());
            
            // if there is no pages in the DB create them
            if (context.Pages.Any())
                return;

            context.Pages.AddRange(
                new Page
                {
                    Title = "Home",
                    Slug = "home",
                    Content = "home page",
                    Sorting = 0
                },
                new Page
                {
                    Title = "About Us",
                    Slug = "about-us",
                    Content = "about us page",
                    Sorting = 100
                },
                new Page
                {
                    Title = "Serivces",
                    Slug = "services",
                    Content = "services page",
                    Sorting = 100
                },
                new Page
                {
                    Title = "Contact",
                    Slug = "contact",
                    Content = "contact page",
                    Sorting = 100
                });

            context.SaveChanges();
        }
    }
}
