using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Tenats;
using Infrastructure.Announcements;
using Infrastructure.Polls;
using Infrastructure.Meetings;
using Infrastructure.Tenats;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ServiceForWorkingWithApartmentBuilding.Extensions;
using ServiceForWorkingWithApartmentBuilding.Hubs;

namespace ServiceForWorkingWithApartmentBuilding
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
            services.AddSignalR();

            var connectionString = Configuration.GetConnectionString("ServiceForWorkingWithApartmentBuilding");

            #region Tenat

            services.AddNpgsqlDbContext<Infrastructure.Tenats.TenantDbContext>(connectionString);
            services.AddNpgsqlDbContext<Infrastructure.Tenats.BuildingDbContext>(connectionString);

            services.AddScoped<Domain.Tenats.ITenantRepository, Infrastructure.Tenats.TenantRepository>();
            services.AddScoped<Domain.Tenats.IBuildingService, Infrastructure.Tenats.BuildingService>();
            services.AddScoped<Domain.Tenats.TenantManager>();
            services.AddScoped<Infrastructure.Tenats.Query.GetProfileViewByName>();
            services.AddScoped<Infrastructure.Tenats.Query.GetProfileViewById>();
            services.AddScoped<Infrastructure.Tenats.Query.GetListAddress>();

            #endregion

            #region Announcement

            services.AddNpgsqlDbContext<AnnouncementDbContext>(connectionString);
            services.AddNpgsqlDbContext<Infrastructure.Announcements.TenantDbContext>(connectionString);

            services.AddScoped<Domain.Announcements.IAnnouncementRepository, Infrastructure.Announcements.AnnouncementRepository>();
            services.AddScoped<Domain.Announcements.AnnouncementManager>();
            services.AddScoped<Infrastructure.Announcements.Query.GetListAnnouncement>();
            services.AddScoped<Domain.Announcements.ITenantService, 
                Infrastructure.Announcements.TenantService>();

            #endregion

            #region Poll

            services.AddNpgsqlDbContext<Infrastructure.Polls.PollDbContext>(connectionString);
            services.AddNpgsqlDbContext<Infrastructure.Polls.TenantDbContext>(connectionString);

            services.AddScoped<Domain.Polls.IPollRepository, Infrastructure.Polls.PollRepository>();
            services.AddScoped<Domain.Polls.ITenantService, Infrastructure.Polls.TenantService>();
            services.AddScoped<Domain.Polls.PollManager>();
            services.AddScoped<Infrastructure.Polls.Query.GetListPollForTenant>();
            services.AddScoped<Infrastructure.Polls.Query.GetListAnswerOption>();
            services.AddScoped<Infrastructure.Polls.Query.GetListPollForManagementCompany>();

            #endregion

            #region Meeting

            services.AddNpgsqlDbContext<MeetingDbContext>(connectionString);
            services.AddNpgsqlDbContext<Infrastructure.Meetings.BuildingDbContext>(connectionString);

            services.AddScoped<Domain.Meetings.IMeetingRepository, Infrastructure.Meetings.MeetingRepository>();
            services.AddScoped<Domain.Meetings.MeetingManager>();
            services.AddScoped<Domain.Meetings.IBuildingService, Infrastructure.Meetings.BuildingService>();

            #endregion

            #region ManagementCompany

            services.AddNpgsqlDbContext<Infrastructure.ManagementCompanies.ManagementCompanyDbContext>(connectionString);
            services.AddNpgsqlDbContext<Infrastructure.ManagementCompanies.MeetingDbContext>(connectionString);

            services.AddScoped<Domain.ManagementCompanies.IManagementCompanyRepository, Infrastructure.ManagementCompanies.ManagementCompanyRepository>();
            services.AddScoped<Infrastructure.ManagementCompanies.Query.GetManagementCompanyProfileViewByName>();
            services.AddScoped<Infrastructure.ManagementCompanies.Query.GetManagementCompanyProfileViewById>();
            services.AddScoped<Domain.ManagementCompanies.IMeetingService, 
                Infrastructure.ManagementCompanies.MeetingService>();

            #endregion

            #region Building

            services.AddNpgsqlDbContext<Infrastructure.Buildings.BuildingDbContext>(connectionString);

            services.AddScoped<Domain.Buildings.IBuildingRepository, Infrastructure.Buildings.BuildingRepository>();
            services.AddScoped<Infrastructure.Buildings.Query.GetListBuilding>();

            #endregion

            services.AddSwagger();

            //services.AddAuthentication()
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            //    });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ContosoChatHub>("/ChatHub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRewriter(new RewriteOptions().AddRedirect(@"^$", "swagger", (int)HttpStatusCode.Redirect));
        }
    }
}
