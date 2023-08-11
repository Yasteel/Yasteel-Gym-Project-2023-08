using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BmiRecords",
                columns: table => new
                {
                    pkBmiRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkMemberId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    BMI = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BmiRecords", x => x.pkBmiRecordId);
                });

            migrationBuilder.CreateTable(
                name: "HrRecords",
                columns: table => new
                {
                    pkHrRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkMemberId = table.Column<int>(type: "int", nullable: false),
                    HRmax = table.Column<double>(type: "float", nullable: false),
                    HRrest = table.Column<double>(type: "float", nullable: false),
                    OTWOmax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrRecords", x => x.pkHrRecordId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    pkMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fkMembershipType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.pkMemberId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    pkTrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerClass = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.pkTrainerId);
                });

            migrationBuilder.CreateTable(
                name: "MemberTrainerLink",
                columns: table => new
                {
                    pkLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkMemberId = table.Column<int>(type: "int", nullable: false),
                    fkTrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTrainerLink", x => x.pkLinkId);
                    table.ForeignKey(
                        name: "FK_MemberTrainerLink_Members_fkMemberId",
                        column: x => x.fkMemberId,
                        principalTable: "Members",
                        principalColumn: "pkMemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberTrainerLink_Trainers_fkTrainerId",
                        column: x => x.fkTrainerId,
                        principalTable: "Trainers",
                        principalColumn: "pkTrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberTrainerLink_fkMemberId",
                table: "MemberTrainerLink",
                column: "fkMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTrainerLink_fkTrainerId",
                table: "MemberTrainerLink",
                column: "fkTrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BmiRecords");

            migrationBuilder.DropTable(
                name: "HrRecords");

            migrationBuilder.DropTable(
                name: "MemberTrainerLink");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
