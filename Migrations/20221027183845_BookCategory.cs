using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kovacs_Adela_lab02.Migrations
{
    public partial class BookCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Author_AuthorID",
                table: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Author_AuthorID",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Author");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookCategory_Book_BookID",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_BookID",
                table: "BookCategory",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryID",
                table: "BookCategory",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Author",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_AuthorID",
                table: "Author",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Author_AuthorID",
                table: "Author",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID");
        }
    }
}
