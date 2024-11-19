#pragma warning disable IDE0065 // Misplaced using directive
using Microsoft.EntityFrameworkCore.Migrations;
#pragma warning restore IDE0065 // Misplaced using directive

#nullable disable

#pragma warning disable IDE0161 // Convert to file-scoped namespace
namespace Orange.API.Data.Migrations
#pragma warning restore IDE0161 // Convert to file-scoped namespace
{
	/// <inheritdoc />
	public partial class InitialMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterDatabase()
				.Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

#pragma warning disable IDE0053 // Use expression body for lambda expression
			migrationBuilder.CreateTable(
				name: "Tags",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
					Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tags", x => x.Id);
				});
#pragma warning restore IDE0053 // Use expression body for lambda expression

#pragma warning disable IDE0053 // Use expression body for lambda expression
			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					First_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
					Last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
					Avatar_url = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});
#pragma warning restore IDE0053 // Use expression body for lambda expression

			migrationBuilder.CreateTable(
				name: "Projects",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
					Title = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: false),
					Project_link = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
					Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
					Thumbnail_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
					Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
					User_id = table.Column<Guid>(type: "uuid", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Projects", x => x.Id);
					table.ForeignKey(
						name: "FK_Projects_Users_User_id",
						column: x => x.User_id,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Project_Tag",
				columns: table => new
				{
					ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
					TagId = table.Column<Guid>(type: "uuid", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Project_Tag", x => new { x.ProjectId, x.TagId });
					table.ForeignKey(
						name: "FK_Project_Tag_Projects_ProjectId",
						column: x => x.ProjectId,
						principalTable: "Projects",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Project_Tag_Tags_TagId",
						column: x => x.TagId,
						principalTable: "Tags",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Project_Tag_TagId",
				table: "Project_Tag",
				column: "TagId");

			migrationBuilder.CreateIndex(
				name: "IX_Projects_User_id",
				table: "Projects",
				column: "User_id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Project_Tag");

			migrationBuilder.DropTable(
				name: "Projects");

			migrationBuilder.DropTable(
				name: "Tags");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
