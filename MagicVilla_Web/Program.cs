using MagicVilla_Web.Extensions;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(u=>u.Filters.Add(new AuthExceptionRedirection()));

builder.Services.AddHttpClient<IVillaService, VillaService>();
builder.Services.AddHttpClient<IVillaNumberService, VillaNumberService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IVillaService, VillaService>();
builder.Services.AddScoped<IVillaNumberService, VillaNumberService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

builder.Services.AddSingleton<IApiMessageRequestBuilder, ApiMessageRequestBuilder>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(op =>
{
    op.IdleTimeout = TimeSpan.FromMinutes(100);
    op.Cookie.HttpOnly = true;
    op.Cookie.IsEssential= true;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(op =>
    {
        op.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        op.LoginPath = "/Auth/Login";
        op.AccessDeniedPath = "/Auth/AccessDenied";
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
