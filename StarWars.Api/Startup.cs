using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StarWars.Api.Models;
using StarWars.Core.Data;
using StarWars.Core.Logic;
using StarWars.Data.EntityFramework;
using StarWars.Data.EntityFramework.Repositories;
using StarWars.Data.EntityFramework.Seed;

namespace StarWars
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Env = env;
        }

        public IConfigurationRoot Configuration { get; }
        private IHostingEnvironment Env { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(Startup));

            InjectDataService(services);
            InjectGraphQLSchema(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                        ILoggerFactory loggerFactory, StarWarsContext db)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug();
            }

            app.UseMvc();
            app.UseStaticFiles();

            db.EnsureSeedData();
        }

        private void InjectDataService(IServiceCollection services)
        {
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<IDroidRepository, DroidRepository>();
            services.AddTransient<IHumanRepository, HumanRepository>();
            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddDbContext<StarWarsContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:StarWarsDatabaseConnection"])
            );
        }
        private void InjectGraphQLSchema(IServiceCollection services)
        {
            services.AddScoped<StarWarsQuery>(); 
            services.AddScoped<StarWarsMutation>(); 
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<ITrilogyHeroes, TrilogyHeroes>();
            services.AddTransient<DroidType>();
            services.AddTransient<HumanType>();
            services.AddTransient<CharacterInterface>();
            services.AddTransient<EpisodeEnum>();

            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new StarWarsSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<StarWarsQuery>(), Mutation = sp.GetService<StarWarsMutation>() });

        }


    }
}
