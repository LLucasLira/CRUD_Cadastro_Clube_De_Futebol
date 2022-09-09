using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CADASTRO_DE_CLUBE_DE_FUTEBOL.Models;
using CADASTRO_DE_CLUBE_DE_FUTEBOL.Repositorio;

namespace CADASTRO_DE_CLUBE_DE_FUTEBOL.Controllers
{
    public class JogadorController : Controller
    {
        // GET: Jogador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addJogador()
        {
            return View();
        }

        public ActionResult getAllJogadorDetails()
        {
            jogadorRepositorio jogadorRepo = new jogadorRepositorio();
            ModelState.Clear();

            return View(jogadorRepo.getAllJogadores());
        }

        [HttpPost]
        public ActionResult addJogador(clsJogador jogador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    jogadorRepositorio jogadorRepo = new jogadorRepositorio();
                    if (jogadorRepo.addJogador(jogador))
                    {
                        ViewBag.Message = "Cadastro com sucesso!";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro em: " + ex.Message);
                return View();
            }
        }

        public ActionResult editaJogadorDetails(int id)
        {
            jogadorRepositorio jogadorRepo = new jogadorRepositorio();

            return View(jogadorRepo.getAllJogadores().Find(jogador => jogador.Id == id));
        }

        [HttpPost]
        public ActionResult editaJogadorDetails(int id, clsJogador obj)
        {
            try
            {
                jogadorRepositorio jogadorRepo = new jogadorRepositorio();

                jogadorRepo.updateJogador(obj, id);
                return RedirectToAction("getAllJogadorDetails");
            }
            catch
            {
                ViewBag.Message = "Deu ruim no Editar";
                return View();
            }
        }
        public ActionResult deleteJogador(int Id)
        {
            try
            {
                jogadorRepositorio jogadrRepo = new jogadorRepositorio();
                if (jogadrRepo.deleteJogador(Id))
                {
                    ViewBag.AlertMessage = "Deletado com sucesso";
                }
                return RedirectToAction("getAllJogadorDetails");
            }
            catch
            {
                ViewBag.AlertMessage = "Deu ruim no deletar";
                return View();
            }
        }
    }
}