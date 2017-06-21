using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.Dominio.Entidades
{
    public class Jogador
    {
        [Key]
        public int JogadorId { get; set; }
        public string Nome { get; set; }

        public bool Status { get; set; }
    }
}
