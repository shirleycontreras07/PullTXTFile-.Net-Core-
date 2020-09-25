using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PullOpenSource.Data.Migrations
{
    public partial class mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoSeguridadSocial",
                table: "DatosEmpleado");

            migrationBuilder.RenameColumn(
                name: "SueldoNeto",
                table: "DatosEmpleado",
                newName: "NoCuenta");

            migrationBuilder.AddColumn<string>(
                name: "CodigoMoneda",
                table: "DatosEmpresa",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sumario",
                columns: table => new
                {
                    SumarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CanEmpleados = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sumario", x => x.SumarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sumario");

            migrationBuilder.DropColumn(
                name: "CodigoMoneda",
                table: "DatosEmpresa");

            migrationBuilder.RenameColumn(
                name: "NoCuenta",
                table: "DatosEmpleado",
                newName: "SueldoNeto");

            migrationBuilder.AddColumn<string>(
                name: "NoSeguridadSocial",
                table: "DatosEmpleado",
                nullable: true);
        }
    }
}
