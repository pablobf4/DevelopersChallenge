using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.Dominio.Entidades
{
   public  class Partida
    {
       [Key]
        public int Id { get; set; }
        public int JogadorId1 { get; set; }
        [ForeignKey("JogadorId1")]
        public virtual Jogador Jogador1 { get; set; }
        public int JogadorId2 { get; set; }
        [ForeignKey("JogadorId2")]
        public virtual Jogador Jogador2 { get; set; }
        public int? JogadorIdVencedor { get; set; }
        [ForeignKey("JogadorIdVencedor")]
        public virtual  Jogador JogadorVencedor { get; set; }
        public int CampeonatoId { get; set; }
        [ForeignKey("CampeonatoId")]
        public virtual Campeonato Campeonato { get; set; }
        public int Turno { get; set; }

    }
}


