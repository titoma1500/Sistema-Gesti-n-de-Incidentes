using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarUsuariosReales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nombre" },
                values: new object[] { "carlos.mendoza@universidad.edu", "Infraestructura Cloud", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7101), "Carlos Mendoza" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "ana.ruiz@universidad.edu", "Seguridad Informática", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7103), 4, "Ana Patricia Ruiz" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "roberto.sanchez@universidad.edu", "Arquitectura de Sistemas", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7105), 4, "Roberto Sánchez" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "laura.fernandez@universidad.edu", "DevOps y Automatización", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7141), 4, "Laura Fernández" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[] { "miguel.torres@universidad.edu", "Ciberseguridad", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7143), 4, "Miguel Ángel Torres", "tecnico123" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[] { "patricia.morales@universidad.edu", "Administración de Redes", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7145), 3, "Patricia Morales", "tecnico123" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[,]
                {
                    { 8, true, "jorge.ramirez@universidad.edu", "Servidores y Virtualización", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7147), 3, "Jorge Luis Ramírez", "tecnico123" },
                    { 9, true, "sofia.castro@universidad.edu", "Redes Inalámbricas", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7149), 3, "Sofía Castro", "tecnico123" },
                    { 10, true, "diego.herrera@universidad.edu", "Bases de Datos", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7151), 3, "Diego Herrera", "tecnico123" },
                    { 11, true, "valentina.lopez@universidad.edu", "Almacenamiento y Backup", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7153), 3, "Valentina López", "tecnico123" },
                    { 12, true, "andres.jimenez@universidad.edu", "Desarrollo Web", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7155), 2, "Andrés Jiménez", "tecnico123" },
                    { 13, true, "camila.vargas@universidad.edu", "Aplicaciones Empresariales", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7156), 2, "Camila Vargas", "tecnico123" },
                    { 14, true, "felipe.ortiz@universidad.edu", "Integración de Sistemas", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7158), 2, "Felipe Ortiz", "tecnico123" },
                    { 15, true, "daniela.rojas@universidad.edu", "Plataformas Educativas", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7160), 2, "Daniela Rojas", "tecnico123" },
                    { 16, true, "sebastian.pena@universidad.edu", "Software de Gestión", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7162), 2, "Sebastián Peña", "tecnico123" },
                    { 17, true, "gabriela.munoz@universidad.edu", "Soporte Técnico General", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7164), 1, "Gabriela Muñoz", "tecnico123" },
                    { 18, true, "alejandro.cruz@universidad.edu", "Atención al Usuario", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7166), 1, "Alejandro Cruz", "tecnico123" },
                    { 19, true, "isabella.romero@universidad.edu", "Hardware y Mantenimiento", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7167), 1, "Isabella Romero", "tecnico123" },
                    { 20, true, "mateo.silva@universidad.edu", "Soporte de Office", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7169), 1, "Mateo Silva", "tecnico123" },
                    { 21, true, "lucia.martinez@universidad.edu", "Conectividad y Accesos", new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7171), 1, "Lucía Martínez", "tecnico123" },
                    { 22, true, "juan.perez@universidad.edu", null, new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7173), 0, "Juan Pablo Pérez", "estudiante123" },
                    { 23, true, "maria.gonzalez@universidad.edu", null, new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7175), 0, "María José González", "estudiante123" },
                    { 24, true, "david.rodriguez@universidad.edu", null, new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7176), 0, "David Rodríguez", "estudiante123" },
                    { 25, true, "carolina.diaz@universidad.edu", null, new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7178), 0, "Carolina Díaz", "estudiante123" },
                    { 26, true, "nicolas.gomez@universidad.edu", null, new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7180), 0, "Nicolás Gómez", "estudiante123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 17, 26, 201, DateTimeKind.Local).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nombre" },
                values: new object[] { "tecnico4@universidad.edu", "Infraestructura y Seguridad", new DateTime(2025, 11, 29, 12, 17, 26, 201, DateTimeKind.Local).AddTicks(1026), "Técnico Nivel 4" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "tecnico3@universidad.edu", "Redes y Servidores", new DateTime(2025, 11, 29, 12, 17, 26, 201, DateTimeKind.Local).AddTicks(1029), 3, "Técnico Nivel 3" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "tecnico2@universidad.edu", "Software y Aplicaciones", new DateTime(2025, 11, 29, 12, 17, 26, 201, DateTimeKind.Local).AddTicks(1030), 2, "Técnico Nivel 2" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre" },
                values: new object[] { "tecnico1@universidad.edu", "Soporte Básico", new DateTime(2025, 11, 29, 12, 17, 26, 201, DateTimeKind.Local).AddTicks(1032), 1, "Técnico Nivel 1" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[] { "estudiante1@universidad.edu", null, new DateTime(2025, 11, 29, 12, 17, 26, 201, DateTimeKind.Local).AddTicks(1034), 0, "Juan Pérez", "estudiante123" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Especialidad", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[] { "estudiante2@universidad.edu", null, new DateTime(2025, 11, 29, 12, 17, 26, 201, DateTimeKind.Local).AddTicks(1035), 0, "María González", "estudiante123" });
        }
    }
}
