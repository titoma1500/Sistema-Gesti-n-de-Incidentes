# 📋 Sistema de Gestión de Incidentes - Estructura del Proyecto

## 👥 División del Trabajo (3 Personas)

### 👤 Persona 1: Backend & Base de Datos
**Responsabilidades:**
- Capa de Dominio (Entities, Enums)
- Capa de Infraestructura (DbContext, Repositories)
- Base de Datos (Migraciones, Configuración)
- Sistema de notificaciones por email

**Carpetas asignadas:**
- `src/Domain/`
- `src/Infrastructure/`
- `database/`

---

### 👤 Persona 2: Lógica de Negocio & Servicios
**Responsabilidades:**
- Capa de Aplicación (Services, DTOs, Interfaces)
- Lógica de asignación de incidentes
- Lógica de escalamiento entre niveles
- Búsqueda en base de conocimiento

**Carpetas asignadas:**
- `src/Application/`
- `docs/business-logic/`

---

### 👤 Persona 3: Frontend (Blazor)
**Responsabilidades:**
- Todas las páginas Blazor
- Componentes de UI
- Formularios y validaciones
- Diseño y estilos

**Carpetas asignadas:**
- `src/Web/Components/`
- `src/Web/wwwroot/`
- `docs/ui-design/`

---

## 📁 Estructura de Carpetas del Proyecto

```
Proyecto/
│
├── src/                              # Código fuente
│   ├── Domain/                       # 👤 Persona 1
│   │   ├── Entities/                 # Entidades del dominio
│   │   │   ├── Usuario.cs
│   │   │   ├── Incidente.cs
│   │   │   ├── BaseConocimiento.cs
│   │   │   └── Notificacion.cs
│   │   ├── Enums/                    # Enumeraciones
│   │   │   ├── NivelUsuario.cs
│   │   │   ├── EstadoIncidente.cs
│   │   │   ├── PrioridadIncidente.cs
│   │   │   └── TipoNotificacion.cs
│   │   └── ValueObjects/             # Objetos de valor
│   │       └── Email.cs
│   │
│   ├── Application/                  # 👤 Persona 2
│   │   ├── DTOs/                     # Data Transfer Objects
│   │   │   ├── Auth/
│   │   │   ├── Incidentes/
│   │   │   ├── BaseConocimiento/
│   │   │   └── Usuarios/
│   │   ├── Interfaces/               # Contratos
│   │   │   ├── IIncidenteService.cs
│   │   │   ├── IBaseConocimientoService.cs
│   │   │   ├── IUsuarioService.cs
│   │   │   ├── IAuthService.cs
│   │   │   └── IEmailService.cs
│   │   ├── Services/                 # Implementación de servicios
│   │   │   ├── IncidenteService.cs
│   │   │   ├── BaseConocimientoService.cs
│   │   │   ├── UsuarioService.cs
│   │   │   └── EscalamientoService.cs
│   │   └── Validators/               # Validaciones
│   │       └── IncidenteValidator.cs
│   │
│   ├── Infrastructure/               # 👤 Persona 1
│   │   ├── Data/                     # Acceso a datos
│   │   │   ├── ApplicationDbContext.cs
│   │   │   └── Configurations/       # Configuraciones EF
│   │   ├── Repositories/             # Implementación de repositorios
│   │   │   ├── IncidenteRepository.cs
│   │   │   ├── BaseConocimientoRepository.cs
│   │   │   └── UsuarioRepository.cs
│   │   └── Services/                 # Servicios de infraestructura
│   │       ├── EmailService.cs       # Envío de emails
│   │       └── NotificacionService.cs
│   │
│   └── Web/                          # 👤 Persona 3
│       ├── Components/               # Componentes Blazor
│       │   ├── Pages/                # Páginas principales
│       │   │   ├── Auth/
│       │   │   │   └── Login.razor
│       │   │   ├── Incidentes/
│       │   │   │   ├── Index.razor
│       │   │   │   ├── Crear.razor
│       │   │   │   ├── Detalle.razor
│       │   │   │   └── MisIncidentes.razor
│       │   │   ├── BaseConocimiento/
│       │   │   │   ├── Index.razor
│       │   │   │   ├── Buscar.razor
│       │   │   │   └── Detalle.razor
│       │   │   ├── Admin/
│       │   │   │   ├── Dashboard.razor
│       │   │   │   └── AsignarIncidentes.razor
│       │   │   └── Home.razor
│       │   ├── Shared/               # Componentes compartidos
│       │   │   ├── IncidenteCard.razor
│       │   │   ├── EtiquetaComponent.razor
│       │   │   ├── BuscadorBase.razor
│       │   │   └── NotificacionToast.razor
│       │   └── Layout/               # Layouts
│       │       ├── MainLayout.razor
│       │       ├── NavMenu.razor
│       │       └── AdminLayout.razor
│       └── wwwroot/                  # Archivos estáticos
│           ├── css/
│           ├── js/
│           └── images/
│
├── database/                         # 👤 Persona 1
│   ├── migrations/                   # Scripts de migración
│   ├── seeds/                        # Datos iniciales
│   │   ├── usuarios.sql
│   │   ├── etiquetas.sql
│   │   └── base-conocimiento.sql
│   └── scripts/                      # Scripts útiles
│       └── backup.sql
│
├── docs/                             # Documentación
│   ├── business-logic/               # 👤 Persona 2
│   │   ├── flujo-incidentes.md
│   │   ├── escalamiento.md
│   │   └── reglas-negocio.md
│   ├── ui-design/                    # 👤 Persona 3
│   │   ├── wireframes/
│   │   ├── mockups/
│   │   └── guia-estilos.md
│   ├── api/                          # Común
│   │   └── endpoints.md
│   └── setup/                        # Común
│       ├── instalacion.md
│       └── configuracion.md
│
├── tests/                            # Tests (compartido)
│   ├── Domain.Tests/
│   ├── Application.Tests/
│   └── Web.Tests/
│
├── .github/                          # GitHub workflows
│   ├── workflows/
│   │   └── dotnet.yml
│   └── PULL_REQUEST_TEMPLATE.md
│
├── Proyecto.sln                      # Solución de Visual Studio
├── .gitignore
├── README.md                         # Documentación principal
└── DIVISION_TRABAJO.md               # Este archivo
```

---

## 🔄 Flujo de Trabajo con Git/GitHub

### Estrategia de Ramas

```
main (producción)
  └── develop (desarrollo)
        ├── feature/backend-entities          # Persona 1
        ├── feature/application-services      # Persona 2
        └── feature/blazor-pages              # Persona 3
```

### Pasos para Cada Persona

1. **Clonar el repositorio**
```bash
git clone <url-repositorio>
cd Proyecto
```

2. **Crear rama de trabajo**
```bash
# Persona 1
git checkout -b feature/backend-entities

# Persona 2
git checkout -b feature/application-services

# Persona 3
git checkout -b feature/blazor-pages
```

3. **Trabajar en su área asignada**
4. **Hacer commits frecuentes**
```bash
git add .
git commit -m "descripción del cambio"
```

5. **Push a GitHub**
```bash
git push origin nombre-de-tu-rama
```

6. **Crear Pull Request en GitHub**
7. **Revisión de código por otros miembros**
8. **Merge a develop**

---

## 📝 Tareas Iniciales por Persona

### 👤 Persona 1: Backend & Base de Datos

**Semana 1:**
- [ ] Crear entidades: Usuario, Incidente, BaseConocimiento, Notificacion
- [ ] Crear enums: NivelUsuario, EstadoIncidente, PrioridadIncidente
- [ ] Configurar DbContext con relaciones
- [ ] Crear migraciones iniciales
- [ ] Implementar repositorios básicos

**Entidades a crear:**
```
Usuario
- Id, Nombre, Email, Password (hash), Nivel (1-4), FechaRegistro

Incidente
- Id, Titulo, Descripcion, Estado, Prioridad, Etiquetas
- UsuarioReportaId, UsuarioAsignadoId, FechaCreacion, FechaSolucion
- MensajeSolucion, MensajeEscalamiento

BaseConocimiento
- Id, Titulo, Descripcion, Solucion, Etiquetas
- FechaCreacion, VecesConsultada

Etiqueta
- Id, Nombre, Categoria (Hardware, Software, Red, etc.)
```

---

### 👤 Persona 2: Lógica de Negocio & Servicios

**Semana 1:**
- [ ] Crear DTOs para todas las operaciones
- [ ] Definir interfaces de servicios
- [ ] Implementar IncidenteService (crear, asignar, escalar)
- [ ] Implementar BaseConocimientoService (buscar por etiquetas)
- [ ] Implementar lógica de escalamiento automático

**Servicios clave:**
```
IIncidenteService
- CrearIncidente(dto)
- AsignarIncidente(incidenteId, usuarioId)
- EscalarIncidente(incidenteId, mensaje, nuevoNivel)
- ResolverIncidente(incidenteId, solucion)
- BuscarPorEstado(estado)

IBaseConocimientoService
- BuscarPorEtiquetas(etiquetas)
- BuscarPorTexto(texto)
- CrearArticulo(dto)
- IncrementarConsultas(id)
```

---

### 👤 Persona 3: Frontend (Blazor)

**Semana 1:**
- [ ] Crear página de Login
- [ ] Crear página de listado de incidentes
- [ ] Crear formulario de crear incidente con etiquetas
- [ ] Crear página de detalle de incidente
- [ ] Crear buscador de base de conocimiento
- [ ] Diseñar componentes reutilizables (cards, etiquetas)

**Páginas principales:**
```
Login.razor
- Formulario de autenticación
- Validación de credenciales

Incidentes/Index.razor
- Lista de incidentes (admin ve todos, usuario ve asignados)
- Filtros por estado, prioridad, etiquetas
- Botón crear nuevo incidente

Incidentes/Crear.razor
- Formulario con: Título, Descripción, Prioridad
- Selector de etiquetas (múltiple)
- Botón enviar

Incidentes/Detalle.razor
- Info completa del incidente
- Buscador de base de conocimiento
- Botón resolver / escalar (según nivel usuario)
- Formulario de solución o escalamiento

BaseConocimiento/Buscar.razor
- Buscador por etiquetas y texto
- Lista de artículos relevantes
- Vista previa de soluciones
```

---

## 🔗 Dependencias entre Personas

### Orden de Desarrollo Recomendado

1. **Persona 1** empieza primero (1-2 días de ventaja)
   - Crea entidades y base de datos
   - Define contratos (interfaces) básicos

2. **Persona 2** espera las entidades
   - Implementa servicios usando las entidades de Persona 1
   - Define DTOs basados en entidades

3. **Persona 3** puede empezar en paralelo
   - Trabaja en el diseño visual
   - Crea componentes estáticos
   - Integra servicios cuando estén listos (Persona 2)

---

## 🤝 Puntos de Integración

### Interfaces Compartidas (Contratos)

Todas las personas deben acordar estos contratos:

```csharp
// Persona 1 define, Persona 2 usa en Application
public interface IIncidenteRepository 
{
    Task<Incidente> ObtenerPorIdAsync(int id);
    Task<IEnumerable<Incidente>> ObtenerTodosAsync();
    // ...
}

// Persona 2 define, Persona 3 usa en Blazor
public interface IIncidenteService
{
    Task<IncidenteDto> CrearAsync(CrearIncidenteDto dto);
    Task AsignarAsync(int id, int usuarioId);
    // ...
}
```

---

## 📧 Sistema de Notificaciones (Persona 1)

**Implementar EmailService para:**
- Notificar asignación de incidente
- Notificar escalamiento de incidente
- Notificar resolución de incidente

**Configuración en appsettings.json:**
```json
{
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "SenderEmail": "sistema@universidad.edu",
    "SenderPassword": "******",
    "EnableSsl": true
  }
}
```

---

## 🏷️ Sistema de Etiquetas

**Categorías sugeridas:**
- Hardware (impresora, computadora, mouse, etc.)
- Software (office, navegador, antivirus, etc.)
- Red (wifi, ethernet, vpn, etc.)
- Sistema Operativo (windows, linux, mac, etc.)
- Seguridad (contraseña, virus, acceso, etc.)

---

## 📊 Niveles de Usuario

```
Nivel 1: Usuario Regular
- Reporta incidentes
- Ve solo sus incidentes
- No puede asignar ni escalar

Nivel 2: Soporte Básico
- Ve incidentes asignados a él
- Puede resolver o escalar a Nivel 3
- Busca en base de conocimiento

Nivel 3: Soporte Avanzado
- Ve incidentes de Nivel 2 y 3
- Puede resolver o escalar a Nivel 4
- Puede crear artículos en base de conocimiento

Nivel 4: Administrador
- Ve TODOS los incidentes
- Asigna incidentes a cualquier nivel
- Gestiona base de conocimiento
- Dashboard con estadísticas
```

---

## ✅ Checklist de Inicio

### Configuración Inicial (Todos)
- [ ] Clonar repositorio
- [ ] Instalar .NET 8 SDK
- [ ] Instalar SQL Server
- [ ] Configurar Git (nombre, email)
- [ ] Crear rama de trabajo personal
- [ ] Leer documentación completa

### Primera Reunión de Equipo
- [ ] Acordar convenciones de código (naming, estructura)
- [ ] Definir interfaces compartidas
- [ ] Establecer horario de stand-ups diarios
- [ ] Configurar canal de comunicación (Discord/Slack)
- [ ] Definir estrategia de Pull Requests

---

## 📅 Timeline Sugerido (3 Semanas)

**Semana 1: Fundación**
- Persona 1: Entidades y base de datos ✅
- Persona 2: Interfaces y DTOs básicos ✅
- Persona 3: Login y estructura de páginas ✅

**Semana 2: Integración**
- Persona 1: Servicio de email y notificaciones ✅
- Persona 2: Servicios completos (crear, asignar, escalar) ✅
- Persona 3: Formularios funcionales y base de conocimiento ✅

**Semana 3: Refinamiento**
- Todos: Integración final ✅
- Todos: Testing y corrección de bugs ✅
- Todos: Documentación y presentación ✅

---

## 🎯 Entregables Finales

- [ ] Sistema de login funcional
- [ ] CRUD completo de incidentes
- [ ] Sistema de asignación (admin a técnicos)
- [ ] Sistema de escalamiento entre niveles
- [ ] Base de conocimiento con búsqueda por etiquetas
- [ ] Notificaciones por email
- [ ] Dashboard administrativo
- [ ] Documentación técnica
- [ ] Manual de usuario

---

**Fecha de inicio:** Definir
**Fecha de entrega:** Definir
**Reuniones:** Definir (sugerido: 2 por semana)
