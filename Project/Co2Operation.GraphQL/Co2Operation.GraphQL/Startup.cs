using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using Co2Operation.GraphQL.Schema.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Co2Operation.GraphQL
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

             services.AddCors(options =>
             {
                 options.AddPolicy(name: MyAllowSpecificOrigins,
                     builder =>
                     {
                         builder.AllowAnyOrigin()
                             .WithMethods("PUT", "DELETE", "GET");
                         builder.AllowAnyHeader();
                     });
             });

             services.AddSingleton<ICarRepository>(sp =>
                 {
                     var context = new Co2DatabaseContext();
                     return new CarRepository(context);
                 })
                 .AddSingleton<IUserRepository>(sp =>
                 {
                     var context = new Co2DatabaseContext();
                     return new UserRepository(context);
                 })
                 .AddSingleton<ITripRepository>(sp =>
                 {
                     var context = new Co2DatabaseContext();
                     return new TripRepository(context);
                 })
                 .AddSingleton<ICarbonHistoryRepository>(sp =>
                 {
                     var context = new Co2DatabaseContext();
                     return new CarbonHistoryRepository(context);
                 })
                 .AddSingleton<ITransportMethodsRepository>(sp =>
                 {
                     var context = new Co2DatabaseContext();
                     return new TransportMethodsRepository(context);
                 });

            services.AddDataLoaderRegistry();

            services.AddDbContext<Co2DatabaseContext>();

            services.AddGraphQL(sp => 
                SchemaBuilder.New()
                .AddServices(sp)
                .AddQueryType<QueryType>()
                .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UsePlayground();
            }

            app.UseRouting()
                .UseWebSockets()
                .UseGraphQL()
                .UseGraphQLHttpPost(new HttpPostMiddlewareOptions {Path = "/graphql"})
                .UseGraphQLHttpGetSchema(new HttpGetSchemaMiddlewareOptions {Path = "/graphql/schema"});

            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
