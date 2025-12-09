# 🎫 Sistema de Gestión de Incidentes y Base de Conocimiento

Sistema completo de gestión de incidentes con base de conocimiento integrada, notificaciones en tiempo real y gestión de sesiones por circuito. Desarrollado con Blazor Server, .NET 8, SignalR, Arquitectura Onion y SQL Server. Diseñado para instituciones educativas con soporte técnico multinivel.

## ✨ Características Principales

### 📋 Gestión de Incidentes
- **Reportes de usuarios**: Los estudiantes pueden crear y dar seguimiento a sus incidentes
- **Sistema de prioridades**: Baja, Media, Alta y Crítica
- **Flujo de estados**: Abierto → Asignado → En Proceso → Escalado → Resuelto/Descartado
- **Asignación inteligente**: Asignación a técnicos según nivel y especialidad
- **Escalamiento multinivel**: 4 niveles técnicos + administrador
- **Sistema de etiquetas**: Clasificación y búsqueda por categorías
- **Límite de incidentes activos**: Control de 3 incidentes máximo por estudiante
- **Descarte de incidentes**: Cierre administrativo con justificación
- **Actualización en tiempo real**: Los cambios se reflejan automáticamente en todos los usuarios conectados

### 🔔 Sistema de Notificaciones en Tiempo Real
- **SignalR WebSocket**: Comunicación bidireccional en tiempo real
- **Notificaciones instantáneas**: 
  - 🔵 Asignación de incidentes (info)
  - 🟠 Escalamiento (warning)
  - 🟢 Resolución (success)
  - 🔴 Descarte (danger)
  - 🆕 Creación de nuevos incidentes (info)
- **Campana de notificaciones**: Icono 🔔 con contador de notificaciones no leídas
- **Persistencia**: Hasta 50 notificaciones por usuario en memoria
- **Auto-actualización**: Las tablas de incidentes se actualizan automáticamente sin recargar

### 💡 Base de Conocimiento
- **Artículos de soluciones**: Documentación de problemas comunes y sus resoluciones
- **Búsqueda inteligente**: Por título, descripción y etiquetas
- **Sugerencias automáticas**: Soluciones relacionadas mostradas al resolver incidentes
- **Gestión completa**: Crear y eliminar artículos (solo admin)
- **Vinculación**: Relación entre incidentes resueltos y artículos de conocimiento

### 👥 Sistema de Usuarios Multinivel
- **Estudiantes (Nivel 0)**: 
  - Crear y consultar sus incidentes
  - Recibir notificaciones de cambios en sus tickets
  - Ver estado y seguimiento en tiempo real
  
- **Técnicos (Niveles 1-4)**: 
  - Ver incidentes asignados
  - Resolver problemas
  - Escalar a nivel superior cuando necesario
  - Recibir notificaciones de asignaciones
  - Gestionar base de conocimiento
  
- **Administrador (Nivel 5)**:
  - Asignar incidentes a técnicos específicos
  - Resolver directamente cualquier incidente
  - Descartar incidentes con justificación
  - Acceso total a base de conocimiento
  - Recibir notificaciones de nuevos incidentes

### 🔐 Gestión de Sesiones
- **CircuitId único**: Cada pestaña del navegador tiene su propia sesión aislada
- **Sesión por circuito**: Múltiples pestañas pueden tener sesiones diferentes
- **Detección automática**: La barra lateral aparece inmediatamente después del login
- **Persistencia de sesión**: Mantiene el usuario activo durante toda la conexión del circuito

## 🏗️ Arquitectura

Implementa **Arquitectura Onion** (Clean Architecture) garantizando separación de responsabilidades y fácil mantenimiento:

```
Proyecto/
├── src/
│   ├── Domain/                     # Capa de Dominio (Núcleo del negocio)
│   │   ├── Entities/              # Entidades del negocio
│   │   │   ├── Incidente.cs       # Tickets de soporte
│   │   │   ├── BaseConocimiento.cs # Artículos de KB
│   │   │   ├── Usuario.cs         # Usuarios del sistema
│   │   │   ├── Etiqueta.cs        # Tags para clasificación
│   │   │   └── Servicio.cs        # Servicios técnicos
│   │   └── Enums/                 # Enumeraciones
│   │       ├── EstadoIncidente.cs
│   │       └── PrioridadIncidente.cs
│   │
│   ├── Application/                # Capa de Aplicación (Lógica de negocio)
│   │   ├── DTOs/                  # Data Transfer Objects
│   │   │   ├── Auth/              # DTOs de autenticación
│   │   │   ├── Incidentes/        # DTOs de incidentes
│   │   │   └── BaseConocimiento/  # DTOs de KB
│   │   ├── Interfaces/            # Contratos de servicios
│   │   │   ├── IIncidenteService.cs
│   │   │   ├── IAuthService.cs
│   │   │   ├── ISessionService.cs
│   │   │   └── INotificacionService.cs
│   │   └── Services/              # Implementación de lógica de negocio
│   │       ├── IncidenteService.cs
│   │       ├── AuthService.cs
│   │       ├── SessionService.cs
│   │       └── NotificacionService.cs
│   │
│   └── Infrastructure/             # Capa de Infraestructura (Acceso externo)
│       ├── Data/                  # DbContext y configuraciones EF
│       │   └── ApplicationDbContext.cs
│       ├── Repositories/          # Acceso a datos
│       │   ├── IncidenteRepository.cs
│       │   ├── UsuarioRepository.cs
│       │   └── BaseConocimientoRepository.cs
│       ├── Hubs/                  # SignalR Hubs
│       │   └── NotificacionHub.cs # Hub de notificaciones en tiempo real
│       ├── Handlers/              # Circuit Handlers
│       │   ├── CircuitIdProvider.cs    # Proveedor de ID único por pestaña
│       │   └── LoggingCircuitHandler.cs
│       └── Services/              # Servicios externos
│           └── EmailService.cs    # Servicio de email
│
└── Components/                     # Capa de Presentación (UI Blazor)
    ├── Pages/                     # Páginas Razor
    │   ├── Auth/                  # Login y autenticación
    │   ├── Incidentes/            # Gestión de incidentes
    │   │   ├── Index.razor        # Lista de incidentes
    │   │   ├── Crear.razor        # Crear incidente
    │   │   └── Detalle.razor      # Detalles y acciones
    │   └── BaseConocimiento/      # KB
    │       ├── Index.razor        # Lista de artículos
    │       └── Crear.razor        # Crear artículo
    └── Layout/                    # Componentes de layout
        ├── MainLayout.razor       # Layout principal
        ├── NavMenu.razor          # Menú de navegación
        └── Notificaciones.razor   # Componente de notificaciones
```

### 🔄 Flujo de Datos

```
Usuario interactúa con UI (Blazor Component)
            ↓
    Llama a Service (Application Layer)
            ↓
    Service ejecuta lógica de negocio
            ↓
    Accede a Repository (Infrastructure Layer)
            ↓
    Repository consulta/modifica Base de Datos
            ↓
    Resultado regresa a través de DTOs
            ↓
    SignalR notifica a todos los clientes conectados
            ↓
    UI se actualiza automáticamente en tiempo real
```

## 🚀 Instalación y Configuración

### Requisitos Previos

- ✅ [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- ✅ SQL Server LocalDB (incluido con Visual Studio) o SQL Server completo
- ✅ Editor: Visual Studio 2022, VS Code o Rider

### Pasos de Instalación

#### 1️⃣ Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/Sistema-Gestion-de-Incidentes.git
cd Sistema-Gestion-de-Incidentes
```

#### 2️⃣ Configurar la cadena de conexión

Edita el archivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SistemaIncidentes;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

💡 **Nota**: Si usas SQL Server completo en lugar de LocalDB:
```json
"DefaultConnection": "Server=localhost;Database=SistemaIncidentes;Trusted_Connection=true;MultipleActiveResultSets=true"
```

#### 3️⃣ Restaurar dependencias

```bash
dotnet restore
```

#### 4️⃣ Aplicar migraciones y crear base de datos

```bash
dotnet ef database update
```

Este comando creará automáticamente:
- ✅ La base de datos
- ✅ Todas las tablas necesarias
- ✅ Datos semilla (usuarios, etiquetas, servicios)

#### 5️⃣ Ejecutar la aplicación

```bash
dotnet run
```

🌐 La aplicación estará disponible en: **http://localhost:5078**

## 👤 Usuarios de Prueba

El sistema incluye usuarios precargados para pruebas:

| Usuario | Email | Contraseña | Rol | Nivel |
|---------|-------|-----------|-----|-------|
| Admin Sistema | admin@universidad.edu | admin123 | Administrador | 5 |
| Carlos Técnico | carlos@universidad.edu | tecnico123 | Técnico Nivel 1 | 1 |
| Ana López | ana@universidad.edu | tecnico123 | Técnico Nivel 2 | 2 |
| Luis Martín | luis@universidad.edu | tecnico123 | Técnico Nivel 3 | 3 |
| Pedro Sánchez | pedro@universidad.edu | tecnico123 | Técnico Nivel 4 | 4 |
| Juan Estudiante | juan@universidad.edu | tecnico123 | Estudiante | 0 |
| María García | maria@universidad.edu | tecnico123 | Estudiante | 0 |

## 📖 Guía de Uso Rápida

### 🎓 Como Estudiante
1. Inicia sesión con tu cuenta de estudiante
2. En el dashboard, haz clic en **"Nuevo Incidente"**
3. Completa el formulario:
   - Título descriptivo del problema
   - Descripción detallada
   - Selecciona prioridad (Baja/Media/Alta/Crítica)
   - Agrega etiquetas relevantes
4. Envía el incidente y recibirás una confirmación
5. **Notificaciones en tiempo real**: Recibirás 🔔 cuando:
   - Tu incidente sea asignado a un técnico
   - El técnico lo escale a nivel superior
   - Tu incidente sea resuelto
   - Tu incidente sea descartado (con motivo)
6. Consulta el estado actual en tu lista de incidentes
7. **Límite**: Máximo 3 incidentes activos simultáneamente

### 🔧 Como Técnico
1. Inicia sesión con cuenta de técnico (Nivel 1-4)
2. En el dashboard verás **solo tus incidentes asignados**
3. Haz clic en el ícono 👁️ **"Ver"** para revisar detalles
4. **Acciones disponibles**:
   - ✅ **Resolver**: Agrega descripción de la solución
   - ⬆️ **Escalar**: Si no puedes resolverlo, envíalo a nivel superior
5. **Notificaciones**: Recibirás 🔔 cuando te asignen un incidente
6. **Base de Conocimiento**: 
   - Consulta artículos existentes antes de resolver
   - Crea nuevos artículos después de resolver problemas comunes
7. La tabla se actualiza automáticamente cuando hay cambios

### 👨‍💼 Como Administrador
1. Accede con cuenta de administrador (Nivel 5)
2. Dashboard muestra **TODOS los incidentes** del sistema
3. **Asignar incidente**:
   - Haz clic en ícono ➕ **"Asignar"**
   - Selecciona nivel técnico requerido (1-4)
   - Elige técnico específico de ese nivel
   - El técnico recibirá notificación instantánea
4. **Resolver directamente**:
   - Haz clic en ícono ✅ **"Resolver"**
   - Agrega descripción de solución
   - Opcional: vincula con artículo de KB
5. **Descartar incidente**:
   - Haz clic en ícono ✖️ **"Descartar"**
   - Escribe motivo obligatorio
   - Útil para duplicados o incidentes inválidos
6. **Notificaciones**: Recibirás 🔔 cuando se creen nuevos incidentes
7. **Administrar Base de Conocimiento**:
   - Crear nuevos artículos
   - Eliminar artículos obsoletos
   - Organizar por etiquetas

### 🔔 Sistema de Notificaciones

**Campana de Notificaciones** (esquina superior derecha):
- 🔔 amarillo con sombra (visible en modo claro y oscuro)
- **Badge rojo** muestra cantidad de notificaciones no leídas
- Haz clic para abrir dropdown con lista de notificaciones
- Cada notificación muestra:
  - 🔵 Info (asignación, creación)
  - 🟠 Warning (escalamiento)
  - 🟢 Success (resolución)
  - 🔴 Danger (descarte)
  - ⏰ Tiempo transcurrido
- **Marcar como leída**: Clic en cualquier notificación
- **Marcar todas como leídas**: Botón en header del dropdown

## 🛠️ Tecnologías Utilizadas

| Categoría | Tecnología | Versión |
|-----------|-----------|---------|
| **Frontend** | Blazor Server | .NET 8 |
| **UI Framework** | Bootstrap | 5.3 |
| **Iconos** | Font Awesome | 6.0 |
| **Backend** | ASP.NET Core | 8.0 |
| **Lenguaje** | C# | 12 |
| **Base de Datos** | SQL Server | 2019+ |
| **ORM** | Entity Framework Core | 8.0 |
| **Real-time** | SignalR | 8.0 |
| **Seguridad** | BCrypt.Net-Next | 4.0.3 |
| **Arquitectura** | Onion Architecture | - |
| **Patrones** | Repository, DI, DTO, CQRS | - |

### 📦 Paquetes NuGet Principales

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="8.0.0" />
<PackageReference Include="Microsoft.AspNetCore.SignalR.Client" Version="8.0.11" />
<PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
```

## 📊 Modelo de Datos

### Entidades Principales

**Incidente**
- Id, Titulo, Descripcion
- Prioridad (enum), Estado (enum)
- FechaCreacion, FechaResolucion
- UsuarioReportaId, UsuarioAsignadoId
- Resolucion, MotivoDescarte
- Relaciones: Usuario (reporta), Usuario (asignado), Etiquetas (many-to-many)

**BaseConocimiento**
- Id, Titulo, Descripcion, Solucion
- FechaCreacion
- Relaciones: Etiquetas (many-to-many)

**Usuario**
- Id, Nombre, Email, PasswordHash
- Nivel (0-5: Estudiante, Técnico 1-4, Admin)
- Relaciones: Incidentes reportados, Incidentes asignados

**Etiqueta**
- Id, Nombre
- Relaciones: Incidentes, Artículos de KB

**Servicio**
- Id, Nombre, Descripcion, NivelRequerido

**Notificacion** (en memoria)
- Id, UsuarioId, Mensaje, Tipo, Fecha, Leida

### Estados de Incidentes

| Estado | Icono | Descripción | Acciones Disponibles |
|--------|-------|-------------|---------------------|
| 🟦 **Abierto** | Nuevo | Recién creado, sin asignar | Asignar, Resolver, Descartar |
| 🟩 **Asignado** | En proceso | Asignado a un técnico | Resolver, Escalar, Descartar |
| 🟨 **En Proceso** | Trabajando | Técnico trabajando en solución | Resolver, Escalar |
| 🟠 **Escalado** | Nivel superior | Enviado a técnico de mayor nivel | Resolver |
| ✅ **Resuelto** | Completado | Problema solucionado | Ver detalles |
| ⚫ **Descartado** | Cerrado | Cerrado administrativamente | Ver detalles |

### Niveles de Prioridad

- 🟢 **Baja**: Problemas menores, sin impacto inmediato
- 🟡 **Media**: Problemas que requieren atención pronta
- 🟠 **Alta**: Problemas que afectan funcionalidad importante
- 🔴 **Crítica**: Problemas que impiden operación normal

## 🔄 Flujo de Trabajo

### Ciclo de Vida de un Incidente

```
📝 Estudiante crea incidente
         ↓
    [🟦 Abierto]
         ↓
    🔔 Admin recibe notificación
         ↓
    Admin asigna a técnico → [🟩 Asignado]
         ↓
    🔔 Técnico recibe notificación
         ↓
    Técnico evalúa el problema
         ↓
    ┌────────────┴────────────┐
    │                         │
¿Puede resolver?          ¿Necesita ayuda?
    │                         │
    ✓ Sí                      ✗ No
    ↓                         ↓
[✅ Resuelto]            [🟠 Escalado]
    ↓                         ↓
🔔 Estudiante           🔔 Técnico superior
   recibe                   recibe
   notificación             notificación
                            ↓
                       [✅ Resuelto]
                            ↓
                       🔔 Estudiante
                          recibe
                          notificación
```

### Flujo de Notificaciones en Tiempo Real

```
Usuario realiza acción (Asignar/Resolver/Escalar/Descartar)
                    ↓
        Blazor Component envía petición
                    ↓
            Service ejecuta lógica
                    ↓
        Repository actualiza BD
                    ↓
    ┌───────────────┴───────────────┐
    │                               │
NotificacionService             SignalR Hub
guarda notificación         envía evento broadcast
    │                               │
    └───────────────┬───────────────┘
                    ↓
        Todos los clientes conectados
                    ↓
    ┌───────────────┼───────────────┐
    │               │               │
Componente      Componente      Componente
Notificaciones    Index         Detalle
actualiza 🔔     recarga lista   actualiza vista
```

### Sistema de Permisos

| Acción | Estudiante | Técnico 1-4 | Admin |
|--------|-----------|-------------|-------|
| Crear incidente | ✅ (max 3) | ✅ | ✅ |
| Ver propios incidentes | ✅ | ✅ | ✅ |
| Ver todos incidentes | ❌ | ❌ | ✅ |
| Ver incidentes asignados | ❌ | ✅ | ✅ |
| Asignar incidente | ❌ | ❌ | ✅ |
| Resolver incidente | ❌ | ✅ (asignados) | ✅ (todos) |
| Escalar incidente | ❌ | ✅ | ❌ |
| Descartar incidente | ❌ | ❌ | ✅ |
| Crear artículo KB | ❌ | ✅ | ✅ |
| Eliminar artículo KB | ❌ | ❌ | ✅ |
| Recibir notificaciones | ✅ | ✅ | ✅ |

## 🎯 Características Técnicas Destacadas

### SignalR en Tiempo Real
- **WebSocket persistente**: Conexión bidireccional constante
- **Reconexión automática**: Si se pierde conexión, se reintenta automáticamente
- **Broadcast a todos**: Los eventos se envían a todos los usuarios conectados
- **Listeners específicos**: Cada componente escucha solo los eventos relevantes
- **Logging detallado**: Console logs para debugging (ConnectionId, eventos, etc.)

### Gestión de Sesiones por CircuitId
- **CircuitIdProvider**: Genera ID único por cada pestaña del navegador
- **SessionService**: Almacena usuario actual usando CircuitId como clave
- **Aislamiento de sesiones**: Múltiples pestañas pueden tener usuarios diferentes
- **Detección automática**: Timer verifica sesión hasta que usuario esté disponible
- **Cleanup automático**: Sesiones se limpian al cerrar pestaña

### Seguridad
- **BCrypt**: Hash seguro de contraseñas con salt automático
- **Validación de permisos**: Cada acción valida nivel de usuario
- **UsuarioActualId explícito**: Evita manipulación de DTOs
- **Circuit-scoped services**: Servicios aislados por circuito de Blazor

### Optimizaciones
- **Lazy Loading**: Entity Framework carga relaciones bajo demanda
- **DTOs optimizados**: Transferencia solo de datos necesarios
- **In-memory notifications**: NotificacionService usa ConcurrentDictionary
- **Índices en BD**: Queries optimizadas con índices en columnas clave
- **Logging condicional**: Logs detallados solo en Development

### Manejo de Errores
- **Try-catch estratégico**: Captura excepciones sin bloquear flujo
- **Logging completo**: Console logs con prefijos identificables
- **Email fallback**: Si email falla, continúa ejecución normalmente
- **Validaciones robustas**: Verificación de permisos antes de cada acción

## 🤝 Contribuciones

Este es un proyecto educativo. Si deseas contribuir:

1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/NuevaCaracteristica`)
3. Haz commit de tus cambios (`git commit -m 'Agregar: descripción de cambios'`)
4. Push a la rama (`git push origin feature/NuevaCaracteristica`)
5. Abre un Pull Request con descripción detallada

### Áreas de Mejora Sugeridas
- ✨ Implementar autenticación JWT
- 📧 Configurar servicio de email real (SMTP)
- 🔍 Agregar filtros avanzados y búsqueda
- 📊 Dashboard con estadísticas y gráficas
- 📱 Optimización para móviles
- 🌐 Internacionalización (i18n)
- 🧪 Tests unitarios y de integración
- 📁 Adjuntar archivos a incidentes
- 💬 Sistema de comentarios en incidentes
- 📈 Reportes y exportación de datos

## 📄 Licencia

Este proyecto es de código abierto para propósitos educativos. Se permite usar, modificar y distribuir libremente.

## 🐛 Problemas Conocidos

- **SignalR en estudiantes**: La actualización en tiempo real para estudiantes puede no funcionar en todos los escenarios (funciona correctamente para admins y técnicos)
- **Email Service**: Actualmente es un mock, no envía emails reales

## 📧 Contacto y Soporte

- 🐛 **Reportar bugs**: Abre un issue en GitHub
- 💡 **Sugerencias**: Pull requests son bienvenidos
- 📖 **Documentación**: Consulta ARQUITECTURA.md para detalles técnicos

## 🙏 Agradecimientos

Desarrollado como proyecto educativo para aprender:
- Arquitectura Onion/Clean Architecture
- Blazor Server y SignalR
- Entity Framework Core
- Patrones de diseño (Repository, DI, DTO)

---

**Desarrollado con ❤️ usando .NET 8 y Blazor Server**

💻 **Stack**: Blazor Server | SignalR | EF Core | SQL Server | Bootstrap 5
