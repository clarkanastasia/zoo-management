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
                    { -5, 10, 0 },
                    { -4, 10, 4 },
                    { -3, 40, 2 },
                    { -2, 50, 1 },
                    { -1, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Classification", "Name" },
                values: new object[,]
                {
                    { -7, 2, "parrot" },
                    { -6, 0, "hippo" },
                    { -5, 0, "giraffe" },
                    { -4, 1, "snake" },
                    { -3, 0, "zebra" },
                    { -2, 0, "elephant" },
                    { -1, 0, "lion" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "DateOfAcquisition", "DateOfBirth", "EnclosureId", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { -100, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8120), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8123), -4, "Pooh", 0, -4 },
                    { -99, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8110), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8113), -2, "Garfield", 0, -4 },
                    { -98, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8101), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8104), -5, "Mickey", 1, -7 },
                    { -97, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8090), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8093), -5, "Garfield", 0, -3 },
                    { -96, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8081), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8084), -1, "Winston", 0, -5 },
                    { -95, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8071), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8074), -4, "Mickey", 0, -3 },
                    { -94, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8062), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8065), -1, "Piglet", 0, -3 },
                    { -93, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8051), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8054), -2, "Pooh", 1, -4 },
                    { -92, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8042), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8044), -5, "Piglet", 0, -7 },
                    { -91, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8032), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8035), -1, "Piglet", 1, -6 },
                    { -90, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8023), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8026), -1, "Piglet", 1, -2 },
                    { -89, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8011), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8014), -3, "Winston", 1, -2 },
                    { -88, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8002), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(8005), -3, "Mickey", 0, -4 },
                    { -87, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7993), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7996), -3, "Tabatha", 0, -3 },
                    { -86, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7984), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7987), -2, "Mickey", 1, -7 },
                    { -85, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7973), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7975), -3, "Mickey", 1, -1 },
                    { -84, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7963), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7966), -5, "Mickey", 1, -3 },
                    { -83, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7954), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7957), -4, "Snoopy", 0, -5 },
                    { -82, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7944), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7947), -2, "Winston", 1, -6 },
                    { -81, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7933), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7936), -2, "Peter", 1, -5 },
                    { -80, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7924), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7927), -2, "Winston", 1, -4 },
                    { -79, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7915), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7918), -4, "Garfield", 0, -2 },
                    { -78, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7905), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7908), -4, "Winston", 1, -7 },
                    { -77, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7894), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7897), -1, "Mickey", 1, -6 },
                    { -76, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7885), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7887), -3, "Piglet", 0, -5 },
                    { -75, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7875), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7878), -3, "Snoopy", 0, -1 },
                    { -74, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7866), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7869), -3, "Daffy", 1, -2 },
                    { -73, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7855), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7858), -4, "Garfield", 0, -4 },
                    { -72, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7845), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7848), -3, "Spot", 0, -7 },
                    { -71, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7836), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7839), -3, "Peter", 1, -6 },
                    { -70, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7826), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7829), -5, "Kanga", 0, -6 },
                    { -69, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7790), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7793), -3, "Winston", 0, -3 },
                    { -68, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7781), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7784), -3, "Snoopy", 0, -7 },
                    { -67, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7771), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7774), -1, "Kanga", 0, -3 },
                    { -66, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7762), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7765), -3, "Snoopy", 0, -7 },
                    { -65, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7751), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7754), -3, "Garfield", 1, -4 },
                    { -64, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7742), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7745), -3, "Daffy", 0, -3 },
                    { -63, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7733), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7736), -3, "Pooh", 0, -4 },
                    { -62, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7724), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7726), -2, "Kanga", 0, -7 },
                    { -61, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7712), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7715), -2, "Piglet", 1, -1 },
                    { -60, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7703), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7706), -5, "Winston", 0, -7 },
                    { -59, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7694), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7697), -4, "Snoopy", 1, -5 },
                    { -58, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7684), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7687), -5, "Piglet", 0, -4 },
                    { -57, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7673), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7676), -4, "Spot", 1, -6 },
                    { -56, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7664), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7667), -3, "Tabatha", 1, -7 },
                    { -55, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7655), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7658), -5, "Tabatha", 0, -2 },
                    { -54, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7645), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7648), -2, "Tabatha", 0, -4 },
                    { -53, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7634), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7637), -1, "Snoopy", 1, -1 },
                    { -52, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7625), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7628), -1, "Garfield", 0, -2 },
                    { -51, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7616), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7619), -2, "Snoopy", 0, -5 },
                    { -50, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7607), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7610), -1, "Tabatha", 0, -7 },
                    { -49, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7595), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7598), -5, "Piglet", 1, -1 },
                    { -48, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7586), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7589), -1, "Kanga", 1, -7 },
                    { -47, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7577), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7580), -1, "Mickey", 1, -4 },
                    { -46, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7568), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7571), -2, "Piglet", 1, -1 },
                    { -45, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7556), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7559), -4, "Daffy", 1, -6 },
                    { -44, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7547), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7550), -1, "Snoopy", 0, -1 },
                    { -43, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7538), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7541), -5, "Garfield", 0, -1 },
                    { -42, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7529), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7532), -3, "Garfield", 0, -4 },
                    { -41, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7518), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7521), -2, "Garfield", 1, -2 },
                    { -40, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7508), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7511), -4, "Pooh", 1, -6 },
                    { -39, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7499), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7502), -5, "Winston", 1, -3 },
                    { -38, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7490), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7493), -3, "Piglet", 0, -3 },
                    { -37, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7479), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7482), -1, "Peter", 1, -7 },
                    { -36, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7470), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7472), -3, "Snoopy", 0, -6 },
                    { -35, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7460), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7463), -2, "Tabatha", 1, -4 },
                    { -34, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7451), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7454), -4, "Spot", 1, -5 },
                    { -33, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7440), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7443), -4, "Peter", 0, -3 },
                    { -32, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7431), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7434), -5, "Winston", 0, -7 },
                    { -31, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7421), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7424), -1, "Pooh", 1, -3 },
                    { -30, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7412), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7415), -3, "Peter", 1, -3 },
                    { -29, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7401), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7404), -3, "Garfield", 1, -6 },
                    { -28, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7392), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7395), -4, "Peter", 0, -6 },
                    { -27, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7383), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7385), -5, "Tabatha", 1, -1 },
                    { -26, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7372), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7376), -2, "Snoopy", 0, -5 },
                    { -25, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7311), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7314), -1, "Spot", 0, -2 },
                    { -24, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7301), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7304), -3, "Daffy", 0, -4 },
                    { -23, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7292), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7295), -4, "Peter", 0, -7 },
                    { -22, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7283), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7286), -3, "Peter", 1, -4 },
                    { -21, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7272), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7275), -1, "Snoopy", 1, -5 },
                    { -20, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7262), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7265), -1, "Mickey", 0, -5 },
                    { -19, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7253), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7256), -5, "Kanga", 1, -4 },
                    { -18, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7244), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7247), -1, "Spot", 1, -2 },
                    { -17, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7233), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7236), -4, "Daffy", 1, -2 },
                    { -16, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7224), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7227), -2, "Piglet", 0, -7 },
                    { -15, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7214), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7217), -1, "Winston", 1, -3 },
                    { -14, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7205), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7208), -4, "Tabatha", 1, -2 },
                    { -13, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7194), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7197), -3, "Garfield", 1, -1 },
                    { -12, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7185), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7188), -3, "Pooh", 0, -1 },
                    { -11, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7175), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7178), -3, "Spot", 1, -6 },
                    { -10, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7166), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7169), -5, "Snoopy", 1, -1 },
                    { -9, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7155), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7158), -4, "Winston", 1, -7 },
                    { -8, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7146), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7148), -3, "Pooh", 1, -6 },
                    { -7, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7136), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7139), -2, "Spot", 0, -2 },
                    { -6, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7130), -3, "Piglet", 0, -1 },
                    { -5, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7115), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7118), -3, "Spot", 1, -6 },
                    { -4, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7106), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7109), -5, "Daffy", 0, -2 },
                    { -3, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7096), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7099), -1, "Garfield", 0, -6 },
                    { -2, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7086), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7089), -5, "Mickey", 1, -5 },
                    { -1, new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7001), new DateTime(2024, 3, 7, 13, 37, 5, 822, DateTimeKind.Utc).AddTicks(7063), -5, "Mickey", 0, -5 }
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
