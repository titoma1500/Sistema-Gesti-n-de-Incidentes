using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarNivelesUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "Nivel" },
                values: new object[] { new DateTime(2025, 11, 29, 12, 14, 34, 808, DateTimeKind.Local).AddTicks(5548), 5 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "tecnico4@universidad.edu", "Infraestructura y Seguridad", new DateTime(2025, 11, 29, 12, 14, 34, 808, DateTimeKind.Local).AddTicks(5551), 4, "Técnico Nivel 4" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "tecnico3@universidad.edu", "Redes y Servidores", new DateTime(2025, 11, 29, 12, 14, 34, 808, DateTimeKind.Local).AddTicks(5553), 3, "Técnico Nivel 3" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "tecnico2@universidad.edu", "Software y Aplicaciones", new DateTime(2025, 11, 29, 12, 14, 34, 808, DateTimeKind.Local).AddTicks(5555), 2, "Técnico Nivel 2" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[] { "tecnico1@universidad.edu", "Soporte Básico", new DateTime(2025, 11, 29, 12, 14, 34, 808, DateTimeKind.Local).AddTicks(5557), 1, "Técnico Nivel 1", "tecnico123" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "FechaCreacion", "Nombre" },
                values: new object[] { "estudiante1@universidad.edu", new DateTime(2025, 11, 29, 12, 14, 34, 808, DateTimeKind.Local).AddTicks(5558), "Juan Pérez" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[] { 7, true, "estudiante2@universidad.edu", null, new DateTime(2025, 11, 29, 12, 14, 34, 808, DateTimeKind.Local).AddTicks(5560), 0, "María González", "estudiante123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "Nivel" },
                values: new object[] { new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9434), 4 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "tecnico3@universidad.edu", "Redes y Servidores", new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9439), 3, "Técnico Avanzado" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "tecnico2@universidad.edu", "Software y Aplicaciones", new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9442), 2, "Técnico Básico" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "tecnico1@universidad.edu", "Soporte Básico", new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9445), 1, "Técnico Nivel 1" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[] { "estudiante1@universidad.edu", null, new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9448), 0, "Juan Pérez", "estudiante123" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "FechaCreacion", "Nombre" },
                values: new object[] { "estudiante2@universidad.edu", new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9451), "María González" });
        }
    }
}
