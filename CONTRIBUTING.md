# 🤝 Guía de Contribución

¡Gracias por tu interés en contribuir al Sistema de Gestión de Incidentes! Este documento proporciona pautas para contribuir al proyecto.

## 📋 Código de Conducta

- Sé respetuoso y profesional
- Acepta críticas constructivas
- Enfócate en lo mejor para la comunidad
- Muestra empatía hacia otros colaboradores

## 🚀 Cómo Contribuir

### Reportar Bugs

1. Verifica que el bug no haya sido reportado anteriormente
2. Crea un issue con:
   - Título descriptivo
   - Pasos para reproducir
   - Comportamiento esperado vs actual
   - Screenshots si aplica
   - Versión de .NET y navegador

### Sugerir Mejoras

1. Abre un issue describiendo la mejora
2. Explica por qué sería útil
3. Proporciona ejemplos de uso

### Pull Requests

1. **Fork** el repositorio
2. **Crea una rama** desde `main`:
   ```bash
   git checkout -b feature/mi-nueva-caracteristica
   # o
   git checkout -b fix/correccion-bug
   ```

3. **Desarrolla** siguiendo las convenciones del proyecto:
   - Arquitectura Onion (Domain → Application → Infrastructure → Presentation)
   - DTOs para transferencia de datos
   - Services para lógica de negocio
   - Repositories para acceso a datos

4. **Commits** descriptivos:
   ```bash
   git commit -m "Agregar: funcionalidad de exportar reportes"
   git commit -m "Corregir: bug en asignación de incidentes"
   git commit -m "Refactorizar: optimizar consulta de incidentes"
   ```

5. **Push** a tu fork:
   ```bash
   git push origin feature/mi-nueva-caracteristica
   ```

6. **Abre un Pull Request** con:
   - Título claro
   - Descripción de cambios
   - Issue relacionado (si aplica)
   - Screenshots/GIFs de cambios visuales

## 🏗️ Estructura del Proyecto

```
src/
├── Domain/              # Entidades y enums (sin dependencias)
├── Application/         # Lógica de negocio, DTOs, interfaces
├── Infrastructure/      # Implementaciones, acceso a datos
Components/              # UI Blazor
```

### Principios de Arquitectura

- **Domain**: No debe tener dependencias externas
- **Application**: Depende solo de Domain
- **Infrastructure**: Implementa interfaces de Application
- **Components**: Depende de Application (interfaces, no implementaciones)

## 📝 Estándares de Código

### C#
```csharp
// ✅ Bueno
public async Task<IncidenteDto> ObtenerPorIdAsync(int id)
{
    var incidente = await _repository.ObtenerPorIdAsync(id);
    return MapearADto(incidente);
}

// ❌ Malo
public async Task<IncidenteDto> get(int x)
{
    return MapearADto(await _repository.ObtenerPorIdAsync(x));
}
```

### Naming Conventions
- **Clases**: PascalCase (IncidenteService)
- **Métodos**: PascalCase (ObtenerTodos)
- **Parámetros**: camelCase (usuarioId)
- **Privados**: _camelCase (_repository)
- **Async**: Sufijo Async (CrearAsync)

### Blazor Components
```razor
@* ✅ Bueno *@
@page "/incidentes"
@inject IIncidenteService IncidenteService

<h3>Gestión de Incidentes</h3>

@code {
    private List<IncidenteDto> incidentes = new();
    
    protected override async Task OnInitializedAsync()
    {
        incidentes = await IncidenteService.ObtenerTodosAsync();
    }
}
```

## 🧪 Testing

Si agregas tests (altamente recomendado):

```bash
dotnet test
```

## 📦 Dependencias

- Evita agregar dependencias innecesarias
- Justifica nuevas dependencias en el PR
- Mantén versiones actualizadas

## 🔍 Revisión de Código

Todos los PRs serán revisados. Esperamos:

- ✅ Código limpio y legible
- ✅ Sigue arquitectura establecida
- ✅ Sin warnings de compilación
- ✅ Funcionalidad probada
- ✅ Documentación actualizada si es necesario

## 📚 Áreas de Contribución Sugeridas

### Funcionalidades
- [ ] Sistema de adjuntar archivos
- [ ] Comentarios en incidentes
- [ ] Dashboard con estadísticas
- [ ] Exportar reportes (PDF/Excel)
- [ ] Búsqueda avanzada con filtros
- [ ] Historial de cambios de incidentes

### Mejoras Técnicas
- [ ] Tests unitarios
- [ ] Tests de integración
- [ ] Autenticación JWT
- [ ] API REST
- [ ] Optimización de queries
- [ ] Caché de datos

### UI/UX
- [ ] Diseño responsive mejorado
- [ ] Modo oscuro completo
- [ ] Animaciones
- [ ] Accesibilidad (ARIA)
- [ ] Internacionalización

## 💬 Comunicación

- **Issues**: Para bugs y sugerencias
- **Discussions**: Para preguntas generales
- **Pull Requests**: Para contribuciones de código

## ❓ Preguntas

Si tienes dudas, abre un issue con la etiqueta `question`.

---

¡Gracias por contribuir! 🎉
