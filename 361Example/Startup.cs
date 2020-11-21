using _361Example.Accessors;
using _361Example.Engines;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _361Example
{
    /**
     * This class is used when the web application starts to configure the services
     * and HTTP request pipeline of the web app.
     **/
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime to add to the program's services
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();


            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddTransient<IGListEngine, GListEngine>();
            services.AddTransient<IGListAccessor, GListAccessor>();

            services.AddTransient<IItemAccessor, ItemsAccessor>();
            services.AddTransient<IItemsEngine, ItemsEngine>();

            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<IUserEngine, UserEngine>();

        }

        // This method gets called by the runtime to determine the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            app.UseCors("CorePolicy");
        }
    }
}
