using MagnetApi.DB;
using MagnetApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DBConnection>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MyConnection"),
                     new MySqlServerVersion(new Version(8, 0, 26))));
builder.Services.AddScoped<IUserService, UserService>(); // Register IUserService>

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
        Title = "Magnet API",
        Version = "v1",
        Description = "Magnet API"
        });
    // Konfiguracja schematu autoryzacji JWT
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "WprowadŸ token JWT w formacie: Bearer <token>"
        });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("https://localhost:4200") // Zast¹p `example.com` swoj¹ domen¹
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Odczyt ustawieñ JWT z konfiguracji
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

// Konfiguracja uwierzytelniania JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
        {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
        };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin")); // Polityka dla roli Admin
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
    app.UseSwagger();
    app.UseSwaggerUI();
    }

app.UseCors("AllowSpecificOrigins"); // Mo¿esz zmieniæ na "AllowAllOrigins" w zale¿noœci od potrzeb
app.UseHttpsRedirection();
app.UseAuthentication(); // Dodaj przed Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
