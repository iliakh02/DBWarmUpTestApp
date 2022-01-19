using DBWarmUpApp.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration["ConnectionStrings:BlogDatabase"];
builder.Services.AddDbContext<BlogDbContext>(options 
    => options.UseSqlServer(connectionString),
    ServiceLifetime.Singleton);

builder.Services.AddSingleton<IBlogRepository, BlogRepository>();

builder.Services.AddHealthChecks().AddDbContextCheck<BlogDbContext>(customTestQuery:
            (db, sddf) => 
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    var result = db.Blogs.Where(n => n.Id > 0).FirstOrDefault();
                    return Task.FromResult(result is not null);
                }
            );

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
});

app.Run();
