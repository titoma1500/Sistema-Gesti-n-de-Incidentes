using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNivelEstudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 21, 31, 13, 548, DateTimeKind.Local).AddTicks(7484), "$2a$11$FJM9igbgIG3Gabdj11D5RuHxm.SG5h2qWyQvvrmScdZ.3GCdG5ikS" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 21, 31, 13, 666, DateTimeKind.Local).AddTicks(7941), "$2a$11$MpihhH7kztTutCFstBNGg.M5JeHHty3HeCqXJNfph4w5fuYrxYgqG" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 21, 31, 13, 787, DateTimeKind.Local).AddTicks(3554), "$2a$11$M/A8Or8DU9urnvVyNTLQ7OwoFSCD6rxVld/rI1nllZpQqQOO1/9Ha" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FechaCreacion", "Nombre", "PasswordHash" },
                values: new object[] { "tecnico1@universidad.edu", new DateTime(2025, 11, 24, 21, 31, 13, 902, DateTimeKind.Local).AddTicks(1082), "Técnico Nivel 1", "$2a$11$LVHhD3RsZflOdgTZrF7LguY0ABL29.k2xI7xSLe0iZwfvh1r8MNnO" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "Email", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[,]
                {
                    { 5, true, "estudiante1@universidad.edu", new DateTime(2025, 11, 24, 21, 31, 14, 27, DateTimeKind.Local).AddTicks(9845), 0, "Juan Pérez", "$2a$11$wI70JU01Cs7uqIa5HeuO4ehW2SOOFaRNTfSymDognI8zkwegb2v3S" },
                    { 6, true, "estudiante2@universidad.edu", new DateTime(2025, 11, 24, 21, 31, 14, 146, DateTimeKind.Local).AddTicks(2746), 0, "María González", "$2a$11$ISJWVGfMpxUW58j5Y3yfze89xxzdpyc5w8/aGAJFwdZG64hQads6K" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 21, 9, 3, 302, DateTimeKind.Local).AddTicks(9489), "$2a$11$qY4Y/jvCoLMOOhDY78vOK.SjEmZCNt5Gjmqg/AbdQNMs0wOnRSkhy" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 21, 9, 3, 424, DateTimeKind.Local).AddTicks(8285), "$2a$11$jrDogvM91tLQrBsj4qRxgO1tAHe8sZg9MZbQzkzWwuZMWJQB0ewdm" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 21, 9, 3, 543, DateTimeKind.Local).AddTicks(7796), "$2a$11$uf/345hl4CEM3xENeOSLceSrQCvcNj6mk3NqBT1aZS71xq1EuSMsO" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FechaCreacion", "Nombre", "PasswordHash" },
                values: new object[] { "usuario@universidad.edu", new DateTime(2025, 11, 24, 21, 9, 3, 661, DateTimeKind.Local).AddTicks(3099), "Usuario Normal", "$2a$11$XX9h1e8hhHxEQHK13vruq.p8BsN.KEKQ8Bx2ZCixez2TNav6gIX5q" });
        }
    }
}
