using Microsoft.EntityFrameworkCore;
using ShoxShop.Data;
using ShoxShop.Data.Seed;
using ShoxShop.UnitOfWork;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbConext
var connString=builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(
    options=>options.UseSqlite(connString)
);

// Add UnitOfWork
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

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
Seed.Init(app);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
