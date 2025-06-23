using System.Text;
using LMS.System.Blazor.Components;
using LMS.System.Domain.Services.Auth;
using LMS.System.Domain.Services.DBServices.DBContext;
using LMS.System.Migrations.MSSQL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Конфигурация JWT (из appsettings.json)
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

// Регистрация JWT-сервисов
builder.Services.Configure<JwtSettings>(jwtSettings);
builder.Services.AddScoped<IJwtService, JwtService>();

// Настройка аутентификации
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
    };
});

// Настройка авторизации с ролями
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Student", policy => policy.RequireRole("Student"));
    options.AddPolicy("Teacher", policy => policy.RequireRole("Teacher"));
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

// Подключение БД
string connection = builder.Configuration.GetConnectionString("LMS_Main")
    ?? throw new InvalidOperationException("Строка подключения 'LMS_Main' не найдена в конфигурации.");

builder.Services.AddDbContext<ApplicationContext>(builder => builder
    .UseSqlServer(connection, op => op.MigrationsAssembly(typeof(AppDbContextFactory).Assembly)));

// MudBlazor
builder.Services.AddMudServices();

// Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Применение миграций
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    context.Database.Migrate();
}

// Конвейер middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
