using Army.Core.DAL;
using AutoMapper;
using Meshini.Core.BLL.Domains;
using Meshini.Core.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArmyTechTask
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
            services.AddDbContext<ArmyTechContext>(ww =>
            { ww.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); });

           
            services.AddSession();

            MapperConfiguration mapperConfig = new(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            services.AddAutoMapper(typeof(Startup));


            DIServices(services);
           

            services.AddControllersWithViews();
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
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}",
                    defaults: new {  controller = "Home", action = "Index" }
                );
            });
        }

        private void DIServices(IServiceCollection services)
        {
            #region DI
            services.AddScoped<CardProductRepository>();
            services.AddScoped<CardProductDomain>();
            #endregion
        }





    }
}
