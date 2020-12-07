using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using skinet.API.Data;
using skinet.API.Extensions;
using skinet.API.Helpers;
using skinet.API.Middleware;
using skinet.Infrastructure.Identity;
using StackExchange.Redis;

namespace skinet.API
{
    public class Startup
    {

        private   IConfiguration _config { get; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connString = _config.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoreContext>(option => option.UseSqlServer(connString));
            var identityConnectionString = _config.GetConnectionString("IdentityConnection");
            services.AddDbContext<AppIdentityDbContext>(option => option.UseSqlServer(identityConnectionString));

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });
            services.AddApplicationServices();
            services.AddIdentityService(_config);
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddSwaggerDocumentation();

            services.AddCors(opt =>
            {
                opt.AddPolicy(name:"CorsPolicy", policy =>
                 {
                     policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                     //policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                 });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithRedirects("/error/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
