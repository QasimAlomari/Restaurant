using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.UnitWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(services => services.EnableEndpointRouting = false);
            services.AddScoped<IRepository<MasterCategoryMenu>, DbMasterCategoryMenuRepository>();
            services.AddScoped<IRepository<MasterContactUsInformation>, DbMasterContactUsInformationRepository>();
            services.AddScoped<IRepository<MasterItemMenu>, DbMasterItemMenuRepository>();
            services.AddScoped<IRepository<MasterMenu>, DbMasterMenuRepository>();
            services.AddScoped<IRepository<MasterOffer>, DbMasterOfferRepository>();
            services.AddScoped<IRepository<MasterPartner>, DbMasterPartnerRepository>();
            services.AddScoped<IRepository<MasterService>, DbMasterServiceRepository>();
            services.AddScoped<IRepository<MasterSlider>, DbMasterSliderRepository>();
            services.AddScoped<IRepository<MasterSocialMedia>, DbMasterSocialMediaRepository>();
            services.AddScoped<IRepository<MasterWorkingHour>, DbMasterWorkingHourRepository>();
            services.AddScoped<IRepository<SystemSetting>, DbSystemSettingRepository>();
            services.AddScoped<IRepository<TransactionBookTable>, DbTransactionBookTableRepository>();
            services.AddScoped<IRepository<TransactionContactUs>, DbTransactionContactUsRepository>();
            services.AddScoped<IRepository<TransactionNewsletter>, DbTransactionNewsletterRepository>();
            services.AddScoped<IRepository<MasterAbout>, DbMasterAboutRepository>();
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Admin/Account/Login";
            });
            services.AddDbContext<AppDbContext>(DbContext =>
            {
                DbContext.UseSqlServer(Configuration.GetConnectionString("SqlConn"));
            });
            services.Configure<IdentityOptions>(passwordConfig =>
            {
                passwordConfig.Password.RequireDigit = false;
                passwordConfig.Password.RequireLowercase = false;
                passwordConfig.Password.RequireUppercase = false;
                passwordConfig.Password.RequireNonAlphanumeric = false;
                passwordConfig.Password.RequiredUniqueChars = 0;
                passwordConfig.Password.RequiredLength = 3;

            });


            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvc();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(app =>
            {

                app.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
                        );

                app.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                        );

            });

        }
    }
}


