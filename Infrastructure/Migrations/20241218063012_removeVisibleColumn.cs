using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeVisibleColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("648b96d9-0b3f-4fd4-baa0-91073c60e45e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a95ab7a5-25f3-43db-8a19-fd073f378819"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c0471043-2bf1-4f3e-90e4-c5297470f386"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("ec3de45b-9fcb-4a55-98c4-102a8c9e1740"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "415bf191-caa8-4c07-be9b-e63fecb999e3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "48d03fcb-685c-44c2-81c4-701ae8affd95");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Order",
                newName: "TotalAmount");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Order",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateBy", "CreatedOn", "Description", "LastUpdatedOn", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("648b96d9-0b3f-4fd4-baa0-91073c60e45e"), null, new DateTime(2024, 12, 17, 13, 28, 42, 643, DateTimeKind.Local).AddTicks(6928), "Sports equipment and accessories", new DateTime(2024, 12, 17, 13, 28, 42, 643, DateTimeKind.Local).AddTicks(6922), "Sports", null },
                    { new Guid("a95ab7a5-25f3-43db-8a19-fd073f378819"), null, new DateTime(2024, 12, 17, 13, 28, 42, 643, DateTimeKind.Local).AddTicks(6911), "Fiction and non-fiction books", new DateTime(2024, 12, 17, 13, 28, 42, 643, DateTimeKind.Local).AddTicks(6899), "Books", null },
                    { new Guid("c0471043-2bf1-4f3e-90e4-c5297470f386"), null, new DateTime(2024, 12, 17, 13, 28, 42, 643, DateTimeKind.Local).AddTicks(6870), "Devices and gadgets", new DateTime(2024, 12, 17, 13, 28, 42, 643, DateTimeKind.Local).AddTicks(6822), "Electronics", null },
                    { new Guid("ec3de45b-9fcb-4a55-98c4-102a8c9e1740"), null, new DateTime(2024, 12, 17, 13, 28, 42, 643, DateTimeKind.Local).AddTicks(6885), "Apparel and accessories", new DateTime(2024, 12, 17, 13, 28, 42, 643, DateTimeKind.Local).AddTicks(6879), "Clothing", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "415bf191-caa8-4c07-be9b-e63fecb999e3", 0, "admin_concurrency_stamp", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEKFXJcghBoFh/GD3iY4PpluCFRafHfBItQMFVMJakiMq4q85ls/4HbNnRfLv8Srjig==", null, true, "admin_security_stamp", false, "admin" },
                    { "48d03fcb-685c-44c2-81c4-701ae8affd95", 0, "user_concurrency_stamp", "user@example.com", true, false, null, "USER@EXAMPLE.COM", "USER", "AQAAAAIAAYagAAAAEN/axge7CfhZuu3QUvPP8KYWiaRiGAtUDgk7uy2fwgE5eg/G5xnmUfDe/I4jyhZVjQ==", null, true, "user_security_stamp", false, "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");
        }
    }
}
