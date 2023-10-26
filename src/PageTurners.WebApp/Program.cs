using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PageTurners.Core.Context;
using PageTurners.Core.Entities;
using PageTurners.Repositories.Interfaces;
using PageTurners.Repositories.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PageTurnersContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;
    }).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PageTurnersContext>();

/*builder.Services.AddScoped<UserManager<User>>();*/
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookRequestRepository, BookRequestRepository>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "bookManagement",
    pattern: "book/manage/{action=Index}/{id?}",
    defaults: new { controller = "BookManagement" }
);

app.MapControllerRoute(
    name: "bookEdit",
    pattern: "Book/Edit/{id?}",
    defaults: new { controller = "Book", action = "Edit" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "bookRequestCreate",
    pattern: "BookRequest/Create",
    defaults: new { controller = "BookRequest", action = "Create" }
);

app.MapRazorPages();

app.Run();
