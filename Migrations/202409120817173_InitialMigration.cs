namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        kullaniciAd = c.String(maxLength: 10, unicode: false),
                        sifre = c.String(maxLength: 30, unicode: false),
                        yetki = c.String(maxLength: 1, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Carilers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ad = c.String(nullable: false, maxLength: 30, unicode: false),
                        soyad = c.String(nullable: false, maxLength: 30, unicode: false),
                        sehir = c.String(maxLength: 13, unicode: false),
                        mail = c.String(nullable: false, maxLength: 50, unicode: false),
                        sifre = c.String(maxLength: 20, unicode: false),
                        gorsel = c.String(maxLength: 8000, unicode: false),
                        meslek = c.String(maxLength: 30, unicode: false),
                        telefonNo = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        satisId = c.Int(nullable: false, identity: true),
                        tarih = c.DateTime(nullable: false),
                        adet = c.Int(nullable: false),
                        fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        toplamTutar = c.Decimal(precision: 18, scale: 2),
                        urunId = c.Int(nullable: false),
                        cariId = c.Int(nullable: false),
                        personelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.satisId)
                .ForeignKey("dbo.Carilers", t => t.cariId, cascadeDelete: true)
                .ForeignKey("dbo.Personels", t => t.personelId, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.urunId, cascadeDelete: true)
                .Index(t => t.urunId)
                .Index(t => t.cariId)
                .Index(t => t.personelId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ad = c.String(maxLength: 30, unicode: false),
                        soyad = c.String(maxLength: 30, unicode: false),
                        gorsel = c.String(nullable: false, maxLength: 250, unicode: false),
                        departmanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departmen", t => t.departmanId, cascadeDelete: true)
                .Index(t => t.departmanId);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ad = c.String(nullable: false, maxLength: 30, unicode: false),
                        durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        kargoDetayId = c.Int(nullable: false, identity: true),
                        aciklama = c.String(maxLength: 300, unicode: false),
                        takipKodu = c.String(maxLength: 10, unicode: false),
                        alici = c.String(maxLength: 25, unicode: false),
                        tarih = c.DateTime(nullable: false),
                        personel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.kargoDetayId)
                .ForeignKey("dbo.Personels", t => t.personel, cascadeDelete: true)
                .Index(t => t.personel);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ad = c.String(nullable: false, maxLength: 30, unicode: false),
                        marka = c.String(nullable: false, maxLength: 30, unicode: false),
                        stok = c.Short(nullable: false),
                        alisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        satisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        durum = c.Boolean(nullable: false),
                        gorsel = c.String(maxLength: 250, unicode: false),
                        kategoriid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Kategoris", t => t.kategoriid, cascadeDelete: true)
                .Index(t => t.kategoriid);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ad = c.String(nullable: false, maxLength: 30, unicode: false),
                        durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Detays",
                c => new
                    {
                        detayId = c.Int(nullable: false, identity: true),
                        urunAd = c.String(nullable: false, maxLength: 30, unicode: false),
                        urunBilgi = c.String(nullable: false, maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.detayId);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        faturaKalemid = c.Int(nullable: false, identity: true),
                        aciklama = c.String(nullable: false, maxLength: 200, unicode: false),
                        miktar = c.Int(nullable: false),
                        birimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        faturaId = c.Int(nullable: false),
                        Faturalar_id = c.Int(),
                    })
                .PrimaryKey(t => t.faturaKalemid)
                .ForeignKey("dbo.Faturalars", t => t.Faturalar_id)
                .Index(t => t.Faturalar_id);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        seriNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        sıraNo = c.String(nullable: false, maxLength: 6, unicode: false),
                        tarih = c.DateTime(nullable: false),
                        vergiDairesi = c.String(nullable: false, maxLength: 60, unicode: false),
                        saat = c.String(maxLength: 50, fixedLength: true, unicode: false),
                        teslimEden = c.String(maxLength: 30, unicode: false),
                        teslimAlan = c.String(maxLength: 30, unicode: false),
                        toplam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        giderId = c.Int(nullable: false, identity: true),
                        aciklama = c.String(maxLength: 100, unicode: false),
                        tarih = c.DateTime(nullable: false),
                        tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.giderId);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        kargoTakipId = c.Int(nullable: false, identity: true),
                        takipKodu = c.String(nullable: false, maxLength: 10, unicode: false),
                        aciklama = c.String(maxLength: 100, unicode: false),
                        tarihZaman = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.kargoTakipId);
            
            CreateTable(
                "dbo.mesajlars",
                c => new
                    {
                        mesajId = c.Int(nullable: false, identity: true),
                        gonderici = c.String(nullable: false, maxLength: 50, unicode: false),
                        alici = c.String(nullable: false, maxLength: 50, unicode: false),
                        konu = c.String(maxLength: 50, unicode: false),
                        icerik = c.String(maxLength: 2000, unicode: false),
                        tarih = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        durum = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.mesajId);
            
            CreateTable(
                "dbo.Yapilacaks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        baslik = c.String(maxLength: 100, unicode: false),
                        durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "Faturalar_id", "dbo.Faturalars");
            DropForeignKey("dbo.SatisHarekets", "urunId", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "kategoriid", "dbo.Kategoris");
            DropForeignKey("dbo.SatisHarekets", "personelId", "dbo.Personels");
            DropForeignKey("dbo.KargoDetays", "personel", "dbo.Personels");
            DropForeignKey("dbo.Personels", "departmanId", "dbo.Departmen");
            DropForeignKey("dbo.SatisHarekets", "cariId", "dbo.Carilers");
            DropIndex("dbo.FaturaKalems", new[] { "Faturalar_id" });
            DropIndex("dbo.Uruns", new[] { "kategoriid" });
            DropIndex("dbo.KargoDetays", new[] { "personel" });
            DropIndex("dbo.Personels", new[] { "departmanId" });
            DropIndex("dbo.SatisHarekets", new[] { "personelId" });
            DropIndex("dbo.SatisHarekets", new[] { "cariId" });
            DropIndex("dbo.SatisHarekets", new[] { "urunId" });
            DropTable("dbo.Yapilacaks");
            DropTable("dbo.mesajlars");
            DropTable("dbo.KargoTakips");
            DropTable("dbo.Giders");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Detays");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.KargoDetays");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Carilers");
            DropTable("dbo.Admins");
        }
    }
}
