using BookWarehouse.Api.Users;
using BookWarehouse.Api.Utils;
using BookWarehouse.Domain;
using BookWarehouse.Domain.Books;
using BookWarehouse.Domain.SharedKernel;
using BookWarehouse.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookWarehouse.Api
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
            services.AddHttpContextAccessor();
            services.AddScoped<IUserContext, AspNetUserContextAdapter>();

            services.AddHandlers();

            var options = CreateOptions(Configuration);
            var configurations = EntityTypeConfigurations.All;

            services.AddScoped(p => new WarehouseContext(options, configurations));
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<Warehouse>();
            services.AddScoped<Messages>();

            services.AddRouting(options => { options.LowercaseUrls = true; });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
        }

        private DbContextOptions<WarehouseContext> CreateOptions(IConfiguration configuration)
        {
            var contextOptions = new DbContextOptionsBuilder<WarehouseContext>();

            contextOptions.UseSqlServer(configuration["Database:ConnectionString"]);

            return contextOptions.Options;
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
