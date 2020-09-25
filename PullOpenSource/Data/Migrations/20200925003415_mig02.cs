using Microsoft.EntityFrameworkCore.Migrations;

namespace PullOpenSource.Data.Migrations
{
    public partial class mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "DatosEmpleado");

            migrationBuilder.DropColumn(
                name: "TipoIdEmpleado",
                table: "DatosEmpleado");

            migrationBuilder.DropColumn(
                name: "TipoRegistro",
                table: "DatosEmpleado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdEmpresa",
                table: "DatosEmpleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoIdEmpleado",
                table: "DatosEmpleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoRegistro",
                table: "DatosEmpleado",
                nullable: true);
        }
    }
}
