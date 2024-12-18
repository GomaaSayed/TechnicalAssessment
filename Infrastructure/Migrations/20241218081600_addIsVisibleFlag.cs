using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addIsVisibleFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("5f38db14-2a8c-4201-893c-2c8dd84848df"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e4487971-cf5c-41c2-b01b-de40afbacd22"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e582b208-c40c-482b-bb67-c4ac914116ec"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e7ba128b-9c1f-4ca6-89e6-152fe2fe7ebd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "179feea1-16ce-4e33-a083-ccd820b0e90c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cbbb1b0b-069f-4754-be1a-c6abb71c5116");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateBy", "CreatedOn", "Description", "LastUpdatedOn", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2a93257a-a3d7-4f51-91f6-238d194feccd"), null, new DateTime(2024, 12, 18, 10, 16, 0, 178, DateTimeKind.Local).AddTicks(6959), "Apparel and accessories", new DateTime(2024, 12, 18, 10, 16, 0, 178, DateTimeKind.Local).AddTicks(6957), "Clothing", null },
                    { new Guid("2c8340f7-5e62-4bb8-aab7-3806210af77a"), null, new DateTime(2024, 12, 18, 10, 16, 0, 178, DateTimeKind.Local).AddTicks(6968), "Sports equipment and accessories", new DateTime(2024, 12, 18, 10, 16, 0, 178, DateTimeKind.Local).AddTicks(6966), "Sports", null },
                    { new Guid("be2aee6f-9c81-4112-ac65-e3d4287d7107"), null, new DateTime(2024, 12, 18, 10, 16, 0, 178, DateTimeKind.Local).AddTicks(6964), "Fiction and non-fiction books", new DateTime(2024, 12, 18, 10, 16, 0, 178, DateTimeKind.Local).AddTicks(6961), "Books", null },
                    { new Guid("cec5ac19-e107-4595-b0c7-4ed3d32baff4"), null, new DateTime(2024, 12, 18, 10, 16, 0, 178, DateTimeKind.Local).AddTicks(6953), "Devices and gadgets", new DateTime(2024, 12, 18, 10, 16, 0, 178, DateTimeKind.Local).AddTicks(6916), "Electronics", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1f1e2f93-35a6-4396-8ba3-7b7b5072439a", 0, "user_concurrency_stamp", "user@example.com", true, false, null, "USER@EXAMPLE.COM", "USER", "AQAAAAIAAYagAAAAEA4LdUURJXWF/vWve2Wpa0cThaDEPnLofYYnmf/Iq2hi1Q+A4Ztr6DW2OtprClKG3g==", null, true, "user_security_stamp", false, "user" },
                    { "7c3dfd63-3231-4788-8d15-8b622f2d1139", 0, "admin_concurrency_stamp", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEBI7IFSfNrCb8Mxt6/bGZDAhpTKALeHEN1K7CIjnfzySmlo7tO/FtTcxLdd3tf5Ejg==", null, true, "admin_security_stamp", false, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2a93257a-a3d7-4f51-91f6-238d194feccd"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2c8340f7-5e62-4bb8-aab7-3806210af77a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("be2aee6f-9c81-4112-ac65-e3d4287d7107"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("cec5ac19-e107-4595-b0c7-4ed3d32baff4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1f1e2f93-35a6-4396-8ba3-7b7b5072439a");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "7c3dfd63-3231-4788-8d15-8b622f2d1139");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Product");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateBy", "CreatedOn", "Description", "LastUpdatedOn", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("5f38db14-2a8c-4201-893c-2c8dd84848df"), null, new DateTime(2024, 12, 18, 8, 30, 11, 459, DateTimeKind.Local).AddTicks(2937), "Sports equipment and accessories", new DateTime(2024, 12, 18, 8, 30, 11, 459, DateTimeKind.Local).AddTicks(2934), "Sports", null },
                    { new Guid("e4487971-cf5c-41c2-b01b-de40afbacd22"), null, new DateTime(2024, 12, 18, 8, 30, 11, 459, DateTimeKind.Local).AddTicks(2909), "Devices and gadgets", new DateTime(2024, 12, 18, 8, 30, 11, 459, DateTimeKind.Local).AddTicks(2813), "Electronics", null },
                    { new Guid("e582b208-c40c-482b-bb67-c4ac914116ec"), null, new DateTime(2024, 12, 18, 8, 30, 11, 459, DateTimeKind.Local).AddTicks(2921), "Apparel and accessories", new DateTime(2024, 12, 18, 8, 30, 11, 459, DateTimeKind.Local).AddTicks(2916), "Clothing", null },
                    { new Guid("e7ba128b-9c1f-4ca6-89e6-152fe2fe7ebd"), null, new DateTime(2024, 12, 18, 8, 30, 11, 459, DateTimeKind.Local).AddTicks(2930), "Fiction and non-fiction books", new DateTime(2024, 12, 18, 8, 30, 11, 459, DateTimeKind.Local).AddTicks(2926), "Books", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "179feea1-16ce-4e33-a083-ccd820b0e90c", 0, "admin_concurrency_stamp", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAELCFXapaY8p9ICX0k0VSJOnM5u80N3F6hXNlUFnAc3VSWI5CpwaiS3EZxPIUVMn6bw==", null, true, "admin_security_stamp", false, "admin" },
                    { "cbbb1b0b-069f-4754-be1a-c6abb71c5116", 0, "user_concurrency_stamp", "user@example.com", true, false, null, "USER@EXAMPLE.COM", "USER", "AQAAAAIAAYagAAAAEMd9zQjyoOWZzuYVRwEQ1bG0abrai7X2BUtf9SQNf6v1fEccFDDrafwqSRSSOab70Q==", null, true, "user_security_stamp", false, "user" }
                });
        }
    }
}
