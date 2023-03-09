using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Blog.Areas.Identity.Data;
using Blog.Interfaces;
using Blog.Services;
using Blog.Models;
using Blog.Mapping;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BlogDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BlogDbContextConnection' not found.");

builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<BlogUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<BlogDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddScoped<IMapper<Blog.Entities.BlogPost, BlogPostModel>, BlogPostMapper>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
