using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShoxShop.Data;
using ShoxShop.Data.Seed;
using ShoxShop.Services.Admin;
using ShoxShop.Services.Vendor;
using ShoxShop.Services.Category;
using ShoxShop.UnitOfWork;
using ShoxShop.Services.SubCategory;
using ShoxShop.Services.JWT;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(
    c=>c.SwaggerDoc("v1",new OpenApiInfo{Title="Aspnet Core Api", Version="v1"})
);
// Add Auhentication JWT token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option=>{
    option.TokenValidationParameters=new TokenValidationParameters{
        ValidateAudience=true,
        ValidateIssuer=true,
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,
        ValidIssuer=builder.Configuration["Jwt:Issuer"],
        ValidAudience=builder.Configuration["Jwt:Audience"],
        ClockSkew=TimeSpan.Zero,
        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    }; 
});
builder.Services.AddAuthorization();


//' Add DbConext
var connString=builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(
    options=>options.UseSqlite(connString)
);

// Add UnitOfWork
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

// Add Services
builder.Services.AddScoped<IJWTService,JWTService>();
builder.Services.AddScoped<IAdminService,AdminService>();
builder.Services.AddScoped<IVendorService,VendorService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ISubCategoryService,SubCategoryService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
Seed.Init(app);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
