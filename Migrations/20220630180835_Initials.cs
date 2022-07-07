using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prayaas_Website.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accountStatus",
                columns: table => new
                {
                    accountStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountStatus", x => x.accountStatusID);
                });

            migrationBuilder.CreateTable(
                name: "bloodGroups",
                columns: table => new
                {
                    BloodGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroup = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloodGroups", x => x.BloodGroupID);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "institutionType",
                columns: table => new
                {
                    InstitutionTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituitonType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionType", x => x.InstitutionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "requestType",
                columns: table => new
                {
                    RequestTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestType", x => x.RequestTypeID);
                });

            migrationBuilder.CreateTable(
                name: "userType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "request",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "date", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTypeID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    RequestTypeID = table.Column<int>(type: "int", nullable: true),
                    BloodGroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_request_bloodGroups_BloodGroupID",
                        column: x => x.BloodGroupID,
                        principalTable: "bloodGroups",
                        principalColumn: "BloodGroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_request_city_CityID",
                        column: x => x.CityID,
                        principalTable: "city",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_request_requestType_RequestTypeID",
                        column: x => x.RequestTypeID,
                        principalTable: "requestType",
                        principalColumn: "RequestTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_request_userType_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "userType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountStatusID = table.Column<int>(type: "int", nullable: false),
                    UserTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_user_accountStatus_AccountStatusID",
                        column: x => x.AccountStatusID,
                        principalTable: "accountStatus",
                        principalColumn: "accountStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_userType_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "userType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "donor",
                columns: table => new
                {
                    DonorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BloodGroupID = table.Column<int>(type: "int", nullable: false),
                    LastDonationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Adhaar = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    GenderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donor", x => x.DonorID);
                    table.ForeignKey(
                        name: "FK_donor_bloodGroups_BloodGroupID",
                        column: x => x.BloodGroupID,
                        principalTable: "bloodGroups",
                        principalColumn: "BloodGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donor_city_CityID",
                        column: x => x.CityID,
                        principalTable: "city",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donor_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donor_user_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "institution",
                columns: table => new
                {
                    InstitutionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InstitutionTypeID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    InstituionTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institution", x => x.InstitutionID);
                    table.ForeignKey(
                        name: "FK_institution_city_CityID",
                        column: x => x.CityID,
                        principalTable: "city",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_institution_institutionType_InstituionTypeID",
                        column: x => x.InstituionTypeID,
                        principalTable: "institutionType",
                        principalColumn: "InstitutionTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_institution_user_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seeker",
                columns: table => new
                {
                    SeekerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Adhaar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "date", nullable: false),
                    BloodGroupID = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seeker", x => x.SeekerID);
                    table.ForeignKey(
                        name: "FK_seeker_bloodGroups_BloodGroupID",
                        column: x => x.BloodGroupID,
                        principalTable: "bloodGroups",
                        principalColumn: "BloodGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seeker_city_CityID",
                        column: x => x.CityID,
                        principalTable: "city",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seeker_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seeker_user_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bloodStock",
                columns: table => new
                {
                    BloodStockID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroupID = table.Column<int>(type: "int", nullable: false),
                    InstitutionID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloodStock", x => x.BloodStockID);
                    table.ForeignKey(
                        name: "FK_bloodStock_bloodGroups_BloodGroupID",
                        column: x => x.BloodGroupID,
                        principalTable: "bloodGroups",
                        principalColumn: "BloodGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bloodStock_institution_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "institution",
                        principalColumn: "InstitutionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "GenderID", "Gender" },
                values: new object[,]
                {
                    { 3, "Others" },
                    { 2, "Female" },
                    { 1, "Male" }
                });

            migrationBuilder.InsertData(
                table: "accountStatus",
                columns: new[] { "accountStatusID", "accountStatus" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approved" },
                    { 3, "Denied" },
                    { 4, "Open" },
                    { 5, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "bloodGroups",
                columns: new[] { "BloodGroupID", "BloodGroup" },
                values: new object[,]
                {
                    { 1, "AB+" },
                    { 2, "B+" },
                    { 3, "O+" },
                    { 4, "A-" },
                    { 5, "B-" },
                    { 6, "A+" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "CityID", "City" },
                values: new object[,]
                {
                    { 7, "Indore" },
                    { 6, "Nagpur" },
                    { 2, "Mumbai" },
                    { 4, "Bhopal" },
                    { 3, "Nashik" },
                    { 1, "Pune" },
                    { 5, "Ahmedabad" }
                });

            migrationBuilder.InsertData(
                table: "requestType",
                columns: new[] { "RequestTypeID", "RequestType" },
                values: new object[,]
                {
                    { 1, "Seeker" },
                    { 2, "Institution" }
                });

            migrationBuilder.InsertData(
                table: "userType",
                columns: new[] { "UserTypeID", "UserType" },
                values: new object[,]
                {
                    { 2, "Seeker" },
                    { 1, "Donor" },
                    { 3, "Institution" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bloodStock_BloodGroupID",
                table: "bloodStock",
                column: "BloodGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_bloodStock_InstitutionID",
                table: "bloodStock",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_donor_BloodGroupID",
                table: "donor",
                column: "BloodGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_donor_CityID",
                table: "donor",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_donor_GenderID",
                table: "donor",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_donor_UserID",
                table: "donor",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_institution_CityID",
                table: "institution",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_institution_InstituionTypeID",
                table: "institution",
                column: "InstituionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_institution_UserID",
                table: "institution",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_request_BloodGroupID",
                table: "request",
                column: "BloodGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_request_CityID",
                table: "request",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_request_RequestTypeID",
                table: "request",
                column: "RequestTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_request_UserTypeID",
                table: "request",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_seeker_BloodGroupID",
                table: "seeker",
                column: "BloodGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_seeker_CityID",
                table: "seeker",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_seeker_GenderID",
                table: "seeker",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_seeker_UserID",
                table: "seeker",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_user_AccountStatusID",
                table: "user",
                column: "AccountStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_user_UserTypeID",
                table: "user",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bloodStock");

            migrationBuilder.DropTable(
                name: "donor");

            migrationBuilder.DropTable(
                name: "request");

            migrationBuilder.DropTable(
                name: "seeker");

            migrationBuilder.DropTable(
                name: "institution");

            migrationBuilder.DropTable(
                name: "requestType");

            migrationBuilder.DropTable(
                name: "bloodGroups");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "institutionType");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "accountStatus");

            migrationBuilder.DropTable(
                name: "userType");
        }
    }
}
