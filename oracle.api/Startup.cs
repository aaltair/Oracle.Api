using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using oracle.api.Dtos.JWT;
using oracle.api.Entities.User;
using oracle.api.Infrastructure.Contexts;
using oracle.api.Services.Mapper;

namespace oracle.api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation();
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseOracle(Configuration.GetConnectionString("orcConnection"));
            });
      

            services.Scan(scan =>
                scan.FromCallingAssembly()
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithScopedLifetime() );          

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = Boolean.Parse(Configuration.GetSection("IdentityConfiguration").GetSection("RequireDigit").Value);
                    options.Password.RequireLowercase = Boolean.Parse(Configuration.GetSection("IdentityConfiguration").GetSection("RequireLowercase").Value);
                    options.Password.RequireUppercase = Boolean.Parse(Configuration.GetSection("IdentityConfiguration").GetSection("RequireUppercase").Value);
                    options.Password.RequireNonAlphanumeric = Boolean.Parse(Configuration.GetSection("IdentityConfiguration").GetSection("RequireNonAlphanumeric").Value);
                    options.Password.RequiredLength = int.Parse(Configuration.GetSection("IdentityConfiguration").GetSection("RequiredLength").Value);
                })
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            var optionsw = new JwtOptions();
            var section = Configuration.GetSection("jwt");
            section.Bind(optionsw);
            services.Configure<JwtOptions>(section);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })

                .AddJwtBearer( cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = optionsw.Audience,
                        ValidIssuer = optionsw.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(optionsw.SecretKey))
                    };
                });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //    if (env.IsDevelopment())
            //    {
            //        //app.UseDeveloperExceptionPage();
            //    }
            //    else
            //    {
            //        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //        app.UseHsts();
            //    }

            app.UseExceptionHandler(builder =>
            {
                builder.Run(ReqDelegate);
            });
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
        private static async Task ReqDelegate(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {


                var ex = error.Error;


                var errorId = Activity.Current?.Id ?? context.TraceIdentifier;
                var jsonResponse = JsonConvert.SerializeObject(new
                {
                    ErrorId = errorId,
                    Message = error.Error.Message ?? "error happened."
                });

                await context.Response.WriteAsync(jsonResponse, Encoding.UTF8);
            }

        }


    }

}
