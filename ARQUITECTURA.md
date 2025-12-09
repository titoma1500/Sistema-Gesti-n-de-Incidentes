# Documentación Técnica - Arquitectura Onion

## Resumen de la Arquitectura

Este proyecto implementa **Arquitectura Onion (Cebolla)**, un patrón de diseño que promueve:

- Alta cohesión y bajo acoplamiento
- Independencia de frameworks
- Testabilidad
- Mantenibilidad
- Separación de responsabilidades

## Capas de la Arquitectura

```
┌─────────────────────────────────────────┐
│      Presentación (Blazor/UI)           │
│         Components/Pages                │
├─────────────────────────────────────────┤
│      Capa de Aplicación                 │
│    Services, DTOs, Interfaces           │
├─────────────────────────────────────────┤
│      Capa de Infraestructura            │
│   DbContext, Repositories, Data Access  │
├─────────────────────────────────────────┤
│      Capa de Dominio (Core)             │
│      Entities, Enums, Rules             │
└─────────────────────────────────────────┘
```

### 1. Capa de Dominio (Domain)

**Ubicación**: `Domain/`

**Responsabilidad**: Núcleo del negocio, contiene las reglas y lógica de dominio.

**Contenido**:
- **Entities**: Entidades del modelo de negocio
  - `Incidente.cs`: Representa un incidente reportado
  - `BaseConocimiento.cs`: Artículos de soluciones
  - `Usuario.cs`: Usuarios del sistema
  - `ServicioDITIC.cs`: Niveles de servicio

- **Enums**: Enumeraciones del dominio
  - `EstadoIncidente.cs`: Estados posibles de un incidente
  - `PrioridadIncidente.cs`: Niveles de prioridad
  - `NivelServicio.cs`: Niveles de escalamiento

**Características**:
- No depende de ninguna otra capa
- Contiene solo lógica de negocio pura
- No tiene referencias a frameworks externos

### 2. Capa de Aplicación (Application)

**Ubicación**: `Application/`

**Responsabilidad**: Orquesta la lógica de negocio y coordina entre capas.

**Contenido**:
- **DTOs (Data Transfer Objects)**: Objetos para transferir datos
  - `IncidenteDto.cs`: DTOs para incidentes
  - `BaseConocimientoDto.cs`: DTOs para conocimiento
  
- **Interfaces**: Contratos para servicios y repositorios
  - `IIncidenteService.cs`: Contrato del servicio de incidentes
  - `IBaseConocimientoService.cs`: Contrato del servicio de conocimiento
  - `IIncidenteRepository.cs`: Contrato del repositorio de incidentes
  - `IBaseConocimientoRepository.cs`: Contrato del repositorio de conocimiento

- **Services**: Implementación de la lógica de aplicación
  - `IncidenteService.cs`: Lógica de negocio para incidentes
  - `BaseConocimientoService.cs`: Lógica de negocio para conocimiento

**Características**:
- Depende solo de la capa de Dominio
- Define interfaces que serán implementadas por Infrastructure
- Contiene lógica de aplicación y orquestación

### 3. Capa de Infraestructura (Infrastructure)

**Ubicación**: `Infrastructure/`

**Responsabilidad**: Implementa el acceso a datos y servicios externos.

**Contenido**:
- **Data**: Configuración de Entity Framework
  - `ApplicationDbContext.cs`: DbContext con configuraciones
  
- **Repositories**: Implementación de repositorios
  - `IncidenteRepository.cs`: Acceso a datos de incidentes
  - `BaseConocimientoRepository.cs`: Acceso a datos de conocimiento

**Características**:
- Implementa las interfaces definidas en Application
- Contiene toda la lógica de acceso a datos
- Puede ser reemplazada sin afectar las capas superiores

### 4. Capa de Presentación (Components)

**Ubicación**: `Components/`

**Responsabilidad**: Interfaz de usuario con Blazor Server.

**Contenido**:
- **Pages**: Páginas Razor del sitio
  - `Incidentes.razor`: Lista y creación de incidentes
  - `IncidenteDetalle.razor`: Detalle de un incidente
  - `BaseConocimiento.razor`: Gestión de conocimiento
  - `Home.razor`: Página de inicio

- **Layout**: Componentes de diseño
  - `MainLayout.razor`: Layout principal
  - `NavMenu.razor`: Menú de navegación

**Características**:
- Depende de Application (servicios)
- No conoce Infrastructure directamente
- Usa inyección de dependencias

## Flujo de Datos

### Ejemplo: Crear un Incidente

```
1. Usuario → Blazor Page (Incidentes.razor)
   └─ Llena formulario y hace clic en "Guardar"

2. Blazor Page → IncidenteService
   └─ Llama a CrearAsync(CrearIncidenteDto)

3. IncidenteService → IncidenteRepository
   └─ Crea entidad Incidente
   └─ Llama a CrearAsync(Incidente)

4. IncidenteRepository → DbContext
   └─ Agrega a DbSet
   └─ Llama a SaveChangesAsync()

5. DbContext → SQL Server
   └─ Ejecuta INSERT en tabla Incidentes

6. Respuesta de vuelta por todas las capas
   └─ Blazor Page actualiza UI
```

## Patrones Implementados

### 1. Repository Pattern

Abstrae el acceso a datos detrás de una interfaz:

```csharp
public interface IIncidenteRepository
{
    Task<IEnumerable<Incidente>> ObtenerTodosAsync();
    Task<Incidente?> ObtenerPorIdAsync(int id);
    Task<Incidente> CrearAsync(Incidente incidente);
    // ...
}
```

**Beneficios**:
- Fácil de testear (mocks)
- Cambiar base de datos sin afectar lógica de negocio
- Centraliza consultas a datos

### 2. Service Layer Pattern

Encapsula la lógica de negocio en servicios:

```csharp
public class IncidenteService : IIncidenteService
{
    private readonly IIncidenteRepository _repository;
    
    public async Task<IncidenteDto> CrearAsync(CrearIncidenteDto dto)
    {
        // Lógica de validación y transformación
        var incidente = new Incidente { /* mapeo */ };
        var creado = await _repository.CrearAsync(incidente);
        return MapearADto(creado);
    }
}
```

**Beneficios**:
- Reutilización de lógica de negocio
- Validación centralizada
- Fácil de testear

### 3. Dependency Injection

Configurado en `Program.cs`:

```csharp
builder.Services.AddScoped<IIncidenteRepository, IncidenteRepository>();
builder.Services.AddScoped<IIncidenteService, IncidenteService>();
```

**Beneficios**:
- Bajo acoplamiento
- Fácil sustitución de implementaciones
- Mejora testabilidad

### 4. DTO Pattern

Objetos para transferir datos entre capas:

```csharp
public class CrearIncidenteDto
{
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public PrioridadIncidente Prioridad { get; set; }
    public int UsuarioReportaId { get; set; }
}
```

**Beneficios**:
- Control de datos expuestos
- Validación en el límite
- Desacoplamiento de entidades de dominio

## Modelo de Base de Datos

### Tablas Principales

#### Incidentes
- Id (PK)
- Titulo
- Descripcion
- Estado (enum)
- Prioridad (enum)
- UsuarioReportaId (FK → Usuarios)
- TecnicoAsignadoId (FK → Usuarios)
- ServicioDITICId (FK → ServiciosDITIC)
- NivelEscalamiento
- Fechas (Creacion, Asignacion, Resolucion, Cierre)

#### BaseConocimientos
- Id (PK)
- Titulo
- Problema
- Solucion
- Categoria
- PalabrasClaves (array)
- UsuarioCreadorId (FK → Usuarios)
- VecesConsultada
- Fechas (Creacion, Actualizacion)

#### Usuarios
- Id (PK)
- Nombre
- Email (Unique)
- Telefono
- Departamento
- EsTecnico
- FechaRegistro

#### ServiciosDITIC
- Id (PK)
- Nombre
- Nivel (enum)
- HoraInicio
- HoraFin
- DiasLaborales
- Activo

### Relaciones

```
Usuarios 1──N Incidentes (como reportador)
Usuarios 1──N Incidentes (como técnico)
Usuarios 1──N BaseConocimientos (como creador)
ServiciosDITIC 1──N Incidentes
```

## Configuración de Entity Framework

### Fluent API

Configurado en `ApplicationDbContext.OnModelCreating`:

```csharp
modelBuilder.Entity<Incidente>(entity =>
{
    entity.HasKey(e => e.Id);
    entity.Property(e => e.Titulo).IsRequired().HasMaxLength(200);
    
    entity.HasOne(e => e.UsuarioReporta)
        .WithMany(u => u.IncidentesReportados)
        .HasForeignKey(e => e.UsuarioReportaId)
        .OnDelete(DeleteBehavior.Restrict);
});
```

### Datos Semilla

```csharp
modelBuilder.Entity<Usuario>().HasData(
    new Usuario { Id = 1, Nombre = "Admin", Email = "admin@uni.edu" }
);
```

## Inyección de Dependencias

### Configuración en Program.cs

```csharp
// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repositorios (Scoped - una instancia por request)
builder.Services.AddScoped<IIncidenteRepository, IncidenteRepository>();

// Servicios (Scoped)
builder.Services.AddScoped<IIncidenteService, IncidenteService>();
```

### Uso en Blazor Components

```csharp
@inject IIncidenteService IncidenteService

@code {
    protected override async Task OnInitializedAsync()
    {
        var incidentes = await IncidenteService.ObtenerTodosAsync();
    }
}
```

## Ventajas de esta Arquitectura

### 1. Mantenibilidad
- Código organizado por responsabilidades
- Fácil localizar y modificar funcionalidad
- Cambios aislados a una capa

### 2. Testabilidad
- Interfaces permiten usar mocks
- Lógica de negocio separada de UI y datos
- Unit tests sin base de datos

### 3. Escalabilidad
- Fácil agregar nuevas funcionalidades
- Se puede reemplazar cualquier capa
- Múltiples implementaciones de interfaces

### 4. Independencia de Frameworks
- Dominio no depende de EF Core
- Se puede cambiar ORM sin afectar dominio
- Se puede cambiar UI (Blazor → MVC → API)

## Sistema de Notificaciones en Tiempo Real

### SignalR Hub

**Ubicación**: `Infrastructure/Hubs/NotificacionHub.cs`

**Responsabilidad**: Gestionar comunicación en tiempo real entre servidor y clientes.

**Características**:
- WebSocket persistente con reconexión automática
- Broadcast de eventos a todos los clientes conectados
- Métodos específicos para cada tipo de notificación

**Eventos Emitidos**:
```csharp
- "ActualizarIncidentes" (int incidenteId, string accion)
  → Enviado en: Crear, Asignar, Escalar, Resolver, Descartar
  → Recibido por: Index.razor, Detalle.razor
  → Acción: Recargar lista/detalle de incidentes

- "NotificarAsignacion" (int usuarioId, int incidenteId, string titulo)
  → Enviado en: AsignarAsync()
  → Recibido por: Notificaciones.razor
  → Acción: Crear notificación para técnico asignado

- "NotificarEscalamiento" (int usuarioId, int incidenteId, string titulo)
  → Enviado en: EscalarAsync()
  → Recibido por: Notificaciones.razor
  → Acción: Crear notificación para técnico superior

- "NotificarResolucion" (int usuarioId, int incidenteId, string titulo)
  → Enviado en: ResolverAsync()
  → Recibido por: Notificaciones.razor
  → Acción: Crear notificación para usuario reportante

- "NotificarDescarte" (int usuarioId, int incidenteId, string titulo, string motivo)
  → Enviado en: DescartarAsync()
  → Recibido por: Notificaciones.razor
  → Acción: Crear notificación para usuario reportante

- "RecibirNotificacion" (string mensaje, string tipo)
  → Evento genérico para notificaciones
```

### NotificacionService

**Ubicación**: `Application/Services/NotificacionService.cs`

**Tipo**: Singleton (una instancia compartida)

**Almacenamiento**: In-memory usando `ConcurrentDictionary<int, List<Notificacion>>`

**Características**:
- Almacena hasta 50 notificaciones por usuario
- Notificaciones más antiguas se eliminan automáticamente
- Thread-safe con ConcurrentDictionary

**Métodos**:
```csharp
Task AgregarNotificacion(int usuarioId, string mensaje, string tipo)
Task<List<Notificacion>> ObtenerNotificaciones(int usuarioId)
Task<int> ObtenerNoLeidas(int usuarioId)
Task MarcarComoLeida(int notificacionId)
Task MarcarTodasComoLeidas(int usuarioId)
```

### Flujo Completo de Notificación

```
Usuario realiza acción (ej: Asignar incidente)
            ↓
Index.razor → AsignarIncidente()
            ↓
IncidenteService.AsignarAsync()
            ↓
    ┌───────┴───────┐
    ↓               ↓
Repository      NotificacionService
actualiza BD    guarda notificación
    ↓               ↓
    └───────┬───────┘
            ↓
    HubContext.Clients.All.SendAsync()
            ↓
    ┌───────┴───────┬───────────┐
    ↓               ↓           ↓
Cliente A       Cliente B   Cliente C
    ↓               ↓           ↓
hubConnection.On("ActualizarIncidentes", ...)
    ↓
await CargarIncidentes()
await InvokeAsync(StateHasChanged)
    ↓
UI actualizada automáticamente
```

### SessionService con CircuitId

**Ubicación**: `Application/Services/SessionService.cs`

**Scope**: Circuit-scoped (una instancia por circuito/pestaña)

**Propósito**: Gestionar sesión del usuario actual por CircuitId único

**Características**:
- Almacena usuario en `ConcurrentDictionary<string, UsuarioResponseDto>`
- Key es CircuitId (único por pestaña del navegador)
- Permite múltiples sesiones simultáneas en pestañas diferentes
- Cleanup automático al cerrar pestaña (circuit disposed)

**Métodos**:
```csharp
Task SetUsuarioActualAsync(UsuarioResponseDto usuario)
Task<UsuarioResponseDto?> GetUsuarioActualAsync()
Task ClearSessionAsync()
```

**Uso en Componentes**:
```csharp
// NavMenu.razor - Detección con Timer
protected override void OnInitialized()
{
    timer = new Timer(async _ => await VerificarSesion(), 
                      null, TimeSpan.Zero, TimeSpan.FromMilliseconds(500));
}

private async Task VerificarSesion()
{
    var usuarioActual = await SessionService.GetUsuarioActualAsync();
    if (usuario == null && usuarioActual != null)
    {
        usuario = usuarioActual;
        timer?.Dispose(); // Detener timer
        await InvokeAsync(StateHasChanged);
    }
}
```

### CircuitIdProvider

**Ubicación**: `Infrastructure/Handlers/CircuitIdProvider.cs`

**Tipo**: CircuitHandler

**Propósito**: Generar y almacenar ID único por circuito Blazor

**Implementación**:
```csharp
public class CircuitIdProvider : CircuitHandler
{
    public string CircuitId { get; private set; } = Guid.NewGuid().ToString();

    public override Task OnCircuitOpenedAsync(Circuit circuit, 
                                             CancellationToken cancellationToken)
    {
        CircuitId = circuit.Id;
        Console.WriteLine($"[CircuitIdProvider] Circuit opened: {CircuitId}");
        return base.OnCircuitOpenedAsync(circuit, cancellationToken);
    }
}
```

**Registro en DI**:
```csharp
// Program.cs
builder.Services.AddScoped<CircuitHandler, CircuitIdProvider>();
builder.Services.AddScoped<CircuitIdProvider>();
```

## Mejores Prácticas Implementadas

1. **Separación de Responsabilidades**: Cada capa tiene un propósito claro
2. **Principio de Inversión de Dependencias**: Capas superiores dependen de abstracciones
3. **Single Responsibility**: Cada clase tiene una responsabilidad única
4. **Open/Closed**: Abierto para extensión, cerrado para modificación
5. **Dependency Injection**: Inyección de dependencias en toda la aplicación
6. **Repository Pattern**: Abstracción del acceso a datos
7. **DTO Pattern**: Transferencia de datos sin exponer entidades
8. **Circuit-scoped Services**: Aislamiento de sesiones por pestaña
9. **Real-time Communication**: SignalR para actualizaciones instantáneas
10. **Logging Detallado**: Console logs para debugging en desarrollo

## Extensibilidad Futura

### Agregar Autenticación JWT
1. Instalar `Microsoft.AspNetCore.Authentication.JwtBearer`
2. Configurar JWT en Program.cs
3. Crear AuthController para login/registro
4. Generar y validar tokens
5. Proteger endpoints con `[Authorize]`

### Agregar API REST
1. Crear proyecto `Proyecto.API`
2. Referenciar Application
3. Crear Controllers que usen los servicios
4. Configurar CORS
5. Documentar con Swagger/OpenAPI

### Agregar Logging Avanzado
1. Instalar Serilog o NLog
2. Inyectar `ILogger` en servicios
3. Registrar operaciones importantes
4. Configurar sinks (archivo, BD, cloud)
5. Implementar structured logging

### Agregar Validaciones con FluentValidation
1. Instalar FluentValidation.AspNetCore
2. Crear validadores para DTOs
3. Registrar en DI container
4. Validar automáticamente en controllers/services

### Agregar Caché
1. Instalar `Microsoft.Extensions.Caching.Memory`
2. Inyectar `IMemoryCache`
3. Cachear consultas frecuentes (etiquetas, usuarios)
4. Configurar políticas de expiración
5. Invalidar caché cuando datos cambien

### Agregar Tests
```csharp
// Tests Unitarios
[Fact]
public async Task CrearIncidente_DebeRetornarDto()
{
    // Arrange
    var mockRepo = new Mock<IIncidenteRepository>();
    var service = new IncidenteService(mockRepo.Object, ...);
    
    // Act
    var resultado = await service.CrearAsync(dto);
    
    // Assert
    Assert.NotNull(resultado);
}

// Tests de Integración
public class IncidenteIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task GetIncidentes_DebeRetornar200()
    {
        // ...
    }
}
```

### Migrar a Microservicios
1. **Servicio de Incidentes**: Gestión de tickets
2. **Servicio de Notificaciones**: Emails, push, SMS
3. **Servicio de Conocimiento**: KB y artículos
4. **API Gateway**: Kong, Ocelot o YARP
5. **Service Discovery**: Consul o Eureka
6. **Message Queue**: RabbitMQ o Azure Service Bus

## Conclusión

Esta arquitectura proporciona:
- ✅ Código mantenible y testeable
- ✅ Fácil de extender con nuevas funcionalidades
- ✅ Separación clara de responsabilidades
- ✅ Independencia de frameworks
- ✅ Escalabilidad futura
- ✅ Comunicación en tiempo real
- ✅ Gestión de sesiones robusta
- ✅ Logging completo para debugging

La arquitectura permite evolucionar el sistema sin reescribir código existente, facilitando la adición de nuevas características como autenticación avanzada, APIs REST, microservicios, etc.
