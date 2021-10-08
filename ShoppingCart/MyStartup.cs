using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchoolOf.Data.Abstractions;
using ShoppingCart.Common.Database;
using ShoppingCart.Data;
using ShoppingCart.Mappers;
using MediatR;
using ShoppingCart.Application.Query.Handlers;
using ShoppingCart.Application.Behaviour;

namespace ShoppingCart
{
    public class MyStartup
    {
        public MyStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddControllers(); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShoppingCart", Version = "v1" });
            });

            // settings
            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));

            // mappers
            services.AddAutoMapper(typeof(BaseProfile).Assembly);

            // mediatr
            services.AddMediatR(typeof(GetProductsHandler).Assembly);

            // mediatr behaviours
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            // db registration
            services.AddScoped<DatabaseContext>(); 
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingCart v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
