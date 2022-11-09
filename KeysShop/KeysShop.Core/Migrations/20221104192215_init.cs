using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeysShop.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buckets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buckets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Sale = table.Column<double>(type: "float", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOriginal = table.Column<bool>(type: "bit", nullable: false),
                    IsKeyless = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keys_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BucketItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KeyId = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    BucketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BucketItem_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BucketItem_Buckets_BucketId",
                        column: x => x.BucketId,
                        principalTable: "Buckets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BucketItem_Keys_KeyId",
                        column: x => x.KeyId,
                        principalTable: "Keys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KeyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Keys_KeyId",
                        column: x => x.KeyId,
                        principalTable: "Keys",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30402003-0f5b-49a0-b7ac-13bb66400ef9", "c94200db-6aae-4db0-81a8-a5544c38f82a", "Manager", "MANAGER" },
                    { "c9934176-4d04-4120-a066-c24eed230908", "36eaab49-7598-4960-b6e8-30b222c584bc", "Consultant", "CONSULTANT" },
                    { "d191d0bf-e97a-4553-b9da-02e05cb5588d", "89c48a2a-f1c3-4716-9f00-0a176059fdd8", "Admin", "ADMIN" },
                    { "e78efcfa-b117-4e6d-8b2b-9ec09dc24788", "f57ce71f-aa06-4e70-8543-efbca8fcb221", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "277ec0d9-95d0-4226-8461-4b8001a84f9b", 0, "6f4fd905-a798-4795-88b4-558e46f6f963", "customer@keysshop.com", true, null, null, false, null, "CUSTOMER@KEYSSHOP.COM", "CUSTOMER@KEYSSHOP.COM", "AQAAAAEAACcQAAAAEMZhAP9D1j8Tf9Qye5xqYtHBY+4ArLNVTQJXB6hzDytz9w47faUe5YawEbk5JZvdRQ==", null, false, "1bdeeb76-c786-4087-8ebf-fa20a11d6e80", false, "customer@keysshop.com" },
                    { "64a183d9-c9ae-440c-b726-0d93a8385731", 0, "3fcd9034-6915-490a-9091-d6282125b74c", "manager@keysshop.com", true, null, null, false, null, "MANAGER@KEYSSHOP.COM", "MANAGER@KEYSSHOP.COM", "AQAAAAEAACcQAAAAEJWOTA+y8euJi3y9SYNDw4WopC6TKd3fgEuinsB9FwVgE2xNwk4aJ2Yd7uHrkCBtxA==", null, false, "8e1ec647-3716-4426-ba6f-859ca402f6de", false, "manager@keysshop.com" },
                    { "72dcbfc5-828a-4c20-b228-1597ad9e9d00", 0, "c7c7bfaf-6030-4928-9b0a-734a0f93b108", "consultant@keysshop.com", true, null, null, false, null, "CONSULTANT@KEYSSHOP.COM", "CONSULTANT@KEYSSHOP.COM", "AQAAAAEAACcQAAAAENrBihSt801ii0OLl+m6SVy+pcjOieK/lLZG9VVzR9zRIjxWBp6txBftcJQ+GBMMAw==", null, false, "4d6e1cab-85f7-4336-a08e-f5b2e5a6e29d", false, "consultant@keysshop.com" },
                    { "be65a422-9838-4602-ab5c-2b6a0d482385", 0, "5ed705cb-aab9-4587-af03-f2c4d25537bb", "admin@keysshop.com", true, null, null, false, null, "ADMIN@KEYSSHOP.COM", "ADMIN@KEYSSHOP.COM", "AQAAAAEAACcQAAAAELYk+NNt10UtyiXqIwvPWhGbNbXoIeVRGGiVbg1GygqEeSWrOtOmyp6kD+IMT8zKPQ==", null, false, "423cc505-9fa4-4d4b-9a4e-b05a97e060fe", false, "admin@keysshop.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e78efcfa-b117-4e6d-8b2b-9ec09dc24788", "277ec0d9-95d0-4226-8461-4b8001a84f9b" },
                    { "30402003-0f5b-49a0-b7ac-13bb66400ef9", "64a183d9-c9ae-440c-b726-0d93a8385731" },
                    { "e78efcfa-b117-4e6d-8b2b-9ec09dc24788", "64a183d9-c9ae-440c-b726-0d93a8385731" },
                    { "c9934176-4d04-4120-a066-c24eed230908", "72dcbfc5-828a-4c20-b228-1597ad9e9d00" },
                    { "e78efcfa-b117-4e6d-8b2b-9ec09dc24788", "72dcbfc5-828a-4c20-b228-1597ad9e9d00" },
                    { "30402003-0f5b-49a0-b7ac-13bb66400ef9", "be65a422-9838-4602-ab5c-2b6a0d482385" },
                    { "c9934176-4d04-4120-a066-c24eed230908", "be65a422-9838-4602-ab5c-2b6a0d482385" },
                    { "d191d0bf-e97a-4553-b9da-02e05cb5588d", "be65a422-9838-4602-ab5c-2b6a0d482385" },
                    { "e78efcfa-b117-4e6d-8b2b-9ec09dc24788", "be65a422-9838-4602-ab5c-2b6a0d482385" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BucketItem_BucketId",
                table: "BucketItem",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketItem_KeyId",
                table: "BucketItem",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketItem_UserId",
                table: "BucketItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_KeyId",
                table: "Feedbacks",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_BrandId",
                table: "Keys",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BucketItem");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Buckets");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
