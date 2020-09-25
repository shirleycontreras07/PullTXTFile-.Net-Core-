using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PullOpenSource.Data.Migrations
{
    public partial class migration00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatosEmpleado",
                columns: table => new
                {
                    DatosEmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEmpresa = table.Column<string>(nullable: true),
                    TipoRegistro = table.Column<string>(nullable: true),
                    TipoIdEmpleado = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<string>(nullable: true),
                    Sueldo = table.Column<string>(nullable: true),
                    SueldoNeto = table.Column<string>(nullable: true),
                    NoSeguridadSocial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosEmpleado", x => x.DatosEmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "DatosEmpresa",
                columns: table => new
                {
                    DatosEmpresaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoRegistro = table.Column<string>(nullable: true),
                    TipoArchivo = table.Column<string>(nullable: true),
                    Identificacion = table.Column<string>(nullable: true),
                    Periodo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosEmpresa", x => x.DatosEmpresaID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatosEmpleado");

            migrationBuilder.DropTable(
                name: "DatosEmpresa");
        }
    }
}
