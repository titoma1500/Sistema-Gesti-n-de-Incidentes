#!/bin/bash
# Script de setup inicial para Linux/Mac

echo "🎫 Sistema de Gestión de Incidentes - Setup"
echo "=========================================="
echo ""

# Verificar .NET SDK
echo "📦 Verificando .NET SDK..."
if ! command -v dotnet &> /dev/null
then
    echo "❌ .NET SDK no encontrado"
    echo "   Descarga desde: https://dotnet.microsoft.com/download/dotnet/8.0"
    exit 1
fi

dotnet --version
echo "✅ .NET SDK encontrado"
echo ""

# Restaurar dependencias
echo "📥 Restaurando dependencias NuGet..."
dotnet restore
if [ $? -ne 0 ]; then
    echo "❌ Error restaurando dependencias"
    exit 1
fi
echo "✅ Dependencias restauradas"
echo ""

# Verificar Entity Framework Tools
echo "🔧 Verificando EF Core Tools..."
dotnet tool install --global dotnet-ef 2>/dev/null || dotnet tool update --global dotnet-ef
echo "✅ EF Core Tools instalado"
echo ""

# Aplicar migraciones
echo "🗃️  Aplicando migraciones de base de datos..."
dotnet ef database update
if [ $? -ne 0 ]; then
    echo "⚠️  No se pudieron aplicar las migraciones"
    echo "   Verifica que SQL Server esté corriendo"
    echo "   O actualiza la cadena de conexión en appsettings.json"
else
    echo "✅ Base de datos creada y migraciones aplicadas"
fi
echo ""

# Build del proyecto
echo "🔨 Compilando proyecto..."
dotnet build
if [ $? -ne 0 ]; then
    echo "❌ Error compilando el proyecto"
    exit 1
fi
echo "✅ Proyecto compilado correctamente"
echo ""

echo "=========================================="
echo "✨ Setup completado!"
echo ""
echo "Para ejecutar la aplicación:"
echo "  dotnet run"
echo ""
echo "La aplicación estará disponible en:"
echo "  http://localhost:5078"
echo ""
echo "Usuarios de prueba:"
echo "  Admin: admin@universidad.edu / admin123"
echo "  Técnico: carlos@universidad.edu / tecnico123"
echo "  Estudiante: juan@universidad.edu / tecnico123"
echo "=========================================="
