# 👤 Persona 1: Backend & Base de Datos

## 📋 Tu Responsabilidad

Eres responsable de:
1. **Capa de Dominio** - Entidades y lógica core del negocio
2. **Capa de Infraestructura** - Acceso a datos y servicios externos
3. **Base de Datos** - Migraciones, configuraciones y datos iniciales
4. **Sistema de Notificaciones** - Envío de emails

## 📁 Tus Carpetas

```
src/Domain/          ← Trabajas aquí
src/Infrastructure/  ← Trabajas aquí
database/           ← Trabajas aquí
```

## ✅ Tareas Semana 1

### Parte 1: Domain/Entities (Prioridad Alta)

Crear las siguientes entidades:

#### 1. Usuario.cs
```csharp
namespace Proyecto.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public NivelUsuario Nivel { get; set; }
    public DateTime FechaRegistro { get; set; }
    public bool Activo { get; set; }
    
    // Navegación
    public ICollection<Incidente> IncidentesReportados { get; set; }
    public ICollection<Incidente> IncidentesAsignados { get; set; }
}
```

#### 2. Incidente.cs
```csharp
public class Incidente
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public EstadoIncidente Estado { get; set; }
    public PrioridadIncidente Prioridad { get; set; }
    
    // Relaciones
    public int UsuarioReportaId { get; set; }
    public Usuario UsuarioReporta { get; set; }
    
    public int? UsuarioAsignadoId { get; set; }
    public Usuario? UsuarioAsignado { get; set; }
    
    // Etiquetas (muchos a muchos)
    public ICollection<Etiqueta> Etiquetas { get; set; }
    
    // Fechas y solución
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaAsignacion { get; set; }
    public DateTime? FechaSolucion { get; set; }
    public string? MensajeSolucion { get; set; }
    public string? MensajeEscalamiento { get; set; }
}
```

#### 3. BaseConocimiento.cs
```csharp
public class BaseConocimiento
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Solucion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int VecesConsultada { get; set; }
    
    // Etiquetas para búsqueda
    public ICollection<Etiqueta> Etiquetas { get; set; }
}
```

#### 4. Etiqueta.cs
```csharp
public class Etiqueta
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public CategoriaEtiqueta Categoria { get; set; }
    
    // Navegación
    public ICollection<Incidente> Incidentes { get; set; }
    public ICollection<BaseConocimiento> ArticulosConocimiento { get; set; }
}
```

#### 5. Notificacion.cs
```csharp
public class Notificacion
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public string Asunto { get; set; }
    public string Mensaje { get; set; }
    public TipoNotificacion Tipo { get; set; }
    public DateTime FechaEnvio { get; set; }
    public bool Enviado { get; set; }
}
```

### Parte 2: Domain/Enums

#### NivelUsuario.cs
```csharp
public enum NivelUsuario
{
    UsuarioRegular = 1,
    SoporteBasico = 2,
    SoporteAvanzado = 3,
    Administrador = 4
}
```

#### EstadoIncidente.cs
```csharp
public enum EstadoIncidente
{
    Abierto = 1,
    Asignado = 2,
    EnProceso = 3,
    Resuelto = 4,
    Cerrado = 5
}
```

#### PrioridadIncidente.cs
```csharp
public enum PrioridadIncidente
{
    Baja = 1,
    Media = 2,
    Alta = 3,
    Critica = 4
}
```

#### CategoriaEtiqueta.cs
```csharp
public enum CategoriaEtiqueta
{
    Hardware = 1,
    Software = 2,
    Red = 3,
    SistemaOperativo = 4,
    Seguridad = 5,
    Otro = 6
}
```

#### TipoNotificacion.cs
```csharp
public enum TipoNotificacion
{
    IncidenteAsignado = 1,
    IncidenteEscalado = 2,
    IncidenteResuelto = 3
}
```

### Parte 3: Infrastructure/Data

#### ApplicationDbContext.cs
```csharp
using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Incidente> Incidentes { get; set; }
    public DbSet<BaseConocimiento> BaseConocimientos { get; set; }
    public DbSet<Etiqueta> Etiquetas { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuraciones Fluent API aquí
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
```

### Parte 4: Infrastructure/Repositories

Implementar repositorios para cada entidad:

```csharp
public class IncidenteRepository : IIncidenteRepository
{
    private readonly ApplicationDbContext _context;
    
    public IncidenteRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Incidente?> ObtenerPorIdAsync(int id)
    {
        return await _context.Incidentes
            .Include(i => i.UsuarioReporta)
            .Include(i => i.UsuarioAsignado)
            .Include(i => i.Etiquetas)
            .FirstOrDefaultAsync(i => i.Id == id);
    }
    
    // Más métodos...
}
```

### Parte 5: Infrastructure/Services

#### EmailService.cs
```csharp
public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    
    public async Task EnviarEmailAsync(string destinatario, string asunto, string mensaje)
    {
        // Implementar con SmtpClient o servicio externo
        // Configuración desde appsettings.json
    }
}
```

## 🔧 Configuración Necesaria

### appsettings.json
Agregar:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SistemaIncidentes;Trusted_Connection=true"
  },
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "SenderEmail": "sistema@universidad.edu",
    "SenderPassword": "tu-password-aqui",
    "EnableSsl": true
  }
}
```

## 📦 Paquetes NuGet a Instalar

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## 🗃️ Migraciones

```bash
# Crear migración inicial
dotnet ef migrations add MigracionInicial

# Aplicar migración
dotnet ef database update
```

## 📊 Datos Iniciales (database/seeds/)

### usuarios.sql
```sql
INSERT INTO Usuarios (Nombre, Email, PasswordHash, Nivel, FechaRegistro, Activo)
VALUES 
('Admin Sistema', 'admin@universidad.edu', 'hash', 4, GETDATE(), 1),
('Soporte Nivel 1', 'soporte1@universidad.edu', 'hash', 2, GETDATE(), 1),
('Soporte Nivel 2', 'soporte2@universidad.edu', 'hash', 3, GETDATE(), 1);
```

### etiquetas.sql
```sql
INSERT INTO Etiquetas (Nombre, Categoria)
VALUES 
('Impresora', 1),      -- Hardware
('Office', 2),         -- Software
('WiFi', 3),           -- Red
('Windows', 4),        -- Sistema Operativo
('Contraseña', 5);     -- Seguridad
```

## 🤝 Coordinación con Otros

**Con Persona 2 (Application):**
- Tus interfaces de repositorio serán usadas por sus servicios
- Define claramente los métodos de cada repositorio
- Comunica cuando termines las entidades

**Con Persona 3 (Web):**
- No hay dependencia directa
- Tus datos semilla serán usados para probar la UI

## 📝 Checklist

- [ ] Crear todas las entidades en Domain/Entities
- [ ] Crear todos los enums en Domain/Enums
- [ ] Configurar ApplicationDbContext
- [ ] Crear configuraciones Fluent API
- [ ] Implementar repositorios
- [ ] Implementar EmailService
- [ ] Crear migración inicial
- [ ] Aplicar migración
- [ ] Crear datos iniciales (seeds)
- [ ] Probar conexión a BD
- [ ] Documentar en database/README.md

## 🆘 Ayuda

Si tienes dudas, revisa:
- `docs/setup/configuracion.md` (crear este archivo)
- Ejemplos en tests/Domain.Tests
- Documentación de EF Core
