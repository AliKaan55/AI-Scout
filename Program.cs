using AIScoutProject.AIScout.Business.Abstract;
using AIScoutProject.AIScout.Business.Concrete;
using AIScoutProject.AIScout.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient<IScoutService, ScoutManager>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles(); // index.html'i otomatik ana sayfa yapar
app.UseStaticFiles();  // wwwroot içindeki dosyalarýn okunmasýný saðlar

app.UseAuthorization();

app.MapControllers();

app.Run();
