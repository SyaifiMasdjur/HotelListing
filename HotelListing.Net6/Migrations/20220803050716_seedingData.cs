using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Net6.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "name", "shortname" },
                values: new object[] { 1, "Bahama", "BHM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "name", "shortname" },
                values: new object[] { 2, "Caribean", "CRB" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "name", "shortname" },
                values: new object[] { 3, "Greece", "GRC" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "adress", "countryId", "name", "rating" },
                values: new object[] { 1, "Bahama Hotel International Address", 1, "Bahama Hotel International", 1.0 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "adress", "countryId", "name", "rating" },
                values: new object[] { 2, "Bahama Hotel Leasure Hotel Address", 1, "Bahama Hotel Leasure Hotel", 5.0 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "adress", "countryId", "name", "rating" },
                values: new object[] { 3, "Greece  Hotel Leasure Hotel Address", 3, "Greece Hotel Leasure Hotel", 4.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
