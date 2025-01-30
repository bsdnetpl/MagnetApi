using MagnetApi.DB;
using MagnetApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
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

builder.Services.AddDbContext<DBConnection>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MyConnection"),
                     new MySqlServerVersion(new Version(8, 0, 26))));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStanService, StanService>();
builder.Services.AddScoped<ISprzedazService, SprzedazService>();
builder.Services.AddScoped<IBazaFvService, BazaFvService>();
builder.Services.AddScoped<IDostawcaService, DostawcaService>();

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])),
        ClockSkew = TimeSpan.Zero // Wy³¹czenie domyœlnej tolerancji czasu
        };

    // Obs³uga b³êdów autoryzacji JWT
    options.Events = new JwtBearerEvents
        {
        OnAuthenticationFailed = context =>
        {
            context.NoResult();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(new
                {
                error = "Unauthorized",
                details = context.Exception.Message
                }.ToString());
        }
        };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin")); // Polityka dla roli Admin
});

// Konfiguracja CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Adres frontend-u Angular
              .AllowAnyHeader()                    // Pozwala na dowolne nag³ówki
              .AllowAnyMethod()                    // Pozwala na dowolne metody (GET, POST, etc.)
              .AllowCredentials();                 // Obs³uguje ciasteczka (jeœli u¿ywane)
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
    app.UseSwagger();
    app.UseSwaggerUI();
    }

// Obs³uga CORS
app.UseCors("AllowSpecificOrigins"); // Mo¿esz zmieniæ na "AllowAllOrigins" w zale¿noœci od potrzeb

app.UseHttpsRedirection();
app.UseAuthentication(); // Dodaj przed Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
