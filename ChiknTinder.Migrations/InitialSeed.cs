using ChiknTinder.Services;
using FluentMigrator;
using System.Security.Cryptography;

namespace ChiknTinder.Migrations
{
    [Migration(1)]
    public class InitialSeed : Migration
    {
        public override void Up()
        {
            // Insert roles.
            Execute.Sql("INSERT INTO Roles (Name) VALUES ('Admin');");
            Execute.Sql("INSERT INTO Roles (Name) VALUES ('Farmer');");
            Execute.Sql("INSERT INTO Roles (Name) VALUES ('Chicken');");

            // Insert initial admin user with hashed password and salt.
            var cryptoService = new CryptoService();
            var salt = cryptoService.GenerateSalt();
            var hash = cryptoService.HashPassword("Password1", salt);
            Execute.Sql($"INSERT INTO Users (Username, Email, HashedPassword, PasswordSalt, CreatedAt) VALUES ('admin', 'admin@example.com', '{hash}', '{salt}', GETDATE());");

            // Use SQL to retrieve IDs and insert the Admin user role.
            Execute.Sql("INSERT INTO UserRoles (UserId, RoleId) VALUES ((SELECT Id FROM Users WHERE Username = 'admin'), (SELECT Id FROM Roles WHERE Name = 'Admin'));");
        }

        public override void Down()
        {
            // Here you should implement steps to revert what you have done in the Up method if required
            Execute.Sql("DELETE FROM UserRoles;");
            Execute.Sql("DELETE FROM Users;");
            Execute.Sql("DELETE FROM Roles;");
        }
    }
}