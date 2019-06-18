using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherQueue.Migrations
{
    public partial class addedQueueToTeach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Queues_TeacherId",
                table: "Queues");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_TeacherId",
                table: "Queues",
                column: "TeacherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Queues_TeacherId",
                table: "Queues");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_TeacherId",
                table: "Queues",
                column: "TeacherId");
        }
    }
}
