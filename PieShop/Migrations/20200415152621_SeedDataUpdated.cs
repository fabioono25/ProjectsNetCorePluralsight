using Microsoft.EntityFrameworkCore.Migrations;

namespace PieShop.Migrations
{
    public partial class SeedDataUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "PieId",
                keyValue: 2,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl" },
                values: new object[] { "https://s3.amazonaws.com/finecooking.s3.tauntonclud.com/app/uploads/2017/04/18134327/051093069-01-blueberry-blackberry-pie-main.jpg", "https://s3.amazonaws.com/finecooking.s3.tauntonclud.com/app/uploads/2017/04/18134327/051093069-01-blueberry-blackberry-pie-main.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pies",
                keyColumn: "PieId",
                keyValue: 2,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl" },
                values: new object[] { "https://cdn.sallysbakingaddiction.com/wp-content/uploads/2016/06/simply-the-best-blueberry-pie-2.jpg", "https://cdn.sallysbakingaddiction.com/wp-content/uploads/2016/06/simply-the-best-blueberry-pie-2.jpg" });
        }
    }
}
