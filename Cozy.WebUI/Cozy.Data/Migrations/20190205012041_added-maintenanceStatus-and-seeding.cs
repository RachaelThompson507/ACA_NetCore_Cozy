using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cozy.Data.Migrations
{
    public partial class addedmaintenanceStatusandseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenences");

            migrationBuilder.CreateTable(
                name: "MaintenanceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HomeId = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    MaintenanceStatus = table.Column<int>(nullable: false),
                    MaintenanceStatusesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintenances_MaintenanceStatuses_MaintenanceStatusesId",
                        column: x => x.MaintenanceStatusesId,
                        principalTable: "MaintenanceStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MaintenanceStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "In Progress" },
                    { 3, "Completed" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_HomeId",
                table: "Maintenances",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_MaintenanceStatusesId",
                table: "Maintenances",
                column: "MaintenanceStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_TenantId",
                table: "Maintenances",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "MaintenanceStatuses");

            migrationBuilder.CreateTable(
                name: "Maintenences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HomeId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenences_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintenences_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenences_HomeId",
                table: "Maintenences",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenences_TenantId",
                table: "Maintenences",
                column: "TenantId");
        }
    }
}
