using Company.BL.Services.Abstractions;
using Company.BL.Services.Implementations;
using Company.DAL.DAL;
using Company.DAL.Repositories.Abstractions;
using Company.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});


builder.Services.AddScoped<IDepartmentRepository, DepartrmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
