namespace GreenFlix.Infrastructure
{
    using GreenFlix.Data;
    using GreenFlix.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static WebConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);
            SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<GreenFlixDbContext>();

            data.Database.Migrate();

        }

        public static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<GreenFlixDbContext>();

            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category {Name="Action"},
                new Category {Name="Adult"},
                new Category {Name="Adventure"},
                new Category {Name="Animation"},
                new Category {Name="Biography"},
                new Category {Name="Comedy"},
                new Category {Name="Crime"},
                new Category {Name="Documentary"},
                new Category {Name="Drama"},
                new Category {Name="Family"},
                new Category {Name="Fantasy"},
                new Category {Name="Film-Noir"},
                new Category {Name="Game-Show"},
                new Category {Name="History"},
                new Category {Name="Horror"},
                new Category {Name="Musical"},
                new Category {Name="Music"},
                new Category {Name="Mystery"},
                new Category {Name="News"},
                new Category {Name="Reality-TV"},
                new Category {Name="Romance"},
                new Category {Name="Sci-Fi"},
                new Category {Name="Short"},
                new Category {Name="Sport"},
                new Category {Name="Talk-Show"},
                new Category {Name="Thriller"},
                new Category {Name="War"},
                new Category {Name="Western"},
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManeger = services.GetRequiredService<UserManager<User>>();
            var roleManeger = services.GetRequiredService<RoleManager<IdentityRole>>();

            //tova bukvalno oznachava runni vsichkoto ei tova neshto i go izchakai
            //izchakai rezultata ot ei tiq zadachi vutre
            Task
                .Run(async () =>
                {
                    if (await roleManeger.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }
            
                    var role = new IdentityRole { Name = AdministratorRoleName };
            
                    await roleManeger.CreateAsync(role);

                    const string adminEmail = "admin@mvs.com";
                    const string adminPassword = "admin12";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FullName = "Admin"
                    };

                    await userManeger.CreateAsync(user,adminPassword);

                    await userManeger.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
            
        }
    }
}
