# 📘 Ejemplos de Uso - Sistema DITIC

## Escenarios Prácticos

### Escenario 1: Estudiante con Problema de Impresora

**Situación**: Un estudiante no puede imprimir su tarea desde una computadora del laboratorio.

#### Paso 1: Crear Incidente
```
Título: "Impresora no responde en Lab 3"
Descripción: "Al intentar imprimir desde la computadora 15 del Lab 3, 
la impresora no responde. El documento queda en cola pero nunca imprime."
Prioridad: Alta (necesita imprimir para entregar tarea)
```

#### Paso 2: Usuario Experto (Nivel 1)
- Revisa el incidente
- Busca en Base de Conocimiento: "impresora no imprime"
- Encuentra solución: "Reiniciar cola de impresión"
- Aplica solución
- **Resultado**: ✅ Problema resuelto

---

### Escenario 2: Error de Software Complejo

**Situación**: Aplicación de diseño gráfico se cierra inesperadamente.

#### Paso 1: Crear Incidente
```
Título: "Adobe Photoshop se cierra al abrir archivo PSD"
Descripción: "Al intentar abrir archivos .psd grandes (más de 500MB),
la aplicación se cierra sin mensaje de error."
Prioridad: Crítica (trabajo de clase en riesgo)
```

#### Paso 2: Usuario Experto (Nivel 1)
- Intenta soluciones básicas: reiniciar, actualizar
- No puede resolver
- **Escala a Nivel 2**

#### Paso 3: Ingeniería de Soporte (Nivel 2)
- Revisa logs del sistema
- Identifica problema de memoria RAM
- Verifica hardware
- No puede reparar hardware
- **Escala a Nivel 3**

#### Paso 4: Proveedor (Nivel 3)
- Contacta fabricante del equipo
- Programa reemplazo de RAM
- Instala nuevos módulos
- **Resultado**: ✅ Problema resuelto - Se crea artículo en Base de Conocimiento

---

### Escenario 3: Problema Recurrente

**Situación**: Varios estudiantes reportan el mismo error de WiFi.

#### Primera vez
```
Incidente #1: "No puedo conectarme a WiFi-Universidad"
- Usuario Experto investiga
- Encuentra que es problema de configuración
- Resuelve el incidente
- **IMPORTANTE: Crea artículo en Base de Conocimiento**
```

#### Artículo en Base de Conocimiento
```
Título: "Error de conexión WiFi-Universidad en Windows 11"
Categoría: Red
Problema: "No se puede conectar a la red WiFi-Universidad, 
muestra error 'No se puede conectar a esta red'"
Solución:
1. Ir a Configuración > Red e Internet
2. Seleccionar WiFi > Administrar redes conocidas
3. Eliminar "WiFi-Universidad"
4. Volver a buscar redes
5. Conectarse de nuevo e ingresar contraseña
Palabras clave: wifi, conexión, windows 11, red
```

#### Siguientes veces
```
Incidente #2, #3, #4...: Mismo problema
- Técnico busca en Base de Conocimiento: "wifi no conecta"
- Encuentra el artículo
- Aplica solución documentada
- **Resolución en 2 minutos** ⚡
```

---

## Flujos de Trabajo Completos

### Flujo 1: Incidente Simple

```
┌─────────────────┐
│ Crear Incidente │
└────────┬────────┘
         │
         ▼
┌──────────────────────┐
│ Asignar a Nivel 1    │
│ (Usuario Experto)    │
└────────┬─────────────┘
         │
         ▼
┌──────────────────────┐
│ Buscar en Base de    │
│ Conocimiento         │
└────────┬─────────────┘
         │
         ▼
┌──────────────────────┐
│ Aplicar Solución     │
└────────┬─────────────┘
         │
         ▼
┌──────────────────────┐
│ Marcar como Resuelto │
└─────────────────────┘
```

### Flujo 2: Incidente con Escalamiento

```
┌─────────────────┐
│ Crear Incidente │
└────────┬────────┘
         │
         ▼
┌──────────────────────┐
│ Nivel 1: Intento     │
│ solución básica      │
└────────┬─────────────┘
         │ ❌ No resuelto
         ▼
┌──────────────────────┐
│ ESCALAR → Nivel 2    │
│ (Ingeniería)         │
└────────┬─────────────┘
         │
         ▼
┌──────────────────────┐
│ Diagnóstico avanzado │
└────────┬─────────────┘
         │ ❌ No resuelto
         ▼
┌──────────────────────┐
│ ESCALAR → Nivel 3    │
│ (Proveedor)          │
└────────┬─────────────┘
         │
         ▼
┌──────────────────────┐
│ Soporte fabricante   │
└────────┬─────────────┘
         │ ✅ Resuelto
         ▼
┌──────────────────────┐
│ Documentar solución  │
│ en Base Conocimiento │
└────────┬─────────────┘
         │
         ▼
┌──────────────────────┐
│ Marcar como Resuelto │
└─────────────────────┘
```

---

## Ejemplos de Artículos de Base de Conocimiento

### Ejemplo 1: Hardware

**Título**: Computadora no enciende - LED amarillo parpadeante

**Categoría**: Hardware

**Problema**: 
La computadora Dell Optiplex muestra un LED amarillo parpadeante en el botón de encendido y no arranca. No hay video en pantalla.

**Solución**:
1. Apagar completamente la computadora
2. Desconectar cable de alimentación
3. Mantener presionado el botón de encendido por 30 segundos
4. Volver a conectar cable de alimentación
5. Encender computadora
6. Si persiste: Verificar módulos de RAM, remover y reinstalar

**Palabras clave**: dell, led, amarillo, no enciende, optiplex

---

### Ejemplo 2: Software

**Título**: Microsoft Office muestra error de activación

**Categoría**: Software

**Problema**:
Al abrir Word, Excel o PowerPoint aparece mensaje "Producto sin licencia" o "Activación requerida" aunque la universidad tiene licencias.

**Solución**:
1. Cerrar todas las aplicaciones de Office
2. Abrir símbolo del sistema como administrador
3. Navegar a: C:\Program Files\Microsoft Office\Office16
4. Ejecutar: cscript ospp.vbs /dstatus
5. Ejecutar: cscript ospp.vbs /act
6. Reiniciar computadora
7. Abrir Office de nuevo

**Palabras clave**: office, activación, licencia, word, excel

---

### Ejemplo 3: Red

**Título**: Unidad de red no aparece en Este Equipo

**Categoría**: Red

**Problema**:
La unidad de red compartida (Z:) no aparece en "Este equipo" aunque antes funcionaba.

**Solución**:
1. Abrir símbolo del sistema
2. Ejecutar: net use Z: /delete
3. Ejecutar: net use Z: \\servidor\compartido /persistent:yes
4. Ingresar credenciales de red cuando se solicite
5. Verificar que aparezca la unidad Z: en "Este equipo"

Alternativa desde Explorador:
1. Clic derecho en "Este equipo"
2. "Conectar a unidad de red"
3. Letra: Z
4. Carpeta: \\servidor\compartido
5. ✓ Conectar de nuevo al iniciar sesión
6. Finalizar

**Palabras clave**: unidad red, z:, compartida, servidor, mapear

---

## Dashboard de Métricas (Conceptual)

### Panel de Control para Administrador

```
┌─────────────────────────────────────────┐
│  📊 Incidentes por Estado               │
├─────────────────────────────────────────┤
│  Nuevos:        15 🔵                   │
│  Asignados:     23 🟢                   │
│  En Proceso:    12 🟡                   │
│  Escalados:      5 🔴                   │
│  Resueltos:    150 ✅                   │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│  ⚡ Incidentes por Prioridad            │
├─────────────────────────────────────────┤
│  Crítica:        3 🔥                   │
│  Alta:          12 ⚠️                   │
│  Media:         25 📊                   │
│  Baja:           8 📝                   │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│  📚 Artículos Más Consultados           │
├─────────────────────────────────────────┤
│  1. WiFi no conecta (45 consultas)     │
│  2. Office activación (32 consultas)   │
│  3. Impresora cola (28 consultas)      │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│  👥 Técnicos Más Activos                │
├─────────────────────────────────────────┤
│  María García:  18 resueltos           │
│  Juan Pérez:    12 resueltos           │
│  Admin Sistema:  8 resueltos           │
└─────────────────────────────────────────┘
```

---

## Casos de Uso por Rol

### Estudiante
1. ✅ Reportar problema en laboratorio
2. ✅ Ver estado de mi incidente
3. ✅ Buscar soluciones en Base de Conocimiento
4. ✅ Consultar horarios de soporte

### Usuario Experto (Nivel 1)
1. ✅ Ver incidentes nuevos
2. ✅ Asignarse incidentes
3. ✅ Buscar soluciones conocidas
4. ✅ Resolver incidentes simples
5. ✅ Escalar incidentes complejos
6. ✅ Crear artículos de conocimiento

### Ingeniero de Soporte (Nivel 2)
1. ✅ Recibir incidentes escalados
2. ✅ Diagnóstico avanzado
3. ✅ Resolver problemas técnicos complejos
4. ✅ Escalar a proveedor si necesario
5. ✅ Documentar soluciones técnicas
6. ✅ Actualizar Base de Conocimiento

### Proveedor (Nivel 3/4)
1. ✅ Recibir incidentes críticos escalados
2. ✅ Contactar fabricantes
3. ✅ Gestionar garantías
4. ✅ Programar reparaciones
5. ✅ Documentar soluciones de hardware

### Administrador
1. ✅ Ver todos los incidentes
2. ✅ Asignar técnicos
3. ✅ Revisar métricas
4. ✅ Gestionar usuarios
5. ✅ Aprobar artículos de conocimiento
6. ✅ Configurar servicios DITIC

---

## Mejores Prácticas

### Al Reportar Incidentes

✅ **HACER**:
- Título descriptivo y conciso
- Descripción detallada del problema
- Incluir pasos para reproducir
- Indicar prioridad real
- Mencionar equipo/ubicación

❌ **NO HACER**:
- Títulos vagos: "No funciona"
- Descripción mínima: "Ayuda"
- Marcar todo como crítico
- Reportar múltiples problemas en uno
- Omitir detalles importantes

### Al Crear Artículos

✅ **HACER**:
- Título que describa el problema
- Problema claramente definido
- Solución paso a paso numerada
- Palabras clave relevantes
- Categoría apropiada

❌ **NO HACER**:
- Soluciones vagas o incompletas
- Pasos sin orden lógico
- Omitir palabras clave
- Escribir todo en un párrafo
- Sin categorizar

### Al Resolver Incidentes

✅ **HACER**:
- Documentar la solución aplicada
- Crear artículo si es problema nuevo
- Actualizar estado correctamente
- Cerrar cuando esté verificado
- Agregar notas técnicas relevantes

❌ **NO HACER**:
- Resolver sin documentar
- Dejar solución vacía
- Cerrar sin verificar
- Omitir detalles técnicos
- No compartir conocimiento

---

## Tiempo Promedio de Resolución (Objetivos)

```
Nivel 1 (Usuario Experto)
├─ Problemas simples:     15 minutos
├─ Problemas documentados: 5 minutos
└─ Escalamiento:          30 minutos

Nivel 2 (Ingeniería)
├─ Problemas técnicos:    2 horas
├─ Diagnóstico:           1 hora
└─ Escalamiento:          4 horas

Nivel 3 (Proveedor)
├─ Contacto fabricante:   1 día
├─ Reparación:            2-5 días
└─ Reemplazo:             1-2 semanas
```

---

Este sistema ayuda a:
- ⚡ Resolver problemas más rápido
- 📚 Acumular conocimiento institucional
- 📊 Medir desempeño de soporte
- 🎯 Priorizar recursos correctamente
- 👥 Escalar eficientemente entre niveles
