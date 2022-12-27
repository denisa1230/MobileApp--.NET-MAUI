using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectContext") ?? throw new InvalidOperationException("Connection string 'ProiectContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectContext") ?? throw new InvalidOperationException("Connection string 'ProiectContext' not found.")));


builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Buses");
    options.Conventions.AllowAnonymousToPage("/Buses/Index");
    options.Conventions.AllowAnonymousToPage("/Buses/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
