using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.CampeonatoXadrez.Dominio.Entidades
{
    public class Campeonato
    {
        [Key]
        public int CampeonatoId { get; set; }
        public string Nome { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

    }
}
