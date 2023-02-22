using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubSystemsAssessment.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Memberships_MemberId",
                table: "Memberships");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MemberId_MembershipTypeId",
                table: "Memberships",
                columns: new[] { "MemberId", "MembershipTypeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Memberships_MemberId_MembershipTypeId",
                table: "Memberships");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MemberId",
                table: "Memberships",
                column: "MemberId");
        }
    }
}
