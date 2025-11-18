# 👤 Persona 2: Lógica de Negocio & Servicios

## 📋 Tu Responsabilidad

Eres responsable de:
1. **Capa de Aplicación** - Servicios de negocio y orquestación
2. **DTOs** - Objetos de transferencia de datos
3. **Interfaces de Servicios** - Contratos para la lógica de negocio
4. **Lógica de Escalamiento** - Reglas para asignar y escalar incidentes

## 📁 Tus Carpetas

```
src/Application/      ← Trabajas aquí
docs/business-logic/ ← Documentas aquí
```

## ✅ Tareas Semana 1

### Parte 1: Application/DTOs

Crear DTOs organizados por módulo:

#### DTOs/Auth/LoginDto.cs
```csharp
namespace Proyecto.Application.DTOs.Auth;

public class LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginResponseDto
{
    public int UsuarioId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Nivel { get; set; }
    public string Token { get; set; } = string.Empty; // JWT si usas
}
```

#### DTOs/Incidentes/IncidenteDto.cs
```csharp
namespace Proyecto.Application.DTOs.Incidentes;

public class IncidenteDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Prioridad { get; set; } = string.Empty;
    public string UsuarioReportaNombre { get; set; } = string.Empty;
    public string? UsuarioAsignadoNombre { get; set; }
    public List<string> Etiquetas { get; set; } = new();
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaSolucion { get; set; }
    public string? MensajeSolucion { get; set; }
}

public class CrearIncidenteDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int PrioridadId { get; set; }
    public List<int> EtiquetasIds { get; set; } = new();
    public int UsuarioReportaId { get; set; }
}

public class AsignarIncidenteDto
{
    public int IncidenteId { get; set; }
    public int UsuarioAsignadoId { get; set; }
}

public class ResolverIncidenteDto
{
    public int IncidenteId { get; set; }
    public string MensajeSolucion { get; set; } = string.Empty;
}

public class EscalarIncidenteDto
{
    public int IncidenteId { get; set; }
    public int NuevoNivel { get; set; }
    public string MensajeEscalamiento { get; set; } = string.Empty;
}
```

#### DTOs/BaseConocimiento/BaseConocimientoDto.cs
```csharp
namespace Proyecto.Application.DTOs.BaseConocimiento;

public class BaseConocimientoDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Solucion { get; set; } = string.Empty;
    public List<string> Etiquetas { get; set; } = new();
    public int VecesConsultada { get; set; }
    public DateTime FechaCreacion { get; set; }
}

public class CrearBaseConocimientoDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Solucion { get; set; } = string.Empty;
    public List<int> EtiquetasIds { get; set; } = new();
}

public class BuscarBaseConocimientoDto
{
    public string? TextoBusqueda { get; set; }
    public List<int>? EtiquetasIds { get; set; }
}
```

### Parte 2: Application/Interfaces

Define los contratos de servicios:

#### IAuthService.cs
```csharp
namespace Proyecto.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);
    Task<bool> ValidarCredencialesAsync(string email, string password);
}
```

#### IIncidenteService.cs
```csharp
public interface IIncidenteService
{
    // Consultas
    Task<IEnumerable<IncidenteDto>> ObtenerTodosAsync();
    Task<IncidenteDto?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<IncidenteDto>> ObtenerPorUsuarioAsync(int usuarioId);
    Task<IEnumerable<IncidenteDto>> ObtenerPorEstadoAsync(int estadoId);
    Task<IEnumerable<IncidenteDto>> ObtenerPorNivelAsync(int nivel);
    
    // Operaciones
    Task<IncidenteDto> CrearAsync(CrearIncidenteDto dto);
    Task AsignarAsync(AsignarIncidenteDto dto);
    Task ResolverAsync(ResolverIncidenteDto dto);
    Task EscalarAsync(EscalarIncidenteDto dto);
    Task CerrarAsync(int incidenteId);
    
    // Búsqueda
    Task<IEnumerable<IncidenteDto>> BuscarPorEtiquetasAsync(List<int> etiquetasIds);
}
```

#### IBaseConocimientoService.cs
```csharp
public interface IBaseConocimientoService
{
    Task<IEnumerable<BaseConocimientoDto>> ObtenerTodosAsync();
    Task<BaseConocimientoDto?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<BaseConocimientoDto>> BuscarAsync(BuscarBaseConocimientoDto dto);
    Task<IEnumerable<BaseConocimientoDto>> BuscarPorEtiquetasAsync(List<int> etiquetasIds);
    Task<BaseConocimientoDto> CrearAsync(CrearBaseConocimientoDto dto);
    Task IncrementarConsultasAsync(int id);
}
```

#### IUsuarioService.cs
```csharp
public interface IUsuarioService
{
    Task<UsuarioDto?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<UsuarioDto>> ObtenerPorNivelAsync(int nivel);
    Task<UsuarioDto?> ObtenerPorEmailAsync(string email);
}
```

#### IEmailService.cs (interfaz, implementación en Infrastructure)
```csharp
public interface IEmailService
{
    Task EnviarEmailAsync(string destinatario, string asunto, string mensaje);
    Task EnviarNotificacionAsignacionAsync(int incidenteId, int usuarioId);
    Task EnviarNotificacionEscalamientoAsync(int incidenteId, int usuarioId);
    Task EnviarNotificacionResolucionAsync(int incidenteId, int usuarioReportaId);
}
```

### Parte 3: Application/Services

Implementa la lógica de negocio:

#### IncidenteService.cs
```csharp
namespace Proyecto.Application.Services;

public class IncidenteService : IIncidenteService
{
    private readonly IIncidenteRepository _incidenteRepo;
    private readonly IUsuarioRepository _usuarioRepo;
    private readonly IEmailService _emailService;

    public IncidenteService(
        IIncidenteRepository incidenteRepo,
        IUsuarioRepository usuarioRepo,
        IEmailService emailService)
    {
        _incidenteRepo = incidenteRepo;
        _usuarioRepo = usuarioRepo;
        _emailService = emailService;
    }

    public async Task<IncidenteDto> CrearAsync(CrearIncidenteDto dto)
    {
        var incidente = new Incidente
        {
            Titulo = dto.Titulo,
            Descripcion = dto.Descripcion,
            Prioridad = (PrioridadIncidente)dto.PrioridadId,
            Estado = EstadoIncidente.Abierto,
            UsuarioReportaId = dto.UsuarioReportaId,
            FechaCreacion = DateTime.Now
        };
        
        // Asignar etiquetas
        // TODO: Agregar lógica para etiquetas
        
        await _incidenteRepo.CrearAsync(incidente);
        
        return MapearADto(incidente);
    }

    public async Task AsignarAsync(AsignarIncidenteDto dto)
    {
        var incidente = await _incidenteRepo.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null) 
            throw new Exception("Incidente no encontrado");

        incidente.UsuarioAsignadoId = dto.UsuarioAsignadoId;
        incidente.Estado = EstadoIncidente.Asignado;
        incidente.FechaAsignacion = DateTime.Now;
        
        await _incidenteRepo.ActualizarAsync(incidente);
        
        // Enviar notificación por email
        await _emailService.EnviarNotificacionAsignacionAsync(
            dto.IncidenteId, 
            dto.UsuarioAsignadoId
        );
    }

    public async Task EscalarAsync(EscalarIncidenteDto dto)
    {
        var incidente = await _incidenteRepo.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null) 
            throw new Exception("Incidente no encontrado");

        // Validar que el nuevo nivel sea mayor
        var usuarioActual = await _usuarioRepo.ObtenerPorIdAsync(
            incidente.UsuarioAsignadoId ?? 0
        );
        
        if (usuarioActual == null || (int)usuarioActual.Nivel >= dto.NuevoNivel)
            throw new Exception("Nivel de escalamiento inválido");

        incidente.MensajeEscalamiento = dto.MensajeEscalamiento;
        incidente.UsuarioAsignadoId = null; // Desasignar para que admin asigne
        incidente.Estado = EstadoIncidente.Abierto;
        
        await _incidenteRepo.ActualizarAsync(incidente);
        
        // TODO: Notificar a usuarios del nuevo nivel
    }

    public async Task ResolverAsync(ResolverIncidenteDto dto)
    {
        var incidente = await _incidenteRepo.ObtenerPorIdAsync(dto.IncidenteId);
        if (incidente == null) 
            throw new Exception("Incidente no encontrado");

        incidente.Estado = EstadoIncidente.Resuelto;
        incidente.MensajeSolucion = dto.MensajeSolucion;
        incidente.FechaSolucion = DateTime.Now;
        
        await _incidenteRepo.ActualizarAsync(incidente);
        
        // Notificar al usuario que reportó
        await _emailService.EnviarNotificacionResolucionAsync(
            dto.IncidenteId,
            incidente.UsuarioReportaId
        );
    }

    private IncidenteDto MapearADto(Incidente incidente)
    {
        return new IncidenteDto
        {
            Id = incidente.Id,
            Titulo = incidente.Titulo,
            Descripcion = incidente.Descripcion,
            Estado = incidente.Estado.ToString(),
            Prioridad = incidente.Prioridad.ToString(),
            UsuarioReportaNombre = incidente.UsuarioReporta?.Nombre ?? "",
            UsuarioAsignadoNombre = incidente.UsuarioAsignado?.Nombre,
            FechaCreacion = incidente.FechaCreacion,
            FechaSolucion = incidente.FechaSolucion,
            MensajeSolucion = incidente.MensajeSolucion,
            Etiquetas = incidente.Etiquetas?.Select(e => e.Nombre).ToList() ?? new()
        };
    }
    
    // Implementar otros métodos...
}
```

#### BaseConocimientoService.cs
```csharp
public class BaseConocimientoService : IBaseConocimientoService
{
    private readonly IBaseConocimientoRepository _repository;

    public BaseConocimientoService(IBaseConocimientoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BaseConocimientoDto>> BuscarAsync(
        BuscarBaseConocimientoDto dto)
    {
        var articulos = await _repository.BuscarAsync(
            dto.TextoBusqueda, 
            dto.EtiquetasIds
        );
        
        return articulos.Select(MapearADto);
    }

    public async Task IncrementarConsultasAsync(int id)
    {
        var articulo = await _repository.ObtenerPorIdAsync(id);
        if (articulo != null)
        {
            articulo.VecesConsultada++;
            await _repository.ActualizarAsync(articulo);
        }
    }

    private BaseConocimientoDto MapearADto(BaseConocimiento articulo)
    {
        return new BaseConocimientoDto
        {
            Id = articulo.Id,
            Titulo = articulo.Titulo,
            Descripcion = articulo.Descripcion,
            Solucion = articulo.Solucion,
            VecesConsultada = articulo.VecesConsultada,
            FechaCreacion = articulo.FechaCreacion,
            Etiquetas = articulo.Etiquetas?.Select(e => e.Nombre).ToList() ?? new()
        };
    }
    
    // Implementar otros métodos...
}
```

#### EscalamientoService.cs
```csharp
public class EscalamientoService
{
    /// <summary>
    /// Determina si un usuario puede escalar un incidente
    /// </summary>
    public bool PuedeEscalar(int nivelUsuario, int nuevoNivel)
    {
        // Nivel 1 puede escalar a 2
        // Nivel 2 puede escalar a 3
        // Nivel 3 puede escalar a 4
        // Nivel 4 no puede escalar
        return nuevoNivel == nivelUsuario + 1 && nivelUsuario < 4;
    }

    /// <summary>
    /// Obtiene el siguiente nivel disponible para escalamiento
    /// </summary>
    public int? ObtenerSiguienteNivel(int nivelActual)
    {
        return nivelActual < 4 ? nivelActual + 1 : null;
    }
}
```

### Parte 4: Documentación de Lógica de Negocio

#### docs/business-logic/flujo-incidentes.md
```markdown
# Flujo de Incidentes

## 1. Creación de Incidente
1. Usuario reporta problema
2. Selecciona prioridad y etiquetas
3. Sistema crea incidente en estado "Abierto"
4. Administrador recibe notificación

## 2. Asignación
1. Admin ve incidentes abiertos
2. Selecciona técnico según:
   - Nivel apropiado
   - Etiquetas del incidente
   - Carga de trabajo
3. Sistema asigna y cambia estado a "Asignado"
4. Técnico recibe email con detalles

## 3. Resolución
1. Técnico revisa incidente
2. Busca en base de conocimiento
3. Aplica solución
4. Marca como "Resuelto" con mensaje
5. Usuario reportador recibe notificación

## 4. Escalamiento
1. Si técnico no puede resolver
2. Escala a nivel superior
3. Sistema desasigna y vuelve a "Abierto"
4. Admin asigna a técnico de nivel superior
```

## 🤝 Coordinación con Otros

**Con Persona 1 (Domain/Infrastructure):**
- ESPERA a que termine las entidades básicas
- Usa sus interfaces de repositorios (IIncidenteRepository, etc.)
- Coordina los métodos necesarios en repositorios

**Con Persona 3 (Web):**
- Tus DTOs serán usados en los formularios Blazor
- Tus servicios serán inyectados en las páginas
- Define contratos claros en las interfaces

## 📝 Checklist

- [ ] Crear todos los DTOs organizados por módulo
- [ ] Definir interfaces de servicios
- [ ] Implementar IncidenteService
- [ ] Implementar BaseConocimientoService
- [ ] Implementar AuthService
- [ ] Implementar EscalamientoService
- [ ] Documentar flujo de incidentes
- [ ] Documentar reglas de escalamiento
- [ ] Crear validadores (opcional)
- [ ] Escribir tests unitarios

## 🆘 Ayuda

Si tienes dudas:
- Revisa `docs/business-logic/`
- Pregunta a Persona 1 sobre las entidades
- Coordina con Persona 3 sobre necesidades de UI
