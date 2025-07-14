using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class NameofMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RegionImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Descripton = table.Column<string>(type: "text", nullable: false),
                    LengthInKm = table.Column<double>(type: "double precision", nullable: false),
                    WalkImageUrl = table.Column<string>(type: "text", nullable: true),
                    DifficultyId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2753b649-7f84-41d5-9002-aa5caec518c3"), "Medium" },
                    { new Guid("27e7b6b0-11c4-4b57-a152-ed9deea60be1"), "Hard" },
                    { new Guid("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("a1f70de2-9c49-4cf1-9d2b-3eaa2bc11111"), "AKL", "Auckland", "https://example.com/images/auckland.jpg" },
                    { new Guid("a6e66c53-bd5e-4c1f-a0f0-6c7f3f1b2c8a"), "CCC", "Christchurch", "https://example.com/images/christchurch.jpg" },
                    { new Guid("b2f70de2-9c49-4cf1-9d2b-3eaa2bc12222"), "WGN", "Wellington", "https://example.com/images/wellington.jpg" },
                    { new Guid("b8c7f8e2-9c29-4e3a-b0d1-5c8d7e3f8c9e"), "DAE", "Dunedin", "https://example.com/images/dunedin.jpg" },
                    { new Guid("c3f70de2-9c49-4cf1-9d2b-3eaa2bc13333"), "CHC", "Christchurch", "https://example.com/images/christchurch.jpg" },
                    { new Guid("c9d3c5b1-9f5c-4f3c-8f4a-5e9a2f3b3f1e"), "NPL", "Napier", "https://example.com/images/napier.jpg" },
                    { new Guid("d4f70de2-9c49-4cf1-9d2b-3eaa2bc14444"), "DUD", "Dunedin", "https://example.com/images/dunedin.jpg" },
                    { new Guid("d57f1a68-3a3b-4d4c-bfe8-1b1e7b0c8c8d"), "AEL", "Auckland", "https://example.com/images/auckland.jpg" },
                    { new Guid("e5f70de2-9c49-4cf1-9d2b-3eaa2bc15555"), "ROT", "Rotorua", "https://example.com/images/rotorua.jpg" },
                    { new Guid("f5e6b1c4-f8e7-4d7b-bd6e-8d3bcf7d3e7e"), "WLG", "Wellington", "https://example.com/images/wellington.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Descripton", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("f0f70de2-9c49-4cf1-9d2b-3eaa2bc16676"), "A unique walk among the treetops.", new Guid("2753b649-7f84-41d5-9002-aa5caec518c3"), 3.3999999999999999, "Treetop Walk", new Guid("a6e66c53-bd5e-4c1f-a0f0-6c7f3f1b2c8a"), "https://example.com/walks/treetop.jpg" },
                    { new Guid("f1f70de2-9c49-4cf1-9d2b-3eaa2bc16661"), "Beautiful track along the coast.", new Guid("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), 5.2000000000000002, "Coastal Track", new Guid("a1f70de2-9c49-4cf1-9d2b-3eaa2bc11111"), "https://example.com/walks/coastal.jpg" },
                    { new Guid("f1f70de2-9c49-4cf1-9d2b-3eaa2bc16677"), "A serene walk through the botanical gardens.", new Guid("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), 2.2000000000000002, "Botanical Garden Trail", new Guid("b8c7f8e2-9c29-4e3a-b0d1-5c8d7e3f8c9e"), "https://example.com/walks/botanical.jpg" },
                    { new Guid("f2f70de2-9c49-4cf1-9d2b-3eaa2bc16662"), "Challenging hike up the mountain.", new Guid("27e7b6b0-11c4-4b57-a152-ed9deea60be1"), 12.699999999999999, "Mountain Hike", new Guid("c3f70de2-9c49-4cf1-9d2b-3eaa2bc13333"), "https://example.com/walks/mountain.jpg" },
                    { new Guid("f3f70de2-9c49-4cf1-9d2b-3eaa2bc16663"), "Shady forest walk for all skill levels.", new Guid("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), 3.1000000000000001, "Forest Trail", new Guid("b2f70de2-9c49-4cf1-9d2b-3eaa2bc12222"), "https://example.com/walks/forest.jpg" },
                    { new Guid("f4f70de2-9c49-4cf1-9d2b-3eaa2bc16664"), "Relaxing walk around the lake.", new Guid("2753b649-7f84-41d5-9002-aa5caec518c3"), 4.0, "Lake Loop", new Guid("e5f70de2-9c49-4cf1-9d2b-3eaa2bc15555"), "https://example.com/walks/lake.jpg" },
                    { new Guid("f5f70de2-9c49-4cf1-9d2b-3eaa2bc16665"), "Medium difficulty hike with great views.", new Guid("2753b649-7f84-41d5-9002-aa5caec518c3"), 6.7999999999999998, "Hill Climb", new Guid("d4f70de2-9c49-4cf1-9d2b-3eaa2bc14444"), "https://example.com/walks/hill.jpg" },
                    { new Guid("f6f70de2-9c49-4cf1-9d2b-3eaa2bc16666"), "Scenic walk along the riverbank.", new Guid("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), 4.5, "River Walk", new Guid("b2f70de2-9c49-4cf1-9d2b-3eaa2bc12222"), "https://example.com/walks/river.jpg" },
                    { new Guid("f7f70de2-9c49-4cf1-9d2b-3eaa2bc16667"), "A challenging walk through a desert landscape.", new Guid("27e7b6b0-11c4-4b57-a152-ed9deea60be1"), 10.0, "Desert Trail", new Guid("d4f70de2-9c49-4cf1-9d2b-3eaa2bc14444"), "https://example.com/walks/desert.jpg" },
                    { new Guid("f8f70de2-9c49-4cf1-9d2b-3eaa2bc16668"), "Explore the city on this urban trail.", new Guid("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), 5.0, "Urban Walk", new Guid("a1f70de2-9c49-4cf1-9d2b-3eaa2bc11111"), "https://example.com/walks/urban.jpg" },
                    { new Guid("f9f70de2-9c49-4cf1-9d2b-3eaa2bc16669"), "A beautiful trail lined with wildflowers.", new Guid("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), 3.6000000000000001, "Wildflower Path", new Guid("c3f70de2-9c49-4cf1-9d2b-3eaa2bc13333"), "https://example.com/walks/wildflower.jpg" },
                    { new Guid("fae70de2-9c49-4cf1-9d2b-3eaa2bc16670"), "Stunning views of the canyon.", new Guid("27e7b6b0-11c4-4b57-a152-ed9deea60be1"), 7.5, "Canyon View", new Guid("d4f70de2-9c49-4cf1-9d2b-3eaa2bc14444"), "https://example.com/walks/canyon.jpg" },
                    { new Guid("fbf70de2-9c49-4cf1-9d2b-3eaa2bc16671"), "A picturesque walk, perfect for sunsets.", new Guid("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), 4.7999999999999998, "Sunset Trail", new Guid("b2f70de2-9c49-4cf1-9d2b-3eaa2bc12222"), "https://example.com/walks/sunset.jpg" },
                    { new Guid("fcf70de2-9c49-4cf1-9d2b-3eaa2bc16672"), "Walk through history on this guided trail.", new Guid("2753b649-7f84-41d5-9002-aa5caec518c3"), 6.0, "Historical Route", new Guid("a1f70de2-9c49-4cf1-9d2b-3eaa2bc11111"), "https://example.com/walks/historical.jpg" },
                    { new Guid("fde70de2-9c49-4cf1-9d2b-3eaa2bc16673"), "An exhilarating walk along the cliffs.", new Guid("27e7b6b0-11c4-4b57-a152-ed9deea60be1"), 8.3000000000000007, "Cliffside Walk", new Guid("c3f70de2-9c49-4cf1-9d2b-3eaa2bc13333"), "https://example.com/walks/cliffside.jpg" },
                    { new Guid("fee70de2-9c49-4cf1-9d2b-3eaa2bc16674"), "A relaxing walk along the beach.", new Guid("3caf2feb-8230-4e81-a8ae-202af8e1a93d"), 2.5, "Beach Walk", new Guid("e5f70de2-9c49-4cf1-9d2b-3eaa2bc15555"), "https://example.com/walks/beach.jpg" },
                    { new Guid("fff70de2-9c49-4cf1-9d2b-3eaa2bc16675"), "A trek to the snowy peaks.", new Guid("27e7b6b0-11c4-4b57-a152-ed9deea60be1"), 15.0, "Snowy Peak Hike", new Guid("f5e6b1c4-f8e7-4d7b-bd6e-8d3bcf7d3e7e"), "https://example.com/walks/snowypeak.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
