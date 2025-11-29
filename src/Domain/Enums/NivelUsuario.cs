namespace Proyecto.Domain.Enums;

public enum NivelUsuario
{
    Estudiante = 0,  // Estudiante - Solo puede crear incidentes
    Nivel1 = 1,      // Técnico Nivel 1 - Resuelve incidentes básicos
    Nivel2 = 2,      // Técnico Nivel 2 - Resuelve incidentes simples
    Nivel3 = 3,      // Técnico Nivel 3 - Resuelve incidentes complejos
    Nivel4 = 4,      // Técnico Nivel 4 - Resuelve incidentes críticos
    Nivel5 = 5       // Administrador - Asigna y gestiona todo
}
