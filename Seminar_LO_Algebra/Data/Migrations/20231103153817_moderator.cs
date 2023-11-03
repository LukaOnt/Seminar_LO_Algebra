using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Seminar_LO_Algebra.Data.Migrations
{
    
    public partial class moderator : Migration
    {
        const string MODERATOR_USER_GUID = "58423d7c-94b5-44af-b54c-049558a37532";
        const string MODERATOR_ROLE_GUID = "b7605cb2-01b5-42fb-ad4c-d72f3eef60c0";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordhasher = hasher.HashPassword(null, "admin123");
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO AspNetUsers (Id, " +
                                                    "UserName, " +
                                                    "NormalizedUserName, " +
                                                    "Email, " +
                                                    "NormalizedEmail, " +
                                                    "EmailConfirmed, " +
                                                    "PasswordHash, " +
                                                    "SecurityStamp, " +
                                                    "PhoneNumber, " +
                                                    "PhoneNumberConfirmed, " +
                                                    "TwoFactorEnabled, " +
                                                    "LockoutEnabled, " +
                                                    "AccessFailedCount, " +
                                                    "Address, " +
                                                    "City, " +
                                                    "Country, " +
                                                    "FirstName, " +
                                                    "LastName, " +
                                                    "PostalCode) ");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{MODERATOR_USER_GUID}',");
            sb.AppendLine($"'mod@admin.com',");
            sb.AppendLine($"'MOD@ADMIN.COM',");
            sb.AppendLine($"'mod@admin.com',");
            sb.AppendLine($"'MOD@ADMIN.COM',");
            sb.AppendLine($"0,");
            sb.AppendLine($"'{passwordhasher}',");
            sb.AppendLine($"'Moderator',");
            sb.AppendLine($"'+385981234567',");
            sb.AppendLine($"1,");
            sb.AppendLine($"0,");
            sb.AppendLine($"0,");
            sb.AppendLine($"0,");
            sb.AppendLine($"'Zagrebacka 140',");
            sb.AppendLine($"'Zagreb',");
            sb.AppendLine($"'Hrvatska',");
            sb.AppendLine($"'Maja',");
            sb.AppendLine($"'Ontl',");
            sb.AppendLine($"'44320'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{MODERATOR_ROLE_GUID}', 'moderator', 'MODERATOR')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{MODERATOR_USER_GUID}', '{MODERATOR_ROLE_GUID}')");

        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId='{MODERATOR_USER_GUID}' AND RoleId='{MODERATOR_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id='{MODERATOR_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id='{MODERATOR_USER_GUID}'");
        }
    }
}
