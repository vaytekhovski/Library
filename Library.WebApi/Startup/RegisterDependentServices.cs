using System;
using System.Reflection;
using Library.App;
using Library.App.Common.Mapping;
using Library.App.Interfaces;
using Library.Persistence;

namespace Library.WebApi.Startup
{
    public static class RegisterDependentServices { 

        public static IConfiguration? Configuration { get; }

        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            //builder.Services.Add
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IAuthorDbContext).Assembly));
            });

            builder.Services.AddApplication();
            builder.Services.AddPersistence(Configuration);
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            return builder;
        }
    }
}

