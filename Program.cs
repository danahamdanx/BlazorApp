using ElectricMeterApp.Models;
using ElectricMeterApp.Services;
using ElectricMeterApp.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register custom services
builder.Services.AddScoped<IElectricMeterService, ElectricMeterService>();
builder.Services.AddScoped<IValidator<MeterQueryRequest>, MeterQueryRequestValidator>();
// Register local storage service
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<ElectricMeterApp.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();