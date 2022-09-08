using Bookapi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services;

namespace Bookapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<BookstoreDbSettings>(
                Configuration.GetSection(nameof(BookstoreDbSettings)));

            services.AddTransient<IBookservices, Bookservices>();
            services.AddSingleton<IMongoClient, MongoClient>();

            services.AddScoped<IBookstoreDbSettings, BookstoreDbSettings>(e => 
            e.GetRequiredService<IOptions<BookstoreDbSettings>>().Value);

           

            services.AddControllers()
                    .AddNewtonsoftJson(Options => Options.UseMemberCasing());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
