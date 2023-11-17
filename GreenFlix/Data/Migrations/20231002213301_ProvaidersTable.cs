using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenFlix.Data.Migrations
{
    public partial class ProvaidersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvaiderId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Provaiders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provaiders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provaiders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProvaiderId",
                table: "Movies",
                column: "ProvaiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Provaiders_UserId",
                table: "Provaiders",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Provaiders_ProvaiderId",
                table: "Movies",
                column: "ProvaiderId",
                principalTable: "Provaiders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Provaiders_ProvaiderId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Provaiders");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ProvaiderId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ProvaiderId",
                table: "Movies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
