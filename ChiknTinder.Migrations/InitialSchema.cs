using FluentMigrator;

namespace ChiknTinder.Migrations
{
    [Migration(0)]
    public class InitialSchema : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Username").AsString(50).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable()
                .WithColumn("HashedPassword").AsString(500).NotNullable()
                .WithColumn("PasswordSalt").AsString(500).NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("CreatedByUserId").AsInt32().ForeignKey("Users", "Id").Nullable()
                .WithColumn("DeactivatedAt").AsDateTime().Nullable()
                .WithColumn("DeactivatedByUserId").AsInt32().ForeignKey("Users", "Id").Nullable();

            Create.Table("Roles")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable();

            Create.Table("UserRoles")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().ForeignKey("Users", "Id").NotNullable()
                .WithColumn("RoleId").AsInt32().ForeignKey("Roles", "Id").NotNullable();

            Create.Table("Chickens")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("Description").AsString(1000).NotNullable()
                .WithColumn("ImageUrl").AsString(500).NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("CreatedByUserId").AsInt32().ForeignKey("Users", "Id").Nullable()
                .WithColumn("DeactivatedAt").AsDateTime().Nullable()
                .WithColumn("DeactivatedByUserId").AsInt32().ForeignKey("Users", "Id").Nullable();

            Create.Table("Doots")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().ForeignKey("Users", "Id").NotNullable()
                .WithColumn("ChickenId").AsInt32().ForeignKey("Chickens", "Id").NotNullable()
                .WithColumn("Doot").AsBoolean().NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("CreatedByUserId").AsInt32().ForeignKey("Users", "Id").Nullable()
                .WithColumn("DeactivatedAt").AsDateTime().Nullable()
                .WithColumn("DeactivatedByUserId").AsInt32().ForeignKey("Users", "Id").Nullable();
        }

        public override void Down()
        {
            Delete.Table("Doots");
            Delete.Table("Chickens");
            Delete.Table("Users");
        }
    }
}