using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using SklepKomputerowy.CMS.Services;
using SklepKomputerowy.Data.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace SklepKomputerowy.CMS
{
    public class Startup
    {
        private readonly IWebHostEnvironment  _webHostEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {

            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<SklepKomputerowyContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("SklepKomputerowyContext")));
            services.Configure<RequestLocalizationOptions>(
            options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: "pl-PL", uiCulture: "pl-PL");
            });
            services.AddDirectoryBrowser();
            IFileProvider physicalProvider = new PhysicalFileProvider(@"D:/Users/Micha³ Jaœkiewicz/Desktop/Praktyki projekt/sklepKomputerowy");
            var embeddedProvider = new EmbeddedFileProvider(Assembly.GetEntryAssembly());
            var compositeProvider = new CompositeFileProvider(physicalProvider, embeddedProvider);
            // choose one provider to use for the app and register it
            services.AddSingleton<IFileProvider>(compositeProvider);
            services.AddRazorPages();
            services.AddTransient<FilterZamowienieServices>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), @"..\DataFiles\")),
                RequestPath = "/DataFiles"
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), @"..\DataFiles\")),
                RequestPath = new PathString("/DataFiles")
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
