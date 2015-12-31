using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using CadeMeuMedico.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CadeMeuMedico.Controllers
{
    public class CidadesController : Controller
    {
        private CadeMeuMedicoBDContext db = new CadeMeuMedicoBDContext();

        // GET: /Cidades/
        public IActionResult Index()
        {
            var cidades = db.Cidades.ToList();
            return View(cidades);
        }

        //GET /Cidades/Adicionar
        public IActionResult Adicionar()
        {
            return View();
        }

        //POST /Cidades/Adicionar
        [HttpPost]
        public IActionResult Adicionar(Cidades cidade)
        {
            if(ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        //GET /Cidades/Editar
        public IActionResult Editar(long id)
        {
            var cidadef = from c in db.Cidades select c;
            cidadef = cidadef.Where(x => x.IDCidade == id);
            Cidades cidade = cidadef.First();

            return View(cidade);
        }

        //POST /Cidades/Editar
        [HttpPost]
        public IActionResult Editar(Cidades cidade)
        {
            if(ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        //POST /Cidades/Excluir
        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                var cidadef = from c in db.Cidades select c;
                cidadef = cidadef.Where(x => x.IDCidade == id);
                Cidades cidade = cidadef.First();

                db.Cidades.Remove(cidade);
                db.SaveChanges();
                return Boolean.TrueString;

            }
            catch
            {
                return Boolean.FalseString;
            }

        }
    }
}
