using PA.CampeonatoXadrez.Dominio.Entidades;
using PA.CampeonatoXadrez.Dominio.Interface.Repository;
using PA.CampeonatoXadrez.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.CampeonatoXadrez.Controllers
{
    public class PartidaController : Controller
    {
        private readonly IJogadorRepository _jogadorRepositorio;
        private readonly IPartidaRepository _partidaRepositorio;
        public PartidaController(IPartidaRepository _partidaRepositorio ,IJogadorRepository _jogadorRepositorio) 
        {
            this._jogadorRepositorio = _jogadorRepositorio;
            this._partidaRepositorio = _partidaRepositorio;
        }
        // GET: Partida
        public ActionResult Index(int Id, string Nome)
        {
            @ViewBag.IdCampeonato = Id;
            var partidaViewModel = new List<PartidaViewModel>();
            var partida = _partidaRepositorio.Get(a=>a.CampeonatoId == Id);
            foreach (var i in partida) 
            {
                var PartidaViewModel = new PartidaViewModel()
                {
                    NomeJogador1 = i.Jogador1.Nome,
                    NomeJogadorVencedor = i.JogadorIdVencedor == null ? "" : i.JogadorVencedor.Nome,
                    NomeJogador2 = i.Jogador2.Nome,
                    JogadorId1 = i.JogadorId1,
                    JogadorId2 = i.JogadorId2,
                    Turno = i.Turno,
                    JogadorIdVencedor = i.JogadorIdVencedor,
                    PartidaId = i.Id
                };
                ViewBag.NomeVencedor = Nome;
                ViewBag.Turno = PartidaViewModel.Turno;
                partidaViewModel.Add(PartidaViewModel);
                //if (PartidaViewModel.Turno == 3 || PartidaViewModel.Turno == 4 || PartidaViewModel.Turno == 5)
                //{
                //    var turno = PartidaViewModel.Turno;
                //    var jogadorVencedor = _partidaRepositorio.First(a => a.Turno == turno && a.CampeonatoId == Id).JogadorVencedor.Nome;
                //        //First(a => a.Turno == 3 || a.Turno == 4 || a.Turno == 5 && a.CampeonatoId == Id ).JogadorVencedor.Nome;
                //    @ViewBag.JogadorVencedor = jogadorVencedor;
                //}
                
            }

            
            var vencedor = TempData["Vencedor"];
            ViewBag.Vencedor = vencedor;
            var erro = TempData["mensagemErro"];
            if (erro != null)
                ModelState.AddModelError("Erro", erro.ToString());

            return View(partidaViewModel);
        }
        

        public ActionResult ProximoTurno (int Id)
        {
            // pega ultimo turno(atual) ,se partida estiver null turno será zero se não tuno  vai receber o valor do turno dauqela partida 
            var ultimaPartida = _partidaRepositorio.Get(a => a.CampeonatoId == Id).OrderByDescending(p => p.Turno).FirstOrDefault();
           
            int turno = 0;
            if (ultimaPartida != null)
            {
                turno = ultimaPartida.Turno;
            }

            List<Jogador> jogadores = null;
            if(turno == 0)
            {
                 jogadores = _jogadorRepositorio.GetTodos();
            }
            else
            {
                var possuiPartidaSemResultado = _partidaRepositorio.Get(a=>a.JogadorIdVencedor == null && a.Turno == turno).Any();

                if (possuiPartidaSemResultado)
                {
                    TempData["mensagemErro"] = "Favor Verifique se alguma partida não possui resultado";
                    return RedirectToAction("Index", new { Id = Id });
                }
                else
                {
                    jogadores = _partidaRepositorio.Get(a => a.Turno == turno && a.CampeonatoId == Id ).Select(a => a.JogadorVencedor).ToList();
                   
                }
            }

            var possilidades = new List<int>() {2, 4, 8, 16, 32};
            var resultado = possilidades.FirstOrDefault(p => p == jogadores.Count);
            if(resultado == 0) {

                var msg = string.Join(",", possilidades);
                TempData["mensagemErro"] = "O sistema não possui quantidade de jogadores suficiente, para se iniciar um campeonato é necessário " + msg;
                return RedirectToAction("Index", new { Id = Id });
            }

            turno++;

            
           
            //combina jogadores criandndo partida
            for(var i= 0 ; i<jogadores.Count;i++)
            {
                var jogador1 = jogadores[i];
                var jogador2 = jogadores[++i];
                var partida = new Partida()
                {
                    JogadorId1 = jogador1.JogadorId,
                    JogadorId2 = jogador2.JogadorId,
                    Turno = turno,
                    CampeonatoId = Id
                };

                _partidaRepositorio.Adicionar(partida);
            }
            
            
            return RedirectToAction("Index", new { Id = Id });
        }

        public ActionResult Vencedor(int Id, int IdPartida)
        {
            var partida = _partidaRepositorio.Find(IdPartida);
            partida.JogadorIdVencedor = Id;
            _partidaRepositorio.Atualizar(partida);

            if (partida.Turno == 3 || partida.Turno == 4 || partida.Turno == 5)
            {
                var turno = partida.Turno;
                var jogadorVencedor = _partidaRepositorio.First(a => a.Turno == turno && a.CampeonatoId == Id).JogadorVencedor.Nome;
                return RedirectToAction("Index", new { Id = partida.CampeonatoId, Nome = jogadorVencedor });
            }
            return RedirectToAction("Index", new { Id = partida.CampeonatoId });
        }
    }
}