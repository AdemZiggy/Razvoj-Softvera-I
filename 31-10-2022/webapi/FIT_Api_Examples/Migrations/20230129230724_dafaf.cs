using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class dafaf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaticnaKnjiga",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumUpisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    godinaStudija = table.Column<int>(type: "int", nullable: false),
                    cijenaSkolarine = table.Column<float>(type: "real", nullable: false),
                    obnova = table.Column<bool>(type: "bit", nullable: false),
                    datumOvjere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akademska_godina_id = table.Column<int>(type: "int", nullable: true),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    korisnicki_nalog_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaticnaKnjiga", x => x.id);
                    table.ForeignKey(
                        name: "FK_MaticnaKnjiga_AkademskaGodina_akademska_godina_id",
                        column: x => x.akademska_godina_id,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaticnaKnjiga_KorisnickiNalog_korisnicki_nalog_id",
                        column: x => x.korisnicki_nalog_id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaticnaKnjiga_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaticnaKnjiga_akademska_godina_id",
                table: "MaticnaKnjiga",
                column: "akademska_godina_id");

            migrationBuilder.CreateIndex(
                name: "IX_MaticnaKnjiga_korisnicki_nalog_id",
                table: "MaticnaKnjiga",
                column: "korisnicki_nalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_MaticnaKnjiga_studentId",
                table: "MaticnaKnjiga",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaticnaKnjiga");
        }
    }
}
