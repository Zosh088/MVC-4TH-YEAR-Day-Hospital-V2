using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surgeon__Day_Hospital_.Migrations
{
    /// <inheritdoc />
    public partial class Rebirth03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Active_Ingredients",
                columns: table => new
                {
                    ActiveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Active_Ingredients", x => x.ActiveID);
                });

            migrationBuilder.CreateTable(
                name: "Address_Book",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuburbID = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address_Book", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Admin_Records",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personnel_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin_Records", x => x.Admin_ID);
                });

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
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HCRNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Bed_Records",
                columns: table => new
                {
                    BedRecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bed_ID = table.Column<int>(type: "int", nullable: false),
                    Day_of_Use = table.Column<DateOnly>(type: "date", nullable: false),
                    Patient_ID_no = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed_Records", x => x.BedRecordID);
                });

            migrationBuilder.CreateTable(
                name: "Chronic_Conditions",
                columns: table => new
                {
                    ConditionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICD10Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_ID_no = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chronic_Conditions", x => x.ConditionID);
                });

            migrationBuilder.CreateTable(
                name: "Chronic_Medication__Active_Ingredients",
                columns: table => new
                {
                    Chronic_ActiveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChronicID = table.Column<int>(type: "int", nullable: false),
                    ActiveID = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chronic_Medication__Active_Ingredients", x => x.Chronic_ActiveID);
                });

            migrationBuilder.CreateTable(
                name: "Chronic_Medications",
                columns: table => new
                {
                    Chronic_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<int>(type: "int", nullable: false),
                    DosageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chronic_Medications", x => x.Chronic_ID);
                });

            migrationBuilder.CreateTable(
                name: "City_Records",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City_Records", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Contra_Indications",
                columns: table => new
                {
                    ContraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contra_Indications", x => x.ContraID);
                });

            migrationBuilder.CreateTable(
                name: "Dosage_Forms",
                columns: table => new
                {
                    DosageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosage_Forms", x => x.DosageID);
                });

            migrationBuilder.CreateTable(
                name: "Hospital_Records",
                columns: table => new
                {
                    HospitalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PracticeManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PracticeManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital_Records", x => x.HospitalID);
                });

            migrationBuilder.CreateTable(
                name: "Medication_Interactions",
                columns: table => new
                {
                    InteractionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveID1 = table.Column<int>(type: "int", nullable: false),
                    ActiveID2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication_Interactions", x => x.InteractionID);
                });

            migrationBuilder.CreateTable(
                name: "Nurse_Records",
                columns: table => new
                {
                    NurseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse_Records", x => x.NurseID);
                });

            migrationBuilder.CreateTable(
                name: "nurseRecords",
                columns: table => new
                {
                    PatientRecordID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surgeon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nurseRecords", x => x.PatientRecordID);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Vitals",
                columns: table => new
                {
                    pVitalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VitalID = table.Column<int>(type: "int", nullable: false),
                    Patient_ID_no = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Vitals", x => x.pVitalID);
                });

            migrationBuilder.CreateTable(
                name: "Personnel_Records",
                columns: table => new
                {
                    PersonnelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HCRNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnel_Records", x => x.PersonnelID);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacist_Records",
                columns: table => new
                {
                    PharmacistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacist_Records", x => x.PharmacistID);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy_Medication",
                columns: table => new
                {
                    PharmacyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<int>(type: "int", nullable: false),
                    DosageID = table.Column<int>(type: "int", nullable: false),
                    ReOrder = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy_Medication", x => x.PharmacyID);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy_Medication__Active_Ingredients",
                columns: table => new
                {
                    Pharmacy_ActiveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyID = table.Column<int>(type: "int", nullable: false),
                    ActiveID = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy_Medication__Active_Ingredients", x => x.Pharmacy_ActiveID);
                });

            migrationBuilder.CreateTable(
                name: "Province_Records",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province_Records", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "Suburb_Records",
                columns: table => new
                {
                    SuburbID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuburbName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburb_Records", x => x.SuburbID);
                });

            migrationBuilder.CreateTable(
                name: "Theatre_Records",
                columns: table => new
                {
                    TheatreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheatreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theatre_Records", x => x.TheatreID);
                });

            migrationBuilder.CreateTable(
                name: "Treatment_Codes",
                columns: table => new
                {
                    TreatmentCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICD10Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment_Codes", x => x.TreatmentCodeID);
                });

            migrationBuilder.CreateTable(
                name: "Vital_Types",
                columns: table => new
                {
                    VitalTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LowLimit = table.Column<double>(type: "float", nullable: false),
                    HighLimit = table.Column<double>(type: "float", nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LowLimit2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighLimit2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vital_Types", x => x.VitalTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Ward_Records",
                columns: table => new
                {
                    WardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward_Records", x => x.WardID);
                });

            migrationBuilder.CreateTable(
                name: "Allergy_Records",
                columns: table => new
                {
                    AllergyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_ID_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy_Records", x => x.AllergyID);
                    table.ForeignKey(
                        name: "FK_Allergy_Records_Active_Ingredients_ActiveID",
                        column: x => x.ActiveID,
                        principalTable: "Active_Ingredients",
                        principalColumn: "ActiveID",
                        onDelete: ReferentialAction.Cascade);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Chronic_Patients",
                columns: table => new
                {
                    ChronicPatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_ID_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chronic_Patients", x => x.ChronicPatientID);
                    table.ForeignKey(
                        name: "FK_Chronic_Patients_Chronic_Conditions_ConditionID",
                        column: x => x.ConditionID,
                        principalTable: "Chronic_Conditions",
                        principalColumn: "ConditionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedOrder_Records",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyID = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PackageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PharmacistID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOrdered = table.Column<DateOnly>(type: "date", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedOrder_Records", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_MedOrder_Records_AspNetUsers_PharmacistID",
                        column: x => x.PharmacistID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedOrder_Records_Pharmacy_Medication_PharmacyID",
                        column: x => x.PharmacyID,
                        principalTable: "Pharmacy_Medication",
                        principalColumn: "PharmacyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Script_Lines",
                columns: table => new
                {
                    ScriptLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScriptID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Script_Lines", x => x.ScriptLineID);
                    table.ForeignKey(
                        name: "FK_Script_Lines_Pharmacy_Medication_PharmacyID",
                        column: x => x.PharmacyID,
                        principalTable: "Pharmacy_Medication",
                        principalColumn: "PharmacyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Records",
                columns: table => new
                {
                    Patient_ID_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Patient_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuburbID = table.Column<int>(type: "int", nullable: true),
                    Patient_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_DOB = table.Column<DateOnly>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Records", x => x.Patient_ID_no);
                    table.ForeignKey(
                        name: "FK_Patient_Records_Suburb_Records_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburb_Records",
                        principalColumn: "SuburbID");
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardID = table.Column<int>(type: "int", nullable: false),
                    BedNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedID);
                    table.ForeignKey(
                        name: "FK_Beds_Ward_Records_WardID",
                        column: x => x.WardID,
                        principalTable: "Ward_Records",
                        principalColumn: "WardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discharge_Records",
                columns: table => new
                {
                    DischargeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Patient_ID_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NurseID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discharge_Records", x => x.DischargeID);
                    table.ForeignKey(
                        name: "FK_Discharge_Records_AspNetUsers_NurseID",
                        column: x => x.NurseID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discharge_Records_Patient_Records_Patient_ID_no",
                        column: x => x.Patient_ID_no,
                        principalTable: "Patient_Records",
                        principalColumn: "Patient_ID_no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Script_Records",
                columns: table => new
                {
                    ScriptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurgeonID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PharmacistID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateIssued = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeIssued = table.Column<TimeSpan>(type: "time", nullable: false),
                    Patient_ID_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Urgent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Script_Records", x => x.ScriptID);
                    table.ForeignKey(
                        name: "FK_Script_Records_AspNetUsers_SurgeonID",
                        column: x => x.SurgeonID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Script_Records_Patient_Records_Patient_ID_no",
                        column: x => x.Patient_ID_no,
                        principalTable: "Patient_Records",
                        principalColumn: "Patient_ID_no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Theatre_Bookings",
                columns: table => new
                {
                    TheatreBookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurgeonID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheatreID = table.Column<int>(type: "int", nullable: false),
                    Patient_ID_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theatre_Bookings", x => x.TheatreBookingID);
                    table.ForeignKey(
                        name: "FK_Theatre_Bookings_AspNetUsers_SurgeonID",
                        column: x => x.SurgeonID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Theatre_Bookings_Patient_Records_Patient_ID_no",
                        column: x => x.Patient_ID_no,
                        principalTable: "Patient_Records",
                        principalColumn: "Patient_ID_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Theatre_Bookings_Theatre_Records_TheatreID",
                        column: x => x.TheatreID,
                        principalTable: "Theatre_Records",
                        principalColumn: "TheatreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vital_Records",
                columns: table => new
                {
                    VitalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Value2 = table.Column<double>(type: "float", nullable: true),
                    Patient_ID_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Vital = table.Column<int>(type: "int", nullable: false),
                    VitalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VitalTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vital_Records", x => x.VitalID);
                    table.ForeignKey(
                        name: "FK_Vital_Records_Patient_Records_Patient_ID_no",
                        column: x => x.Patient_ID_no,
                        principalTable: "Patient_Records",
                        principalColumn: "Patient_ID_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vital_Records_Vital_Types_Vital",
                        column: x => x.Vital,
                        principalTable: "Vital_Types",
                        principalColumn: "VitalTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
     name: "Admission_Records",
     columns: table => new
     {
         Admission_ID = table.Column<int>(type: "int", nullable: false)
             .Annotation("SqlServer:Identity", "1, 1"),
         Patient_ID_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
         AdmissionDate = table.Column<DateTime>(type: "date", nullable: false),
         AdmissionTime = table.Column<DateTime>(type: "time", nullable: false),
         BedID = table.Column<int>(type: "int", nullable: false),
         BookingID = table.Column<int>(type: "int", nullable: false),
         Nurse_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
     },
     constraints: table =>
     {
         table.PrimaryKey("PK_Admission_Records", x => x.Admission_ID);

         table.ForeignKey(
             name: "FK_Admission_Records_AspNetUsers_Nurse_ID",
             column: x => x.Nurse_ID,
             principalTable: "AspNetUsers",
             principalColumn: "Id",
             onDelete: ReferentialAction.Cascade);

         table.ForeignKey(
             name: "FK_Admission_Records_Beds_BedID",
             column: x => x.BedID,
             principalTable: "Beds",
             principalColumn: "BedID",
             onDelete: ReferentialAction.Cascade);

         table.ForeignKey(
             name: "FK_Admission_Records_Patient_Records_Patient_ID_no",
             column: x => x.Patient_ID_no,
             principalTable: "Patient_Records",
             principalColumn: "Patient_ID_no",
             onDelete: ReferentialAction.Cascade);

         // Modify the cascade rule here
         table.ForeignKey(
             name: "FK_Admission_Records_Theatre_Bookings_BookingID",
             column: x => x.BookingID,
             principalTable: "Theatre_Bookings",
             principalColumn: "TheatreBookingID",
             onDelete: ReferentialAction.Restrict);  // Change Cascade to Restrict (or NoAction)
     });


            migrationBuilder.CreateTable(
                name: "Booking_Codes",
                columns: table => new
                {
                    Booking_Code_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentCodeID = table.Column<int>(type: "int", nullable: false),
                    TheatreBookingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Codes", x => x.Booking_Code_ID);
                    table.ForeignKey(
                        name: "FK_Booking_Codes_Theatre_Bookings_TheatreBookingID",
                        column: x => x.TheatreBookingID,
                        principalTable: "Theatre_Bookings",
                        principalColumn: "TheatreBookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Codes_Treatment_Codes_TreatmentCodeID",
                        column: x => x.TreatmentCodeID,
                        principalTable: "Treatment_Codes",
                        principalColumn: "TreatmentCodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Records_BedID",
                table: "Admission_Records",
                column: "BedID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Records_BookingID",
                table: "Admission_Records",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Records_Nurse_ID",
                table: "Admission_Records",
                column: "Nurse_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Records_Patient_ID_no",
                table: "Admission_Records",
                column: "Patient_ID_no");

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_Records_ActiveID",
                table: "Allergy_Records",
                column: "ActiveID");

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
                name: "IX_Beds_WardID",
                table: "Beds",
                column: "WardID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Codes_TheatreBookingID",
                table: "Booking_Codes",
                column: "TheatreBookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Codes_TreatmentCodeID",
                table: "Booking_Codes",
                column: "TreatmentCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Chronic_Patients_ConditionID",
                table: "Chronic_Patients",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_Discharge_Records_NurseID",
                table: "Discharge_Records",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Discharge_Records_Patient_ID_no",
                table: "Discharge_Records",
                column: "Patient_ID_no");

            migrationBuilder.CreateIndex(
                name: "IX_MedOrder_Records_PharmacistID",
                table: "MedOrder_Records",
                column: "PharmacistID");

            migrationBuilder.CreateIndex(
                name: "IX_MedOrder_Records_PharmacyID",
                table: "MedOrder_Records",
                column: "PharmacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Records_SuburbID",
                table: "Patient_Records",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_Script_Lines_PharmacyID",
                table: "Script_Lines",
                column: "PharmacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Script_Records_Patient_ID_no",
                table: "Script_Records",
                column: "Patient_ID_no");

            migrationBuilder.CreateIndex(
                name: "IX_Script_Records_SurgeonID",
                table: "Script_Records",
                column: "SurgeonID");

            migrationBuilder.CreateIndex(
                name: "IX_Theatre_Bookings_Patient_ID_no",
                table: "Theatre_Bookings",
                column: "Patient_ID_no");

            migrationBuilder.CreateIndex(
                name: "IX_Theatre_Bookings_SurgeonID",
                table: "Theatre_Bookings",
                column: "SurgeonID");

            migrationBuilder.CreateIndex(
                name: "IX_Theatre_Bookings_TheatreID",
                table: "Theatre_Bookings",
                column: "TheatreID");

            migrationBuilder.CreateIndex(
                name: "IX_Vital_Records_Patient_ID_no",
                table: "Vital_Records",
                column: "Patient_ID_no");

            migrationBuilder.CreateIndex(
                name: "IX_Vital_Records_Vital",
                table: "Vital_Records",
                column: "Vital");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address_Book");

            migrationBuilder.DropTable(
                name: "Admin_Records");

            migrationBuilder.DropTable(
                name: "Admission_Records");

            migrationBuilder.DropTable(
                name: "Allergy_Records");

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
                name: "Bed_Records");

            migrationBuilder.DropTable(
                name: "Booking_Codes");

            migrationBuilder.DropTable(
                name: "Chronic_Medication__Active_Ingredients");

            migrationBuilder.DropTable(
                name: "Chronic_Medications");

            migrationBuilder.DropTable(
                name: "Chronic_Patients");

            migrationBuilder.DropTable(
                name: "City_Records");

            migrationBuilder.DropTable(
                name: "Contra_Indications");

            migrationBuilder.DropTable(
                name: "Discharge_Records");

            migrationBuilder.DropTable(
                name: "Dosage_Forms");

            migrationBuilder.DropTable(
                name: "Hospital_Records");

            migrationBuilder.DropTable(
                name: "Medication_Interactions");

            migrationBuilder.DropTable(
                name: "MedOrder_Records");

            migrationBuilder.DropTable(
                name: "Nurse_Records");

            migrationBuilder.DropTable(
                name: "nurseRecords");

            migrationBuilder.DropTable(
                name: "Patient_Vitals");

            migrationBuilder.DropTable(
                name: "Personnel_Records");

            migrationBuilder.DropTable(
                name: "Pharmacist_Records");

            migrationBuilder.DropTable(
                name: "Pharmacy_Medication__Active_Ingredients");

            migrationBuilder.DropTable(
                name: "Province_Records");

            migrationBuilder.DropTable(
                name: "Script_Lines");

            migrationBuilder.DropTable(
                name: "Script_Records");

            migrationBuilder.DropTable(
                name: "Vital_Records");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Active_Ingredients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Theatre_Bookings");

            migrationBuilder.DropTable(
                name: "Treatment_Codes");

            migrationBuilder.DropTable(
                name: "Chronic_Conditions");

            migrationBuilder.DropTable(
                name: "Pharmacy_Medication");

            migrationBuilder.DropTable(
                name: "Vital_Types");

            migrationBuilder.DropTable(
                name: "Ward_Records");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Patient_Records");

            migrationBuilder.DropTable(
                name: "Theatre_Records");

            migrationBuilder.DropTable(
                name: "Suburb_Records");
        }
    }
}
