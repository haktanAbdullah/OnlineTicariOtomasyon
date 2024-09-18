namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class degisiklik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FaturaKalems", "Faturalar_id", "dbo.Faturalars");
            DropIndex("dbo.FaturaKalems", new[] { "Faturalar_id" });
            DropColumn("dbo.FaturaKalems", "faturaId");
            RenameColumn(table: "dbo.FaturaKalems", name: "Faturalar_id", newName: "faturaId");
            AlterColumn("dbo.FaturaKalems", "faturaId", c => c.Int(nullable: false));
            CreateIndex("dbo.FaturaKalems", "faturaId");
            AddForeignKey("dbo.FaturaKalems", "faturaId", "dbo.Faturalars", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "faturaId", "dbo.Faturalars");
            DropIndex("dbo.FaturaKalems", new[] { "faturaId" });
            AlterColumn("dbo.FaturaKalems", "faturaId", c => c.Int());
            RenameColumn(table: "dbo.FaturaKalems", name: "faturaId", newName: "Faturalar_id");
            AddColumn("dbo.FaturaKalems", "faturaId", c => c.Int(nullable: false));
            CreateIndex("dbo.FaturaKalems", "Faturalar_id");
            AddForeignKey("dbo.FaturaKalems", "Faturalar_id", "dbo.Faturalars", "id");
        }
    }
}
