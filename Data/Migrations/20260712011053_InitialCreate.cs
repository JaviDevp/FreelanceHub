using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelanceHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExternalId = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Platform = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DescriptionSummary = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    OriginalUrl = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: false),
                    CanonicalUrl = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: true),
                    BudgetMinimum = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    BudgetMaximum = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    PaymentType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    PublishedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    IsRemote = table.Column<bool>(type: "INTEGER", nullable: true),
                    Tags = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicantsCount = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    FetchedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastVerifiedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.CheckConstraint("CK_JobOffers_ApplicantsCount", "ApplicantsCount IS NULL OR ApplicantsCount >= 0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_Platform",
                table: "JobOffers",
                column: "Platform");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_Platform_CanonicalUrl",
                table: "JobOffers",
                columns: new[] { "Platform", "CanonicalUrl" },
                unique: true,
                filter: "CanonicalUrl IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_Platform_ExternalId",
                table: "JobOffers",
                columns: new[] { "Platform", "ExternalId" },
                unique: true,
                filter: "ExternalId IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_PublishedAt",
                table: "JobOffers",
                column: "PublishedAt");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_Status",
                table: "JobOffers",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_Status_PublishedAt",
                table: "JobOffers",
                columns: new[] { "Status", "PublishedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOffers");
        }
    }
}
