using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMotivoDescarte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MotivoDescarte",
                table: "Incidentes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 26,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 16, 52, 24, 718, DateTimeKind.Local).AddTicks(9466));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotivoDescarte",
                table: "Incidentes");

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
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7156));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7167));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 26,
                column: "FechaCreacion",
                value: new DateTime(2025, 11, 29, 12, 39, 16, 478, DateTimeKind.Local).AddTicks(7180));
        }
    }
}
