using PA.CampeonatoXadrez.Dominio.Entidades;
using PA.CampeonatoXadrez.Dominio.Interface.Repository;
using PA.CampeonatoXadrez.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.CampeonatoXadrez.Controllers
{
    public class CampeonatoController : Controller
    {
       private readonly ICampeonatoRepository _campeonatoRepositorio;

        public CampeonatoController( ICampeonatoRepository _campeonatoRepositorio)
       {
           this._campeonatoRepositorio = _campeonatoRepositorio;
       }
        // GET: Campeonato
        public ActionResult Index()
        {
            var retorno = _campeonatoRepositorio.GetTodos();
            var lista = new List<CampeonatoViewModel>();
            foreach (var i in retorno)
            {
                var campeonatoViewModel = new CampeonatoViewModel() 
                {
                    Id = i.CampeonatoId,
                    Nome = i.Nome,
                    inicio = i.Inicio,
                    Fim = i.Fim
                };
                lista.Add(campeonatoViewModel);
            }
            return View(lista);
        } 
        public ActionResult Criar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Criar(Campeonato campeonato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _campeonatoRepositorio.Adicionar(campeonato);
                    return RedirectToAction("Index", "Campeonato");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente novamente....");
            }
            return View(campeonato);
        }
       
    }
}