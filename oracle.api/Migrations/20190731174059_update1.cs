using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace oracle.api.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a9ae4b38-5f11-4d49-8204-9c6a724cfee4", "5b8f579e-59f6-4153-8938-b5f6fa3285f9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b8f579e-59f6-4153-8938-b5f6fa3285f9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9ae4b38-5f11-4d49-8204-9c6a724cfee4");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    AuthorName = table.Column<string>(maxLength: 100, nullable: true),
                    AuthorNameEn = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateOn = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(maxLength: 50, nullable: true),
                    CourseNameEn = table.Column<string>(maxLength: 50, nullable: true),
                    CourseCategory = table.Column<string>(maxLength: 50, nullable: true),
                    CourseCategoryEn = table.Column<string>(maxLength: 50, nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateOn = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08cba36d-764a-42ac-9424-60d3265f8f23", "043d4314-df87-480c-9ecb-71dfc6fa7e38", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "City", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "FirstNameEn", "IsDelete", "LastName", "LastNameEn", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImg", "SecondName", "SecondNameEn", "SecurityStamp", "Street", "TwoFactorEnabled", "UpdateBy", "UpdateOn", "UserName", "ZipCode" },
                values: new object[] { "83fdc6f0-45df-499b-96e7-9d3b5255b471", 0, "Amman", new DateTime(1993, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amman", "0c36d87b-8d62-40ed-8512-a7ea1faf7435", null, new DateTime(2019, 7, 31, 20, 40, 58, 706, DateTimeKind.Local).AddTicks(6409), "aaltair.developer@gmail.com", true, "علاء", "Alaa", false, "الطير", "Altair", false, null, "AALTAIR.DEVELOPER@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEOTAQ9qqjkAkMnoS/hhFwzEq2ADjU0MF9Wht+QGtE0OjBXgNWgu5wYJDFDmyh4Y03w==", "+962788260020", true, null, "عباس", "Abbas", "", null, false, null, null, "admin", null });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "AuthorNameEn", "CreatedBy", "CreatedOn", "IsDelete", "UpdateBy", "UpdateOn" },
                values: new object[] { 1, "علاء عباس الطير", "Alaa Abbas Altair", null, new DateTime(2019, 7, 31, 20, 40, 58, 732, DateTimeKind.Local).AddTicks(6848), false, null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "83fdc6f0-45df-499b-96e7-9d3b5255b471", "08cba36d-764a-42ac-9424-60d3265f8f23" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "AuthorId", "CourseCategory", "CourseCategoryEn", "CourseName", "CourseNameEn", "CreatedBy", "CreatedOn", "IsDelete", "UpdateBy", "UpdateOn" },
                values: new object[,]
                {
                    { 1, 1, "شامل", "FullStack", "دوره (.Net Core With React) ", ".Net Core With React", null, new DateTime(2019, 7, 31, 20, 40, 58, 734, DateTimeKind.Local).AddTicks(6843), false, null, null },
                    { 2, 1, "تصمم وجهات", "FrontEnd", "دوره (React With Redux)", "React With Redux", null, new DateTime(2019, 7, 31, 20, 40, 58, 734, DateTimeKind.Local).AddTicks(8929), false, null, null },
                    { 3, 1, "برمجه", "BackEnd", "دوره (.Net Core WebApi)", ".Net Core WebApi", null, new DateTime(2019, 7, 31, 20, 40, 58, 734, DateTimeKind.Local).AddTicks(8984), false, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "83fdc6f0-45df-499b-96e7-9d3b5255b471", "08cba36d-764a-42ac-9424-60d3265f8f23" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08cba36d-764a-42ac-9424-60d3265f8f23");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83fdc6f0-45df-499b-96e7-9d3b5255b471");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b8f579e-59f6-4153-8938-b5f6fa3285f9", "baf87edd-a2a9-40b7-a68e-3df9a5f14bbb", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "City", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "FirstNameEn", "IsDelete", "LastName", "LastNameEn", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImg", "SecondName", "SecondNameEn", "SecurityStamp", "Street", "TwoFactorEnabled", "UpdateBy", "UpdateOn", "UserName", "ZipCode" },
                values: new object[] { "a9ae4b38-5f11-4d49-8204-9c6a724cfee4", 0, "Amman", new DateTime(1993, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amman", "739b704b-90ef-4235-8387-4a5486832934", null, new DateTime(2019, 7, 31, 18, 1, 6, 812, DateTimeKind.Local).AddTicks(649), "aaltair.developer@gmail.com", true, "علاء", "Alaa", false, "الطير", "Altair", false, null, "AALTAIR.DEVELOPER@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEMOmQit9abHq/acO8dZo5qjuomnzOEZ7UvDzpvSHQXSrFXBUCxryhhakatcBqcNfCA==", "+962788260020", true, null, "عباس", "Abbas", "", null, false, null, null, "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a9ae4b38-5f11-4d49-8204-9c6a724cfee4", "5b8f579e-59f6-4153-8938-b5f6fa3285f9" });
        }
    }
}
