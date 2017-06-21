namespace PA.CampeonatoXadrez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criar_Banco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Partidas", "CampeonatoId", "dbo.Jogadors");
            DropIndex("dbo.Partidas", new[] { "CampeonatoId" });
            CreateIndex("dbo.Partidas", "CampeonatoId");
            AddForeignKey("dbo.Partidas", "CampeonatoId", "dbo.Campeonatoes", "CampeonatoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partidas", "CampeonatoId", "dbo.Campeonatoes");
            DropIndex("dbo.Partidas", new[] { "CampeonatoId" });
            CreateIndex("dbo.Partidas", "CampeonatoId");
            AddForeignKey("dbo.Partidas", "CampeonatoId", "dbo.Jogadors", "JogadorId");
        }
    }
}
