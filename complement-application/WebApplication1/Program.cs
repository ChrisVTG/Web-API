using NToastNotify;
using WebApplication1.Configurations;
using WebApplicationPersistence.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSqlite<PcrContext>(builder.Configuration.GetConnectionString("PcrDatabase"));
builder.Services.AddAutoMapper(typeof(EditViewModelsAutoMapperConfigurations).Assembly);
builder.Services.AddMvc().AddNToastNotifyNoty(new NotyOptions {
    ProgressBar = true,
    Timeout = 5000,
    Theme = "mint"
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

app.UseAuthorization();

app.UseNToastNotify();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();