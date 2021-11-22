using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiMF.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoriaconsumibles",
                columns: table => new
                {
                    idCategoriaConsumibles = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCategoriaConsumibles = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idCategoriaConsumibles);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "categoriaherramienta",
                columns: table => new
                {
                    idCategoriaHerramienta = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCategoriaHerramienta = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idCategoriaHerramienta);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "categoriamateriaprima",
                columns: table => new
                {
                    idCategoriaMateriaPrima = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCategoriaMateriaPrima = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idCategoriaMateriaPrima);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCliente = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductoTerminado = table.Column<int>(type: "int", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idCliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "consumible",
                columns: table => new
                {
                    idConsumible = table.Column<int>(type: "int", nullable: false),
                    ClaveConsumible = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescripcionConsumible = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    idCategoriaConsumible = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagen = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreConsumible = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<double>(type: "double", nullable: false),
                    UnidadMedida = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idConsumible);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "herramienta",
                columns: table => new
                {
                    idHerramienta = table.Column<int>(type: "int", nullable: false),
                    ClaveHerramienta = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescripcionHerramienta = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    idCategoriaHerramienta = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreHerramienta = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idHerramienta);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "materiaprima",
                columns: table => new
                {
                    idMateriaPrima = table.Column<int>(type: "int", nullable: false),
                    CategoriaMateriaPrima = table.Column<int>(type: "int", nullable: false),
                    ClaveMateriaPrima = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescripcionMateriaPrima = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    idCategoriaMateriaPrima = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<int>(type: "int", nullable: true),
                    NombreMateriaPrima = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<double>(type: "double", nullable: false),
                    UnidadMedida = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idMateriaPrima);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "productoterminado",
                columns: table => new
                {
                    idProductoTerminado = table.Column<int>(type: "int", nullable: false),
                    DescripcionProductoTerminado = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Empresa = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaLlegada = table.Column<DateTime>(type: "datetime", nullable: true),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    NombreProductoTerminado = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idProductoTerminado);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tipousuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    TipoUsuario = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idTipoUsuario);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    idUsuarios = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idUsuarios);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoriaconsumibles");

            migrationBuilder.DropTable(
                name: "categoriaherramienta");

            migrationBuilder.DropTable(
                name: "categoriamateriaprima");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "consumible");

            migrationBuilder.DropTable(
                name: "herramienta");

            migrationBuilder.DropTable(
                name: "materiaprima");

            migrationBuilder.DropTable(
                name: "productoterminado");

            migrationBuilder.DropTable(
                name: "tipousuario");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
