# 🚀 Inicio Rápido - 5 Minutos

## ⚡ Ejecutar el Proyecto AHORA

### Opción 1: Ejecutar Directamente (Recomendado)

```powershell
# En la terminal de VS Code o PowerShell
cd c:\ps\Proyecto
dotnet run
```

Luego abre tu navegador en: **https://localhost:5001**

### Opción 2: Desde Visual Studio

1. Abrir `Proyecto.sln`
2. Presionar `F5` o clic en ▶️ "Run"
3. El navegador se abrirá automáticamente

---

## 📖 Guía Visual Rápida

### 1️⃣ Crear un Incidente

```
🏠 Inicio → 🎫 Incidentes → ➕ Nuevo Incidente
```

Completa:
- **Título**: "Impresora no responde"
- **Descripción**: "La impresora del Lab 3..."
- **Prioridad**: Media
- Clic en **Guardar**

### 2️⃣ Ver Detalles del Incidente

```
🎫 Incidentes → 👁️ Ver (botón azul)
```

Verás:
- Información completa
- Estado actual
- Nivel de escalamiento
- Opción para resolver o escalar

### 3️⃣ Resolver un Incidente

```
📋 Detalle del Incidente → Escribir solución → ✅ Marcar como Resuelto
```

### 4️⃣ Crear Artículo de Conocimiento

```
🏠 Inicio → 📚 Base de Conocimiento → ➕ Nuevo Artículo
```

Completa:
- **Título**: "Error WiFi Windows 11"
- **Categoría**: "Red"
- **Problema**: "No se puede conectar..."
- **Solución**: "Pasos: 1. Ir a..."
- **Palabras clave**: "wifi, red, windows"
- Clic en **Guardar**

### 5️⃣ Buscar Soluciones

```
📚 Base de Conocimiento → 🔍 Escribir término → Buscar
```

---

## 🎯 Funciones Principales

| Función | Ubicación | Descripción |
|---------|-----------|-------------|
| Ver incidentes | `/incidentes` | Lista completa con filtros |
| Crear incidente | `/incidentes` → Nuevo | Reportar problema |
| Ver detalle | `/incidente/{id}` | Info completa + acciones |
| Base conocimiento | `/conocimiento` | Buscar y crear artículos |
| Escalar | Detalle → Escalar | Subir nivel de soporte |
| Resolver | Detalle → Resolver | Marcar solucionado |

---

## 📊 Datos de Prueba Incluidos

### Usuarios Pre-creados
- **Admin Sistema** (Técnico)
- **Juan Pérez** (Usuario)
- **María García** (Técnico de Soporte TI)

### Servicios DITIC
1. Usuario Experto (L-V 8:00-17:00)
2. Ingeniería de Soporte (L-S 7:00-19:00)
3. Proveedor Externo (L-V 9:00-18:00)

---

## 🎨 Paleta de Colores en la UI

| Estado/Prioridad | Color | Significado |
|------------------|-------|-------------|
| Nuevo | 🔵 Azul | Pendiente |
| Asignado | 🟢 Verde | En atención |
| Escalado | 🔴 Rojo | Nivel superior |
| Resuelto | ✅ Verde | Solucionado |
| Prioridad Baja | ⚪ Gris | No urgente |
| Prioridad Alta | 🟡 Amarillo | Urgente |
| Prioridad Crítica | 🔴 Rojo | Muy urgente |

---

## 🔧 Comandos Útiles

```powershell
# Ejecutar
dotnet run

# Compilar
dotnet build

# Limpiar
dotnet clean

# Ver migraciones
dotnet ef migrations list

# Recrear base de datos
dotnet ef database drop
dotnet ef database update

# Hot reload (auto-recarga cambios)
dotnet watch run
```

---

## 📁 Documentación Disponible

1. **README.md** → Configuración y tecnologías
2. **GUIA_DE_USO.md** → Manual completo de usuario
3. **ARQUITECTURA.md** → Documentación técnica
4. **EJEMPLOS_USO.md** → Casos de uso y ejemplos
5. **RESUMEN_PROYECTO.md** → Estado del proyecto

---

## ✅ Verificación Rápida

### ¿Todo funciona?

```powershell
# 1. Verificar compilación
dotnet build
# Debe decir: "Compilación realizado correctamente"

# 2. Verificar base de datos
dotnet ef migrations list
# Debe mostrar: "20251118034441_MigracionInicial"

# 3. Ejecutar
dotnet run
# Debe mostrar: "Now listening on: https://localhost:5001"
```

---

## 🎬 Flujo Completo de Ejemplo (2 minutos)

### Escenario: Problema de Impresora

**1. Crear Incidente (30 seg)**
- Ir a Incidentes → Nuevo Incidente
- Título: "Impresora Lab 3 no imprime"
- Descripción: "Documentos quedan en cola"
- Prioridad: Alta
- Guardar

**2. Ver en Lista (10 seg)**
- Aparece en tabla con badge Alta (amarillo)
- Estado: Nuevo (azul)

**3. Ver Detalle (15 seg)**
- Clic en "Ver"
- Muestra toda la información
- Nivel 1 (Usuario Experto)

**4. Escalar (10 seg)**
- Clic en "Escalar Nivel"
- Ahora es Nivel 2 (Ingeniería)
- Estado: Escalado (rojo)

**5. Resolver (30 seg)**
- Escribir solución: "Se reinició el servicio de cola de impresión"
- Clic en "Marcar como Resuelto"
- Estado: Resuelto (verde)

**6. Documentar (25 seg)**
- Ir a Base de Conocimiento → Nuevo Artículo
- Título: "Cola de impresión bloqueada"
- Problema: "Documentos no imprimen, quedan en cola"
- Solución: "Reiniciar servicio Print Spooler"
- Categoría: "Hardware"
- Palabras: "impresora, cola, spooler"
- Guardar

**✅ Total: ~2 minutos**

---

## 🌟 Características Destacadas

### ⚡ Rápido
- Búsqueda instantánea en Base de Conocimiento
- Escalamiento con un clic
- Resolución documentada

### 📊 Organizado
- Estados claros con colores
- Prioridades visuales
- Niveles de servicio definidos

### 🎯 Eficiente
- Reutilización de soluciones
- Escalamiento inteligente
- Seguimiento completo

### 🎨 Moderno
- Interfaz Bootstrap 5
- Responsive design
- Iconos intuitivos

---

## 💡 Tips Rápidos

1. **Busca antes de escalar**: Revisa Base de Conocimiento
2. **Documenta todo**: Cada solución puede ayudar después
3. **Prioriza correctamente**: No todo es crítico
4. **Escala cuando sea necesario**: Mejor rápido que tarde
5. **Usa palabras clave**: Facilitan búsquedas futuras

---

## 🆘 Problemas Comunes

### "No puedo conectarme a la BD"
```powershell
dotnet ef database update
```

### "El puerto está en uso"
Cambiar en `Properties/launchSettings.json`:
```json
"applicationUrl": "https://localhost:5002"
```

### "Error al compilar"
```powershell
dotnet clean
dotnet restore
dotnet build
```

---

## 📞 ¿Necesitas Ayuda?

1. Revisa **GUIA_DE_USO.md** para instrucciones detalladas
2. Revisa **ARQUITECTURA.md** para entender la estructura
3. Revisa **EJEMPLOS_USO.md** para casos de uso completos

---

**¡Listo! El sistema está funcionando y esperando tu primer incidente! 🎉**
