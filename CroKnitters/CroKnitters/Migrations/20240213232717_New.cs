using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CroKnitters.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminId", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "admin1@example.com", "!a123456", "Admin1" },
                    { 2, "admin2@example.com", "!a123456", "Admin2" },
                    { 3, "admin3@example.com", "!a123456", "Admin3" },
                    { 4, "admin4@example.com", "!a123456", "Admin4" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImageSrc" },
                values: new object[,]
                {
                    { 1, "https://pbs.twimg.com/profile_images/1654080701292068865/AL2TAeY5_400x400.jpg" },
                    { 2, "https://i.redd.it/jeuusd992wd41.jpg" },
                    { 3, "https://images.squarespace-cdn.com/content/v1/5e10bdc20efb8f0d169f85f9/09943d85-b8c7-4d64-af31-1a27d1b76698/arrow.png" },
                    { 4, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQV1_mGYXjq3eWha-wQIRkn6ulW9X6Ws-ztw&usqp=CAU" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "ProvinceName" },
                values: new object[,]
                {
                    { 1, "Alberta" },
                    { 2, "British Columbia" },
                    { 3, "Manitoba" },
                    { 4, "New Brunswick" },
                    { 5, "Newfoundland and Labrador" },
                    { 6, "Nova Scotia" },
                    { 7, "Ontario" },
                    { 8, "Prince Edward Island" },
                    { 9, "Quebec" },
                    { 10, "Saskatchewan" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "CityId", "Email", "FirstName", "ImageId", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Just a guy whose favourite thing is to crochet :).", null, "samD@example.com", "Samuel", 1, "Dane", "!a123456", "Samuel123" },
                    { 2, "Hello there! I like to crochet and knit...", null, "juliaCrochet@example.com", "Julia", 2, "Fernandez", "!a123456", "Julia123" },
                    { 3, "My name is Juan Pablo and I'm exploring this craft as a new hobby.", null, "Pablo@example.com", "Juan", 4, "Pablo", "!a123456", "Juan123" },
                    { 4, "Hello!", null, "Dsmith@example.com", "Delilah", 3, "Smith", "!a123456", "Delilah123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 4);
        }
    }
}
