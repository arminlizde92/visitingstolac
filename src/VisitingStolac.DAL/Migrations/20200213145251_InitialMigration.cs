using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitingStolac.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    IsSubscribedOnNews = table.Column<bool>(nullable: false),
                    IsSubscribedOnPosts = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublicId = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_MediaGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "MediaGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQs_TextContents_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "TextContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAQs_TextContents_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "TextContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleId = table.Column<int>(nullable: false),
                    TextId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    AdministratorId = table.Column<int>(nullable: false),
                    MediaGroupId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_MediaGroups_MediaGroupId",
                        column: x => x.MediaGroupId,
                        principalTable: "MediaGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_TextContents_TextId",
                        column: x => x.TextId,
                        principalTable: "TextContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_TextContents_TitleId",
                        column: x => x.TitleId,
                        principalTable: "TextContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TextContentTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TextContentId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Locale = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextContentTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextContentTranslations_TextContents_TextContentId",
                        column: x => x.TextContentId,
                        principalTable: "TextContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contributions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubscriberId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contributions_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    ContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostContacts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_PostId",
                table: "Contributions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_SubscriberId",
                table: "Contributions",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_AnswerId",
                table: "FAQs",
                column: "AnswerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_QuestionId",
                table: "FAQs",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_GroupId",
                table: "Medias",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PostContacts_ContactId",
                table: "PostContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PostContacts_PostId",
                table: "PostContacts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AdministratorId",
                table: "Posts",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MediaGroupId",
                table: "Posts",
                column: "MediaGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TextId",
                table: "Posts",
                column: "TextId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TitleId",
                table: "Posts",
                column: "TitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextContentTranslations_TextContentId",
                table: "TextContentTranslations",
                column: "TextContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributions");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "PostContacts");

            migrationBuilder.DropTable(
                name: "TextContentTranslations");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "MediaGroups");

            migrationBuilder.DropTable(
                name: "TextContents");
        }
    }
}
