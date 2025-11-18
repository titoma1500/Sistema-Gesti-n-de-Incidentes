# Guía de Uso - Sistema de Gestión de Incidentes DITIC

## Inicio Rápido

### Ejecutar la aplicación

```powershell
dotnet run
```

Luego abre tu navegador en: `https://localhost:5001`

## Módulos del Sistema

### 1. Gestión de Incidentes

#### Crear un Nuevo Incidente

1. Navega a **Incidentes** en el menú lateral
2. Haz clic en el botón **"Nuevo Incidente"**
3. Completa el formulario:
   - **Título**: Descripción breve del problema
   - **Descripción**: Detalle completo del incidente
   - **Prioridad**: Selecciona el nivel de urgencia
     - Baja: Problemas menores sin impacto inmediato
     - Media: Problemas que afectan el trabajo pero tienen workaround
     - Alta: Problemas que impiden el trabajo normal
     - Crítica: Sistemas caídos o problemas de seguridad
4. Haz clic en **"Guardar"**

#### Estados de un Incidente

- **Nuevo**: Incidente recién creado, pendiente de asignación
- **Asignado**: Se ha asignado un técnico
- **En Proceso**: El técnico está trabajando en la solución
- **Escalado**: Se ha escalado a un nivel superior de soporte
- **Resuelto**: Se ha encontrado y aplicado una solución
- **Cerrado**: El incidente está completamente cerrado

#### Escalar un Incidente

1. Abre el detalle del incidente
2. Haz clic en **"Escalar Nivel"**
3. El incidente pasará al siguiente nivel de soporte:
   - Nivel 1 → Nivel 2 (Usuario Experto → Ingeniería)
   - Nivel 2 → Nivel 3 (Ingeniería → Proveedor)
   - Nivel 3 → Nivel 4 (Proveedor → Proveedor Avanzado)

#### Resolver un Incidente

1. Abre el detalle del incidente
2. En el campo **"Resolver incidente"**, describe la solución aplicada
3. Haz clic en **"Marcar como Resuelto"**
4. El incidente cambiará a estado "Resuelto"

### 2. Base de Conocimiento

#### Crear un Artículo

1. Navega a **Base de Conocimiento** en el menú lateral
2. Haz clic en **"Nuevo Artículo"**
3. Completa el formulario:
   - **Título**: Nombre descriptivo del artículo
   - **Categoría**: Tipo de problema (Hardware, Software, Red, etc.)
   - **Problema**: Descripción detallada del problema
   - **Solución**: Pasos para resolver el problema
   - **Palabras clave**: Términos de búsqueda separados por coma
4. Haz clic en **"Guardar"**

#### Buscar en la Base de Conocimiento

1. En la página de Base de Conocimiento
2. Escribe términos de búsqueda en el campo de búsqueda
3. Haz clic en **"Buscar"**
4. El sistema buscará en:
   - Títulos de artículos
   - Descripciones de problemas
   - Soluciones
   - Categorías
   - Palabras clave

#### Ver Solución Completa

1. Haz clic en **"Ver solución completa"** en cualquier artículo
2. Se abrirá un modal con toda la información
3. El contador de consultas se incrementará automáticamente

## Flujo de Trabajo Recomendado

### Para Estudiantes (Usuarios)

1. **Reportar un problema**
   - Crear nuevo incidente
   - Describir el problema claramente
   - Indicar prioridad según la urgencia

2. **Buscar soluciones**
   - Antes de reportar, buscar en Base de Conocimiento
   - Ver si existe una solución documentada

### Para Técnicos de Soporte

1. **Revisar incidentes nuevos**
   - Verificar incidentes en estado "Nuevo"
   - Analizar prioridad y descripción

2. **Buscar soluciones conocidas**
   - Consultar Base de Conocimiento
   - Aplicar soluciones documentadas

3. **Resolver o Escalar**
   - Si se puede resolver: Documentar solución y marcar como resuelto
   - Si no se puede resolver: Escalar al siguiente nivel

4. **Documentar nuevas soluciones**
   - Crear artículo en Base de Conocimiento
   - Incluir palabras clave relevantes
   - Categorizar apropiadamente

## Categorías Sugeridas para Base de Conocimiento

- **Hardware**: Problemas con equipos físicos
- **Software**: Problemas con aplicaciones
- **Red**: Conectividad, WiFi, Internet
- **Sistema Operativo**: Windows, macOS, Linux
- **Impresoras**: Configuración e impresión
- **Periféricos**: Mouse, teclado, monitores
- **Seguridad**: Antivirus, contraseñas
- **Email**: Correo electrónico
- **Aplicaciones**: Software específico

## Niveles de Servicio y Horarios

### Nivel 1: Usuario Experto
- **Horario**: Lunes a Viernes, 8:00 - 17:00
- **Responsabilidad**: Soporte básico, problemas comunes
- **Ejemplos**: Resetear contraseña, configuración básica

### Nivel 2: Ingeniería de Soporte
- **Horario**: Lunes a Sábado, 7:00 - 19:00
- **Responsabilidad**: Problemas técnicos especializados
- **Ejemplos**: Configuración de red, problemas de software complejo

### Nivel 3: Proveedor
- **Horario**: Lunes a Viernes, 9:00 - 18:00
- **Responsabilidad**: Problemas de hardware, contacto con fabricantes
- **Ejemplos**: Reparación de equipos, garantías

### Nivel 4: Proveedor Avanzado
- **Disponibilidad**: Según acuerdo con proveedor
- **Responsabilidad**: Casos críticos y complejos
- **Ejemplos**: Fallas de servidor, problemas de seguridad críticos

## Consejos de Uso

### Para Reportar Incidentes Efectivamente

1. **Título claro**: Resume el problema en pocas palabras
2. **Descripción detallada**: Incluye:
   - ¿Qué estabas haciendo cuando ocurrió?
   - ¿Qué mensaje de error aparece?
   - ¿Cuándo comenzó el problema?
   - ¿Qué has intentado hacer?
3. **Prioridad correcta**: No marcar todo como crítico
4. **Un problema por incidente**: No mezclar varios problemas

### Para Crear Artículos de Conocimiento

1. **Título descriptivo**: Que se entienda el problema sin abrir el artículo
2. **Problema bien definido**: Síntomas claros y específicos
3. **Solución paso a paso**: Instrucciones numeradas y claras
4. **Palabras clave relevantes**: Términos que alguien buscaría
5. **Categoría apropiada**: Facilita la navegación

### Para Gestionar Incidentes

1. **Priorizar**: Atender primero los críticos y de alta prioridad
2. **Documentar**: Siempre registrar la solución aplicada
3. **Compartir conocimiento**: Crear artículos de problemas recurrentes
4. **Escalar cuando sea necesario**: No perder tiempo en problemas fuera de tu nivel

## Solución de Problemas Comunes

### No puedo conectarme a la base de datos

Verifica:
1. SQL Server está ejecutándose
2. La cadena de conexión en `appsettings.json` es correcta
3. La base de datos fue creada con `dotnet ef database update`

### Error al crear migración

```powershell
# Eliminar migración anterior
dotnet ef migrations remove

# Crear nueva migración
dotnet ef migrations add NuevaMigracion

# Aplicar migración
dotnet ef database update
```

### La aplicación no inicia

```powershell
# Limpiar y reconstruir
dotnet clean
dotnet build
dotnet run
```

## Comandos Útiles

```powershell
# Ver todas las migraciones
dotnet ef migrations list

# Revertir a una migración específica
dotnet ef database update MigracionAnterior

# Eliminar la base de datos
dotnet ef database drop

# Ver información del proyecto
dotnet --info
```
