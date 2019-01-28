using BOOKCATALOG.DB.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BOOKCATALOG.DB
{
    public static class SeedData
    {
        public static void AddBooks(IApplicationBuilder app)
        {
            Context context = app.ApplicationServices.GetRequiredService<Context>();

            if (!context.Books.Any())
            {
                List<Book> booksDB = new List<Book>()
                {
                    new Book()
                    {
                        Title = "Kwiat wiśni",
                        ReleaseDate = DateTime.Now.Year,
                        Price = 19.5,
                        Count = 3
                    },
                    new Book()
                    {
                        Title = "Zbrodnia i kara",
                        ReleaseDate = DateTime.Now.Year,
                        Price = 19.5,
                        Count = 3
                    },
                    new Book()
                    {
                        Title = "W pustyni i w puszczy",
                        ReleaseDate = DateTime.Now.Year,
                        Price = 19.5,
                        Count = 3
                    }
                };

                context.Books.AddRange(booksDB);
            }

            context.SaveChanges();
        }
    }
}