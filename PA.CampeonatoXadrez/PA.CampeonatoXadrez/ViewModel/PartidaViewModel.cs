using PA.CampeonatoXadrez.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.CampeonatoXadrez.ViewModel
{
    public class PartidaViewModel
    {
      
        public int PartidaId { get; set; }
        public int JogadorId1 { get; set; }
        public int JogadorId2 { get; set; }
        public int? JogadorIdVencedor { get; set; }
        public int CampeonatoId { get; set; }
        public string Turno { get; set; }

        public string NomeJogador1 { get; set; }
        public string NomeJogador2 { get; set; }
        public string NomeJogadorVencedor { get; set; }
    }
}