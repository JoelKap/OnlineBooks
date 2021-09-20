using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.DataAccess.DTO;
using OnlineBooks.DataAccess.Implementations;
using OnlineBooks.Service.Contracts;
using OnlineBooks.Service.Implementation;
using System;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooks.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineBooks.Api", Version = "v1" });
            });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<OnlineBooksContext>(options => options.UseSqlServer(
                    this.Configuration.GetConnectionString("OnlineBooksConnection"), sql =>
                    {
                        sql.EnableRetryOnFailure();
                        sql.UseRelationalNulls();
                        sql.CommandTimeout(1000);
                    }));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x=>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var email = context.Principal.Identity.Name;
                        var user = userService.GetUserByEmail(email);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };

                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JwtConfig:secret"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            this.bootstrap(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineBooks.Api v1"));
            }

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private void bootstrap(IServiceCollection services)
        {
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDataAccess, UserDataAccess>(); 
            services.AddScoped<IBookDataAccess, BookDataAccess>();
            services.AddScoped<IBookService, BookService>(); 
            services.AddScoped<ICatalogueDataAccess, CatalogueDataAccess>();
            services.AddScoped<ICatalogueService, CatalogueService>(); 
            services.AddScoped<IOnlineUserTypeService, OnlineUserTypeService>();
            services.AddScoped<IOnlineUserTypeDataAccess, OnlineUserTypeDataAccess>();
            services.AddScoped<ISubscriptionDataAccess, SubscriptionDataAccess>(); 
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IUnsubscribeDataAccess, UnsubscribeDataAccess>();
            services.AddScoped<IUnsubscribeService, UnsubscribeService>(); 
            services.AddScoped<IBookCatalogueDataAccess, BookCatalogueDataAccess>();
            services.AddScoped<IBookCatalogueService, BookCatalogueService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthDataAccess, AuthDataAccess>();
        }
    }
}
