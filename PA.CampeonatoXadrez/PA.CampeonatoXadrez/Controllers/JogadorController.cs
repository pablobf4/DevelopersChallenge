using PA.CampeonatoXadrez.Dominio.Entidades;
using PA.CampeonatoXadrez.Dominio.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PA.CampeonatoXadrez.Controllers
{
    public class JogadorController : Controller
    {
        private readonly IJogadorRepository _jogadorRepositorio;

        public JogadorController(IJogadorRepository _jogadorRepositorio) 
        {
            this._jogadorRepositorio = _jogadorRepositorio;
        }
        // GET: Jogador
        public ActionResult Index()
        {
            var lista = _jogadorRepositorio.GetTodos();
            return View(lista);
        }
        public ActionResult Criar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Criar(Jogador jogador)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _jogadorRepositorio.Adicionar(jogador);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Não foi possível salvar as mudanças. Tente novamente....");
            }
            return View(jogador);
        }

    }
}