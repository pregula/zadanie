using BOOKCATALOG.API.Models;
using BOOKCATALOG.DB;
using BOOKCATALOG.DB.Interfaces;
using BOOKCATALOG.DB.Repositories;
using BOOKCATALOG.INFRASTRUCTURE.Interfaces;
using BOOKCATALOG.INFRASTRUCTURE.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BOOKCATALOG.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options
            .UseSqlServer(Configuration["ConnectionStrings:BOOKCATALOG"]));
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {

                    builder.WithOrigins("http://localhost:1337/").AllowAnyOrigin();
                    builder.WithOrigins("http://localhost:1337/").AllowAnyMethod();
                    builder.WithOrigins("http://localhost:1337/").AllowAnyHeader();
                    builder.AllowAnyOrigin();
                });
            });
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("CorsPolicy");
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

            SeedData.AddBooks(app);
        }
    }
}