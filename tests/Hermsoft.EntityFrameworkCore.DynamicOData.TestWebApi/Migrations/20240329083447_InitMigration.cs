using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "sales",
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
                schema: "sales",
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
                schema: "sales",
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
                schema: "sales",
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
                        principalSchema: "sales",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "sales",
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
                        principalSchema: "sales",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sales",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                schema: "sales",
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
                        principalSchema: "sales",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "sales",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Price" },
                values: new object[,]
                {
                    { new Guid("1f63a613-2ca0-4858-b94b-e6419dd1197b"), 1, "Voluptatem autem similique vero vel ea ratione reprehenderit architecto ex.\nVoluptatem nulla impedit nisi.\nEos nobis vel qui sed quo ex.\nVoluptatem sapiente fuga consequatur dolore.\nEos voluptas nesciunt.", 162.974443957554310m },
                    { new Guid("1fd5ab82-b7fc-45ff-b53e-50409c07585b"), 0, "Et deleniti alias similique consequatur est molestiae aut voluptates et.\nAutem libero magni vero quis qui inventore doloremque qui et.\nSuscipit facilis tenetur et ab similique ab.\nRecusandae velit ut voluptatem excepturi et et officiis quia ut.\nVoluptates pariatur sit.", 465.883130502119880m },
                    { new Guid("25b0d695-0f39-4095-aaaa-f93b4720c5c4"), 1, "Ex voluptatem saepe praesentium ullam molestiae reprehenderit harum quos dolores.\nRerum autem dolor ut occaecati eveniet nemo ut nulla.\nEum quisquam cupiditate harum.\nEveniet dicta aut aut repellendus saepe vero culpa.\nQuia ut voluptate voluptate.", 200.534207402497630m },
                    { new Guid("308fe456-1d7e-414c-b80d-1dc9c9e354b9"), 2, "Doloremque odit sit.\nQuidem vero dolorem nulla voluptatem.\nEx qui dolores dolor ut tempore.\nRerum aspernatur et sed consequatur.\nItaque ducimus voluptate quam qui ad voluptatem.", 340.819338629430490m },
                    { new Guid("3fc279a5-b88d-44bd-85d3-03c276bd1b11"), 0, "Adipisci voluptas nihil magni nobis neque quo.\nEnim facere rerum suscipit suscipit.\nIusto aspernatur non rerum voluptatibus magnam aut sint et consequuntur.\nIpsam voluptatem qui rerum.\nEligendi magni rerum.", 122.290348402171870m },
                    { new Guid("7981f46b-bbd5-4b0b-b8ce-8d2a43f205ea"), 2, "Esse ad porro voluptatum aut molestiae in quibusdam est.\nPorro dolores voluptatem et accusamus iste.\nQuo enim molestias et aliquid aut et commodi voluptatibus.\nVoluptatem quasi inventore dignissimos quam est.\nPariatur quos incidunt repellat similique repellendus et.", 409.545110452462380m },
                    { new Guid("8a373229-f68d-443e-b2e6-3476ba8b9c83"), 1, "Et sit enim voluptas nemo.\nVoluptates cumque ut exercitationem minima aspernatur et molestias.\nVoluptas maiores nulla aut consequuntur animi.\nEsse quos harum cumque quia quia voluptate eos asperiores velit.\nUllam sint doloribus consectetur et assumenda sint.", 417.035179398569330m },
                    { new Guid("9a511daf-86ee-4e93-88c2-0baa77a6d388"), 1, "Id sint optio at dolor error quod quasi expedita fuga.\nEligendi deserunt nobis et laborum debitis sed fugiat sint esse.\nEius esse placeat vitae eaque.\nEt est nihil dolor explicabo aliquid voluptates dignissimos et.\nAtque fugit eveniet qui consequatur.", 143.460996027322530m },
                    { new Guid("d06868bb-b0a2-462f-b87c-ecb48a731684"), 2, "Adipisci perferendis voluptatum corrupti.\nIn itaque sit qui possimus consequatur ut beatae cum qui.\nEt et laudantium beatae autem mollitia vel.\nFuga aperiam fuga.\nAdipisci ut enim.", 157.889987861292110m },
                    { new Guid("ea30040a-4d3f-4f71-a81a-e6ea473afa54"), 2, "Sed necessitatibus voluptatem alias laborum qui.\nDeserunt amet et incidunt ut et voluptatem.\nQuam enim fugit fugit dolor ab sunt.\nIpsam qui blanditiis molestiae.\nRepellat modi dolore aut et maiores alias tempore libero.", 357.802131642519960m }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), "Future Optimization Director" },
                    { new Guid("5e3e9cf6-dc17-4c9e-852f-f7cc39de00c8"), "Investor Markets Engineer" },
                    { new Guid("62581e93-0bf6-402e-a225-f4b60cdfe3c2"), "Chief Research Director" },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), "International Operations Engineer" },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), "Customer Identity Consultant" },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), "Customer Directives Coordinator" },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), "Customer Program Designer" },
                    { new Guid("f7cee502-570b-409d-9e58-c086228dadc9"), "Principal Response Planner" },
                    { new Guid("f9a0826e-3011-48a1-966e-9b2882295ff1"), "Senior Accountability Developer" },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), "Direct Program Associate" }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b"), "Bryana.Ondricka22@yahoo.com", "Bryana" },
                    { new Guid("276fa469-60ff-4858-bc97-0d5ad9955791"), "Abigail_Kreiger71@hotmail.com", "Abigail" },
                    { new Guid("3ea4f195-81c5-400a-8eed-d994ed094232"), "Odell.Armstrong57@gmail.com", "Odell" },
                    { new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7"), "Lura.Beahan86@yahoo.com", "Lura" },
                    { new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3"), "Brianne_Jacobs97@hotmail.com", "Brianne" },
                    { new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c"), "Armando_Schuppe55@gmail.com", "Armando" },
                    { new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98"), "Kadin.Macejkovic@gmail.com", "Kadin" },
                    { new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02"), "Francesca56@hotmail.com", "Francesca" },
                    { new Guid("e8840eba-659e-4c76-8450-35c9f5e2225f"), "Marques.Tillman@gmail.com", "Marques" },
                    { new Guid("ec3b9b71-5663-4110-82d6-c5d9b43c0c29"), "Earl.Braun@yahoo.com", "Earl" }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "Orders",
                columns: new[] { "Id", "OderedOn", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 2, 22, 5, 32, 49, 19, DateTimeKind.Unspecified).AddTicks(8598), new TimeSpan(0, 1, 0, 0, 0)), 5602.402592016024760m, new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { 2, new DateTimeOffset(new DateTime(2019, 5, 2, 18, 7, 17, 760, DateTimeKind.Unspecified).AddTicks(404), new TimeSpan(0, 1, 0, 0, 0)), 677.1253199460393430m, new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { 3, new DateTimeOffset(new DateTime(2021, 1, 1, 8, 26, 5, 412, DateTimeKind.Unspecified).AddTicks(1991), new TimeSpan(0, 1, 0, 0, 0)), 2553.973788429856960m, new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { 4, new DateTimeOffset(new DateTime(2023, 4, 24, 1, 57, 3, 243, DateTimeKind.Unspecified).AddTicks(537), new TimeSpan(0, 1, 0, 0, 0)), 436.323012569336140m, new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { 5, new DateTimeOffset(new DateTime(2020, 9, 8, 20, 31, 2, 231, DateTimeKind.Unspecified).AddTicks(3478), new TimeSpan(0, 1, 0, 0, 0)), 2858.722970300680270m, new Guid("e8840eba-659e-4c76-8450-35c9f5e2225f") },
                    { 6, new DateTimeOffset(new DateTime(2023, 7, 6, 2, 18, 7, 195, DateTimeKind.Unspecified).AddTicks(2919), new TimeSpan(0, 1, 0, 0, 0)), 2935.213836108473320m, new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { 7, new DateTimeOffset(new DateTime(2020, 2, 18, 19, 3, 55, 191, DateTimeKind.Unspecified).AddTicks(511), new TimeSpan(0, 1, 0, 0, 0)), 3612.509413034500120m, new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { 8, new DateTimeOffset(new DateTime(2022, 5, 30, 21, 30, 24, 144, DateTimeKind.Unspecified).AddTicks(9181), new TimeSpan(0, 1, 0, 0, 0)), 1229.993892369971830m, new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { 9, new DateTimeOffset(new DateTime(2021, 7, 7, 15, 15, 0, 290, DateTimeKind.Unspecified).AddTicks(6742), new TimeSpan(0, 1, 0, 0, 0)), 2321.484828339355090m, new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c") },
                    { 10, new DateTimeOffset(new DateTime(2022, 10, 22, 2, 30, 52, 250, DateTimeKind.Unspecified).AddTicks(5578), new TimeSpan(0, 1, 0, 0, 0)), 3415.163941275399190m, new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b") },
                    { new Guid("5e3e9cf6-dc17-4c9e-852f-f7cc39de00c8"), new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b") },
                    { new Guid("62581e93-0bf6-402e-a225-f4b60cdfe3c2"), new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b") },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b") },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b") },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b") },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b") },
                    { new Guid("f7cee502-570b-409d-9e58-c086228dadc9"), new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("1bd7a0ac-a730-4396-96ce-c567756a1d1b") },
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { new Guid("5e3e9cf6-dc17-4c9e-852f-f7cc39de00c8"), new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { new Guid("62581e93-0bf6-402e-a225-f4b60cdfe3c2"), new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { new Guid("f7cee502-570b-409d-9e58-c086228dadc9"), new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { new Guid("f9a0826e-3011-48a1-966e-9b2882295ff1"), new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("276fa469-60ff-4858-bc97-0d5ad9955791") },
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { new Guid("5e3e9cf6-dc17-4c9e-852f-f7cc39de00c8"), new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { new Guid("62581e93-0bf6-402e-a225-f4b60cdfe3c2"), new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { new Guid("f9a0826e-3011-48a1-966e-9b2882295ff1"), new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("3ea4f195-81c5-400a-8eed-d994ed094232") },
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { new Guid("f7cee502-570b-409d-9e58-c086228dadc9"), new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { new Guid("f9a0826e-3011-48a1-966e-9b2882295ff1"), new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("58ffa499-e39c-49c1-9fd5-67674de9e2e7") },
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { new Guid("5e3e9cf6-dc17-4c9e-852f-f7cc39de00c8"), new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { new Guid("62581e93-0bf6-402e-a225-f4b60cdfe3c2"), new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { new Guid("f7cee502-570b-409d-9e58-c086228dadc9"), new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { new Guid("f9a0826e-3011-48a1-966e-9b2882295ff1"), new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("a2680da1-59cd-4c5e-b758-e5564eae2fb3") },
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c") },
                    { new Guid("62581e93-0bf6-402e-a225-f4b60cdfe3c2"), new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c") },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c") },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c") },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c") },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c") },
                    { new Guid("f9a0826e-3011-48a1-966e-9b2882295ff1"), new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("a66b0d01-aa75-41ed-9fbf-a01e487c537c") },
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98") },
                    { new Guid("5e3e9cf6-dc17-4c9e-852f-f7cc39de00c8"), new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98") },
                    { new Guid("62581e93-0bf6-402e-a225-f4b60cdfe3c2"), new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98") },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98") },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98") },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98") },
                    { new Guid("f7cee502-570b-409d-9e58-c086228dadc9"), new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98") },
                    { new Guid("f9a0826e-3011-48a1-966e-9b2882295ff1"), new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("c0b29ec8-8c69-48be-ab79-2292ed3a5b98") },
                    { new Guid("5e3e9cf6-dc17-4c9e-852f-f7cc39de00c8"), new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { new Guid("62581e93-0bf6-402e-a225-f4b60cdfe3c2"), new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { new Guid("f7cee502-570b-409d-9e58-c086228dadc9"), new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { new Guid("f9a0826e-3011-48a1-966e-9b2882295ff1"), new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("e19298ee-809d-48d1-bea4-6cb1a7285f02") },
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), new Guid("e8840eba-659e-4c76-8450-35c9f5e2225f") },
                    { new Guid("5e3e9cf6-dc17-4c9e-852f-f7cc39de00c8"), new Guid("e8840eba-659e-4c76-8450-35c9f5e2225f") },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), new Guid("e8840eba-659e-4c76-8450-35c9f5e2225f") },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), new Guid("e8840eba-659e-4c76-8450-35c9f5e2225f") },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), new Guid("e8840eba-659e-4c76-8450-35c9f5e2225f") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("e8840eba-659e-4c76-8450-35c9f5e2225f") },
                    { new Guid("47928d1f-d692-4f4e-8be0-2d3e8fbf6de9"), new Guid("ec3b9b71-5663-4110-82d6-c5d9b43c0c29") },
                    { new Guid("5e3e9cf6-dc17-4c9e-852f-f7cc39de00c8"), new Guid("ec3b9b71-5663-4110-82d6-c5d9b43c0c29") },
                    { new Guid("926253dd-2d35-40b4-b672-50b419586515"), new Guid("ec3b9b71-5663-4110-82d6-c5d9b43c0c29") },
                    { new Guid("b9307b02-11cc-40e8-a4af-80929c86c4c3"), new Guid("ec3b9b71-5663-4110-82d6-c5d9b43c0c29") },
                    { new Guid("cba2a3d4-cd42-4d7a-98c8-a7832ce0ec49"), new Guid("ec3b9b71-5663-4110-82d6-c5d9b43c0c29") },
                    { new Guid("cbd5b029-7a33-4d44-85c1-3a100ec03be9"), new Guid("ec3b9b71-5663-4110-82d6-c5d9b43c0c29") },
                    { new Guid("f7cee502-570b-409d-9e58-c086228dadc9"), new Guid("ec3b9b71-5663-4110-82d6-c5d9b43c0c29") },
                    { new Guid("fc420210-e68b-466a-b942-7ac851c4a970"), new Guid("ec3b9b71-5663-4110-82d6-c5d9b43c0c29") }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "Number" },
                values: new object[,]
                {
                    { 2, new Guid("1f63a613-2ca0-4858-b94b-e6419dd1197b"), 7 },
                    { 2, new Guid("3fc279a5-b88d-44bd-85d3-03c276bd1b11"), 3 },
                    { 2, new Guid("9a511daf-86ee-4e93-88c2-0baa77a6d388"), 1 },
                    { 2, new Guid("d06868bb-b0a2-462f-b87c-ecb48a731684"), 9 },
                    { 3, new Guid("ea30040a-4d3f-4f71-a81a-e6ea473afa54"), 4 },
                    { 4, new Guid("25b0d695-0f39-4095-aaaa-f93b4720c5c4"), 7 },
                    { 5, new Guid("25b0d695-0f39-4095-aaaa-f93b4720c5c4"), 10 },
                    { 5, new Guid("9a511daf-86ee-4e93-88c2-0baa77a6d388"), 3 },
                    { 6, new Guid("3fc279a5-b88d-44bd-85d3-03c276bd1b11"), 1 },
                    { 6, new Guid("7981f46b-bbd5-4b0b-b8ce-8d2a43f205ea"), 10 },
                    { 8, new Guid("308fe456-1d7e-414c-b80d-1dc9c9e354b9"), 5 },
                    { 8, new Guid("3fc279a5-b88d-44bd-85d3-03c276bd1b11"), 5 },
                    { 9, new Guid("8a373229-f68d-443e-b2e6-3476ba8b9c83"), 7 },
                    { 10, new Guid("25b0d695-0f39-4095-aaaa-f93b4720c5c4"), 2 },
                    { 10, new Guid("3fc279a5-b88d-44bd-85d3-03c276bd1b11"), 5 },
                    { 10, new Guid("9a511daf-86ee-4e93-88c2-0baa77a6d388"), 8 },
                    { 10, new Guid("ea30040a-4d3f-4f71-a81a-e6ea473afa54"), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                schema: "sales",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                schema: "sales",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "sales",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "sales");
        }
    }
}
