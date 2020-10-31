using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spinner.API.Extensions;
using Spinner.Application.Services.Behaviors;
using Spinner.Application.Services.ProdutoService.Mapping;
using Spinner.Application.Services.RelatorioService.DAO;
using Spinner.Domain.Common;
using Spinner.Domain.Entidades.NotaFiscal;
using Spinner.Domain.Entidades.Produto;
using Spinner.Infrastructure;
using Spinner.Infrastructure.DAOs;
using Spinner.Infrastructure.Repositories;
using System.Data;

namespace Spinner.API
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
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionEnabledRequestBehavior<,>));
            services.AddMediatR(typeof(TransactionEnabledRequestBehavior<,>));
            services.AddAutoMapper(typeof(ProdutoMapperProfile));
            services.AddScoped<IDbConnection>(sp => TempDbFactory.CreateConnection());
            services.AddScoped<INotaFiscalRepository, NotaFiscalRepositorySqlite>();
            services.AddScoped<IProdutoRepository, ProdutoRepositorySqlite>();
            services.AddScoped<IRelatorioDAO, RelatorioDAOSqlite>();
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDomainExceptionHandler();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spinner V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
