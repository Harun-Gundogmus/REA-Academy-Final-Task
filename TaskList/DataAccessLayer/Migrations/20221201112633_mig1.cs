using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taskOwner",
                columns: table => new
                {
                    owner_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    owner_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    owner_task_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    owner_explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    owner_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskOwner", x => x.owner_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_pword = table.Column<int>(type: "int", nullable: false),
                    user_role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskOwnerowner_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_Comment_taskOwner_TaskOwnerowner_id",
                        column: x => x.TaskOwnerowner_id,
                        principalTable: "taskOwner",
                        principalColumn: "owner_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TaskOwnerowner_id",
                table: "Comment",
                column: "TaskOwnerowner_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "taskOwner");
        }
    }
}
