using DistrictWebapp.Data;
using DistrictWebapp.Repositories;
using DistrictWebapp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
    
    
    
    
    // API desteği

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<SeederService>();

//using (var scope = app.Services.CreateScope())
//{
//    var seeder = scope.ServiceProvider.GetRequiredService<SeederService>();
//    await seeder.SeedFromJsonAsync(); // otomatik çalıştır
//}
// ------------------> bura seederservice 'i otomatik çalıştırır tek seferde

//buraya ayrı bir klasör açıp taşımak en mantıklısı

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 💥 BU SATIRI EKLE → API Controller'ları aktif eder
app.MapControllers();

// Mevcut MVC controller route'u
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CityMvc}/{action=Index}/{id?}");

app.Run();
