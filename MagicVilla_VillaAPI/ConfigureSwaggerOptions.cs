using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MagicVilla_VillaAPI
{
    public class ConfigureSwaggerOptions:IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;


        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    new List<string>()
                }
            });
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Version = description.ApiVersion.ToString(),
                    Title = $"Magic Villa {description.ApiVersion}",
                    Description = "API to manage villa. This version includes basic operations for managing villas.",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "DotNetAlnuaimi",
                        Url = new Uri("https://Alnuaimi.com"),
                        Email = "support@alnuaimi.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example Licence",
                        Url = new Uri("https://example.com/licence")
                    }
                });
            }
        }
    }
}
