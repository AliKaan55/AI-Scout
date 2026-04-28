using AIScoutProject.AIScout.Business.Abstract;
using AIScoutProject.AIScout.Business.Concrete;
using AIScoutProject.AIScout.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný Ayarý
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Business Servisleri
builder.Services.AddHttpClient<IScoutService, ScoutManager>();

// 3. CORS AYARI (Hata aldýðýn yer burasý!)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. CORS'U ETKÝNLEÞTÝR (Sýralama çok önemli!)
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Render'da HTTPS yönlendirmesi bazen sorun çýkarabilir, 
// ücretsiz planlarda bazen kapatmak daha garantidir ama þimdilik kalsýn.
app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();