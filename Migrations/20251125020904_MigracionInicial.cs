using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseConocimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solucion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VecesConsultada = table.Column<int>(type: "int", nullable: false),
                    CreadoPorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseConocimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseConocimiento_Usuarios_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaResolucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioReportaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAsignadoId = table.Column<int>(type: "int", nullable: true),
                    IncidentePadreId = table.Column<int>(type: "int", nullable: true),
                    MensajeEscalacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidentes_Incidentes_IncidentePadreId",
                        column: x => x.IncidentePadreId,
                        principalTable: "Incidentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidentes_Usuarios_UsuarioAsignadoId",
                        column: x => x.UsuarioAsignadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidentes_Usuarios_UsuarioReportaId",
                        column: x => x.UsuarioReportaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseConocimientoEtiqueta",
                columns: table => new
                {
                    ArticulosConocimientoId = table.Column<int>(type: "int", nullable: false),
                    EtiquetasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseConocimientoEtiqueta", x => new { x.ArticulosConocimientoId, x.EtiquetasId });
                    table.ForeignKey(
                        name: "FK_BaseConocimientoEtiqueta_BaseConocimiento_ArticulosConocimientoId",
                        column: x => x.ArticulosConocimientoId,
                        principalTable: "BaseConocimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseConocimientoEtiqueta_Etiquetas_EtiquetasId",
                        column: x => x.EtiquetasId,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidenteEtiqueta",
                columns: table => new
                {
                    EtiquetasId = table.Column<int>(type: "int", nullable: false),
                    IncidentesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidenteEtiqueta", x => new { x.EtiquetasId, x.IncidentesId });
                    table.ForeignKey(
                        name: "FK_IncidenteEtiqueta_Etiquetas_EtiquetasId",
                        column: x => x.EtiquetasId,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncidenteEtiqueta_Incidentes_IncidentesId",
                        column: x => x.IncidentesId,
                        principalTable: "Incidentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leida = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    IncidenteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Incidentes_IncidenteId",
                        column: x => x.IncidenteId,
                        principalTable: "Incidentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Etiquetas",
                columns: new[] { "Id", "Categoria", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Problemas de hardware", "Hardware" },
                    { 2, 2, "Problemas de software", "Software" },
                    { 3, 3, "Problemas de red", "Red" },
                    { 4, 4, "Problemas con impresoras", "Impresora" },
                    { 5, 7, "Problemas con correo electrónico", "Email" },
                    { 6, 5, "Problemas con Windows", "Windows" },
                    { 7, 6, "Problemas con Office", "Office" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "Email", "FechaCreacion", "Nivel", "Nombre", "PasswordHash" },
                values: new object[,]
                {
                    { 1, true, "admin@universidad.edu", new DateTime(2025, 11, 24, 21, 9, 3, 302, DateTimeKind.Local).AddTicks(9489), 4, "Admin Principal", "$2a$11$qY4Y/jvCoLMOOhDY78vOK.SjEmZCNt5Gjmqg/AbdQNMs0wOnRSkhy" },
                    { 2, true, "tecnico3@universidad.edu", new DateTime(2025, 11, 24, 21, 9, 3, 424, DateTimeKind.Local).AddTicks(8285), 3, "Técnico Avanzado", "$2a$11$jrDogvM91tLQrBsj4qRxgO1tAHe8sZg9MZbQzkzWwuZMWJQB0ewdm" },
                    { 3, true, "tecnico2@universidad.edu", new DateTime(2025, 11, 24, 21, 9, 3, 543, DateTimeKind.Local).AddTicks(7796), 2, "Técnico Básico", "$2a$11$uf/345hl4CEM3xENeOSLceSrQCvcNj6mk3NqBT1aZS71xq1EuSMsO" },
                    { 4, true, "usuario@universidad.edu", new DateTime(2025, 11, 24, 21, 9, 3, 661, DateTimeKind.Local).AddTicks(3099), 1, "Usuario Normal", "$2a$11$XX9h1e8hhHxEQHK13vruq.p8BsN.KEKQ8Bx2ZCixez2TNav6gIX5q" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseConocimiento_CreadoPorId",
                table: "BaseConocimiento",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseConocimientoEtiqueta_EtiquetasId",
                table: "BaseConocimientoEtiqueta",
                column: "EtiquetasId");

            migrationBuilder.CreateIndex(
                name: "IX_Etiquetas_Nombre",
                table: "Etiquetas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncidenteEtiqueta_IncidentesId",
                table: "IncidenteEtiqueta",
                column: "IncidentesId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_IncidentePadreId",
                table: "Incidentes",
                column: "IncidentePadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes",
                column: "UsuarioAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioReportaId",
                table: "Incidentes",
                column: "UsuarioReportaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_IncidenteId",
                table: "Notificaciones",
                column: "IncidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_UsuarioId",
                table: "Notificaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseConocimientoEtiqueta");

            migrationBuilder.DropTable(
                name: "IncidenteEtiqueta");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "BaseConocimiento");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
