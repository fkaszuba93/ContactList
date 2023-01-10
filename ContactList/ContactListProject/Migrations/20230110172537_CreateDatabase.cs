using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactListProject.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactRowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_Contacts_Contacts_ContactRowId",
                        column: x => x.ContactRowId,
                        principalTable: "Contacts",
                        principalColumn: "RowId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactRowId",
                table: "Contacts",
                column: "ContactRowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
