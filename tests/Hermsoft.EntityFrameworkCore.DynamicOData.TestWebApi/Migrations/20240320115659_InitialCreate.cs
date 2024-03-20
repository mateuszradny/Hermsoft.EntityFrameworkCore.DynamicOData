using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OderedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Price" },
                values: new object[,]
                {
                    { new Guid("3506cfdf-45ff-4309-8d6e-96953b411db5"), 0, "Enim reprehenderit ratione quis vel.\nUllam harum delectus cum corporis.\nNumquam quo laborum quis dolorem provident nihil atque.\nAutem quia vel animi atque doloremque amet.\nIncidunt rerum libero ab.", 313.744050048589570m },
                    { new Guid("5afb1f49-b2f0-4763-a873-53fbee4d5ea0"), 0, "Quae alias tempore.\nId rerum et rem ratione dicta necessitatibus.\nPraesentium voluptates totam laboriosam eaque reiciendis neque tempora ipsam quia.\nMaxime ut nihil veniam.\nMaxime temporibus ut dolore nesciunt quo eius molestiae.", 404.397414031759810m },
                    { new Guid("61e48d59-280f-4353-8e92-056364a8b0c8"), 1, "Cupiditate quidem dignissimos sunt culpa.\nEt autem rerum aut.\nEst totam assumenda animi quam.\nTempore dolores aut et dolores.\nEst enim voluptatem.", 489.069272819944590m },
                    { new Guid("64ee64aa-2b73-4bb9-8b4f-e71cc1e3ab66"), 1, "Quia dicta id similique dolor impedit qui voluptas voluptatem natus.\nDoloribus ducimus necessitatibus.\nModi aperiam dolorem nostrum.\nQuo dolores natus quidem ea sunt sed dolorum sed ipsum.\nDolorem consequatur eos voluptate eaque quaerat autem non expedita.", 472.975635138031260m },
                    { new Guid("7068c1aa-f8ba-4cda-b948-92b3ae9d2d84"), 0, "Cumque quibusdam nulla sed ducimus aperiam eaque libero sunt aut.\nCum eum adipisci inventore iusto blanditiis velit.\nSoluta eveniet adipisci impedit sunt suscipit hic voluptas recusandae.\nAutem aut quidem id et.\nIpsum ea sit ut ea dolor numquam.", 442.946250739041970m },
                    { new Guid("aab6b14e-dbbf-42e1-a1ab-e3f079169d8a"), 2, "A expedita reiciendis illo minima doloribus beatae nesciunt quidem.\nEt repellendus maxime laborum omnis voluptatem ea labore earum vitae.\nQuia dolores voluptate sed.\nNihil repudiandae ut odio sapiente fugiat beatae.\nIste id laborum.", 185.909284769374380m },
                    { new Guid("b9547288-646c-40f4-a12d-c6392be029a9"), 0, "Praesentium velit voluptatem reprehenderit.\nEnim consequuntur aut harum ullam dolorem blanditiis sed vero.\nOccaecati cumque nulla vel.\nEt ut id mollitia harum pariatur blanditiis rerum excepturi sed.\nIllum cum accusamus vero dolorem itaque suscipit quae.", 159.784193200983180m },
                    { new Guid("c2cc2294-7473-4d13-be4d-2bfecb452cee"), 0, "Et sunt quo harum explicabo sint tenetur.\nEnim fuga repudiandae.\nQuisquam qui voluptatem inventore neque saepe.\nEa est laudantium cupiditate.\nVoluptatem ut ut ab voluptatibus ducimus quo et quia debitis.", 186.665222618532340m },
                    { new Guid("dbff6dac-e1a0-400d-95b6-97726cb8c220"), 2, "Vel qui qui mollitia aut.\nIn sit quam odio aspernatur distinctio labore nesciunt.\nVelit et non sit nulla doloribus suscipit.\nNihil itaque illum facilis.\nRepellendus ut blanditiis vel laudantium esse culpa eum deserunt perspiciatis.", 291.989514051445760m },
                    { new Guid("f288ffef-8cc5-47db-9f47-670f31e089c3"), 2, "Quod amet repudiandae adipisci sit molestiae earum modi.\nA eaque dolore quas aspernatur non reprehenderit.\nModi unde ullam quisquam quam.\nQuidem eos corrupti est ratione ullam.\nVoluptate magni minus ullam porro dolor sunt.", 72.434936204608380m }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), "International Security Associate" },
                    { new Guid("3c45b109-7fe7-4d13-833f-a362dad09255"), "Customer Integration Producer" },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), "Direct Configuration Analyst" },
                    { new Guid("84270375-4a7b-4191-9365-27515e326c07"), "Human Configuration Architect" },
                    { new Guid("9847f812-bc9f-4202-b3cf-ab4736ac4b83"), "Forward Paradigm Supervisor" },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), "Investor Infrastructure Associate" },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), "Corporate Brand Planner" },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), "Central Identity Officer" },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), "Regional Functionality Architect" },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), "Investor Factors Director" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b"), "Aurelie_Murphy8@gmail.com", "Aurelie" },
                    { new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e"), "Leola_Bartell24@hotmail.com", "Leola" },
                    { new Guid("2704a669-6a44-461f-98d0-e8d3f4459525"), "Alisa.Kertzmann66@yahoo.com", "Alisa" },
                    { new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81"), "Mason_Prohaska@gmail.com", "Mason" },
                    { new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31"), "Lula_Hagenes83@hotmail.com", "Lula" },
                    { new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a"), "Hailey35@yahoo.com", "Hailey" },
                    { new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12"), "Alvina.Beahan41@gmail.com", "Alvina" },
                    { new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da"), "Terrence8@hotmail.com", "Terrence" },
                    { new Guid("d5eb7384-bb02-432e-a984-53717aef48aa"), "Emile_Jacobs16@hotmail.com", "Emile" },
                    { new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252"), "Garland32@hotmail.com", "Garland" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OderedOn", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2019, 6, 27, 9, 50, 45, 837, DateTimeKind.Unspecified).AddTicks(9546), new TimeSpan(0, 1, 0, 0, 0)), 3297.142318029015820m, new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") },
                    { 2, new DateTimeOffset(new DateTime(2019, 12, 7, 8, 26, 8, 780, DateTimeKind.Unspecified).AddTicks(6962), new TimeSpan(0, 1, 0, 0, 0)), 2858.994959849721820m, new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { 3, new DateTimeOffset(new DateTime(2020, 5, 1, 19, 10, 41, 229, DateTimeKind.Unspecified).AddTicks(423), new TimeSpan(0, 1, 0, 0, 0)), 3163.810148245459630m, new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { 4, new DateTimeOffset(new DateTime(2022, 2, 16, 8, 52, 52, 659, DateTimeKind.Unspecified).AddTicks(9683), new TimeSpan(0, 1, 0, 0, 0)), 3603.499611863080270m, new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { 5, new DateTimeOffset(new DateTime(2020, 5, 24, 14, 55, 39, 164, DateTimeKind.Unspecified).AddTicks(4947), new TimeSpan(0, 1, 0, 0, 0)), 6735.676321353297880m, new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") },
                    { 6, new DateTimeOffset(new DateTime(2024, 1, 27, 8, 42, 57, 841, DateTimeKind.Unspecified).AddTicks(1070), new TimeSpan(0, 1, 0, 0, 0)), 4233.250988790866560m, new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { 7, new DateTimeOffset(new DateTime(2022, 7, 18, 21, 24, 50, 523, DateTimeKind.Unspecified).AddTicks(1039), new TimeSpan(0, 1, 0, 0, 0)), 4606.61770865728030m, new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { 8, new DateTimeOffset(new DateTime(2022, 3, 11, 12, 49, 42, 827, DateTimeKind.Unspecified).AddTicks(4517), new TimeSpan(0, 1, 0, 0, 0)), 3279.493968512423020m, new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { 9, new DateTimeOffset(new DateTime(2022, 7, 18, 22, 52, 54, 974, DateTimeKind.Unspecified).AddTicks(76), new TimeSpan(0, 1, 0, 0, 0)), 1333.860271952596060m, new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { 10, new DateTimeOffset(new DateTime(2022, 3, 7, 23, 34, 31, 626, DateTimeKind.Unspecified).AddTicks(7022), new TimeSpan(0, 1, 0, 0, 0)), 6213.46954525338790m, new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("3c45b109-7fe7-4d13-833f-a362dad09255"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("84270375-4a7b-4191-9365-27515e326c07"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("9847f812-bc9f-4202-b3cf-ab4736ac4b83"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("00801dd5-ca2d-40a3-8a8e-75a7adfaca1b") },
                    { new Guid("3c45b109-7fe7-4d13-833f-a362dad09255"), new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e") },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e") },
                    { new Guid("84270375-4a7b-4191-9365-27515e326c07"), new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e") },
                    { new Guid("9847f812-bc9f-4202-b3cf-ab4736ac4b83"), new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e") },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e") },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("0af908c1-ed6c-49c8-91c2-30bedee5469e") },
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { new Guid("3c45b109-7fe7-4d13-833f-a362dad09255"), new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { new Guid("84270375-4a7b-4191-9365-27515e326c07"), new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("2704a669-6a44-461f-98d0-e8d3f4459525") },
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { new Guid("3c45b109-7fe7-4d13-833f-a362dad09255"), new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { new Guid("9847f812-bc9f-4202-b3cf-ab4736ac4b83"), new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("85b9dcb2-5dea-43aa-a6a2-85345145be81") },
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { new Guid("9847f812-bc9f-4202-b3cf-ab4736ac4b83"), new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("8f96dda5-97f5-45a8-a3e1-5bc40d31bf31") },
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a") },
                    { new Guid("3c45b109-7fe7-4d13-833f-a362dad09255"), new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a") },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a") },
                    { new Guid("84270375-4a7b-4191-9365-27515e326c07"), new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a") },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a") },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("ab0d1ecb-ca32-4410-b9fb-66227beafb2a") },
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12") },
                    { new Guid("3c45b109-7fe7-4d13-833f-a362dad09255"), new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12") },
                    { new Guid("84270375-4a7b-4191-9365-27515e326c07"), new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12") },
                    { new Guid("9847f812-bc9f-4202-b3cf-ab4736ac4b83"), new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12") },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12") },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("b9fa8877-2987-411e-b01a-a8f8f468aa12") },
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { new Guid("3c45b109-7fe7-4d13-833f-a362dad09255"), new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { new Guid("84270375-4a7b-4191-9365-27515e326c07"), new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { new Guid("9847f812-bc9f-4202-b3cf-ab4736ac4b83"), new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("d44979b3-d2b7-4228-85cf-6d3eb6c4c4da") },
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { new Guid("3c45b109-7fe7-4d13-833f-a362dad09255"), new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { new Guid("84270375-4a7b-4191-9365-27515e326c07"), new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { new Guid("9847f812-bc9f-4202-b3cf-ab4736ac4b83"), new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("d5eb7384-bb02-432e-a984-53717aef48aa") },
                    { new Guid("12b0ad2d-b2b8-43a5-8d43-ae98fb5b9933"), new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") },
                    { new Guid("53f83577-9bd2-4cb1-9dbf-94f0bc9bd08b"), new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") },
                    { new Guid("84270375-4a7b-4191-9365-27515e326c07"), new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") },
                    { new Guid("aa3499e8-35dd-4807-a336-1d0d147942e1"), new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") },
                    { new Guid("ded8b2d6-bf6c-4bd8-a01a-a67863307d24"), new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") },
                    { new Guid("e2045953-adf6-41c6-b823-64661714aac3"), new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") },
                    { new Guid("ecc1caaa-3a3c-4fb9-aa43-a2c10f4d4b11"), new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") },
                    { new Guid("feaa9549-1a3d-4798-abc3-c0d2445b8aca"), new Guid("fcac228e-f7e7-42e4-b34d-5516d9460252") }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "Number" },
                values: new object[,]
                {
                    { 1, new Guid("61e48d59-280f-4353-8e92-056364a8b0c8"), 7 },
                    { 2, new Guid("3506cfdf-45ff-4309-8d6e-96953b411db5"), 5 },
                    { 2, new Guid("5afb1f49-b2f0-4763-a873-53fbee4d5ea0"), 1 },
                    { 2, new Guid("dbff6dac-e1a0-400d-95b6-97726cb8c220"), 8 },
                    { 4, new Guid("3506cfdf-45ff-4309-8d6e-96953b411db5"), 5 },
                    { 4, new Guid("f288ffef-8cc5-47db-9f47-670f31e089c3"), 1 },
                    { 5, new Guid("61e48d59-280f-4353-8e92-056364a8b0c8"), 10 },
                    { 5, new Guid("aab6b14e-dbbf-42e1-a1ab-e3f079169d8a"), 7 },
                    { 6, new Guid("7068c1aa-f8ba-4cda-b948-92b3ae9d2d84"), 9 },
                    { 6, new Guid("b9547288-646c-40f4-a12d-c6392be029a9"), 7 },
                    { 6, new Guid("c2cc2294-7473-4d13-be4d-2bfecb452cee"), 9 },
                    { 7, new Guid("3506cfdf-45ff-4309-8d6e-96953b411db5"), 4 },
                    { 7, new Guid("5afb1f49-b2f0-4763-a873-53fbee4d5ea0"), 2 },
                    { 7, new Guid("61e48d59-280f-4353-8e92-056364a8b0c8"), 4 },
                    { 7, new Guid("aab6b14e-dbbf-42e1-a1ab-e3f079169d8a"), 10 },
                    { 7, new Guid("b9547288-646c-40f4-a12d-c6392be029a9"), 2 },
                    { 8, new Guid("61e48d59-280f-4353-8e92-056364a8b0c8"), 9 },
                    { 8, new Guid("dbff6dac-e1a0-400d-95b6-97726cb8c220"), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
