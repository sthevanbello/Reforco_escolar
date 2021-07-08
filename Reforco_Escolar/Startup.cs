using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reforco_Escolar.Areas.Identity;
using Reforco_Escolar.Context;
using Reforco_Escolar.Data;
using Reforco_Escolar.Repositories;
using Reforco_Escolar.Services;
using System;
using Microsoft.AspNetCore.Authentication;

namespace Reforco_Escolar
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
            services.AddSession();

            #region SQLServer Default Identity

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
                .AddErrorDescriber<IdentityErrorDescriberPtBr>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            
            #endregion


            services.AddControllersWithViews();

            #region SQLServer

            string connectionString = Configuration.GetConnectionString("SQLServer");

            services.AddDbContext<ApplicationContext>(options =>

            options.UseSqlServer(connectionString)

            );

            #endregion

            // Cria a instância de DataService
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IClienteRepository, ClienteRepository>(); // Instância de ClienteRepository


            services.AddAuthentication()
                .AddMicrosoftAccount(options =>
                {
                    options.ClientId = Configuration["ExternalLogin:Microsoft:ClientId"];
                    options.ClientSecret = Configuration["ExternalLogin:Microsoft:ClientSecret"];
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Cria o banco caso não haja banco existente
            serviceProvider.GetService<IDataService>().InicializaDB();

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Basic}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
