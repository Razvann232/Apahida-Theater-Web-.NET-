using Microsoft.EntityFrameworkCore.Migrations;

namespace ApahidaTheatherWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Play_PlayId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_PlayId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "PlayId",
                table: "Ticket",
                newName: "PlayID");

            migrationBuilder.AlterColumn<int>(
                name: "PlayID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayID",
                table: "Ticket",
                newName: "PlayId");

            migrationBuilder.AlterColumn<int>(
                name: "PlayId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PlayId",
                table: "Ticket",
                column: "PlayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Play_PlayId",
                table: "Ticket",
                column: "PlayId",
                principalTable: "Play",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
