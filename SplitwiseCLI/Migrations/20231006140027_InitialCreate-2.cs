using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitwiseCLI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "expenses",
                columns: table => new
                {
                    expenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenses", x => x.expenseId);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseUsers",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseUsers", x => new { x.userId, x.ExpenseId });
                    table.ForeignKey(
                        name: "FK_ExpenseUsers_expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "expenses",
                        principalColumn: "expenseId");
                });

            migrationBuilder.CreateTable(
                name: "Group_Admins",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    group_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Admins", x => new { x.User_Id, x.group_Id });
                });

            migrationBuilder.CreateTable(
                name: "Group_Members",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Members", x => new { x.UserId, x.groupId });
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    expenseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_expenses_expenseId",
                        column: x => x.expenseId,
                        principalTable: "expenses",
                        principalColumn: "expenseId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    groupesGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Groups_groupesGroupId",
                        column: x => x.groupesGroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                });

            migrationBuilder.CreateTable(
                name: "userExpenses",
                columns: table => new
                {
                    UserExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paidById = table.Column<int>(type: "int", nullable: true),
                    owedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userExpenses", x => x.UserExpenseId);
                    table.ForeignKey(
                        name: "FK_userExpenses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userExpenses_expenses_owedById",
                        column: x => x.owedById,
                        principalTable: "expenses",
                        principalColumn: "expenseId");
                    table.ForeignKey(
                        name: "FK_userExpenses_expenses_paidById",
                        column: x => x.paidById,
                        principalTable: "expenses",
                        principalColumn: "expenseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseUsers_ExpenseId",
                table: "ExpenseUsers",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Admins_group_Id",
                table: "Group_Admins",
                column: "group_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Members_groupId",
                table: "Group_Members",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_expenseId",
                table: "Groups",
                column: "expenseId",
                unique: true,
                filter: "[expenseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_userId",
                table: "Groups",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_userExpenses_owedById",
                table: "userExpenses",
                column: "owedById");

            migrationBuilder.CreateIndex(
                name: "IX_userExpenses_paidById",
                table: "userExpenses",
                column: "paidById");

            migrationBuilder.CreateIndex(
                name: "IX_userExpenses_UserId",
                table: "userExpenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_groupesGroupId",
                table: "Users",
                column: "groupesGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseUsers_Users_userId",
                table: "ExpenseUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Admins_Groups_group_Id",
                table: "Group_Admins",
                column: "group_Id",
                principalTable: "Groups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Admins_Users_User_Id",
                table: "Group_Admins",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Members_Groups_groupId",
                table: "Group_Members",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Members_Users_UserId",
                table: "Group_Members",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_userId",
                table: "Groups",
                column: "userId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_userId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "ExpenseUsers");

            migrationBuilder.DropTable(
                name: "Group_Admins");

            migrationBuilder.DropTable(
                name: "Group_Members");

            migrationBuilder.DropTable(
                name: "userExpenses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "expenses");
        }
    }
}
