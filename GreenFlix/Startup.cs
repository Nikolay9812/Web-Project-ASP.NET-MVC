namespace GreenFlix
{
    using GreenFlix.Data;
    using GreenFlix.Data.Models;
    using GreenFlix.Infrastructure;
    using GreenFlix.Services.Movies;
    using GreenFlix.Services.Provaiders;
    using GreenFlix.Services.Statistics;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GreenFlixDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                //ot tyk mojem da configurirame identity user,v sluchaq burnikame po usloviqta na nashata parola
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<GreenFlixDbContext>();

            services.AddControllersWithViews(options => 
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                //tazi opciq q vkarvame za da zashtetim app si ot cross-site atack
                //toest ako nqkoi se opita da izstrie avtomatchno generiraniqt kluch ot asp.net
                //na nasha post zaqvka kato (Add/Login/Register etc...) shte ni zashteti i shte hvurli greshka
                //tazi opcia se slaga pri pravene na web prilojenie s formi,naprimer web api nqma nyjda
                //ot tazi opcia poneje tam rabotim s jasoni ,suotvetno ne trqbva tova neshto
                //tozi atribut e globalen za appa
            });

            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IProvaiderService, ProvaiderService>();
            services.AddTransient<IStatisticsService, StatisticsService>();
            //tyk registrirame services,za da budat polzvani
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                });

        }
    }
}
