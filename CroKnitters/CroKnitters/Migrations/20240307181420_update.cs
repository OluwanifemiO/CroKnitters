using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CroKnitters.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Groups__149AF36A0C281B44", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageSrc = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Images__7516F70CC8F1B07F", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Language__B93855ABA45758AD", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Province__FD0A6F83F858F43F", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tags__657CF9ACB4394FA8", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ThemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThemeTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Themes__FBB3E4D98AE98BB3", x => x.ThemeId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cities__F2D21B763291A5A0", x => x.CityId);
                    table.ForeignKey(
                        name: "FK__Cities__Province__2E1BDC42",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Bio = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4CEBD8424E", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__Users__CityId__30F848ED",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK__Users__ImageId__31EC6D26",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__C3B4DFCA7D1B4540", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Comments__OwnerI__4AB81AF0",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Events__7944C810EEF9274C", x => x.EventId);
                    table.ForeignKey(
                        name: "FK__Events__OwnerId__34C8D9D1",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "FriendsList",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FriendsL__E3832805B148DDC9", x => x.ListId);
                    table.ForeignKey(
                        name: "FK__FriendsLi__Frien__3B40CD36",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__FriendsLi__UserI__3A4CA8FD",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    GroupUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false, defaultValueSql: "('Member')"),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GroupUse__37F70716E0C22569", x => x.GroupUserId);
                    table.ForeignKey(
                        name: "FK__GroupUser__Group__40058253",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK__GroupUser__UserI__3E1D39E1",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Messages__C87C0C9C167A84C6", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK__Messages__Sender__2CF2ADDF",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Patterns",
                columns: table => new
                {
                    PatternId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    StitchType = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    StitchCount = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Patterns__0A631B521FCBD794", x => x.PatternId);
                    table.ForeignKey(
                        name: "FK_Patterns_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                    table.ForeignKey(
                        name: "FK__Patterns__OwnerI__3E52440B",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Preferen__E228496F2600B5A8", x => x.PreferenceId);
                    table.ForeignKey(
                        name: "FK__Preferenc__Langu__38996AB5",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId");
                    table.ForeignKey(
                        name: "FK__Preferenc__Theme__398D8EEE",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "ThemeId");
                    table.ForeignKey(
                        name: "FK__Preferenc__UserI__37A5467C",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('In-Progress')"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Projects__761ABEF001154132", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                    table.ForeignKey(
                        name: "FK__Projects__OwnerI__44FF419A",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "EventUsers",
                columns: table => new
                {
                    EventUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventUse__75F92483FA2626FC", x => x.EventUserId);
                    table.ForeignKey(
                        name: "FK__EventUser__Event__68487DD7",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId");
                    table.ForeignKey(
                        name: "FK__EventUser__UserI__693CA210",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "GroupChat",
                columns: table => new
                {
                    GChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GroupCha__75C801E807CEC318", x => x.GChatId);
                    table.ForeignKey(
                        name: "FK__GroupChat__Group__31B762FC",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK__GroupChat__Messa__30C33EC3",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId");
                });

            migrationBuilder.CreateTable(
                name: "PrivateChat",
                columns: table => new
                {
                    PChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecieverId = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PrivateC__752CDBDC8FE2125C", x => x.PChatId);
                    table.ForeignKey(
                        name: "FK__PrivateCh__Messa__367C1819",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId");
                    table.ForeignKey(
                        name: "FK__PrivateCh__Recie__3587F3E0",
                        column: x => x.RecieverId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__PrivateCh__Sende__3493CFA7",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "PatternComments",
                columns: table => new
                {
                    PatComId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PatternC__272DE03846EEF9E6", x => x.PatComId);
                    table.ForeignKey(
                        name: "FK__PatternCo__Comme__656C112C",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId");
                    table.ForeignKey(
                        name: "FK__PatternCo__Patte__6477ECF3",
                        column: x => x.PatternId,
                        principalTable: "Patterns",
                        principalColumn: "PatternId");
                });

            migrationBuilder.CreateTable(
                name: "PatternImage",
                columns: table => new
                {
                    PatImId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PatternI__469D527DA79D41C7", x => x.PatImId);
                    table.ForeignKey(
                        name: "FK__PatternIm__Image__236943A5",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                    table.ForeignKey(
                        name: "FK__PatternIm__Patte__22751F6C",
                        column: x => x.PatternId,
                        principalTable: "Patterns",
                        principalColumn: "PatternId");
                });

            migrationBuilder.CreateTable(
                name: "PatternTags",
                columns: table => new
                {
                    PatTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PatternT__68421DA4E054EE9B", x => x.PatTagId);
                    table.ForeignKey(
                        name: "FK__PatternTa__Patte__5CD6CB2B",
                        column: x => x.PatternId,
                        principalTable: "Patterns",
                        principalColumn: "PatternId");
                    table.ForeignKey(
                        name: "FK__PatternTa__TagId__5DCAEF64",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId");
                });

            migrationBuilder.CreateTable(
                name: "UserPatterns",
                columns: table => new
                {
                    UpatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PatternId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserPatt__900CF3B8C62046ED", x => x.UpatId);
                    table.ForeignKey(
                        name: "FK__UserPatte__Patte__4E88ABD4",
                        column: x => x.PatternId,
                        principalTable: "Patterns",
                        principalColumn: "PatternId");
                    table.ForeignKey(
                        name: "FK__UserPatte__UserI__4D94879B",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectComments",
                columns: table => new
                {
                    ProComId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectC__FAF8CB4AAB204E27", x => x.ProComId);
                    table.ForeignKey(
                        name: "FK__ProjectCo__Comme__619B8048",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId");
                    table.ForeignKey(
                        name: "FK__ProjectCo__Proje__60A75C0F",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectImages",
                columns: table => new
                {
                    ProImId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectI__05A6BB15FBD6324F", x => x.ProImId);
                    table.ForeignKey(
                        name: "FK__ProjectIm__Image__1F98B2C1",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                    table.ForeignKey(
                        name: "FK__ProjectIm__Proje__1EA48E88",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectPatterns",
                columns: table => new
                {
                    ProPatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PatternId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectP__19B1EB93417F37D9", x => x.ProPatId);
                    table.ForeignKey(
                        name: "FK__ProjectPa__Patte__5629CD9C",
                        column: x => x.PatternId,
                        principalTable: "Patterns",
                        principalColumn: "PatternId");
                    table.ForeignKey(
                        name: "FK__ProjectPa__Proje__5535A963",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTags",
                columns: table => new
                {
                    ProTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectT__EA3BF1B886EBE45B", x => x.ProTagId);
                    table.ForeignKey(
                        name: "FK__ProjectTa__Proje__59063A47",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK__ProjectTa__TagId__59FA5E80",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId");
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UproId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserProj__1DAD7D9709F4A257", x => x.UproId);
                    table.ForeignKey(
                        name: "FK__UserProje__Proje__52593CB8",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK__UserProje__UserI__5165187F",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminId", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "admin1@example.com", "!a123456", "Admin1" },
                    { 2, "admin2@example.com", "!a123456", "Admin2" },
                    { 3, "admin3@example.com", "!a123456", "Admin3" },
                    { 4, "admin4@example.com", "!a123456", "Admin4" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "CreationDate", "Description", "GroupName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2958), "Some lazy people coming together to motivate one another.", "Lazy Crocheters community" },
                    { 2, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3003), "Weekend warriors unite for crochet projects big and small. All skill levels welcome.", "Weekend Crochet Warriors" },
                    { 3, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3008), "A community focused on using eco-friendly and sustainable materials in our crochet and knitting projects.", "Eco-Friendly Fiber Artists" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImageSrc" },
                values: new object[,]
                {
                    { 1, "image_one.jpg" },
                    { 2, "image_two.jpg" },
                    { 3, "image_three.png" },
                    { 4, "image_four.jpeg" },
                    { 5, "mesh-stitch.png" },
                    { 6, "treble-stitch.png" },
                    { 7, "chevron-stitch.png" },
                    { 8, "granny-square-stitch.png" },
                    { 9, "basketweave-stitch.png" },
                    { 10, "popcorn_stitch.jpeg" },
                    { 11, "baby-socks.jpeg" },
                    { 12, "winter-scarf.jpeg" },
                    { 13, "granny-square-blanket.jpeg" },
                    { 14, "amigurumi-bunny.jpeg" },
                    { 15, "summer-top.jpeg" },
                    { 16, "crochet-coaster.jpg" },
                    { 17, "cable-stitch.jpg" },
                    { 18, "shell-stitch.png" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "LanguageName" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "French" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "ProvinceName" },
                values: new object[,]
                {
                    { 1, "Alberta" },
                    { 2, "British Columbia" },
                    { 3, "Manitoba" },
                    { 4, "New Brunswick" },
                    { 5, "Newfoundland and Labrador" },
                    { 6, "Nova Scotia" },
                    { 7, "Ontario" },
                    { 8, "Prince Edward Island" },
                    { 9, "Quebec" },
                    { 10, "Saskatchewan" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[,]
                {
                    { 1, "Amazing" },
                    { 2, "Cute" },
                    { 3, "Elegant" },
                    { 4, "Classic" },
                    { 5, "Modern" },
                    { 6, "Colorful" },
                    { 7, "Simple" },
                    { 8, "Unique" }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeId", "ThemeTitle" },
                values: new object[,]
                {
                    { 1, "Light" },
                    { 2, "Dark" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Calgary", 1 },
                    { 2, "Edmonton", 1 },
                    { 3, "Red Deer", 1 },
                    { 4, "Vancouver", 2 },
                    { 5, "Surrey", 2 },
                    { 6, "Victoria", 2 },
                    { 7, "Burnaby", 2 },
                    { 8, "Richmond", 2 },
                    { 9, "Kelowna", 2 },
                    { 10, "Abbotsford", 2 },
                    { 11, "Coquitlam", 2 },
                    { 12, "Saanich", 2 },
                    { 13, "White Rock", 2 },
                    { 14, "Delta", 2 },
                    { 15, "Nanaimo", 2 },
                    { 16, "Winnipeg", 3 },
                    { 17, "Moncton", 4 },
                    { 18, "St. John's", 5 },
                    { 19, "Halifax", 6 },
                    { 20, "Toronto", 7 },
                    { 21, "Ottawa", 7 },
                    { 22, "Hamilton", 7 },
                    { 23, "Mississauga", 7 },
                    { 24, "Brampton", 7 },
                    { 25, "Kitchener", 7 },
                    { 26, "London", 7 },
                    { 27, "Markham", 7 },
                    { 28, "Oshawa", 7 },
                    { 29, "Vaughan", 7 },
                    { 30, "Windsor", 7 },
                    { 31, "St. Catharines", 7 },
                    { 32, "Oakville", 7 },
                    { 33, "Richmond Hill", 7 },
                    { 34, "Burlington", 7 },
                    { 35, "Sudbury", 7 },
                    { 36, "Barrie", 7 },
                    { 37, "Guelph", 7 },
                    { 38, "Whitby", 7 },
                    { 39, "Cambridge", 7 },
                    { 40, "Milton", 7 },
                    { 41, "Ajax", 7 },
                    { 42, "Waterloo", 7 },
                    { 43, "Thunder Bay", 7 },
                    { 44, "Brantford", 7 },
                    { 45, "Chatham", 7 },
                    { 46, "Clarington", 7 },
                    { 47, "Montréal", 9 },
                    { 48, "Quebec City", 9 },
                    { 49, "Laval", 9 },
                    { 50, "Gatineau", 9 },
                    { 51, "Longueuil", 9 },
                    { 52, "Sherbrooke", 9 },
                    { 53, "Lévis", 9 },
                    { 54, "Saguenay", 9 },
                    { 55, "Trois-Rivières", 9 },
                    { 56, "Terrebonne", 9 },
                    { 57, "Saint-Jérôme", 9 },
                    { 58, "Saskatoon", 10 },
                    { 59, "Regina", 10 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Bio", "CityId", "Email", "FirstName", "ImageId", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Just a guy whose favourite thing is to crochet :).", null, "samD@example.com", "Samuel", 1, "Dane", "!a123456", "Samuel123" },
                    { 2, "Hello there! I like to crochet and knit...", null, "juliaCrochet@example.com", "Julia", 2, "Fernandez", "!a123456", "Julia123" },
                    { 3, "My name is Juan Pablo and I'm exploring this craft as a new hobby.", null, "Pablo@example.com", "Juan", 4, "Pablo", "!a123456", "Juan123" },
                    { 4, "Hello!", null, "Dsmith@example.com", "Delilah", 3, "Smith", "!a123456", "Delilah123" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AdminId", "ApprovalStatus", "Content", "CreationDate", "Likes", "OwnerId" },
                values: new object[,]
                {
                    { 1, 1, true, "Very pretty!", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2632), 10, 1 },
                    { 2, 2, true, "Super cute!", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2669), 20, 2 },
                    { 3, 1, true, "Love the colors!", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2674), 15, 3 },
                    { 4, 1, false, "Shitty job!", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2701), 12, 4 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Date", "Description", "EventTitle", "OwnerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2796), "Don't miss out on amazing deals at our annual yarn sale! From colorful skeins to luxurious blends, we've got something for every project. See you there!", "Yarn sale at Kitchener, Ontario.", 1 },
                    { 2, new DateTime(2024, 5, 16, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2837), "Join us for an inspiring evening as local crafters showcase their latest creations. From intricate afghans to cozy scarves, you'll find plenty of ideas to spark your creativity.", "Project showcase at Toronto, Ontario", 2 },
                    { 3, new DateTime(2024, 5, 6, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2843), "Learn the art of crochet from experienced instructors in a fun and supportive environment. Whether you're a complete beginner or looking to refine your skills, this workshop is perfect for you!", "Crochet workshop in Vancouver, BC", 3 },
                    { 4, new DateTime(2024, 3, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), "Discover the latest trends and techniques in knitting and crochet at our annual expo. From interactive workshops to vendor booths featuring the hottest yarns, you'll find everything you need to take your crafting to the next level.", "Knitting and Crochet Expo in Montreal, QC", 4 },
                    { 5, new DateTime(2024, 4, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2854), "Join us for a virtual crochet class designed for beginners. Learn essential stitches and techniques from the comfort of your own home, with personalized instruction and plenty of support.", "Online Crochet Class - Beginners Welcome!", 2 },
                    { 6, new DateTime(2024, 5, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2859), "Trade your stash and discover new treasures at our yarn swap meet. Bring your unwanted yarn and notions to exchange with fellow crafters, and leave with fresh inspiration for your next project.", "Local Yarn Swap Meet in Calgary, AB", 4 }
                });

            migrationBuilder.InsertData(
                table: "FriendsList",
                columns: new[] { "ListId", "FriendId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 1, 4 },
                    { 4, 2, 3 },
                    { 5, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "GroupUsers",
                columns: new[] { "GroupUserId", "GroupId", "Role", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Admin", 2 },
                    { 2, 1, "Member", 1 },
                    { 3, 2, "Admin", 3 },
                    { 4, 2, "Member", 4 },
                    { 5, 3, "Admin", 2 },
                    { 6, 3, "Member", 4 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "CreationDate", "SenderId" },
                values: new object[,]
                {
                    { 1, "Hey everyone! Excited to join this group.", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3136), 1 },
                    { 2, "Welcome! Looking forward to seeing your projects.", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3160), 2 },
                    { 3, "Does anyone have tips for a beginner?", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3163), 3 },
                    { 4, "Sure! I'd recommend starting with simple patterns and bulky yarn. It's easier to see your stitches.", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3169), 4 },
                    { 5, "I'm trying to find eco-friendly yarn. Any brand recommendations?", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3173), 2 },
                    { 6, "I love using bamboo and recycled cotton yarns. They're great for the environment and work well for many projects.", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3176), 4 },
                    { 7, "Hey! How's it going?", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3180), 1 },
                    { 8, "Hi there! Not bad, just working on a new project. How about you?", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3183), 2 },
                    { 9, "Hey! What kind of project are you working on?", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3186), 1 },
                    { 10, "I'm trying out a new crochet pattern for a scarf. It's a bit challenging, but fun!", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3190), 3 },
                    { 11, "Hello! Do you have a favorite type of yarn you like to use?", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3193), 1 },
                    { 12, "I love using soft merino wool for scarves. It gives a cozy feel. How about you?", new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3196), 4 }
                });

            migrationBuilder.InsertData(
                table: "Patterns",
                columns: new[] { "PatternId", "CreationDate", "Description", "ImageId", "Likes", "OwnerId", "PatternName", "StitchCount", "StitchType" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This pattern usually consists of single chains connected to one another in the middle to resemble a mesh design.", null, 50, 1, "Mesh Pattern", 30, "Mesh Stitch" },
                    { 2, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This pattern consists of treble crochet stitches.", null, 20, 2, "Treble Crochet Pattern", 20, "Treble Crochet Stitch" },
                    { 3, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "This pattern usually consists of double crochet stitches connected to one to resemble a wave design.", null, 80, 2, "Chevron Pattern", 70, "Double Crochet Stitch" },
                    { 4, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "This pattern usually consists of Double crochet stitches that are connected in a unique way.", null, 100, 3, "Granny Square Pattern", 100, "Double Crochet Stitch" },
                    { 5, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "This pattern creates a woven texture resembling a basket.", null, 45, 1, "Basketweave Pattern", 25, "Basketweave Stitch" },
                    { 6, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "This pattern features the popcorn stitch for a textured and raised effect.", null, 30, 3, "Popcorn Stitch Pattern", 15, "Popcorn Stitch" },
                    { 7, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "This pattern creates a twisted and braided appearance using cable stitches.", null, 60, 1, "Cable Stitch Pattern", 40, "Cable Stitch" },
                    { 8, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This pattern forms a scallop-like shell using various crochet stitches.", null, 75, 2, "Shell Stitch Pattern", 50, "Shell Stitch" }
                });

            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "PreferenceId", "LanguageId", "ThemeId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "CreationDate", "Description", "ImageId", "Likes", "OwnerId", "ProjectName", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is a work in progress socks for my six month old baby.", null, 50, 1, "Baby Socks", "In-Progress" },
                    { 2, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2012), "A warm scarf for the winter season, using a bobble stitch pattern.", null, 75, 2, "Winter Scarf", "Completed" },
                    { 3, new DateTime(2024, 2, 16, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2399), "A colorful blanket made from granny squares. Each square features a different color, aiming for a vibrant look.", null, 90, 3, "Granny Square Blanket", "In-Progress" },
                    { 4, new DateTime(2024, 3, 2, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2405), "A cute bunny amigurumi project for the upcoming Easter holidays.", null, 120, 1, "Amigurumi Bunny", "Completed" },
                    { 5, new DateTime(2024, 2, 6, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2411), "A light and breezy top perfect for summer, using cotton yarn.", null, 65, 2, "Summer Top", "In-Progress" },
                    { 6, new DateTime(2024, 2, 21, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(2417), "Set of coasters for the dining table, featuring a floral motif.", null, 40, 3, "Crochet Coasters", "Completed" }
                });

            migrationBuilder.InsertData(
                table: "EventUsers",
                columns: new[] { "EventUserId", "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 3 },
                    { 6, 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "GroupChat",
                columns: new[] { "GChatId", "GroupId", "MessageId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 2, 4 },
                    { 5, 3, 5 },
                    { 6, 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "PatternComments",
                columns: new[] { "PatComId", "CommentId", "PatternId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 1, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 2, 3 },
                    { 6, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "PatternImage",
                columns: new[] { "PatImId", "ImageId", "PatternId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 6, 2 },
                    { 3, 7, 3 },
                    { 4, 8, 4 },
                    { 5, 9, 5 },
                    { 6, 10, 6 },
                    { 7, 17, 7 },
                    { 8, 18, 8 }
                });

            migrationBuilder.InsertData(
                table: "PatternTags",
                columns: new[] { "PatTagId", "PatternId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 }
                });

            migrationBuilder.InsertData(
                table: "PrivateChat",
                columns: new[] { "PChatId", "CreationDate", "MessageId", "RecieverId", "SenderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3623), 7, 2, 1 },
                    { 2, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3720), 8, 1, 2 },
                    { 3, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3726), 9, 3, 1 },
                    { 4, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3730), 10, 1, 3 },
                    { 5, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3734), 11, 4, 1 },
                    { 6, new DateTime(2024, 2, 26, 13, 14, 19, 912, DateTimeKind.Local).AddTicks(3738), 12, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProjectComments",
                columns: new[] { "ProComId", "CommentId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 1, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 2, 3 },
                    { 6, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProjectImages",
                columns: new[] { "ProImId", "ImageId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 11, 1 },
                    { 2, 12, 2 },
                    { 3, 13, 3 },
                    { 4, 14, 4 },
                    { 5, 15, 5 },
                    { 6, 16, 6 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTags",
                columns: new[] { "ProTagId", "ProjectId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 8 },
                    { 2, 2, 7 },
                    { 3, 3, 6 },
                    { 4, 4, 5 },
                    { 5, 5, 4 },
                    { 6, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserPatterns",
                columns: new[] { "UpatId", "PatternId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 7, 4 },
                    { 8, 8, 4 }
                });

            migrationBuilder.InsertData(
                table: "UserProjects",
                columns: new[] { "UproId", "ProjectId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 3 },
                    { 5, 5, 3 },
                    { 6, 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AdminId",
                table: "Comments",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OwnerId",
                table: "Comments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OwnerId",
                table: "Events",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUsers_EventId",
                table: "EventUsers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUsers_UserId",
                table: "EventUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsList_FriendId",
                table: "FriendsList",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsList_UserId",
                table: "FriendsList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChat_GroupId",
                table: "GroupChat",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChat_MessageId",
                table: "GroupChat",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UserId",
                table: "GroupUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PatternComments_CommentId",
                table: "PatternComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatternComments_PatternId",
                table: "PatternComments",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_PatternImage_ImageId",
                table: "PatternImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_PatternImage_PatternId",
                table: "PatternImage",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_Patterns_ImageId",
                table: "Patterns",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Patterns_OwnerId",
                table: "Patterns",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PatternTags_PatternId",
                table: "PatternTags",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_PatternTags_TagId",
                table: "PatternTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_LanguageId",
                table: "Preferences",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_ThemeId",
                table: "Preferences",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_UserId",
                table: "Preferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateChat_MessageId",
                table: "PrivateChat",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateChat_RecieverId",
                table: "PrivateChat",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateChat_SenderId",
                table: "PrivateChat",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComments_CommentId",
                table: "ProjectComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectComments_ProjectId",
                table: "ProjectComments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_ImageId",
                table: "ProjectImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_ProjectId",
                table: "ProjectImages",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPatterns_PatternId",
                table: "ProjectPatterns",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPatterns_ProjectId",
                table: "ProjectPatterns",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ImageId",
                table: "Projects",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_ProjectId",
                table: "ProjectTags",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_TagId",
                table: "ProjectTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPatterns_PatternId",
                table: "UserPatterns",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPatterns_UserId",
                table: "UserPatterns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_UserId",
                table: "UserProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageId",
                table: "Users",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUsers");

            migrationBuilder.DropTable(
                name: "FriendsList");

            migrationBuilder.DropTable(
                name: "GroupChat");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "PatternComments");

            migrationBuilder.DropTable(
                name: "PatternImage");

            migrationBuilder.DropTable(
                name: "PatternTags");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "PrivateChat");

            migrationBuilder.DropTable(
                name: "ProjectComments");

            migrationBuilder.DropTable(
                name: "ProjectImages");

            migrationBuilder.DropTable(
                name: "ProjectPatterns");

            migrationBuilder.DropTable(
                name: "ProjectTags");

            migrationBuilder.DropTable(
                name: "UserPatterns");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Patterns");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
