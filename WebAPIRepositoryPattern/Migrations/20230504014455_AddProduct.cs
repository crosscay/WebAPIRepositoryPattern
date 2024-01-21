using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIRepositoryPattern.Migrations
{
    /// <inheritdoc />
    public partial class AddProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "ProductInfos",
            columns: table => new
            {

                IdProduct = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NameProduct = table.Column<string>(type: "nvarchar(100)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Price = table.Column<string>(type: "decimal(18,2)", nullable: false),
                Amount = table.Column<string>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProductoInfos", x => x.IdProduct);
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInfos");
        }
    }
}
