namespace TP1IdS_G15AccesoADatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sessions_UserName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sesiones", name: "User_UserName", newName: "UserName");
            RenameIndex(table: "dbo.Sesiones", name: "IX_User_UserName", newName: "IX_UserName");
            DropColumn("dbo.Sesiones", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sesiones", "UserId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Sesiones", name: "IX_UserName", newName: "IX_User_UserName");
            RenameColumn(table: "dbo.Sesiones", name: "UserName", newName: "User_UserName");
        }
    }
}
