using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DjurApiLiveDemo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_People_PersonId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PersonId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Pets");

            migrationBuilder.CreateTable(
                name: "PersonPet",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    PetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPet", x => new { x.PeopleId, x.PetsId });
                    table.ForeignKey(
                        name: "FK_PersonPet_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPet_Pets_PetsId",
                        column: x => x.PetsId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPet_PetsId",
                table: "PersonPet",
                column: "PetsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPet");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PersonId",
                table: "Pets",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_People_PersonId",
                table: "Pets",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
