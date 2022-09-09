using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CADASTRO_DE_CLUBE_DE_FUTEBOL.Models;
using CADASTRO_DE_CLUBE_DE_FUTEBOL.Repositorio;

namespace CADASTRO_DE_CLUBE_DE_FUTEBOL.Controllers
{
    public class TecnicoController : Controller
    {
        // GET: Tecnico
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addTecnico()
        {
            return View();
        }

        public ActionResult getAllTecnicoDetails()
        {
            tecnicoRepositorio tecnicoRepo = new tecnicoRepositorio();
            ModelState.Clear();

            return View(tecnicoRepo.getAllTecnicos());
        }

        [HttpPost]
        public ActionResult addTecnico(clsTecnico Tecnico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tecnicoRepositorio tecnicoRepo = new tecnicoRepositorio();
                    if (tecnicoRepo.addTecnico(Tecnico))
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

        public ActionResult editaTecnicoDetails(int id)
        {
            tecnicoRepositorio tecnicoRepo = new tecnicoRepositorio();

            return View(tecnicoRepo.getAllTecnicos().Find(tecnico => tecnico.Id == id));
        }

        [HttpPost]
        public ActionResult editaTecnicoDetails(int id, clsTecnico obj)
        {
            try
            {
                tecnicoRepositorio tecnicoRepo = new tecnicoRepositorio();

                tecnicoRepo.updateTecnico(obj, id);
                return RedirectToAction("getAllTecnicoDetails");
            }
            catch
            {
                ViewBag.Message = "Deu ruim no Editar";
                return View();
            }
        }

        public ActionResult deleteTecnico(int id)
        {
            try
            {
                tecnicoRepositorio tecnicoRepo = new tecnicoRepositorio();
                if (tecnicoRepo.deleteTecnico(id))
                {
                    ViewBag.AlertMessage = "Deletado com sucesso";
                }
                return RedirectToAction("getAllTecnicoDetails");
            }
            catch
            {
                ViewBag.AlertMessage = "Deu ruim no deletar";
                return View();
            }
        }
    }
}