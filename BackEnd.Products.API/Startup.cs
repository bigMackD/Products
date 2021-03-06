using System.Collections.Generic;
using BackEnd.Products.Contracts.Models.Products;
using BackEnd.Products.Contracts.Request.Command.Products;
using BackEnd.Products.Contracts.Request.Products;
using BackEnd.Products.Contracts.Response.Products;
using BackEnd.Products.DAL.Repositories.Products;
using BackEnd.Products.Infrastructure.CommandHandlers.Products;
using BackEnd.Products.Infrastructure.QueryHandlers.Products;
using BackEnd.Products.Shared.DAL.Repositories.Product;
using BackEnd.Products.Shared.Infrastructure.CommandHandlers;
using BackEnd.Products.Shared.Infrastructure.QueryHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Products.Api
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "AngularOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));
            services.AddSingleton<IProductsRepository, ProductsRepository>();
            services
                .AddSingleton<IQueryHandler<GetProductListQuery, GetProductListResponse, IEnumerable<ProductModel>>,
                    GetProductListQueryHandler>();
            services
                .AddSingleton<IQueryHandler<GetProductQuery, GetProductResponse, ProductModel>, GetProductQueryHandler>();
            services
                .AddSingleton<ICommandHandler<UpdateProductCommand, UpdateProductResponse>,
                    UpdateProductCommandHandler>();
            services
                .AddSingleton<ICommandHandler<DeleteProductCommand, DeleteProductResponse>, DeleteProductCommandHandler>();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "My API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API"); });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}