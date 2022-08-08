using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SocialMediaApp.Business.UserService;
using System.Collections;
using System.Text;

namespace SocialMediaApp.Configuration
{
    public static class StartupConfiguration
    {
        private static IConfiguration _config;
        public static void AddConfiguration(this IServiceCollection services)
        {
            #region Conf

            var securityScheme = new OpenApiSecurityScheme()
            {
                Name = "Authantication",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Auth deneme"
            };

            var securityReq = new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            };

            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = " JWT Authentication with Swagger demo",
                Description = "Implementing JWT Authentication ",
                TermsOfService = new Uri("http://www.example.com"),
            };

            #endregion

            ConfigurationManager conf = new ConfigurationManager();

            services.AddSwaggerGen(o =>
            {
                o.AddSecurityDefinition("Bearer", securityScheme);
                o.AddSecurityRequirement(securityReq);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<IUserService, UserService>();

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Environment.GetEnvironmentVariable("JWT:Issuer"),
                    ValidAudience = Environment.GetEnvironmentVariable("JWT:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT:Key"))), //builder.Configuration["JWT:Key"]
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthorization();
        }

    }
}
