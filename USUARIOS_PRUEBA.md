# 👤 Usuarios de Prueba

El sistema incluye usuarios precargados para facilitar las pruebas de cada rol.

## 🔑 Credenciales de Acceso

### 🛡️ Administrador (Nivel 5)
```
Email: admin@universidad.edu
Contraseña: Admin123!
```
**Permisos:**
- ✅ Ver todos los incidentes del sistema
- ✅ Asignar incidentes a técnicos específicos
- ✅ Resolver incidentes directamente
- ✅ Descartar incidentes con justificación
- ✅ Gestión completa de Base de Conocimiento

---

### ⚙️ Técnico Nivel 4 (Pedro Sánchez)
```
Email: pedro@universidad.edu
Contraseña: Tecnico123!
```
**Permisos:**
- ✅ Ver incidentes asignados a él
- ✅ Resolver incidentes
- ❌ No puede escalar (es el nivel más alto de técnicos)
- ✅ Gestionar Base de Conocimiento

---

### ⚙️ Técnico Nivel 3 (Luis Martín)
```
Email: luis@universidad.edu
Contraseña: Tecnico123!
```
**Permisos:**
- ✅ Ver incidentes asignados
- ✅ Resolver incidentes
- ✅ Escalar a Nivel 4
- ✅ Gestionar Base de Conocimiento

---

### ⚙️ Técnico Nivel 2 (Ana López)
```
Email: ana@universidad.edu
Contraseña: Tecnico123!
```
**Permisos:**
- ✅ Ver incidentes asignados
- ✅ Resolver incidentes
- ✅ Escalar a Nivel 3 o 4
- ✅ Gestionar Base de Conocimiento

---

### ⚙️ Técnico Nivel 1 (Carlos Técnico)
```
Email: carlos@universidad.edu
Contraseña: Tecnico123!
```
**Permisos:**
- ✅ Ver incidentes asignados
- ✅ Resolver incidentes
- ✅ Escalar a niveles superiores (2, 3 o 4)
- ✅ Gestionar Base de Conocimiento

---

### 🎓 Estudiante 1 (Juan Estudiante)
```
Email: juan@universidad.edu
Contraseña: Estudiante123!
```
**Permisos:**
- ✅ Crear nuevos incidentes (máximo 3 activos)
- ✅ Ver solo sus propios incidentes
- ❌ No puede acceder a Base de Conocimiento

---

### 🎓 Estudiante 2 (María García)
```
Email: maria@universidad.edu
Contraseña: Estudiante123!
```
**Permisos:**
- ✅ Crear nuevos incidentes (máximo 3 activos)
- ✅ Ver solo sus propios incidentes
- ❌ No puede acceder a Base de Conocimiento

---

## 📋 Resumen de Funcionalidades por Rol

### 🎓 Estudiantes (Nivel 0)
| Funcionalidad | Permitido |
|--------------|-----------|
| Crear incidentes | ✅ (máximo 3 activos) |
| Ver incidentes | ✅ Solo propios |
| Resolver incidentes | ❌ |
| Escalar incidentes | ❌ |
| Base de Conocimiento | ❌ |

### ⚙️ Técnicos (Niveles 1-4)
| Funcionalidad | Permitido |
|--------------|-----------|
| Ver incidentes | ✅ Solo asignados |
| Resolver incidentes | ✅ |
| Escalar incidentes | ✅ (excepto Nivel 4) |
| Base de Conocimiento | ✅ Completo |
| Asignar incidentes | ❌ |
| Descartar incidentes | ❌ |

### 🛡️ Administrador (Nivel 5)
| Funcionalidad | Permitido |
|--------------|-----------|
| Ver incidentes | ✅ Todos |
| Asignar incidentes | ✅ |
| Resolver incidentes | ✅ |
| Descartar incidentes | ✅ |
| Escalar incidentes | ❌ (no aplica) |
| Base de Conocimiento | ✅ Completo |

---

## 🔒 Notas de Seguridad

- ⚠️ Las contraseñas están hasheadas en la base de datos
- ✅ Los usuarios deben estar activos para poder iniciar sesión
- 🔐 Sistema de sesión basado en sessionStorage del navegador

## 🚀 Inicio Rápido

1. Ejecuta `dotnet run`
2. Abre http://localhost:5078
3. Usa cualquiera de las credenciales anteriores
4. Explora las funcionalidades según el rol
