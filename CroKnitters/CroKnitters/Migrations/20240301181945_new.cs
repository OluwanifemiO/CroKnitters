using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CroKnitters.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
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
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__C3B4DFCA7D1B4540", x => x.CommentId);
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
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    StitchType = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    StitchCount = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Patterns__0A631B521FCBD794", x => x.PatternId);
                    table.ForeignKey(
                        name: "FK_Patterns_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
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
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Projects__761ABEF001154132", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
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
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PatternC__272DE03846EEF9E6", x => x.PatComId);
                    table.ForeignKey(
                        name: "FK_PatternComments_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
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
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectC__FAF8CB4AAB204E27", x => x.ProComId);
                    table.ForeignKey(
                        name: "FK_ProjectComments_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Images",
                columns: new[] { "ImageId", "ImageSrc" },
                values: new object[,]
                {
                    { 1, "https://pbs.twimg.com/profile_images/1654080701292068865/AL2TAeY5_400x400.jpg" },
                    { 2, "https://i.redd.it/jeuusd992wd41.jpg" },
                    { 3, "https://images.squarespace-cdn.com/content/v1/5e10bdc20efb8f0d169f85f9/09943d85-b8c7-4d64-af31-1a27d1b76698/arrow.png" },
                    { 4, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQV1_mGYXjq3eWha-wQIRkn6ulW9X6Ws-ztw&usqp=CAU" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

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
                name: "IX_PatternComments_AdminId",
                table: "PatternComments",
                column: "AdminId");

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
                name: "IX_Patterns_AdminId",
                table: "Patterns",
                column: "AdminId");

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
                name: "IX_ProjectComments_AdminId",
                table: "ProjectComments",
                column: "AdminId");

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
                name: "IX_Projects_AdminId",
                table: "Projects",
                column: "AdminId");

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
