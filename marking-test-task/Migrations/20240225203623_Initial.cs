using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace marking_test_task.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MissionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Gtin = table.Column<string>(type: "TEXT", nullable: false),
                    BoxCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    PalleteCapacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.UniqueConstraint("AK_Missions_MissionId", x => x.MissionId);
                });

            migrationBuilder.CreateTable(
                name: "Palletes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    MissionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palletes_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "MissionId");
                });

            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    PalleteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boxes_Palletes_PalleteId",
                        column: x => x.PalleteId,
                        principalTable: "Palletes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bottles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    BoxId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bottles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bottles_Boxes_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Boxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_BoxId",
                table: "Bottles",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_PalleteId",
                table: "Boxes",
                column: "PalleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MissionId",
                table: "Missions",
                column: "MissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Palletes_MissionId",
                table: "Palletes",
                column: "MissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bottles");

            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Palletes");

            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}
