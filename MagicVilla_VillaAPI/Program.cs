using System;
using System.Text;
using MagicVilla_VillaAPI;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Extensions;
using MagicVilla_VillaAPI.Filters;
using MagicVilla_VillaAPI.Mappers;
using MagicVilla_VillaAPI.MiddleWares;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option =>
{
    option.Filters.Add<CustomFilterException>();
}).ConfigureApiBehaviorOptions(op =>
{
    op.ClientErrorMapping[StatusCodes.Status500InternalServerError] = new ClientErrorData()
    {
        Link = "https://Alnuaimi.com/500"
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddResponseCaching();

builder.Services.AddApiVersioning(option =>
{
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.DefaultApiVersion = new ApiVersion(1, 0);
    option.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(op =>
{
    op.GroupNameFormat = "'v'VVV";
    op.SubstituteApiVersionInUrl = true;
});
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<JwtOptions>()
    .BindConfiguration(JwtOptions.SectionName)
    .ValidateDataAnnotations()
    .ValidateOnStart();
var jwtSettings = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();
var assure= builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();
var audience= builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = assure!.Issuer,
            ValidateAudience = true,
            ValidAudience = audience!.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings!.SecretKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddDbContext<ApplicationDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringDb"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IVillaRepository, VillaRepository>();
builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(op
        =>
    {
        op.SwaggerEndpoint("/swagger/v2/swagger.json", "Magic_VillaV2");
        op.SwaggerEndpoint("/swagger/v1/swagger.json", "Magic_VillaV1");
        // op.InjectStylesheet("/swagger-ui/custom.css");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
//way to handle the error
//app.UseExceptionHandler("/ErrorHandling/ProcessError");
//another way to handle the error
//app.HandleError(app.Environment.IsDevelopment());
//another way to handle the error
app.UseMiddleware<CustomExceptionMiddleWare>();
app.MapControllers();
ApplyMigration();
app.Run();

 void ApplyMigration()
{
    using var scope = app!.Services.CreateScope();
    var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (_db.Database.GetPendingMigrations().Any())
    {
        _db.Database.Migrate();
    }
}