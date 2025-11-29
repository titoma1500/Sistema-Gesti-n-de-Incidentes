using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEspecialidadUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Especialidad",
                table: "Usuarios",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Especialidad", "FechaCreacion" },
                values: new object[] { "Administración General", new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Especialidad", "FechaCreacion" },
                values: new object[] { "Redes y Servidores", new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9439) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Especialidad", "FechaCreacion" },
                values: new object[] { "Software y Aplicaciones", new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9442) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Especialidad", "FechaCreacion" },
                values: new object[] { "Soporte Básico", new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Especialidad", "FechaCreacion" },
                values: new object[] { null, new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9448) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Especialidad", "FechaCreacion" },
                values: new object[] { null, new DateTime(2025, 11, 29, 11, 43, 51, 692, DateTimeKind.Local).AddTicks(9451) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especialidad",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(624));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(638));
        }
    }
}
