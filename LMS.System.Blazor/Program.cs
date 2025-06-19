using LMS.System.Blazor.Components;
using LMS.System.Domain.Services.DBServices.DBContext;
using LMS.System.Migrations.MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("LMS_Main")
    ?? throw new InvalidOperationException("Строка подключения 'LMS_Main' не найдена в конфигурации.");

builder.Services.AddDbContext<ApplicationContext>(builder => builder
.UseSqlServer(connection, op => op.MigrationsAssembly(typeof(AppDbContextFactory).Assembly)));

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
