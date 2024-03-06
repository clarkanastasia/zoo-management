using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enclosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Classification = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SpeciesId = table.Column<int>(type: "integer", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateOfAcquisition = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EnclosureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "Id", "Capacity", "Type" },
                values: new object[,]
                {
                    { 1, 6, 3 },
                    { 2, 50, 1 },
                    { 3, 40, 2 },
                    { 4, 10, 4 },
                    { 5, 10, 0 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Classification", "Name" },
                values: new object[,]
                {
                    { 1, 0, "lion" },
                    { 2, 0, "elephant" },
                    { 3, 0, "zebra" },
                    { 4, 1, "snake" },
                    { 5, 0, "giraffe" },
                    { 6, 0, "hippo" },
                    { 7, 2, "parrot" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "DateOfAcquisition", "DateOfBirth", "EnclosureId", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9048), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9115), 4, "Snoopy", 1, 1 },
                    { 2, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9128), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9131), 2, "Tabatha", 1, 6 },
                    { 3, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9138), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9141), 3, "Winston", 0, 4 },
                    { 4, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9151), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9154), 2, "Snoopy", 0, 5 },
                    { 5, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9160), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9163), 3, "Tabatha", 0, 1 },
                    { 6, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9170), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9173), 4, "Kanga", 0, 2 },
                    { 7, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9179), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9182), 3, "Garfield", 1, 3 },
                    { 8, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9191), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9193), 3, "Garfield", 1, 4 },
                    { 9, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9200), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9203), 1, "Peter", 0, 4 },
                    { 10, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9210), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9213), 2, "Garfield", 0, 3 },
                    { 11, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9304), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9307), 1, "Garfield", 1, 1 },
                    { 12, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9317), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9319), 4, "Pooh", 0, 2 },
                    { 13, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9326), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9329), 2, "Mickey", 0, 4 },
                    { 14, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9335), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9338), 2, "Winston", 1, 3 },
                    { 15, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9344), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9347), 3, "Spot", 1, 5 },
                    { 16, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9356), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9358), 1, "Kanga", 0, 6 },
                    { 17, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9365), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9368), 2, "Mickey", 0, 3 },
                    { 18, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9374), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9377), 1, "Piglet", 1, 1 },
                    { 19, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9384), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9387), 2, "Peter", 1, 3 },
                    { 20, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9395), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9398), 4, "Garfield", 0, 3 },
                    { 21, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9404), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9407), 2, "Winston", 0, 1 },
                    { 22, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9413), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9416), 2, "Peter", 0, 1 },
                    { 23, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9423), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9426), 2, "Winston", 1, 1 },
                    { 24, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9434), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9437), 4, "Mickey", 1, 4 },
                    { 25, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9443), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9446), 1, "Peter", 1, 3 },
                    { 26, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9452), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9455), 2, "Piglet", 1, 1 },
                    { 27, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9462), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9464), 3, "Piglet", 1, 3 },
                    { 28, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9473), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9476), 1, "Mickey", 0, 3 },
                    { 29, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9482), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9485), 1, "Piglet", 0, 5 },
                    { 30, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9491), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9494), 3, "Daffy", 1, 6 },
                    { 31, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9501), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9503), 4, "Tabatha", 1, 1 },
                    { 32, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9512), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9515), 3, "Kanga", 1, 4 },
                    { 33, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9521), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9524), 3, "Peter", 1, 1 },
                    { 34, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9530), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9533), 3, "Kanga", 0, 5 },
                    { 35, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9540), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9542), 2, "Daffy", 0, 4 },
                    { 36, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9551), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9554), 4, "Winston", 0, 1 },
                    { 37, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9560), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9563), 1, "Piglet", 1, 5 },
                    { 38, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9569), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9572), 3, "Peter", 0, 1 },
                    { 39, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9579), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9582), 4, "Pooh", 0, 1 },
                    { 40, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9590), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9593), 3, "Garfield", 0, 6 },
                    { 41, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9599), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9602), 1, "Snoopy", 1, 2 },
                    { 42, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9608), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9611), 1, "Peter", 1, 1 },
                    { 43, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9617), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9620), 1, "Peter", 0, 6 },
                    { 44, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9628), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9631), 3, "Garfield", 0, 2 },
                    { 45, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9638), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9640), 1, "Kanga", 1, 2 },
                    { 46, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9647), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9650), 1, "Peter", 0, 2 },
                    { 47, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9656), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9659), 2, "Garfield", 0, 1 },
                    { 48, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9668), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9670), 4, "Winston", 0, 5 },
                    { 49, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9677), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9679), 4, "Peter", 1, 2 },
                    { 50, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9686), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9689), 2, "Snoopy", 0, 5 },
                    { 51, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9695), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9698), 1, "Tabatha", 0, 5 },
                    { 52, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9706), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9709), 2, "Garfield", 1, 5 },
                    { 53, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9715), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9718), 4, "Daffy", 0, 4 },
                    { 54, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9725), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9728), 2, "Pooh", 0, 4 },
                    { 55, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9734), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9737), 4, "Pooh", 0, 1 },
                    { 56, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9803), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9806), 4, "Winston", 0, 3 },
                    { 57, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9812), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9815), 3, "Tabatha", 0, 2 },
                    { 58, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9824), 3, "Spot", 1, 6 },
                    { 59, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9831), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9833), 4, "Garfield", 1, 3 },
                    { 60, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9842), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9845), 4, "Peter", 1, 5 },
                    { 61, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9851), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9854), 4, "Daffy", 0, 2 },
                    { 62, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9860), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9863), 4, "Peter", 0, 4 },
                    { 63, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9869), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9872), 3, "Kanga", 1, 1 },
                    { 64, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9880), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9883), 4, "Daffy", 0, 3 },
                    { 65, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9889), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9892), 4, "Spot", 1, 5 },
                    { 66, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9898), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9901), 3, "Kanga", 0, 3 },
                    { 67, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9907), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9910), 3, "Kanga", 1, 5 },
                    { 68, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9918), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9921), 1, "Kanga", 1, 3 },
                    { 69, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9927), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9930), 4, "Snoopy", 1, 5 },
                    { 70, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9936), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9939), 4, "Mickey", 1, 4 },
                    { 71, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9945), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9948), 2, "Pooh", 1, 2 },
                    { 72, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9956), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9959), 2, "Kanga", 1, 3 },
                    { 73, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9965), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9968), 2, "Peter", 0, 4 },
                    { 74, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9974), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9977), 4, "Winston", 1, 2 },
                    { 75, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9983), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9986), 3, "Kanga", 1, 6 },
                    { 76, new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9994), new DateTime(2024, 3, 6, 21, 40, 49, 802, DateTimeKind.Utc).AddTicks(9997), 3, "Kanga", 0, 4 },
                    { 77, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(4), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(6), 3, "Winston", 0, 1 },
                    { 78, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(13), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(16), 1, "Piglet", 0, 1 },
                    { 79, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(22), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(25), 3, "Winston", 1, 5 },
                    { 80, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(33), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(36), 2, "Snoopy", 1, 3 },
                    { 81, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(42), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(45), 4, "Mickey", 0, 2 },
                    { 82, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(52), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(55), 1, "Spot", 0, 4 },
                    { 83, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(61), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(64), 3, "Winston", 1, 4 },
                    { 84, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(72), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(75), 2, "Piglet", 0, 2 },
                    { 85, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(81), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(84), 3, "Snoopy", 0, 3 },
                    { 86, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(91), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(93), 3, "Winston", 1, 4 },
                    { 87, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(100), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(103), 4, "Tabatha", 0, 5 },
                    { 88, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(111), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(114), 4, "Garfield", 0, 5 },
                    { 89, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(121), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(124), 2, "Peter", 1, 3 },
                    { 90, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(130), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(133), 2, "Spot", 1, 2 },
                    { 91, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(140), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(142), 2, "Daffy", 0, 4 },
                    { 92, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(151), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(153), 2, "Peter", 1, 4 },
                    { 93, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(160), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(163), 1, "Daffy", 0, 6 },
                    { 94, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(169), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(172), 3, "Daffy", 1, 6 },
                    { 95, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(179), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(182), 4, "Garfield", 1, 2 },
                    { 96, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(190), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(193), 1, "Daffy", 1, 1 },
                    { 97, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(199), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(202), 4, "Spot", 1, 6 },
                    { 98, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(208), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(211), 3, "Mickey", 1, 3 },
                    { 99, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(217), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(220), 4, "Garfield", 1, 4 },
                    { 100, new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(269), new DateTime(2024, 3, 6, 21, 40, 49, 803, DateTimeKind.Utc).AddTicks(272), 2, "Garfield", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_EnclosureId",
                table: "Animals",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Enclosures");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
