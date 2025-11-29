public class EscalamientoService
{
    /// <summary>
    /// Determina si un usuario puede escalar un incidente
    /// </summary>
    public bool PuedeEscalar(int nivelUsuario, int nuevoNivel)
    {
        // Nivel 1 puede escalar a 2
        // Nivel 2 puede escalar a 3
        // Nivel 3 puede escalar a 4
        // Nivel 4 no puede escalar
        return nuevoNivel == nivelUsuario + 1 && nivelUsuario < 4;
    }

    /// <summary>
    /// Obtiene el siguiente nivel disponible para escalamiento
    /// </summary>
    public int? ObtenerSiguienteNivel(int nivelActual)
    {
        return nivelActual < 4 ? nivelActual + 1 : null;
    }
}
