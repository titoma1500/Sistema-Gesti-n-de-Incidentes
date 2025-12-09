using Proyecto.Components;
using Microsoft.EntityFrameworkCore;
using Proyecto.Infrastructure.Data;
using Proyecto.Application.Interfaces;
using Proyecto.Application.Services;
using Proyecto.Infrastructure.Repositories;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Proyecto.Infrastructure.Hubs;
using Proyecto.Infrastructure.Handlers;
using Proyecto.Infrastructure.Services;

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
            
            // Agregar SignalR para notificaciones en tiempo real
            builder.Services.AddSignalR();
            
            // Configurar opciones de circuito
            builder.Services.Configure<Microsoft.AspNetCore.Components.Server.CircuitOptions>(options =>
            {
                options.DetailedErrors = true;
                options.DisconnectedCircuitMaxRetained = 100;
                options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
                options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
                options.MaxBufferedUnacknowledgedRenderBatches = 10;
            });
            
            // Configurar logging detallado
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            // Agregar CircuitHandler para debugging y manejo de sesión
            builder.Services.AddScoped<CircuitHandler, LoggingCircuitHandler>();
            builder.Services.AddScoped<CircuitIdProvider>();
            builder.Services.AddScoped<CircuitHandler>(sp => sp.GetRequiredService<CircuitIdProvider>());

            // Configurar DbContext con SQL Server
            Console.WriteLine("[STARTUP] Configurando DbContext...");
            try
            {
                var connString = builder.Configuration.GetConnectionString("DefaultConnection");
                Console.WriteLine($"[STARTUP] Connection String: {connString}");
                
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connString, b => b.MigrationsAssembly("Proyecto"))
                           .EnableSensitiveDataLogging()
                           .EnableDetailedErrors());
                
                Console.WriteLine("[STARTUP] DbContext configurado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[STARTUP ERROR] Error configurando DbContext: {ex.Message}");
                Console.WriteLine($"[STARTUP ERROR] StackTrace: {ex.StackTrace}");
                throw;
            }

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
            builder.Services.AddSingleton<INotificacionService, NotificacionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Logging middleware para capturar todas las excepciones
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[MIDDLEWARE ERROR] {ex.GetType().Name}: {ex.Message}");
                    Console.WriteLine($"[MIDDLEWARE ERROR] StackTrace: {ex.StackTrace}");
                    throw;
                }
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            // Logging para endpoints de Blazor
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/_blazor"))
                {
                    Console.WriteLine($"[BLAZOR ENDPOINT] {context.Request.Method} {context.Request.Path}");
                }
                await next();
            });

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Mapear el Hub de SignalR para notificaciones
            app.MapHub<NotificacionHub>("/notificacionhub");

            Console.WriteLine("[STARTUP] Configuración completada. Aplicación lista.");
            
            app.Run();
        }
    }
}
