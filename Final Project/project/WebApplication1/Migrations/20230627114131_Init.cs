﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PublishDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookUser",
                columns: table => new
                {
                    BooksID = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser", x => new { x.BooksID, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BookUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser_Books_BooksID",
                        column: x => x.BooksID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookUser1",
                columns: table => new
                {
                    OwnedBooksID = table.Column<int>(type: "int", nullable: false),
                    OwnerUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUser1", x => new { x.OwnedBooksID, x.OwnerUsersId });
                    table.ForeignKey(
                        name: "FK_BookUser1_AspNetUsers_OwnerUsersId",
                        column: x => x.OwnerUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUser1_Books_OwnedBooksID",
                        column: x => x.OwnedBooksID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Chapters_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Votes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 27, 14, 41, 31, 665, DateTimeKind.Local).AddTicks(1088)),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterUser",
                columns: table => new
                {
                    ReadChaptersID = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterUser", x => new { x.ReadChaptersID, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ChapterUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterUser_Chapters_ReadChaptersID",
                        column: x => x.ReadChaptersID,
                        principalTable: "Chapters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Votes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 27, 14, 41, 31, 664, DateTimeKind.Local).AddTicks(8856)),
                    ChapterID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Chapters_ChapterID",
                        column: x => x.ChapterID,
                        principalTable: "Chapters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "PremiumUser", "PREMIUMUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "671d4a9a-c1c0-4369-8bde-f26242c39143", "Mahmoud@gmail.com", false, false, null, "MAHMOUD@GMAIL.COM", "MAHMOUD", "AQAAAAIAAYagAAAAEM6bztfW4lSrkXqVBXPaXhBGUIAznEuiidOvk5ojWngU0HnGQVxaZOPVaZGMdzhvIg==", null, false, "7739610e-f30a-4de7-8646-408a8d4eb1dd", false, "Mahmoud" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Horror" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorName", "CategoryId", "Description", "ImagePath", "Name", "Price", "PublishDate", "Rating" },
                values: new object[] { 1, "H. P. Lovecraft", 1, "The Call of Cthulhu is a short story by American writer H. P. Lovecraft. Written in the summer of 1926, it was first published in the pulp magazine Weird Tales in February 1928.", "https://m.media-amazon.com/images/I/515TltJSPEL.jpg", "The Call of Cthulhu", 19.989999999999998, "1928", 70 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorName", "CategoryId", "Description", "ImagePath", "Name", "Price", "PublishDate" },
                values: new object[,]
                {
                    { 2, "W.W. Jacobs", 1, "The Monkey's Paw is a short story by English writer W.W. Jacobs. It was first published in Harper's Monthly magazine in 1902. The story follows the White family, who come into possession of a magical monkey's paw that grants three wishes.", "https://m.media-amazon.com/images/I/51e7aoodRtL.jpg", "The Monkey's Paw", 9.9900000000000002, "1902" },
                    { 3, "Edgar Allan Poe", 1, "The Tell-Tale Heart is a short story by American writer Edgar Allan Poe. It was first published in 1843. The story is narrated by an unnamed protagonist who is obsessed with the eye of an elderly man. As his obsession grows, he commits a heinous act of murder.", "https://m.media-amazon.com/images/I/71igzz1F+JL._AC_UF1000,1000_QL80_.jpg", "The Tell-Tale Heart", 14.99, "1843" },
                    { 4, "J. Sheridan Le Fanu", 1, "Carmilla is a Gothic novella by Irish writer J. Sheridan Le Fanu. It was first published in 1872. The story revolves around a young woman named Laura, who becomes friends with the mysterious and alluring Carmilla. As their relationship deepens, Laura begins to suspect that Carmilla may be a supernatural entity.", "https://images.penguinrandomhouse.com/cover/9781782275848", "Carmilla", 12.99, "1872" },
                    { 5, "Charlotte Perkins Gilman", 1, "The Yellow Wallpaper is a haunting short story by American writer Charlotte Perkins Gilman. It was first published in 1892. The story is narrated by a woman who is confined to a room with yellow wallpaper. As her mental state deteriorates, she becomes obsessed with the wallpaper, leading to a descent into madness.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSSpjWuHwCM_LBBK08M-ZsGGZ6hOm6pBxrngYEzRTTJ&s", "The Yellow Wallpaper", 11.99, "1892" }
                });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "ID", "BookID", "Content", "Order", "Title" },
                values: new object[,]
                {
                    { 1, 1, "The most merciful thing in the world, I think, is the inability of\r\nthe human mind to correlate all its contents. We live on a placid\r\nisland of ignorance in the midst of black seas of infinity, and it\r\nwas not meant that we should voyage far. The sciences, each\r\nstraining in its own direction, have hitherto harmed us little; but\r\nsome day the piecing together of dissociated knowledge will\r\nopen up such terrifying vistas of reality, and of our frightful\r\nposition therein, that we shall either go mad from the revelation\r\nor flee from the light into the peace and safety of a new dark\r\nage.\r\nTheosophists have guessed at the awesome grandeur of the\r\ncosmic cycle wherein our world and human race form transient\r\nincidents. They have hinted\r\nat strange survivals in terms which would freeze the blood if not\r\nmasked by a bland optimism. But it is not from them that there\r\ncame the single glimpse of forbidden eons which chills me when\r\nI think of it and maddens me when I dream of it. That glimpse,\r\nlike all dread glimpses of truth, flashed out from an accidental\r\npiecing together of separated things—in this case an old\r\nnewspaper item and the notes of a dead professor. I hope that\r\nno one else will accomplish this piecing out; certainly, if I live, I\r\nshall never knowingly supply a link in so hideous a chain. I think\r\n\r\nthat the professor, too intended to keep silent regarding the\r\npart he knew, and that he would have destroyed his notes had\r\nnot sudden death seized him.\r\nMy knowledge of the thing began in the winter of 1926-27 with\r\nthe death of my great-uncle, George Gammell Angell, Professor\r\nEmeritus of Semitic Languages in Brown University, Providence,\r\nRhode Island. Professor Angell was widely known as an\r\nauthority on ancient inscriptions, and had frequently been\r\nresorted to by the heads of prominent museums; so that his\r\npassing at the age of ninety-two may be recalled by many.\r\nLocally, interest was intensified by the obscurity of the cause of\r\ndeath. The professor had been stricken whilst returning from the\r\nNewport boat; falling suddenly; as witnesses said, after having\r\nbeen jostled by a nautical-looking negro who had come from\r\none of the queer dark courts on the precipitous hillside which\r\nformed a short cut from the waterfront to the deceased's home\r\nin Williams Street. Physicians were unable to find any visible\r\ndisorder, but concluded after perplexed debate that some\r\nobscure lesion of the heart, induced by the brisk ascent of so\r\nsteep a hill by so elderly a man, was responsible for the end. At\r\nthe time I saw no reason to dissent from this dictum, but latterly\r\nI am inclined to wonder—and more than wonder.\r\nAs my great-uncle's heir and executor, for he died a childless\r\nwidower, I was expected to go over his papers with some\r\nthoroughness; and for that purpose moved his entire set of files\r\nand boxes to my quarters in Boston. Much of the material which\r\n\r\nI correlated will be later published by the American\r\nArchaeological Society, but there was one box which I found\r\nexceedingly puzzling, and which I felt much averse from\r\nshowing to other eyes. It had been locked and I did not find the\r\nkey till it occurred to me to examine the personal ring which the\r\nprofessor carried in his pocket. Then, indeed, I succeeded in\r\nopening it, but when I did so seemed only to be confronted by a\r\ngreater and more closely locked barrier. For what could be the\r\nmeaning of the queer clay bas-relief and the disjointed jottings,\r\nramblings, and cuttings which I found? Had my uncle, in his\r\nlatter years become credulous of the most superficial\r\nimpostures? I resolved to search out the eccentric sculptor\r\nresponsible for this apparent disturbance of an old man's peace\r\nof mind.\r\nThe bas-relief was a rough rectangle less than an inch thick and\r\nabout five by six inches in area; obviously of modern origin. Its\r\ndesigns, however, were far\r\nfrom modern in atmosphere and suggestion; for, although the\r\nvagaries of cubism and futurism are many and wild, they do not\r\noften reproduce that cryptic regularity which lurks in prehistoric\r\nwriting. And writing of some kind the bulk of these designs\r\nseemed certainly to be; though my memory, despite much the\r\npapers and collections of my uncle, failed in any way to identify\r\nthis particular species, or even hint at its remotest affiliations.\r\n\r\nAbove these apparent hieroglyphics was a figure of evident\r\npictorial intent, though its impressionistic execution forbade a\r\nvery clear idea of its nature. It seemed to be a sort of monster,\r\nor symbol representing a monster, of a form which only a\r\ndiseased fancy could conceive. If I say that my somewhat\r\nextravagant imagination yielded simultaneous pictures of an\r\noctopus, a dragon, and a human caricature, I shall not be\r\nunfaithful to the spirit of the thing. A pulpy, tentacled head\r\nsurmounted a grotesque and scaly body with rudimentary\r\nwings; but it was the general outline of the whole which made it\r\nmost shockingly frightful. Behind the figure was a vague\r\nsuggestions of a Cyclopean architectural background.\r\nThe writing accompanying this oddity was, aside from a stack\r\nof press cuttings, in Professor Angell's most recent hand; and\r\nmade no pretense to literary style. What seemed to be the main\r\ndocument was headed \"CTHULHU CULT\" in characters\r\npainstakingly printed to avoid the erroneous reading of a word\r\nso unheard-of. This manuscript was divided into two sections,\r\nthe first of which was headed \"1925—Dream and Dream Work\r\nof H.A. Wilcox, 7 Thomas St., Providence, R. I.\", and the second,\r\n\"Narrative of Inspector John\r\nR. Legrasse, 121 Bienville St., New Orleans, La., at 1908 A. A. S.\r\nMtg.— Notes on Same, & Prof. Webb's Acct.\" The other\r\nmanuscript papers were brief notes, some of them accounts of\r\nthe queer dreams of different persons, some of them citations\r\nfrom theosophical books and magazines (notably W. Scott-\r\n\r\nElliot's Atlantis and the Lost Lemuria), and the rest comments\r\non long- surviving secret societies and hidden cults, with\r\nreferences to passages in such mythological and\r\nanthropological source-books as Frazer's Golden Bough and\r\nMiss Murray's Witch-Cult in Western Europe. The cuttings largely\r\nalluded to outré mental illness and outbreaks of group folly or\r\nmania in the spring of 1925.\r\nThe first half of the principal manuscript told a very particular\r\ntale. It appears that on March 1st, 1925, a thin, dark young man\r\nof neurotic and excited aspect had called upon Professor Angell\r\nbearing the singular clay bas-relief, which was then exceedingly\r\ndamp and fresh. His card bore the name of Henry Anthony\r\nWilcox, and my uncle had recognized him as the youngest son\r\nof an excellent family slightly known to him, who had latterly\r\nbeen studying sculpture at the Rhode Island School of Design\r\nand living alone at the Fleur- de-Lys Building near that\r\ninstitution. Wilcox was a precocious youth of known genius but\r\ngreat eccentricity, and had from childhood excited attention\r\nthrough\r\nthe strange stories and odd dreams he was in the habit of\r\nrelating. He called himself \"psychically hypersensitive\", but the\r\nstaid folk of the ancient commercial city dismissed him as\r\nmerely \"queer.\" Never mingling much with his kind, he had\r\ndropped gradually from social visibility, and was now known\r\nonly to a small group of esthetes from other towns. Even the\r\n\r\nProvidence Art Club, anxious to preserve its conservatism, had\r\nfound him quite hopeless.\r\nOn the occasion of the visit, ran the professor's manuscript, the\r\nsculptor abruptly asked for the benefit of his host's\r\narcheological knowledge in identifying the hieroglyphics of the\r\nbas-relief. He spoke in a dreamy, stilted manner which\r\nsuggested pose and alienated sympathy; and my uncle showed\r\nsome sharpness in replying, for the conspicuous freshness of\r\nthe tablet implied kinship with anything but archeology. Young\r\nWilcox's rejoinder, which impressed my uncle enough to make\r\nhim recall and record it verbatim, was of a fantastically poetic\r\ncast which must have typified his whole conversation, and\r\nwhich I have since found highly characteristic of him. He said,\r\n\"It is new, indeed, for I made it last night in a dream of strange\r\ncities; and dreams are older than brooding Tyre, or the\r\ncontemplative Sphinx, or garden-girdled Babylon.\"\r\nIt was then that he began that rambling tale which suddenly\r\nplayed upon a sleeping memory and won the fevered interest of\r\nmy uncle. There had been a slight earthquake tremor the night\r\nbefore, the most considerable felt in New England for some\r\nyears; and Wilcox's imagination had been keenly affected. Upon\r\nretiring, he had had an unprecedented dream of great\r\nCyclopean cities of Titan blocks and sky-flung monoliths, all\r\ndripping with green ooze and sinister with latent horror.\r\nHieroglyphics had covered the walls and pillars, and from some\r\nundetermined point below had come a voice that was not a\r\n\r\nvoice; a chaotic sensation which only fancy could transmute\r\ninto sound, but which he attempted to render by the almost\r\nunpronounceable jumble of letters: \"Cthulhu fhtagn.\"\r\nThis verbal jumble was the key to the recollection which excited\r\nand disturbed Professor Angell. He questioned the sculptor with\r\nscientific minuteness; and studied with frantic intensity the basrelief\r\non which the youth had found himself working, chilled and\r\nclad only in his night clothes, when waking had stolen\r\nbewilderingly over him. My uncle blamed his old age, Wilcox\r\nafterwards said, for his slowness in recognizing both\r\nhieroglyphics and pictorial design. Many of his questions\r\nseemed highly out of place to his visitor, especially those which\r\ntried to connect the latter with strange cults or societies; and\r\nWilcox could not understand the repeated promises of silence\r\nwhich he was offered in exchange for an admission of\r\nmembership in some widespread mystical or paganly religious\r\nbody. When Professor Angell became convinced that the\r\nsculptor was indeed ignorant of any cult or system of cryptic\r\nlore, he besieged his visitor with demands for future reports of\r\ndreams. This bore regular fruit, for after the first interview the\r\nmanuscript records daily calls of the young man, during which\r\nhe related startling fragments of nocturnal imagery whose\r\nburden was always some terrible Cyclopean vista of dark and\r\ndripping stone, with a subterrene voice or intelligence shouting\r\nmonotonously in enigmatical sense-impacts uninscribable save\r\n\r\nas gibberish. The two sounds frequently repeated are those\r\nrendered by the letters \"Cthulhu\" and \"R'lyeh.\"\r\nOn March 23, the manuscript continued, Wilcox failed to appear;\r\nand inquiries at his quarters revealed that he had been stricken\r\nwith an obscure sort of fever and taken to the home of his\r\nfamily in Waterman Street. He had cried out in the night,\r\narousing several other artists in the building, and had\r\nmanifested since then only alternations of unconsciousness and\r\ndelirium. My uncle at once telephoned the family, and from that\r\ntime forward kept close watch of the case; calling often at the\r\nThayer Street office of Dr. Tobey, whom he learned to be in\r\ncharge. The youth's febrile mind, apparently, was dwelling on\r\nstrange things; and the doctor shuddered now and then as he\r\nspoke of them. They included not only a repetition of what he\r\nhad formerly dreamed, but touched wildly on a gigantic thing\r\n\"miles high\" which walked or lumbered about.\r\nHe at no time fully described this object but occasional frantic\r\nwords, as repeated by Dr. Tobey, convinced the professor that it\r\nmust be identical with the nameless monstrosity he had sought\r\nto depict in his dream-sculpture. Reference to this object, the\r\ndoctor added, was invariably a prelude to the young man's\r\nsubsidence into lethargy. His temperature, oddly enough, was\r\nnot greatly above normal; but the whole condition was\r\notherwise such as to suggest true fever rather than mental\r\ndisorder.\r\n\r\nOn April 2 at about 3 P.M. every trace of Wilcox's malady\r\nsuddenly ceased. He sat upright in bed, astonished to find\r\nhimself at home and completely ignorant of what had\r\nhappened in dream or reality since the night of March 22.\r\nPronounced well by his physician, he returned to his quarters in\r\nthree days; but to Professor Angell he was of no further\r\nassistance. All traces of strange dreaming had vanished with his\r\nrecovery, and my uncle kept no record of his night-thoughts\r\nafter a week of pointless and irrelevant accounts of thoroughly\r\nusual visions.\r\nHere the first part of the manuscript ended, but references to\r\ncertain of the scattered notes gave me much material for\r\nthought—so much, in fact, that only the ingrained skepticism\r\nthen forming my philosophy can account for my continued\r\ndistrust of the artist. The notes in question were those\r\ndescriptive of the dreams of various persons covering the same\r\nperiod as that in which young Wilcox had had his strange\r\nvisitations. My uncle, it seems, had quickly instituted a\r\nprodigiously far-flung body of inquires amongst nearly all the\r\nfriends whom he could question without impertinence, asking\r\nfor nightly reports of their dreams, and the dates of any notable\r\nvisions for some time\r\npast. The reception of his request seems to have varied; but he\r\nmust, at the very least, have received more responses than any\r\nordinary man could have handled without a secretary. This\r\n\r\noriginal correspondence was not preserved, but his notes\r\nformed a thorough and really significant digest. Average people\r\nin society and business—New England's traditional \"salt of the\r\nearth\" —gave an almost completely negative result, though\r\nscattered cases of uneasy but formless nocturnal impressions\r\nappear here and there, always between March 23 and and April\r\n2—the period of young Wilcox's delirium. Scientific men were\r\nlittle more affected, though four cases of vague description\r\nsuggest fugitive glimpses of strange landscapes, and in one\r\ncase there is mentioned a dread of something abnormal.\r\nIt was from the artists and poets that the pertinent answers\r\ncame, and I know that panic would have broken loose had they\r\nbeen able to compare notes. As it was, lacking their original\r\nletters, I half suspected the compiler of having asked leading\r\nquestions, or of having edited the correspondence in\r\ncorroboration of what he had latently resolved to see. That is\r\nwhy I continued to feel that Wilcox, somehow cognizant of the\r\nold data which my uncle had possessed, had been imposing on\r\nthe veteran scientist. These responses from esthetes told\r\ndisturbing tale. From February 28 to April 2 a large proportion\r\nof them had dreamed very bizarre things, the intensity of the\r\ndreams being immeasurably the stronger during the period of\r\nthe sculptor's delirium. Over a fourth of those who reported\r\nanything, reported scenes and half-sounds not unlike those\r\nwhich Wilcox had described; and some of the dreamers\r\nconfessed acute fear of the gigantic nameless thing visible\r\n\r\ntoward the last. One case, which the note describes with\r\nemphasis, was very sad. The subject, a widely known architect\r\nwith leanings toward theosophy and occultism, went violently\r\ninsane on the date of young Wilcox's seizure, and expired\r\nseveral months later after incessant screamings to be saved\r\nfrom some escaped denizen of hell. Had my uncle referred to\r\nthese cases by name instead of merely by number, I should\r\nhave attempted some corroboration and personal investigation;\r\nbut as it was, I succeeded in tracing down only a few. All of\r\nthese, however, bore out the notes in full. I have often wondered\r\nif all the the objects of the professor's questioning felt as\r\npuzzled as did this fraction. It is well that no explanation shall\r\never reach them.\r\nThe press cuttings, as I have intimated, touched on cases of\r\npanic, mania, and eccentricity during the given period.\r\nProfessor Angell must have employed a cutting bureau, for the\r\nnumber of extracts was tremendous, and the sources scattered\r\nthroughout the globe. Here was a nocturnal suicide in London,\r\nwhere a lone sleeper had leaped from a window after a\r\nshocking cry. Here likewise a rambling letter to the editor of a\r\npaper in South America, where a fanatic deduces a dire future\r\nfrom visions he has seen. A dispatch from California describes a\r\ntheosophist colony as donning white robes en masse for some\r\n\"glorious fulfillment\" which never arrives, whilst items from India\r\nspeak\r\n\r\nguardedly of serious native unrest toward the end of March 22-\r\n23.\r\nThe west of Ireland, too, is full of wild rumor and legendry, and\r\na fantastic painter named Ardois-Bonnot hangs a blasphemous\r\nDream Landscape in the Paris spring salon of 1926. And so\r\nnumerous are the recorded troubles in insane asylums that only\r\na miracle can have stopped the medical fraternity from noting\r\nstrange parallelisms and drawing mystified conclusions. A weird\r\nbunch of cuttings, all told; and I can at this date scarcely\r\nenvisage the callous rationalism with which I set them aside.\r\nBut I was then convinced that young Wilcox had known of the\r\nolder matters mentioned by the professor.\r\n", 1, "" },
                    { 2, 1, "The older matters which had made the sculptor's dream and\r\nbas-relief so significant to my uncle formed the subject of the\r\nsecond half of his long manuscript. Once before, it appears,\r\nProfessor Angell had seen the hellish outlines of the nameless\r\nmonstrosity, puzzled over the unknown hieroglyphics, and heard\r\nthe ominous syllables which can be rendered only as \"Cthulhu\";\r\nand all this in so stirring and horrible a connection that it is\r\nsmall wonder he pursued young Wilcox with queries and\r\ndemands for data.\r\nThis earlier experience had come in 1908, seventeen years\r\nbefore, when the American Archaeological Society held its\r\nannual meeting in St. Louis. Professor Angell, as befitted one of\r\nhis authority and attainments, had had a prominent part in all\r\nthe deliberations; and was one of the first to be approached by\r\nthe several outsiders who took advantage of the convocation to\r\noffer questions for correct answering and problems for expert\r\nsolution.\r\nThe chief of these outsiders, and in a short time the focus of\r\ninterest for the entire meeting, was a commonplace-looking\r\nmiddle-aged man who had traveled all the way from New\r\nOrleans for certain special information unobtainable from any\r\nlocal source. His name was John Raymond Legrasse, and he\r\nwas by profession an Inspector of Police. With him he bore the\r\n\r\nsubject of his visit, a grotesque, repulsive, and apparently very\r\nancient stone statuette whose origin he was at a loss to\r\ndetermine. It must not be fancied that Inspector Legrasse had\r\nthe least interest in archaeology. On the contrary, his wish for\r\nenlightenment was prompted by purely professional\r\nconsiderations. The statuette, idol, fetish, or whatever it was,\r\nhad been captured some months before in the wooded swamps\r\nsouth of New Orleans during a raid on a supposed voodoo\r\nmeeting; and so singular and hideous were the rites connected\r\nwith it, that the police could not but realize that they had\r\nstumbled\r\non a dark cult totally unknown to them, and infinitely more\r\ndiabolic than even the blackest of the African voodoo circles. Of\r\nits origin, apart from the erratic and unbelievable tales extorted\r\nfrom the captured members, absolutely nothing was to be\r\ndiscovered; hence the anxiety of the police for any antiquarian\r\nlore which might help them to place the frightful symbol, and\r\nthrough it track down the cult to its fountain-head.\r\nInspector Legrasse was scarcely prepared for the sensation\r\nwhich his offering created. One sight of the thing had been\r\nenough to throw the assembled men of science into a state of\r\ntense excitement, and they lost no time in crowding around him\r\nto gaze at the diminutive figure whose utter strangeness and air\r\nof genuinely abysmal antiquity hinted so potently at unopened\r\nand archaic vistas. No recognized school of sculpture had\r\n\r\nanimated this terrible object, yet centuries and even thousands\r\nof years seemed recorded in its dim and greenish surface of\r\nunplaceable stone.\r\nThe figure, which was finally passed slowly from man to man for\r\nclose and careful study, was between seven and eight inches in\r\nheight, and of exquisitely artistic workmanship. It represented a\r\nmonster of vaguely anthropoid outline, but with an octopus-like\r\nhead whose face was a mass of feelers, a scaly, rubberylooking\r\nbody, prodigious claws on hind and fore feet, and long,\r\nnarrow wings behind. This thing, which seemed instinct with a\r\nfearsome and unnatural malignancy, was of a somewhat\r\nbloated corpulence, and squatted evilly on a rectangular block\r\nor pedestal covered with undecipherable characters. The tips of\r\nthe wings touched the back edge of the block, the seat\r\noccupied the center, whilst the long, curved claws of the\r\ndoubled-up, crouching hind legs gripped the front edge and\r\nextended a quarter of the way clown toward the bottom of the\r\npedestal. The cephalopod head was bent forward, so that the\r\nends of the facial feelers brushed the backs of huge fore paws\r\nwhich clasped the croucher's elevated knees. The aspect of the\r\nwhole was abnormally life-like, and the more subtly fearful\r\nbecause its source was so totally unknown. Its vast, awesome,\r\nand incalculable age was unmistakable; yet not one link did it\r\nshow with any known type of art belonging to civilization's\r\nyouth—or indeed to any other time. Totally separate and apart,\r\nits very material was a mystery; for the soapy, greenish-black\r\n\r\nstone with its golden or iridescent flecks and striations\r\nresembled nothing familiar to geology or mineralogy. The\r\ncharacters along the base were equally baffling; and no\r\nmember present, despite a representation of half the world's\r\nexpert learning in this field, could form the least notion of even\r\ntheir remotest linguistic kinship. They, like the subject and\r\nmaterial, belonged to something horribly remote and distinct\r\nfrom mankind as we know it. something frightfully suggestive of\r\nold and unhallowed cycles of life in which our world and our\r\nconceptions have no part.\r\nAnd yet, as the members severally shook their heads and\r\nconfessed defeat at\r\nthe Inspector's problem, there was one man in that gathering\r\nwho suspected a touch of bizarre familiarity in the monstrous\r\nshape and writing, and who presently told with some diffidence\r\nof the odd trifle he knew. This person was the late William\r\nChanning Webb, Professor of Anthropology in Princeton\r\nUniversity, and an explorer of no slight note. Professor Webb\r\nhad been engaged, forty-eight years before, in a tour of\r\nGreenland and Iceland in search of some Runic inscriptions\r\nwhich he failed to unearth; and whilst high up on the West\r\nGreenland coast had encountered a singular tribe or cult of\r\ndegenerate Esquimaux whose religion, a curious form of devilworship,\r\nchilled him with its deliberate bloodthirstiness and\r\nrepulsiveness. It was a faith of which other Esquimaux knew\r\n\r\nlittle, and which they mentioned only with shudders, saying that\r\nit had come down from horribly ancient aeons before ever the\r\nworld was made. Besides nameless rites and human sacrifices\r\nthere were certain queer hereditary rituals addressed to a\r\nsupreme elder devil or tornasuk; and of this Professor Webb had\r\ntaken a careful phonetic copy from an aged angekok or wizardpriest,\r\nexpressing the sounds in Roman letters as best he knew\r\nhow. But just now of prime significance was the fetish which this\r\ncult had cherished, and around which they danced when the\r\naurora leaped high over the ice cliffs. It was, the professor\r\nstated, a very crude bas-relief of stone, comprising a hideous\r\npicture and some cryptic writing. And so far as he could tell, it\r\nwas a rough parallel in all essential features of the bestial thing\r\nnow lying before the meeting.\r\nThis data, received with suspense and astonishment by the\r\nassembled members, proved doubly exciting to Inspector\r\nLegrasse; and he began at once to ply his informant with\r\nquestions. Having noted and copied an oral ritual among the\r\nswamp cult-worshipers his men had arrested, he besought the\r\nprofessor to remember as best he might the syllables taken\r\ndown amongst the diabolist Esquimaux. There then followed an\r\nexhaustive comparison of details, and a moment of really awed\r\nsilence when both detective and scientist agreed on the virtual\r\nidentity of the phrase common to two hellish rituals so many\r\nworlds of distance apart. What, in substance, both the\r\nEsquimaux wizards and the Louisiana swamp-priests had\r\n\r\nchanted to their kindred idols was something very like this: the\r\nword-divisions being guessed at from traditional breaks in the\r\nphrase as chanted aloud:\r\n\"Ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn.\"\r\nLegrasse had one point in advance of Professor Webb, for\r\nseveral among his mongrel prisoners had repeated to him what\r\nolder celebrants had told them the words meant. This text, as\r\ngiven, ran something like this:\r\n\"In his house at R'lyeh dead Cthulhu waits dreaming.\"\r\nAnd now, in response to a general and urgent demand,\r\nInspector Legrasse related as fully as possible his experience\r\nwith the swamp worshipers; telling a\r\nstory to which I could see my uncle attached profound\r\nsignificance. It savored of the wildest dreams of myth-maker\r\nand theosophist, and disclosed an astonishing degree of cosmic\r\nimagination among such half-castes and pariahs as might be\r\nleast expected to possess it.\r\nOn November 1st, 1907, there had come to the New Orleans\r\npolice a frantic summons from the swamp and lagoon country\r\nto the south. The squatters there, mostly primitive but goodnatured\r\ndescendants of Lafitte's men, were in the grip of stark\r\nterror from an unknown thing which had stolen upon them in the\r\nnight. It was voodoo, apparently, but voodoo of a more terrible\r\n\r\nsort than they had ever known; and some of their women and\r\nchildren had disappeared since the malevolent tom-tom had\r\nbegun its incessant beating far within the black haunted woods\r\nwhere no dweller ventured. There were insane shouts and\r\nharrowing screams, soul-chilling chants and dancing devilflames;\r\nand, the frightened messenger added, the people could\r\nstand it no more.\r\nSo a body of twenty police, filling two carriages and an\r\nautomobile, had set out in the late afternoon with the shivering\r\nsquatter as a guide. At the end of the passable road they\r\nalighted, and for miles splashed on in silence through the\r\nterrible cypress woods where day never came. Ugly roots and\r\nmalignant hanging nooses of Spanish moss beset them, and\r\nnow and then a pile of dank stones or fragment of a rotting wall\r\nintensified by its hint of morbid habitation a depression which\r\nevery malformed tree and every fungous islet combined to\r\ncreate. At length the squatter settlement, a miserable huddle of\r\nhuts, hove in sight; and hysterical dwellers ran out to cluster\r\naround the group of bobbing lanterns. The muffled beat of tomtoms\r\nwas now faintly audible far, far ahead; and a curdling\r\nshriek came at infrequent intervals when the wind shifted. A\r\nreddish glare, too, seemed to filter through pale undergrowth\r\nbeyond the endless avenues of forest night. Reluctant even to\r\nbe left alone again, each one of the cowed squatters refused\r\npoint-blank to advance another inch toward the scene of unholy\r\nworship, so Inspector Legrasse and his nineteen colleagues\r\n\r\nplunged on unguided into black arcades of horror that none of\r\nthem had ever trod before.\r\nThe region now entered by the police was one of traditionally\r\nevil repute, substantially unknown and untraversed by white\r\nmen. There were legends of a hidden lake unglimpsed by mortal\r\nsight, in which dwelt a huge, formless white polypous thing with\r\nluminous eyes; and squatters whispered that bat-winged devils\r\nflew up out of caverns in inner earth to worship it at midnight.\r\nThey said it had been there before d'Iberville, before La Salle,\r\nbefore the Indians, and before even the wholesome beasts and\r\nbirds of the woods. It was nightmare itself, and to see it was to\r\ndie. But it made men dream, and so they knew enough to keep\r\naway. The present voodoo orgy was, indeed, on the merest\r\nfringe of this abhorred area, but that location was bad enough;\r\nhence perhaps the very place of the worship had terrified the\r\nsquatters more than the\r\nshocking sounds and incidents.\r\nOnly poetry or madness could do justice to the noises heard by\r\nLegrasse's men as they ploughed on through the black morass\r\ntoward the red glare and muffled tom-toms. There are vocal\r\nqualities peculiar to men, and vocal qualities peculiar to beasts;\r\nand it is terrible to hear the one when the source should yield\r\nthe other. Animal fury and orgiastic license here whipped\r\nthemselves to daemoniac heights by howls and squawking\r\n\r\necstasies that tore and reverberated through those nighted\r\nwoods like pestilential tempests from the gulfs of hell. Now and\r\nthen the less organized ululation would cease, and from what\r\nseemed a well-drilled chorus of hoarse voices would rise in singsong\r\nchant that hideous phrase or ritual:\r\n\"Ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn.\"\r\nThen the men, having reached a spot where the trees were\r\nthinner, came suddenly in sight of the spectacle itself. Four of\r\nthem reeled, one fainted, and two were shaken into a frantic cry\r\nwhich the mad cacophony of the orgy fortunately deadened.\r\nLegrasse dashed swamp water on the face of the fainting man,\r\nand all stood trembling and nearly hypnotized with horror.\r\nIn a natural glade of the swamp stood a grassy island of\r\nperhaps an acre's extent, clear of trees and tolerably dry. On\r\nthis now leaped and twisted a more indescribable horde of\r\nhuman abnormality than any but a Sime or an Angarola could\r\npaint. Void of clothing, this hybrid spawn were braying,\r\nbellowing, and writhing about a monstrous ring-shaped bonfire;\r\nin the center of which, revealed by occasional rifts in the curtain\r\nof flame, stood a great granite monolith some eight feet in\r\nheight; on top of which, incongruous in its diminutiveness,\r\nrested the noxious carven statuette. From a wide circle of ten\r\nscaffolds set up at regular intervals with the flame-girt monolith\r\nas a center hung, head downward, the oddly marred bodies of\r\nthe helpless squatters who had disappeared. It was inside this\r\ncircle that the ring of worshipers jumped and roared, the\r\n\r\ngeneral direction of the mass motion being from left to right in\r\nendless Bacchanal between the ring of bodies and the ring of\r\nfire.\r\nIt may have been only imagination and it may have been only\r\nechoes which induced one of the men, an excitable Spaniard, to\r\nfancy he heard antiphonal responses to the ritual from some far\r\nand unillumined spot deeper within the wood of ancient\r\nlegendry and horror. This man, Joseph D. Galvez, I later met\r\nand questioned; and he proved distractingly imaginative. He\r\nindeed went so far as to hint of the faint beating of great wings,\r\nand of a glimpse of shining eyes and a mountainous white bulk\r\nbeyond the remotest trees but I suppose he had been hearing\r\ntoo much native superstition.\r\nActually, the horrified pause of the men was of comparatively\r\nbrief duration. Duty came first; and although there must have\r\nbeen nearly a hundred mongrel\r\ncelebrants in the throng, the police relied on their firearms and\r\nplunged determinedly into the nauseous rout. For five minutes\r\nthe resultant din and chaos were beyond description. Wild blows\r\nwere struck, shots were fired, and escapes were made; but in\r\nthe end Legrasse was able to count some forty- seven sullen\r\nprisoners, whom he forced to dress in haste and fall into line\r\nbetween two rows of policemen. Five of the worshipers lay\r\ndead, and two severely wounded ones were carried away on\r\n\r\nimprovised stretchers by their fellow-prisoners. The image on\r\nthe monolith, of course, was carefully removed and carried back\r\nby Legrasse.\r\nExamined at headquarters after a trip of intense strain and\r\nweariness, the prisoners all proved to be men of a very low,\r\nmixed-blooded, and mentally aberrant type. Most were seamen,\r\nand a sprinkling of Negroes and mulattoes, largely West\r\nIndians or Brava Portuguese from the Cape Verde Islands, gave\r\na colouring of voodooism to the heterogeneous cult. But before\r\nmany questions were asked, it became manifest that something\r\nfar deeper and older than Negro fetishism was involved.\r\nDegraded and ignorant as they were, the creatures held with\r\nsurprising consistency to the central idea of their loathsome\r\nfaith.\r\nThey worshipped, so they said, the Great Old Ones who lived\r\nages before there were any men, and who came to the young\r\nworld out of the sky. Those Old Ones were gone now, inside the\r\nearth and under the sea; but their dead bodies had told their\r\nsecrets in dreams to the first men, who formed a cult which had\r\nnever died. This was that cult, and the prisoners said it had\r\nalways existed and always would exist, hidden in distant wastes\r\nand dark places all over the world until the time when the great\r\npriest Cthulhu, from his dark house in the mighty city of R'lyeh\r\nunder the waters, should rise and bring the earth again beneath\r\nhis sway. Some day he would call, when the stars were ready,\r\nand the secret cult would always be waiting to liberate him.\r\n\r\nMeanwhile no more must be told. There was a secret which even\r\ntorture could not extract. Mankind was not absolutely alone\r\namong the conscious things of earth, for shapes came out of\r\nthe dark to visit the faithful few. But these were not the Great\r\nOld Ones. No man had ever seen the Old Ones. The carven idol\r\nwas great Cthulhu, but none might say whether or not the\r\nothers were precisely like him. No one could read the old writing\r\nnow, but things were told by word of mouth. The chanted ritual\r\nwas not the secret—that was never spoken aloud, only\r\nwhispered. The chant meant only this: \"In his house at R'lyeh\r\ndead Cthulhu waits dreaming.\"\r\nOnly two of the prisoners were found sane enough to be\r\nhanged, and the rest were committed to various institutions. All\r\ndenied a part in the ritual murders, and averred that the killing\r\nhad been done by Black Winged Ones which had come to them\r\nfrom their immemorial meeting-place in the haunted wood. But\r\nof those mysterious allies no coherent account could ever be\r\ngained. What the\r\npolice did extract, came mainly from the immensely aged\r\nmestizo named Castro, who claimed to have sailed to strange\r\nports and talked with undying leaders of the cult in the\r\nmountains of China.\r\nOld Castro remembered bits of hideous legend that paled the\r\nspeculations of theosophists and made man and the world\r\n\r\nseem recent and transient indeed. There had been aeons when\r\nother Things ruled on the earth, and They had had great cities.\r\nRemains of Them, he said the deathless Chinamen had told him,\r\nwere still be found as Cyclopean stones on islands in the Pacific.\r\nThey all died vast epochs of time before men came, but there\r\nwere arts which could revive Them when the stars had come\r\nround again to the right positions in the cycle of eternity. They\r\nhad, indeed, come themselves from the stars, and brought Their\r\nimages with Them.\r\nThese Great Old Ones, Castro continued, were not composed\r\naltogether of flesh and blood. They had shape—for did not this\r\nstar-fashioned image prove it?—but that shape was not made\r\nof matter. When the stars were right, They could plunge from\r\nworld to world through the sky; but when the stars were wrong,\r\nThey could not live. But although They no longer lived, They\r\nwould never really die. They all lay in stone houses in Their great\r\ncity of R'lyeh, preserved by the spells of mighty Cthulhu for a\r\nglorious surrection when the stars and the earth might once\r\nmore be ready for Them. But at that time some force from\r\noutside must serve to liberate Their bodies. The spells that\r\npreserved them intact likewise prevented Them from making an\r\ninitial move, and They could only lie awake in the dark and think\r\nwhilst uncounted millions of years rolled by. They knew all that\r\nwas occurring in the universe, for Their mode of speech was\r\ntransmitted thought. Even now They talked in Their tombs.\r\nWhen, after infinities of chaos, the first men came, the Great\r\n\r\nOld Ones spoke to the sensitive among them by moulding their\r\ndreams; for only thus could Their language reach the fleshly\r\nminds of mammals.\r\nThen, whispered Castro, those first men formed the cult around\r\ntall idols which the Great Ones showed them; idols brought in\r\ndim eras from dark stars. That cult would never die till the stars\r\ncame right again, and the secret priests would take great\r\nCthulhu from His tomb to revive His subjects and resume His\r\nrule of earth. The time would be easy to know, for then mankind\r\nwould have become as the Great Old Ones; free and wild and\r\nbeyond good and evil, with laws and morals thrown aside and\r\nall men shouting and killing and levelling in joy. Then the\r\nliberated Old Ones would teach them new ways to shout and kill\r\nand revel and enjoy themselves, and all the earth would flame\r\nwith a holocaust of ecstasy and freedom. Meanwhile the cult, by\r\nappropriate rites, must keep alive the memory of those ancient\r\nways and shadow forth the prophecy of their return.\r\nIn the elder time chosen men had talked with the entombed Old\r\nOnes in dreams, but then something happened. The great stone\r\ncity R'lyeh, with its\r\nmonoliths and sepulchers, had sunk beneath the waves; and the\r\ndeep waters, full of the one primal mystery through which not\r\neven thought can pass, had cut off the spectral intercourse. But\r\nmemory never died, and the high-priests said that the city\r\n\r\nwould rise again when the stars were right. Then came out of\r\nthe earth the black spirits of earth, mouldy and shadowy, and\r\nfull of dim rumors picked up in caverns beneath forgotten seabottoms.\r\nBut of them old Castro dared not speak much. He cut\r\nhimself off hurriedly, and no amount of persuasion or subtlety\r\ncould elicit more in this direction. The size of the Old Ones, too,\r\nhe curiously declined to mention. Of the cult, he said that he\r\nthought the center lay amid the pathless desert of Arabia,\r\nwhere Irem, the City of Pillars, dreams hidden and untouched. It\r\nwas not allied to the European witch-cult, and was virtually\r\nunknown beyond its members. No book had ever really hinted\r\nof it, though the deathless Chinamen said that there were\r\ndouble meanings in the Necronomicon of the mad Arab Abdul\r\nAlhazred which the initiated might read as they chose,\r\nespecially the much-discussed couplet:\r\nThat is not dead which can eternal lie,\r\nAnd with strange aeons even death may die.\r\nLegrasse, deeply impressed and not a little bewildered, had\r\ninquired in vain concerning the historic affiliations of the cult.\r\nCastro, apparently, had told the truth when he said that it was\r\nwholly secret. The authorities at Tulane University could shed no\r\nlight upon either cult or image, and now the detective had come\r\nto the highest authorities in the country and met with no more\r\nthan the Greenland tale of Professor Webb.\r\n\r\nThe feverish interest aroused at the meeting by Legrasse's tale,\r\ncorroborated as it was by the statuette, is echoed in the\r\nsubsequent correspondence of those who attended; although\r\nscant mention occurs in the formal publications of the society.\r\nCaution is the first care of those accustomed to face occasional\r\ncharlatanry and imposture. Legrasse for some time lent the\r\nimage to Professor Webb, but at the latter's death it was\r\nreturned to him and remains in his possession, where I viewed it\r\nnot long ago. It is truly a terrible thing, and unmistakably akin\r\nto the dream-sculpture of young Wilcox.\r\nThat my uncle was excited by the tale of the sculptor I did not\r\nwonder, for what thoughts must arise upon hearing, after a\r\nknowledge of what Legrasse had learned of the cult, of a\r\nsensitive young man who had dreamed not only the figure and\r\nexact hieroglyphics of the swamp-found image and the\r\nGreenland devil tablet, but had come in his dreams upon at\r\nleast three of the precise words of the formula uttered alike by\r\nEsquimaux diabolists and mongrel Louisianans?. Professor\r\nAngell's instant start on an investigation of the utmost\r\nthoroughness was eminently natural; though privately I\r\nsuspected young Wilcox of having heard of the cult in some\r\nindirect way, and of having invented a series of dreams to\r\nheighten and continue the mystery at my uncle's expense. The\r\ndream-narratives and cuttings collected by the professor were,\r\nof\r\n\r\ncourse, strong corroboration; but the rationalism of my mind\r\nand the extravagance of the whole subject led me to adopt\r\nwhat I thought the most sensible conclusions. So, after\r\nthoroughly studying the manuscript again and correlating the\r\ntheosophical and anthropological notes with the cult narrative\r\nof Legrasse, I made a trip to Providence to see the sculptor and\r\ngive him the rebuke I thought proper for so boldly imposing\r\nupon a learned and aged man.\r\nWilcox still lived alone in the Fleur-de-Lys Building in Thomas\r\nStreet, a hideous Victorian imitation of seventeenth century\r\nBreton Architecture which flaunts its stuccoed front amidst the\r\nlovely colonial houses on the ancient hill, and under the very\r\nshadow of the finest Georgian steeple in America, I found him\r\nat work in his rooms, and at once conceded from the specimens\r\nscattered about that his genius is indeed profound and\r\nauthentic. He will, I believe, some time be heard from as one of\r\nthe great decadents; for he has crystallized in clay and will one\r\nday mirror in marble those nightmares and fantasies which\r\nArthur Machen evokes in prose, and Clark Ashton Smith makes\r\nvisible in verse and in painting.\r\nDark, frail, and somewhat unkempt in aspect, he turned\r\nlanguidly at my knock and asked me my business without rising.\r\nThen I told him who I was, he displayed some interest; for my\r\nuncle had excited his curiosity in probing his strange dreams,\r\nyet had never explained the reason for the study. I did not\r\nenlarge his knowledge in this regard, but sought with some\r\n\r\nsubtlety to draw him out. In a short time I became convinced of\r\nhis absolute sincerity, for he spoke of the dreams in a manner\r\nnone could mistake. They and their subconscious residuum had\r\ninfluenced his art profoundly, and he showed me a morbid\r\nstatue whose contours almost made me shake with the potency\r\nof its black suggestion. He could not recall having seen the\r\noriginal of this thing except in his own dream bas-relief, but the\r\noutlines had formed themselves insensibly under his hands. It\r\nwas, no doubt, the giant shape he had raved of in delirium. That\r\nhe really knew nothing of the hidden cult, save from what my\r\nuncle's relentless catechism had let fall, he soon made clear; and\r\nagain I strove to think of some way in which he could possibly\r\nhave received the weird impressions.\r\nHe talked of his dreams in a strangely poetic fashion; making\r\nme see with terrible vividness the damp Cyclopean city of slimy\r\ngreen stone—whose geometry, he oddly said, was all wrong—\r\nand hear with frightened expectancy the ceaseless, half-mental\r\ncalling from underground: \"Cthulhu fhtagn\", \"Cthulhu fhtagn.\"\r\nThese words had formed part of that dread ritual which told of\r\ndead Cthulhu's dream-vigil in his stone vault at R'lyeh, and I felt\r\ndeeply moved despite my rational beliefs. Wilcox, I was sure,\r\nhad heard of the cult in some casual way, and had soon\r\nforgotten it amidst the mass of his equally weird reading and\r\nimagining. Later, by virtue of its sheer impressiveness, it had\r\nfound\r\n\r\nsubconscious expression in dreams, in the bas-relief, and in the\r\nterrible statue I now beheld; so that his imposture upon my\r\nuncle had been a very innocent one. The youth was of a type, at\r\nonce slightly affected and slightly ill- mannered, which I could\r\nnever like, but I was willing enough now to admit both his\r\ngenius and his honesty. I took leave of him amicably, and wish\r\nhim all the success his talent promises.\r\nThe matter of the cult still remained to fascinate me, and at\r\ntimes I had visions of personal fame from researches into its\r\norigin and connections. I visited New Orleans, talked with\r\nLegrasse and others of that old-time raiding-party, saw the\r\nfrightful image, and even questioned such of the mongrel\r\nprisoners as still survived. Old Castro, unfortunately, had been\r\ndead for some years. What I now heard so graphically at firsthand,\r\nthough it was really no more than a detailed confirmation\r\nof what my uncle had written, excited me afresh; for I felt sure\r\nthat I was on the track of a very real, very secret, and very\r\nancient religion whose discovery would make me an\r\nanthropologist of note. My attitude was still one of absolute\r\nmaterialism, as l wish it still were, and I discounted with almost\r\ninexplicable perversity the coincidence of the dream notes and\r\nodd cuttings collected by Professor Angell.\r\nOne thing I began to suspect, and which I now fear I know, is\r\nthat my uncle's death was far from natural. He fell on a narrow\r\nhill street leading up from an ancient waterfront swarming with\r\nforeign mongrels, after a careless push from a Negro sailor. I\r\n\r\ndid not forget the mixed blood and marine pursuits of the cultmembers\r\nin Louisiana, and would not be surprised to learn of\r\nsecret methods and rites and beliefs. Legrasse and his men, it is\r\ntrue, have been let alone; but in Norway a certain seaman who\r\nsaw things is dead. Might not the deeper inquiries of my uncle\r\nafter encountering the sculptor's data have come to sinister\r\nears?. I think Professor Angell died because he knew too much,\r\nor because he was likely to learn too much. Whether I shall go\r\nas he did remains to be seen, for I have learned much now.\r\n", 2, "" },
                    { 3, 1, "If heaven ever wishes to grant me a boon, it will be a total\r\neffacing of the results of a mere chance which fixed my eye on\r\na certain stray piece of shelf- paper. It was nothing on which I\r\nwould naturally have stumbled in the course of my daily round,\r\nfor it was an old number of an Australian journal, the Sydney\r\nBulletin for April 18, 1925. It had escaped even the cutting\r\nbureau which had at the time of its issuance been avidly\r\ncollecting material for my uncle's research.\r\nI had largely given over my inquiries into what Professor Angell\r\ncalled the \"Cthulhu Cult\", and was visiting a learned friend in\r\nPaterson, New Jersey; the curator of a local museum and a\r\nmineralogist of note. Examining one day the reserve specimens\r\nroughly set on the storage shelves in a rear room of the\r\nmuseum, my eye was caught by an odd picture in one of the old\r\npapers spread beneath the stones. It was the Sydney Bulletin I\r\nhave mentioned, for my friend had wide affiliations in all\r\nconceivable foreign parts; and the picture was a half-tone cut\r\nof a hideous stone image almost identical with that which\r\nLegrasse had found in the swamp.\r\nEagerly clearing the sheet of its precious contents, I scanned\r\nthe item in detail; and was disappointed to find it of only\r\nmoderate length. What it suggested, however, was of\r\n\r\nportentous significance to my flagging quest; and I carefully\r\ntore it out for immediate action. It read as follows:\r\nMYSTERY DERELICT FOUND AT SEA\r\nVigilant Arrives With Helpless Armed New Zealand Yacht in Tow.\r\nOne Survivor and Dead Man Found Aboard. Tale of Desperate\r\nBattle and Deaths at Sea. Rescued Seaman Refuses Particulars\r\nof Strange Experience. Odd Idol Found in His Possession.\r\nInquiry to Follow.\r\nThe Morrison Co.'s freighter Vigilant, bound from Valparaiso,\r\narrived this morning at its wharf in Darling Harbor, having in\r\ntow the battled and disabled but heavily armed steam yacht\r\nAlert of Dunedin, N.Z., which was sighted April 12th in S.\r\nLatitude 34°21', W. Longitude 152°17', with one living and one\r\ndead man aboard.\r\nThe Vigilant left Valparaiso March 25th, and on April 2nd was\r\ndriven considerably south of her course by exceptionally heavy\r\nstorms and monster waves. On April 12th the derelict was\r\nsighted; and though apparently deserted, was found upon\r\nboarding to contain one survivor in a half-delirious condition\r\nand one man who had evidently been dead for more than a\r\nweek. The living man was clutching a horrible stone idol of\r\nunknown origin, about foot in height, regarding whose nature\r\nauthorities at Sydney University, the Royal Society, and the\r\nMuseum in College Street all profess complete bafflement, and\r\n\r\nwhich the survivor says he found in the cabin of the yacht, in a\r\nsmall carved shrine of common pattern.\r\nThis man, after recovering his senses, told an exceedingly\r\nstrange story of piracy and slaughter. He is Gustaf Johansen, a\r\nNorwegian of some intelligence, and had been second mate of\r\nthe two-masted schooner Emma of Auckland, which sailed for\r\nCallao February 20th with a complement of eleven men. The\r\nEmma, he says, was delayed and thrown widely south of her\r\ncourse by the great storm of March 1st, and on March 22nd, in\r\nS. Latitude 49°51' W. Longitude 128°34', encountered the Alert,\r\nmanned by a queer and evil-looking\r\ncrew of Kanakas and half-castes. Being ordered peremptorily to\r\nturn back, Capt. Collins refused; whereupon the strange crew\r\nbegan to fire savagely and without warning upon the schooner\r\nwith a peculiarly heavy battery of brass cannon forming part of\r\nthe yacht's equipment. The Emma's men showed fight, says the\r\nsurvivor, and though the schooner began to sink from shots\r\nbeneath the water-line they managed to heave alongside their\r\nenemy and board her, grappling with the savage crew on the\r\nyacht's deck, and being forced to kill them all, the number being\r\nslightly superior, because of their particularly abhorrent and\r\ndesperate though rather clumsy mode of fighting.\r\nThree of the Emma's men, including Capt. Collins and First Mate\r\nGreen, were killed; and the remaining eight under Second Mate\r\n\r\nJohansen proceeded to navigate the captured yacht, going\r\nahead in their original direction to see if any reason for their\r\nordering back had existed. The next day, it appears, they raised\r\nand landed on a small island, although none is known to exist in\r\nthat part of the ocean; and six of the men somehow died\r\nashore, though Johansen is queerly reticent about this part of\r\nhis story, and speaks only of their falling into a rock chasm.\r\nLater, it seems, he and one companion boarded the yacht and\r\ntried to manage her, but were beaten about by the storm of\r\nApril 2nd, From that time till his rescue on the 12th the man\r\nremembers little, and he does not even recall when William\r\nBriden, his companion, died. Briden's death reveals no apparent\r\ncause, and was probably due to excitement or exposure. Cable\r\nadvices from Dunedin report that the Alert was well known there\r\nas an island trader, and bore an evil reputation along the\r\nwaterfront, It was owned by a curious group of half-castes\r\nwhose frequent meetings and night trips to the woods attracted\r\nno little curiosity; and it had set sail in great haste just after the\r\nstorm and earth tremors of March 1st. Our Auckland\r\ncorrespondent gives the Emma and her crew an excellent\r\nreputation, and Johansen is described as a sober and worthy\r\nman. The admiralty will institute an inquiry on the whole matter\r\nbeginning tomorrow, at which every effort will be made to\r\ninduce Johansen to speak more freely than he has done\r\nhitherto.\r\n\r\nThis was all, together with the picture of the hellish image; but\r\nwhat a train of ideas it started in my mind! Here were new\r\ntreasuries of data on the Cthulhu Cult, and evidence that it had\r\nstrange interests at sea as well as on land. What motive\r\nprompted the hybrid crew to order back the Emma as they\r\nsailed about with their hideous idol? What was the unknown\r\nisland on which six of the Emma's crew had died, and about\r\nwhich the mate Johansen was so secretive? What had the viceadmiralty's\r\ninvestigation brought out, and what was known of\r\nthe noxious cult in Dunedin? And most marvelous of all, what\r\ndeep and more than natural linkage of dates was this which\r\ngave a malign and now undeniable significance to the various\r\nturns of events so carefully noted by my uncle?\r\nMarch 1st—or February 28th according to the International\r\nDate Line—the\r\nearthquake and storm had come. From Dunedin the Alert and\r\nher noisome crew had darted eagerly forth as if imperiously\r\nsummoned, and on the other side of the earth poets and artists\r\nhad begun to dream of a strange, dank Cyclopean city whilst a\r\nyoung sculptor had moulded in his sleep the form of the\r\ndreaded Cthulhu. March 23rd the crew of the Emma landed on\r\nan unknown island and left six men dead; and on that date the\r\ndreams of sensitive men assumed a heightened vividness and\r\ndarkened with dread of a giant monster's malign pursuit, whilst\r\nan architect had gone mad and a sculptor had lapsed suddenly\r\n\r\ninto delirium! And what of this storm of April 2nd—the date on\r\nwhich all dreams of the dank city ceased, and Wilcox emerged\r\nunharmed from the bondage of strange fever? What of all this—\r\nand of those hints of old Castro about the sunken, star-born Old\r\nOnes and their coming reign; their faithful cult and their\r\nmastery of dreams? Was I tottering on the brink of cosmic\r\nhorrors beyond man's power to bear? If so, they must be\r\nhorrors of the mind alone, for in some way the second of April\r\nhad put a stop to whatever monstrous menace had begun its\r\nsiege of mankind's soul.\r\nThat evening, after a day of hurried cabling and arranging, I\r\nbade my host adieu and took a train for San Francisco. In less\r\nthan a month I was in Dunedin; where, however, I found that\r\nlittle was known of the strange cult- members who had lingered\r\nin the old sea-taverns. Waterfront scum was far too common\r\nfor special mention; though there was vague talk about one\r\ninland trip these mongrels had made, during which faint\r\ndrumming and red flame were noted on the distant hills. In\r\nAuckland I learned that Johansen had returned with yellow hair\r\nturned white after a perfunctory and inconclusive questioning at\r\nSydney, and had thereafter sold his cottage in West Street and\r\nsailed with his wife to his old home in Oslo. Of his stirring\r\nexperience he would tell his friends no more than he had told\r\nthe admiralty officials, and all they could do was to give me his\r\nOslo address.\r\n\r\nAfter that I went to Sydney and talked profitlessly with seamen\r\nand members of the vice-admiralty court. I saw the Alert, now\r\nsold and in commercial use, at Circular Quay in Sydney Cove,\r\nbut gained nothing from its non-committal bulk. The crouching\r\nimage with its cuttlefish head, dragon body, scaly wings, and\r\nhieroglyphed pedestal, was preserved in the Museum at Hyde\r\nPark; and I studied it long and well, finding it a thing of balefully\r\nexquisite workmanship, and with the same utter mystery,\r\nterrible antiquity, and unearthly strangeness of material which I\r\nhad noted in Legrasse's smaller specimen. Geologists, the\r\ncurator told me, had found it a monstrous puzzle; for they\r\nvowed that the world held no rock like it. Then I thought with a\r\nshudder of what Old Castro had told Legrasse about the Old\r\nOnes; \"They had come from the stars, and had brought Their\r\nimages with Them.\"\r\nShaken with such a mental revolution as I had never before\r\nknown, I now resolved to visit Mate Johansen in Oslo. Sailing\r\nfor London, I re-embarked at\r\nonce for the Norwegian capital; and one autumn day landed at\r\nthe trim wharves in the shadow of the Egeberg. Johansen's\r\naddress, I discovered, lay in the Old Town of King Harold\r\nHaardrada, which kept alive the name of Oslo during all the\r\ncenturies that the greater city masqueraded as \"Christiana.\" I\r\nmade the brief trip by taxicab, and knocked with palpitant heart\r\nat the door of a neat and ancient building with plastered front.\r\n\r\nA sad-faced woman in black answered my summons, and I was\r\nstung th disappointment when she told me in halting English\r\nthat Gustaf Johansen was no more.\r\nHe had not long survived his return, said his wife, for the doings\r\nsea in 1925 had broken him. He had told her no more than he\r\ntold the public, but had left a long manuscript—of \"technical\r\nmatters\" as he said— written in English, evidently in order to\r\nguard her from the peril of casual perusal. During a walk rough\r\na narrow lane near the Gothenburg dock, a bundle of papers\r\nfalling from an attic window had knocked him down. Two Lascar\r\nsailors at once helped him to his feet, but before the ambulance\r\ncould reach him he was dead. Physicians found no adequate\r\ncause the end, and laid it to heart trouble and a weakened\r\nconstitution. I now felt gnawing at my vitals that dark terror\r\nwhich will never leave me till I, too, am at rest; \"accidentally\" or\r\notherwise. Persuading the widow that my connection with her\r\nhusband's \"technical matters\" was sufficient to entitle me to his\r\nmanuscript, I bore the document away and began to read it on\r\nthe London boat.\r\nIt was a simple, rambling thing—a naive sailor's effort at a postfacto\r\ndiary— and strove to recall day by day that last awful\r\nvoyage. I cannot attempt to transcribe it verbatim in all its\r\ncloudiness and redundancy, but I will tell its gist enough to show\r\nwhy the sound the water against the vessel's sides became so\r\nunendurable to me that I stopped my ears with cotton.\r\n\r\nJohansen, thank God, did not know quite all, even though he\r\nsaw the city and the Thing, but I shall never sleep calmly again\r\nwhen I think of the horrors that lurk ceaselessly behind life in\r\ntime and in space, and of those unhallowed blasphemies from\r\nelder stars which dream beneath the sea, known and favored by\r\na nightmare cult ready and eager to loose them upon the world\r\nwhenever another earthquake shall heave their monstrous stone\r\ncity again to the sun and air.\r\nJohansen's voyage had begun just as he told it to the viceadmiralty.\r\nThe Emma, in ballast, had cleared Auckland on\r\nFebruary 20th, and had felt the full force of that earthquakeborn\r\ntempest which must have heaved up from the sea-bottom\r\nthe horrors that filled men's dreams. Once more under control,\r\nthe ship was making good progress when held up by the Alert\r\non March 22nd, and I could feel the mate's regret as he wrote of\r\nher bombardment and sinking. Of the swarthy cult-fiends on the\r\nAlert he speaks with significant horror. There was some\r\npeculiarly abominable quality about them which made their\r\ndestruction seem almost a duty, and Johansen shows\r\ningenuous wonder at the\r\ncharge of ruthlessness brought against his party during the\r\nproceedings of the court of inquiry. Then, driven ahead by\r\ncuriosity in their captured yacht under Johansen's command,\r\nthe men sight a great stone pillar sticking out of the sea, and in\r\nS. Latitude 47°9', W. Longitude l23°43', come upon a coastline\r\n\r\nof mingled mud, ooze, and weedy Cyclopean masonry which\r\ncan be nothing less than the tangible substance of earth's\r\nsupreme terror—the nightmare corpse- city of R'lyeh, that was\r\nbuilt in measureless aeons behind history by the vast,\r\nloathsome shapes that seeped down from the dark stars. There\r\nlay great Cthulhu and his hordes, hidden in green slimy vaults\r\nand sending out at last, after cycles incalculable, the thoughts\r\nthat spread fear to the dreams of the sensitive and called\r\nimperiously to the faithful to come on a pilgrimage of liberation\r\nand restoration. All this Johansen did not suspect, but God\r\nknows he soon saw enough!\r\nI suppose that only a single mountain-top, the hideous\r\nmonolith-crowned citadel whereon great Cthulhu was buried,\r\nactually emerged from the waters. When I think of the extent of\r\nall that may be brooding down there I almost wish to kill myself\r\nforthwith. Johansen and his men were awed by the cosmic\r\nmajesty of this dripping Babylon of elder daemons, and must\r\nhave guessed without guidance that it was nothing of this or of\r\nany sane planet. Awe at the unbelievable size of the greenish\r\nstone blocks, at the dizzying height of the great carven\r\nmonolith, and at the stupefying identity of the colossal statues\r\nand bas-reliefs with the queer image found in the shrine on the\r\nAlert, is poignantly visible in every line of the mates frightened\r\ndescription.\r\nWithout knowing what futurism is like, Johansen achieved\r\nsomething very close to it when he spoke of the city; for instead\r\n\r\nof describing any definite structure or building, he dwells only\r\non broad impressions of vast angles and stone surfaces—\r\nsurfaces too great to belong to anything right or proper for this\r\nearth, and impious with horrible images and hieroglyphs. I\r\nmention his talk about angles because it suggests something\r\nWilcox had told me of his awful dreams. He said that the\r\ngeometry of the dream-place he saw was abnormal, non-\r\nEuclidean, and loathsomely redolent of spheres and dimensions\r\napart from ours. Now an unlettered seaman felt the same thing\r\nwhilst gazing at the terrible reality.\r\nJohansen and his men landed at a sloping mud-bank on this\r\nmonstrous Acropolis, and clambered slipperily up over titan\r\noozy blocks which could have been no mortal staircase. The\r\nvery sun of heaven seemed distorted when viewed through the\r\npolarizing miasma welling out from this sea-soaked perversion,\r\nand twisted menace and suspense lurked leeringly in those\r\ncrazily elusive angles of carven rock where a second glance\r\nshowed concavity after the first showed convexity.\r\nSomething very like fright had come over all the explorers\r\nbefore anything more definite than rock and ooze and weed\r\nwas seen. Each would have fled\r\nhad he not feared the scorn of the others, and it was only halfheartedly\r\nthat they searched—vainly, as it proved—for some\r\nportable souvenir to bear away.\r\n\r\nIt was Rodriguez the Portuguese who climbed up the foot of the\r\nmonolith and shouted of what he had found. The rest followed\r\nhim, and looked curiously at the immense carved door with the\r\nnow familiar squid-dragon bas-relief. It was, Johansen said, like\r\na great barn-door; and they all felt that it was a door because\r\nof the ornate lintel, threshold, and jambs around it, though they\r\ncould not decide whether it lay flat like a trap-door or slantwise\r\nlike an outside cellar-door. As Wilcox would have said, the\r\ngeometry of the place was all wrong. One could not be sure that\r\nthe sea and the ground were horizontal, hence the relative\r\nposition of everything else seemed phantasmally variable.\r\nBriden pushed at the stone in several places without result. Then\r\nDonovan felt over it delicately around the edge, pressing each\r\npoint separately as he went. He climbed interminably along the\r\ngrotesque stone moulding—that is, one would call it climbing if\r\nthe thing was not after all horizontal —and the men wondered\r\nhow any door in the universe could be so vast. Then, very softly\r\nand slowly, the acre-great lintel began to give inward at the top;\r\nand they saw that it was balanced\r\nDonovan slid or somehow propelled himself down or along the\r\njamb and rejoined his fellows, and everyone watched the queer\r\nrecession of the monstrously carven portal. In this phantasy of\r\nprismatic distortion it moved anomalously in a diagonal way, so\r\nthat all the rules of matter and perspective seemed upset.\r\nThe aperture was black with a darkness almost material. That\r\ntenebrousness was indeed a positive quality; for it obscured\r\n\r\nsuch parts of the inner walls as ought to have been revealed,\r\nand actually burst forth like smoke from its aeon- long\r\nimprisonment, visibly darkening the sun as it slunk away into\r\nthe shrunken and gibbous sky on flapping membraneous wings.\r\nThe odor rising from the newly opened depths was intolerable,\r\nand at length the quick-eared Hawkins thought he heard a\r\nnasty, slopping sound down there. Everyone listened, and\r\neveryone was listening still when It lumbered slobberingly into\r\nsight and gropingly squeezed Its gelatinous green immensity\r\nthrough the black doorway into the tainted outside air of that\r\npoison city of madness.\r\nPoor Johansen's handwriting almost gave out when he wrote of\r\nthis. Of the six men who never reached the ship, he thinks two\r\nperished of pure fright in that accursed instant. The Thing\r\ncannot be described—there is no language for such abysms of\r\nshrieking and immemorial lunacy, such eldritch contradictions\r\nof all matter, force, and cosmic order. A mountain walked or\r\nstumbled. God! What wonder that across the earth a great\r\narchitect went mad, and poor Wilcox raved with fever in that\r\ntelepathic instant? The Thing of the idols, the green, sticky\r\nspawn of the stars, had awaked to claim his own. The stars were\r\nright again, and what an age-old cult had failed to do by\r\ndesign, a band of innocent sailors had done by accident. After\r\nvigintillions of years great Cthulhu was loose again, and\r\nravening for delight.\r\n\r\nThree men were swept up by the flabby claws before anybody\r\nturned. God rest them, if there be any rest in the universe. They\r\nwere Donovan, Guerrera, and Angstrom. Parker slipped as the\r\nother three were plunging frenziedly over endless vistas of\r\ngreen-crusted rock to the boat, and Johansen swears he was\r\nswallowed up by an angle of masonry which shouldn't have\r\nbeen there; an angle which was acute, but behaved as if it were\r\nobtuse. So only Briden and Johansen reached the boat, and\r\npulled desperately for the Alert as the mountainous monstrosity\r\nflopped down the slimy stones and hesitated, floundering at the\r\nedge of the water.\r\nSteam had not been suffered to go down entirely, despite the\r\ndeparture of all hands for the shore; and it was the work of only\r\na few moments of feverish rushing up and down between wheel\r\nand engines to get the Alert under way. Slowly, amidst the\r\ndistorted horrors of that indescribable scene, she began to\r\nchurn the lethal waters; whilst on the masonry of that charnel\r\nshore that was not of earth the titan Thing from the stars\r\nslavered and gibbered like Polypheme cursing the fleeing ship\r\nof Odysseus. Then, bolder than the storied Cyclops, great\r\nCthulhu slid greasily into the water and began to pursue with\r\nvast wave-raising strokes of cosmic potency. Briden looked\r\nback and went mad, laughing shrilly as he kept on laughing at\r\nintervals till death found him one night in the cabin whilst\r\nJohansen was wandering deliriously.\r\n\r\nBut Johansen had not given out yet. Knowing that the Thing\r\ncould surely overtake the Alert until steam was fully up, he\r\nresolved on a desperate chance; and, setting the engine for full\r\nspeed, ran lightning-like on deck and reversed the wheel. There\r\nwas a mighty eddying and foaming in the noisome brine, and\r\nas the steam mounted higher and higher the brave Norwegian\r\ndrove his vessel head on against the pursuing jelly which rose\r\nabove the unclean froth like the stern of a daemon galleon. The\r\nawful squid-head with writhing feelers came nearly up to the\r\nbowsprit of the sturdy yacht, but Johansen drove on\r\nrelentlessly. There was a bursting as of an exploding bladder, a\r\nslushy nastiness as of a cloven sunfish, a stench as of a\r\nthousand opened graves, and a sound that the chronicler could\r\nnot put on paper. For an instant the ship was befouled by an\r\nacrid and blinding green cloud, and then there was only a\r\nvenomous seething astern; where—God in heaven!—the\r\nscattered plasticity of that nameless sky-spawn was nebulously\r\nrecombining in its hateful original form, whilst its distance\r\nwidened every second as the Alert gained impetus from its\r\nmounting steam.\r\nThat was all. After that Johansen only brooded over the idol in\r\nthe cabin and attended to a few matters of food for himself and\r\nthe laughing maniac by his side. He did not try to navigate after\r\nthe first bold flight, for the reaction had\r\n\r\ntaken something out of his soul. Then came the storm of April\r\n2nd, and a gathering of the clouds about his consciousness.\r\nThere is a sense of spectral whirling through liquid gulfs of\r\ninfinity, of dizzying rides through reeling universes on a comets\r\ntail, and of hysterical plunges from the pit to the moon and\r\nfrom the moon back again to the pit, all livened by a\r\ncachinnating chorus of the distorted, hilarious elder gods and\r\nthe green, bat-winged mocking imps of Tartarus.\r\nOut of that dream came rescue—the Vigilant, the viceadmiralty\r\ncourt, the streets of Dunedin, and the long voyage\r\nback home to the old house by the Egeberg. He could not tell—\r\nthey would think him mad. He would write of what he knew\r\nbefore death came, but his wife must not guess. Death would be\r\na boon if only it could blot out the memories.\r\nThat was the document I read, and now I have placed it in the\r\ntin box beside the bas-relief and the papers of Professor Angell.\r\nWith it shall go this record of mine—this test of my own sanity,\r\nwherein is pieced together that which I hope may never be\r\npieced together again. I have looked upon all that the universe\r\nhas to hold of horror, and even the skies of spring and the\r\nflowers of summer must ever afterward be poison to me. But I\r\ndo not think my life will be long. As my uncle went, as poor\r\nJohansen went, so I shall go. I know too much, and the cult still\r\nlives.\r\nCthulhu still lives, too, I suppose, again in that chasm of stone\r\nwhich has shielded him since the sun was young. His accursed\r\n\r\ncity is sunken once more, for the Vigilant sailed over the spot\r\nafter the April storm; but his ministers on earth still bellow and\r\nprance and slay around idol-capped monoliths in lonely places.\r\nHe must have been trapped by the sinking whilst within his\r\nblack abyss, or else the world would by now be screaming with\r\nfright and frenzy. Who knows the end? What has risen may sink,\r\nand what has sunk may rise. Loathsomeness waits and dreams\r\nin the deep, and decay spreads over the tottering cities of men.\r\nA time will come—but I must not and cannot think! Let me pray\r\nthat, if I do not survive this manuscript, my executors may put\r\ncaution before audacity and see that it meets no other eye.\r\n", 3, "" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ID", "BookID", "Date", "Rating", "Text", "UserID", "Votes" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 27, 14, 41, 31, 665, DateTimeKind.Local).AddTicks(2986), 3, "Very amusing book", "1", 10 },
                    { 2, 1, new DateTime(2023, 6, 27, 14, 41, 31, 665, DateTimeKind.Local).AddTicks(2999), 4, "Very creative writing", "1", 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "ChapterID", "Date", "Text", "UserID", "Votes" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 27, 14, 41, 31, 665, DateTimeKind.Local).AddTicks(630), "Great chapter, very scary", "1", -1 },
                    { 2, 1, new DateTime(2023, 6, 27, 14, 41, 31, 665, DateTimeKind.Local).AddTicks(643), "Bad Chapter, very scary for me", "1", 3 },
                    { 3, 1, new DateTime(2023, 6, 27, 14, 41, 31, 665, DateTimeKind.Local).AddTicks(646), "Not bad", "1", 5 },
                    { 4, 1, new DateTime(2023, 6, 27, 14, 41, 31, 665, DateTimeKind.Local).AddTicks(648), "Didn't meet my expectations to be honest", "1", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser_UsersId",
                table: "BookUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUser1_OwnerUsersId",
                table: "BookUser1",
                column: "OwnerUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_BookID",
                table: "Chapters",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterUser_UsersId",
                table: "ChapterUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ChapterID",
                table: "Comments",
                column: "ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookID",
                table: "Reviews",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserID",
                table: "Reviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_CommentId",
                table: "UserComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserId",
                table: "UserComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_ReviewId",
                table: "UserReviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_UserId",
                table: "UserReviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookUser");

            migrationBuilder.DropTable(
                name: "BookUser1");

            migrationBuilder.DropTable(
                name: "ChapterUser");

            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "UserReviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
