using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CowboyWebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_CowboyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Hair = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CowboyDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_GunDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GunName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxNumberOfBullets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_GunDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CowboyGunBulletsMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cowboy_Id = table.Column<int>(type: "int", nullable: false),
                    Gun_Id = table.Column<int>(type: "int", nullable: false),
                    BulletsLeft = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CowboyGunBulletsMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_CowboyGunBulletsMapping_tbl_CowboyDetails_Cowboy_Id",
                        column: x => x.Cowboy_Id,
                        principalTable: "tbl_CowboyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_CowboyGunBulletsMapping_tbl_GunDetails_Gun_Id",
                        column: x => x.Gun_Id,
                        principalTable: "tbl_GunDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CowboyGunBulletsMapping_Cowboy_Id",
                table: "tbl_CowboyGunBulletsMapping",
                column: "Cowboy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CowboyGunBulletsMapping_Gun_Id",
                table: "tbl_CowboyGunBulletsMapping",
                column: "Gun_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_CowboyGunBulletsMapping");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "tbl_CowboyDetails");

            migrationBuilder.DropTable(
                name: "tbl_GunDetails");
        }
    }
}
