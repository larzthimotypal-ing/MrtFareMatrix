using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using app.repository;
using app.ui.Areas.Identity.Service;
using app.ui.Areas.Identity.Data;
using app.ui.Areas.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(app.ui.Areas.Identity.IdentityStartup))]
namespace app.ui.Areas.Identity
{
    public class IdentityStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("DefaultConnection")))
                .AddDbContext<UserIdentityDbContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddIdentity<AppUser, IdentityRole>(config =>
                {
                    //configuring password
                    config.Password.RequiredLength = 6;
                    config.Password.RequireDigit = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.SignIn.RequireConfirmedEmail = true;
                })
               .AddEntityFrameworkStores<UserIdentityDbContext>()
               .AddDefaultTokenProviders()
               .AddClaimsPrincipalFactory<MyUserClaimsPrincipalFactory>();

                services.ConfigureApplicationCookie(config =>
                {
                    config.Cookie.Name = "Identity.Cookie";
                    config.LoginPath = "/Identity/Authenticate/Login";
                });

                services.AddAuthorization(config =>
                {
                    config.AddPolicy("BasicAccess", policyBuilder =>
                    {
                        policyBuilder.RequireClaim("AccessLevel");
                    });
                    config.AddPolicy("ClientAccess", policyBuilder =>
                    {
                         policyBuilder.RequireClaim("AccessLevel", "Client");
                    });
                    config.AddPolicy("AdminAccess", policyBuilder =>
                    {
                        policyBuilder.RequireClaim("AccessLevel", "Admin");
                    });
                });

                services.AddHttpContextAccessor();

                services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, MyUserClaimsPrincipalFactory>();
                services.AddScoped<IIdentityService, IdentityService>();
                services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
                
                
            });

        }
    }
}
