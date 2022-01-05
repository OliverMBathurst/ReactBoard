using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactBoard.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BoardUrlName = table.Column<string>(nullable: true),
                    IsWorkSafe = table.Column<bool>(nullable: false),
                    MaxThreads = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thread",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardId = table.Column<int>(nullable: false),
                    Locked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thread", x => new { x.Id, x.BoardId });
                    table.ForeignKey(
                        name: "FK_Thread_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<long>(nullable: false),
                    Size = table.Column<float>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageMetadata_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardAdminMapping",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BoardId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardAdminMapping", x => new { x.UserId, x.BoardId });
                    table.ForeignKey(
                        name: "FK_BoardAdminMapping_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleMapping_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadId = table.Column<long>(nullable: false),
                    BoardId = table.Column<int>(nullable: false),
                    ImageId = table.Column<long>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    PostBoardId = table.Column<int>(nullable: true),
                    PostId = table.Column<long>(nullable: true),
                    PostThreadId = table.Column<long>(nullable: true),
                    ThreadBoardId = table.Column<int>(nullable: false),
                    ThreadId1 = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => new { x.Id, x.ThreadId, x.BoardId });
                    table.ForeignKey(
                        name: "FK_Post_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Thread_ThreadId1_ThreadBoardId",
                        columns: x => new { x.ThreadId1, x.ThreadBoardId },
                        principalTable: "Thread",
                        principalColumns: new[] { "Id", "BoardId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Post_PostId_PostThreadId_PostBoardId",
                        columns: x => new { x.PostId, x.PostThreadId, x.PostBoardId },
                        principalTable: "Post",
                        principalColumns: new[] { "Id", "ThreadId", "BoardId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardAdminMapping_UserId",
                table: "BoardAdminMapping",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageMetadata_ImageId",
                table: "ImageMetadata",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_ImageId",
                table: "Post",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ThreadId1_ThreadBoardId",
                table: "Post",
                columns: new[] { "ThreadId1", "ThreadBoardId" });

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostId_PostThreadId_PostBoardId",
                table: "Post",
                columns: new[] { "PostId", "PostThreadId", "PostBoardId" });

            migrationBuilder.CreateIndex(
                name: "IX_Thread_BoardId",
                table: "Thread",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMapping_UserId",
                table: "UserRoleMapping",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardAdminMapping");

            migrationBuilder.DropTable(
                name: "ImageMetadata");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "UserRoleMapping");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Thread");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Board");
        }
    }
}
