using Microsoft.EntityFrameworkCore;
using WorldAPI.Common;
using WorldAPI.Data;
using WorldAPI.Repositery;
using WorldAPI.Repositery.IRepositery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region configure CORS
builder.Services.AddCors( options =>
{
    options.AddPolicy("custom", o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion

#region configure Db
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
#endregion

#region
builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion
builder.Services.AddControllers();

#region
builder.Services.AddTransient<ICountryRepositery, CountryRepositery>();
builder.Services.AddTransient<IStateRepositery, StateRepositery>();
#endregion
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

app.UseCors("custom");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
