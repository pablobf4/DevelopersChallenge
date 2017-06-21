using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.CampeonatoXadrez.ViewModel
{
    public class CampeonatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}