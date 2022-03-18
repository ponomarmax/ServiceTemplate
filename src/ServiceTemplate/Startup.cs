using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceTemplate.Common;
using ServiceTemplate.Data;
using ServiceTemplate.Data.Abstractions;
using ServiceTemplate.Data.Repositories;
using ServiceTemplate.StartupHelper;

namespace Oneview.Inpatient.Logging.ApiDemo
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
            services.AddLogging(Configuration);
            services.AddDbContextFactory<Context>(options =>
            {
                // #DemontrationOnly
                options.UseInMemoryDatabase(Configuration.GetConnectionString(DbContant.ConnectionStringDbSection));
                //options.UseSqlServer(Configuration.GetConnectionString(DbContant.ConnectionStringDbSection), b => b.MigrationsAssembly(typeof(Context).Assembly.FullName));
            }, ServiceLifetime.Transient);
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddTransient<ITestRepository, TestRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // #DemontrationOnly
            InitializeDb(app);
        }

        private void InitializeDb(IApplicationBuilder app)
        {
            var _factory = app.ApplicationServices.GetRequiredService<IDbContextFactory<Context>>();
            using var context = _factory.CreateDbContext();
            context.Database.EnsureCreated();
        }
    }
}
