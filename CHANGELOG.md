# 📝 Changelog

Todos los cambios notables en este proyecto serán documentados en este archivo.

El formato está basado en [Keep a Changelog](https://keepachangelog.com/es-ES/1.0.0/),
y este proyecto adhiere a [Semantic Versioning](https://semver.org/lang/es/).

## [1.0.0] - 2025-12-08

### 🎉 Versión Inicial

#### ✨ Agregado
- **Sistema completo de gestión de incidentes**
  - Crear, asignar, resolver, escalar y descartar incidentes
  - Sistema de prioridades (Baja, Media, Alta, Crítica)
  - Estados de seguimiento (Abierto, Asignado, En Proceso, Escalado, Resuelto, Descartado)
  - Límite de 3 incidentes activos por estudiante
  
- **Base de conocimiento integrada**
  - Crear y gestionar artículos de soluciones
  - Búsqueda por título, descripción y etiquetas
  - Sugerencias automáticas al resolver incidentes
  - Vinculación entre incidentes resueltos y artículos
  
- **Sistema de notificaciones en tiempo real**
  - SignalR WebSocket para comunicación bidireccional
  - Notificaciones instantáneas de asignación, escalamiento, resolución y descarte
  - Campana de notificaciones con contador de no leídas
  - Persistencia de hasta 50 notificaciones por usuario
  - Auto-actualización de tablas sin recargar página
  
- **Gestión de usuarios multinivel**
  - Estudiantes (Nivel 0): Crear y consultar incidentes
  - Técnicos (Niveles 1-4): Resolver y escalar incidentes
  - Administrador (Nivel 5): Control total del sistema
  - Autenticación con BCrypt para hashing seguro
  
- **Arquitectura Onion (Clean Architecture)**
  - Capa Domain: Entidades y enums
  - Capa Application: Lógica de negocio, DTOs, interfaces
  - Capa Infrastructure: Repositorios, hubs, servicios externos
  - Capa Presentation: Componentes Blazor Server
  
- **Gestión de sesiones por CircuitId**
  - ID único por pestaña del navegador
  - Aislamiento de sesiones entre pestañas
  - SessionService circuit-scoped
  - Detección automática de usuario logueado
  
- **Interfaz de usuario con Blazor Server**
  - Bootstrap 5 para diseño responsive
  - Font Awesome para iconografía
  - Componentes interactivos sin JavaScript manual
  - Modales para acciones de incidentes
  
- **Base de datos SQL Server con Entity Framework Core**
  - Migraciones automáticas
  - Lazy loading de relaciones
  - Datos semilla (seed) para desarrollo
  - Índices optimizados en columnas clave

#### 🔧 Características Técnicas
- **SignalR Hub** (`NotificacionHub`) para eventos en tiempo real
- **Repository Pattern** para acceso a datos
- **Dependency Injection** en toda la aplicación
- **DTO Pattern** para transferencia de datos
- **Circuit Handlers** personalizados para debugging
- **Logging detallado** en consola (Development)
- **Email Service** (mock para desarrollo)

#### 📦 Dependencias Principales
- .NET 8.0
- ASP.NET Core 8.0
- Entity Framework Core 8.0.0
- Microsoft.EntityFrameworkCore.SqlServer 8.0.0
- Microsoft.AspNetCore.SignalR.Client 8.0.11
- BCrypt.Net-Next 4.0.3
- Bootstrap 5.3
- Font Awesome 6.0

#### 🎨 UI/UX
- Dashboard personalizado por rol de usuario
- Lista de incidentes con estados visuales (colores/iconos)
- Formularios de creación con validación
- Modales para acciones rápidas (asignar, resolver, escalar, descartar)
- Notificaciones tipo toast con colores según tipo
- Campana de notificaciones con dropdown
- Barra lateral con información del usuario
- Diseño responsive (Bootstrap)

#### 🗃️ Base de Datos
- Tabla `Incidentes` con relaciones a Usuarios y Etiquetas
- Tabla `BaseConocimiento` con relaciones a Etiquetas
- Tabla `Usuarios` con niveles jerárquicos (0-5)
- Tabla `Etiquetas` para clasificación
- Tabla `Servicios` para categorización técnica
- Relaciones many-to-many con tablas intermedias

#### 📝 Documentación
- README.md completo con instalación y uso
- ARQUITECTURA.md con detalles técnicos
- CONTRIBUTING.md con guías de contribución
- Este CHANGELOG.md

### 🐛 Problemas Conocidos
- SignalR: Actualización en tiempo real para estudiantes puede fallar en algunos escenarios
- Email Service: Actualmente es un mock, no envía emails reales

### 🔮 Mejoras Futuras Planeadas
- [ ] Implementar autenticación JWT
- [ ] Configurar SMTP real para emails
- [ ] Agregar sistema de adjuntar archivos
- [ ] Dashboard con estadísticas y gráficas
- [ ] Tests unitarios y de integración
- [ ] Sistema de comentarios en incidentes
- [ ] Exportar reportes a PDF/Excel
- [ ] API REST para integración externa
- [ ] Optimización para dispositivos móviles
- [ ] Internacionalización (i18n)

---

## Formato de Cambios

- `✨ Agregado` - Nuevas funcionalidades
- `🔧 Cambiado` - Cambios en funcionalidades existentes
- `🗑️ Deprecado` - Funcionalidades que se eliminarán pronto
- `❌ Eliminado` - Funcionalidades eliminadas
- `🐛 Corregido` - Corrección de bugs
- `🔒 Seguridad` - Correcciones de vulnerabilidades

[1.0.0]: https://github.com/tu-usuario/Sistema-Gestion-de-Incidentes/releases/tag/v1.0.0
