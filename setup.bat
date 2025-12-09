@echo off
REM Script de setup inicial para Windows

echo ========================================
echo 🎫 Sistema de Gestión de Incidentes - Setup
echo ========================================
echo.

REM Verificar .NET SDK
echo 📦 Verificando .NET SDK...
dotnet --version >nul 2>&1
if errorlevel 1 (
    echo ❌ .NET SDK no encontrado
    echo    Descarga desde: https://dotnet.microsoft.com/download/dotnet/8.0
    exit /b 1
)
dotnet --version
echo ✅ .NET SDK encontrado
echo.

REM Restaurar dependencias
echo 📥 Restaurando dependencias NuGet...
dotnet restore
if errorlevel 1 (
    echo ❌ Error restaurando dependencias
    exit /b 1
)
echo ✅ Dependencias restauradas
echo.

REM Verificar Entity Framework Tools
echo 🔧 Verificando EF Core Tools...
dotnet tool install --global dotnet-ef >nul 2>&1
if errorlevel 1 (
    dotnet tool update --global dotnet-ef
)
echo ✅ EF Core Tools instalado
echo.

REM Aplicar migraciones
echo 🗃️  Aplicando migraciones de base de datos...
dotnet ef database update
if errorlevel 1 (
    echo ⚠️  No se pudieron aplicar las migraciones
    echo    Verifica que SQL Server esté corriendo
    echo    O actualiza la cadena de conexión en appsettings.json
) else (
    echo ✅ Base de datos creada y migraciones aplicadas
)
echo.

REM Build del proyecto
echo 🔨 Compilando proyecto...
dotnet build
if errorlevel 1 (
    echo ❌ Error compilando el proyecto
    exit /b 1
)
echo ✅ Proyecto compilado correctamente
echo.

echo ========================================
echo ✨ Setup completado!
echo.
echo Para ejecutar la aplicación:
echo   dotnet run
echo.
echo La aplicación estará disponible en:
echo   http://localhost:5078
echo.
echo Usuarios de prueba:
echo   Admin: admin@universidad.edu / admin123
echo   Técnico: carlos@universidad.edu / tecnico123
echo   Estudiante: juan@universidad.edu / tecnico123
echo ========================================
pause
