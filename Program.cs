using Proyecto.Components;
using Microsoft.EntityFrameworkCore;
using Proyecto.Infrastructure.Data;
using Proyecto.Application.Interfaces;
using Proyecto.Application.Services;
using Proyecto.Infrastructure.Repositories;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Proyecto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Configurar DbContext con SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Proyecto")));

            // Registrar repositorios
            builder.Services.AddScoped<IIncidenteRepository, IncidenteRepository>();
            builder.Services.AddScoped<IBaseConocimientoRepository, BaseConocimientoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Registrar servicios de infraestructura
            builder.Services.AddScoped<Infrastructure.Services.IEmailService, Infrastructure.Services.EmailService>();

            // Registrar servicios de aplicación
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<IIncidenteService, IncidenteService>();
            builder.Services.AddScoped<IBaseConocimientoService, BaseConocimientoService>();
            builder.Services.AddScoped<IEtiquetaService, EtiquetaService>();
            builder.Services.AddScoped<Application.Interfaces.IEmailService, EmailServiceAdapter>();
            
            // Configurar circuit handler para mantener el estado
            builder.Services.AddScoped<CircuitHandler, CircuitHandlerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
