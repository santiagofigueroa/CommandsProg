using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Commander.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Newtonsoft.Json.Serialization; 

namespace Commander
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
            // Dependency Injection
            // Added the connection string to our services. 
            /** We will create a migration using: 
            * " dotnet ef migrations add InitialMigration " command
            * The name of our migration is " InitialMigration " 
            * to remove migrations we need to do "ef migrations remove" command 
            */ 
            services.AddDbContext<CommanderContext> (opt => 
            opt.UseSqlServer(Configuration.GetConnectionString("CommanderConnection")));
           
            // Added for the JSON handler to be working properly.
            //services.AddControllers().AddNewtonsoftJson(
            //  s => s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            // Previous code could not PATCH JSON 
            // New format can but with and XML hander.
            services.AddControllers(s =>
                s.ReturnHttpNotAcceptable = true
                ).AddXmlDataContractSerializerFormatters().AddNewtonsoftJson(s =>
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            // TODO: Add automapper to prog.
            //
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
             services.AddScoped<ICommanderRepo,SqlCommanderRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipelin
        
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
