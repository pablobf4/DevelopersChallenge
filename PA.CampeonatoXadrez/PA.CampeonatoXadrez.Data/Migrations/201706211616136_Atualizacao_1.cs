namespace PA.CampeonatoXadrez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atualizacao_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Partidas", "JogadorIdVencedor", "dbo.Jogadors");
            DropIndex("dbo.Partidas", new[] { "JogadorIdVencedor" });
            AlterColumn("dbo.Partidas", "JogadorIdVencedor", c => c.Int());
            CreateIndex("dbo.Partidas", "JogadorIdVencedor");
            AddForeignKey("dbo.Partidas", "JogadorIdVencedor", "dbo.Jogadors", "JogadorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partidas", "JogadorIdVencedor", "dbo.Jogadors");
            DropIndex("dbo.Partidas", new[] { "JogadorIdVencedor" });
            AlterColumn("dbo.Partidas", "JogadorIdVencedor", c => c.Int(nullable: false));
            CreateIndex("dbo.Partidas", "JogadorIdVencedor");
            AddForeignKey("dbo.Partidas", "JogadorIdVencedor", "dbo.Jogadors", "JogadorId");
        }
    }
}
