# 🎫 Sistema de Gestión de Incidentes y Base de Conocimiento

Sistema completo de gestión de incidentes con base de conocimiento integrada, desarrollado con Blazor Server, .NET 8, Arquitectura Onion y SQL Server. Diseñado para instituciones educativas con soporte técnico multinivel.

## ✨ Características Principales

### 📋 Gestión de Incidentes
- **Reportes de usuarios**: Los estudiantes pueden crear y dar seguimiento a sus incidentes
- **Sistema de prioridades**: Baja, Media, Alta y Crítica
- **Flujo de estados**: Abierto → Asignado → Escalado → Resuelto/Descartado
- **Asignación inteligente**: Asignación a técnicos según nivel y especialidad
- **Escalamiento multinivel**: 4 niveles técnicos + administrador
- **Sistema de etiquetas**: Clasificación y búsqueda por categorías
- **Límite de incidentes activos**: Control de 3 incidentes máximo por estudiante
- **Descarte de incidentes**: Cierre administrativo con justificación

### 💡 Base de Conocimiento
- **Artículos de soluciones**: Documentación de problemas comunes y sus resoluciones
- **Búsqueda inteligente**: Por título, descripción y etiquetas
- **Sugerencias automáticas**: Soluciones relacionadas mostradas al resolver incidentes
- **Gestión completa**: Crear, editar y eliminar artículos (solo técnicos/admin)

### 👥 Sistema de Usuarios
- **Estudiantes (Nivel 0)**: Crear y consultar sus incidentes
- **Técnicos (Niveles 1-4)**: 
  - Ver incidentes asignados
  - Resolver problemas
  - Escalar a nivel superior
  - Gestionar base de conocimiento
- **Administrador (Nivel 5)**:
  - Asignar incidentes a técnicos
  - Resolver directamente
  - Descartar incidentes
  - Acceso total a base de conocimiento

## 🏗️ Arquitectura

Implementa **Arquitectura Onion** (Clean Architecture) garantizando separación de responsabilidades:

```
Proyecto/
├── src/
│   ├── Domain/                  # Capa de Dominio (Núcleo)
│   │   ├── Entities/           # Entidades del negocio
│   │   └── Enums/              # Enumeraciones
│   ├── Application/             # Capa de Aplicación
│   │   ├── DTOs/               # Data Transfer Objects
│   │   ├── Interfaces/         # Contratos
│   │   └── Services/           # Lógica de negocio
│   └── Infrastructure/          # Capa de Infraestructura
│       ├── Data/               # DbContext y configuraciones EF
│       ├── Repositories/       # Acceso a datos
│       └── Services/           # Servicios externos
└── Components/                  # Capa de Presentación (Blazor)
    ├── Pages/                  # Páginas Razor
    └── Layout/                 # Componentes de layout
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
| Admin Sistema | admin@universidad.edu | Admin123! | Administrador | 5 |
| Carlos Técnico | carlos@universidad.edu | Tecnico123! | Técnico Nivel 1 | 1 |
| Ana López | ana@universidad.edu | Tecnico123! | Técnico Nivel 2 | 2 |
| Luis Martín | luis@universidad.edu | Tecnico123! | Técnico Nivel 3 | 3 |
| Pedro Sánchez | pedro@universidad.edu | Tecnico123! | Técnico Nivel 4 | 4 |
| Juan Estudiante | juan@universidad.edu | Estudiante123! | Estudiante | 0 |
| María García | maria@universidad.edu | Estudiante123! | Estudiante | 0 |

## 📖 Guía de Uso Rápida

### Como Estudiante
1. Inicia sesión con tu cuenta
2. Haz clic en **"Reportar Incidente"**
3. Completa el formulario (título, descripción, prioridad, etiquetas)
4. Da seguimiento al estado de tu incidente
5. Máximo 3 incidentes activos simultáneamente

### Como Técnico
1. Inicia sesión con cuenta de técnico
2. Ve tus incidentes asignados en la lista
3. Haz clic en **"Ver"** para revisar detalles
4. **Resolver**: Marca como resuelto con descripción de solución
5. **Escalar**: Envía a nivel superior si no puedes resolverlo
6. Consulta/crea artículos en **Base de Conocimiento**

### Como Administrador
1. Accede con cuenta de administrador
2. Ve TODOS los incidentes del sistema
3. **Asignar**: Selecciona nivel y técnico específico
4. **Resolver**: Soluciona directamente si es necesario
5. **Descartar**: Cierra incidentes duplicados/irrelevantes con justificación
6. Administra la base de conocimiento completa

## 🛠️ Tecnologías Utilizadas

| Categoría | Tecnología |
|-----------|-----------|
| **Frontend** | Blazor Server, Bootstrap 5, Font Awesome |
| **Backend** | ASP.NET Core 8, C# 12 |
| **Base de Datos** | SQL Server, Entity Framework Core 8 |
| **Arquitectura** | Onion Architecture (Clean Architecture) |
| **Patrones** | Repository Pattern, Dependency Injection, DTO Pattern |
| **Autenticación** | Session Storage (navegador) |

## 📊 Modelo de Datos

### Entidades Principales

- **Incidente**: Tickets reportados con seguimiento completo
- **BaseConocimiento**: Artículos de soluciones documentadas
- **Usuario**: Estudiantes, técnicos y administradores
- **Etiqueta**: Categorización de incidentes y artículos
- **Prioridad**: Niveles de urgencia

### Estados de Incidentes

- 🟦 **Abierto**: Recién creado, sin asignar
- 🟩 **Asignado**: Asignado a un técnico
- 🟨 **Escalado**: Enviado a nivel superior
- ✅ **Resuelto**: Problema solucionado
- ⚫ **Descartado**: Cerrado administrativamente

## 🔄 Flujo de Trabajo

```
Estudiante crea incidente
         ↓
    [Abierto]
         ↓
Admin asigna → [Asignado] → Técnico recibe
         ↓                       ↓
    Resuelve              ¿Puede resolver?
         ↓                       ↓
    [Resuelto]         No → [Escalado] → Nivel superior
                                ↓
                           [Resuelto]
```

## 🤝 Contribuciones

Este es un proyecto educativo. Si deseas contribuir:

1. Haz fork del repositorio
2. Crea una rama para tu feature (`git checkout -b feature/NuevaCaracteristica`)
3. Commit tus cambios (`git commit -m 'Agregar nueva característica'`)
4. Push a la rama (`git push origin feature/NuevaCaracteristica`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto es de código abierto para propósitos educativos.

## 📧 Contacto

Para preguntas o sugerencias, abre un issue en el repositorio.

---

**Desarrollado con ❤️ para gestión eficiente de incidentes técnicos**
