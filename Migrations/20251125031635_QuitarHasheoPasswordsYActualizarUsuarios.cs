using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class QuitarHasheoPasswordsYActualizarUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(624), "admin123" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(628), "tecnico123" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(630), "tecnico123" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(632), "tecnico123" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(635), "estudiante123" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 22, 16, 35, 626, DateTimeKind.Local).AddTicks(638), "estudiante123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 21, 31, 13, 902, DateTimeKind.Local).AddTicks(1082), "$2a$11$LVHhD3RsZflOdgTZrF7LguY0ABL29.k2xI7xSLe0iZwfvh1r8MNnO" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 21, 31, 14, 27, DateTimeKind.Local).AddTicks(9845), "$2a$11$wI70JU01Cs7uqIa5HeuO4ehW2SOOFaRNTfSymDognI8zkwegb2v3S" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "PasswordHash" },
                values: new object[] { new DateTime(2025, 11, 24, 21, 31, 14, 146, DateTimeKind.Local).AddTicks(2746), "$2a$11$ISJWVGfMpxUW58j5Y3yfze89xxzdpyc5w8/aGAJFwdZG64hQads6K" });
        }
    }
}
