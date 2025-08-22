using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LesAmes.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitForDeploy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_AspNetUsers_TutorId",
                table: "Hobbies");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_TutorId",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Hobbies");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TutorHobbies",
                columns: table => new
                {
                    HobbiesId = table.Column<string>(type: "text", nullable: false),
                    TutorsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorHobbies", x => new { x.HobbiesId, x.TutorsId });
                    table.ForeignKey(
                        name: "FK_TutorHobbies_AspNetUsers_TutorsId",
                        column: x => x.TutorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorHobbies_Hobbies_HobbiesId",
                        column: x => x.HobbiesId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutorHobbies_TutorsId",
                table: "TutorHobbies",
                column: "TutorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TutorHobbies");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TutorId",
                table: "Hobbies",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_TutorId",
                table: "Hobbies",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_AspNetUsers_TutorId",
                table: "Hobbies",
                column: "TutorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
