using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Seminar_LO_Algebra.Data.Migrations
{
    
    public partial class AdminAccount : Migration
    {
        const string ADMIN_USER_GUID = "0435707f-1700-45fe-868e-a55af9c6db5e";
        const string ADMIN_ROLE_GUID = "aada9ff8-e0d8-4185-adca-7281e94a6c17";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordhasher = hasher.HashPassword(null, "admin123");
            StringBuilder sb= new StringBuilder();

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
            sb.AppendLine($"'{ADMIN_USER_GUID}',");
            sb.AppendLine($"'admin@admin.com',");
            sb.AppendLine($"'ADMIN@ADMIN.COM',");
            sb.AppendLine($"'admin@admin.com',");
            sb.AppendLine($"'ADMIN@ADMIN.COM',");
            sb.AppendLine($"0,");
            sb.AppendLine($"'{passwordhasher}',");
            sb.AppendLine($"'Admin',");
            sb.AppendLine($"'+385981234567',");
            sb.AppendLine($"1,");
            sb.AppendLine($"0,");
            sb.AppendLine($"0,");
            sb.AppendLine($"0,");
            sb.AppendLine($"'Zagrebacka 140',");
            sb.AppendLine($"'Zagreb',");
            sb.AppendLine($"'Hrvatska',");
            sb.AppendLine($"'Luka',");
            sb.AppendLine($"'Ontl',");
            sb.AppendLine($"'44320'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{ADMIN_ROLE_GUID}', 'Admin', 'ADMIN')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{ADMIN_USER_GUID}', '{ADMIN_ROLE_GUID}')");

        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId='{ADMIN_USER_GUID}' AND RoleId='{ADMIN_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id='{ADMIN_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id='{ADMIN_USER_GUID}'");

        }
    }
}
