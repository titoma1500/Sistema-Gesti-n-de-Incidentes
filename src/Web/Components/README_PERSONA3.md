# 👤 Persona 3: Frontend (Blazor)

## 📋 Tu Responsabilidad

Eres responsable de:
1. **Todas las páginas Blazor** - UI completa del sistema
2. **Componentes reutilizables** - Cards, etiquetas, buscadores
3. **Diseño y estilos** - CSS, Bootstrap, temas
4. **Validaciones de formularios** - UX y experiencia de usuario

## 📁 Tus Carpetas

```
src/Web/Components/  ← Trabajas aquí
src/Web/wwwroot/     ← Estilos y archivos estáticos
docs/ui-design/      ← Documentas diseños aquí
```

## ✅ Tareas Semana 1

### Parte 1: Página de Login

#### Components/Pages/Auth/Login.razor
```razor
@page "/login"
@using Proyecto.Application.DTOs.Auth
@using Proyecto.Application.Interfaces
@inject IAuthService AuthService
@inject NavigationManager Navigation

<PageTitle>Login - Sistema de Incidentes</PageTitle>

<div class="container">
    <div class="row justify-content-center mt-5">
        <div class="col-md-4">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h4>Iniciar Sesión</h4>
                </div>
                <div class="card-body">
                    <EditForm Model="loginDto" OnValidSubmit="HandleLogin">
                        <DataAnnotationsValidator />
                        
                        <div class="mb-3">
                            <label class="form-label">Email:</label>
                            <InputText class="form-control" @bind-Value="loginDto.Email" 
                                       placeholder="usuario@universidad.edu" />
                            <ValidationMessage For="() => loginDto.Email" />
                        </div>
                        
                        <div class="mb-3">
                            <label class="form-label">Contraseña:</label>
                            <InputText type="password" class="form-control" 
                                       @bind-Value="loginDto.Password" />
                            <ValidationMessage For="() => loginDto.Password" />
                        </div>
                        
                        @if (!string.IsNullOrEmpty(errorMessage))
                        {
                            <div class="alert alert-danger">@errorMessage</div>
                        }
                        
                        <button type="submit" class="btn btn-primary w-100">
                            Ingresar
                        </button>
                    </EditForm>
                </div>
            </div>
        </div>
    </div>
</div>

@code {
    private LoginDto loginDto = new();
    private string errorMessage = string.Empty;

    private async Task HandleLogin()
    {
        var response = await AuthService.LoginAsync(loginDto);
        
        if (response != null)
        {
            // Guardar sesión (usar localStorage o SessionStorage)
            // await SessionStorage.SetItemAsync("usuario", response);
            Navigation.NavigateTo("/incidentes");
        }
        else
        {
            errorMessage = "Credenciales incorrectas";
        }
    }
}
```

### Parte 2: Gestión de Incidentes

#### Components/Pages/Incidentes/Index.razor
```razor
@page "/incidentes"
@rendermode InteractiveServer
@using Proyecto.Application.DTOs.Incidentes
@using Proyecto.Application.Interfaces
@inject IIncidenteService IncidenteService
@inject NavigationManager Navigation

<PageTitle>Gestión de Incidentes</PageTitle>

<div class="container-fluid">
    <div class="row mb-3">
        <div class="col-md-6">
            <h3>Incidentes</h3>
        </div>
        <div class="col-md-6 text-end">
            <button class="btn btn-success" @onclick="NuevoIncidente">
                <i class="bi bi-plus-circle"></i> Nuevo Incidente
            </button>
        </div>
    </div>

    <!-- Filtros -->
    <div class="row mb-3">
        <div class="col-md-3">
            <select class="form-select" @onchange="FiltrarPorEstado">
                <option value="">Todos los estados</option>
                <option value="1">Abierto</option>
                <option value="2">Asignado</option>
                <option value="3">En Proceso</option>
                <option value="4">Resuelto</option>
                <option value="5">Cerrado</option>
            </select>
        </div>
        <div class="col-md-3">
            <select class="form-select" @onchange="FiltrarPorPrioridad">
                <option value="">Todas las prioridades</option>
                <option value="1">Baja</option>
                <option value="2">Media</option>
                <option value="3">Alta</option>
                <option value="4">Crítica</option>
            </select>
        </div>
    </div>

    <!-- Lista de Incidentes -->
    @if (incidentes == null)
    {
        <p><em>Cargando...</em></p>
    }
    else
    {
        <div class="table-responsive">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Título</th>
                        <th>Estado</th>
                        <th>Prioridad</th>
                        <th>Reportado por</th>
                        <th>Asignado a</th>
                        <th>Etiquetas</th>
                        <th>Fecha</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var incidente in incidentes)
                    {
                        <tr>
                            <td>@incidente.Id</td>
                            <td>@incidente.Titulo</td>
                            <td>
                                <span class="badge bg-@ObtenerColorEstado(incidente.Estado)">
                                    @incidente.Estado
                                </span>
                            </td>
                            <td>
                                <span class="badge bg-@ObtenerColorPrioridad(incidente.Prioridad)">
                                    @incidente.Prioridad
                                </span>
                            </td>
                            <td>@incidente.UsuarioReportaNombre</td>
                            <td>@(incidente.UsuarioAsignadoNombre ?? "Sin asignar")</td>
                            <td>
                                @foreach (var etiqueta in incidente.Etiquetas)
                                {
                                    <span class="badge bg-secondary me-1">@etiqueta</span>
                                }
                            </td>
                            <td>@incidente.FechaCreacion.ToString("dd/MM/yyyy")</td>
                            <td>
                                <button class="btn btn-sm btn-primary" 
                                        @onclick="() => VerDetalle(incidente.Id)">
                                    Ver
                                </button>
                            </td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>
    }
</div>

@code {
    private List<IncidenteDto>? incidentes;
    
    protected override async Task OnInitializedAsync()
    {
        await CargarIncidentes();
    }

    private async Task CargarIncidentes()
    {
        var resultado = await IncidenteService.ObtenerTodosAsync();
        incidentes = resultado.ToList();
    }

    private void NuevoIncidente()
    {
        Navigation.NavigateTo("/incidentes/crear");
    }

    private void VerDetalle(int id)
    {
        Navigation.NavigateTo($"/incidentes/detalle/{id}");
    }

    private async Task FiltrarPorEstado(ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out int estadoId))
        {
            var resultado = await IncidenteService.ObtenerPorEstadoAsync(estadoId);
            incidentes = resultado.ToList();
        }
        else
        {
            await CargarIncidentes();
        }
    }

    private string ObtenerColorEstado(string estado) => estado switch
    {
        "Abierto" => "primary",
        "Asignado" => "info",
        "EnProceso" => "warning",
        "Resuelto" => "success",
        "Cerrado" => "secondary",
        _ => "secondary"
    };

    private string ObtenerColorPrioridad(string prioridad) => prioridad switch
    {
        "Baja" => "secondary",
        "Media" => "info",
        "Alta" => "warning",
        "Critica" => "danger",
        _ => "secondary"
    };
}
```

#### Components/Pages/Incidentes/Crear.razor
```razor
@page "/incidentes/crear"
@rendermode InteractiveServer
@using Proyecto.Application.DTOs.Incidentes
@using Proyecto.Application.Interfaces
@inject IIncidenteService IncidenteService
@inject NavigationManager Navigation

<PageTitle>Crear Incidente</PageTitle>

<div class="container">
    <h3>Crear Nuevo Incidente</h3>
    
    <div class="card mt-3">
        <div class="card-body">
            <EditForm Model="nuevoIncidente" OnValidSubmit="CrearIncidente">
                <DataAnnotationsValidator />
                
                <div class="mb-3">
                    <label class="form-label">Título:</label>
                    <InputText class="form-control" @bind-Value="nuevoIncidente.Titulo"
                               placeholder="Ej: Impresora no funciona en Lab 3" />
                    <ValidationMessage For="() => nuevoIncidente.Titulo" />
                </div>
                
                <div class="mb-3">
                    <label class="form-label">Descripción detallada:</label>
                    <InputTextArea class="form-control" rows="5" 
                                   @bind-Value="nuevoIncidente.Descripcion"
                                   placeholder="Describe el problema en detalle..." />
                    <ValidationMessage For="() => nuevoIncidente.Descripcion" />
                </div>
                
                <div class="mb-3">
                    <label class="form-label">Prioridad:</label>
                    <InputSelect class="form-select" @bind-Value="nuevoIncidente.PrioridadId">
                        <option value="1">Baja</option>
                        <option value="2">Media</option>
                        <option value="3">Alta</option>
                        <option value="4">Crítica</option>
                    </InputSelect>
                </div>
                
                <div class="mb-3">
                    <label class="form-label">Etiquetas:</label>
                    <div class="d-flex flex-wrap gap-2">
                        @foreach (var etiqueta in etiquetasDisponibles)
                        {
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox"
                                       id="etiqueta-@etiqueta.Id"
                                       @onchange="e => ToggleEtiqueta(etiqueta.Id, e.Value)" />
                                <label class="form-check-label" for="etiqueta-@etiqueta.Id">
                                    @etiqueta.Nombre
                                </label>
                            </div>
                        }
                    </div>
                </div>
                
                <div class="mt-4">
                    <button type="submit" class="btn btn-success">Crear Incidente</button>
                    <button type="button" class="btn btn-secondary" 
                            @onclick="Cancelar">Cancelar</button>
                </div>
            </EditForm>
        </div>
    </div>
</div>

@code {
    private CrearIncidenteDto nuevoIncidente = new() { UsuarioReportaId = 1 };
    private List<EtiquetaDto> etiquetasDisponibles = new();

    protected override async Task OnInitializedAsync()
    {
        // TODO: Cargar etiquetas desde servicio
        etiquetasDisponibles = new List<EtiquetaDto>
        {
            new() { Id = 1, Nombre = "Hardware" },
            new() { Id = 2, Nombre = "Software" },
            new() { Id = 3, Nombre = "Red" },
        };
    }

    private void ToggleEtiqueta(int etiquetaId, object? isChecked)
    {
        if (isChecked is bool check && check)
        {
            if (!nuevoIncidente.EtiquetasIds.Contains(etiquetaId))
                nuevoIncidente.EtiquetasIds.Add(etiquetaId);
        }
        else
        {
            nuevoIncidente.EtiquetasIds.Remove(etiquetaId);
        }
    }

    private async Task CrearIncidente()
    {
        await IncidenteService.CrearAsync(nuevoIncidente);
        Navigation.NavigateTo("/incidentes");
    }

    private void Cancelar()
    {
        Navigation.NavigateTo("/incidentes");
    }

    public class EtiquetaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
```

#### Components/Pages/Incidentes/Detalle.razor
```razor
@page "/incidentes/detalle/{id:int}"
@rendermode InteractiveServer
@using Proyecto.Application.DTOs.Incidentes
@using Proyecto.Application.DTOs.BaseConocimiento
@using Proyecto.Application.Interfaces
@inject IIncidenteService IncidenteService
@inject IBaseConocimientoService BaseConocimientoService
@inject NavigationManager Navigation

<PageTitle>Detalle Incidente</PageTitle>

@if (incidente == null)
{
    <p><em>Cargando...</em></p>
}
else
{
    <div class="container-fluid">
        <div class="row">
            <!-- Columna Izquierda: Detalles del Incidente -->
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h4>Incidente #@incidente.Id - @incidente.Titulo</h4>
                    </div>
                    <div class="card-body">
                        <p><strong>Descripción:</strong></p>
                        <p>@incidente.Descripcion</p>
                        
                        <hr />
                        
                        <div class="row">
                            <div class="col-6">
                                <p><strong>Estado:</strong> 
                                    <span class="badge bg-primary">@incidente.Estado</span>
                                </p>
                            </div>
                            <div class="col-6">
                                <p><strong>Prioridad:</strong> 
                                    <span class="badge bg-warning">@incidente.Prioridad</span>
                                </p>
                            </div>
                        </div>
                        
                        <p><strong>Reportado por:</strong> @incidente.UsuarioReportaNombre</p>
                        <p><strong>Asignado a:</strong> 
                            @(incidente.UsuarioAsignadoNombre ?? "Sin asignar")</p>
                        <p><strong>Fecha:</strong> @incidente.FechaCreacion</p>
                        
                        <!-- Acciones según rol del usuario -->
                        <div class="mt-4">
                            @if (esAdmin)
                            {
                                <button class="btn btn-primary">Asignar Técnico</button>
                            }
                            
                            @if (esTecnicoAsignado && incidente.Estado != "Resuelto")
                            {
                                <button class="btn btn-success" @onclick="MostrarFormResolver">
                                    Resolver
                                </button>
                                <button class="btn btn-warning" @onclick="MostrarFormEscalar">
                                    Escalar
                                </button>
                            }
                        </div>
                    </div>
                </div>
            </div>
            
            <!-- Columna Derecha: Base de Conocimiento -->
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h5>Base de Conocimiento</h5>
                    </div>
                    <div class="card-body">
                        <input type="text" class="form-control mb-3" 
                               placeholder="Buscar soluciones..."
                               @bind="terminoBusqueda"
                               @bind:event="oninput"
                               @onkeyup="BuscarSoluciones" />
                        
                        @if (articulosRelacionados != null && articulosRelacionados.Any())
                        {
                            @foreach (var articulo in articulosRelacionados)
                            {
                                <div class="card mb-2">
                                    <div class="card-body">
                                        <h6>@articulo.Titulo</h6>
                                        <p class="small">@articulo.Descripcion</p>
                                        <button class="btn btn-sm btn-link" 
                                                @onclick="() => VerSolucion(articulo.Id)">
                                            Ver solución completa
                                        </button>
                                    </div>
                                </div>
                            }
                        }
                        else
                        {
                            <p class="text-muted">No se encontraron soluciones relacionadas</p>
                        }
                    </div>
                </div>
            </div>
        </div>
    </div>
}

@code {
    [Parameter]
    public int Id { get; set; }

    private IncidenteDto? incidente;
    private List<BaseConocimientoDto>? articulosRelacionados;
    private string terminoBusqueda = string.Empty;
    private bool esAdmin = false; // TODO: Obtener del usuario logueado
    private bool esTecnicoAsignado = false; // TODO: Verificar

    protected override async Task OnInitializedAsync()
    {
        incidente = await IncidenteService.ObtenerPorIdAsync(Id);
        await BuscarSoluciones();
    }

    private async Task BuscarSoluciones()
    {
        // TODO: Buscar por etiquetas del incidente
        var resultado = await BaseConocimientoService.ObtenerTodosAsync();
        articulosRelacionados = resultado.Take(5).ToList();
    }

    private void MostrarFormResolver()
    {
        // TODO: Mostrar modal/formulario para resolver
    }

    private void MostrarFormEscalar()
    {
        // TODO: Mostrar modal/formulario para escalar
    }

    private void VerSolucion(int articuloId)
    {
        // TODO: Mostrar solución completa en modal
    }
}
```

### Parte 3: Base de Conocimiento

#### Components/Pages/BaseConocimiento/Buscar.razor
```razor
@page "/conocimiento"
@rendermode InteractiveServer
@using Proyecto.Application.DTOs.BaseConocimiento
@using Proyecto.Application.Interfaces
@inject IBaseConocimientoService BaseConocimientoService

<PageTitle>Base de Conocimiento</PageTitle>

<div class="container">
    <h3>Base de Conocimiento</h3>
    
    <div class="row mt-3">
        <div class="col-md-8">
            <input type="text" class="form-control" 
                   placeholder="Buscar por palabras clave..."
                   @bind="textoBusqueda"
                   @bind:event="oninput" />
        </div>
        <div class="col-md-4">
            <button class="btn btn-primary w-100" @onclick="Buscar">
                <i class="bi bi-search"></i> Buscar
            </button>
        </div>
    </div>
    
    <!-- Resultados -->
    @if (articulos != null)
    {
        <div class="row mt-4">
            @foreach (var articulo in articulos)
            {
                <div class="col-md-6 mb-3">
                    <div class="card h-100">
                        <div class="card-header">
                            <strong>@articulo.Titulo</strong>
                        </div>
                        <div class="card-body">
                            <p>@articulo.Descripcion</p>
                            <div class="mb-2">
                                @foreach (var etiqueta in articulo.Etiquetas)
                                {
                                    <span class="badge bg-info me-1">@etiqueta</span>
                                }
                            </div>
                            <small class="text-muted">
                                Consultado @articulo.VecesConsultada veces
                            </small>
                        </div>
                        <div class="card-footer">
                            <button class="btn btn-sm btn-primary" 
                                    @onclick="() => VerDetalle(articulo.Id)">
                                Ver Solución
                            </button>
                        </div>
                    </div>
                </div>
            }
        </div>
    }
</div>

@code {
    private List<BaseConocimientoDto>? articulos;
    private string textoBusqueda = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await Buscar();
    }

    private async Task Buscar()
    {
        var dto = new BuscarBaseConocimientoDto
        {
            TextoBusqueda = textoBusqueda
        };
        
        var resultado = await BaseConocimientoService.BuscarAsync(dto);
        articulos = resultado.ToList();
    }

    private void VerDetalle(int id)
    {
        // TODO: Mostrar modal o navegar a detalle
    }
}
```

### Parte 4: Componentes Compartidos

#### Components/Shared/IncidenteCard.razor
```razor
<div class="card">
    <div class="card-header d-flex justify-content-between">
        <strong>@Incidente.Titulo</strong>
        <span class="badge bg-@ObtenerColorPrioridad()">@Incidente.Prioridad</span>
    </div>
    <div class="card-body">
        <p>@Incidente.Descripcion</p>
        <div class="d-flex justify-content-between align-items-center">
            <small class="text-muted">@Incidente.FechaCreacion</small>
            <button class="btn btn-sm btn-primary" @onclick="OnVerClick">Ver</button>
        </div>
    </div>
</div>

@code {
    [Parameter]
    public IncidenteDto Incidente { get; set; } = null!;
    
    [Parameter]
    public EventCallback<int> OnVerClick { get; set; }

    private string ObtenerColorPrioridad() => Incidente.Prioridad switch
    {
        "Baja" => "secondary",
        "Media" => "info",
        "Alta" => "warning",
        "Critica" => "danger",
        _ => "secondary"
    };
}
```

## 📝 Tareas de Estilos

### wwwroot/css/app.css
```css
/* Estilos personalizados */
:root {
    --color-primary: #0d6efd;
    --color-success: #198754;
    --color-warning: #ffc107;
    --color-danger: #dc3545;
}

.incidente-card {
    transition: transform 0.2s;
}

.incidente-card:hover {
    transform: translateY(-5px);
    box-shadow: 0 4px 8px rgba(0,0,0,0.2);
}

.badge-etiqueta {
    font-size: 0.85rem;
    padding: 0.35rem 0.65rem;
}
```

## 🤝 Coordinación con Otros

**Con Persona 2 (Application):**
- ESPERA a que termine las interfaces y DTOs
- Usa sus servicios en las páginas
- Inyecta IIncidenteService, IBaseConocimientoService, etc.

**Con Persona 1 (Domain):**
- No hay dependencia directa
- Usas datos a través de los servicios

## 📝 Checklist

- [ ] Crear página de Login
- [ ] Crear Index de incidentes
- [ ] Crear formulario Crear incidente
- [ ] Crear página Detalle de incidente
- [ ] Crear búsqueda de base de conocimiento
- [ ] Crear componentes compartidos
- [ ] Diseñar estilos personalizados
- [ ] Validar formularios
- [ ] Manejar estados de carga
- [ ] Manejar errores

## 🆘 Ayuda

- Revisa documentación de Blazor Server
- Coordina con Persona 2 sobre DTOs
- Usa Bootstrap 5 para estilos base
