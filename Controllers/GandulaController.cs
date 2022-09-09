using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CADASTRO_DE_CLUBE_DE_FUTEBOL.Models;
using CADASTRO_DE_CLUBE_DE_FUTEBOL.Repositorio;

namespace CADASTRO_DE_CLUBE_DE_FUTEBOL.Controllers
{
    public class GandulaController : Controller
    {
        // GET: Gandula
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addGandula()
        {
            return View();
        }

        public ActionResult getAllGandulasDetails()
        {
            gandulaRepositorio ganRepo = new gandulaRepositorio();
            ModelState.Clear();

            return View(ganRepo.getAllGandulas());
        }

        [HttpPost]
        public ActionResult addGandula(clsGandula Gandula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gandulaRepositorio gandulaRepo = new gandulaRepositorio();
                    if (gandulaRepo.addGandula(Gandula))
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
        public ActionResult editaGandulaDetails(int id)
        {
            gandulaRepositorio gandulaRepo = new gandulaRepositorio();

            return View(gandulaRepo.getAllGandulas().Find(gandula => gandula.Id == id));
        }

        [HttpPost]
        public ActionResult editaGandulaDetails(clsGandula obj, int id)
        {
            try
            {
                gandulaRepositorio gandulaRepo = new gandulaRepositorio();

                gandulaRepo.updateGandula(obj, id);
                return RedirectToAction("getAllGandulasDetails");
            }
            catch
            {
                ViewBag.Message = "Deu ruim no Editar";
                return View();
            }
        }

        public ActionResult deleteGandula(int id)
        {
            try
            {
                gandulaRepositorio gandulaRepo = new gandulaRepositorio();
                if (gandulaRepo.deleteGandula(id))
                {
                    ViewBag.AlertMessage = "Deletado com sucesso";
                    return View();
                }
                return RedirectToAction("getAllGandulasDetails");
            }
            catch
            {
                ViewBag.AlertMessage = "Deu ruim no deletar";
                return View();
            }
        }
    }
}