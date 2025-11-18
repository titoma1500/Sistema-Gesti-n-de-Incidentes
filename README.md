# Sistema de Gestión de Incidentes DITIC

Sistema de gestión de incidentes y base de conocimiento para servicios DITIC universitarios, desarrollado con Blazor Server, .NET 8, Arquitectura Onion y SQL Server.

## Características

### Gestión de Incidentes
- Registro de incidentes reportados por estudiantes
- Sistema de prioridades (Baja, Media, Alta, Crítica)
- Estados del incidente (Nuevo, Asignado, En Proceso, Escalado, Resuelto, Cerrado)
- Escalamiento entre 4 niveles de servicio
- Asignación de técnicos especializados
- Seguimiento de fechas (creación, asignación, resolución)

### Base de Conocimiento
- Registro de soluciones a problemas comunes
- Búsqueda por palabras clave
- Categorización de artículos
- Estadísticas de consultas
- Sistema de palabras clave para búsqueda rápida

### Niveles de Servicio DITIC
1. **Usuario Experto** - Soporte básico de primer nivel
2. **Ingeniería de Soporte** - Problemas técnicos especializados
3. **Proveedor** - Escalamiento a fabricantes
4. **Proveedor Avanzado** - Casos críticos y complejos

## Arquitectura

El proyecto implementa **Arquitectura Onion** con las siguientes capas:

```
Proyecto/
├── Domain/                 # Núcleo del dominio
│   ├── Entities/          # Entidades del negocio
│   └── Enums/             # Enumeraciones
├── Application/            # Lógica de aplicación
│   ├── DTOs/              # Data Transfer Objects
│   ├── Interfaces/        # Contratos de servicios y repositorios
│   └── Services/          # Implementación de servicios
├── Infrastructure/         # Acceso a datos
│   ├── Data/              # DbContext y configuraciones
│   └── Repositories/      # Implementación de repositorios
└── Components/            # Capa de presentación (Blazor)
    ├── Pages/             # Páginas Razor
    └── Layout/            # Componentes de layout
```

## Requisitos

- .NET 8 SDK
- SQL Server (LocalDB o instancia completa)
- Visual Studio 2022 o VS Code

## Configuración

### 1. Cadena de Conexión

Edita `appsettings.json` para configurar tu servidor SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SistemaDITIC;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 2. Crear la Base de Datos

Ejecuta los siguientes comandos en la terminal:

```powershell
# Restaurar paquetes
dotnet restore

# Crear migración inicial
dotnet ef migrations add MigracionInicial

# Aplicar migración y crear base de datos
dotnet ef database update
```

### 3. Ejecutar la Aplicación

```powershell
dotnet run
```

La aplicación estará disponible en: `https://localhost:5001` o `http://localhost:5000`

## Datos Iniciales

El sistema incluye datos semilla:

### Usuarios
- Admin Sistema (Técnico)
- Juan Pérez (Usuario)
- María García (Técnico - Soporte TI)

### Servicios DITIC
- Usuario Experto (L-V 8:00-17:00)
- Ingeniería de Soporte (L-S 7:00-19:00)
- Proveedor Externo (L-V 9:00-18:00)

## Tecnologías

- **Frontend**: Blazor Server
- **Backend**: ASP.NET Core 8
- **ORM**: Entity Framework Core 8
- **Base de Datos**: SQL Server
- **Arquitectura**: Onion Architecture
- **Patrón**: Repository Pattern
- **Inyección de Dependencias**: Built-in DI Container

## Próximas Mejoras

- [ ] Autenticación y autorización
- [ ] Dashboard con estadísticas
- [ ] Notificaciones por email
- [ ] Archivos adjuntos en incidentes
- [ ] Reportes y gráficas
- [ ] API REST para integración
- [ ] Sistema de comentarios en incidentes
- [ ] Historial de cambios
- [ ] SLA (Service Level Agreement) tracking

## Estructura de Datos

### Entidades Principales

- **Incidente**: Registro de problemas reportados
- **BaseConocimiento**: Artículos con soluciones
- **Usuario**: Usuarios del sistema (estudiantes y técnicos)
- **ServicioDITIC**: Niveles de servicio con horarios

## Autor

Sistema desarrollado para gestión de incidentes universitarios.
