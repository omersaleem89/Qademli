using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qademli.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GoalProperty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalProperty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GoalPropertyValue",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalPropertyID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalPropertyValue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GoalPropertyValue_GoalProperty_GoalPropertyID",
                        column: x => x.GoalPropertyID,
                        principalTable: "GoalProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Fee = table.Column<float>(nullable: false),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Goal_Topic_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEducationDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    HighSchoolDegree = table.Column<string>(nullable: true),
                    ILETSorTOEFL = table.Column<int>(nullable: false),
                    MinistryofHigherEducationDoc = table.Column<string>(nullable: true),
                    FinancialSupport = table.Column<string>(nullable: true),
                    UnitsPassed = table.Column<int>(nullable: false),
                    LastDegree = table.Column<string>(nullable: true),
                    SchoolName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducationDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserEducationDetail_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFamilyDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    ParentPassport = table.Column<string>(nullable: true),
                    ParentMobileNo = table.Column<string>(nullable: true),
                    FatherCivilIDFront = table.Column<string>(nullable: true),
                    FatherCivilIDBack = table.Column<string>(nullable: true),
                    MotherCivilIDFront = table.Column<string>(nullable: true),
                    MotherCivilIDBack = table.Column<string>(nullable: true),
                    SpouseCivilIDFront = table.Column<string>(nullable: true),
                    SpouseCivilIDBack = table.Column<string>(nullable: true),
                    SpousePassport = table.Column<string>(nullable: true),
                    FriendInUS = table.Column<bool>(nullable: false),
                    FriendAddress = table.Column<string>(nullable: true),
                    FriendMobileNo = table.Column<string>(nullable: true),
                    FamilyMemberInUS = table.Column<bool>(nullable: false),
                    FamilyMemberFirstName = table.Column<string>(nullable: true),
                    FamilyMemberLastName = table.Column<string>(nullable: true),
                    FamilyMemberRelation = table.Column<string>(nullable: true),
                    FamilyMemberUSCitizen = table.Column<bool>(nullable: false),
                    FamilyMemberImmigrant = table.Column<bool>(nullable: false),
                    FamilyMemberRole = table.Column<string>(nullable: true),
                    CollegeUniversity = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    MonthlySalary = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    CompanionPassport = table.Column<string>(nullable: true),
                    CompanionI20 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFamilyDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserFamilyDetail_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPersonalDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    MaritalStatus = table.Column<string>(nullable: true),
                    CivilIDFront = table.Column<string>(nullable: true),
                    CivilIDBack = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    USAddress = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    FirstLanguage = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    IdentificationDoc = table.Column<string>(nullable: true),
                    IdentificationDocNo = table.Column<string>(nullable: true),
                    TownCity = table.Column<string>(nullable: true),
                    StateCountry = table.Column<string>(nullable: true),
                    ZipPostalCode = table.Column<int>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    OccupationSector = table.Column<string>(nullable: true),
                    OccupationLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPersonalDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPersonalDetail_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVisaDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    MyProperty = table.Column<string>(nullable: true),
                    Passport = table.Column<string>(nullable: true),
                    VisaPermit = table.Column<string>(nullable: true),
                    Recommendations = table.Column<string>(nullable: true),
                    LastVisitToUS = table.Column<DateTime>(nullable: false),
                    DaysSpentInUS = table.Column<int>(nullable: false),
                    CountriesVisted = table.Column<string>(nullable: true),
                    I20Doc = table.Column<string>(nullable: true),
                    Employee = table.Column<bool>(nullable: false),
                    OrganizationName = table.Column<string>(nullable: true),
                    DateTo = table.Column<DateTime>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    TravelDate = table.Column<DateTime>(nullable: false),
                    VisaPermitRejected = table.Column<bool>(nullable: false),
                    ReasonOfRejection = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVisaDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserVisaDetail_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    GoalID = table.Column<int>(nullable: false),
                    TopicID = table.Column<int>(nullable: true),
                    StatusID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Fee = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Application_Goal_GoalID",
                        column: x => x.GoalID,
                        principalTable: "Goal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_ApplicationStatus_StatusID",
                        column: x => x.StatusID,
                        principalTable: "ApplicationStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_Topic_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoalDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalID = table.Column<int>(nullable: false),
                    GoalPropertyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GoalDetail_Goal_GoalID",
                        column: x => x.GoalID,
                        principalTable: "Goal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalDetail_GoalProperty_GoalPropertyID",
                        column: x => x.GoalPropertyID,
                        principalTable: "GoalProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_GoalID",
                table: "Application",
                column: "GoalID");

            migrationBuilder.CreateIndex(
                name: "IX_Application_StatusID",
                table: "Application",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Application_TopicID",
                table: "Application",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_Application_UserID",
                table: "Application",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_TopicID",
                table: "Goal",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_GoalDetail_GoalID",
                table: "GoalDetail",
                column: "GoalID");

            migrationBuilder.CreateIndex(
                name: "IX_GoalDetail_GoalPropertyID",
                table: "GoalDetail",
                column: "GoalPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_GoalPropertyValue_GoalPropertyID",
                table: "GoalPropertyValue",
                column: "GoalPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducationDetail_UserID",
                table: "UserEducationDetail",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFamilyDetail_UserID",
                table: "UserFamilyDetail",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalDetail_UserID",
                table: "UserPersonalDetail",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserVisaDetail_UserID",
                table: "UserVisaDetail",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "GoalDetail");

            migrationBuilder.DropTable(
                name: "GoalPropertyValue");

            migrationBuilder.DropTable(
                name: "UserEducationDetail");

            migrationBuilder.DropTable(
                name: "UserFamilyDetail");

            migrationBuilder.DropTable(
                name: "UserPersonalDetail");

            migrationBuilder.DropTable(
                name: "UserVisaDetail");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "GoalProperty");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
